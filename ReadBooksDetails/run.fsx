#load "../FunctionPattern.fsx"

#load "../Utils.fsx"
#load "../JsonConverter.fsx"
#load "GenresList.fsx"
#load "LanguageMap.fsx"

open Microsoft.Azure.WebJobs.Host
open System.Net.Http
open FunctionPattern
open Utils
open Newtonsoft.Json
open JsonConverter
open GoodreadsApi
open GenresList
open LanguageMap

type BookDetail =
    { Id : int
      Genres : string[]
      OriginalPublicationYear : int option
      Language : string option }

let intersect col1 col2 =
    Set.intersect (Set.ofArray col1) (Set.ofArray col2) |> Set.toArray

let genres (d:Model.BookDetail) =
    let shelves = d.PopularShelves |> Seq.map (fun (s,c) -> s) |> Seq.toArray
    intersect shelves goodreadsGenres

let getDetails req =
    let perPage = queryValue req "perPage" |> int
    let pageNumber = queryValue req "page" |> int
    
    let accessData = accessData req
    let user = GoodreadsApi.getUser accessData
    let reviews = getReviewsOnPage accessData user.Id "read" "date_read" perPage pageNumber
    
    let bookId (r:Model.Review) = r.Book.Id 
    let detail = getBookDetail accessData
    let createDetail (d:Model.BookDetail) = 
        { Id = d.Id; 
          Genres = genres d; 
          OriginalPublicationYear = d.Work.OriginalPublicationYear
          Language = language d.LaguageCode}

    let details = reviews.Reviews |> Seq.map (bookId >> detail >> createDetail) |> Seq.toArray
    JsonConvert.SerializeObject(details, JsonConverter())

let Run(req, log) =    
    azureFunction req log getDetails
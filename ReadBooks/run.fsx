#load "../FunctionPattern.fsx"

#load "../Utils.fsx"
#load "../JsonConverter.fsx"

open System
open Microsoft.Azure.WebJobs.Host
open System.Net.Http
open FunctionPattern
open Newtonsoft.Json
open Utils
open GoodreadsApi
open JsonConverter

type ReadData =
    { ReadAt : DateTime
      StartedAt : DateTime }

type ReadBook = 
    { ReadData : ReadData option
      NumPages : int
      BookTitle : string
      AuthorName : string
      ReviewId : int 
      Shelves : string[] 
      SmallImageUrl : string
      BookId : int }

let shelves (r : Model.Review) = 
    r.Shelves 
    |> Seq.filter (fun s -> not s.Exclusive) 
    |> Seq.map (fun s -> s.Name) 
    |> Seq.toArray

let createBook (r : Model.Review) = 
    let author = r.Book.Authors |> Seq.head
    let readData = 
        match (r.ReadAt, r.StartedAt) with
        | (Some readAt, Some startedAt) -> Some { ReadData.StartedAt = startedAt;  ReadAt = readAt }
        | (_, _) -> None
        
    { ReadData = readData
      NumPages = 
        match r.Book.NumPages with
        | Some numPages -> numPages
        | None -> 0
      BookTitle = r.Book.Title
      AuthorName = author.Name
      ReviewId = r.Id 
      Shelves = shelves r 
      SmallImageUrl = r.Book.SmallImageUrl
      BookId = r.Book.Id }

let getReviews req =
    let perPage = queryValue req "perPage" |> int
    let pageNumber = queryValue req "page" |> int

    let accessData = accessData req    
    let user = getUser accessData

    let reviews = getReviewsOnPage accessData user.Id "read" "date_read" perPage pageNumber
    
    let readBooks = 
        reviews.Reviews
        |> Seq.map createBook
        |> Seq.toArray
    
    JsonConvert.SerializeObject(readBooks, JsonConverter())

let Run(req, log) =    
    azureFunction req log getReviews
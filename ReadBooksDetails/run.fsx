#load "../FunctionPattern.fsx"

#load "../Utils.fsx"
#load "../JsonConverter.fsx"

open Microsoft.Azure.WebJobs.Host
open System.Net.Http
open FunctionPattern
open Utils
open Newtonsoft.Json
open JsonConverter
open GoodreadsApi

type BookDetail =
    { Id : int
      Shelves : string[] }

let getDetails (log:TraceWriter) req =

    let perPage = queryValue req "perPage" |> int
    let pageNumber = queryValue req "page" |> int
    
    let accessData = accessData req
    let user = GoodreadsApi.getUser accessData
    let reviews = getReviewsOnPage accessData user.Id "read" "date_read" perPage pageNumber
    
    let bookId (r:Model.Review) = r.Book.Id 
    let detail id=
        getBookDetail accessData id
    let createDetail (d:Model.BookDetail ) = { Id = d.Id; Shelves = d.PopularShelves |> Seq.map (fun (s,c) -> s) |> Seq.toArray }

    let details = reviews.Reviews |> Seq.map (bookId >> detail >> createDetail) |> Seq.toArray
    JsonConvert.SerializeObject(details, JsonConverter())

let Run(req, log) =    
    azureFunction req log (getDetails log)
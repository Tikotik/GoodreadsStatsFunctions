#load "../FunctionPattern.fsx"

#r "Microsoft.Azure.WebJobs.Host"
#r "System.Net.Http"
#r "System.Web.Http"

#load "../Configuration.fsx"
#load "JsonConverter.fsx"

open System
open Microsoft.Azure.WebJobs.Host
open System.Net.Http
open Configuration
open FunctionPattern
open Newtonsoft.Json

open GoodreadsApi
open JsonConverter

type ReadData=
    { ReadAt : DateTime
      StartedAt : DateTime}

type ReadBook = 
    { ReadData : ReadData option
      NumPages : int
      BookTitle : string
      AuthorName : string
      ReviewId : int }

let createBook (r : Model.Review) = 
    let author = r.Book.Authors |> Seq.head
    let readData = 
        match (r.ReadAt, r.StartedAt) with
        | (Some readAt, Some startedAt) -> Some {ReadData.StartedAt = startedAt;  ReadAt = readAt }
        | (_, _) -> None
        
    { ReadData = readData
      NumPages = 
        match r.Book.NumPages with
        | Some numPages -> numPages
        | None -> 0
      BookTitle = r.Book.Title
      AuthorName = author.Name
      ReviewId = r.Id }

let getReviews (req: HttpRequestMessage)=
    let queryValue key = 
        let pair = req.GetQueryNameValuePairs() |> Seq.find (fun q -> q.Key = key)
        pair.Value
    let token = queryValue "token"
    let tokenSecret = queryValue "tokenSecret"
    
    let perPage = queryValue "perPage" |> int
    let pageNumber = queryValue "page" |> int

    let accessData = getAccessData clientKey clientSecret token tokenSecret
    
    let user = getUser accessData

    let reviews = getReviewsOnPage accessData user.Id "read" "date_read" perPage pageNumber
    
    let readBooks = 
        reviews.Reviews
        |> Seq.map createBook
        |> Seq.toArray
    
    JsonConvert.SerializeObject(readBooks, JsonConverter())

let Run(req: HttpRequestMessage, log: TraceWriter) =    
    azureFunction req log getReviews
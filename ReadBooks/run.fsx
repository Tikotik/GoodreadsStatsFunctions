#r "System.Net.Http"
#r "Newtonsoft.Json"

#load "JsonConverter.fsx"
#load "../Configuration.fsx"

open System
open System.Net
open Configuration
open GoodreadsApi
open Newtonsoft.Json
open System.Configuration
open Model
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

let createBook (r : Review) = 
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

let Run(req: HttpRequestMessage, log: TraceWriter) =    
    async {
        try    
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
            
            let result = JsonConvert.SerializeObject(readBooks, JsonConverter())

            return req.CreateResponse(HttpStatusCode.OK, result)
        with
        | e ->
            log.Info(sprintf "Failed: %s" (e.ToString())) 
            return req.CreateResponse(HttpStatusCode.OK, e.ToString())
    } |> Async.RunSynchronously

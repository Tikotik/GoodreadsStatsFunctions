#r "System.Net.Http"
#r "Newtonsoft.Json"

#load "JsonConverter.fsx"

open System
open System.Net
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
      AuthorName : string}

let reviews accessData = 
    let user = getUser accessData
    getAllReviews accessData user.Id "read" "date_read"

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
      AuthorName = author.Name}

let Run(req: HttpRequestMessage, log: TraceWriter) =    
    async {
        try 
            let clientKey = ConfigurationManager.AppSettings.["clientKey"]
            let clientSecret = ConfigurationManager.AppSettings.["clientSecret"]
            
            let queryValue key = 
                let pair = req.GetQueryNameValuePairs() |> Seq.find (fun q -> q.Key = key)
                pair.Value
            let token = queryValue "token"
            let tokenSecret = queryValue "tokenSecret"

            let accessData = getAccessData clientKey clientSecret token tokenSecret
            
            let reviews = reviews accessData |> Seq.toArray
            
            let readBooks = 
                reviews
                |> Seq.map createBook
                |> Seq.toArray
            
            let result = JsonConvert.SerializeObject(readBooks, JsonConverter())

            return req.CreateResponse(HttpStatusCode.OK, result)
        with
        | e ->
            log.Info(sprintf "Failed: %s" (e.ToString())) 
            return req.CreateResponse(HttpStatusCode.OK, e.ToString())
    } |> Async.RunSynchronously

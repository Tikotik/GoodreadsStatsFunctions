#r "System.Net.Http"
#r "Newtonsoft.Json"

#load "../Model.fsx"

open System
open System.Net
open GoodreadsApi
open GoodreadsStats.Model
open Newtonsoft.Json
open System.Configuration
open Model

type ReadBook = 
    { ReadAt : DateTime option
      StartedAt : DateTime option
      NumPages : int option
      BookTitle : string
      AuthorName : string}

let reviews accessData = 
    let user = getUser accessData
    getAllReviews accessData user.Id "read" "date_read"

let createBook (r : Review) = 
    let author = r.Book.Authors |> Seq.head
    { ReadAt = r.ReadAt
      StartedAt = r.StartedAt
      NumPages = r.Book.NumPages
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
            
            let result = JsonConvert.SerializeObject  readBooks

            return req.CreateResponse(HttpStatusCode.OK, result)
        with
        | e ->
            log.Info(sprintf "Failed: %s" (e.ToString())) 
            return req.CreateResponse(HttpStatusCode.OK, e.ToString())
    } |> Async.RunSynchronously

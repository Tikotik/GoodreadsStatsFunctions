#r "System.Net.Http"
#r "Newtonsoft.Json"

#load "../Model.fsx"
#load "BasicStatsCalculator.fsx"

open System.Net
open GoodreadsApi
open GoodreadsStats.Model
open Newtonsoft.Json
open System.Configuration
open BasicStatsCalculator

let reviews accessData = 
    let user = getUser accessData
    getAllReviews accessData user.Id "read" "date_read"

let createBook (r : Reviews.Review) = 
    { ReadAt = parseOptionDate r.ReadAt
      StartedAt = parseOptionDate r.StartedAt
      NumPages = r.Book.NumPages
      Book = 
          { Title = r.Book.Title
            Author = r.Book.Author.Name } }

let Run(req: HttpRequestMessage, log: TraceWriter) =
    let clientKey = ConfigurationManager.AppSettings.["clientKey"]
    let clientSecret = ConfigurationManager.AppSettings.["clientSecret"]

    async {

        try 
            let queryValue key = 
                let pair = req.GetQueryNameValuePairs() |> Seq.find (fun q -> q.Key = key)
                pair.Value
            let token = queryValue "token"
            let tokenSecret = queryValue "tokenSecret"

            let accessData = getAccessData clientKey clientSecret token tokenSecret
            
            let reviews = reviews accessData
            
            let readBooks = 
                reviews
                |> Seq.map createBook
                |> Seq.toArray
            
            let result = JsonConvert.SerializeObject  (basicStats readBooks)

            return req.CreateResponse(HttpStatusCode.OK, result)
        with
        | e ->
            log.Info(sprintf "chyba: %s" (e.ToString())) 
            return req.CreateResponse(HttpStatusCode.OK, e.ToString())
    } |> Async.RunSynchronously

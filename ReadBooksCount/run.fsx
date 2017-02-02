#r "System.Net.Http"
#r "Newtonsoft.Json"

#load "../Configuration.fsx"

open System
open System.Net
open Configuration
open GoodreadsApi
open System.Configuration
open Model

let getReviewsCount accessData = 
    let user = getUser accessData

    getReviewsCount accessData user.Id "read"


let Run(req: HttpRequestMessage, log: TraceWriter) =    
    async {
        try    
            let queryValue key = 
                let pair = req.GetQueryNameValuePairs() |> Seq.find (fun q -> q.Key = key)
                pair.Value
            let token = queryValue "token"
            let tokenSecret = queryValue "tokenSecret"

            let accessData = getAccessData clientKey clientSecret token tokenSecret
            
            return req.CreateResponse(HttpStatusCode.OK, (getReviewsCount accessData))
        with
        | e ->
            log.Info(sprintf "Failed: %s" (e.ToString())) 
            return req.CreateResponse(HttpStatusCode.OK, e.ToString())
    } |> Async.RunSynchronously

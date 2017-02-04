#load "../FunctionPattern.fsx"

#r "Microsoft.Azure.WebJobs.Host"
#r "System.Net.Http"
#r "System.Web.Http"
#r "Newtonsoft.Json"

#load "../Configuration.fsx"

open Microsoft.Azure.WebJobs.Host
open System.Net.Http
open Configuration
open FunctionPattern

open GoodreadsApi

let getReviewsCount (req: HttpRequestMessage)=
    let queryValue key = 
        let pair = req.GetQueryNameValuePairs() |> Seq.find (fun q -> q.Key = key) 
        pair.Value
        
    let token = queryValue "token"
    let tokenSecret = queryValue "tokenSecret"

    let accessData = getAccessData clientKey clientSecret token tokenSecret
    let user = getUser accessData

    getReviewsCount accessData user.Id "read"

let Run(req: HttpRequestMessage, log: TraceWriter) =    
    azureFunction req log getReviewsCount
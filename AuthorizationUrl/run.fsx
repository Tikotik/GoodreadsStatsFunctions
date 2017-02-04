#load "../FunctionPattern.fsx"

#r "Microsoft.Azure.WebJobs.Host"
#r "System.Net.Http"
#r "System.Web.Http"

#load "../Configuration.fsx"

open Microsoft.Azure.WebJobs.Host
open System.Net.Http
open Configuration
open FunctionPattern
open Newtonsoft.Json

open GoodreadsApi

type AuthorizationUserData = 
    { Token : string
      TokenSecret : string
      Url : string }

let getAuthorizationUrl (req: HttpRequestMessage) =
    let queryValue key= 
        let pair = req.GetQueryNameValuePairs() |> Seq.find (fun q -> q.Key = key)
        pair.Value

    let clientSideUrl = queryValue "clientSideUrl"

    let (authorizationUrl, token, tokenSecret) = getAuthorizationData clientKey clientSecret clientSideUrl
    JsonConvert.SerializeObject { Token = token; TokenSecret = tokenSecret; Url = authorizationUrl}
    

let Run(req: HttpRequestMessage, log: TraceWriter) =
    azureFunction req log getAuthorizationUrl
#r "System.Net.Http"
#r "Newtonsoft.Json"

#load "../Model.fsx"

open System.Net
open GoodreadsApi
open GoodreadsStats.Model
open Newtonsoft.Json
open System.Configuration

let Run(req: HttpRequestMessage, log: TraceWriter) =
    async {
        let clientKey = ConfigurationManager.AppSettings.["clientKey"]
        let clientSecret = ConfigurationManager.AppSettings.["clientSecret"]

        let queryValue key = 
            let pair = req.GetQueryNameValuePairs() |> Seq.find (fun q -> q.Key = key)
            pair.Value
        
        let clientSideUrl = queryValue "clientSideUrl"

        let (authorizationUrl, token, tokenSecret) = getAuthorizationData clientKey clientSecret clientSideUrl
        let result = JsonConvert.SerializeObject { Token = token; TokenSecret = tokenSecret; Url = authorizationUrl}
        log.Info(authorizationUrl)

        return req.CreateResponse(HttpStatusCode.OK, result)
    } |> Async.RunSynchronously

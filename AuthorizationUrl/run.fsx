#r "System.Net.Http"
#r "Newtonsoft.Json"

#load "../Model.fsx"

open System.Net
open GoodreadsApi
open GoodreadsStats.Model
open Newtonsoft.Json
open System.Configuration

let clientSideUrl = "http://localhost:1234" 

let Run(req: HttpRequestMessage, log: TraceWriter) =
    let clientKey = ConfigurationManager.AppSettings.["clientKey"]
    let clientSecret = ConfigurationManager.AppSettings.["clientSecret"]

    async {
        let (authorizationUrl, token, tokenSecret) = getAuthorizationData clientKey clientSecret clientSideUrl
        let result = JsonConvert.SerializeObject { Token = token; TokenSecret = tokenSecret; Url = authorizationUrl}
        log.Info(authorizationUrl)

        return req.CreateResponse(HttpStatusCode.OK, result)
    } |> Async.RunSynchronously

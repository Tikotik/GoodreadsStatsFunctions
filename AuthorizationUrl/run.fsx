#r "System.Net.Http"
#r "Newtonsoft.Json"

#load "../Configuration.fsx"

open System.Net
open Configuration
open GoodreadsApi
open Newtonsoft.Json
open System.Configuration

type AuthorizationUserData = 
    { Token : string
      TokenSecret : string
      Url : string }

let Run(req: HttpRequestMessage, log: TraceWriter) =
    async {
        let queryValue key = 
            let pair = req.GetQueryNameValuePairs() |> Seq.find (fun q -> q.Key = key)
            pair.Value
        
        let clientSideUrl = queryValue "clientSideUrl"

        let (authorizationUrl, token, tokenSecret) = getAuthorizationData clientKey clientSecret clientSideUrl
        let result = JsonConvert.SerializeObject { Token = token; TokenSecret = tokenSecret; Url = authorizationUrl}
        log.Info(authorizationUrl)

        return req.CreateResponse(HttpStatusCode.OK, result)
    } |> Async.RunSynchronously

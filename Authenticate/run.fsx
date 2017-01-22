#r "System.Net.Http"
#r "Newtonsoft.Json"

#load "../Configuration.fsx"

open System.Net
open GoodreadsApi
open Configuration
open Newtonsoft.Json
open System.Configuration

type LoggedUserData = 
    { AccessToken : string
      AccessTokenSecret : string
      UserName : string}

let Run(req: HttpRequestMessage, log: TraceWriter) =
    async {
        let queryValue key = 
            let pair = req.GetQueryNameValuePairs() |> Seq.find (fun q -> q.Key = key)
            pair.Value
        let token = queryValue "token"
        let tokenSecret = queryValue "tokenSecret"
 
        let (token, tokenSecret) = getAccessToken clientKey clientSecret token tokenSecret
        let accessData = getAccessData clientKey clientSecret token tokenSecret
        let user = getUser accessData
        let result = JsonConvert.SerializeObject { AccessToken = token; AccessTokenSecret = tokenSecret; UserName = user.Name }

        return req.CreateResponse(HttpStatusCode.OK, result)
    } |> Async.RunSynchronously

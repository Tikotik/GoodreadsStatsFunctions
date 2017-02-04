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

type LoggedUserData = 
    { AccessToken : string
      AccessTokenSecret : string
      UserName : string}

let autheticate (req: HttpRequestMessage)=
    let queryValue key = 
        let pair = req.GetQueryNameValuePairs() |> Seq.find (fun q -> q.Key = key)
        pair.Value
    let token = queryValue "token"
    let tokenSecret = queryValue "tokenSecret"

    let (token, tokenSecret) = getAccessToken clientKey clientSecret token tokenSecret
    let accessData = OAuth.getAccessData clientKey clientSecret token tokenSecret
    let user = getUser accessData
    JsonConvert.SerializeObject { AccessToken = token; AccessTokenSecret = tokenSecret; UserName = user.Name }

let Run(req: HttpRequestMessage, log: TraceWriter) =
    azureFunction req log autheticate
#load "../FunctionPattern.fsx"

#load "../Utils.fsx"
#load "../Configuration.fsx"

open Configuration
open FunctionPattern
open Newtonsoft.Json
open Utils

open GoodreadsApi

type LoggedUserData = 
    { AccessToken : string
      AccessTokenSecret : string
      UserName : string}

let autheticate req =
    let token = queryValue req "token"
    let tokenSecret = queryValue req "tokenSecret"

    let (token, tokenSecret) = getAccessToken clientKey clientSecret token tokenSecret
    let accessData = OAuth.getAccessData clientKey clientSecret token tokenSecret
    let user = getUser accessData
    JsonConvert.SerializeObject { AccessToken = token; AccessTokenSecret = tokenSecret; UserName = user.Name }

let Run(req, log) =
    azureFunction req log autheticate
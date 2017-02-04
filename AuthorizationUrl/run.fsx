#load "../FunctionPattern.fsx"

#load "../Utils.fsx"
#load "../Configuration.fsx"

open Configuration
open FunctionPattern
open Newtonsoft.Json
open Utils

open GoodreadsApi

type AuthorizationUserData = 
    { Token : string
      TokenSecret : string
      Url : string }

let getAuthorizationUrl req =
    let clientSideUrl = queryValue req "clientSideUrl"

    let (authorizationUrl, token, tokenSecret) = getAuthorizationData clientKey clientSecret clientSideUrl
    JsonConvert.SerializeObject { Token = token; TokenSecret = tokenSecret; Url = authorizationUrl}

let Run(req, log) =
    azureFunction req log getAuthorizationUrl
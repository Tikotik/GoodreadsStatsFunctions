#load "FunctionPattern.fsx"
#load "Configuration.fsx"

#r "System.Web.Http"

open System.Net.Http
open FunctionPattern

open GoodreadsApi
open Configuration

let queryValue (req: HttpRequestMessage) key = 
    let pair = req.GetQueryNameValuePairs() |> Seq.find (fun q -> q.Key = key) 
    pair.Value
        
let accessData req =
    let token = queryValue req "token"
    let tokenSecret = queryValue req "tokenSecret"
    getAccessData clientKey clientSecret token tokenSecret
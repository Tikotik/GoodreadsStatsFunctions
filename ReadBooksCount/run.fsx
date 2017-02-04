#load "../FunctionPattern.fsx"

#load "../Utils.fsx"

open Microsoft.Azure.WebJobs.Host
open System.Net.Http
open FunctionPattern
open Utils

let getReviewsCount req =
    let accessData = accessData req
    let user = GoodreadsApi.getUser accessData
    GoodreadsApi.getReviewsCount accessData user.Id "read"

let Run(req, log) =    
    azureFunction req log getReviewsCount
#if INTERACTIVE
//TODO: Better...
#I "C:/Users/MV/AppData/Roaming/npm/node_modules/azure-functions-cli/bin"
#I "C:/Users/MV/.nuget/packages/"

#r "mveith.oauth/1.0.0/lib/net46/OAuth.dll"
#r "mveith.goodreadsapi/0.5.0/lib/net46/GoodreadsApi.dll"
#r "newtonsoft.json/9.0.1/lib/net45/Newtonsoft.Json.dll"
#endif

#r "System.Net.Http.dll"
#r "Microsoft.Azure.WebJobs.Host.dll"

open System
open System.Net.Http
open Microsoft.Azure.WebJobs.Host

let azureFunction (req: HttpRequestMessage) (log: TraceWriter) getResult=
     async 
        {
            try    
                let result = getResult req
                return result.ToString()
            with
            | e ->
                log.Info(sprintf "Failed: %s" (e.ToString())) 
                return (e.ToString())
        } |> Async.RunSynchronously

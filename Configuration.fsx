#r "System.Configuration"

open System.Configuration

let clientKey = ConfigurationManager.AppSettings.["clientKey"]
let clientSecret = ConfigurationManager.AppSettings.["clientSecret"]
let languagesFile = """D:\home\site\wwwroot\Languages.txt"""
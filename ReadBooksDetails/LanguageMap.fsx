#load "../Configuration.fsx"

open System.Globalization
open Configuration

let parseLine (line:string) =
    let parts = line.Split '|'
    (parts.[0], parts.[1])

let languageMap =
    System.IO.File.ReadAllLines languagesFile
    |> Seq.map parseLine
    |> dict

let languageFromCulture (code:string) =
    try
        let unknownCultureLCID = 4096
        let ci = new CultureInfo(code)
        if ci.LCID = unknownCultureLCID then None else Some ci.EnglishName
    with
    | _ -> None
let language code =    
    if System.String.IsNullOrEmpty code then None
    else 
        if languageMap.ContainsKey code then Some (languageMap.Item code) 
        else languageFromCulture code
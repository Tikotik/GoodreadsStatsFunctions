namespace GoodreadsStats.Model

open System

type AuthorizationUserData = 
    { Token : string
      TokenSecret : string
      Url : string }

type LoggedUserData = 
    { AccessToken : string
      AccessTokenSecret : string
      UserName : string}

type ReadData=
    { ReadAt : DateTime
      StartedAt : DateTime}

type ReadBook = 
    { ReadData : ReadData option
      NumPages : int
      BookTitle : string
      AuthorName : string}

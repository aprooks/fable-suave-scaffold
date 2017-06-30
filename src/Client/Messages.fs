module Client.Messages

open System
open ServerCode.Domain

type Auth0User = 
    {
        AccessToken: string
        Name       : string
        Email      : string
        Picture    : string
        UserId     : string
    }

/// The messages processed during login 
type LoginMsg =
  | GetTokenSuccess of string
  | SetUserName of string
  | SetPassword of string
  | AuthError of exn
  | ClickLogIn

/// The different messages processed when interacting with the wish list
type WishListMsg =
  | LoadForUser of string
  | FetchedWishList of WishList
  | RemoveBook of Book
  | AddBook
  | TitleChanged of string
  | AuthorsChanged of string
  | LinkChanged of string
  | FetchError of exn

/// The different messages processed by the application
type AppMsg = 
  | LoggedIn
  | LoggedOut
  | StorageFailure of exn
  | OpenLogIn
  | LoginMsg of LoginMsg
  | WishListMsg of WishListMsg
  | Logout
  | ShowLogin
  | Logout0
  | LoggedIn0
  | LoggedOut0
  | ProfileLoaded of Auth0User


/// The user data sent with every message.
type UserData = 
  { UserName : string 
    Token : JWT }

/// The different pages of the application. If you add a new page, then add an entry here.
type Page = 
  | Home 
  | Login
  | WishList
  | LoginAuth

let toHash =
  function
  | Home -> "#home"
  | Login -> "#login"
  | WishList -> "#wishlist"
  | LoginAuth -> "#loginauth"
  

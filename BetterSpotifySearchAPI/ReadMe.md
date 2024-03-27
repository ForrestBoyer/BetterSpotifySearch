# Better Spotify Search API
UMASS Lowell Spring 2024
COMP 4120  
___
## How to Run Independently:
    dotnet run

**Will fail unless both [.NET 7.0 Runtime AND ASP.NET Core Runtime 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) are downloaded** 
(SDK 7.0 Contains Both)
___
## Current Endpoints:
### Authentication
    http://localhost:40080/api/SpotifyAuthentication/Register
**REQUIRES A VALID [SPOTIFY DEVELOPER ACCOUNT](https://developer.spotify.com/)** 

**Register MUST be run before Song/Search or Artist/Search**

*Currently run by opening in browser*
### Songs
**Search by Name:**

    GET http://localhost:40080/api/Song/Search/{{SongName}}
Params: string SongName (REQUIRED)  
*Returns [Spotify Track Objects](https://developer.spotify.com/documentation/web-api/reference/get-track)*  
*\*URL Variables Must Be Percent Encoded*

**Get Song Features:**

    GET http://localhost:40080/api/Song/Features/{{SongID}}
Params: string SongID (REQUIRED)  
*Returns [Song Features (See Bottom)](##Features)*

**Search by Features:**

    GET http://localhost:40080/api/Song/SearchBy?{{FeatureName}}={{Feature}}&...
e.g.:
```GET http://localhost:40080/api/Song/SearchBy?min_danceability=0.1&max_dancibility=0.3```  
Params: string seed\_artists, string seed\_genres, string seed\_songs, min\_, max\_, or target\_ [Features](##Features) (AT LEAST ONE CRITERIA REQUIRED)  
*Returns [Spotify Track Objects](https://developer.spotify.com/documentation/web-api/reference/get-track)* 
### Artists
**Search by Name:**

    GET http://localhost:40080/api/Artist/Search/{{ArtistName}}
Params: string ArtistName (REQUIRED)  
*Returns [Spotify Artist Objects](https://developer.spotify.com/documentation/web-api/reference/get-an-artist)*  
*\*URL Variables Must Be Percent Encoded*

### Testing Endpoints
Access Service Testing:

#### Authentication Controller Test:

    POST http://localhost:40080/api/SpotifyAuthentication/SharedServiceTest/{{testToken}}
Returns testToken  
*\*URL Variables Must Be Percent Encoded*
    
#### Song Controller Test:

    GET http://localhost:40080/api/Song/SharedServiceTest
Returns testToken if run after AuthController test
    
#### Artist Controller Test:

    GET http://localhost:40080/api/Artist/SharedServiceTest
Returns testToken if run after AuthController test

## Features
**Acousticness:** Float from `0 - 1`  
**Danceability:** Float from `0 - 1`  
**Duration:** Integer
**Energy:** Float from `0 - 1`  
**Instrumentalness:** Float from `0 - 1`  
**Key:** Integer from `-1 - 11`  
**Liveness:** Float from `0 - 1`  
**Loudness:** Float from `0 - 1`  
**Mode:** Integer, either `0` or `1`  
**Speechiness:** Float from `0 - 1`  
**Tempo:** Float  
**Time_Signature:** Integer from `3 - 7`  
**Valence:** Float from `0 - 1`

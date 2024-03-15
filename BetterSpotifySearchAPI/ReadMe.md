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

**Register MUST be run before Song/Songs or Artist/Artists**

*Currently run by opening in browser*
### Songs
Searches for songs:

    GET http://localhost:40080/api/Song/Songs/{{SongName}}
*\*URL Variables Must Be Percent Encoded*

### Artists
Searches for Artists:

    GET http://localhost:40080/api/Artist/Artists/{{ArtistName}}
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

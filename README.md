# Better Spotify Search 
UMASS Lowell Spring 2024
COMP 4120  
___
How to Run:
- Visit *final-website-link*
___
Project Description:  
- Spotify is a digital audio streaming service that offers songs, podcasts, and playlists for
users to create, discover, and listen to. Spotify’s search feature allows for easy
exploration of music; however, it has limited options when it comes to searching for the right
songs. Better Spotify Search is an app designed to expand the search functionality within the
Spotify application. A look into the Spotify API, reveals hidden characteristics that are stored for each song.
Spotify tracks information such as danceability, energy, song key, loudness, acoustic value,
valence, tempo, time signature, and more. Every single song on Spotify has this data associated
with it. However, users are unable to search for this information directly. Our project intends to add these 
hidden features as additional options to the Spotify search query. Better Spotify Search
offers advanced features such as, allowing users to manually search for songs based off hidden song information,
and providing similar songs based off an input song. 
___
Dependencies:
- Nvm
- Node.js version 16.10.0
- Angular version 13.0.1
- Angular Material
___
How to Install Dependencies:  
1. Clone repository.
2. Install nvm: https://github.com/coreybutler/nvm-windows/releases.
4. Run: ```nvm install 16.10.0```.
5. Run: ```nvm use 16.10.0```.
6. Run: ```node -v``` and ensure the current version is 16.10.0.
7. Run: ```npm install -g @angular/cli@13.0.1```.
8. If building the project results in an error about angular node modules, Run: ```npm uninstall -g @angular/cli@13.0.1```,  navigate to ```./BetterSpotifySearch/BetterSpotifySearch``` and Run: ```npm install @angular/cli@13.0.1``` inside the repository.
9. Run: ```ng version``` and ensure no compatibility issues have arose.
10. Run: ```ng add @angular/material```, and when prompted, select ```indigo/pink```, ```yes```, ```yes```.
___
How to Build on Local Machine and Run Tests:  
1. Navigate to ```./BetterSpotifySearch/BetterSpotifySearch```
2. Run: ```npm start```
3. This will run all tests, and lauch the front-end and back-end
4. The front-end can be accessed by visiting ```http://localhost:4200/```
5. The back-end can be accessed by visiting ```http://localhost:40080/```
___
Development Tools Used:
- Angular / Angular Material - Front-end design
- Node.js - Front-end hosting
- Asp.net - Back-end
- SpotifyAPI-net - C# client for Spotify API
- Spotify API
- xUnit - Unit testing
- VSCode - Code editor and debugger
- Github - Version control
___
Sources:
- https://open.spotify.com/
- https://developer.spotify.com/documentation/web-api
- https://dotnet.microsoft.com/en-us/apps/aspnet
- https://johnnycrazy.github.io/SpotifyAPI-NET/
- https://angular.io/
- https://material.angular.io/
- https://github.com/coreybutler/nvm-windows/releases
___
Github Repository:
- https://github.com/ForrestBoyer/BetterSpotifySearch

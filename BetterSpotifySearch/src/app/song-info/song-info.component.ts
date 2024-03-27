import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-song-info',
  templateUrl: './song-info.component.html',
  styleUrls: ['./song-info.component.scss']
})
export class SongInfoComponent implements OnInit {
  public songName?: string;
  public songID?: number;

  constructor() { }

  ngOnInit(): void {
  }

  setSongName(event: any): void {
    // Called from html on input (don't know how to pass event into here)
    this.songName = event.target.value;
    console.log("Song name set", this.songName);
  }

  searchSongInfo(): void {
    // api call for song 
    // run register: http://localhost:40080/api/SpotifyAuthentication/Register
    // GET http://localhost:40080/api/Song/Search/{{songName}}
    // GET http://localhost:40080/api/Song/Features/{{songID}}
    console.log("Song info request: ", this.songName);
  }

}







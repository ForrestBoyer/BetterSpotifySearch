import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { SongNameIdService } from '../song-name-id.service';

@Component({
  selector: 'app-song-info',
  templateUrl: './song-info.component.html',
  styleUrls: ['./song-info.component.scss'],
})
export class SongInfoComponent implements OnInit {
  public songName?: string;
  public songInfo?: string;
  public songID?: string;

  constructor(
    protected http: HttpClient, 
    private nameID:SongNameIdService
  ) { }

  ngOnInit(): void {
  }

  setSongName(event: any): void {
    this.songName = event.target.value;
    console.log("Song name set", this.songName);
  }

  searchSongInfo(): void {
    // api call for song search
    // GET http://localhost:40080/api/Song/Search/{{songName}}
    console.log("Song info request: ", this.songName)
    var url = ("api/song/search/"+this.songName);

    this.http.get<string>(url).subscribe(result => 
      {
        this.songInfo = result;
        console.log(this.songInfo);
      }, error => console.error(error));
    // *** TO DO: Parse string to get returned song name and song id ***

    // Pass song name and ID to info results page through service
    this.nameID.setSongId(this.songID);
    this.nameID.setSongName(this.songName);
  }
}







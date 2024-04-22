import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SongNameIdService } from '../song-name-id.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-similar-search',
  templateUrl: './similar-search.component.html',
  styleUrls: ['./similar-search.component.scss']
})
export class SimilarSearchComponent implements OnInit {
  public songInfo?: string;
  public songName?: string;
  public songID?: string;
  public songLink?: string;
  public parse?: any

  constructor(protected http: HttpClient, 
              private nameID: SongNameIdService,
              private router: Router) { }

  ngOnInit(): void {
    
  }

  setSongName(event: any): void {
    this.songName = event.target.value;
    console.log("Song Name: ", this.songName);
  }

  searchSimilarSongs()
  {
    /*
      1. Get song
      2. Search with that song to get its info
      3. Search again with that info, using the options the user selected
      4. Route to show that data
    */
  }

  searchSimilarSongs() {
    // api call for song search
    // GET http://localhost:40080/api/Song/Search/{{songName}}
    console.log("Song info request: ", this.songName)
    var url = this.createUrl();

    this.http.get<string>(url).subscribe(result => 
      {
        // *** Parse string to get returned song id ***
        this.songInfo = result;
        this.parse = JSON.stringify(this.songInfo);
        this.parse = JSON.parse(this.parse);
        this.songID = this.parse["tracks"]["items"]["0"]["id"];
        this.songName = this.parse["tracks"]["items"]["0"]["name"];
        this.songLink = this.parse["tracks"]["items"]["0"]["external_urls"]["spotify"];

        // Pass song name and ID to info results page through service
        this.nameID.setSongId(this.songID);
        this.nameID.setSongName(this.songName);
        this.nameID.setSongLink(this.songLink);
        this.router.navigateByUrl('/info-results')

        console.log(this.songInfo);
        // console.log("Parse: ", this.parse);
        // console.log("Parsed Song ID: ", this.songID);
      }, error => console.error(error));
  }

  createUrl(): string {
    var url:string = "api/song/searchby/";


  }
}

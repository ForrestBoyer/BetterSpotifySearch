import { Component, Input, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { SongNameIdService } from '../song-name-id.service';

@Component({
  selector: 'app-info-results',
  templateUrl: './info-results.component.html',
  styleUrls: ['./info-results.component.scss'],
})
export class InfoResultsComponent implements OnInit {
  public songName?: string;
  public songID?: string;
  public songFeatures?: string;
  public danceability?: number;
  public timeSignature?: number;
  public instrumentalValue?: number;
  public liveliness?: number;
  public loudness?: number;
  public mode?: number;
  public speechiness?: number;
  public acousticness?: number;
  public energy?: number;
  public valence?: number;
  public tempo?: number;
  public duration?: number;
  public genre?: string;

  constructor(
    protected http: HttpClient, 
    private nameId:SongNameIdService
  ) { 
      this.songID = this.nameId.getSongId();
      this.songName = this.nameId.getSongName(); 
    }

  ngOnInit(): void {
    console.log(this.songName);
    var url = ("api/song/features/"+this.songID);
    // api call for feature search
    // GET http://localhost:40080/api/Song/Features/{{songID}}
    this.http.get<string>(url).subscribe(result => 
      {
        this.songFeatures = result;
        console.log("Song features: ", this.songFeatures)
      }, error => console.error(error));
  }
}

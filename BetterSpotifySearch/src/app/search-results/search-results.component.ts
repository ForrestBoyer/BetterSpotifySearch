import { AfterContentInit, Component, Input, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { SongNameIdService } from '../song-name-id.service';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.scss'],
})
export class SearchResultsComponent implements OnInit {
  public songName?: string;
  public songID?: string;
  public songFeatures?: string;
  public parse?: any;
  public danceability?: number;
  public timeSignature?: number;
  public instrumentalValue?: number;
  public liveness?: number;
  public loudness?: number;
  public mode?: number;
  public speechiness?: number;
  public acousticness?: number;
  public energy?: number;
  public valence?: number;
  public tempo?: number;
  public duration?: number;
  public key?: string;
  public songLink?: string;

  constructor(
    protected http: HttpClient, 
    private nameId:SongNameIdService
  ) { 
    }

  ngOnInit(): void {
    this.songName = this.nameId.getSongName(); 
    this.songID = this.nameId.getSongId();
    this.songLink = this.nameId.getSongLink();

    // console.log("Results name: ", this.songName);
    // console.log("Results id: ", this.songID);

    var url = ("api/song/features/"+this.songID);
    // *** Hard coded test url for dreams - fleetwood mac, replace once id parse is complete ***
    // var testUrl = ("api/song/features/0ofHAoxe9vBkTCp2UQIavz");

    // api call for feature search
    // GET http://localhost:40080/api/Song/Features/{{songID}}
    this.http.get<string>(url).subscribe(result => 
      {
        this.songFeatures = result;
        console.log("Song features: ", this.songFeatures)

        // *** Parse string to get song features ***
        this.parse = JSON.stringify(this.songFeatures);
        this.parse = JSON.parse(this.parse);
        this.acousticness = this.parse.acousticness;
        this.danceability = this.parse.danceability;
        this.duration = this.parse.duration_ms;
        this.energy = this.parse.energy;
        this.instrumentalValue = this.parse.instrumentalness;
        this.key = this.parse.key;
        this.liveness = this.parse.liveness;
        this.loudness = this.parse.loudness;
        this.mode = this.parse.mode;
        this.speechiness = this.parse.speechiness;
        this.tempo = this.parse.tempo;
        this.timeSignature = this.parse.time_signature;
        this.valence = this.parse.valence;
      }, error => console.error(error));
  }
}

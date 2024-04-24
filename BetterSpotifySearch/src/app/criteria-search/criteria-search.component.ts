import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { SongNameIdService } from '../song-name-id.service';
import { Router } from '@angular/router';
import { Song, createDefaultSong } from '../objects/Song';

@Component({
  selector: 'app-criteria-search',
  templateUrl: './criteria-search.component.html',
  styleUrls: ['./criteria-search.component.scss']
})
export class CriteriaSearchComponent implements OnInit {
  public songResult?:any;
  public parse?:any;
  public danceability: number = 0;
  public timeSignature: number = 3;
  public instrumentalValue: number = 0;
  public liveness: number = 0;
  public loudness: number = -60;
  public mode: number = 0;
  public speechiness: number = 0;
  public acousticness: number = 0;
  public energy: number = 0;
  public valence: number = 0;
  public tempo: number = 0;
  public duration: number = 0;
  public durationSecs ?: number;
  public key: number = -1;
  public genre?: string;
  
  constructor(
    protected http: HttpClient, 
    private nameID: SongNameIdService,
    private router: Router,
  ) {}

  ngOnInit(): void {
  }

  criteriaSearch() {
    // api call for criteria search
    // GET http://localhost:40080/api/Song/SearchBy/{{params}}
    var url = this.createURL();

    this.http.get<string>(url).subscribe(result => 
      {
        // *** Parse string to get returned song id ***
        this.songResult = result;
        console.log(result);
        this.parse = JSON.stringify(this.songResult);
        this.parse = JSON.parse(this.parse);

        // Pass song name and ID to info results page through service
        this.nameID.setSongId(this.parse["tracks"]["0"]["id"]);
        this.nameID.setSongName(this.parse["tracks"]["0"]["name"]);
        this.nameID.setSongLink(this.parse["tracks"]["0"]["external_urls"]["spotify"]);
        this.router.navigateByUrl('/results')

      }, error => console.error(error));
  }

  createURL():string {
    var url:string = "api/song/SearchBy/";
    url = url + "?seed_genres=" + this.genre;
    url = url + "&target_acousticness=" + this.acousticness;
    url = url + "&target_danceability=" + this.danceability;
    url = url + "&target_duration=" + this.duration;
    url = url + "&target_energy=" + this.energy;
    url = url + "&target_instrumentalness=" + this.instrumentalValue;
    url = url + "&target_key=" + this.key;
    url = url + "&target_liveness=" + this.liveness;
    url = url + "&target_loudness=" + this.loudness;
    url = url + "&target_mode=" + this.mode;
    url = url + "&target_speechiness=" + this.speechiness;
    url = url + "&target_tempo=" + this.tempo;
    url = url + "&target_time_signature=" + this.timeSignature;
    url = url + "&target_valence=" + this.valence;
    return url;
  }

  setGenre(event: any) {
      this.genre = event.target.value;
  }

  setAcousticness(value: any) {
    this.acousticness = value.value;
  }
  setDanceability(value: any) {
    this.danceability = value.value;
  }
  setDuration(value: any) {
    this.duration = value.value;
    this.durationSecs = value.value;
    if (this.duration) {
      this.duration = this.duration * 1000;
    }
  }
  setEnergy(value: any) {
    this.energy = value.value;
  }
  setInstrumentalness(value: any) {
    this.instrumentalValue = value.value;
  } 
  setKey(value: any) {
    this.key = value.value;
  }
  setLiveness(value: any) {
    this.liveness = value.value;
  }
  setLoudness(value: any) {
    this.loudness = value.value;
  }
  setMode(value: any) {
    this.mode = value.value;
  }
  setSpeechiness(value: any) {
    this.speechiness = value.value;
  }
  setTempo(value: any) {
    this.tempo = value.value;
  }
  setTimeSignature(value: any) {
    this.timeSignature = value.value;
  }
  setValence(value: any) {
    this.valence = value.value;
  }

}

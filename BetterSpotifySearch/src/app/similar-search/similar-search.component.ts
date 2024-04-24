import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SongNameIdService } from '../song-name-id.service';
import { Router } from '@angular/router';
import { createDefaultSong } from '../objects/Song';
import { Song } from '../objects/Song';

@Component({
  selector: 'app-similar-search',
  templateUrl: './similar-search.component.html',
  styleUrls: ['./similar-search.component.scss']
})
export class SimilarSearchComponent implements OnInit {
  public song: Song = createDefaultSong();

  constructor(protected http: HttpClient, 
              private nameID: SongNameIdService,
              private router: Router) { }

  ngOnInit(): void {
    
  }

  setSongName(event: any): void {
      this.song.songName.value = event.target.value;
      console.log("Song Name: ", this.song.songName.value);
    }

  searchSimilarSongs()
  {
      /*
        1. Get song
        2. Search with that song to get its info
        3. Search again with that info, using the options the user selected
        4. Route to show that data
      */

      console.log("Getting Song ID for " + this.song.songName.value);
      var url = ("api/song/search/" + this.song.songName.value);

      // This is the http request of doom, dont do things like this
      this.http.get<string>(url).subscribe(result => 
        {
          var parse = JSON.parse(JSON.stringify(result));
          this.song.songId.value = parse["tracks"]["items"]["0"]["id"];

          var url = ("api/song/features/" + this.song.songId.value);

          this.http.get<string>(url).subscribe(result => 
            {
              var parse = JSON.parse(JSON.stringify(result));

              this.song.acousticness.value = parse.acousticness;
              this.song.danceability.value = parse.danceability;
              this.song.duration.value = parse.duration_ms;
              this.song.energy.value = parse.energy;
              this.song.instrumentalValue.value = parse.instrumentalness;
              this.song.key.value = parse.key;
              this.song.liveness.value = parse.liveness;
              this.song.loudness.value = parse.loudness;
              this.song.mode.value = parse.mode;
              this.song.speechiness.value = parse.speechiness;
              this.song.tempo.value = parse.tempo;
              this.song.timeSignature.value = parse.time_signature;
              this.song.valence.value = parse.valence;

              var url = "api/song/SearchBy/";
              let params = [];

              this.song.genre.enabled && params.push("seed_genres=" + this.song.genre.value);
              this.song.acousticness.enabled && params.push("target_acousticness=" + this.song.acousticness.value);
              this.song.danceability.enabled && params.push("target_danceability=" + this.song.danceability.value);
              this.song.duration.enabled && params.push("target_duration=" + this.song.duration.value);
              this.song.energy.enabled && params.push("target_energy=" + this.song.energy.value);
              this.song.instrumentalValue.enabled && params.push("target_instrumentalness=" + this.song.instrumentalValue.value);
              this.song.key.enabled && params.push("target_key=" + this.song.key.value);
              this.song.liveness.enabled && params.push("target_liveness=" + this.song.liveness.value);
              this.song.loudness.enabled && params.push("target_loudness=" + this.song.loudness.value);
              this.song.mode.enabled && params.push("target_mode=" + this.song.mode.value);
              this.song.speechiness.enabled && params.push("target_speechiness=" + this.song.speechiness.value);
              this.song.tempo.enabled && params.push("target_tempo=" + this.song.tempo.value);
              this.song.timeSignature.enabled && params.push("target_time_signature=" + this.song.timeSignature.value);
              this.song.valence.enabled && params.push("target_valence=" + this.song.valence.value);
              
              if (params.length > 0) {
                  url += '?' + params.join('&');
              }

              this.http.get<string>(url).subscribe(result => 
                {
                    var parse = JSON.parse(JSON.stringify(result));
                })
            }, error => console.error(error));
        }, error => console.error(error));
  }

  createUrl(): string 
  {
      var url:string = "api/song/searchby/";

      return url;
  }
}

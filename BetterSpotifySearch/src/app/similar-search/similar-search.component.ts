import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-similar-search',
  templateUrl: './similar-search.component.html',
  styleUrls: ['./similar-search.component.scss']
})
export class SimilarSearchComponent implements OnInit {
  public songName?: string;
  public songID?: number;
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

  constructor() { }

  ngOnInit(): void {
  }

  setSongName(event: any): void {
    this.songName = event.target.value;
    console.log("Song Name: ", this.songName);
  }

  searchSimilarSongs() {
    // Call api for similar songs w/ features
    console.log("Requesting songs similar to: ", this.songName);
  }

}

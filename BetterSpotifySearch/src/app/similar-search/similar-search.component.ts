import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-similar-search',
  templateUrl: './similar-search.component.html',
  styleUrls: ['./similar-search.component.scss']
})
export class SimilarSearchComponent implements OnInit {

  public songName?: string;

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

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-info-results',
  templateUrl: './info-results.component.html',
  styleUrls: ['./info-results.component.scss']
})
export class InfoResultsComponent implements OnInit {
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
  
  constructor() { }

  ngOnInit(): void {
  }

}

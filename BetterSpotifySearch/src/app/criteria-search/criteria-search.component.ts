import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-criteria-search',
  templateUrl: './criteria-search.component.html',
  styleUrls: ['./criteria-search.component.scss']
})
export class CriteriaSearchComponent implements OnInit {
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

}

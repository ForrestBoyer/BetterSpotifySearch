import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SongNameIdService {
  private songID?: string;
  private songName?: string;

  constructor() { }

  setSongId(id?: string) {
    this.songID = id;
  }
  getSongId() {
    return this.songID;
  }
  setSongName(name?: string) {
    this.songName = name;
  }
  getSongName() {
    return this.songName;
  }
}

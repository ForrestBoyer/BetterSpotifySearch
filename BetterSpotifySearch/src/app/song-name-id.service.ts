import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SongNameIdService {
  private songId?: string;
  private songName?: string;

  constructor() { }

  setSongId(id?: string) {
    this.songId = id;
  }
  getSongId() {
    return this.songId;
  }
  setSongName(name?: string) {
    this.songName = name;
  }
  getSongName() {
    return this.songName;
  }
}

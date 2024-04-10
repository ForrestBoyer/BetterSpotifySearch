import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SongNameIdService {
  private songId?: string;
  private songName?: string;
  private songLink?: string;

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
  setSongLink(link?: string) {
    this.songLink = link;
  }
  getSongLink() {
    return this.songLink;
  }
}

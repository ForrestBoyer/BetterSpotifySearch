import { SongField } from "./SongField";

export class Song {
    songName: SongField;
    songId: SongField;
    danceability: SongField;
    timeSignature: SongField;
    instrumentalValue: SongField;
    liveness: SongField;
    loudness: SongField;
    mode: SongField;
    speechiness: SongField;
    acousticness: SongField;
    energy: SongField;
    valence: SongField;
    tempo: SongField;
    key: SongField;
    duration: SongField;
    genre: SongField;

    constructor(song: Song) {
        this.songName = song.songName;
        this.songId = song.songId;
        this.danceability = song.danceability;
        this.timeSignature = song.timeSignature;
        this.instrumentalValue = song.instrumentalValue;
        this.liveness = song.liveness;
        this.loudness = song.loudness;
        this.mode = song.mode;
        this.speechiness = song.speechiness;
        this.acousticness = song.acousticness;
        this.energy = song.energy;
        this.valence = song.valence;
        this.tempo = song.tempo;
        this.duration = song.duration;
        this.genre = song.genre;
        this.key = song.key;
    }
}

function createDefaultSongField(): SongField {
    return { value: null, enabled: false };
}

export function createDefaultSong(): Song {
    return {
        songName: createDefaultSongField(),
        songId: createDefaultSongField(),
        danceability: createDefaultSongField(),
        timeSignature: createDefaultSongField(),
        instrumentalValue: createDefaultSongField(),
        liveness: createDefaultSongField(),
        loudness: createDefaultSongField(),
        mode: createDefaultSongField(),
        speechiness: createDefaultSongField(),
        acousticness: createDefaultSongField(),
        energy: createDefaultSongField(),
        valence: createDefaultSongField(),
        tempo: createDefaultSongField(),
        duration: createDefaultSongField(),
        genre: createDefaultSongField(),
        key: createDefaultSongField()
    };
} 
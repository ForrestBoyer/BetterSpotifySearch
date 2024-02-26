import { Routes } from '@angular/router';
import { SongFinderComponent } from './song-finder/song-finder.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: '/songfinder', component: SongFinderComponent},
    { path: "**", component: HomeComponent }
];

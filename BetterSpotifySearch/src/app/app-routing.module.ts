import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from './login/login.component'; 
import { SimilarSearchComponent } from './similar-search/similar-search.component';
import { CriteriaSearchComponent } from './criteria-search/criteria-search.component';
import { SongInfoComponent } from './song-info/song-info.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'similar-song-search', component: SimilarSearchComponent },
  { path: 'song-criteria-search', component: CriteriaSearchComponent },
  { path: 'song-info', component: SongInfoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

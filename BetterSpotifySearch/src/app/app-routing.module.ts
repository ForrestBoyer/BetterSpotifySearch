import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from './login/login.component'; 
import { SimilarSearchComponent } from './similar-search/similar-search.component';
import { CriteriaSearchComponent } from './criteria-search/criteria-search.component';
import { SongInfoComponent } from './song-info/song-info.component';
import { SearchResultsComponent } from './search-results/search-results.component';
import { InfoResultsComponent } from './info-results/info-results.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'similar-song-search', component: SimilarSearchComponent },
  { path: 'song-criteria-search', component: CriteriaSearchComponent },
  { path: 'song-info', component: SongInfoComponent },
  { path: 'results', component: SearchResultsComponent },
  { path: 'info-results', component: InfoResultsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  
  constructor(protected http: HttpClient) { }

  ngOnInit(): void {
  }

  authenticateUser(): void {
    console.log("Authenticated!");
    var url = ("api/SpotifyAuthentication/Register");
    this.http.get<string>(url).subscribe(result => 
      {

      }, error => console.error(error));
  }

}

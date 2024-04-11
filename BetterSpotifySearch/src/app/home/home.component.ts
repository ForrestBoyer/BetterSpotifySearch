import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public number?: number;

  constructor(protected http: HttpClient) { }

  ngOnInit(): void { 
    var url = ("api/example/getrandomnumber");

    this.http.get<number>(url).subscribe(result => 
      {
        this.number = result;
        console.log(this.number);
      }, error => console.error(error));
  }

}

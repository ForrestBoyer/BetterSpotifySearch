import { Component, OnInit } from '@angular/core';
import { BaseFormComponent } from '../bases/base-form.component';
import { FormControl, FormGroup } from '@angular/forms';
import { Song } from '../DTOs/song';

@Component({
  selector: 'app-criteria-search',
  templateUrl: './criteria-search.component.html',
  styleUrls: ['./criteria-search.component.scss']
})

export class CriteriaSearchComponent extends BaseFormComponent implements OnInit {

  song?: Song;
  
  constructor() 
  { 
    super();
  }

  ngOnInit(): void {

  }

}

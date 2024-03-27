import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS, MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';

@NgModule({
    imports: [
      MatToolbarModule,
      MatIconModule,
      MatFormFieldModule,
      MatCardModule,
      MatButtonModule,
      MatInputModule
    ],
    exports: [
      MatToolbarModule,
      MatIconModule,
      MatFormFieldModule,
      MatCardModule,
      MatButtonModule,
      MatInputModule
    ],
    providers: [
      {provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: {appearance: 'outline'}}
    ]
  })
  export class AngularMaterialModule { }
  
import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button'

@Component({
  selector: 'app-nav-menu',
  standalone: true,
  imports: [MatButton],
  templateUrl: './nav-menu.component.html',
  styleUrl: './nav-menu.component.scss'
})
export class NavMenuComponent {

}

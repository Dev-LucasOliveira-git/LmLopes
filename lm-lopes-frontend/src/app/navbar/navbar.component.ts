import { Component, OnInit } from '@angular/core';
import { faDoorOpen, faFileCirclePlus, faPlus, faUserPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {
  faUserPlus = faUserPlus;
  faFileCirclePlus = faFileCirclePlus;
  faDoorOpen = faDoorOpen;

  roleUser: any

  ngOnInit(): void {
    this.roleUser = localStorage.getItem('tipoUser')
  }
}

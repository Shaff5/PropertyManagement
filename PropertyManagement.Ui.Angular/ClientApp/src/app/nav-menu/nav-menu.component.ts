import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isSearchTypesExpanded = false;
  isImportTypesExpanded = false;
  isMenuExpanded = false;

  constructor(private router: Router) { }

  collapseSearchTypes() {
    this.isSearchTypesExpanded = false;
  }

  toggleSearchTypes() {
    this.isSearchTypesExpanded = !this.isSearchTypesExpanded;
  }

  collapseImportTypes() {
    this.isImportTypesExpanded = false;
  }

  toggleImportTypes() {
    this.isImportTypesExpanded = !this.isImportTypesExpanded;
  }

  toggleMenu() {
    this.isMenuExpanded = !this.isMenuExpanded;
  }

  collapseMenu() {
    this.isMenuExpanded = false;
  }

  fastFind(searchTerm: string) {
    this.router.navigate(['/fastfind', { searchTerm: searchTerm }]).then(nav => {
      console.log(nav); // true if navigation is successful
    }, err => {
      console.log(err) // when there's an error
    });
  }
}

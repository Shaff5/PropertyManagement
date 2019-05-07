import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isSearchTypesExpanded = false;
  isImportTypesExpanded = false;
  isMenuExpanded = false;

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
}

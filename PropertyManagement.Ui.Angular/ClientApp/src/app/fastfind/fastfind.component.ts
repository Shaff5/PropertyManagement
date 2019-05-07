import { Component, Inject, OnInit } from '@angular/core';
import { Building } from '../buildings/building'
import { FastFindService } from './fastfind.service';

@Component({
  selector: 'fastfind',
  templateUrl: './fastfind.component.html'
})
export class FastFindComponent implements OnInit {
  public buildings: Building[];

  constructor(private fastfindservice: FastFindService) { }

  ngOnInit(): void {
    this.getFastFindItems();
  }

  private getFastFindItems(): void {
    alert('hi');
    this.fastfindservice.getFastFindItems().subscribe(buildings => this.buildings = buildings, error => this.handleError(error));
  }

  //private delete(id: number): void {
  //  if (confirm("Are you sure you want to delete this building?")) {
  //    this.buildingservice.deleteBuilding(id)
  //      .subscribe(() => this.getBuildings(), error => this.handleError(error));
  //  }
  //}

  private handleError(error: any) {
    let msg: string = "";
    msg = "Status: " + error.status;
    msg += " Status Text: " + error.statusText;

    alert(msg);
  }
}

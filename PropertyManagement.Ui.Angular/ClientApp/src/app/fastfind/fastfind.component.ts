import { Component, Inject, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Building } from '../buildings/building';
import { Unit } from '../units/unit';
import { FastFindService } from './fastfind.service';

@Component({
  selector: 'fastfind',
  templateUrl: './fastfind.component.html'
})
export class FastFindComponent implements OnInit {
  public buildings: Building[];
  public units: Unit[];
  public rents: any;

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private fastfindservice: FastFindService) { }

  ngOnInit(): void {
    let searchTerm = this.activatedRoute.snapshot.params["searchTerm"];
    this.getFastFindItems(searchTerm);
  }

  private getFastFindItems(searchTerm: string): void {
    this.fastfindservice.getFastFindItems(searchTerm).subscribe(o => { this.buildings = o.buildings; this.units = o.units, this.rents = o.rents }, error => this.handleError(error));
  }

  private handleError(error: any) {
    let msg: string = "";
    msg = "Status: " + error.status;
    msg += " Status Text: " + error.statusText;

    alert(msg);
  }
}

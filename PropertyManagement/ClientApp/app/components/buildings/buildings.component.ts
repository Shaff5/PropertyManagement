﻿import { Component, Inject, OnInit } from '@angular/core';
import { Building } from './building'
import { BuildingService } from './building.service';

@Component({
    selector: 'buildings',
    templateUrl: './buildings.component.html'
})
export class BuildingsComponent implements OnInit {
    public buildings: Building[];

    constructor(private buildingservice: BuildingService) { }

    ngOnInit(): void {
        this.getBuildings();
    }

    private getBuildings(): void {
        this.buildingservice.getBuildings().subscribe(buildings => this.buildings = buildings);
    }

    private delete(id: number): void {
        if (confirm("Are you sure you want to delete this building?")) {
            this.buildingservice.deleteBuilding(id)
                .subscribe(() => this.getBuildings(), errors => alert(errors[0]));
        }
    }
}

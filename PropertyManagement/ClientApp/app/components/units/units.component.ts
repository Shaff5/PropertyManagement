import { Component, Inject, OnInit } from '@angular/core';
import { Unit } from './unit'
import { UnitService } from './unit.service';
import { LogService } from '../../shared/log.service';

@Component({
    selector: 'units',
    templateUrl: './units.component.html'
})
export class UnitsComponent implements OnInit {
    public units: Unit[];

    constructor(private unitservice: UnitService, private logservice: LogService) { }

    ngOnInit(): void {
        this.getUnits();
    }

    private getUnits(): void {
        this.unitservice.getUnits().subscribe(units => this.units = units, error => this.handleError(error));
    }

    private delete(id: number): void {
        if (confirm("Are you sure you want to delete this unit?")) {
            this.unitservice.deleteUnit(id)
                .subscribe(() => this.getUnits(), error => this.handleError(error));
        }
    }

    private handleError(error: any) {
        let msg: string = "";
        msg = "Status: " + error.status;
        msg += " Status Text: " + error.statusText;

        alert(msg);
        this.logservice.log(msg);
    }
}

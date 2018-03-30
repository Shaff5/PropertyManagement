import { Component, Inject, OnInit } from '@angular/core'
import 'rxjs/add/operator/catch'
import { Router, ActivatedRoute } from '@angular/router'
import { Building } from './building'
import { BuildingService } from './building.service';
import { LogService } from '../../shared/log.service';

@Component({
    selector: 'building',
    templateUrl: './building-detail.component.html'
})
export class BuildingDetailComponent implements OnInit {
    public building: Building;
    private router: Router;
    private messages: string[] = [];

    constructor(private buildingservice: BuildingService, private logservice: LogService, router: Router, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute) {
        this.router = router;
    }

    ngOnInit(): void {
        this.getBuilding();
    }

    ngAfterViewInit(): void {
        //need to figure out how to add jquery
        //$('#datetimepicker1').datetimepicker();
    }

    private getBuilding() {
        let id = this.activatedRoute.snapshot.params["id"];
        if (id > 0) {
            this.buildingservice.getBuilding(id).subscribe(building => this.building = building, error => this.handleError(error));
        }
        else {
            this.building = new Building();
        }
    }

    private saveBuilding() {
        if (this.building.BuildingId > 0) {
            this.updateBuilding();
        }
        else {
            this.addBuilding();
        }
    }

    private updateBuilding() {
        this.buildingservice.updateBuilding(this.building.BuildingId, this.building)
            .subscribe(() => this.goBack(), error => this.handleError(error));
    }

    private addBuilding() {
        this.buildingservice.addBuilding(this.building)
            .subscribe(() => this.goBack(), error => this.handleError(error));
    }

    private handleError(error: any) {
        let msg: string = "";
        msg = "Status: " + error.status;
        msg += " Status Text: " + error.statusText;

        alert(msg);
        this.logservice.log(msg);
    }

    private goBack() {
        this.router.navigateByUrl('/buildings');
    }
}
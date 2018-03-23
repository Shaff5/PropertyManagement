﻿import { Component, Inject, OnInit } from '@angular/core'
import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/map' 
import 'rxjs/add/operator/catch'
//import 'rxjs/add/operator/throw'
import { Router, ActivatedRoute } from '@angular/router'
import { Building } from './building'
import { BuildingService } from './building.service';

@Component({
    selector: 'building',
    templateUrl: './building-detail.component.html'
})
export class BuildingDetailComponent implements OnInit {
    public building: Building;
    private http: Http;
    private router: Router;
    private messages: string[] = [];

    constructor(private buildingservice: BuildingService, http: Http, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute) {
        this.http = http;
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
            this.buildingservice.getBuilding(id).subscribe(building => this.building = building, errors => alert(errors));
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
        this.buildingservice.updateBuilding(this.building.BuildingId, this.building);
    }

    private addBuilding() {
        this.buildingservice.addBuilding(this.building)
            .subscribe(() => this.goBack(), errors => this.handleErrors(errors));
    }

    private handleErrors(errors: any) {
        this.messages = [];
        for (let msg of errors) {
            this.messages.push(msg);
        }
    }

    private goBack() {
        alert('going back');
        //this.location.back();
        this.router.navigate(['./buildings']);
    }
}
import { Component, Inject, OnInit } from '@angular/core'
import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/map' 
import 'rxjs/add/operator/catch'
//import 'rxjs/add/operator/throw'
import { ActivatedRoute } from '@angular/router'
import { Building } from './building'
import { BuildingService } from './building.service';

@Component({
    selector: 'building',
    templateUrl: './building-detail.component.html'
})
export class BuildingDetailComponent implements OnInit {
    public building: Building;
    private http: Http;

    constructor(private buildingservice: BuildingService, http: Http, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute) {
        //http.get(baseUrl + 'api/Building/Get').subscribe(result => {
        this.http = http;
        //let id = this.activatedRoute.snapshot.params["id"];
        //if (id > 0)
        //{
        //    //alert('hi');
        //    //http.get('http://localhost:62579/api/Building/' + id)
        //    //    .subscribe(result => {
        //    //        alert(result);
        //    //        //alert(result.json());
        //    //        this.building = result.json() as Building;
        //    //        alert(1);
        //    //        alert(this.building.buildingName);
        //    //        alert(2);
        //    //    }/*, error => console.error(error)*/);
        //    this.buildingservice.getBuilding(id).subscribe(building => this.building = building);
        //}
        //else
        //{
        //    this.building = new Building();
        //}
    }

    ngOnInit(): void {
        this.getBuilding();
    }

    private getBuilding() {
        let id = this.activatedRoute.snapshot.params["id"];
        if (id > 0) {
            this.buildingservice.getBuilding(id).subscribe(building => this.building = building, errors => alert(errors) );
        }
        else {
            this.building = new Building();
        }
    }

    saveBuilding() {
        if (this.building.BuildingId > 0)
        {
            this.updateBuilding();
        }
        else
        {
            this.addBuilding();
        }
    }

    private updateBuilding() {
        this.buildingservice.updateBuilding(this.building.BuildingId, this.building);
    }

    private addBuilding() {
        //let headers = new Headers({ 'Content-Type': 'application/json' });
        //let options = new RequestOptions(headers: headers);
        this.http.post('http://localhost:62579/api/Building/', this.building)
            .subscribe(result => {
                this.building = result.json() as Building;
            }, error => console.error(error));
    }
}

//interface Building {
//    buildingId: number;
//    buildingName: string;
//    address1: string;
//    city: string;
//}
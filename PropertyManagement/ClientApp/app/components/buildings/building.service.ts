import { Http, Headers } from '@angular/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Building } from './building';

@Injectable()
export class BuildingService {
    private apiUrl: string;

    constructor(private http: Http, @Inject('API_URL') apiUrl: string) {
        this.apiUrl = apiUrl;
    }

    getBuildings() {
        return this.http.get(this.apiUrl + 'Building').map(result => result.json());
    }

    getBuilding(id: number) : Observable<Building> {
        return this.http.get(this.apiUrl + 'Building/' + id).map(response => response.json() as Building);
    }

    updateBuilding(id: number, building: Building) {
        this.http.put(this.apiUrl + 'Building/' + id, building)
            .subscribe(result => {
            }, error => console.error(error));
    }

    deleteBuilding(id: number) {
        this.http.delete(this.apiUrl + 'Building/' + id)
            .subscribe(result => {

            }, error => console.error(error));
    }

}
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/throw';
import { Building } from './building';

@Injectable()
export class BuildingService {
    private apiUrl: string;

    constructor(private httpClient: HttpClient, @Inject('API_URL') apiUrl: string) {
        this.apiUrl = apiUrl;
    }

    getBuildings() {
        return this.httpClient.get<Building[]>(this.apiUrl + 'Building')
            .map(result => result)
            .catch(this.handleError);
    }

    getBuilding(id: number) : Observable<Building> {
        return this.httpClient.get(this.apiUrl + 'Building/' + id, { responseType: 'text' })
            .map(result => this.extractData(result))
            .catch(this.handleError);
    }

    addBuilding(building: Building) {
        return this.httpClient.post(this.apiUrl + 'Building/', building)
            .map(() => null).catch(this.handleError);
    }

    updateBuilding(id: number, building: Building) {
        return this.httpClient.put(this.apiUrl + 'Building/' + id, building)
            .map(() => null).catch(this.handleError);
    }
    
    deleteBuilding(id: number) {
        return this.httpClient.delete(this.apiUrl + 'Building/' + id).map(() => null).catch(this.handleError);
    }

    private handleError(error: any): Observable<any> {
        return Observable.throw(error);
    }

    private extractData(response: string): Building {
        var serverBuilding = JSON.parse(response);
        var purchaseDate = serverBuilding.PurchaseDate;

        var building = JSON.parse(response) as Building;
        building.PurchaseDate = new Date(purchaseDate);

        //var building = new Building;
        //building.BuildingId = serverBuilding.BuildingId;
        //building.BuildingName = serverBuilding.BuildingName;
        //building.AddressLine1 = serverBuilding.AddressLine1;
        //building.AddressLine2 = serverBuilding.AddressLine2;
        //building.AddressLine3 = serverBuilding.AddressLine3;
        //building.City = serverBuilding.City;
        //building.State = serverBuilding.State;
        //building.ZipCode = serverBuilding.ZipCode;
        //building.PurchaseDate = new Date(serverBuilding.PurchaseDate);

        return building;
    }
}
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

    getBuildings() : Observable<Building[]> {
        return this.httpClient.get(this.apiUrl + 'Building', { responseType: 'text' })
            .map(result => this.extractBuildings(result))
            .catch(this.handleError);
    }

    getBuilding(id: number) : Observable<Building> {
        return this.httpClient.get(this.apiUrl + 'Building/' + id, { responseType: 'text' })
            .map(result => this.extractBuilding(result))
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

    private extractBuilding(response: string): Building {
        var serverBuilding = JSON.parse(response);
        var purchaseDate = serverBuilding.PurchaseDate;
        var sellDate = serverBuilding.SellDate;
        var createdOn = serverBuilding.CreatedOn;
        var lastUpdatedOn = serverBuilding.LastUpdatedOn;

        var building = JSON.parse(response) as Building;
        building.PurchaseDate = new Date(purchaseDate);

        if (sellDate != null) {
            building.SellDate = new Date(sellDate);
        }
        
        building.CreatedOn = new Date(createdOn);
        building.LastUpdatedOn = new Date(lastUpdatedOn);

        return building;
    }

    private extractBuildings(response: string): Building[] {
        var serverBuildings = JSON.parse(response);
        var buildings = [];

        for (var i = 0; i < serverBuildings.length; i++) {
            var purchaseDate = serverBuildings[i].PurchaseDate;
            var sellDate = serverBuildings[i].SellDate;
            var createdOn = serverBuildings[i].CreatedOn;
            var lastUpdatedOn = serverBuildings[i].LastUpdatedOn;

            var building = serverBuildings[i] as Building;
            building.PurchaseDate = new Date(purchaseDate);

            if (sellDate != null) {
                building.SellDate = new Date(sellDate);
            }

            building.CreatedOn = new Date(createdOn);
            building.LastUpdatedOn = new Date(lastUpdatedOn);

            buildings.push(building);
        }

        return buildings;
    }
}
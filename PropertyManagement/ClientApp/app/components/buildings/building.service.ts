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
        return this.httpClient.get<Building>(this.apiUrl + 'Building/' + id)
            .map(result => result)
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

}
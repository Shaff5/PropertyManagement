import { Http } from '@angular/http';
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
        return this.http.get(this.apiUrl + 'Building')
            .map(result => result.json() as Building[]);
    }

    getBuilding(id: number) : Observable<Building> {
        return this.http.get(this.apiUrl + 'Building/' + id)
            .map(result => result.json() as Building);
    }

    addBuilding(building: Building) {
        return this.http.post(this.apiUrl + 'Building/', building)
            .map(() => null).catch(this.handleError);
    }

    updateBuilding(id: number, building: Building) {
        return this.http.put(this.apiUrl + 'Building/' + id, building)
            .map(() => null).catch(this.handleError);
    }
    
    deleteBuilding(id: number) {
        return this.http.delete(this.apiUrl + 'Building/' + id).map(() => null).catch(this.handleError);
    }

    private handleError(error: any): Observable<any> {
        let errors: string[] = [];
        errors.push(error.json().exceptionMessage);

        return Observable.throw(errors);
    }

}
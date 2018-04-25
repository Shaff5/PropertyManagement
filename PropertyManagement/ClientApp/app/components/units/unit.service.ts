import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/throw';
import { Unit } from './unit';

@Injectable()
export class UnitService {
    private apiUrl: string;

    constructor(private httpClient: HttpClient, @Inject('API_URL') apiUrl: string) {
        this.apiUrl = apiUrl;
    }

    getUnits(): Observable<Unit[]> {
        return this.httpClient.get(this.apiUrl + 'Unit', { responseType: 'text' })
            .map(result => this.extractUnits(result))
            .catch(this.handleError);
    }

    getUnit(id: number): Observable<Unit> {
        return this.httpClient.get(this.apiUrl + 'Unit/' + id, { responseType: 'text' })
            .map(result => this.extractUnit(result))
            .catch(this.handleError);
    }

    addUnit(unit: Unit) {
        return this.httpClient.post(this.apiUrl + 'Unit/', unit)
            .map(() => null).catch(this.handleError);
    }

    updateUnit(id: number, unit: Unit) {
        return this.httpClient.put(this.apiUrl + 'Unit/' + id, unit)
            .map(() => null).catch(this.handleError);
    }

    deleteUnit(id: number) {
        return this.httpClient.delete(this.apiUrl + 'Unit/' + id).map(() => null).catch(this.handleError);
    }

    private handleError(error: any): Observable<any> {
        return Observable.throw(error);
    }

    private extractUnit(response: string): Unit {
        var serverUnit = JSON.parse(response);
        var createdOn = serverUnit.CreatedOn;
        var lastUpdatedOn = serverUnit.LastUpdatedOn;

        var unit = JSON.parse(response) as Unit;
        
        unit.CreatedOn = new Date(createdOn);
        unit.LastUpdatedOn = new Date(lastUpdatedOn);

        return unit;
    }

    private extractUnits(response: string): Unit[] {
        var serverUnits = JSON.parse(response);
        var units = [];

        for (var i = 0; i < serverUnits.length; i++) {
            var createdOn = serverUnits[i].CreatedOn;
            var lastUpdatedOn = serverUnits[i].LastUpdatedOn;

            var unit = serverUnits[i] as Unit;
            
            unit.CreatedOn = new Date(createdOn);
            unit.LastUpdatedOn = new Date(lastUpdatedOn);

            units.push(unit);
        }

        return units;
    }
}
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { Building } from '../buildings/building';
import { Unit } from '../units/unit';

@Injectable()
export class FastFindService {
  private apiUrl: string;
  
  constructor(private httpClient: HttpClient, @Inject('API_URL') apiUrl: string) {
    this.apiUrl = apiUrl;
  }

  getFastFindItems(searchTerm: string): Observable<any> {
    var tt = this.httpClient.get<any>(this.apiUrl + 'FastFind/' + searchTerm)
      .pipe(
        map(
          result => this.extractItems(result)));
    return tt;
  }

  private extractItems(response: any): any {
    var buildings = [];
    var units = [];

    for (var i = 0; i < response.buildings.length; i++) {
      var purchaseDate = response.buildings[i].PurchaseDate;
      var sellDate = response.buildings[i].SellDate;
      var createdOn = response.buildings[i].CreatedOn;
      var lastUpdatedOn = response.buildings[i].LastUpdatedOn;

      var building = response.buildings[i] as Building;
      building.PurchaseDate = new Date(purchaseDate);

      if (sellDate != null) {
        building.SellDate = new Date(sellDate);
      }

      building.CreatedOn = new Date(createdOn);
      building.LastUpdatedOn = new Date(lastUpdatedOn);

      buildings.push(building);
    }

    for (var j = 0; j < response.units.length; j++) {
      var unit = response.units[j] as Unit;
      units.push(unit);
    }

    var o = { buildings: buildings, units: units, rents: response.rents };

    return o;
  }
}

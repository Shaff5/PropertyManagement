import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BuildingsComponent } from './buildings/buildings.component';
import { BuildingService } from './buildings/building.service';
import { FastFindComponent } from './fastfind/fastfind.component';
import { FastFindService } from './fastfind/fastfind.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    BuildingsComponent,
    FastFindComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'buildings', component: BuildingsComponent },
      { path: 'fastfind', component: FastFindComponent },
    ])
  ],
  providers: [
    { provide: 'API_URL', useFactory: getApiUrl },
    BuildingService,
    FastFindService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}

export function getApiUrl() {
  return 'https://localhost:44358/api/';
}

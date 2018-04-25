import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { BuildingsComponent } from './components/buildings/buildings.component';
import { BuildingDetailComponent } from './components/buildings/building-detail.component';
import { UnitsComponent } from './components/units/units.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        BuildingsComponent,
        BuildingDetailComponent,
        UnitsComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        NgbModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'buildings', component: BuildingsComponent },
            { path: 'buildings/building-detail/:id', component: BuildingDetailComponent },
            { path: 'units', component: UnitsComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.module.shared';
import { AppComponent } from './components/app/app.component';
import { BuildingService } from './components/buildings/building.service';
import { LogService } from './shared/log.service';
import { StatesService } from './shared/states.service';
import { NgbDateNativeAdapter } from './shared/datepicker-adapter';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        AppModuleShared
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl },
        { provide: 'API_URL', useFactory: getApiUrl },
        { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter},
        BuildingService,
        LogService,
        StatesService
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}

export function getApiUrl() {
    return 'http://localhost:62579/api/';
}

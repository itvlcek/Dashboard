import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { LogComponent } from './components/logdashboard/log.dashboard.component';

import { LogDashbardService } from './components/logdashboard/log.dashboard.service';
import { UserService } from './user/user.service';
import { UserProfile } from './user/user.profile';
import { CommonService } from './services/common.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        LogComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'log-dashboard', component: LogComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ], providers: [
        LogDashbardService, UserService, UserProfile, CommonService]
})
export class AppModuleShared {
}

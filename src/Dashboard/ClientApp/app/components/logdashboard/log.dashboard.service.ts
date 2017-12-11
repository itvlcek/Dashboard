import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/of';
import { ILogInfo } from './log.dashboard.model';
import { UserProfile } from '../../user/user.profile'
import { CommonService } from '../../services/common.service'
 
@Injectable()
export class LogDashbard {
    constructor(private http: Http,
        private authProfile: UserProfile,
        private commonService: CommonService) { }
 
    getProducts(): Observable<ILogInfo[]> {
        let url = this.commonService.getBaseUrl() + '/data';
 
        let options = null;
        let profile = this.authProfile.getProfile();
 
        if (profile != null && profile != undefined) {
            let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token });
            options = new RequestOptions({ headers: headers });
        }
        let data: Observable<ILogInfo[]> = this.http.get(url, options)
            .map(res => <ILogInfo[]>res.json())
            .do(data => console.log('getLogs: ' + JSON.stringify(data)))
            .catch(this.commonService.handleError);
 
        return data;
    }
}
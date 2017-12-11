import { Component, OnInit } from '@angular/core';

import { ILogInfo } from './log.dashboard.model';
import { LogDashbardService } from './log.dashboard.service';

@Component({
    templateUrl: './log.dashboard.component.html'
})

export class LogComponent implements OnInit {
    pageTitle: string = 'Product List';
    logs: ILogInfo[];

    constructor(private logService: LogDashbardService) { }

    ngOnInit(): void {
        this.logService.getLogs()
            .subscribe(logs => this.logs = logs,
            error => console.log(error));
    }
}
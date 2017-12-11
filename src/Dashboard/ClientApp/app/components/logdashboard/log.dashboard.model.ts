export interface ILogInfo {
    application: string;
    level: string;
    loggerName: string;
    timeStamp: Date;
    state: string;
    exceptionMessage: string;
    exceptionInner: string;
    exceptionStack: string;
    message: string;
    Parameters: any;   
}
export interface IProfile {
    token: string;
    expiration: string;
    claims: IClaim[];
    currentUser: IUser;
}
 
export interface IClaim {
    type: string;
    value: string;
}
 
export interface IUser {
    id: string;
    userName: string;
    email: string;
}
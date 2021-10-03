import { User } from './user';

export interface Address {
    id?:number,
    address?:string,
    zipCode?:number,
    cityName?:number,
    user? : User
}
import { User } from './user';

export interface Address {
    addressId:number,
    address:string,
    zipCode:number,
    cityName:number,
    userId : number,
    user? : User
}
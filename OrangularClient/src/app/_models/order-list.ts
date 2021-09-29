import { User } from './user';

export interface OrderList {
    id : number,
    orderDateTime : Date,
    userId : number,
    user? : User
}
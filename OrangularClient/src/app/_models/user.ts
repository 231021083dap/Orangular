import { Address } from './address';
import { OrderList } from './order-list';
import { Role } from './role';

export interface User {
    userId : number,
    email : string,
    password : string,
    role : Role,
    orderList? : OrderList[],
    address? : Address[]
}
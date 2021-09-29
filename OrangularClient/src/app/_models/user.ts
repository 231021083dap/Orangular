import { Address } from './address';
import { OrderList } from './order-list';
import { Role } from './role';

export interface User {
    id? : number,
    email? : string,
    password? : string,
    role? : Role,
    orderList? : OrderList[],
    address? : Address[]
}
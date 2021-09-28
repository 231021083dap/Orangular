import { Category } from "./category";
export interface Product {
    productId:number,
    breed:string, 
    price:number,
    weight:number, 
    gender:string, 
    description:string, 
    category?: Category[]
}
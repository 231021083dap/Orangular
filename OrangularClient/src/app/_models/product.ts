import { Category } from "../models";
export interface Product {
    productId:number,
    breed:string, 
    price:number,
    weight:number, 
    gender:string, 
    description:string, 
    categoryId: number,
    categoryName: Category
}
import { Category } from "./category";
export interface Product {
    productId:number,
    breedName:string, 
    price:number,
    weight:number, 
    gender:string, 
    description:string, 
    productCategoryResponse?: Category[]
}
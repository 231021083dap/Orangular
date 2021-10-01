import { Category } from "./category";
export interface Product {
    id:number,
    breedName:string, 
    price:number,
    weight:number, 
    gender:string, 
    description:string, 
    category?: Category[]
    images: string
    
}
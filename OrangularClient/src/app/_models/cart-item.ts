import { Product } from "./product";
export interface CartItem {
    ProductId: number,
    navn: string,
    pris: number,
    antal: number,
    storage: number,
}
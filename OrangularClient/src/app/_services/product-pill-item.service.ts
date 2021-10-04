import { elementEventFullName } from '@angular/compiler/src/view_compiler/view_compiler';
import { Injectable } from '@angular/core';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service'


@Injectable({
  providedIn: 'root'
})
export class ProductPillItemService {

  constructor(private productService: ProductService) { }
  public product: Product[] = [];
  public productObj: Product = { id: 0, breedName: "", price: 0, weight: 0, gender: "", description: "" };


  public testfunc(id: string) {
    console.log(id);
    this.productService.getProduct(id).subscribe(a => {
      this.productObj = {
        id: a.id,
        breedName: a.breedName,
        price: a.price,
        weight: a.weight,
        gender: a.gender,
        description: a.description
      }

      const body = document.getElementById("product-page-body")
    const parent = document.createElement('div')
    parent.setAttribute('id', 'products')
    body?.appendChild(parent)


    });
  }

}

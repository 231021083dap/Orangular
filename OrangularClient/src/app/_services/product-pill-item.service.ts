import { elementEventFullName } from '@angular/compiler/src/view_compiler/view_compiler';
import { Injectable } from '@angular/core';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service'
import { LibraryService } from './library.service'


@Injectable({
  providedIn: 'root'
})
export class ProductPillItemService {

  constructor(
    private productService: ProductService,
    private libraryService: LibraryService
    ) { }
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

      const newChildDiv1 = document.createElement('div');
      newChildDiv1.setAttribute('class', 'child-pill');
      parent!.appendChild(newChildDiv1);

      let thisImage = this.productService.setImage(this.productObj.id)
      const newImg = document.createElement('img');
      newImg.setAttribute('class', 'picture');
      newImg.setAttribute('src', `./assets/${thisImage}`);
      newImg.setAttribute('width', '200');
      newImg.setAttribute('height', '200');
      newImg.setAttribute('border', '1 px')
      newChildDiv1!.appendChild(newImg);

      const newChildP1 = document.createElement('p');
      newChildP1.innerHTML = `<b>Breed:</b> ${this.productObj.breedName} | <b>Price:</b> ${this.productObj.price} kr
      <br> <b>Weight:</b> ${this.productObj.weight} | <b>Gender:</b> ${this.productObj.gender}
      <br> <b>Description:</b> ${this.productObj.description} `;
      newChildDiv1.appendChild(newChildP1);

      const newChildTextProductAmount = document.createElement('input');
      newChildTextProductAmount.setAttribute('id', 'ProductAmountId');
      newChildTextProductAmount.setAttribute('value', '1');
      newChildDiv1.appendChild(newChildTextProductAmount);

      const newChildbuttonAddToCart = document.createElement('input');
      newChildbuttonAddToCart.setAttribute('type', 'button')
      newChildbuttonAddToCart.setAttribute('value', 'Add to cart');
      newChildbuttonAddToCart.addEventListener('click', this.alertCart)
      newChildDiv1.appendChild(newChildbuttonAddToCart);
    });
  }
  private alertCart(): void {
    alert("You have added: " +(<HTMLInputElement>document.getElementById('ProductAmountId')).value + " to the cart");
    let clicks = "hej"

    localStorage.setItem('Hejsa', clicks);
    const test = localStorage.getItem('Hejsa')
    console.log(test);


  }
}

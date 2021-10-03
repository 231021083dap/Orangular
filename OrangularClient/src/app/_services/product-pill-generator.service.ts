import { Injectable } from '@angular/core';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service'

@Injectable({
  providedIn: 'root'
})
export class ProductPillGeneratorService {

  constructor(private productService: ProductService) { }
  public product: Product[] = [];

  public getProducts(functionString: string, dynamicParameters: object): void {
    // vars
    let paramters = JSON.parse(JSON.stringify(dynamicParameters))
    let modifyArray

    // eksternt metode kald til product.service
    // Henter alle produkter
    this.productService.getAllProduct().subscribe(a => { this.product = a
      // Ændrer produkt array efter vores ønske
      // F.eks. tager de tre nyeste produkter i database
      modifyArray = this._modifyProductArray(this.product, functionString, paramters);
      // Udskriver en "pille" fra det modificeret array
      this._createPill(modifyArray);
    });

  }

  // en slags routing - vælger hvilken metode der skal køres
  private _modifyProductArray(productArray: Product[] = [], functionCall: string, dynamicParameters: object): any {
    let paramters = JSON.parse(JSON.stringify(dynamicParameters))
    switch (functionCall) {
      case 'getThreeNewestProducts': productArray = this._getThreeNewestProducts(productArray); break;
      case 'getCategory': productArray = this._getCategory(productArray, paramters); break;
      case 'searchBreedNametest': productArray = this._searchBreedNametest(productArray, paramters); break;
      default: console.log("Default case: Returning all products")
    }
    return productArray
  }
  //------------------------------------------------------------------------------------------------------
  private _getCategory(productArray: Product[] = [], dynamicParameters: object): any {
    let parameters = JSON.parse(JSON.stringify(dynamicParameters))
    let myObj = JSON.parse(JSON.stringify(productArray))
    
    let result: Product[] = []
    // console.log(myObj[0].category.categoryName)
    
    // console.log(myObj);
    console.log(parameters);
    

    for (let i = 0; i < myObj.length; i++) {
      // console.log(myObj[i].category.categoryName);
      if (myObj[i].category.categoryName == parameters.categoryName) {
        result.push(myObj[i])
      } 
    }
    return result
    }

  private _searchBreedNametest(productArray: Product[] = [], dynamicParameters: object): any {
    let paramters = JSON.parse(JSON.stringify(dynamicParameters))
    let result: Product[] = []
    productArray.forEach(element => {
      if (element.breedName.includes(paramters.breedName)) result.push(element)
    });
    return result
  }

  private _getThreeNewestProducts(productArray: Product[] = []): any {
    let result = productArray.sort((a, b) => (a.id < b.id) ? 1 : -1)
    // sa længe at længden er større end 3 sa pop
    while (result.length > 3) { result.pop() }
    return result
  }

  private _createPill(modifyArray: Product[] = []): void {
    let thisImage = 'DefaultImage.jpg'
    
    const body = document.getElementById('product-body')
    const parent = document.createElement('div')
    parent.setAttribute('id', 'products')
    body?.appendChild(parent)

    modifyArray.forEach(element => {

      switch (element.id) {
        case 1: thisImage = "Schaeferhund.jpg"; break;
        case 2: thisImage = "Corgi.jpg"; break;
        case 3: thisImage = "JackRussellTerrier.jpg"; break;
        default: thisImage = 'DefaultImage.jpg';
      }
      const newChildDiv1 = document.createElement('div')
      newChildDiv1.setAttribute('class', 'child-pill')
      parent!.appendChild(newChildDiv1)

      const newImg = document.createElement('img')
      newImg.setAttribute('class', 'picture')
      newImg.setAttribute('src', `./assets/${thisImage}`)
      newImg.setAttribute('width', '200')
      newImg.setAttribute('height', '200')
      parent!.appendChild(newImg)

      const newChildP1 = document.createElement('p')
      newChildP1.innerHTML = "price : 2000"
      const newChildP2 = document.createElement('p')
      newChildP2.innerHTML = `name : ${element.breedName}`

      newChildDiv1.appendChild(newChildP1)
      newChildDiv1.appendChild(newChildP2)
    })
  }
}






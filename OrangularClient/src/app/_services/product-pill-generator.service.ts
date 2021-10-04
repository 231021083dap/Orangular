import { Injectable } from '@angular/core';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service'

@Injectable({
  providedIn: 'root'
})
export class ProductPillGeneratorService {

  constructor(private productService: ProductService) { }
  public product: Product[] = [];
  //---------------------------------------------------------------------------------------------------------------------------------------------------
  //#region Creating Pills
  public getProducts(htmlElementId: string, functionString: string, dynamicParameters: object): void {
    document.getElementById("products")?.remove();
    let parameters = JSON.parse(JSON.stringify(dynamicParameters))
    let modifyArray;
    this.productService.getAllProduct().subscribe(a => {
      this.product = a
      modifyArray = this._modifyProductArray(this.product, functionString, parameters);
      this._createPill(htmlElementId, modifyArray);
    });
  }

  private _modifyProductArray(productArray: Product[] = [], functionCall: string, dynamicParameters: object): any {
    let parameters = JSON.parse(JSON.stringify(dynamicParameters))
    switch (functionCall) {
      case 'getThreeNewestProducts': productArray = this._getThreeNewestProducts(productArray); break;
      case 'getCategory': productArray = this._getCategory(productArray, parameters); break;
      case 'searchByBreedName': productArray = this._searchByBreedName(productArray, parameters); break;
      case 'searchByMinMaxPrice': productArray = this._searchByMinMaxPrice(productArray, parameters); break;
      default: console.log(`Default case: Returning all products. functionCall: ${functionCall}`)
    }
    return productArray
  }
  private _createPill(htmlElementId : string, modifyArray: Product[] = []): void {

    const body = document.getElementById(htmlElementId)
    const parent = document.createElement('div')
    parent.setAttribute('id', 'products')
    body?.appendChild(parent)

    modifyArray.forEach(element => {
      element.price = element.price / 100

      const newChildDiv1 = document.createElement('div');
      newChildDiv1.setAttribute('class', 'child-pill');
      parent!.appendChild(newChildDiv1);

      const newLink = document.createElement('a');
      newLink.setAttribute('href', `/product/${element.id}`);
      newChildDiv1!.appendChild(newLink);

      let thisImage = this.productService.setImage(element.id)
      const newImg = document.createElement('img');
      newImg.setAttribute('class', 'picture');
      newImg.setAttribute('src', `./assets/${thisImage}`);
      newImg.setAttribute('width', '200');
      newImg.setAttribute('height', '200');
      newImg.setAttribute('border', '1 px')
      newImg.addEventListener('mouseenter', () => { newImg.style.opacity =  '.7' });
      newImg.addEventListener('mouseleave', () => { newImg.style.opacity =  '1'; });
      newLink!.appendChild(newImg);

      const newChildP1 = document.createElement('p');
      newChildP1.innerHTML = `<b>Breed:</b> ${element.breedName} | <b>Price:</b> ${element.price} kr` ;
      newChildDiv1.appendChild(newChildP1);
    })
  }
  //#endregion
  //---------------------------------------------------------------------------------------------------------------------------------------------------
  //#region private modifyArray functions
  private _getThreeNewestProducts(productArray: Product[] = []): any {
    let result = productArray.sort((a, b) => (a.id < b.id) ? 1 : -1)
    while (result.length > 3) { result.pop() }
    return result
  }

  private _getCategory(productArray: Product[] = [], dynamicParameters: object): any {
    let parameters = JSON.parse(JSON.stringify(dynamicParameters))
    let myObj = JSON.parse(JSON.stringify(productArray))
    let result: Product[] = []

    for (let i = 0; i < myObj.length; i++) {
      if (myObj[i].category.category == parameters.id) result.push(myObj[i])
      console.log(myObj[i]);
    } return result
  }

  private _searchByBreedName(productArray: Product[] = [], dynamicParameters: object): any {
    let paramters = JSON.parse(JSON.stringify(dynamicParameters))
    let result: Product[] = []
    productArray.forEach(element => {
      if (element.breedName.includes(paramters.breedName)) result.push(element)
    });
    return result
  }

  private _searchByMinMaxPrice(productArray: Product[] = [], dynamicParameters: object) : any {
    let paramters = JSON.parse(JSON.stringify(dynamicParameters))
    let result: Product[] = []
    let minPrice: number
    let maxPrice: number

    // Konverter fra kroner til øre
    function converFromKronerToOre(kroner : number) {
      return kroner * 100
    }
    
    minPrice = converFromKronerToOre(paramters.minPrice)
    maxPrice = converFromKronerToOre(paramters.maxPrice)

    console.log(minPrice + " " + maxPrice + "element price: " + productArray[0].price)

    productArray.forEach(element => {
      if (element.price > minPrice && element.price <= maxPrice) result.push(element)
    });
    console.log(result)
    return result
  }
  //#endregion
}






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
  // clearProducts fjerner vores products div, og dermed alle dets child elementer ("produkt pill").
  // clearProducts bliver kaldt i header.component og kører hver gang et link bliver trykket på. 
  public clearProducts(): void {
    document.getElementById("products")?.remove();
    console.log("clearProducts()")
  }
  //---------------------------------------------------------------------------------------------------------------------------------------------------
  //#region Creating Pills
  public getProducts(htmlElementId: string, functionString: string, dynamicParameters: object): void {
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
    let thisImage = 'DefaultImage.jpg'
    

    const body = document.getElementById(htmlElementId)
    const parent = document.createElement('div')
    parent.setAttribute('id', 'products')
    body?.appendChild(parent)

    modifyArray.forEach(element => {
      element.price = element.price / 100

      switch (element.id) {
        case 1: thisImage = "Schaeferhund.jpg"; break;
        case 2: thisImage = "Corgi.jpg"; break;
        case 3: thisImage = "JackRussellTerrier.jpg"; break;
        case 4: thisImage = "Siamese.jpg"; break;
        case 5: thisImage = "SnowShoe.jpg"; break;
        case 6: thisImage = "Persian.jpg"; break;
        default: thisImage = 'DefaultImage.jpg';
      }

      const newChildDiv1 = document.createElement('div');
      newChildDiv1.setAttribute('class', 'child-pill');
      parent!.appendChild(newChildDiv1);

      const newLink = document.createElement('a');
      newLink.setAttribute('href', '/test');
      parent!.appendChild(newLink);

      const newImg = document.createElement('img');
      newImg.setAttribute('class', 'picture');
      newImg.setAttribute('src', `./assets/${thisImage}`);
      newImg.setAttribute('width', '200');
      newImg.setAttribute('height', '200');
      newImg.addEventListener('mouseenter', () => { newImg.style.opacity =  '.7' });
      newImg.addEventListener('mouseleave', () => { newImg.style.opacity =  '1'; });
      newLink!.appendChild(newImg);

      const newChildP1 = document.createElement('p');
      newChildP1.innerHTML = `price : ${element.price}` ;
      const newChildP2 = document.createElement('p');
      newChildP2.innerHTML = `name : ${element.breedName}`;

      newChildDiv1.appendChild(newChildP1);
      newChildDiv1.appendChild(newChildP2);
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
      if (myObj[i].category.categoryName == parameters.categoryName) result.push(myObj[i])
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






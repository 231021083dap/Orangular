import { Component, OnInit } from '@angular/core';
import { Product } from '../_models/product';
import { ProductPillGeneratorService } from '../_services/product-pill-generator.service'
import { ProductService } from '../_services/product.service'

@Component({
  selector: 'app-home-page-temp',
  templateUrl: './home-page-temp.component.html',
  styleUrls: ['./home-page-temp.component.css']
})
export class HomePageTempComponent implements OnInit {

  constructor(
    private productPillGeneratorService: ProductPillGeneratorService,
    private productService: ProductService
  ) { }

  public allProducts: Product[] = [];
  public sortedProducts: Product[] = [];

  ngOnInit(): void {
    this.productPillGeneratorService.getProducts('getThreeNewestProducts', {});


    // // Problem
    // // Vi skal hente de tre sidste tilføjet produkter
    
    // // Løsning
    // // 1) Hent alle objekter
    // this.productService.getAllProduct().subscribe(p => 
    // {
    //   this.allProducts = p
    //   // console.log(this.allProducts)


    //   // 2) Sorter uønskede objekter fra
    //   // this.allProducts.sort((a, b) => (a.id < b.id) ? 1 : -1).pop()
    //   this.sortedProducts = this.allProducts.sort((a, b) => (a.id < b.id) ? 1 : -1)
    //   // sa længe at længden er større end 3 sa pop
    //   while(this.sortedProducts.length > 3) {
    //     this.sortedProducts.pop()
    //   }


    //   console.log(this.sortedProducts)
    //   // console.log(this.allProducts.length)
    //   // implementering
    //   // sorter først all products via id


    //   this.sortedProducts.forEach(product => {
    //     // console.log(product.id)
    //     this.createPill('products-temp', product)
    //   })
    // })   
  }

  // createPill(elementId : string, product: Product): void {

  //   console.log(`elementId: ${elementId}, product: ${product.id}`)

  //   let thisImage = 'DefaultImage.jpg'
  //   const parent = document.getElementById(elementId)
  //   switch (product.id) {
  //     case 1: thisImage = "Schaeferhund.jpg"; break;
  //     case 2: thisImage = "Corgi.jpg"; break;
  //     case 3: thisImage = "JackRussellTerrier.jpg"; break;
  //     case 4: thisImage = "Siamese.jpg"; break;
  //     case 5: thisImage = "SnowShoe.jpg"; break;
  //     case 6: thisImage = "Persian.jpg"; break;
  //     default: thisImage = 'DefaultImage.jpg';
  //   }

  //     const newChildDiv1 = document.createElement('div')
  //     newChildDiv1.setAttribute('class', 'child-pill')
  //     parent!.appendChild(newChildDiv1)

  //     const newImg = document.createElement('img')
  //     newImg.setAttribute('class', 'picture')
  //     newImg.setAttribute('src', `./assets/${thisImage}`)
  //     newImg.setAttribute('width', '200')
  //     newImg.setAttribute('height', '200')
  //     parent!.appendChild(newImg)

  //     const newChildP1 = document.createElement('p')
  //     newChildP1.innerHTML = "price : 2000"
  //     const newChildP2 = document.createElement('p')
  //     newChildP2.innerHTML = `name : ${product.breedName}`

  //     newChildDiv1.appendChild(newChildP1)
  //     newChildDiv1.appendChild(newChildP2)

  // }
}

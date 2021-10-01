import { Component, OnInit } from '@angular/core';
import { Product } from '../_models/product';
import { ProductPillGeneratorService } from '../_services/product-pill-generator.service'
import { ProductService } from '../_services/product.service'

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private productPillGeneratorService: ProductPillGeneratorService, private productService: ProductService) { }
  public product: Product[] = [];

  ngOnInit(): void {

    this.productService.getAllProduct().subscribe(a => { this.product = a

      const parent = document.getElementById('products')
      this.product.forEach(element => {
        
        let thisImage = 'DefaultImage.jpg'

        if (element.id == 1) {
          thisImage = "1.jpg"
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
      });
    });
  }
}



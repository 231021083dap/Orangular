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

  // public productPicture : string = 'DefaultImage.jpg'

  // public defaultImage: string = `assets/${this.productPicture}`

  constructor(private productPillGeneratorService: ProductPillGeneratorService, private productService: ProductService) { }
  public product: Product[] = [];

  ngOnInit(): void {
    console.log(this.productPillGeneratorService.testHelloWorld());
    //  this.productPillGeneratorService.testGetProductPillContent();


    this.productService.getAllProduct().subscribe(a => {
      this.product = a
      console.log(this.product);

      console.log(a);

      const parent = document.getElementById('products')
      // Loop igemmen array
      this.product.forEach(element => {
        
        console.log(element.id)
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
        // width="500" height="600"
        parent!.appendChild(newImg)

        const newChildP1 = document.createElement('p')
        newChildP1.innerHTML = "price : 2000"

        const newChildP2 = document.createElement('p')
        setInterval(() => { newChildP2.innerHTML = `name : ${element.breedName}` }, 1000);
        newChildDiv1.appendChild(newChildP1)
        newChildDiv1.appendChild(newChildP2)
      });

      

    });




    // setInterval(()=> { console.log(this.product[0].breedName) }, 1000);
    // console.log("Hello world from ngOnInit()")
    // document.getElementById("testID")!.innerHTML = "home-page works! Hello world from ngOnInit()"
    // document.getElementById("testID");
    // document.getElementById("testID")!.innerHTML = "hey";

    // Dette eksempel viser at vi kan tage et html element og tilføje et child element
    





    // const elementTR = document.createElement("tr");
    // const edit = document.createElement("td");
    // edit.setAttribute('class', '_main-createpc-list-pc-table-edit')
    // edit.setAttribute('id', `_main-createpc-list-pc-table-edit-${list.list[i].serialnr}`)
    // edit.innerHTML = 'Rediger'
    // elementTR.appendChild(edit)
    // document.getElementById('_main-createpc-list-pc-table').appendChild(elementTR)
  }


  myConsoleLog(myString: string): void {
    console.log(myString)
  }

}



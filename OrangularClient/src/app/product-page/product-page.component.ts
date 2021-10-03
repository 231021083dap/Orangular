import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Params } from '@angular/router';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {      
      let productName = params.productName; 
      alert(productName)
    });
  }

}

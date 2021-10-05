import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Params } from '@angular/router';
import { ProductPillItemService } from '../_services/product-pill-item.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {

  constructor(private route: ActivatedRoute, private productPillItemService: ProductPillItemService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {      
      let productId = params.productId; 
      this.productPillItemService.productPillItem(productId);
    });
  }

}

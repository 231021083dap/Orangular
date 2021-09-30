
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ProductService } from 'src/app/_services/product.service';
import { Product } from 'src/app/_models/product';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  id : number = 0;
  product: Product = {
    id: 0,
      breedName: "",
      weight: 0,
      price: 0,
      gender: '',
      description: ''
      //categoryId: 0,
      // category: {
      //   id: 0,
      //   categoryName: "",
      // },
  };

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private productService: ProductService
  ) { }

  ngOnInit(): void {
    this.getProduct();
  }

  getProduct(): void {
    this.id = (this.route.snapshot.paramMap.get('id') || 0) as number;
    console.log(this.id);
    this.productService.getProduct(this.id).subscribe(
      product => {
        this.product = product;
        if (this.product == null) {
          this.location.go("/product")
        }
      }
    )
  }
}
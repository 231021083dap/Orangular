import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ProductService } from '../_services/product.service';
import { stringify } from '@angular/compiler/src/util';
import { Product } from '../_models/product';
import { Category } from '../_models/category';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {
  product: Product[] = [];
  category: Category[] = [];
  addProductEnabled: boolean = true;
  productEditIndex: number = -1;
  categoryEditIndex: number = -1;

  isAdmin: boolean = true;


  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private productService: ProductService,
  ) {}

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    //checks if it should sort by categoryId
    if( this.location.path().includes ("products/category/") ){
      var categoryId = (this.route.snapshot.paramMap.get('category_id') || 0) as number;
      this.productService.getProductsByCategoryId(categoryId)
        .subscribe(product => this.product = product)
    } else { //else it just gets everything
      this.productService.getProducts()
        .subscribe(product => this.product = product)
    }
  }



  deleteProduct(product: Product) {
    this.product = this.product.filter(a => a != product);
    this.productService.deleteProduct(product.id).subscribe()
  }

  addProduct(): void {
    var product: Product = {
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
    this.product.push(product);
    this.openEditProduct(this.product.length - 1);
  }

  openEditProduct(index: number) { //Hides the big + button, and sets the current editing target
    this.productEditIndex = index;
    this.addProductEnabled = false;
  }

  closeEditProduct(){ //Unhides the big + button, and resets the editing target
    this.productEditIndex = -1;
    this.addProductEnabled = true;
  }

  editProduct(product: Product, index: number): void {
    var last_index = this.product.length - 1;

    //Tilføjer nyt produkt
    if (this.product[index].id == 0) { 
      this.productService.addProduct(product)
        .subscribe(product => {
          this.product[last_index] = product;
          this.closeEditProduct();
        }
      )
    }
    //retter eksiterende produkt
    else {
      this.productService.updateProduct(this.product[this.productEditIndex].id, product)
        .subscribe(product =>{ //after Api call, the product is updated on the frontend without reloading
          var updated_product = this.product[this.productEditIndex];

          updated_product.breedName = product.breedName;
          updated_product.price = product.price;
          updated_product.weight = product.weight;
          updated_product.gender = product.gender;
          updated_product.description = product.description;


          this.closeEditProduct();
        }
      )
    }
  }
}
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Category } from 'src/app/_models/category';
import { Product } from 'src/app/_models/product';
import { ProductService } from 'src/app/_services/product.service';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  
  //categories: Category[] = [];
  
  @Input() product : Product
  @Output() updateEvent = new EventEmitter<boolean>();
  @Output() cancelEvent = new EventEmitter<boolean>();

  constructor(
    private productService : ProductService,
    public formBuilder: FormBuilder,

  ) { }

  productForm = this.formBuilder.group({
    id: 0,
    breedName: "",
    weight: 0,
    price: 0,
    gender: '',
    description: ''
    //images: "",
  });

  productInitial: Product;

  ngOnInit(): void {
    //this.getCategories();
    this.productForm.controls['breedName'].setValue(this.product.breedName);
    this.productForm.controls['price'].setValue(this.product.price);
    this.productForm.controls['weight'].setValue(this.product.weight);
    this.productForm.controls['gender'].setValue(this.product.gender);
    this.productForm.controls['description'].setValue(this.product.description);
    //this.productForm.controls['categoryid'].setValue(this.product.categoryid);
    //this.productForm.controls['images'].setValue(this.product.images);
  }

  // getCategories(): void {
  //   this.productService.getCategories()
  //     .subscribe(category => {
  //       this.categories = category;
  //     }
  //   )
  // }

  editProduct(): void {
    console.warn('Succes', this.productForm.value);
    this.productForm.reset();
  }

  submit(): void {
    var product = this.productForm.value;
    product.categoryId = parseInt(product.categoryId);
    console.log(product)
    this.updateEvent.emit(product);
  }

  cancel(): void {
    this.cancelEvent.emit();
  }
}
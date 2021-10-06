import { Component, OnInit } from '@angular/core';
import { Product } from '../../_models/product'
import { ProductService } from '../../_services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  public products : Product[] = [];
  
  public getByIdProduct : Product = { id: 0, breedName: '', price: 0, weight: 0, gender: '', description: ''}
  public createProduct : Product = { id: 0, breedName: '', price: 0, weight: 0, gender: '', description: ''}
  public updateProduct : Product = { id: 0, breedName: '', price: 0, weight: 0, gender: '', description: ''}

  public getId : number = 0;
  public updateId : number = 0;
  public deleteId : number = 0
  
  constructor(private productService:ProductService) { }

  ngOnInit(): void {
    // Opdatere getAll listen en gang i sekundet.
    setInterval(()=> { this.getAll(false) }, 1000);
  }
  // ---------------------- Get all Products ---------------------- -->
  getAll(log : boolean) : void {
    this.productService.getAllProduct().subscribe(u=> {
      this.products = u
      if (log) console.log(this.products[0])
    })
  }
  // ---------------------- Get user by id ---------------------- -->
  getById(id : number) : void {
    this.productService.getById(id).subscribe(
      u=> {
        console.log(u);
        this.getByIdProduct = u;
      }
    )
  }
  // ---------------------- Create Product ---------------------- -->
  create(createProduct: Product) : void {
    this.productService.create(createProduct).subscribe(c =>
      {
        this.createProduct  =  {
          id: 0,
          breedName: '',
          price: 0,
          weight: 0,
          gender: '',
          description: '',
        }
        console.log(c);
      })
  }
  // ---------------------- Update Product ---------------------- -->
  update(id : number, updateProduct : Product) : void {
    this.productService.update(id ,updateProduct).subscribe(u => {
      this.updateProduct = u
      console.log(this.updateProduct);
      this.updateId = 0;
      this.updateProduct  =  {
        id: 0,
        breedName: '',
        price: 0,
        weight: 0,
        gender: '',
        description: '',
      }
    })
  }
  // ---------------------- Delete Product ---------------------- -->
  delete(id : number) : void {
    this.productService.delete(id).subscribe(d => {this.updateId = 0;})
  }

}

import { Component, OnInit } from '@angular/core';
import { Product } from '../../_models/product'
import { Category } from 'src/app/_models/category';
import { ProductService } from '../../_services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  public products : Product[] = [];
  public category : Category[] = [];
  public getByIdProduct : Product = {
    id: 0,
    breedName: '',
    price: 0,
    weight: 0,
    gender: '',
    description: ''
    
  }
  public id : number = 1; // bruges af getById
  public newProduct : Product = {
    id: 0,
    breedName: '',
    price: 0,
    weight: 0,
    gender: '',
    description: ''
    
  };
  public updateProduktId : number = 1;
  public updateProduct : Product =  {
    id: 0,
    breedName: '',
    price: 0,
    weight: 0,
    gender: '',
    description: '',
    category: [{id: 0, categoryName: ''}]
    
  }
  public deleteProductid : number = 1


  product:Product[] = [];
  constructor(private productService:ProductService) { }

  ngOnInit(): void {
    // Opdatere getAll listen en gang i sekundet.
    setInterval(()=> { this.getAll(false) }, 1000);

    // this.getAll(true)
    // this.productService.update(2).subscribe(u => {console.log(u);})

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
  create(product: Product) : void {
    this.productService.create(product).subscribe(c =>
      {
        // this.newProduct = c
        console.log(c);
        
      })
  }



  // ---------------------- Update Product ---------------------- -->
  update(id : number, product : Product) : void {
    this.productService.update(id ,product).subscribe(u => {
      this.updateProduct = u
      console.log(u);
      
    })
  }



  // ---------------------- Delete Product ---------------------- -->
  delete(id : number) : void {
    this.productService.delete(id).subscribe(
      d => console.log(d)
    )
  }

}

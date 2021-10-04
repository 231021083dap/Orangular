import { Component, OnInit } from '@angular/core';
import { ProductPillGeneratorService } from '../_services/product-pill-generator.service';

@Component({
  selector: 'app-search-page',
  templateUrl: './search-page.component.html',
  styleUrls: ['./search-page.component.css']
})
export class SearchPageComponent implements OnInit {
  public name : string = ""
  public minprice : number = 100
  public maxprice : number = 1000

  constructor(
    private productPillGeneratorService: ProductPillGeneratorService
    ) {}

  ngOnInit(): void {
    
  }

  searchByBreedName() : void {
    this.productPillGeneratorService.getProducts(
      'search-page-body',
      'searchByBreedName',
      {breedName: `${this.name}`});
  }

  searchByMinMaxPrice() : void {
    this.productPillGeneratorService
    .getProducts(
    'search-page-body', 
    'searchByMinMaxPrice',
    {
      minPrice: `${this.minprice}`,
      maxPrice: `${this.maxprice}`
    });
    console.log(`minprice: ${this.minprice} maxprice: ${this.maxprice}`)
  }
}

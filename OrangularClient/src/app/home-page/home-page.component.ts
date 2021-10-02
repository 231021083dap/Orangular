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

  constructor(
    private productPillGeneratorService: ProductPillGeneratorService,
    private productService: ProductService
    ) { }

  public allProducts: Product[] = [];
  public sortedProducts: Product[] = [];

  ngOnInit(): void {


    // Victor ---- //
    // Problem
    // Vi skal hente de tre sidste tilføjet produkter
    
    // Løsning
    // 1) Hent alle objekter
    this.productService.getAllProduct().subscribe(p => 
      {
        this.allProducts = p
        // console.log(this.allProducts)
      })
        
    // 2) Sorter uønskede objekter fra


    // 3) Skab en pille for hvert objekt
    // Victor ---- //
    


    
  //  this.productPillGeneratorService.getProducts('getThreeNewestProducts', {});
   this.productPillGeneratorService.getProducts('getCategory', {categoryName : 'dog'});
  //  this.productPillGeneratorService.getProducts('_searchBreedNametest', {breedName: "Russel"});

      
  }
}



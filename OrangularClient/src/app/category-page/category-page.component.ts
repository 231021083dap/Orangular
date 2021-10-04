import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Params } from '@angular/router';
import { ProductPillGeneratorService } from '../_services/product-pill-generator.service';


@Component({
  selector: 'app-category-page',
  templateUrl: './category-page.component.html',
  styleUrls: ['./category-page.component.css']
})
export class CategoryPageComponent implements OnInit {

  constructor(private route: ActivatedRoute, private productPillGeneratorService: ProductPillGeneratorService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {      
      let id = params.id; 
      console.log(id);
      
      this.productPillGeneratorService.getProducts('category-page-body', 'getCategory', {id : id});
    });
  }
}

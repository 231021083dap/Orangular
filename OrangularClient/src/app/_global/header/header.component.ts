import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/_models/category';
import { CategoryService } from 'src/app/_services/category.service';
import { ProductPillGeneratorService } from '../../_services/product-pill-generator.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  categories: Category[] = [];
  constructor(private categoryService: CategoryService, private productPillGeneratorService: ProductPillGeneratorService) { }

  ngOnInit(): void {
    this.getAllCategory();
  }

  getAllCategory(): void {
    this.categoryService.getAllCategory().subscribe(a => this.categories = a);
  }

  public clearProducts() :void {
    this.productPillGeneratorService.clearProducts();
  }
}

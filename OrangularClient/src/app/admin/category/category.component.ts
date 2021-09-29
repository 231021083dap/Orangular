import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/_models/category';
import { CategoryService } from 'src/app/_services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categories: Category[] = [];
  category: Category = { id: 0, categoryName: ""}

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.getAllCategory();
  }
  //-----------------------------------------------------------------------------------------------------------
  // Functions for category
  refreshPage() {
    window.location.reload();
  }
  getAllCategory(): void {
    this.categoryService.getAllCategory().subscribe(a => this.categories = a);
  }

}

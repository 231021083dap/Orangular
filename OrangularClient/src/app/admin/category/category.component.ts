import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/_models/category';
import { CategoryService } from 'src/app/_services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  category:Category[] = [];
  constructor(private categoryService:CategoryService) { }

  ngOnInit(): void {
    this.categoryService.getAllCategory().subscribe(a => this.category = a);
  }

}

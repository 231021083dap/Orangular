import { Component, OnInit } from '@angular/core';
import { Category } from '../models';
import { CategoryService } from '../category.service';
@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html', 
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  //declaring a empty array named Category
  Category: Category[] = []; 

  constructor(private categoryService:CategoryService) { }

  ngOnInit(): void {
    this.categoryService.getCategory()
    .subscribe(c => this.Category = c);
  }

}

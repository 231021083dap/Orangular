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
  category: Category = { id: 0, categoryName: "" };
  

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.getAllCategory();
    // this.test();
  }
  //-----------------------------------------------------------------------------------------------------------
  // Functions for category page
// test(){
//   var tableRef = document.getElementById('categoryButtonTable')?.getElementsByTagName('tbody')[0];
//   var titleRow = tableRef!.insertRow(tableRef!.rows.length);
//   var dataRow = tableRef!.insertRow(tableRef!.rows.length);

//   var htmlContentTitle = "<th >CategoryId</th> <th colspan=2>CategoryName</th>";
//   var htmlContentData = "<td >CategoryId</td> <td colspan=2>CategoryName</td>";


//   titleRow.innerHTML = htmlContentTitle;
//   dataRow.innerHTML = htmlContentData;
 
// }

  refreshPage() {
    window.location.reload();
  }
  selectCategoriesRow(id: number): void {
    this.categories.forEach(element => {
      if (element.id == id) this.category = {id: element.id, categoryName: element.categoryName}
    });
  };
  //-----------------------------------------------------------------------------------------------------------
  // Category CRUD
  getAllCategory(): void {
    this.categoryService.getAllCategory().subscribe(a => this.categories = a);
  }
  createCategory(): void {
    console.log(this.category)
    if (this.category.id == 0) {
      this.categoryService.createCategory(this.category).subscribe(a => {
        this.categories.push()
        this.refreshPage()
      });
    }
  }
  updateCategory(UpdateId: number): void {
       this.selectCategoriesRow(UpdateId);
       this.categoryService.updateCategory(this.category.id, this.category).subscribe(() => {})
       this.refreshPage();
  };
  deleteCategory(DeleteId: number): void{
    this.selectCategoriesRow(DeleteId);
    this.categoryService.deleteCategory(this.category.id).subscribe();
    this.refreshPage();
  }
}

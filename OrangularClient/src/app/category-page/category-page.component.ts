import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Params } from '@angular/router';

@Component({
  selector: 'app-category-page',
  templateUrl: './category-page.component.html',
  styleUrls: ['./category-page.component.css']
})
export class CategoryPageComponent implements OnInit {


  constructor( private route: ActivatedRoute ) { }
  
  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
    let breedName = params.breedName; // same as :username in route
    console.log(breedName);

    const newChildP1 = document.createElement('p')
    newChildP1.innerHTML = breedName

    const test = document.getElementById('test')
    test!.innerHTML = breedName
  });
  }

}

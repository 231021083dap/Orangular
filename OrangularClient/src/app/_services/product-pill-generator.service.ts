import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductPillGeneratorService {

  constructor() { }

  testHelloWorld() : string {
    return "Hello World from product-pill-generator.service";
  }

  // retunere indenholdet af product-pill.component.html
  // testGetProductPillContent(htmlId, newContent) : void {
  //   var test = document.getElementById("testID");
  //   test!.innerHTML = "hey from service";

    // document.getElementById(htmlId)!.innerHTML = newContent
  // }

  // testReturnGetProductPillContent(htmlId: string, newContent: string) : string {
  //   return document.getElementById(htmlId)!.innerHTML = newContent;
  // }
}





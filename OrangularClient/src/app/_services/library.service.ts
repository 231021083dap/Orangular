import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LibraryService {

  constructor() { }

  // public convertPriceTo(convertTo : string, convertParam : number) : number {
  //   let result = 0;
  //   switch (convertTo) {
  //     case 'ore': result = convertParam * 100; break;
  //     case 'kroner': result = convertParam / 100; break;
  //     default: console.log(`switch (convertTo) is default. returning 0 input: ${convertTo}`); break;
  //   }
  //   // console.log(`result/return value ${result}`);    
  //   return result;
  // }

  // public convertWeightTo(convertTo : string, convertParam : number) : number {
  //   let result = 0;
  //   switch (convertTo) {
  //     case 'gram': result = convertParam * 1000; break;
  //     case 'kilo': result = convertParam / 1000; break;
  //     default: console.log(`switch (convertTo) is default. returning 0 input: ${convertTo}`); break;
  //   }
  //   // console.log(`result/return value ${result}`);    
  //   return result;
  // }


}
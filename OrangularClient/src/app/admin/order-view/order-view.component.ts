import { Component, OnInit } from '@angular/core';
import { OrderList } from 'src/app/_models/order-list';
import { OrderListService } from '../../_services/order-list.service'
import { User } from 'src/app/_models/user';


@Component({
  selector: 'app-order-view',
  templateUrl: './order-view.component.html',
  styleUrls: ['./order-view.component.css']
})
export class OrderViewComponent implements OnInit {

  public orders : any[] = []
  public id : number = 0;
  public datetime : any;
  public userId : number = 0;
  public email : string = '';

  
  constructor(
    private orderListService: OrderListService
    ) { }

  ngOnInit(): void {

    setInterval(  ()=> { this.getAll(true) }, 1000);
  }

  getAll(log : boolean) : void {    
    this.orderListService.getAll().subscribe(o=> {
      this.orders = o
      if (log) console.log(o)
    })

  }

}

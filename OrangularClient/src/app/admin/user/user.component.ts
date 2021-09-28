import { Component, OnInit } from '@angular/core';
import { UserService } from '../../_services/user.service'

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAll()   
    .subscribe(x=> {
      console.log(x)
      console.log("Hello World from ngOninit")
      // this.userService = x
    })
  }
}

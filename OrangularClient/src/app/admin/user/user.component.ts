import { Component, OnInit } from '@angular/core';
import { UserService } from '../../_services/user.service'

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  public users : UserService[] = [];
  // public user 

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAll()   
    .subscribe(u=> {
      console.log("Hello World from ngOninit")
      console.log(u)
      
    })
  }
}

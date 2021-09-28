import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from '../../_services/user.service'

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  public users : User[] = [];
  // public user : User = {};

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAll()   
    .subscribe(u=> {
      console.log("Hello World from ngOninit")
      console.log(u)
      this.users = u
    })
  }
}

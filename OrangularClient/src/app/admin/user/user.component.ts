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
  public user : User = {}
  public id : number = 1; // bruges af getById

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAll()   
    .subscribe(u=> {
      console.log("Hello World from ngOninit")
      console.log(u)
      this.users = u
    })
  }

  getById(id : number) : void {
    this.userService.getById(id).subscribe(
      u=> {
        this.user = u;
      }
    )
  }
}

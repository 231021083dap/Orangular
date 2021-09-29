import { Component, OnInit } from '@angular/core';
import { Role } from 'src/app/_models/role';
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
  public newUser : User = {email: 'victor', password: 'passwr0123'}


  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getAll();
    // console.log(JSON.stringify(this.user))
    this.userService.create(this.newUser)

  }



  // ---------------------- Get all users ---------------------- -->
  getAll() : void {
    this.userService.getAll()   
    .subscribe(u=> {
      console.log(u)
      this.users = u
    })
  }
  // ---------------------- Get all users ---------------------- -->



  // ---------------------- Get user by id ---------------------- -->
  getById(id : number) : void {
    this.userService.getById(id).subscribe(
      u=> {
        this.user = u;
      }
    )
  }
  // ---------------------- Get user by id ---------------------- -->



  // ---------------------- Create User ---------------------- -->
  create(user: User) : void {
    
    let x = {email: user.email, password: user.password}
    console.log(x)
  }
  // ---------------------- Create User ---------------------- -->



  // ---------------------- Delete User ---------------------- -->
  // ---------------------- Delete User ---------------------- -->



  // ---------------------- Update User ---------------------- -->
  // ---------------------- Update User ---------------------- -->
}

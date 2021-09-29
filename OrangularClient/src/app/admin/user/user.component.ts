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
  public newUser : User = {};
  public updateUser : User = {}
  

  constructor(private userService: UserService) { }

  ngOnInit(): void {    
    // Opdatere getAll listen en gang i sekundet.
    setInterval(()=> { this.getAll(false) }, 1000);
    
    // this.getAll(true)
    // this.create(this.newUser)
  }



  // ---------------------- Get all users ---------------------- -->
  getAll(log : boolean) : void {    
    this.userService.getAll().subscribe(u=> {
      this.users = u
      if (log) console.log(u)
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
    this.userService.create(user).subscribe(c => {this.newUser = c})
  }
  // ---------------------- Create User ---------------------- -->



  // ---------------------- Update User ---------------------- -->
  // update(user : User) : void {
  //   this.userService.update(user).subscribe
  // }
  // ---------------------- Update User ---------------------- -->


  
  // ---------------------- Delete User ---------------------- -->
  // ---------------------- Delete User ---------------------- -->




}

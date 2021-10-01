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

  public updateUserId : number = 1;
  public updateUser : User = {}
  // {
  //   email: "updated@updated",
  //   password: "uptPassword",
  //   "role": Role.User
  // }
  public deleteUserId : number = 1


  constructor(private userService: UserService) { }

  ngOnInit(): void {    
    // Opdatere getAll listen en gang i sekundet.
    setInterval(()=> { this.getAll(false) }, 1000);
    
    this.userService.getAll().subscribe(
      u => console.log(u)
    )
    // this.getAll(true)
    // this.create(this.newUser)



    // update
    // component
    // this.update(3,this.updateUser)
    // service
    // this.userService.update(3,this.updateUser).subscribe(
    //   u => console.log(u)
    // )

    // delete
    // service
    // this.userService.delete(9).subscribe()
    // component
    


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
  update(id : number, user : User) : void {
    this.userService.update(id ,user).subscribe(u => {this.updateUser = u})
  }
  // ---------------------- Update User ---------------------- -->


  
  // ---------------------- Delete User ---------------------- -->
  delete(id : number) : void {
    this.userService.delete(id).subscribe(
      d => console.log(d)
    )
  }
  // ---------------------- Delete User ---------------------- -->




}

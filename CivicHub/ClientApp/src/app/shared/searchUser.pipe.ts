import { Pipe, PipeTransform } from '@angular/core';
import { User } from './user.model';
import {ApiService} from './api.service'
import { HttpClient } from '@angular/common/http';

@Pipe({
  name: 'searchUser'
})
export class SearchUser extends ApiService implements PipeTransform  {

  transform(value:any, args?:any): any {
    return this.searchUser(value);
}
user=new User();

searchUser(id:string):string{
    setTimeout(() => {
        console.info("-------");
        console.log(id);
        this.getUserById(id).subscribe((user:User) => {
          console.log("executed");
          console.log(user);
          this.user=user;
        });
    }, 2000);
    
    return this.user.firstName;  
}
    

}

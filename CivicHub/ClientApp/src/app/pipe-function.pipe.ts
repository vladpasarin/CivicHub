import { Pipe, PipeTransform } from '@angular/core';
import { ApiService } from './shared/api.service';
import { User } from './shared/user.model';

@Pipe({
  name: 'pipeFunction'
})
export class PipeFunctionPipe implements PipeTransform {

    organizer = new User();

    constructor(private api: ApiService) { }

    transform(value: string, args?: any): any {
        return this.getUserById(value);
    }

    getUserById(id: string) {
        console.info("---getUserById---");
        this.api.getUserById(id).subscribe((user: User) => {
            console.log("Executing function searchUserById...");
            this.organizer = user;
            return this.organizer.firstName;
        });
    }
}

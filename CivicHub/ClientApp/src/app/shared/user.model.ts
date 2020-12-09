export class User {
    id: number;
    firstName: string;
    lastName: string;
    mail: string;
    password:string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }
  
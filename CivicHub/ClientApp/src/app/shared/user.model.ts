export class User {
    id: string;
    firstName: string;
    lastName: string;
    mail: string;
    password:string;
    avatar: string;
    points: number;
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }
  
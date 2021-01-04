import { Issue } from "./issue.model";

export class User {
    id: string;
    firstName: string;
    lastName: string;
    mail: string;
    password:string;
    avatar: string;
    points: number;
    issues: Issue[];
    badgeType?:string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }
  
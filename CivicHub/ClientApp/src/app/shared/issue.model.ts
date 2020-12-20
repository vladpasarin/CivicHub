import { User } from "./user.model";

export class Issue {
    id: string;
    title:string;
    latitude: number;
    longitude: number;
    description: string;
    userId: string;
    organizer:User;
    firstName?: string;
    lastName?: string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }
  
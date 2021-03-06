import { User } from "./user.model";

export class Issue {
    id: string;
    title:string;
    latitude: number;
    longitude: number;
    description: string;
    userId: string;
    organizer:User;
    photos?:string[];
    firstName?: string;
    lastName?: string;
    numberOfSignatures?: number;
    selected?:boolean;
    latestState?:string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }
  
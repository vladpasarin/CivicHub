import { User } from './user.model';

export class Issue {
    id: number;
    title:string;
    latitude: number;
    longitude: number;
    description: string;
    photoPath:string;
    organizer: User;
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }
  
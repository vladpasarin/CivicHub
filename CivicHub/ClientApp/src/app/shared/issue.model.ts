export class Issue {
    id: string;
    title:string;
    latitude: number;
    longitude: number;
    description: string;
    userId: string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }
  
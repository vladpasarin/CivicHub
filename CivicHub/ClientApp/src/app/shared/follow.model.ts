export class Follow {
    userId: string;
    issueId: string;
    title?:string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }
  
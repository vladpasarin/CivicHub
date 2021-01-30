export class ResponseGiven {
    issueId: string;
    photos: string[];
    messageFromAuthorities: string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
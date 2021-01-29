export class SignatureSubmitted {
    issueId:string;
    photos:string[];
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
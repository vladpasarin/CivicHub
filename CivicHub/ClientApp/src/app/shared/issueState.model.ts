export class IssueState {
    id: string;
    issueId:string;
    type: number;
    message: string;
    dateStart: Date;
    dateEnd: Date;
    customMessage:string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }
  
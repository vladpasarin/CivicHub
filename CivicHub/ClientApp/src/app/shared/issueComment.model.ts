import { User } from "./user.model";

export class IssueComment {
    Id: string;
    IssueStateId: string;
    Text: string;
    UserId: string;
    dateCreated: Date;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
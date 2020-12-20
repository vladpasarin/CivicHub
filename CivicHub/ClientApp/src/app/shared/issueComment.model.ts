import { User } from "./user.model";

export class IssueComment {
    Id: string;
    IssueStateId: string;
    text: string;
    UserId: string;
    dateCreated: Date;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
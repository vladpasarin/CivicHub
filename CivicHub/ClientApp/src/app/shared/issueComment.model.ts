import { User } from "./user.model";

export class IssueComment {
    id: string;
    IssueStateId: string;
    text: string;
    UserId: string;
    dateCreated: Date;
    nrOfLikes? = 0;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
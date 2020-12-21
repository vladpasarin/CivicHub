import { User } from "./user.model";

export class IssueComment {
    id: string;
    IssueStateId: string;
    text: string;
    userId: string;
    dateCreated: Date;
    nrOfLikes? = 0;
    userName?:string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
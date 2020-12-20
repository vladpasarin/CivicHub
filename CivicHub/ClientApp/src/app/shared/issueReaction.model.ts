
export class IssueReaction {
    Id: string;
    IssueStateId: string;
    UserId: string;
    dateGiven: Date;
    Vote: string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
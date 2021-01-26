
export class IssueReaction {
    issueStateId: string;
    userId: string;
    vote: string;
    dateGiven: Date;
    id: string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
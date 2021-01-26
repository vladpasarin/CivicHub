
export class IssueReaction {
    id: string;
    issueStateId: string;
    userId: string;
    dateGiven: Date;
    vote: string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
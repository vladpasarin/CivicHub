
export class IssueReaction {
<<<<<<< HEAD
    id: string;
    issueStateId: string;
    userId: string;
    dateGiven: Date;
    vote: string;
=======
    issueStateId: string;
    userId: string;
    vote: string;
    dateGiven: Date;
    id: string;
>>>>>>> 8f3abebf2e20d40c2a80e3a01fa3c7059fb524f3
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
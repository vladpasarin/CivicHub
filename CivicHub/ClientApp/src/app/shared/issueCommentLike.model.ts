
export class IssueCommentLike {
    id: string;
    issueStateCommentId: string;
    userId: string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  

export class IssueCommentLike {
    Id: string;
    IssueStateCommentId: string;
    UserId: string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
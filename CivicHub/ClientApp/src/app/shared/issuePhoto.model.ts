export class IssuePhoto {
    id: string;
    issueStateId: string;
    photo: string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
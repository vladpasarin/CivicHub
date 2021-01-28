export class IssuePhoto {
    id: string;
    issueStateId: string;
    photo: string;
    dateAdded: Date;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  
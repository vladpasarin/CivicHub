import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { User } from "./user.model";
import { Request } from "./request";
import { Issue } from './issue.model';
import { IssueComment } from './issueComment.model';
import { IssueCommentLike } from './issueCommentLike.model';
import { Signature } from "./signature.model";

@Injectable({
  providedIn: "root",
})
export class ApiService {
  constructor(private http: HttpClient) {}

  header = new HttpHeaders({
    "Content-Type": "application/json",
  });
  baseUrl = "https://localhost:44397/api";

  
    getIssues() {
        return this.http.get(this.baseUrl + "/Issue/getAllWithUserDetails", 
        { headers: this.header });
    }

    getIssueById(issueId: string) {
      return this.http.get(this.baseUrl + "/Issue/" + issueId, {
        headers: this.header,
      });
    }

    getAllStatesByIssueId(issueId: string) {
      return this.http.get(this.baseUrl + "/IssueState/GetAllByIssueId/" + issueId, {
        headers: this.header,
      });
    }

    getAllCommentsByStateId(issueStateId: string) {
      return this.http.get(this.baseUrl + "/IssueStateComment/all/" + issueStateId, {
        headers: this.header,
      });
    }
    getAllSignaturesByStateId(issueStateId: string) {
      return this.http.get(this.baseUrl + "/IssueStateSignature/all/" + issueStateId, {
        headers: this.header,
      });
    }

  getUsers() {
    return this.http.get(this.baseUrl + "/auth/all", { headers: this.header });
  }

  getUserById(userId: string) {
    return this.http.get(this.baseUrl + "/auth/GetUser/" + userId, {
      headers: this.header,
    });
  }

    getLoginToken(request: Request) {
        return this.http.post(this.baseUrl + "/auth/login", request, {
            headers: this.header, observe: 'response',
        });
    }
    
  addUser(user: User) {
    return this.http.post(this.baseUrl + "/auth/register", user, {
      headers: this.header,
    });
    }
    addIssue(issue: Issue) {
        return this.http.post(this.baseUrl + "/Issue", issue, {
            headers: this.header,
        });
    }
  
    addComment(issueComment: IssueComment) {
      return this.http.post(this.baseUrl + "/IssueStateComment", issueComment, {
        headers: this.header,
      });
    }

    addCommentLike(issueCommentLike: IssueCommentLike) {
      
    }

    addSignature(signature:Signature){
      return this.http.post(this.baseUrl + "/IssueStateSignature", signature, {
        headers: this.header,
      });
    }
  
}

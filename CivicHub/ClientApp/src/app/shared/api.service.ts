import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { User } from "./user.model";
import { Request } from "./request";
import { Issue } from './issue.model';
import { IssueComment } from './issueComment.model';
import { IssueCommentLike } from './issueCommentLike.model';
import { Signature } from "./signature.model";
import { IssueReaction } from './issueReaction.model';
import { IssueReactByUser } from "./issueReactByUser.model";
import { PrizeGiven } from "./prizeGiven.model";

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
    getBagdeNumber(userId:string){
      return this.http.get(this.baseUrl + "/Gamification/GetBadgeNumber/" + userId, {
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

  getAllIssueStateCommentLikes(issueCommentId: string) {
    return this.http.get(this.baseUrl + "/IssueStateCommentLike/all/" + issueCommentId, {
      headers: this.header,
    });
  }

  getNumberOfUpvotesByState(issueStateId: string) {
    return this.http.get(this.baseUrl + "/IssueStateReaction/numberOfUpVotes/" + issueStateId, {
      headers: this.header,
    });
  }

  getNumberOfDownvotesByState(issueStateId: string) {
    return this.http.get(this.baseUrl + "/IssueStateReaction/numberOfDownVotes/" + issueStateId, {
      headers: this.header,
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

    addIssueReaction(issueReaction: IssueReaction) {
      return this.http.post(this.baseUrl + "/IssueStateReaction", issueReaction, {
        headers: this.header,
      }); 
    }
  
    addComment(issueComment: IssueComment) {
      return this.http.post(this.baseUrl + "/IssueStateComment", issueComment, {
        headers: this.header,
      });
    }

    addCommentLike(issueCommentLike: IssueCommentLike) {
      return this.http.post(this.baseUrl + "/IssueStateCommentLike", issueCommentLike, {
        headers: this.header,
      });
    }

    addSignature(signature:Signature){
      return this.http.post(this.baseUrl + "/IssueStateSignature", signature, {
        headers: this.header,
      });
    }

    checkIfUserLikedComment(userId: string, issueStateCommentId: string) {
      return this.http.get(this.baseUrl + "/IssueStateCommentLike/" + userId + "/" + issueStateCommentId, {
        headers: this.header,
      });
    }

    getAllPrizes() {
      return this.http.get(this.baseUrl + "/Prize/all", {
        headers: this.header,
      });
    }

    getPrizesByUser(userId: string) {
      return this.http.get(this.baseUrl + "/prizeGiven/userPrizes/" + userId, {
        headers: this.header,
      });
    }

    redeemPrize(prizeGiven: PrizeGiven){
      return this.http.post(this.baseUrl + "/prizeGiven", prizeGiven, {
        headers: this.header,
      });
    }

    /*getUserReactionToIssue(issueReactByUser: IssueReactByUser) {
      return this.http.get(this.baseUrl + "/IssueStateReaction/getUserReactionToIssueState/", issueReactByUser, {
        headers: this.header,
      });
    }*/

    /*deleteCommentLike(issueCommentLike: IssueCommentLike) {
      return this.http.delete(this.baseUrl + "/IssueStateCommentLike", issueCommentLike, {
        headers: this.header,
      });
    }*/
  
}

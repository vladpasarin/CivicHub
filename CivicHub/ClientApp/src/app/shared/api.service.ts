import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { User } from "./user.model";
import { Request } from "./request";
import { Issue } from './issue.model';

@Injectable({
  providedIn: "root",
})
export class ApiService {
  constructor(private http: HttpClient) {}

  header = new HttpHeaders({
    "Content-Type": "application/json",
  });
  baseUrl = "https://localhost:44397/api";

    /*
  getUser(id: number) {
    return this.http.get(this.baseUrl + "/User/" + id.toString(), {
      headers: this.header,
    });
  }
  */
    getIssues() {
        return this.http.get(this.baseUrl + "/Issue/getAllWithUserDetails", { headers: this.header });
    }
    getIssueById(issueId: string) {
      return this.http.get(this.baseUrl + "/Issue/" + issueId, {
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
  
}

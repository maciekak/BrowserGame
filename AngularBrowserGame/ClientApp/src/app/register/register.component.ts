import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'my-auth-token'
    })
  }

  account: Account = {
    email: '',
    username: '',
    password: ''
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  register() {
    this.http.post<Account>(this.baseUrl + 'api/account/register', this.account, this.httpOptions).subscribe(() => this.account = this.account);
  }
}

interface Account {
  email: string;
  username: string;
  password: string;
}

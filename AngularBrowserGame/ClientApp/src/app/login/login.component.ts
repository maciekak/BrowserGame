import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {

  account: Account = {
    email: '',
    username: '',
    password: ''
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  login() {
    this.http.post<Account>(this.baseUrl + 'api/account/login', this.account).subscribe(() => this.account = this.account);
  }
}

interface Account {
  email: string;
  username: string;
  password: string;
}

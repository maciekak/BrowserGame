import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-logged',
  templateUrl: './logged.component.html'
})
export class LoggedComponent {
  public logged: boolean;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<boolean>(baseUrl + 'api/account/logged').subscribe(result => {
      this.logged = result;
    }, error => console.error(error));
  }
}

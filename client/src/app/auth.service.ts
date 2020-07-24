import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loginUrl = environment.apiUrl + 'login';
  private registerUrl = environment.apiUrl + 'register';
  constructor(private http: HttpClient) { }

  login(data): Observable<any> {
    return this.http.post(this.loginUrl, data);
  }

  register(data): Observable<any> {
    return this.http.post(this.registerUrl, data);
  }
}

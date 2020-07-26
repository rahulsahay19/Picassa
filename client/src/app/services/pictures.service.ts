import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Picture } from '../models/picture';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PicturesService {
  private picturePath = environment.apiUrl + 'pictures/'
  constructor(private httpClient: HttpClient) { }

  postPicture(data): Observable<Picture> {
    return this.httpClient.post<Picture>(this.picturePath, data);
  }
}

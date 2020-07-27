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
  constructor(private http: HttpClient) { }

  postPicture(data): Observable<Picture> {
    return this.http.post<Picture>(this.picturePath, data);
  }

  getPictures(): Observable<Array<Picture>> {
    return this.http.get<Array<Picture>>(this.picturePath);
  }

  getPicture(id): Observable<Picture> {
    return this.http.get<Picture>(this.picturePath + id);
  }

  deletePicture(id): Observable<Picture> {
    return this.http.delete<Picture>(this.picturePath + id);
  }
}

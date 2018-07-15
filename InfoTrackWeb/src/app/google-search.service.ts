import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class GoogleSearchService {
  private _baseUrl = '/api/googleSearch/?';
  
  constructor(private http: HttpClient) { }

  getResult(keywords: string, url: string) {
    return this.http.get(this._baseUrl + 'keywords=' + keywords + '&url=' + url);
  }
}

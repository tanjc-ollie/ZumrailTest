import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { Post } from '../../../core/models/post';

import { environment } from "../../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  constructor(
    private _httpClient: HttpClient
  ) { }

  public getPostsAsync(tags: string, sortBy?: string, direction?: string): Observable<Post[]> {
    let headers = new HttpHeaders({
      'Access-Control-Allow-Origin': '*'
    });

    let params = new HttpParams()
      .set("tags", tags);
    if (!!sortBy)
      params = params.set("sortBy", sortBy);
    if (!!direction)
      params = params.set("direction", direction);

    return this._httpClient.get<Post[]>(`${environment.apiUrl}/posts`, { headers, params })
      .pipe(
        catchError((err) => {
          console.error(err);
          throw err;
        })
      );
  }
}

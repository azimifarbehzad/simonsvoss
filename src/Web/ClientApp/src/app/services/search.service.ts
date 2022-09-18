import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap, catchError, map, of } from 'rxjs';
import { environment } from 'src/environments/environment';
@Injectable({
    providedIn: "root",
  })
export class SearchService {
  url = environment.url + 'Search';

  constructor(private http: HttpClient) {}
  search(q: string): any {
    return this.http.get(this.url+ '?q=' + q).pipe(
      
      map((res) => {
        return res;
      }),
      catchError(this.handleError)
    );
  }

  private handleError(error: any) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('Client side network error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        'Backend - ' +
          `status: ${error.status}, ` +
          `statusText: ${error.statusText}, ` +
          `message: ${error.error.message}`
      );
    }
    return of(0);
  }
}

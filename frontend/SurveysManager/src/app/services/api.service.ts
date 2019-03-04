import { Injectable } from '@angular/core';                                                                                                                                                                                                                                                         //xyz
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  
  private url: string = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  sendRequest(
    type: RequestMethod,
    endpoint: string,
    body: any = {}) {

    let headers;
    if (type === RequestMethod.Post || type === RequestMethod.Put) {
        headers = new HttpHeaders({ 'Content-Type': 'application/json'});
    } else {
        headers = new HttpHeaders();
    }
    headers.append('Access-Control-Allow-Origin', '*');

    let request: Observable<any>;

    switch (type) {
        case RequestMethod.Get:
            request = this.httpClient.get(`${this.url}/${endpoint}`, { headers });
            break;
        case RequestMethod.Post:
            request = this.httpClient.post(`${this.url}/${endpoint}/`, body, { headers });
            break;
        case RequestMethod.Put:
            request = this.httpClient.put(`${this.url}/${endpoint}`, body, { headers });
            break;
        case RequestMethod.Delete:
            request = this.httpClient.delete(`${this.url}/${endpoint}`, { headers });
            break;
    }

    return request.pipe(
      catchError((res: HttpErrorResponse) => this.handleError(res))
  );
}

protected handleError(error: HttpErrorResponse | any): any {
  let errMsg: string;
  let errorData: any;
  if (error instanceof HttpErrorResponse) {
      errorData = error.error || '';
      const err = errorData || JSON.stringify(errorData);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
  } else {
      errMsg = error.Message ? error.Message : error.toString();
  }
  console.error(errMsg);

  if (errorData) {
      return throwError(errorData);
  }

  return throwError(errMsg);
}

  
}

export enum RequestMethod {
  Get,
  Post,
  Put,
  Delete,
}

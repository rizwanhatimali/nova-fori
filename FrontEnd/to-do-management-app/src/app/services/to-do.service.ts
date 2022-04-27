import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from "../../environments/environment";
import { ToDo, ToDoStatus } from '../interfaces/to-do';

const toDoUrl = environment.API_URL + 'api/ToDo/';
@Injectable({
  providedIn: 'root'
})
export class ToDoService {

  constructor(private http: HttpClient) { }

  getToDoListByStatus(status: number): Observable<any> {
      console.log(toDoUrl + 'ListItemsByStatus/' + status);
      return this.http.get(toDoUrl + 'ListItemsByStatus/' + status)
      .pipe(catchError(this.handleError));
  }

  insertToDoItem(toDoItem : ToDo) {
    console.log(toDoUrl + 'AddItem');
    return this.http.post(toDoUrl + 'AddItem', toDoItem)
    .pipe(catchError(this.handleError));
  }

  updateToDoItemStatus(toDoItemId : number) {
    console.log(toDoUrl + 'UpdateStatus/' + toDoItemId);
    return this.http.put(toDoUrl + 'UpdateStatus/' + toDoItemId, null)
    .pipe(catchError(this.handleError));
  }

  private handleError(err: HttpErrorResponse) {
    let errMsg: string = '';
    if (err.error instanceof Error) {
      console.log('An error occurred:', err.error.message);
      errMsg = err.error.message;
    }
    else {
      console.log(`Backend returned code ${err.status}`);
      errMsg = err.message;
    }

    return throwError(errMsg);
  }
}

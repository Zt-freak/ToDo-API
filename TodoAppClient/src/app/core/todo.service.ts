import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Todo } from './todo';
import { TodoData } from './todo-data';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  constructor(private http: HttpClient) {

  }

  getTodos(): Observable<Todo[]> {
    return this.http.get<TodoData>(
      "/api/todos"
    )
      .pipe(
        map(
          response => <Todo[]>response.results
        )
      );
  }

  toggleDone(id: number): Observable<Todo> {
    return this.http.get<Todo>(
      "/api/todo/" + id + "/check"
    )
      .pipe(
        map(
          response => <Todo>response
        )
      );
  }

  addTodo(todo: Todo): Observable<Todo> {
    return this.http.post<Todo>(
      "/api/todo/create", todo
    )
      .pipe(
        map(
          response => <Todo>response
        )
      );
  }

  removeTodo(id: number) {
    return this.http.get(
      "/api/todo/" + id + "/delete"
    )
  }
}

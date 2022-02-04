import { Component, OnInit } from '@angular/core';
import { Todo } from '../core/todo';
import { TodoService } from '../core/todo.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss']
})
export class TodoListComponent implements OnInit {

  todos: Todo[];
  newTodo: Todo = new Todo();
  constructor(private todoService: TodoService) {
    this.todos = [];
  }

  ngOnInit(): void {
    this.showTodos();
  }

  showTodos() {
    this.todoService.getTodos()
      .subscribe(
        response => {
          this.todos = response;
        }
      );
  }

  onKey(event: any, type: string) {
    switch(type) {
      case 'title':
        this.newTodo.title = event.target.value;
        break;
      case 'desc':
        this.newTodo.description = event.target.value;
        break;
    }
  }

  addNewTodo() {
    this.todoService.addTodo(this.newTodo)
      .subscribe(
        response => {
          this.todos.push(response);
        }
      );
  }

  removeTodoComponent(index: number) {
    this.todos.splice(index, 1);
  }
}

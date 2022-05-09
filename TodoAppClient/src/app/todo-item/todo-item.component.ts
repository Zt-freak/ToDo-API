import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Todo } from '../core/todo';
import { TodoService } from '../core/todo.service';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.scss']
})
export class TodoItemComponent implements OnInit {

  @Input() todo: Todo = new Todo();
  @Input() index: number | undefined;
  @Output() deleteEvent = new EventEmitter<number>();
  constructor(private todoService: TodoService) { }

  ngOnInit(): void {
  }

  changeChecked() {
    this.todoService.toggleDone(this.todo.id)
    .subscribe(
      response => {
        this.todo = response;
      }
    );
  }

  remove() {
    this.todoService.removeTodo(this.todo.id)
    .subscribe(
      () => {
        this.deleteEvent.emit(this.index);
      }
    )
  }
}

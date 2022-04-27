import { Component, Input, OnChanges, Output, EventEmitter, SimpleChanges } from '@angular/core';
import { ToDoService } from 'src/app/services/to-do.service';
import { ToDo, ToDoStatus } from 'src/app/interfaces/to-do';

@Component({
  selector: 'app-list-to-do',
  templateUrl: './list-to-do.component.html',
  styleUrls: ['./list-to-do.component.scss']
})
export class ListToDoComponent implements OnChanges {
  @Input() status : ToDoStatus = ToDoStatus.Pending;
  @Input() changeNotification : boolean = false;
  @Output() statusToggled : EventEmitter<boolean> = new EventEmitter<boolean>();
  toDoList : ToDo[] = [];

  constructor(public toDoService : ToDoService) { }
  ngOnChanges(changes: SimpleChanges): void {
    const listStatus : number = this.status;
    this.toDoService.getToDoListByStatus(listStatus).subscribe((data: ToDo[])=>{
      this.toDoList = data;
      console.log(this.toDoList);
    })  
  }

  toggleItemStatus(id:number){
    this.toDoService.updateToDoItemStatus(id).subscribe(res => {
         console.log('Status toggled successfully!');
         this.statusToggled.emit(true);
    })
  }
}

import { Component, OnInit } from '@angular/core';
import { ToDoService } from 'src/app/services/to-do.service';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { ToDoStatus } from 'src/app/interfaces/to-do';

@Component({
  selector: 'app-manage-to-do',
  templateUrl: './manage-to-do.component.html',
  styleUrls: ['./manage-to-do.component.scss']
})
export class ManageToDoComponent implements OnInit {
  public toDoStatus = ToDoStatus;
  public infoChange : boolean = false;

  form: FormGroup = new FormGroup({
    description: new FormControl('', [Validators.required])
  });;

  constructor(
    public toDoService : ToDoService,
    private router: Router
    ) { 
  }

  ngOnInit(): void {
  }

  refreshLists()
  {
    this.infoChange = !this.infoChange;
  }

  submit()
  {
    console.log(this.form.value);
    this.toDoService.insertToDoItem(this.form.value).subscribe(res => {
         console.log('To Do Item created successfully!');
         //this.router.navigateByUrl('manageToDo');
        this.infoChange = !this.infoChange;
    })
  }

}

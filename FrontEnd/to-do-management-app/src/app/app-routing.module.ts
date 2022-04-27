import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManageToDoComponent } from './ToDo/manage-to-do/manage-to-do.component';

const routes: Routes = [
  { path: '', redirectTo: 'manageToDo', pathMatch: 'full'},
  { path: 'manageToDo', component: ManageToDoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

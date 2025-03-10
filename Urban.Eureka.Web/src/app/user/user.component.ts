import { Component } from '@angular/core';
import { UserFormComponent } from './user.form/user.form.component';
import { UserListComponent } from './user.list/user.list.component';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [UserFormComponent, UserListComponent],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {

}

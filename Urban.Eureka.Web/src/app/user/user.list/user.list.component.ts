import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../model/user';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user.list.component.html',
  styleUrl: './user.list.component.css'
})
export class UserListComponent implements OnInit {

  listUsers: User[] = [];
  constructor(private service: UserService) { }

  ngOnInit(): void {
    this.service.users$.subscribe(users => { this.listUsers = users; });
    this.service.getAll();
  }

  delete(id: number): void {
    this.service.delete(id).subscribe(() => {
      this.listUsers = this.listUsers.filter(user => user.id !== id);
    });
  }

  selectUser(user: User): void {
    this.service.loadSelected(user);
  }

}

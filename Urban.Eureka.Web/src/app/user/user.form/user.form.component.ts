import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { User } from '../../model/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './user.form.component.html',
  styleUrl: './user.form.component.css'
})
export class UserFormComponent implements OnInit {
  formUser: User = { id: 0, name: '', email: '', telephone: '' };
  isEdit = false;

  constructor(private service: UserService) { }

  ngOnInit(): void {
    this.service.selectedUser$.subscribe(user => {
      if (user) {
        this.formUser = { ...user };
        this.isEdit = true;
      } else {
        this.formUser = { id: 0, name: '', email: '', telephone: '' };
        this.isEdit = false;
      }
    });
  }

  save(): void {
    if (this.isEdit) {
      this.service.update(this.formUser)
        .subscribe(() => {
          this.formUser = { id: 0, name: '', email: '', telephone: '' };
          this.isEdit = false
        });
    }
    else {
      this.service.save(this.formUser)
        .subscribe(() => {
          this.formUser = { id: 0, name: '', email: '', telephone: '' };
          this.isEdit = false;
        });
    }
  }
}

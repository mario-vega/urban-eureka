import config from '../../assets/config.json'
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { tap } from 'rxjs/operators';
import { User } from '../model/user';

@Injectable({ providedIn: 'root' })
export class UserService {

  private url = config.ApiUrl.url + '/User';
  private usersSubject = new BehaviorSubject<User[]>([]);
  private selectedUserSubject = new BehaviorSubject<User | null>(null);
  public users$ = this.usersSubject.asObservable();
  public selectedUser$ = this.selectedUserSubject.asObservable();

  constructor(private http: HttpClient) { }

  getAll(): void {
    this.http.get<User[]>(this.url).subscribe(users => this.usersSubject.next(users));
  }
  
  save(user: User): Observable<User> {
    return this.http.post<User>(this.url, user)
      .pipe(
        tap(newUser => {
          const users = this.usersSubject.value;
          this.usersSubject.next([...users, newUser]);
        })
      );
  }

  update(user: User): Observable<User> {
    return this.http.put<User>(this.url, user)
      .pipe(
        tap(() => {
          const users = this.usersSubject.value;
          const index = users.findIndex(u => u.id === user.id);
          users[index] = user;
          this.usersSubject.next(users);
        })
      );
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`);
  }

  loadSelected(user: User): void {
    this.selectedUserSubject.next(user);
  }

  clearSelected(): void {
    this.selectedUserSubject.next(null);
  }

}

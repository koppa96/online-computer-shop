import { AfterViewInit, Component } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { UserListResponse, UsersClient } from 'src/app/shared/clients';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.scss']
})
export class UserManagementComponent implements AfterViewInit {

  loadItems$: Subject<void>;
  userItems$: Observable<UserListResponse[]>;

  constructor(
    private usersClient: UsersClient
  ) {
    this.loadItems$ = new Subject<void>();
    this.userItems$ = this.loadItems$.pipe(
      switchMap(() => this.usersClient.listUsers())
    );
  }

  onCheckedChange(event: boolean, userId: string) {
    if (event) {
      this.usersClient.createAdministrator(userId)
        .subscribe(_ => console.log("Okés"));
    } else {
      this.usersClient.removeAdministrator(userId)
        .subscribe(_ => console.log("Nem okés"));
    }
  }

  ngAfterViewInit(): void {
    this.loadItems$.next();
  }


}

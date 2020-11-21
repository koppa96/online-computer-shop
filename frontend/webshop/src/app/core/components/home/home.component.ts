import { Component, OnInit } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private dialogService: NbDialogService) { }

  ngOnInit(): void {
  }

  openDialog() {
    this.dialogService.open(DialogComponent, {
      context: {
        value: 'teszt'
      }
    }).onClose.subscribe(x => console.log(x));
  }
}

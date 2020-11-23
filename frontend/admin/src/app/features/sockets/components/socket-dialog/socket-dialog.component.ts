import { Component, OnInit } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';

@Component({
  selector: 'app-new-socket-dialog',
  templateUrl: './socket-dialog.component.html',
  styleUrls: ['./socket-dialog.component.scss']
})
export class SocketDialogComponent implements OnInit {
  value: string;
  isNewElement: boolean;

  constructor(private dialogRef: NbDialogRef<SocketDialogComponent>) { }

  ngOnInit(): void {
  }

  onCreate() {
    this.dialogRef.close(this.value);
  }

  onModify() {
    this.dialogRef.close(this.value);
  }

  onCancel() {
    this.dialogRef.close();
  }


}

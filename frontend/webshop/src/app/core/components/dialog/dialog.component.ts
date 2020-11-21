import { Component, OnInit } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {
  value: string;

  constructor(private dialogRef: NbDialogRef<DialogComponent>) { }

  ngOnInit() {
  }

  onSend() {
    this.dialogRef.close(this.value);
  }
}

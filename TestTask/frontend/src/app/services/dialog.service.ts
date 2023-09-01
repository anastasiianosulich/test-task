import { Injectable, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatConfirmDialogComponent } from '../shared/mat-confirm-dialog/mat-confirm-dialog.component';

@Injectable({
  providedIn: 'root',
})
export class DialogService {
  @Input() confirmationMessage: string = '';

  constructor(private dialog: MatDialog) {}

  openConfirmDialog(message: string) {
    return this.dialog.open(MatConfirmDialogComponent, {
      width: '390px',
      panelClass: 'confirm-dialog-container',
      disableClose: true,
      data: {
        message: message,
      },
    });
  }
}

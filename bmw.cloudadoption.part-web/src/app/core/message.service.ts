import { Injectable } from '@angular/core';
import { HttpResponse } from '@angular/common/http';
import {MatSnackBar} from "@angular/material/snack-bar";

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(private matSnackBar: MatSnackBar) {
  }

  private openSnackBar(message: string, className?: any ) {
    this.matSnackBar.open(message, 'Close', {
      duration: 5000,
      horizontalPosition: 'center',
      verticalPosition: 'top',
      panelClass: className
    });
  }

  public showInfo(message: string, logIt: boolean = false) {
    if (logIt) {
      console.error(message);
    }
    this.openSnackBar(message, 'info-snackbar');
  }

  public showSuccess(message: string, logIt: boolean = true) {
    if (logIt) {
      console.error(message);
    }
    this.openSnackBar(message, 'success-snackbar');
  }

  public showError(message: string, logIt: boolean = true) {
    if (logIt) {
      console.error(message);
    }
    this.openSnackBar(message, 'error-snackbar');
  }

  public showResponseMessage(response: HttpResponse<any>, logIt: boolean = true) {
    const isError = response.status < 200 || response.status >= 300;
    if (isError) {
      // @ts-ignore
      return this.showError(response['error'] || response.statusText, logIt);
    } else {
      return this.showSuccess(response.statusText, logIt);
    }
  }
}

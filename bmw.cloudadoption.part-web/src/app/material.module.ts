import { NgModule } from '@angular/core';
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatListModule} from "@angular/material/list";
import {MatCardModule} from "@angular/material/card";
import {MatSelectModule} from "@angular/material/select";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {MatProgressBarModule} from "@angular/material/progress-bar";

@NgModule({
  imports: [
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatCardModule,
    MatSelectModule,
    MatSnackBarModule,
    MatProgressBarModule,
  ],
  exports: [
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatCardModule,
    MatSelectModule,
    MatSnackBarModule,
    MatProgressBarModule,
  ]
})
export class MaterialModule {}

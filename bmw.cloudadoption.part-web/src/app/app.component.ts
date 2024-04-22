import { Component } from '@angular/core';
import {TranslateService} from "@ngx-translate/core";
import {Observable} from "rxjs";
import {LoadingService} from "./core/loading.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Vehicle Part';
  isLoading: Observable<boolean>;

  constructor(public translate: TranslateService, private loadingService: LoadingService) {
    translate.use('de');
    translate.use('en');
    translate.setDefaultLang('en');

    this.isLoading = this.loadingService.isLoading;
  }

  setLang (value: string) {
    this.translate.use(value)
  }
}

import { Component } from '@angular/core';
import { BackendService } from './backend.service';
import {TranslateService} from "@ngx-translate/core";

@Component({
  selector: 'app-backend',
  templateUrl: './backend.component.html',
  styleUrls: ['./backend.component.scss'],
})
export class BackendComponent {
  selected: string = 'localhost';

  constructor(private backendService: BackendService,
              private translator: TranslateService,) {}
  
  valueChanged() {
    if (this.selected === 'localhost') {
      this.backendService.setPath('');
    } else {
      this.backendService.setPath(`/${this.selected}`);
    }
  }
}

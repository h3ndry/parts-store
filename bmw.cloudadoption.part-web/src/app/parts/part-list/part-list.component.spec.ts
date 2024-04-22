import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartListComponent } from './part-list.component';
import { RouterTestingModule } from '@angular/router/testing';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from "../../material.module";
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

describe('PartListComponent', () => {
  let component: PartListComponent;
  let fixture: ComponentFixture<PartListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ RouterTestingModule, MaterialModule, TranslateModule.forRoot(), HttpClientTestingModule ],
      declarations: [ PartListComponent ],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PartListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

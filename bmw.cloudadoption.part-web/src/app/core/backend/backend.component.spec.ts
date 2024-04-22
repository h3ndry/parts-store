import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BackendComponent } from './backend.component';
import { TranslateModule } from '@ngx-translate/core';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterTestingModule } from '@angular/router/testing';

describe('BackendComponent', () => {
  let component: BackendComponent;
  let fixture: ComponentFixture<BackendComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ TranslateModule.forRoot(), RouterTestingModule ],
      declarations: [ BackendComponent ],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BackendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

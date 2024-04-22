import { TestBed } from '@angular/core/testing';

import { MessageService } from './message.service';
import { MaterialModule } from "../material.module";

describe('MessageService', () => {
  let service: MessageService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [MaterialModule]
    });
    service = TestBed.inject(MessageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

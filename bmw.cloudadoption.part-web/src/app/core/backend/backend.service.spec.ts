import { TestBed } from '@angular/core/testing';
import { BackendService } from './backend.service';

describe('MessageService', () => {
  let service: BackendService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [BackendService]
    });
    service = TestBed.inject(BackendService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { PartService } from './part.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { MaterialModule } from "../material.module";
import { MockProvider } from 'ng-mocks';

describe('PartService', () => {
  let service: PartService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, MaterialModule],
      providers: [
        MockProvider(PartService, {
          // ToDo: simulate server updates every 5 seconds
          loadPartsAsync: () => service.loadPartsAsync(),
        }),
      ]
    });
    service = TestBed.inject(PartService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

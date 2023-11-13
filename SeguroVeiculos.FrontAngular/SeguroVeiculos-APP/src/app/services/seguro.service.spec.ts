/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SeguroService } from './seguro.service';

describe('Service: Seguro', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SeguroService]
    });
  });

  it('should ...', inject([SeguroService], (service: SeguroService) => {
    expect(service).toBeTruthy();
  }));
});

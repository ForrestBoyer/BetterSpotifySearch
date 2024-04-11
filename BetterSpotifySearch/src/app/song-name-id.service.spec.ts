import { TestBed } from '@angular/core/testing';

import { SongNameIdService } from './song-name-id.service';

describe('SongNameIdService', () => {
  let service: SongNameIdService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SongNameIdService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

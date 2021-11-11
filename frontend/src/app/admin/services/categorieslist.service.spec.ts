import { TestBed } from '@angular/core/testing';

import { CategorieslistService } from './categorieslist.service';

describe('CategorieslistService', () => {
  let service: CategorieslistService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategorieslistService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

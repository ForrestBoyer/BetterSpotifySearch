import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SimilarSearchComponent } from './similar-search.component';

describe('SimilarSearchComponent', () => {
  let component: SimilarSearchComponent;
  let fixture: ComponentFixture<SimilarSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SimilarSearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SimilarSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

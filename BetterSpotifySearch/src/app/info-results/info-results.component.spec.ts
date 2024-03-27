import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoResultsComponent } from './info-results.component';

describe('InfoResultsComponent', () => {
  let component: InfoResultsComponent;
  let fixture: ComponentFixture<InfoResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InfoResultsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfoResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

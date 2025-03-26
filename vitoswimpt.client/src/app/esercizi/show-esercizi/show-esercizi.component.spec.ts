import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowEserciziComponent } from './show-esercizi.component';

describe('ShowEserciziComponent', () => {
  let component: ShowEserciziComponent;
  let fixture: ComponentFixture<ShowEserciziComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowEserciziComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowEserciziComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

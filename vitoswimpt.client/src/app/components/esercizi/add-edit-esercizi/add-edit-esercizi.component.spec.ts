import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditEserciziComponent } from './add-edit-esercizi.component';

describe('AddEditEserciziComponent', () => {
  let component: AddEditEserciziComponent;
  let fixture: ComponentFixture<AddEditEserciziComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddEditEserciziComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditEserciziComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

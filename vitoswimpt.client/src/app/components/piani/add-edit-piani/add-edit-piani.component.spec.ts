import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPianiComponent } from './add-edit-piani.component';

describe('AddEditPianiComponent', () => {
  let component: AddEditPianiComponent;
  let fixture: ComponentFixture<AddEditPianiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddEditPianiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditPianiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

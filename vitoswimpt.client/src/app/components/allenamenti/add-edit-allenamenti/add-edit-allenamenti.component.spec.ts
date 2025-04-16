import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAllenamentiComponent } from './add-edit-allenamenti.component';

describe('AddEditAllenamentiComponent', () => {
  let component: AddEditAllenamentiComponent;
  let fixture: ComponentFixture<AddEditAllenamentiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddEditAllenamentiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditAllenamentiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PianiComponent } from './piani.component';

describe('PianiComponent', () => {
  let component: PianiComponent;
  let fixture: ComponentFixture<PianiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PianiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PianiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

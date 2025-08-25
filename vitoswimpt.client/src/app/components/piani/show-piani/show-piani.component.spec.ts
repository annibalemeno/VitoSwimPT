import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPianiComponent } from './show-piani.component';

describe('ShowPianiComponent', () => {
  let component: ShowPianiComponent;
  let fixture: ComponentFixture<ShowPianiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowPianiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowPianiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

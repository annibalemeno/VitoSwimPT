import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAllenamentiComponent } from './show-allenamenti.component';

describe('ShowAllenamentiComponent', () => {
  let component: ShowAllenamentiComponent;
  let fixture: ComponentFixture<ShowAllenamentiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowAllenamentiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowAllenamentiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

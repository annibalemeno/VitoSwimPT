import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailAllenamentiComponent } from './detail-allenamenti.component';

describe('DetailAllenamentiComponent', () => {
  let component: DetailAllenamentiComponent;
  let fixture: ComponentFixture<DetailAllenamentiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetailAllenamentiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailAllenamentiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

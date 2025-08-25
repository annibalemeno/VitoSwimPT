import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailPianiComponent } from './detail-piani.component';

describe('DetailPianiComponent', () => {
  let component: DetailPianiComponent;
  let fixture: ComponentFixture<DetailPianiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetailPianiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailPianiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { EserciziComponent } from './esercizi.component';

describe('EserciziComponent', () => {
  let component: EserciziComponent;
  let fixture: ComponentFixture<EserciziComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EserciziComponent],
      imports: [HttpClientTestingModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EserciziComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
    fixture.detectChanges();
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve training data from the server', () => {
    const mockEsercizi = [
      { ripetizioni: '4', distanza: 200, recupero: 60, stile: 'dorso' },
      { ripetizioni: '8', distanza: 100, recupero: 30, stile: 'rana' }
    ];

    //component.ngOnInit();

    const req = httpMock.expectOne('/allenamenti');
    expect(req.request.method).toEqual('GET');
    req.flush(mockEsercizi);

    //expect(component.esercizi).toEqual(mockEsercizi);
  });
});

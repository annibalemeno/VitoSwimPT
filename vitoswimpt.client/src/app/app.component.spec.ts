import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppComponent],
      imports: [HttpClientTestingModule]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve training data from the server', () => {
    const mockEsercizi = [
      { ripetizioni: '4', distanza: 200, recupero: 60, stile: 'dorso' },
      { ripetizioni: '8', distanza: 100, recupero: 30, stile: 'rana' }
    ];

    component.ngOnInit();

    const req = httpMock.expectOne('/allenamenti');
    expect(req.request.method).toEqual('GET');
    req.flush(mockEsercizi);

    expect(component.esercizi).toEqual(mockEsercizi);
  });
});

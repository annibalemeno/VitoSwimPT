import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiserviceService } from '../../../apiservice.service';
import { Esercizi } from '../../../interfaces/esercizi';

@Component({
  selector: 'app-detail-allenamenti',
  standalone: false,
  templateUrl: './detail-allenamenti.component.html',
  styleUrl: './detail-allenamenti.component.css'
})
export class DetailAllenamentiComponent implements OnInit {
  id = 0;

  allenamentoId = 0;    //duplicato
  nomeAllenamento = "";
  note = "";

  public eserciziAllenamento: any;  //eserciziAllenamento
  public eserciziAssociabiliAllenamento: any;  //eserciziAllenamento

  constructor(private router: Router,
    public route: ActivatedRoute, private service: ApiserviceService) {

    this.id = Number(this.route.snapshot.paramMap.get('id')); //get id parameter
    console.log('Id chiamante = ' + this.id);
  }

  ngOnInit(): void {
    this.refreshGrid();
  }

  disassocia(esercizio: Esercizi) {
    /*console.log('Esercizio da disassociare= ' ,esercizio, 'ad Allenamento', this.id);*/
    this.service.disassociaEsercizioAllenamento(this.id, esercizio.esercizioId).subscribe(data => {
      this.refreshGrid();
    });
    
  }

  associa(esercizio: Esercizi) {
    this.service.associaEsercizioAllenamento(this.id, esercizio.esercizioId).subscribe(data => {
      this.refreshGrid();
    });
  }

  refreshGrid() {
    this.getEsercizioAllenamentoData(this.id);
    this.getEserciziAssociabiliAllenamento(this.id);
  }

  getEsercizioAllenamentoData(id:number) {
    this.service.getEsercizioAllenamento(id).subscribe(data => {
      this.eserciziAllenamento = data;
     /* console.log("EserciziAllenamento = ", data, 'ad Allenamento', this.id);*/
    });
  }

  getEserciziAssociabiliAllenamento(id: number) {
    this.service.getEserciziAssociabiliAllenamento(id).subscribe(data => {
      this.eserciziAssociabiliAllenamento = data;
/*      console.log("eserciziAssociabiliAllenamento = ", data);*/
    });
  }


}

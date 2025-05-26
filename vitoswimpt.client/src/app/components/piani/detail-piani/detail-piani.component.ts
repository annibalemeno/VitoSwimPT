import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiserviceService } from '../../../apiservice.service';
import { Allenamenti } from '../../../interfaces/allenamenti';

@Component({
  selector: 'app-detail-piani',
  standalone: false,
  templateUrl: './detail-piani.component.html',
  styleUrl: './detail-piani.component.css'
})
export class DetailPianiComponent implements OnInit{
  id = 0;
  public pianiAllenamento: any;  //
  public allenamentiAssociabili: any;  


  constructor(private router: Router,
    public route: ActivatedRoute, private service: ApiserviceService) {

    this.id = Number(this.route.snapshot.paramMap.get('id')); //get id parameter
    console.log('Id chiamante = ' + this.id);
  }

  ngOnInit(): void {
    this.refreshGrid();
  }

  refreshGrid() {
    this.getPianiAllenamento(this.id);
    this.getAllenamentiAssociabiliPiano(this.id);
  }

  getPianiAllenamento(pianoId: number) {
    this.service.getPianoAllenamento(pianoId).subscribe(data => {
      this.pianiAllenamento = data;
      console.log("PianiAllenamento = ", data, 'per Piano', this.id);
    });
  }

  getAllenamentiAssociabiliPiano(pianoId: number) {
    this.service.getAllenamentiAssociabiliPiano(pianoId).subscribe(data => {
      this.allenamentiAssociabili = data;
    });
  }


  disassocia(allenamento: Allenamenti) {
    console.log('Allenamento da disassociare= ', allenamento, 'al Piano', this.id);
    this.service.disassociaAllenamentoPiano(this.id, allenamento.allenamentoId).subscribe(data => {
      this.refreshGrid();
    });
  }

  associa(allenamento: Allenamenti) {
    this.service.associaPianoAllenamento(this.id, allenamento.allenamentoId).subscribe(data => {
      this.refreshGrid();
    })
  }
}

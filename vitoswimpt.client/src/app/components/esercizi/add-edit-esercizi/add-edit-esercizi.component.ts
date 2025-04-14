import { Component, Input, OnInit } from '@angular/core';
import { ApiserviceService } from '../../../apiservice.service';
import { Esercizi } from '../../../interfaces/esercizi';
import { Stili } from '../../../interfaces/stili';

@Component({
  selector: 'app-add-edit-esercizi',
  standalone: false,
  templateUrl: './add-edit-esercizi.component.html',
  styleUrl: './add-edit-esercizi.component.css'
})
export class AddEditEserciziComponent implements OnInit {
  constructor(private service: ApiserviceService) { }

  @Input() eserc: any;
  EsercizioId = 0;
  Ripetizioni = 0;
  Distanza = 0;
  Recupero = 0;
  Stile = "";
  StiliList: Stili[] = [];

  ngOnInit(): void {
    this.getEserciziList();
  }

  getEserciziList() {
    this.service.getStili().subscribe(data => {

      this.StiliList = data;
      console.log(this.StiliList);

      this.EsercizioId = this.eserc.esercizioId;
      this.Ripetizioni = this.eserc.ripetizioni;
      this.Distanza = this.eserc.distanza;
      this.Recupero = this.eserc.recupero;
      /*    this.Stile = this.eserc.stile;*/
    });
  }

  addEsercizio() {
    // console.log("addEsercizio");
    var esercizio: Esercizi;
    esercizio = {
      esercizioId: this.EsercizioId,
      ripetizioni: this.Ripetizioni,
      distanza: this.Distanza,
      recupero: this.Recupero,
      stile: this.Stile
    };

    this.service.addEsercizio(esercizio).subscribe(data => {
      alert(data.toString());
    });
  };

  updateEsercizio() {
    //console.log("updateEserczio");
    var esercizio: Esercizi;

     esercizio = {
      esercizioId: this.EsercizioId,
      ripetizioni: this.Ripetizioni,
      distanza: this.Distanza,
      recupero: this.Recupero,
      stile: this.Stile
    };

    this.service.updateEsercizio(esercizio).subscribe(data => {
      alert(data.toString());
    });
  };

}

import { Component, Input, OnInit } from '@angular/core';
import { ApiserviceService } from '../../../apiservice.service';
import { Allenamenti } from '../../../interfaces/allenamenti';

@Component({
  selector: 'app-add-edit-allenamenti',
  standalone: false,
  templateUrl: './add-edit-allenamenti.component.html',
  styleUrl: './add-edit-allenamenti.component.css'
})
export class AddEditAllenamentiComponent implements OnInit {
  constructor(private service: ApiserviceService) { }
  @Input() training: any;
  allenamentoId = 0;
  nomeAllenamento = "";
  note = "";

  ngOnInit(): void {
    this.getAllenamentiList(); //initialize
  }

  getAllenamentiList() {
    //console.log("getAllenamentiList");
    this.allenamentoId = this.training.allenamentoId;
    this.nomeAllenamento = this.training.nomeAllenamento;
    this.note = this.training.note;
  }

  addAllenamento() {
    // console.log("addEsercizio");
    var allenamento: Allenamenti;
    allenamento = {
      allenamentoId: this.allenamentoId,
      nomeAllenamento: this.nomeAllenamento,
      note: this.note
    };

    this.service.addAllenamento(allenamento).subscribe(data => {
      alert(data.toString());
    });
  }

  updateAllenamento() {
    var training: Allenamenti;

    training = {
      allenamentoId: this.allenamentoId,
      nomeAllenamento: this.nomeAllenamento,
      note: this.note
    };

    this.service.updateAllenamento(training).subscribe(data => {
      alert(data.toString());
    });
  };
}

import { Component, Input, OnInit } from '@angular/core';
import { ApiserviceService } from '../../../apiservice.service';
import { Piani } from '../../../interfaces/piani';

@Component({
  selector: 'app-add-edit-piani',
  standalone: false,
  templateUrl: './add-edit-piani.component.html',
  styleUrl: './add-edit-piani.component.css'
})
export class AddEditPianiComponent implements OnInit {
  constructor(private service: ApiserviceService) { }


  @Input() piano: any;
  PianoId = 0;
  NomePiano = "";
  Descrizione = "";
  Note = "";

  ngOnInit(): void {
    this.PianoId = this.piano.pianoId;
    this.NomePiano = this.piano.nomePiano;
    this.Descrizione = this.piano.descrizione;
    this.Note = this.piano.note;
  }


  

  addPiano() {
    var pianoToAdd: Piani;

    pianoToAdd = {
      pianoId: this.PianoId,
      nomePiano: this.NomePiano,
      descrizione: this.Descrizione,
      note: this.Note,
      username: sessionStorage.getItem('email')!
    };


    this.service.addPiano(pianoToAdd).subscribe(data => {
      alert(data.toString());
    });
  }

  updatePiano() {
    var pianoToUpd: Piani;
    pianoToUpd = {
      pianoId: this.PianoId,
      nomePiano: this.NomePiano,
      descrizione: this.Descrizione,
      note: this.Note,
      username: sessionStorage.getItem('email')!
    };
    this.service.updatePiano(pianoToUpd).subscribe(data => {
      alert(data.toString());
    },
      error => {
        alert(error.error.title + ' : ' + error.error.detail);
      }
    );
}

}




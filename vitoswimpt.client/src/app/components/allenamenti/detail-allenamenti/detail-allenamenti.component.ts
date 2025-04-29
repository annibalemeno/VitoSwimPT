import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiserviceService } from '../../../apiservice.service';

@Component({
  selector: 'app-detail-allenamenti',
  standalone: false,
  templateUrl: './detail-allenamenti.component.html',
  styleUrl: './detail-allenamenti.component.css'
})
export class DetailAllenamentiComponent implements OnInit {
  id = 0;
  constructor(private router: Router,
    public route: ActivatedRoute, private service: ApiserviceService) {

    this.id = Number(this.route.snapshot.paramMap.get('id')); //get id parameter
    console.log('Id chiamante = ' + this.id);
  }

  ngOnInit(): void {
  }

}

import { Component, OnInit } from '@angular/core';
import { Produto } from 'src/app/modelo/produto';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public produtos: Produto[];
  
  constructor() { }

  ngOnInit(): void {
  }

}

import { Component, ViewChild } from '@angular/core';
import { SeguroService } from '../services/seguro.service';

@Component({
  selector: 'app-seguro',
  templateUrl: './seguro.component.html',
  styleUrls: ['./seguro.component.css']
})
export class SeguroComponent {

  public listaVazia: any = [];
  public seguros: any;
  constructor(private seguroService: SeguroService) { }

  ngOnInit(): void{
    this.getSeguros('');
  }

  public getSeguros(nomeOuDocumento?: string): void {

    this.seguroService.getSeguros(nomeOuDocumento).subscribe(
      response =>{ this.seguros = response },
      error => {console.error('Não foram encontrados registros com o parametro fornecido:', error);
                this.seguros = []
      }
    );
  }
}

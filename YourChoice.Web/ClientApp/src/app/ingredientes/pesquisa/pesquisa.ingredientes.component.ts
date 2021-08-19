import { Component, OnInit } from "@angular/core";
import { Ingrediente } from "../../modelo/ingrediente";
import { IngredienteServico } from "../../servicos/ingrediente/ingrediente.servico";
import { Router } from "@angular/router";

@Component({
  selector: "pesquisa-ingrediente",
  templateUrl: "./pesquisa.ingredientes.component.html",
  styleUrls: ["./pesquisa.ingredientes.component.css"] 
})
export class PesquisaIngredienteComponent implements OnInit{

  public ingredientes: Ingrediente[];

    ngOnInit(): void {
        
  }

  constructor(private ingredienteServico: IngredienteServico, private router: Router) {
    this.ingredienteServico.obterTodosIngredientes()
      .subscribe(
        ingredientes => {
          this.ingredientes = ingredientes 
      },
        e => {
          console.log(e.error);

        });
  }

  public adicionarIngrediente() {
    sessionStorage.setItem('ingredienteSession', "");
    this.router.navigate(['/ingrediente']);
  }

  public deletarIngrediente(ingrediente: Ingrediente) {
    this.ingredienteServico.deletar(ingrediente).subscribe(
      ingredientes => {
        this.ingredientes = ingredientes;

      }, e => {
        console.log(e.errors);
      });
  }

  public editarIngrediente(ingrediente: Ingrediente) {
    sessionStorage.setItem('ingredienteSession', JSON.stringify(ingrediente));
    this.router.navigate(['/ingrediente']);
  }
}

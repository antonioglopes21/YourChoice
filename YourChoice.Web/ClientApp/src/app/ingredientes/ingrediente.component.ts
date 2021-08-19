import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Ingrediente } from "../modelo/ingrediente";
import { IngredienteServico } from "../servicos/ingrediente/ingrediente.servico";
@Component({
  selector: "app-ingrediente",
  templateUrl: "./ingrediente.component.html",
  styleUrls: ["./ingrediente.component.css"]
})
export class IngredienteComponent implements OnInit {
  public ingrediente: Ingrediente;
  public ativar_spinner: boolean;
  public mensagem: string;
  constructor(private ingredienteServico: IngredienteServico, private router: Router) {
  }
  ngOnInit(): void {
    var ingredienteSession = sessionStorage.getItem('ingredienteSession');
    if (ingredienteSession) {
      this.ingrediente = JSON.parse(ingredienteSession);
    }
    else {
      this.ingrediente = new Ingrediente();
    }
  }

  public cadastrar() {
    this.ativarEspera();
    this.ingredienteServico.cadastrar(this.ingrediente).subscribe(ingredienteJson => {
      this.desativarEspera();
      /*this.router.navigate(['/pesquisar-ingrediente']);*/
    }, e => {
      this.mensagem = e.error;
      this.desativarEspera();
    });
  }
  public ativarEspera() {
    this.ativar_spinner = true;
  }
  public desativarEspera() {
    this.ativar_spinner = false;
  }
}

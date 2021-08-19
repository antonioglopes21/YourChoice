import { Component, OnInit } from "@angular/core";
import { Produto } from "../modelo/produto";
import { ProdutoServico } from "../servicos/produto/produto.servico";
import { Router } from "@angular/router";
import { IngredienteServico } from "../servicos/ingrediente/ingrediente.servico";
import { Ingrediente } from "../modelo/ingrediente";
@Component({
  selector: "app-produto",
  templateUrl: "./produto.component.html",
  styleUrls: ["./produto.component.css"]
})
export class ProdutoComponent implements OnInit {
  public produto: Produto;
  public ingredientes: Ingrediente[];
  public ativar_spinner: boolean;
  public nomeArquivoVazio: boolean;
  public mensagem: string;
  public arquivoSelecionado: File;
  constructor(private produtoServico: ProdutoServico, private ingredienteServico: IngredienteServico, private router: Router) {
    ingredienteServico.obterTodosIngredientes().subscribe(ingredientes => { this.ingredientes = ingredientes, console.log(ingredientes) }, e => {
      /*console.log(e.error);*/
    })
  }
  ngOnInit(): void {
    var produtoSession = sessionStorage.getItem('produtoSession');
    if (produtoSession) {
      this.produto = JSON.parse(produtoSession);
      this.nomeArquivoVazio = false;
    }
    else {
      this.produto = new Produto();
    }
  }
  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0);
    /*this.ativar_spinner = true;*/
    this.produtoServico.enviarArquivo(this.arquivoSelecionado)
      .subscribe(nomeArquivo => {
        this.produto.nomeArquivo = nomeArquivo;
        console.log(nomeArquivo);
        this.ativar_spinner = false;
        this.nomeArquivoVazio = true;
      }, e => {
        console.log(e.error);
        this.nomeArquivoVazio = false;
      });
  }
  public cadastrar() {
    this.ativarEspera();
    this.produtoServico.cadastrar(this.produto).subscribe(produtoJson => {
      console.log(produtoJson);
      this.desativarEspera();
      /*this.router.navigate(['/pesquisar-produto']);*/
    }, e => {
      console.log(e.error);
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
  get nomeArquivo() {
    return this.produtoServico.produtos;
  }
}

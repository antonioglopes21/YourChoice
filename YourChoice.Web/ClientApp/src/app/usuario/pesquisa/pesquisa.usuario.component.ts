import { Component, OnInit, ViewChild } from "@angular/core";
import { Usuario } from "../../modelo/usuario";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";
import { Router } from "@angular/router";
@Component({
  selector: "pesquisa-usuario",
  templateUrl: "./pesquisa.usuario.component.html",
  styleUrls: ["./pesquisa.usuario.component.css"] 
})
export class PesquisaUsuarioComponent implements OnInit{

  public usuarios: Usuario[];

    ngOnInit(): void {
        
  }

  constructor(private usuarioServico: UsuarioServico, private router: Router) {
    this.usuarioServico.obterTodosUsuarios()
      .subscribe(
        usuarios => {
          this.usuarios = usuarios
          console.log(usuarios);
      },
        e => {
          console.log(e.error);

        });
  }

  public adicionarUsuario() {
    sessionStorage.setItem('usuarioSession', "");
    this.router.navigate(['/cadastro-usuario']);
  }

  public deletarUsuario(usuario: Usuario) {
    this.usuarioServico.deletar(usuario).subscribe(
      usuarios => {
        this.usuarios = usuarios;

      }, e => {
        console.log(e.errors);
      });
  }

  public editarUsuario(usuario: Usuario) {
    sessionStorage.setItem('usuarioSession', JSON.stringify(usuario));
    this.router.navigate(['/cadastro-usuario']);
  }
}

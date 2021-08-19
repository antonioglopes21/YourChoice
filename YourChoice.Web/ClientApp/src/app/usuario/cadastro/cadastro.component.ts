import { Component, OnInit } from '@angular/core';
import { Usuario } from "../../modelo/usuario";
import { ConsultaCepService } from '../../servicos/cep/consulta.cep.servico';
import { UsuarioServico } from '../../servicos/usuario/usuario.servico';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
  public usuario: Usuario;
  public ativar_spinner: boolean;
  public mensagem: string;
  public usuarioCadastrado: boolean;

  constructor(private usuarioServico: UsuarioServico, private cepService: ConsultaCepService) {

  }

  ngOnInit(): void {
    var usuarioSession = sessionStorage.getItem('usuarioSession');
    if (usuarioSession) {
      this.usuario = JSON.parse(usuarioSession);
    }
    else {
      this.usuario = new Usuario();
    }
  }
  public usuario_administrador(): boolean {
    return this.usuarioServico.usuario_administrador();
  }
  public cadastrar() {
    this.ativar_spinner = true;
    this.usuarioServico.cadastrarUsuario(this.usuario)
      .subscribe(
        sucess => {
          this.usuarioCadastrado = true;
          this.mensagem = "";
          this.ativar_spinner = false;
        },
        err => {
          this.mensagem = err.error;
          this.ativar_spinner = false;
        }
      );
  }

  consultaCEP(cep, form) {
    // Nova variável "cep" somente com dígitos.
    cep = cep.replace(/\D/g, '');
    if (cep != null && cep !== '') {
      this.cepService.consultaCEP(cep)
        .subscribe(dados => {
          this.populaDadosForm(dados, form);
        });
    }
  }
  populaDadosForm(dados, formulario) {
    formulario.form.patchValue({
      estado: dados.uf,
      cidade: dados.localidade,
      bairro: dados.bairro,
      endereco: dados.logradouro
    });
  }
}

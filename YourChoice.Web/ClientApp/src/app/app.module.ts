import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { GuardaRotas } from './autorizacao/guarda.rotas';
import { HomeComponent } from './home/home.component';
import { IngredienteComponent } from './ingredientes/ingrediente.component';
//import { LojaCompraRealizadaComponent } from './loja/efetivar/loja.compra.realizada.component';
//import { LojaEfetivarComponent } from './loja/efetivar/loja.efetivar.component';
//import { LojaPesquisaComponent } from './loja/pesquisa/loja.pesquisa.component';
//import { LojaProdutoComponent } from './loja/produto/loja.produto.component';
import { PesquisaProdutoComponent } from './produto/pesquisa/pesquisa.produto.component';
import { PesquisaIngredienteComponent } from './ingredientes/pesquisa/pesquisa.ingredientes.component';
import {PesquisaUsuarioComponent} from './usuario/pesquisa/pesquisa.usuario.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ProdutoComponent } from './produto/produto.component';
import { IngredienteServico } from './servicos/ingrediente/ingrediente.servico';
import { PedidoServico } from './servicos/pedido/pedido.servico';
import { ProdutoServico } from './servicos/produto/produto.servico';
import { UsuarioServico } from './servicos/usuario/usuario.servico';
import { CadastroComponent } from './usuario/cadastro/cadastro.component';
import { LoginComponent } from './usuario/login/login.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    ProdutoComponent,
    IngredienteComponent,
    CadastroComponent,
    PesquisaProdutoComponent,
    PesquisaIngredienteComponent,
    PesquisaUsuarioComponent,
    //LojaPesquisaComponent,
    //LojaProdutoComponent,
    //LojaEfetivarComponent,
    //LojaCompraRealizadaComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'produto', component: ProdutoComponent, canActivate: [GuardaRotas] },
      { path: 'ingrediente', component: IngredienteComponent, canActivate: [GuardaRotas] },
      { path: 'entrar', component: LoginComponent },
      { path: 'cadastro-usuario', component: CadastroComponent },
      { path: 'pesquisar-produto', component: PesquisaProdutoComponent, canActivate: [GuardaRotas] },
      { path: 'pesquisar-ingrediente', component: PesquisaIngredienteComponent, canActivate: [GuardaRotas] },
      { path: 'pesquisar-usuario', component: PesquisaUsuarioComponent, canActivate: [GuardaRotas] },
      //{ path: 'loja-produto', component: LojaProdutoComponent },
      //{ path: 'loja-efetivar', component: LojaEfetivarComponent},
      //{ path: "compra-realizada-sucesso", component: LojaCompraRealizadaComponent }
    ])
  ],
  providers: [UsuarioServico, ProdutoServico, PedidoServico, IngredienteServico],
  bootstrap: [AppComponent]
})
export class AppModule { }

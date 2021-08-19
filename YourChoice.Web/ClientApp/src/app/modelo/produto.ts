import { Ingrediente } from './ingrediente';
import { ProdutoIngrediente } from './produtoIngrediente';
export class Produto {
  id: number;
  nome: string;
  descricao: string;
  preco: number;
  nomeArquivo: string;
  precoOriginal: number;
  quantidade: number;
  ingredientesProdutos: Ingrediente[];
  produtoIngredientes: ProdutoIngrediente[];

  constructor() {
    /*this.produtoIngredientes = [];*/
    this.ingredientesProdutos = [];
  }

}

import { Ingrediente } from './ingrediente';
import { Produto } from './produto';
export class ProdutoIngrediente {
  produtoId: number;
  ingredienteId: number;
  produto: Produto[];
  ingrediente: Ingrediente[];

  constructor() {
    /*this.produtoIngredientes = [];*/
  }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourChoice.Dominio.Entidades
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao { get; set; }
        private List<string> mensagensValidacao
        {
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); }
        }

        protected void LimparMensagemValidacao()
        {
            mensagensValidacao.Clear();
        }

        protected void AdicionarCritica(string mensagem)
        {
            mensagensValidacao.Add(mensagem);
        }

        public string ObterMensagensValidacao()
        {
            return string.Join(". ", mensagensValidacao);
        }

        public abstract void Validate();
        public bool EhValido
        {
            get { return !mensagensValidacao.Any(); }
        }
    }
}

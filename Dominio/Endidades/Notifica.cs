using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Endidades
{
    public class Notifica
    {
        public Notifica()
        {
            Notificacoes = new List<Notifica>();
        }

        [NotMapped]
        public string? NomePropriedade { get; set; }

        [NotMapped]
        public string? Informacao { get; set; }

        public List<Notifica> Notificacoes;


        public bool ValidapropriedadeString(string valor, string nomePropriedade)
        {

            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifica
                {
                    Informacao = "Dgite um valor",
                    NomePropriedade = nomePropriedade,
                });
                return false;
            }
            return true;

        }

    }
}

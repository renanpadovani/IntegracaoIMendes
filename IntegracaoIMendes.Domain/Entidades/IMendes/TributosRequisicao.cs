using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoIMendes.Dominio.Entidades.IMendes
{
    public class Emit
    {
        public int amb { get; set; }
        public string cnpj { get; set; }
        public int crt { get; set; }
        public string regimeTrib { get; set; }
        public string uf { get; set; }
        public string cnae { get; set; }
        public string substICMS { get; set; }
        public string interdependente { get; set; }
    }

    public class Perfil
    {
        public List<string> uf { get; set; }
        public string cfop { get; set; }
        public List<int> caracTrib { get; set; }
        public int finalidade { get; set; }
        public string simplesN { get; set; }
        public string origem { get; set; }
        public string substICMS { get; set; }
    }

    public class Produto
    {
        public string codigo { get; set; }
        public string codInterno { get; set; }
        public string codImendes { get; set; }
        public string descricao { get; set; }
        public string ncm { get; set; }
    }

    public class TributosRequisicao
    {
        public TributosRequisicao()
        {
            emit = new Emit();
            perfil = new Perfil();
            produtos = new List<Produto>();
        }

        public Emit emit { get; set; }
        public Perfil perfil { get; set; }
        public List<Produto> produtos { get; set; }
    }
}

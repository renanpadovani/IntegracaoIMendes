using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoIMendes.Dominio.Mapeamentos
{
    public class UFsMapeamento
    {
        public string Mapp(List<string> listaUFs)
        {
            string strUFs = "";

            foreach (string uf in listaUFs)
                strUFs += uf.ToString() + ",";

            return strUFs.Substring(0, (strUFs.Length > 0 ? strUFs.ToString().Length - 1 : 0));
        }

        public List<string> Mapp(string stringUFs)
        {
            List<string> listaUFs = new List<string>();

            if (!String.IsNullOrEmpty(stringUFs))
            {
                listaUFs = stringUFs.Split(',').ToList();
            }

            return listaUFs;
        }
    }
}

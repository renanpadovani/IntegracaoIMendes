using IntegracaoIMendes.Dominio.Entidades.IMendes;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Enums;
using IntegracaoIMendes.Dominio.Servicos;
using System.Collections.Generic;

namespace IntegracaoIMendes.Dominio.Manipuladores
{
    public class TributacaoIMendesManipulador
    {
        private IMendesServico _imendesService;
        private EAmbiente _ambiente;
        private string _cnpj;
        private string _uf;
        private ECodRegimeTributario _codRegimeTributario;
        private string _regimeTributario;

        public TributacaoIMendesManipulador(
            string loginIMendes,
            string senhaIMendes,
            EAmbiente ambiente,
            string cnpj,
            string uf,
            ECodRegimeTributario codigoRegimeTributario,
            string regimeTributario)
        {
            _ambiente = ambiente;
            _cnpj = cnpj;
            _uf = uf;
            _codRegimeTributario = codigoRegimeTributario;
            _regimeTributario = regimeTributario;

            _imendesService = new IMendesServico(loginIMendes, senhaIMendes);
        }

        public TributosRetorno PesquisarTributos(EFinalidade finalidade, List<ECaracteristicaTributaria> listaCaracteristicasTributarias, string cfop, List<string> ufs, int origemMercadoria, IEnumerable<Produtos> listaProdutos)
        {
            Entidades.IMendes.TributosRequisicao tributosRequisicao = new Entidades.IMendes.TributosRequisicao();

            //Dados do emitente
            tributosRequisicao.emit.amb = (int)_ambiente;
            tributosRequisicao.emit.cnpj = _cnpj;
            tributosRequisicao.emit.crt = (int)_codRegimeTributario;
            tributosRequisicao.emit.regimeTrib = _regimeTributario.ToString();
            tributosRequisicao.emit.uf = _uf;

            //Dados do destinatário
            List<int> caracteristicasTributarias = new List<int>();

            foreach (int caracteristica in listaCaracteristicasTributarias)
                caracteristicasTributarias.Add(caracteristica);

            tributosRequisicao.perfil.uf = ufs;
            tributosRequisicao.perfil.cfop = cfop;
            tributosRequisicao.perfil.caracTrib = caracteristicasTributarias;
            tributosRequisicao.perfil.origem = origemMercadoria.ToString();
            tributosRequisicao.perfil.finalidade = (int)finalidade;
       
            //Dados dos produtos
            foreach (Produtos prod in listaProdutos)
            {
                Produto produto = new Produto();

                produto.codigo = prod.codigo;
                produto.codInterno = prod.codInterno;
                produto.codImendes = prod.codImendes;
                produto.descricao = prod.descricao ;
                produto.ncm = prod.ncm;

                tributosRequisicao.produtos.Add(produto);
            }

            //Realiza a consulta no IMendes
            return _imendesService.PesquisarTributos(tributosRequisicao);
        }
    }
}

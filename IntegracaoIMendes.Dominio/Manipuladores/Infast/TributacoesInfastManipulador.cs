using IntegracaoIMendes.Dominio.Entidades.IMendes;
using IntegracaoIMendes.Dominio.Entidades.Infast;
using IntegracaoIMendes.Dominio.Repositorios.Interfaces;
using System;
using System.Collections.Generic;

namespace IntegracaoIMendes.Dominio.Manipuladores
{
    public class TributacoesInfastManipulador
    {
        private ITributacoesRepositorio _repositorio;
        private List<Produtos> _listaProdutos;

        public TributacoesInfastManipulador(ITributacoesRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void GravarTributos(Int64 CenarioTributarioID, TributosRetorno tribIMendes, List<Produtos> listaProdutos)
        {
            _listaProdutos = listaProdutos;

            TributacaoCabecalho tributacaoInfast = CriarObjetoTributacao(CenarioTributarioID, tribIMendes);

            tributacaoInfast.semRetorno = CriaObjetoItensSemRetorno(CenarioTributarioID, tribIMendes);

            _repositorio.IncluirTributacao(tributacaoInfast);
        }

        private TributacaoCabecalho CriarObjetoTributacao(Int64 CenarioTributarioID, TributosRetorno tribIMendes)
        {
            TributacaoCabecalho tribCab = new TributacaoCabecalho();

            tribCab.EmpresaID = 1;
            tribCab.FilialID = 1;
            tribCab.CenarioTributarioID = CenarioTributarioID;
            tribCab.Ambiente = tribIMendes.Cabecalho.amb.ToString();
            tribCab.CnpjCliente = tribIMendes.Cabecalho.cnpj;
            tribCab.DataHoraRetorno = tribIMendes.Cabecalho.dthr;
            tribCab.NumeroProdutosEnviados = tribIMendes.Cabecalho.prodEnv;
            tribCab.NumeroProdutosRetornados = tribIMendes.Cabecalho.prodRet;
            tribCab.NumeroProdutosNaoRetornados = tribIMendes.Cabecalho.prodNaoRet;
            tribCab.NumeroTransacaoIMendes = long.Parse(tribIMendes.Cabecalho.transacao);
            tribCab.MensagemServidor = tribIMendes.Cabecalho.mensagem;

            tribCab.grupos = CriarGrupoProduto(tribIMendes);

            return tribCab;
        }

        private List<TributacaoProdutoGrupo> CriarGrupoProduto(TributosRetorno tribIMendes)
        {
            List<TributacaoProdutoGrupo> grupos = new List<TributacaoProdutoGrupo>();

            foreach (Grupos grupo in tribIMendes.Grupos)
            {
                foreach (string ean in grupo.prodEan)
                {
                    TributacaoProdutoGrupo tribProd = new TributacaoProdutoGrupo();

                    Produtos produto = _listaProdutos.Find(l => l.codigo == ean);

                    if (produto != null)
                    {
                        tribProd.EmpresaID = 1;
                        tribProd.FilialID = 1;
                        tribProd.ProdutoDerivadoID = produto.produtoID;
                        tribProd.Codigo = grupo.codigo;
                        tribProd.NCM = grupo.nCM;
                        tribProd.CEST = grupo.cEST;
                        tribProd.Lista = grupo.lista;
                        tribProd.Tipo = grupo.tipo;
                        tribProd.CodigoANP = grupo.codAnp;
                        tribProd.PassivelPMC = grupo.passivelPMC;
                        tribProd.ImpostoImportacao = (decimal)grupo.impostoImportacao;
                        tribProd.PisCofinsCSTEntrada = grupo.pisCofins.cstEnt;
                        tribProd.PisCofinsCSTSaida = grupo.pisCofins.cstSai;
                        tribProd.PisCofinsAliquotaPis = (decimal)grupo.pisCofins.aliqPis;
                        tribProd.PisCofinsAliquotaCofins = (decimal)grupo.pisCofins.aliqCofins;
                        tribProd.NRI = grupo.pisCofins.nri;
                        tribProd.AmparoLegal = grupo.pisCofins.ampLegal;
                        tribProd.IpiCSTEntrada = grupo.iPI.cstEnt;
                        tribProd.IpiCSTSaida = grupo.iPI.cstSai;
                        tribProd.IpiAliquota = (decimal)grupo.iPI.aliqipi;
                        tribProd.IpiCodEnquadramento = grupo.iPI.codenq;
                        tribProd.IpiEx = grupo.iPI.ex;

                        tribProd.regras = CriarGrupoProdutoListaRegras(grupo, tribProd.ProdutoDerivadoID);

                        grupos.Add(tribProd);
                    }
                }
            }

            return grupos;
        }

        private List<TributacaoProdutoGrupoLista> CriarGrupoProdutoListaRegras(Grupos Grupo, Int64 produtoID)
        {
            List<TributacaoProdutoGrupoLista> lista = new List<TributacaoProdutoGrupoLista>();

            foreach (Regra regra in Grupo.Regras)
            {
                foreach (UF uf in regra.UFs)
                {
                    foreach (CaracTrib caracteristica in uf.CFOP.CaracTrib)
                    {
                        TributacaoProdutoGrupoLista grupoLista = new TributacaoProdutoGrupoLista();

                        grupoLista.EmpresaID = 1;
                        grupoLista.FilialID = 1;
                        grupoLista.ProdutoDerivadoID = produtoID;
                        grupoLista.UF = uf.uF;
                        grupoLista.CFOP = caracteristica.cFOP;
                        grupoLista.CodigoCaracteristicaTributaria = caracteristica.codigo;
                        grupoLista.Finalidade = short.Parse(caracteristica.finalidade);
                        grupoLista.CfopInterno = caracteristica.cFOP;
                        grupoLista.CfopInterestadual = caracteristica.cFOP;
                        grupoLista.Cst = caracteristica.cST;
                        grupoLista.Csosn = caracteristica.cSOSN;
                        grupoLista.AliquotaInterna = (decimal)caracteristica.aliqIcmsInterna;
                        grupoLista.AliquotaInterestadual = (decimal)caracteristica.aliqIcmsInterestadual;
                        grupoLista.AliquotaReducao = (decimal)caracteristica.reducaoBcIcms;
                        grupoLista.AliquotaReducaoST = (decimal)caracteristica.reducaoBcIcmsSt;
                        grupoLista.AliquotaST = (decimal)caracteristica.aliqIcmsSt;
                        grupoLista.AliquotaIVA = (decimal)caracteristica.iVA;
                        grupoLista.AliquotaFCP = (decimal)caracteristica.fCP;
                        grupoLista.CodBeneficio = caracteristica.codBenef;
                        grupoLista.AliquotaDiferimento = (decimal)caracteristica.pDifer;
                        grupoLista.Antecipado = caracteristica.antecipado;
                        grupoLista.Desonerado = caracteristica.desonerado;
                        grupoLista.Isento = caracteristica.isento;
                        grupoLista.AmparoLegal = caracteristica.ampLegal;
                        grupoLista.AliquotaIsencao = (decimal)caracteristica.pIsencao;

                        lista.Add(grupoLista);
                    }
                }
            }

            return lista;
        }

        private List<TributacaoProdutoSemRetorno> CriaObjetoItensSemRetorno(Int64 CenarioTributarioID, TributosRetorno tribIMendes)
        {
            List<TributacaoProdutoSemRetorno> itensSemRetorno = new List<TributacaoProdutoSemRetorno>();

            return itensSemRetorno;
        }
    }
}

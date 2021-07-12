using System;
using System.Collections.Generic;

namespace IntegracaoIMendes.Dominio.Entidades.IMendes
{
    public class Cabecalho
    {
        public string Sugestao { get; set; }
        public int amb { get; set; }
        public string cnpj { get; set; }
        public DateTime dthr { get; set; }
        public int prodEnv { get; set; }
        public int prodRet { get; set; }
        public int prodNaoRet { get; set; }
        public string transacao { get; set; }
        public string mensagem { get; set; }
    }

    public class PisCofins
    {
        public string cstEnt { get; set; }
        public string cstSai { get; set; }
        public double aliqPis { get; set; }
        public double aliqCofins { get; set; }
        public string nri { get; set; }
        public string ampLegal { get; set; }
    }

    public class IPI
    {
        public string cstEnt { get; set; }
        public string cstSai { get; set; }
        public double aliqipi { get; set; }
        public string codenq { get; set; }
        public string ex { get; set; }
    }

    public class Protocolo
    {
    }

    public class CaracTrib
    {
        public string codigo { get; set; }
        public string finalidade { get; set; }
        public string codRegra { get; set; }
        public int codExcecao { get; set; }
        public string cFOP { get; set; }
        public string cST { get; set; }
        public string cSOSN { get; set; }
        public double aliqIcmsInterna { get; set; }
        public double aliqIcmsInterestadual { get; set; }
        public double reducaoBcIcms { get; set; }
        public double reducaoBcIcmsSt { get; set; }
        public double redBcICMsInterestadual { get; set; }
        public double aliqIcmsSt { get; set; }
        public double iVA { get; set; }
        public double iVAAjust { get; set; }
        public double fCP { get; set; }
        public string codBenef { get; set; }
        public double pDifer { get; set; }
        public double pIsencao { get; set; }
        public string antecipado { get; set; }
        public string desonerado { get; set; }
        public string isento { get; set; }
        public string ampLegal { get; set; }
        public Protocolo Protocolo { get; set; }
    }

    public class CFOP
    {
        public string cFOP { get; set; }
        public List<CaracTrib> CaracTrib { get; set; }
    }

    public class UF
    {
        public string uF { get; set; }
        public CFOP CFOP { get; set; }
        public string mensagem { get; set; }
    }

    public class Regra
    {
        public List<UF> UFs { get; set; }
    }

    public class Grupos
    {
        public string codigo { get; set; }
        public string nCM { get; set; }
        public string cEST { get; set; }
        public string lista { get; set; }
        public string tipo { get; set; }
        public string codAnp { get; set; }
        public string passivelPMC { get; set; }
        public double impostoImportacao { get; set; }
        public PisCofins pisCofins { get; set; }
        public IPI iPI { get; set; }
        public List<Regra> Regras { get; set; }
        public List<string> prodEan { get; set; }
        public string Mensagem { get; set; }
    }
    public class NaoEncontrado
    {
        public string codInterno { get; set; }
        public string codProduto { get; set; }
    }

    public class TributosRetorno
    {
        public Cabecalho Cabecalho { get; set; }
        public List<Grupos> Grupos { get; set; }
        public List<NaoEncontrado> SemRetorno { get; set; }
        public bool ErroRetorno { get; set; }
        public string MensagemErro { get; set; }
    }

}

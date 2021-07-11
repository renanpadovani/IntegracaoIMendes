using IntegracaoIMendes.Domain.Entities.Infast;
using IntegracaoIMendes.Domain.Enums;
using IntegracaoIMendes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegracaoIMendes.Domain.Mappings
{
    public class ProcessamentoCenariosMapping
    {
        public ProcessamentoCenarios Mapp(ProcessamentoCenariosModelo processamentoCenariosModelo)
        {
            ProcessamentoCenarios processamentoCenario = null;

            if (processamentoCenariosModelo != null)
            {
                processamentoCenario = new ProcessamentoCenarios();

                processamentoCenario.ID = processamentoCenariosModelo.ID;
                processamentoCenario.EmpresaID = processamentoCenariosModelo.EmpresaID;
                processamentoCenario.FilialID = processamentoCenariosModelo.FilialID;
                processamentoCenario.Data = processamentoCenariosModelo.Data;
                processamentoCenario.CenarioID = processamentoCenariosModelo.CenarioID;
                processamentoCenario.Finalidades = RetornarListaFinalidades(processamentoCenariosModelo.Finalidades);
                processamentoCenario.CaracteristicasTributarias = RetornarListaCaracteristicas(processamentoCenariosModelo.CaracteristicasTributarias);
                processamentoCenario.UFs = RetornarListaUFs(processamentoCenariosModelo.UFs);
                processamentoCenario.QtdProdutos = processamentoCenariosModelo.QtdProdutos;
                processamentoCenario.QtdOrigensProdutos = processamentoCenariosModelo.QtdOrigensProdutos;
                processamentoCenario.QtdRequisicoesRealizadas = processamentoCenariosModelo.QtdRequisicoesRealizadas;
                processamentoCenario.Mensagem = processamentoCenariosModelo.Mensagem;
            }

            return processamentoCenario;
        }

        public ProcessamentoCenariosModelo Mapp(ProcessamentoCenarios processamentoCenario)
        {
            ProcessamentoCenariosModelo processamentoCenariosModelo = null;

            if (processamentoCenario != null)
            {
                processamentoCenariosModelo = new ProcessamentoCenariosModelo();

                processamentoCenariosModelo.ID = processamentoCenario.ID;
                processamentoCenariosModelo.EmpresaID = processamentoCenario.EmpresaID;
                processamentoCenariosModelo.FilialID = processamentoCenario.FilialID;
                processamentoCenariosModelo.Data = processamentoCenario.Data;
                processamentoCenariosModelo.CenarioID = processamentoCenario.CenarioID;
                processamentoCenariosModelo.Finalidades = RetornarStringFinalidades(processamentoCenario.Finalidades);
                processamentoCenariosModelo.CaracteristicasTributarias = RetornarStringCaracteristicasTributarias(processamentoCenario.CaracteristicasTributarias);
                processamentoCenariosModelo.UFs = RetornarStringUFs(processamentoCenario.UFs);
                processamentoCenariosModelo.QtdProdutos = processamentoCenario.QtdProdutos;
                processamentoCenariosModelo.QtdOrigensProdutos = processamentoCenario.QtdOrigensProdutos;
                processamentoCenariosModelo.QtdRequisicoesRealizadas = processamentoCenario.QtdRequisicoesRealizadas;
                processamentoCenariosModelo.Mensagem = processamentoCenario.Mensagem;
            }

            return processamentoCenariosModelo;
        }

        private string RetornarStringCaracteristicasTributarias(List<ECaracteristicaTributaria> listaCaracteristiscas)
        {
            string strCaracateristicas = "";

            foreach (ECaracteristicaTributaria caracteristica in listaCaracteristiscas)
                strCaracateristicas += (int)caracteristica + ",";

            return strCaracateristicas.Substring(0, (strCaracateristicas.Length > 0 ? strCaracateristicas.ToString().Length - 1 : 0));
        }

        private string RetornarStringUFs(List<string> listaUFs)
        {
            string strUFs = "";

            foreach (string uf in listaUFs)
                strUFs += uf.ToString() + ",";

            return strUFs.Substring(0, (strUFs.Length > 0 ? strUFs.ToString().Length - 1 : 0));
        }

        private string RetornarStringFinalidades(List<EFinalidade> listaFinalidades)
        {
            string strFinalidades = "";

            foreach (EFinalidade finalidade in listaFinalidades)
                strFinalidades += (int)finalidade + ",";

            return strFinalidades.Substring(0, (strFinalidades.Length > 0 ? strFinalidades.ToString().Length - 1 : 0));
        }

        private List<EFinalidade> RetornarListaFinalidades(string stringFinalidades)
        {
            List<EFinalidade> finalidades = new List<EFinalidade>();

            if (!String.IsNullOrEmpty(stringFinalidades))
            {
                List<string> strFinalidades = stringFinalidades.Split(',').ToList();

                if (stringFinalidades.Length > 0)
                {
                    foreach (string caract in strFinalidades)
                        finalidades.Add((EFinalidade)int.Parse(caract));
                }
            }

            return finalidades;
        }

        private List<string> RetornarListaUFs(string stringUFs)
        {
            List<string> listaUFs = new List<string>();

            if (!String.IsNullOrEmpty(stringUFs))
            {
                listaUFs = stringUFs.Split(',').ToList();
            }

            return listaUFs;
        }

        private List<ECaracteristicaTributaria> RetornarListaCaracteristicas(string stringCaracteristicas)
        {
            List<ECaracteristicaTributaria> listaCaracteristicas = new List<ECaracteristicaTributaria>();

            if (!String.IsNullOrEmpty(stringCaracteristicas))
            {
                List<string> strCaracteristicas = stringCaracteristicas.Split(',').ToList();

                foreach (string caract in strCaracteristicas)
                    listaCaracteristicas.Add((ECaracteristicaTributaria)int.Parse(caract));
            }

            return listaCaracteristicas;
        }
    }
}

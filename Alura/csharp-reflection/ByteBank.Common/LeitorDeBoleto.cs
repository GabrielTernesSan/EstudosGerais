﻿using System.Reflection;

namespace ByteBank.Common
{
    public class LeitorDeBoleto
    {
        public List<Boleto> LerBoletos(string caminhoArquivo)
        {
            // montar lista de boletos
            var boletos = new List<Boleto>();

            // ler arquivo de boletos
            using (var reader = new StreamReader(caminhoArquivo))
            {
                // ler cabeçalho do arquivo CSV
                string linha = reader.ReadLine();
                string[] cabecalho = linha.Split(',');

                // para cada linha do arquivo CSV
                while (!reader.EndOfStream)
                {
                    // ler dados
                    linha = reader.ReadLine();
                    string[] dados = linha.Split(',');

                    // carregar objeto Boleto
                    Boleto boleto = MapearTextoParaObjeto<Boleto>(cabecalho, dados);

                    // adicionar boleto à lista
                    boletos.Add(boleto);
                }
            }

            // retornar lista de boletos
            return boletos;
        }

        private T MapearTextoParaObjeto<T>(string[] nomesPropriedades, string[] valoresPropriedades)
        {
            T instancia = Activator.CreateInstance<T>();

            // Percorre os nomes das propriedades
            for (int i = 0; i < nomesPropriedades.Length; i++)
            {
                // Obtém a propriedade atual através do nome
                string nomePropriedade = nomesPropriedades[i];
                PropertyInfo propertyInfo = instancia.GetType().GetProperty(nomePropriedade);

                // Verificar se a propriedade foi encontrada
                if (propertyInfo != null)
                {
                    // Obtém o tipo da propriedade
                    Type propertyType = propertyInfo.PropertyType;

                    // Obtém o valor da propriedade
                    string valor = valoresPropriedades[i];

                    // Converte o valor da propriedade para o tipo correto
                    Object valorConvertido = Convert.ChangeType(valor, propertyType);

                    // Guarda o valor convertidop na propriedade
                    propertyInfo.SetValue(instancia, valorConvertido);
                }
            }

            return instancia;
        }
    }
}

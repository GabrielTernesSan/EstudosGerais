﻿namespace UsuarioLib
{
    public readonly record struct FormularioDtoRecordStruct
    (string Nome, string Cpf, string Cargo, int Idade);

    public record FormularioDtoRecord
        (string Nome, string Cpf, string Cargo, int Idade);

    public struct FormularioDtoStruct
    {
        public string Nome;
        public string Cpf;
        public string Cargo;
        public int Idade;

        public FormularioDtoStruct(string nome, string cpf, string cargo, int idade)
        {
            Nome = nome;
            Cpf = cpf;
            Cargo = cargo;
            Idade = idade;

        }
    }

    public class FormularioDtoClass
    {
        public string Nome;
        public string Cpf;
        public string Cargo;
        public int Idade;

        public FormularioDtoClass(string nome, string cpf, string cargo, int idade)
        {
            Nome = nome;
            Cpf = cpf;
            Cargo = cargo;
            Idade = idade;

        }
    }
}

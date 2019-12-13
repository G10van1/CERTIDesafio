using System;
using System.Collections.Generic;

namespace CERTIDesafio
{
    public class Numero
    {
        public string Extenso { get; set;}

        // Construtor
        public Numero(int NumeroDecimal) => FormatarExtenso(NumeroDecimal);

        private void FormatarExtenso(int Decimal)
        {
            Extenso = "";
            // Vetores de números básicos por extenso
            var NumerosBasicos = new List<string>() {"zero", "um", "dois", "três", "quatro", "cinco",
                "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze",
                "dezesseis", "dezessete", "dezoito", "dezenove"};

            var Dezenas = new List<string>() {"zero", "dez", "vinte", "trinta", "quarenta", "cinquenta",
                "sessenta", "setenta", "oitenta", "noventa"};

            var cem = (Decimal % 100) == 0 ? "cem" : "cento";
            var Centenas = new List<string>() {"zero", cem, "duzentos", "trezentos", "quatrocentos", "quinhentos",
                "seiscentos", "setecentos", "oitocentos", "novecentos"};

            //**************************
            // Formatação por extenso
            //**************************
            
            // Caso seja zero
            if (Decimal == 0)
            {
                Extenso = "zero";
                return;
            }

            // Caso esteja fora de intervalo válido
            if (Decimal > 99999 || Decimal < -99999) {
                Extenso = "Erro: Número fora do limite permitido [-99999,99999]";
                return;
            }

            // Tratamento do sinal negativo
            // Número deve ser positivo para cálculos na formatação
            if (Decimal < 0)
            {
                Extenso = "menos ";
                Decimal *= -1;
            }

            int milhar = (Decimal / 1000);
            int centena = (Decimal % 1000)/100;
            int dezena = (Decimal % 100) / 10;
            int unidade = (Decimal % 10);
            unidade += dezena == 1 ? 10 : 0;// números de 10 a 19

            // Formatar milhar
            if (milhar >= 20)// Acima de 19999
            {
                Extenso += Dezenas[milhar / 10];

                if (milhar % 10 != 0)
                    Extenso += " e " + NumerosBasicos[milhar % 10];

                Extenso += " mil";
            }
            else
            {
                if (milhar % 20 > 1)// Neste caso testa se não é um número abaixo de 2000
                    Extenso += NumerosBasicos[milhar] + " ";

                if (milhar % 20 != 0)// Se não está abaixo de 1000
                    Extenso += "mil";
            }

            // Formatar centena
            if (centena > 0)// Se não está abaixo de 100
            {
                if (Extenso != "" && Extenso != "menos ")
                    Extenso += " e ";
                Extenso += Centenas[centena];
            }

            // Formatar dezena
            if (dezena > 1)// Se não está abaixo de 20
            {
                if (Extenso != "" && Extenso != "menos ")
                    Extenso += " e ";
                Extenso += Dezenas[dezena];
            }

            // Formatar unidade
            if (unidade > 0)// Se não é zero
            {
                if(Extenso != "" && Extenso != "menos ")
                    Extenso += " e ";
                Extenso += NumerosBasicos[unidade];
            }
            return;
        }
    }
}
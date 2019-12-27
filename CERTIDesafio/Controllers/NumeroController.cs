using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CERTIDesafio.Controllers
{
    [ApiController]
    public class NumeroController : ControllerBase
    {
        private readonly ILogger<NumeroController> _logger;

        public NumeroController(ILogger<NumeroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        // Rota b�sica para receber par�metro do n�mero na URL
        [Route("{number:int}")] 
        // Add "Numero/" na URL para manter compatibilidade de vers�es anteriores
        [Route("Numero/{number:int}")]
        //**********************************************************************************
        // Comando HTTP GET
        // Recebe n�mero entre -99999 e 99999 e formata para um string por extenso
        // Par�metros:  int number
        //              N�mero decimal inteiro entre -99999 e 99999
        // Retorna: Json contendo o valor por extenso do n�mero
        //**********************************************************************************
        public Numero Get(int number)
        {
            return (new Numero(number));
        }

        [Route("-Autoteste")]
        //**********************************************************************************
        // Comando HTTP GET
        // Teste unit�rio para validar todos os n�meros do intervalo -99999 a 99999
        // Par�metros:  
        // Retorna: string
        //          Um string contendo o valor num�rico e por extenso de todos os n�meros
        //          do intervalo -99999 a 99999 em ordem crescente
        //**********************************************************************************
        public string GetAllNumbers()
        {
            string str = "";
            for (int i = -99999; i <= 99999; i++)
            {
                Numero num = new Numero(i);
                str += i.ToString() + ": " + num.Extenso + "\n";
            }
            return (str);
        }
    }
}


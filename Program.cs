using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Refit;

namespace ApiTest
{
    public class MainClass
    {

        static async Task Main(string[] args)
        {
            static string Consulta()
            {
                Console.WriteLine("Informe seu Cep: ");

                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando Informações do Cep: " + cepInformado);

                return cepInformado;
            }

            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                var cepInformado = Consulta();
                while (cepInformado != null)
                {
                    var adress = await cepClient.GetAdressAsync(cepInformado);

                    Console.WriteLine($"\nCep: {adress.Cep}, \nComplemento: {adress.Complemento}, \nLogradouro: {adress.Logradouro}, \nBairro: {adress.Bairro}, \nCidade: {adress.Localidade}, \nUF: {adress.Uf}, \nUnidade: {adress.Unidade}, \n");
                    Console.ReadKey();

                    cepInformado = Consulta();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao buscar CEP: " + e.Message);
            }
        }
    }
}

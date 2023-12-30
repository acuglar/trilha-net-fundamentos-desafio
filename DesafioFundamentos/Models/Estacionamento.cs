using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            string placaValida = VerificarPlaca(placa);

            if (placaValida != null)
            {
                veiculos.Add(placaValida);
                Console.WriteLine("Veículo estacionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa inválida. O formato deve estar LLLNNNN ou LLL-NNNN");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = "";

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = 0;
                decimal valorTotal = 0; 

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private string VerificarPlaca(string placa)
        {
            placa = placa.Replace(" ", "").ToUpper();

            // Verifica se a placa esta no formato LLLNNNN ou LLL-NNNN
            bool formatoValido = Regex.IsMatch(placa, @"^[A-Z]{3}\d{4}$|^[A-Z]{3}-\d{4}$");

            if (formatoValido)
            {
                // Normaliza para o formato "LLL-NNNN"
                placa = Regex.Replace(placa, @"^([A-Z]{3})(\d{4})$", "$1-$2");
                return placa;
            }

            return null;
        }
    }
}

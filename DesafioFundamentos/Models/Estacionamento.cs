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
            string placa = Console.ReadLine();
            string placaValida = VerificarPlaca(placa);

            if (placaValida != null)
            {
                // Verifica se o veículo existe
                if (veiculos.Any(x => x == placaValida))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    if (int.TryParse(Console.ReadLine(), out int horas))
                    {
                        decimal valorTotal = precoInicial + precoPorHora * horas;

                        veiculos.Remove(placaValida);
                        Console.WriteLine($"O veículo {placaValida} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Certifique-se de inserir um número inteiro.");
                    }
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            else
            {
                Console.WriteLine("Placa inválida. O formato deve estar LLLNNNN ou LLL-NNNN");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                string pluralIndicator = veiculos.Count == 1 ? "" : "s";
                Console.WriteLine($"Há {veiculos.Count} veículo{pluralIndicator} estacionado{pluralIndicator}.");

                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
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

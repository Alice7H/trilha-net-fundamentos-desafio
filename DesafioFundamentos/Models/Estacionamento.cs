using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        private string PadronizarPlacaVeiculo(string placa)
        {
            // Padronizar a placa antes de salvar (com letra maiúscula e sem hífen)
            return placa = placa.Replace("-", "").Trim().ToUpper();
        }

        private bool ValidarPlacaVeiculo(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }
            if (placa.Length > 8) { return false; }
            if (this.veiculos.Contains(placa)) { return false; }

            placa = this.PadronizarPlacaVeiculo(placa);
            // Verifica o caractere na posição 4: Se for Letra (padrão mercosul) ou se for número(padrão antigo)
            if (char.IsLetter(placa, 4))
            {
                return Regex.IsMatch(placa, @"^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$");
            }
            else
            {
                return Regex.IsMatch(placa, @"^[A-Z]{3}[0-9]{4}$");
            }
        }

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            if (!this.ValidarPlacaVeiculo(placa))
            {
                Console.WriteLine("Placa inválida");
            }
            else
            {
                placa = this.PadronizarPlacaVeiculo(placa);
                this.veiculos.Add(placa);
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();
            placa = this.PadronizarPlacaVeiculo(placa);

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal
                decimal valorTotal = 0;

                int.TryParse(Console.ReadLine().ToUpper(), out int horas);
                valorTotal = this.precoInicial + this.precoPorHora * horas;
                // TODO: Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);
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
    }
}

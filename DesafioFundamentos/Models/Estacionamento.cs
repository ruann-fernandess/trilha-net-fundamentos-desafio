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

            // Valida se a placa não é nula ou vazia antes de adicionar
            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo com a placa {placa} estacionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa inválida. O veículo não foi estacionado.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                decimal valorTotal = 0;

                // Loop para garantir que o usuário digite um número válido para as horas
                while (!int.TryParse(Console.ReadLine(), out horas))
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro para as horas:");
                }

                valorTotal = precoInicial + precoPorHora * horas;

                // Encontra o item exato na lista para remover, ignorando maiúsculas/minúsculas
                string veiculoParaRemover = veiculos.First(x => x.ToUpper() == placa.ToUpper());
                veiculos.Remove(veiculoParaRemover);

                // Formata o valor para exibir como moeda
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
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
                // Laço de repetição para exibir cada veículo na lista
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

using System;
using System.Collections.Generic;

public class Estacionamento
{
    // Variáveis
    private decimal precoInicial;
    private decimal precoPorHora;
    private List<string> veiculos = new List<string>();

    // Construtor
    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
    }

    // Método para adicionar veículo
    public void AdicionarVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para estacionar:");
        string placa = Console.ReadLine();
        veiculos.Add(placa);
        Console.WriteLine($"Veículo com placa {placa} foi adicionado.");
    }

    // Método para remover veículo e calcular valor a pagar
    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para remover:");
        string placa = Console.ReadLine();

        // Verifica se o veículo existe
        if (veiculos.Contains(placa))
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            int horas = int.Parse(Console.ReadLine());

            // Calcula o valor total a ser pago
            decimal valorTotal = precoInicial + (precoPorHora * horas);
            veiculos.Remove(placa);

            Console.WriteLine($"O veículo {placa} foi removido e o valor total a pagar é: R${valorTotal:F2}");
        }
        else
        {
            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Verifique se a placa está correta.");
        }
    }

    // Método para listar veículos
    public void ListarVeiculos()
    {
        if (veiculos.Count > 0)
        {
            Console.WriteLine("Os veículos estacionados são:");
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

public class Program
{
    public static void Main()
    {
        // Definindo os valores iniciais do estacionamento
        Console.WriteLine("Digite o preço inicial:");
        decimal precoInicial = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Digite o preço por hora:");
        decimal precoPorHora = decimal.Parse(Console.ReadLine());

        // Instanciando a classe Estacionamento
        Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

        // Menu interativo
        bool exibirMenu = true;
        while (exibirMenu)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    estacionamento.AdicionarVeiculo();
                    break;
                case "2":
                    estacionamento.RemoverVeiculo();
                    break;
                case "3":
                    estacionamento.ListarVeiculos();
                    break;
                case "4":
                    exibirMenu = false;
                    Console.WriteLine("Encerrando o sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}

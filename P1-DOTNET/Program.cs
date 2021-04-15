using P1_DOTNET.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace P1_DOTNET
{
    class Program
    {
        private static List<Stock> wallet = new List<Stock>(); 
        static void Main(string[] args)
        {
            RunMenu();
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo à JB Investimentos!");
            Console.WriteLine("");
            Console.WriteLine("Menu:");
            Console.WriteLine("");
            Console.WriteLine("1 - Comprar uma ação.");
            Console.WriteLine("2 - Pesquisar por uma ação.");
            Console.WriteLine("3 - Visualizar sua carteira de ações.");
            Console.WriteLine("0 - Sair");
        }

        private static void RunMenu()
        {
            Boolean running = true;
            do
            {
                ShowMenu();
                try
                {
                    int number = Int32.Parse(Console.ReadLine());
                    if (number == 0) {
                        Console.Clear();
                        GetCreatorInfo();
                        Console.WriteLine("Finalizado.");
                        
                        running = false;
                    }
                    else
                    {
                    DoOption(number);
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(2000);

                }
            } while (running);

        }

        private static void DoOption(int option)
        {
            Console.Clear();
            switch (option)
            {
                case 1:
                  {
                        RegisterStock();
                    }
                    break;
                case 2:
                    {
                        GetInfoStockByCode();
                    }
                    break;
                case 3:
                    {
                        GetWalletInfo();
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Opção não existente!");
                        Thread.Sleep(2000);
                    }
                    break;
            }
        }
        private static void RegisterStock()
        {
            Console.Write("Digite o código da ação: ");
            string code = Console.ReadLine().ToUpper();
            code = code.Replace(" ", "");
            if (code == "")
            {
                Console.WriteLine("Código de ação inválida.");
                Thread.Sleep(1000);
                Console.Clear();
                RegisterStock();
            }
            else 
            { 
                Console.Write("Digite a quantidade de ações: ");
                try
                {
                    int quantity = int.Parse(Console.ReadLine());
                    AddStockInWallet(code, quantity);
                    Console.WriteLine("Ação cadastrada com sucesso!");
                    Thread.Sleep(1000);
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Quantidade inválida.");
                    Thread.Sleep(2000);
                    RegisterStock();
                }
            }

        }

        private static void AddStockInWallet(string code, int quantity) {

            Stock stock = FindByCode(code);
            if (stock == null)
            {
                stock = new Stock(code, quantity);
                wallet.Add(stock);
            }
            else 
            {
                stock.IncrementQuantity(quantity);
            }

        }

        private static Stock FindByCode(string code) 
        {
                return wallet.Find(a => a.Code.Equals(code));
        }

        private static void GetInfoStockByCode() 
        {
            Console.Write("Digite o código da ação: ");
            string code = Console.ReadLine().ToUpper();
            if (code == "")
            {
                Console.WriteLine("Código de ação inválida.");
                Thread.Sleep(2000);
            }
            else
            {
                Stock stock = FindByCode(code);
                if (stock != null) {
                    Console.Clear();
                    Console.WriteLine($"Código da Ação: {stock.Code}");
                    Console.WriteLine($"Quantidade: {stock.Quantity}");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ação não encontrada.");
                    Thread.Sleep(2000);
                }

            }
        }

        private static void GetWalletInfo()
        {
            if (wallet.Count == 0)
            {
                Console.WriteLine("Carteira Vazia.");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Carteira:");
                Console.WriteLine("");
                foreach (var stock in wallet)
                {

                    Console.WriteLine($"Código da Ação: {stock.Code}");
                    Console.WriteLine($"Quantidade: {stock.Quantity}");
                    Console.WriteLine("___________________________");  
                }
                Thread.Sleep(5000);
            }
        }

        private static void GetCreatorInfo() {
            Console.WriteLine("Created By : João Bosco.");
            Console.WriteLine("GITHUB : https://github.com/joaobosconff");
        }

    }
}

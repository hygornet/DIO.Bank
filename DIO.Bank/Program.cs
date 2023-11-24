using DIO.Bank.Classes;
using DIO.Bank.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
    internal class Program
    {

        static List<Conta> listaContas = new List<Conta>();

        
        static void Main(string[] args)
        {
            
            var opcao = ObterOpcaoUsuario();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        TransferirNovaConta();
                        break;

                    case "4":
                        SacarValor();
                        break;

                    case "5":
                        DepositarValor();
                        break;

                    case "C":
                        Clear();
                        break;

                    case "X":
                        Console.Write("Encerrando o programa...");
                        Console.ReadKey();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcao = ObterOpcaoUsuario();
            }

            Console.ReadKey();
        }

        private static void DepositarValor()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do deposito: ");
            double valorDep = double.Parse(Console.ReadLine());

            listaContas[numeroConta].Depositar(valorDep);
        }

        private static void SacarValor()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do saque: ");
            double valor = double.Parse(Console.ReadLine());

            listaContas[numeroConta].Sacar(valor);
        }

        private static void TransferirNovaConta()
        {
            Console.WriteLine("Digite o numero da conta de origem: ");
            int numeroContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de destino: ");
            int numeroContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da transferencia: ");
            double valorTrans = double.Parse(Console.ReadLine());

            Console.WriteLine("O cliente da conta de origem é: " + listaContas[numeroContaOrigem]);

            listaContas[numeroContaOrigem].Transferir(valorTrans, listaContas[numeroContaDestino]);
        }

        private static void ListarContas()
        {
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.\n");

                return;

                
            }

            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("Listar contas\n");
                Console.Write($"#{i} - " + conta+"\n");
                
            }

            
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Pessoa Fisica ou 2 para Pessoa Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                tipoConta: (TipoConta)entradaTipoConta, 
                saldo: entradaSaldo, 
                credito: entradaCredito, 
                nome: entradaNome);

            listaContas.Add(novaConta);

        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine("DIO BANK!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Cadastrar nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;


        }
    }
}

using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace FactoryMethodPattern;

class Program
{

    public interface IShoes
    {
        
        public string[]? Materials { get; set; }

    }

    public class Sneakers : IShoes
    {
        
        public string[]? Materials { get; set; }
        public Sneakers(string[] newMaterials)
        {
            
            Materials = newMaterials;

        }

    }
    public class WomensShoes : IShoes
    {
        
        public string[]? Materials { get; set; }
        public WomensShoes(string[] newMaterials)
        {
            
            Materials = newMaterials;

        }

    }
    public class MensShoes : IShoes
    {
        
        public string[]? Materials { get; set; }
        public MensShoes(string[] newMaterials)
        {
            
            Materials = newMaterials;

        }
        
    }

    public interface IShoeSupplier
    {
        
        IShoes CreateShoes();

    }

    public class NaturalShoesSupplier_Sneakers : IShoeSupplier
    {
        
        private string[] shoeMaterials = { "leather"};
        public IShoes CreateShoes()
        {
            
            Console.WriteLine("Got new sneakers made from leather!");
            Console.ReadLine();
            return new Sneakers(shoeMaterials);

        }

    }
    public class NaturalShoesSupplier_WomensShoes : IShoeSupplier
    {
        
        private string[] shoeMaterials = { "leather"};
        public IShoes CreateShoes()
        {
            
            Console.WriteLine("Got new womens shoes made from leather!");
            Console.ReadLine();
            return new WomensShoes(shoeMaterials);

        }

    }
    public class NaturalShoesSupplier_MensShoes : IShoeSupplier
    {
        
        private string[] shoeMaterials = { "leather"};
        public IShoes CreateShoes()
        {
            
            Console.WriteLine("Got new mens shoes made from leather!");
            Console.ReadLine();
            return new MensShoes(shoeMaterials);

        }

    }

    //

    public class Client
    {
        
        //

        public IShoes BuyShoes()
        {
            
            InputHelper input = new InputHelper();
            
            NaturalShoesSupplier_Sneakers sneakers = new NaturalShoesSupplier_Sneakers();
            NaturalShoesSupplier_WomensShoes womensShoes = new NaturalShoesSupplier_WomensShoes();
            NaturalShoesSupplier_MensShoes mensShoes = new NaturalShoesSupplier_MensShoes();

            while (true)
            {

                Console.WriteLine("Which shoe type do you want?");
                Console.WriteLine("1. Sneakers;\n2. Womens shoes;\n3. Mens shoes.");

                int whichShoe = input.GetInt();

                switch (whichShoe)
                {

                    case 1:
                        {
                            
                            return sneakers.CreateShoes();

                        }
                    case 2:
                        {
                            
                            return womensShoes.CreateShoes();

                        }
                    case 3:
                        {
                            
                            return mensShoes.CreateShoes();

                        }
                    default:
                        {
                            
                            Console.WriteLine("Incorrect value: no such shoe type; try again");
                            break;

                        }

                }

            }

        }

    }

    public static void Menu(Client client)
    {

        while (true)
        {
            
            InputHelper input = new InputHelper();

            Console.Clear();
            string[] options = { "Buy shoes", "Exit" };

            Console.WriteLine("====MENU====");
            Console.WriteLine("1. Buy shoes;");
            Console.WriteLine("2. Exit.");
            Console.WriteLine("============");

            int userChoice = input.GetInt();
            Console.Clear();

            switch (userChoice)
            {

                case 1:
                    {
                        
                        client.BuyShoes();
                        break;

                    }
                case 2:
                    {
                        
                        Environment.Exit(0);
                        break;

                    }
                default:
                    {
                        
                        Console.WriteLine("Incorrect value: no such option");
                        Console.ReadLine();
                        break;

                    }

            }

        }

    }

    static void Main(string[] args)
    {

        Client client = new Client();
        Menu(client);

    }
}

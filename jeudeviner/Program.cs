using System;

namespace jeudeviner
{
    class Program
    {
        static private string Message(int aTrouver, int choisi)
        {
            if (aTrouver == choisi)
            {
                return "Bravo mon chou xxx";
            }
            else if (aTrouver < choisi)
            {
                return "Le nombre est trop grand...";
            }
            else if (aTrouver > choisi)
            {
                return "Le nombre est trop petit...";
            }
            else
            {
                return "Erreur...";
            }
        }
        static void Main(string[] args)
        {

            Random random = new Random();

            int nombreCoupsUser = 0;
            int nombreCoupsOrdi = 0;
            int nombreChoisi;

            int max;

            Console.Write("Entrez la valeur maximale du nombre qui sera généré : ");

            max = int.Parse(Console.ReadLine());
            
            Console.WriteLine("L'ordinateur a choisi son nombre, appuyez sur une touche pour commencer.");
            int nombreATrouver = random.Next(0, max);
            Console.WriteLine(nombreATrouver); //pour debug
            Console.ReadKey();

            Console.Clear();
            //Loop pour faire devinner l'humain
            do
            {
                Console.Write("Entrez un nombre : ");
                nombreChoisi = int.Parse(Console.ReadLine());
                Console.WriteLine(Message(nombreATrouver, nombreChoisi));
                nombreCoupsUser++;
            } while (nombreChoisi != nombreATrouver);

            Console.WriteLine("Vous avez trouvé le chiffre en question en {0} coups", (object)nombreCoupsUser);
            Console.ReadKey();

            Console.Write("Entrez le nombre à faire deviner à l'ordinateur : ");
    

        }
    }
}

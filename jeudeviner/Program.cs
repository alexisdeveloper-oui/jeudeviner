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

        static private int demanderUser(int essai)
        {
            Console.WriteLine("Est-ce que votre nombre est {0}?", essai);

            Console.Write("1-Trop grand    2-Trop petit    3-Vous avez trouvé!!!!    :");
            return int.Parse(Console.ReadLine());
        }

        static private int FaireDeviner(int max)
        {
            int essai;
            int reponse;
            int nombrecoups;
            int min = 1;

            essai = max / 2;
            reponse = demanderUser(essai);
            nombrecoups =+ 1;

            while (reponse != 3)
            {
                switch (reponse)
                {
                    case 1:
                        max = essai;
                        essai = ((max - min) / 2) + min;
                        break;
                    case 2:
                        min = essai;
                        essai = ((max - min) / 2) + min;
                        break;
                }
                reponse = demanderUser(essai);
                nombrecoups++;
            } 

            return nombrecoups;
        }
        static void Main(string[] args)
        {

            Random random = new Random();

            int nombreCoupsUser = 0;
            int nombreCoupsOrdi = 0;
            int nombreChoisi;
            int nombreATrouver;
            int max;

            Console.Write("Entrez la valeur maximale du nombre qui sera généré : ");

            max = int.Parse(Console.ReadLine());
            
            Console.WriteLine("L'ordinateur a choisi son nombre, appuyez sur une touche pour commencer.");
            nombreATrouver = random.Next(0, max);
            Console.WriteLine(nombreATrouver); //pour debug
            Console.ReadKey();

            Console.Clear();
            //Loop pour faire deviner l'humain
            do
            {
                Console.Write("Entrez un nombre : ");
                nombreChoisi = int.Parse(Console.ReadLine());
                Console.WriteLine(Message(nombreATrouver, nombreChoisi));
                nombreCoupsUser++;
            } while (nombreChoisi != nombreATrouver);

            if (nombreCoupsUser == 1)
            {
                Console.WriteLine("Vous avez deviné le chiffre en 1 coup");
            }
            else
            {
                Console.WriteLine("Vous avez deviné le chiffre en {0} coups", nombreCoupsUser);
            }
            Console.ReadKey();

            Console.Clear(); //pour enlever les trucs dans la console
            Console.Write("Entrez le nombre à faire deviner à l'ordinateur entre 0 et " + max + " : ");

            nombreATrouver = int.Parse(Console.ReadLine());
            if (nombreATrouver > max)
            {
                do
                {
                    Console.WriteLine("Le nombre entré est plus grand que le maximum défini");
                    Console.Write("Veuillez entrer un nombre valide ici : ");
                    nombreATrouver = int.Parse(Console.ReadLine());
                } while (nombreATrouver > max);
            }

            Console.Clear();

            Console.WriteLine("L'ordinateur va maintenant essayer de deviner");

            nombreCoupsOrdi = FaireDeviner(max); //fait deviner a lordinateur

            Console.Clear();

            Console.WriteLine("Nombre coups utilisateur : " + nombreCoupsUser);
            Console.WriteLine("Nombre coups ordinateur : " + nombreCoupsOrdi);

            if (nombreCoupsOrdi > nombreCoupsUser)
            {
                Console.WriteLine("L'humain a vaincu la machine!!");
            }
            else if (nombreCoupsOrdi < nombreCoupsUser)
            {
                Console.WriteLine("L'ordinateur a gagne!!!!!");
            }


        }
    }
}

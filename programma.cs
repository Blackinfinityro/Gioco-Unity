using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<(string nome, string verso)> animali = new List<(string nome, string verso)>();

        while (true)
        {
            Console.Write("Comando (aggiungi/canta/esci): ");
            string comando = Console.ReadLine().Trim().ToLower();

            if (comando == "aggiungi")
            {
                Console.Write("Inserisci l'animale (es. 'un gatto'): ");
                string nome = Console.ReadLine().Trim();

                Console.Write($"Che verso fa {nome}? ");
                string verso = Console.ReadLine().Trim();

                animali.Add((nome, verso));
                Console.WriteLine($"Hai aggiunto {nome} che fa '{verso}'.");
            }
            else if (comando == "canta")
            {
                if (animali.Count == 0)
                {
                    Console.WriteLine("Non ci sono animali nella fattoria!");
                    continue;
                }

                Console.WriteLine("\n--- LA CANZONE DELLA FATTORIA ---\n");

                for (int i = 0; i < animali.Count; i += 2)
                {
                    Console.WriteLine("Nella vecchia fattoria, ia ia o!");
                    Console.WriteLine("Quante bestie ha Zio Tobia, ia ia o!");

                    var (nome1, verso1) = animali[i];
                    string animale1 = UltimaParola(nome1);
                    Console.Write($"C'è {animale1}, {animale1}, che fa {verso1}");

                    if (i + 1 < animali.Count)
                    {
                        var (nome2, verso2) = animali[i + 1];
                        string animale2 = UltimaParola(nome2);
                        Console.WriteLine($", c'è {animale2}, {animale2}, che fa {verso2},");
                    }
                    else
                    {
                        Console.WriteLine(",");
                    }

                    Console.WriteLine("Quante bestie ha Zio Tobia, ia ia o!\n");
                }
            }
            else if (comando == "esci")
            {
                Console.WriteLine("Arrivederci dalla vecchia fattoria!");
                break;
            }
            else
            {
                Console.WriteLine("Comando non riconosciuto. Usa 'aggiungi', 'canta' o 'esci'.");
            }
        }
    }

    // Funzione di supporto: prende l’ultima parola del nome (es. "un gatto" -> "gatto")
    static string UltimaParola(string frase)
    {
        string[] parole = frase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return parole[parole.Length - 1];
    }
}
    {
    List<(string nome, string verso)> 
    animali = new List<(string nome, string verso)>();
        while (true)
        { Console.Write("Comando (Aggiungi/Canta)")}
        string Comando = Console.ReadLine().Trim().ToLower();

        if (Comando == "Aggiungi")
        {
            Console.Write("Inserisci un animale con il suo articolo indeterminativo")
            string nome = Console.ReadLine().Trim();

            Console.Write($"Che verso fa {nome}? ");
            string verso = Console.ReadLine().Trim();

            animali.Add((nome, verso));
            Console.WriteLine($"Hai aggiunto {nome} che fa '{verso}'.");

         }
        else if (Comando == "Canta")
         
            {
                if (animali.Count == 0)
                {
                    Console.WriteLine("Non ci sono animali nella fattoria!");
                    continue;
                }

                Console.WriteLine("\n--- LA CANZONE DELLA FATTORIA ---\n")



  for (int i = 0; i < animali.Count; i += 2)
            {
                Console.WriteLine("Nella vecchia fattoria, ia ia o!");
                Console.WriteLine("Quante bestie ha Zio Tobia, ia ia o!");

                var (nome1, verso1) = animali[i];
                string animale1 = UltimaParola(nome1);
                Console.Write($"C'è {animale1}, {animale1}, che fa {verso1}");





            }
     }
}
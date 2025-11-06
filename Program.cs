using System.Runtime.CompilerServices;

Console.WriteLine("Scegli l'unità iniziale:");
int.TryParse(Console.ReadLine(), out int scelta);
if (scelta == 1)
{
    Console.WriteLine("Inserisci la temperatura in Celsius");
    double celsius = Convert.ToDouble(Console.ReadLine());
    double fahrenheit = (9.0 / 5.0) * celsius + 32;
    Console.WriteLine("La temperatura convertita è " + fahrenheit);
}
else if (scelta == 2)

   {
    Console.WriteLine("Inserisci la temperatura in fahrenheit");
    double fahrenheit = Convert.ToDouble(Console.ReadLine());
    double celsius = (fahrenheit - 32) * (5.0 / 9.0);
    Console.WriteLine("La temperatura convertita è " + celsius);
}


Console.WriteLine(arrayDiInteri[0]);






int[] listainteri = { 1, 2, 3 };
int[] altroArray = new int [5],
List<int> listainteri 0 new List<int> { 1, 2, 3 };
List<int> listainteri2 = new List<int> { 1, 2, 3 };
listainteri[0] = 5;
listainteri.Add(4);
listainteri.Insert(1, 0);
listainteri.RemoveAt(1);
HashSet<int> interi = new HashSet<int> { 1, 2, 3 };


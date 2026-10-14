bool kilepes = false;

List<string> feladatok = new();

while (!kilepes)
{
    Console.WriteLine("=== Feladatlista ===");
    Console.WriteLine("1. Új feladat");
    Console.WriteLine("2. Feladat törlése");
    Console.WriteLine("3. Feladatok listázása");
    Console.WriteLine("4. Kilépés");
    Console.Write("Válassz egy opciót: ");
    string? valasztas = Console.ReadLine();
    Console.WriteLine();

    switch (valasztas)
    {
        case "1":
            UjFeladatHozzaadasa(feladatok);
            break;
        case "2":
            // Feladat törlése
            break;
        case "3":
            FeladatListazasa(feladatok);
            break;
        case "4":
            kilepes = true;
            break;
        default:
            Console.WriteLine("Érvénytelen választás!");
            break;
    }
}

void UjFeladatHozzaadasa(List<string> feladat)
{
    Console.Write("Add meg az új feladatot: ");
    string? ujFeladat = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(ujFeladat))
    {
        feladat.Add(ujFeladat);
        Console.WriteLine("Feladat hozzáadva!");
    }
    else
    {
        Console.WriteLine("A feladat nem lehet üres!");
    }
    Console.WriteLine();
}

void FeladatListazasa(List<string> lista)
{
    if (lista.Count == 0)
    {
        Console.WriteLine("Nincs feladat a listában.");
        Console.WriteLine();
        return;
    }
    else
    {
        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {lista[i]}");
        }
        Console.WriteLine();
    }        
}

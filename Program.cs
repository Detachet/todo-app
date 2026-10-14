bool kilepes = false;

List<string> feladatok = new();

while (!kilepes)
{    
    Console.WriteLine("=== Feladatlista ===");
    Console.WriteLine();
    Console.WriteLine("1. Új feladat");
    Console.WriteLine("2. Feladat törlése");
    Console.WriteLine("3. Feladatok listázása");
    Console.WriteLine("4. Kilépés");
    Console.WriteLine();
    Console.Write("Válassz egy opciót: ");
    string? valasztas = Console.ReadLine();
    Console.WriteLine();

    switch (valasztas)
    {
        case "1":
            UjFeladatHozzaadasa(feladatok);
            break;
        case "2":
            FeladatTorlese(feladatok);
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

void UjFeladatHozzaadasa(List<string> lista)
{
    Console.Write("Add meg az új feladatot: ");
    string? ujFeladat = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(ujFeladat))
    {
        lista.Add(ujFeladat);
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

    for (int i = 0; i < lista.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {lista[i]}");
    }
    Console.WriteLine();
}

void FeladatTorlese(List<string> lista)
{
    if (lista.Count == 0)
    {
        Console.WriteLine("Nincs feladat a listában.");
        Console.WriteLine();
        return;
    }
    FeladatListazasa(lista);
    Console.Write("Add meg a törölni kívánt feladat számát: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out int index) && index > 0 && index <= lista.Count)
    {
        lista.RemoveAt(index - 1);
        Console.WriteLine("Feladat törölve!");
    }
    else
    {
        Console.WriteLine("Érvénytelen szám!");
    }
    Console.WriteLine();
}

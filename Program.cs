bool kilepes = false;

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
            // Új feladat hozzáadása
            break;
        case "2":
            // Feladat törlése
            break;
        case "3":
            // Feladatok listázása
            break;
        case "4":
            kilepes = true;
            break;
        default:
            Console.WriteLine("Érvénytelen választás!");
            break;
    }
}

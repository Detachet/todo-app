using System.Text.Json;
using TodoApp;

const string FajlNev = "feladatok.json";
var jsonBeallitasok = new JsonSerializerOptions { WriteIndented = true };

bool kilepes = false;
List<TodoItem> feladatok = FeladatokBetoltese();

while (!kilepes)
{ 
    Console.WriteLine("=== Feladatlista ===");
    Console.WriteLine();
    Console.WriteLine("1. Új feladat");
    Console.WriteLine("2. Feladat törlése");
    Console.WriteLine("3. Feladatok listázása");
    Console.WriteLine("4. Feladat késznek jelölése");
    Console.WriteLine("5. Kilépés");
    Console.WriteLine();
    Console.Write("Válassz egy opciót: ");
    string? valasztas = Console.ReadLine();
    Console.WriteLine();

    switch (valasztas)
    {
        case "1":
            UjFeladatHozzaadasa(feladatok);
            FeladatokMentese(feladatok);
            break;
        case "2":
            FeladatTorlese(feladatok);
            FeladatokMentese(feladatok);
            break;
        case "3":
            FeladatListazasa(feladatok);
            break;
        case "4":
            FeladatKesznekJelolese(feladatok);
            FeladatokMentese(feladatok);
            break;
        case "5":
            kilepes = true;
            break;
        default:
            Console.WriteLine("Érvénytelen választás!");
            break;
    }
}

void UjFeladatHozzaadasa(List<TodoItem> lista)
{
    Console.Write("Add meg az új feladatot: ");
    string? ujFeladat = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(ujFeladat))
    {
        lista.Add(new TodoItem(ujFeladat));
        Console.WriteLine("Feladat hozzáadva!");
    }
    else
    {
        Console.WriteLine("A feladat nem lehet üres!");
    }
    Console.WriteLine();
}

void FeladatListazasa(List<TodoItem> lista)
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

void FeladatKesznekJelolese(List<TodoItem> lista)
{
    int? index = SorszamBekeres(lista, "késznek jelölni");
    if (index is null) return;

    lista[index.Value].MarkAsDone();
    Console.WriteLine("Feladat késznek jelölve!");
    Console.WriteLine();
}

void FeladatTorlese(List<TodoItem> lista)
{
    int? index = SorszamBekeres(lista, "törölni");
    if (index is null) return;

    lista.RemoveAt(index.Value);
    Console.WriteLine("Feladat törölve!");
    Console.WriteLine();
}

int? SorszamBekeres(List<TodoItem> lista, string muvelet)
{
    if (lista.Count == 0)
    {
        Console.WriteLine("Nincs feladat a listában.");
        Console.WriteLine();
        return null;
    }
    FeladatListazasa(lista);
    Console.Write($"Add meg a {muvelet} kívánt feladat számát: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out int index) && index > 0 && index <= lista.Count)
    {
        return index - 1; 
    }
    Console.WriteLine("Érvénytelen szám!");
    Console.WriteLine();
    return null;
}

List<TodoItem> FeladatokBetoltese()
{
    if (File.Exists(FajlNev))
        return new();

    try
    {
        string json = File.ReadAllText(FajlNev);
        return JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new();
    }
    catch (JsonException)
    {
        Console.WriteLine("A mentett fájl sérült, üres listával indulunk");
        Console.WriteLine();
        return new();
    }
}
void FeladatokMentese(List<TodoItem> lista)
{
    string json = JsonSerializer.Serialize(lista, jsonBeallitasok);
    File.WriteAllText(FajlNev, json);
}


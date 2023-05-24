using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Operatorok;

List<Kifejezes> kifejezesek = File.ReadAllLines("kifejezesek.txt").Select(x => new Kifejezes(x)).ToList();
Console.WriteLine($"2. feladat:\n\t{kifejezesek.Count()} db");
Console.WriteLine($"3. feladat:\n\t{kifejezesek.Count(x => x.Muvelet == "mod")} db");
Console.WriteLine($"4. feladat:\n\t{(kifejezesek.Select(x => x.ElsoSzam % 10 == 0 && x.MasodikSzam % 10 == 0).Count() > 0 ? "Van ilyen kifejezés" : "Nincs ilyen kifejezés")}");
Console.WriteLine("5. feladat: Statisztika");
Console.WriteLine($"\t+ -> {kifejezesek.Count(x => x.Muvelet == "+")} db");
Console.WriteLine($"\t- -> {kifejezesek.Count(x => x.Muvelet == "-")} db");
Console.WriteLine($"\t* -> {kifejezesek.Count(x => x.Muvelet == "*")} db");
Console.WriteLine($"\t/ -> {kifejezesek.Count(x => x.Muvelet == "/")} db");
Console.WriteLine($"\tmod -> {kifejezesek.Count(x => x.Muvelet == "mod")} db");
Console.WriteLine($"\tdiv -> {kifejezesek.Count(x => x.Muvelet == "div")} db");


static string Matek(string bevitel) {
    string[] tarolt = bevitel.Split(' ');
    string vissza = "";
    try
    {
        switch (tarolt[1])
        {
            case "+":
                vissza = $"{bevitel} = {Convert.ToDouble(tarolt[0]) + Convert.ToDouble(tarolt[2])}";
                break;
            case "-":
                vissza = $"{bevitel} = {Convert.ToDouble(tarolt[0]) - Convert.ToDouble(tarolt[2])}";
                break;
            case "*":
                vissza = $"{bevitel} = {Convert.ToDouble(tarolt[0]) * Convert.ToDouble(tarolt[2])}";
                break;
            case "/":
                vissza = $"{bevitel} = {Convert.ToDouble(tarolt[0]) / Convert.ToDouble(tarolt[2])}";
                break;
            case "mod":
                vissza = $"{bevitel} = {Convert.ToDouble(tarolt[0]) % Convert.ToDouble(tarolt[2])}";
                break;
            case "div":
                vissza = $"{bevitel} = {Convert.ToDouble(tarolt[0]) / Convert.ToDouble(tarolt[2])}";
                break;
            default:
                vissza = $"{bevitel} = Hibás műveletjel";
                break;
        }
    }
    catch (Exception)
    {
        vissza = $"{bevitel} = Egyéb hiba";
    }
    return vissza;
}


while (true)
{
    Console.Write("7. feladat: Kérek egy kifejezést (pl. 1 + 1): ");
    string? bevitel = Console.ReadLine();
    bevitel = bevitel.Trim();
    if (bevitel == "vége")
    {
        break;
    }
    Console.WriteLine($"\t{Matek(bevitel)}");
}

StreamWriter sw = new StreamWriter("eredmenyek.txt");

foreach (Kifejezes item in kifejezesek)
{
    sw.WriteLine(Matek($"{item.ElsoSzam} {item.Muvelet} {item.MasodikSzam}"));
}

sw.Close();
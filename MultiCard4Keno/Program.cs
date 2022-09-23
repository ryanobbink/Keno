// See https://aka.ms/new-console-template for more information
using MultiCard4Keno.Models;
using MultiCard4Keno.Factory;


Card card = CardFactory.Create(MultiCard4Keno.Enums.CardName.CardA);
Console.WriteLine($" Welcome to IGT Keno");
Console.WriteLine($" Let's Quick Pick 10 Cards ");
Console.WriteLine($"Press Any Key");
Console.ReadLine();
card.QuickPick();

Console.WriteLine($"Quick Pick Spots Are:");
foreach(int mark in card.Marked)
{
    Console.WriteLine($"Quick Pick Spot Marked: { mark } ");
}

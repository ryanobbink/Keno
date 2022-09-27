// See https://aka.ms/new-console-template for more information
using Keno.Core.Enums;
using Keno.Core.Models;
using Keno.Core.Factory;
using Keno.Core.Interfaces;

ICard card = CardFactory.Create(CardName.CardA);
Console.WriteLine($" Welcome to IGT Keno");
Console.WriteLine($" Let's Quick Pick 10 Cards ");
Console.WriteLine($"Press Any Key");
Console.ReadLine();
card.QuickPick();
card.Draw();

//Game Time
Console.WriteLine($"Quick Pick Spot Marked: {string.Join(",", card.Marked)} ");
Console.WriteLine($"20 Spots Drawn Are: {string.Join(",", card.Drawn)} ");
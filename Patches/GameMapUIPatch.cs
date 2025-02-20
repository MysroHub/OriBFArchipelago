using System;
using HarmonyLib;

namespace OriBFArchipelago.Patches;

[HarmonyPatch(typeof(GameMapUI), nameof(GameMapUI.Show))]
internal class GameMapUIPatch
{
    private static void Postfix(GameMapUI __instance)
    {
        Console.WriteLine("All Map is Discovered by Prefix!");
    }
}
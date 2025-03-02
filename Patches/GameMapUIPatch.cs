using System;
using HarmonyLib;
using Sein.World;

namespace OriBFArchipelago.Patches;

/// <summary>
/// Patch the GameMapUI to see the entire world map
/// </summary>
[HarmonyPatch(typeof(GameMapUI), nameof(GameMapUI.Show))]
internal class GameMapUIPatch
{
    
    /// <summary>
    /// Allows you to see the entire world map
    /// </summary>
    private static void Prefix()
    {
        foreach (var area in GameWorld.Instance.RuntimeAreas)
        {
            area.VisitAllAreas();
        }
    }
}


[HarmonyPatch(typeof(MistController), nameof(MistController.Awake))]
internal class MistControllerPatch
{
    private static void Prefix()
    {
        Console.WriteLine("MistController called");
        Events.MistLifted = true;
    }
}

[HarmonyPatch(typeof(MistAction), nameof(MistAction.Perform))]
internal class MistActionPatch
{
    private static void Prefix(MistAction __instance)
    {
        Console.WriteLine("MistAction called");
        __instance.Action = MistAction.ActionType.HideMist;
    }
}

[HarmonyPatch(typeof(MistyWoodsAreaMapCanvas), nameof(MistyWoodsAreaMapCanvas.OnEnable))]
internal class MistyWoodsAreaMapCanvasPatch
{
    private static bool Prefix()
    {
        Console.WriteLine("MistyWoodsAreaMapCanvasPatch called");
        return false; // We want to skip the original method
    }
}






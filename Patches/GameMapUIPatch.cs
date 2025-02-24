using HarmonyLib;

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
    /// <param name="__instance">the instance of the GameMapUI to patch</param>
    private static void Postfix(GameMapUI __instance)
    {
        foreach (var teleporter in __instance.Teleporters.Teleporters)
        {
            teleporter.Area.VisitAllAreas();
        }
    }
}
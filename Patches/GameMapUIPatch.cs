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
    private static void Prefix()
    {
        foreach (var area in GameWorld.Instance.RuntimeAreas)
        {
            area.VisitAllAreas();
        }
    }
}
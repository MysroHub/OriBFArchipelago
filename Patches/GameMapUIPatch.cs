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
    /// <param name="__instance">the instance of the GameMapUI to patch</param>
    
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
        Events.MistLifted = true;
    }
}


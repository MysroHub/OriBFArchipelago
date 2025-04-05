using HarmonyLib;
using UnityEngine;

namespace OriBFArchipelago.Patches;

/// <summary>
/// Patchs the GameMapUI to see the entire world map except Mysty Woods
/// </summary>
[HarmonyPatch(typeof(GameMapUI), nameof(GameMapUI.Show))]
internal class GameMapUIPatch
{
    
    /// <summary>
    /// Allows you to see the entire world map except Misty Woods
    /// </summary>
    private static void Prefix()
    {
        foreach (var area in GameWorld.Instance.RuntimeAreas)
        {
            area.VisitAllAreas();
        }
    }
}

/// <summary>
/// Patchs the Misty Woods Area of the GameMapUI
/// We go through a routine that is active when we need to patch the map
/// </summary>
[HarmonyPatch(typeof(GameMapUI), nameof(GameMapUI.UpdateAreaText))]
internal class UpdateAreaTextPath
{
    /// <summary>
    /// Unlock the Misty Woods Area on the GameMapUI
    /// </summary>
    private static void Prefix()
    {
        Transform mapPivot = AreaMapUI.Instance.transform.Find("mapPivot");
        mapPivot.FindChild("mistyWoodsFog").gameObject.SetActive(false);
        mapPivot.FindChild("mistyWoods").gameObject.SetActive(true);
    }
}
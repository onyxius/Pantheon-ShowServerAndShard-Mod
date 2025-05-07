using HarmonyLib;
using Il2Cpp;

namespace ShowServerAndShard.Hooks;

/// <summary>
/// Hooks for UI panel events, specifically for creating the server name display
/// </summary>
[HarmonyPatch(typeof(UIWindowPanel), nameof(UIWindowPanel.Start))]
public class UIPanelHooks
{
    /// <summary>
    /// Called when a UI panel starts
    /// Creates the server name display when the compass panel is initialized
    /// </summary>
    /// <param name="__instance">The UI panel that started</param>
    private static void Postfix(UIWindowPanel __instance)
    {
        if (__instance.name == "Panel_Compass")
        {
            ShowServerAndShard.ModMain.CreateInfoPanelText(__instance.transform);
        }
    }
} 
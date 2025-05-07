using HarmonyLib;
using Il2Cpp;

<<<<<<< HEAD
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
=======
namespace InfoPanel.Hooks;

[HarmonyPatch(typeof(UIWindowPanel), nameof(UIWindowPanel.Start))]
public class UIPanelHooks
{
    private static void Postfix(UIWindowPanel __instance)
    {
        // MelonLoader.MelonLogger.Msg($"UIPanel started: {__instance.name}");
>>>>>>> f70f24938c83148f5d709bd8b99ab22887e94e36
        if (__instance.name == "Panel_Compass")
        {
            ShowServerAndShard.ModMain.CreateInfoPanelText(__instance.transform);
        }
    }
} 
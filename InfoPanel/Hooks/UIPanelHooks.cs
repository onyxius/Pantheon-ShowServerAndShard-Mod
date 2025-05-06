using HarmonyLib;
using Il2Cpp;

namespace InfoPanel.Hooks;

[HarmonyPatch(typeof(UIWindowPanel), nameof(UIWindowPanel.Start))]
public class UIPanelHooks
{
    private static void Postfix(UIWindowPanel __instance)
    {
        // MelonLoader.MelonLogger.Msg($"UIPanel started: {__instance.name}");
        if (__instance.name == "Panel_Compass")
        {
            InfoPanel.ModMain.CreateInfoPanelText(__instance.transform);
        }
    }
} 
using HarmonyLib;
using Il2Cpp;
using MelonLoader;

<<<<<<< HEAD
namespace ShowServerAndShard.Hooks;

/// <summary>
/// Hooks for handling server selection events in the UI
/// </summary>

/// <summary>
/// Hook for when a server is selected in the UI
/// </summary>
[HarmonyPatch(typeof(UIRealmListItem), "OnSelected")]
public class UIRealmListItem_OnSelected_Hook
{
    /// <summary>
    /// Called after a server is selected in the UI
    /// Updates the displayed server name
    /// </summary>
    private static void Postfix(UIRealmListItem __instance)
    {
        try
        {
            string serverName = __instance.Name;
            ShowServerAndShard.ModMain.SetServerName(serverName, true);
        }
        catch (System.Exception)
        {
        }
    }
}

/// <summary>
/// Hook for when a server is programmatically selected
/// </summary>
[HarmonyPatch(typeof(UIRealmListItem), "Select")]
public class UIRealmListItem_Select_Hook
{
    /// <summary>
    /// Called after a server is programmatically selected
    /// Updates the displayed server name
    /// </summary>
    private static void Postfix(UIRealmListItem __instance)
    {
        try
        {
            string serverName = __instance.Name;
            ShowServerAndShard.ModMain.SetServerName(serverName, true);
        }
        catch (System.Exception)
        {
        }
    }
}

/// <summary>
/// Hook for when a server list item is initialized
/// </summary>
[HarmonyPatch(typeof(UIRealmListItem), "Init")]
public class UIRealmListItem_Init_Hook
{
    /// <summary>
    /// Called after a server list item is initialized
    /// If the server is pre-selected, updates the displayed server name
    /// </summary>
    private static void Postfix(UIRealmListItem __instance)
    {
        try
        {
            var toggle = __instance.toggle;
            if (toggle != null && toggle.isOn)
            {
                ShowServerAndShard.ModMain.SetServerName(__instance.Name, false);
            }
        }
        catch (System.Exception)
        {
        }
    }
}

/// <summary>
/// Hook for when server load information is refreshed
/// </summary>
[HarmonyPatch(typeof(UIRealmListItem), "RefreshServerLoad")]
public class UIRealmListItem_RefreshServerLoad_Hook
{
    /// <summary>
    /// Called after server load information is refreshed
    /// Currently a no-op as we don't need to update the display
    /// </summary>
    private static void Postfix(UIRealmListItem __instance)
    {
    }
}

/// <summary>
/// Hook for when a server list item is constructed
/// </summary>
[HarmonyPatch(typeof(UIRealmListItem), MethodType.Constructor)]
public class UIRealmListItem_Ctor_Hook
{
    /// <summary>
    /// Called after a server list item is constructed
    /// Currently a no-op as we don't need to do anything at construction time
    /// </summary>
    private static void Postfix(UIRealmListItem __instance)
    {
=======
namespace InfoPanel.Hooks;

// Patch OnSelected with no parameters
[HarmonyPatch(typeof(UIRealmListItem), "OnSelected")]
public class UIRealmListItem_OnSelected_Hook
{
    private static void Postfix(UIRealmListItem __instance)
    {
        // MelonLogger.Msg($"[InfoPanel] OnSelected hook fired for: {__instance.Name}");
        string serverName = __instance.Name;
        ShowServerAndShard.ModMain.SetServerName(serverName);
    }
}

// Patch Select method
[HarmonyPatch(typeof(UIRealmListItem), "Select")]
public class UIRealmListItem_Select_Hook
{
    private static void Postfix(UIRealmListItem __instance)
    {
        // MelonLogger.Msg($"[InfoPanel] Select hook fired for: {__instance.Name}");
        string serverName = __instance.Name;
        ShowServerAndShard.ModMain.SetServerName(serverName);
    }
}

// Patch Init
[HarmonyPatch(typeof(UIRealmListItem), "Init")]
public class UIRealmListItem_Init_Hook
{
    private static void Postfix(UIRealmListItem __instance)
    {
        // MelonLogger.Msg($"[InfoPanel] Init hook fired for: {__instance.Name}");
    }
}

// Patch RefreshServerLoad
[HarmonyPatch(typeof(UIRealmListItem), "RefreshServerLoad")]
public class UIRealmListItem_RefreshServerLoad_Hook
{
    private static void Postfix(UIRealmListItem __instance)
    {
        // MelonLogger.Msg($"[InfoPanel] RefreshServerLoad hook fired for: {__instance.Name}");
    }
}

// Patch constructor
[HarmonyPatch(typeof(UIRealmListItem), MethodType.Constructor)]
public class UIRealmListItem_Ctor_Hook
{
    private static void Postfix(UIRealmListItem __instance)
    {
        // MelonLogger.Msg("[InfoPanel] UIRealmListItem constructor hook fired.");
>>>>>>> f70f24938c83148f5d709bd8b99ab22887e94e36
    }
} 
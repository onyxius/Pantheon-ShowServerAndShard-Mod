using HarmonyLib;
using Il2Cpp;

namespace InfoPanel.Hooks;

// Patch OnSelected with no parameters
[HarmonyPatch(typeof(UIRealmListItem), "OnSelected")]
public class UIRealmListItem_OnSelected_Hook
{
    private static void Postfix(UIRealmListItem __instance)
    {
        string serverName = __instance.Name;
        InfoPanel.ModMain.SetServerName(serverName);
    }
}

// Patch Select method
[HarmonyPatch(typeof(UIRealmListItem), "Select")]
public class UIRealmListItem_Select_Hook
{
    private static void Postfix(UIRealmListItem __instance)
    {
        string serverName = __instance.Name;
        InfoPanel.ModMain.SetServerName(serverName);
    }
}

// Patch Init
[HarmonyPatch(typeof(UIRealmListItem), "Init")]
public class UIRealmListItem_Init_Hook
{
    private static void Postfix(UIRealmListItem __instance)
    {
        // No logging
    }
}

// Patch RefreshServerLoad
[HarmonyPatch(typeof(UIRealmListItem), "RefreshServerLoad")]
public class UIRealmListItem_RefreshServerLoad_Hook
{
    private static void Postfix(UIRealmListItem __instance)
    {
        // No logging
    }
}

// Patch constructor
[HarmonyPatch(typeof(UIRealmListItem), MethodType.Constructor)]
public class UIRealmListItem_Ctor_Hook
{
    private static void Postfix(UIRealmListItem __instance)
    {
        // No logging
    }
} 
using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;
using Il2CppTMPro;
using UnityEngine.UI;

namespace InfoPanel.Hooks;

[HarmonyPatch(typeof(EntityPlayerGameObject), nameof(EntityPlayerGameObject.NetworkStart))]
public class PlayerNetworkStartHook
{
    private static void Prefix(EntityPlayerGameObject __instance)
    {
        // Fired in character select
        if (__instance.NetworkId.Value == 1)
        {
            return;
        }

        if (__instance.NetworkId.Value == EntityPlayerGameObject.LocalPlayerId.Value)
        {
            MelonLogger.Msg("Local player is about to start setting up");
        }
    }
    
    private static void Postfix(EntityPlayerGameObject __instance)
    {
        // Fired in character select
        if (__instance.NetworkId.Value == 1)
        {
            return;
        }

        if (__instance.NetworkId.Value == EntityPlayerGameObject.LocalPlayerId.Value)
        {
            MelonLogger.Msg("Local player finished setting up");
            // UI creation now handled in UIPanelHooks.cs
        }
    }
}
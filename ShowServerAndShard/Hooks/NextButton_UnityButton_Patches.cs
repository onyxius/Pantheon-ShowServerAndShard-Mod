using HarmonyLib;
using MelonLoader;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ShowServerAndShard.Hooks
{
    [HarmonyPatch(typeof(Button), "OnPointerClick")]
    public class NextButton_OnPointerClick_Patch
    {
        private static void Prefix(Button __instance, PointerEventData eventData)
        {
            // No-op: Logging removed
        }
    }

    [HarmonyPatch(typeof(Button), "OnSubmit")]
    public class NextButton_OnSubmit_Patch
    {
        private static void Prefix(Button __instance, BaseEventData eventData)
        {
            // No-op: Logging removed
        }
    }

    [HarmonyPatch(typeof(Button), "Press")]
    public class NextButton_Press_Patch
    {
        private static void Prefix(Button __instance)
        {
            // No-op: Logging removed
        }
    }
} 
using HarmonyLib;
using UnityEngine.UI;
using MelonLoader;

namespace ShowServerAndShard.Hooks
{
    [HarmonyPatch(typeof(Button), "OnPointerClick")]
    public class ButtonClickLogger
    {
        private static void Prefix(Button __instance)
        {
            //MelonLogger.Msg($"[ShowServerAndShard] Button clicked: {__instance.name}");
        }
    }
} 
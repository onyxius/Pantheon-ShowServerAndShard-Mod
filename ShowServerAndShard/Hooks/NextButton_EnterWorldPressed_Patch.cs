using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using System.Reflection;

namespace ShowServerAndShard.Hooks
{
    // Patch EnterWorldPressed (uppercase)
    [HarmonyPatch(typeof(Il2Cpp.Login_Client), nameof(Il2Cpp.Login_Client.EnterWorldPressed))]
    public class NextButton_EnterWorldPressed_Patch
    {
        private static void Postfix(Il2Cpp.Login_Client __instance)
        {
            var serverName = Il2Cpp.Login_Client.currentRealmName;
            
            var realmList = __instance.realmList as Il2CppSystem.Collections.Generic.List<Il2CppPantheonSOA.PWSServerList>;
            if (realmList != null)
            {
                foreach (var item in realmList)
                {
                    var itemProperties = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var prop in itemProperties)
                    {
                        try
                        {
                            var value = prop.GetValue(item, null);
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                }
            }
            
            // Log all fields/properties of __instance related to realm selection
            var type = __instance.GetType();
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                try
                {
                    var value = field.GetValue(__instance);
                }
                catch (System.Exception ex)
                {
                }
            }
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                try
                {
                    var value = prop.GetValue(__instance, null);
                }
                catch (System.Exception ex)
                {
                }
            }
            
            // --- Dump RealmListEntry ---
            var realmListEntryProp = type.GetProperty("RealmListEntry", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var realmListEntry = realmListEntryProp?.GetValue(__instance, null);
            if (realmListEntry != null)
            {
                var entryFields = realmListEntry.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var field in entryFields)
                {
                    try
                    {
                        var value = field.GetValue(realmListEntry);
                    }
                    catch (System.Exception ex)
                    {
                    }
                }
                var entryProps = realmListEntry.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var prop in entryProps)
                {
                    try
                    {
                        var value = prop.GetValue(realmListEntry, null);
                    }
                    catch (System.Exception ex)
                    {
                    }
                }
            }
            
            // --- Iterate over all children of RealmSelectionGroup and log UIRealmListItem selection state ---
            var realmSelectionGroupProp = type.GetProperty("RealmSelectionGroup", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var realmSelectionGroup = realmSelectionGroupProp?.GetValue(__instance, null);
            if (realmSelectionGroup != null)
            {
                var groupType = realmSelectionGroup.GetType();
                var transformProp = groupType.GetProperty("transform");
                var transform = transformProp?.GetValue(realmSelectionGroup, null);
                if (transform != null)
                {
                    var childCountProp = transform.GetType().GetProperty("childCount");
                    int childCount = childCountProp != null ? (int)childCountProp.GetValue(transform, null) : 0;
                    var getChildMethod = transform.GetType().GetMethod("GetChild");
                    for (int i = 0; i < childCount; i++)
                    {
                        var child = getChildMethod.Invoke(transform, new object[] { i });
                        var childGameObjectProp = child.GetType().GetProperty("gameObject");
                        var childGameObject = childGameObjectProp?.GetValue(child, null);
                        if (childGameObject != null)
                        {
                            // Try to get UIRealmListItem component
                            var getComponentMethod = childGameObject.GetType().GetMethod("GetComponent", new[] { typeof(Type) });
                            if (getComponentMethod != null)
                            {
                                var uiRealmListItemType = typeof(Il2Cpp.UIRealmListItem);
                                var uiRealmListItem = getComponentMethod.Invoke(childGameObject, new object[] { uiRealmListItemType });
                                if (uiRealmListItem != null)
                                {
                                    // Log Name, IsOn, and toggle.isOn
                                    try
                                    {
                                        var nameProp = uiRealmListItem.GetType().GetProperty("Name");
                                        var isOnProp = uiRealmListItem.GetType().GetProperty("IsOn");
                                        var toggleProp = uiRealmListItem.GetType().GetProperty("toggle");
                                        var name = nameProp?.GetValue(uiRealmListItem, null)?.ToString();
                                        var isOn = isOnProp?.GetValue(uiRealmListItem, null)?.ToString();
                                        string toggleIsOn = "(toggle not found)";
                                        if (toggleProp != null)
                                        {
                                            var toggle = toggleProp.GetValue(uiRealmListItem, null);
                                            if (toggle != null)
                                            {
                                                var toggleIsOnProp = toggle.GetType().GetProperty("isOn");
                                                if (toggleIsOnProp != null)
                                                {
                                                    toggleIsOn = toggleIsOnProp.GetValue(toggle, null)?.ToString();
                                                }
                                            }
                                        }
                                    }
                                    catch (System.Exception ex)
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            string serverToUse = !string.IsNullOrEmpty(ShowServerAndShard.ModMain.activelySelectedServerName)
                ? ShowServerAndShard.ModMain.activelySelectedServerName
                : ShowServerAndShard.ModMain.preselectedServerName;
            ShowServerAndShard.ModMain.SetServerName(serverToUse);
        }
    }
} 
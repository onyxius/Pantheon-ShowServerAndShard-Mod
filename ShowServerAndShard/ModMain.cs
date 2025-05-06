using MelonLoader;
using UnityEngine; // For GameObject, Color, and Vector3
//using TMPro;       // For TextMeshPro
using Il2CppTMPro;
using UnityEngine.UI;

namespace ShowServerAndShard;

/// <summary>
/// Main mod class that handles the server name display functionality.
/// This mod adds a text display showing the currently selected server name
/// below the compass UI element.
/// </summary>
public class ModMain : MelonMod
{
    public const string ModVersion = "1.0.1";
    
    // UI Elements
    private static GameObject textObject;        // The GameObject that holds our text display
    private static TextMeshProUGUI textMeshPro;  // The TextMeshPro component for rendering text
    
    // Server Name Tracking
    private static string serverName = "";                    // Current server name
    public static string preselectedServerName = "";         // Server name from initial selection
    public static string activelySelectedServerName = "";    // Server name from user selection

    /// <summary>
    /// Called when the mod is initialized
    /// </summary>
    public override void OnInitializeMelon()
    {
        //MelonLogger.Msg("[ShowServerAndShard] [DEBUG] Mod Initialized!");
    }

    /// <summary>
    /// Called when a new scene is loaded
    /// </summary>
    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        //MelonLogger.Msg($"[ShowServerAndShard] [DEBUG] Scene loaded: {sceneName} (buildIndex: {buildIndex})");
        // UI creation moved to CreateInfoPanelText, called from UIPanelHooks
    }

    /// <summary>
    /// Updates the server name display and stores the selection state
    /// </summary>
    /// <param name="name">The server name to display</param>
    /// <param name="isActiveSelection">Whether this is a user selection (true) or pre-selection (false)</param>
    public static void SetServerName(string name, bool isActiveSelection = false)
    {
        if (isActiveSelection)
            activelySelectedServerName = name;
        else
            preselectedServerName = name;
        serverName = name;
        //MelonLogger.Msg($"[ShowServerAndShard] SetServerName called with: '{name}', isActiveSelection={isActiveSelection}");
        if (textMeshPro != null)
            textMeshPro.text = name;
    }

    /// <summary>
    /// Creates the text display UI element under the compass
    /// </summary>
    /// <param name="parent">The parent transform (compass panel) to attach the text to</param>
    public static void CreateInfoPanelText(Transform parent)
    {
        //MelonLogger.Msg($"[ShowServerAndShard] CreateInfoPanelText called. Current serverName: '{serverName}'");
        if (textObject != null)
        {
            GameObject.Destroy(textObject);
        }

        // Create a GameObject to hold the text
        textObject = new GameObject("InfoPanelText");
        textObject.transform.SetParent(parent, false);

        // Add a TextMeshProUGUI component
        textMeshPro = textObject.AddComponent<TextMeshProUGUI>();

        // Set text properties
        textMeshPro.text = string.IsNullOrEmpty(serverName) ? "No server selected" : serverName;
        //MelonLogger.Msg($"[ShowServerAndShard] InfoPanelText initial text: '{textMeshPro.text}'");
        textMeshPro.fontSize = 12;
        textMeshPro.color = Color.yellow;
        textMeshPro.alignment = TextAlignmentOptions.Center;

        // Set position using RectTransform
        RectTransform rectTransform = textMeshPro.rectTransform;
        rectTransform.anchorMin = new Vector2(0.5f, 0f); // anchor to bottom center of compass
        rectTransform.anchorMax = new Vector2(0.5f, 0f);
        rectTransform.pivot = new Vector2(0.5f, 1f); // pivot at top center of text
        rectTransform.anchoredPosition = new Vector2(0, -5); // 10 units below the compass, adjust as needed
        rectTransform.sizeDelta = new Vector2(400, 20);
    }
}

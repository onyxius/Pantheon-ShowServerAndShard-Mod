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
    }

    /// <summary>
    /// Called when a new scene is loaded
    /// </summary>
    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
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
        
        if (textMeshPro != null)
            textMeshPro.text = name;
    }

    /// <summary>
    /// Creates the text display UI element under the compass
    /// </summary>
    /// <param name="parent">The parent transform (compass panel) to attach the text to</param>
    public static void CreateInfoPanelText(Transform parent)
    {
        // Clean up existing text object if it exists
        if (textObject != null)
        {
            GameObject.Destroy(textObject);
        }

        // Create new GameObject for the text
        textObject = new GameObject("InfoPanelText");
        textObject.transform.SetParent(parent, false);

        // Add and configure TextMeshPro component
        textMeshPro = textObject.AddComponent<TextMeshProUGUI>();
        textMeshPro.text = string.IsNullOrEmpty(serverName) ? "No server selected" : serverName;
        textMeshPro.fontSize = 12;
        textMeshPro.color = Color.yellow;
        textMeshPro.alignment = TextAlignmentOptions.Center;

        // Position the text below the compass
        RectTransform rectTransform = textMeshPro.rectTransform;
        rectTransform.anchorMin = new Vector2(0.5f, 0f);  // Anchor to bottom center
        rectTransform.anchorMax = new Vector2(0.5f, 0f);
        rectTransform.pivot = new Vector2(0.5f, 1f);      // Pivot at top center
        rectTransform.anchoredPosition = new Vector2(0, -5); // 5 units below compass
        rectTransform.sizeDelta = new Vector2(400, 20);   // Set width and height
    }
}

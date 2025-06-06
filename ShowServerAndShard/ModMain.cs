using MelonLoader;
using UnityEngine;
using Il2CppTMPro;
using UnityEngine.UI;
using Object = UnityEngine.Object;

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
    private static GameObject? _textObject;        // The GameObject that holds our text display
    private static TextMeshProUGUI? _textMeshPro;  // The TextMeshPro component for rendering text
    
    // Server Name Tracking
    private static string _serverName = "";                    // Current server name

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
    public static void SetServerName(string name)
    {
        _serverName = name;
        
        if (_textMeshPro != null)
            _textMeshPro.text = name;
    }

    /// <summary>
    /// Creates the text display UI element under the compass
    /// </summary>
    /// <param name="parent">The parent transform (compass panel) to attach the text to</param>
    public static void CreateInfoPanelText(Transform parent)
    {
        // Clean up existing text object if it exists
        if (_textObject != null)
        {
            Object.Destroy(_textObject);
        }

        // Create new GameObject for the text
        _textObject = new GameObject("InfoPanelText");
        _textObject.transform.SetParent(parent, false);

        // Add and configure TextMeshPro component
        _textMeshPro = _textObject.AddComponent<TextMeshProUGUI>();
        _textMeshPro.text = string.IsNullOrEmpty(_serverName) ? "No server selected" : _serverName;
        _textMeshPro.fontSize = 12;
        _textMeshPro.color = Color.yellow;
        _textMeshPro.alignment = TextAlignmentOptions.Center;

        // Position the text below the compass
        RectTransform rectTransform = _textMeshPro.rectTransform;
        rectTransform.anchorMin = new Vector2(0.5f, 0f);  // Anchor to bottom center
        rectTransform.anchorMax = new Vector2(0.5f, 0f);
        rectTransform.pivot = new Vector2(0.5f, 1f);      // Pivot at top center
        rectTransform.anchoredPosition = new Vector2(0, -5); // 5 units below compass
        rectTransform.sizeDelta = new Vector2(400, 20);   // Set width and height
    }
}

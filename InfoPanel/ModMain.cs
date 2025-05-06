using MelonLoader;
using UnityEngine; // For GameObject, Color, and Vector3
//using TMPro;       // For TextMeshPro
using Il2CppTMPro;
using UnityEngine.UI;

namespace InfoPanel;

public class ModMain : MelonMod
{
    public const string ModVersion = "1.0.0";
    private static GameObject textObject;
    private static TextMeshProUGUI textMeshPro;
    private static string serverName = "";

    public override void OnInitializeMelon()
    {
        MelonLogger.Msg("InfoPanel Mod Initialized!");
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        MelonLogger.Msg($"Scene loaded as: {sceneName}");
        // UI creation moved to CreateInfoPanelText, called from UIPanelHooks
    }

    public static void SetServerName(string name)
    {
        serverName = name;
        if (textMeshPro != null)
            textMeshPro.text = string.IsNullOrEmpty(serverName) ? "No server selected" : serverName;
    }

    public static void CreateInfoPanelText(Transform parent)
    {
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

using TMPro;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    
    private void Update()
    {
        var gh = GameHandler.Instance;
        
        textMesh.text = $"Current tool: {gh.currentTool.name}\n" +
                        $"Current tool type: {gh.currentTool.type}";
    }
}

using Classes;
using UnityEngine;

public class ToolsInventory : MonoBehaviour
{
    public Tool tool;
    
    private void OnMouseDown()
    {
        GameManager.Instance.currentTool = tool;
    }
}
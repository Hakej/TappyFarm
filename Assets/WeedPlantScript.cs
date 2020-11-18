using System.Collections;
using System.Collections.Generic;
using Classes.Enums;
using UnityEngine;

public class WeedPlantScript : MonoBehaviour
{
    // Events
    private void OnMouseDown()
    {
        if (GameHandler.Instance.currentTool.type != ToolType.Scythe)
        {
            Debug.Log("You need to get rid of the weed first with a scythe!");
            return;
        }
        
        Gather();
    }
    
    // Custom methods
    private void Gather()
    {
        Destroy(gameObject);
    }
}

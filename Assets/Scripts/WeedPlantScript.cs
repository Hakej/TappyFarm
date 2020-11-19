using System;
using System.Collections;
using System.Collections.Generic;
using Classes.Enums;
using UnityEngine;

public class WeedPlantScript : MonoBehaviour
{
    private void Start()
    {
        EventManager.Instance.onLeftClickDown += OnLeftClickDown;
    }

    private void OnDestroy()
    {
        if (EventManager.Instance == null) return;
        EventManager.Instance.onLeftClickDown -= OnLeftClickDown;
    }

    // Events
    private void OnLeftClickDown(Transform hitTransform)
    {
        if (hitTransform != transform) return;;
        
        if (GameManager.Instance.currentTool.type != ToolType.Scythe)
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

using System;
using System.Collections;
using System.Collections.Generic;
using Classes.Enums;
using Classes.UnityExtensions;
using UnityEngine;

public class WeedPlantScript : MonoBehaviour
{
    private Collider2D _collider2D;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    // Events
    private void Update()
    {
        if (RaycastInput.IsLMBDownColliding(_collider2D))
        {
            UserInput();
        }
    }

    // Custom methods
    private void UserInput()
    {
        if (GameHandler.Instance.currentTool.type != ToolType.Scythe)
        {
            Debug.Log("You need to get rid of the weed first with a scythe!");
            return;
        }
        
        Gather();
    }
    
    private void Gather()
    {
        Destroy(gameObject);
    }
}

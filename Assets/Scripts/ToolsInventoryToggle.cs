using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsInventoryToggle : MonoBehaviour
{
    public GameObject inventory;
    public float inventoryShowSpeed;
    
    private Vector3 _shownInventoryPosition;
    private Vector3 _hiddenInventoryPosition;
    private bool _isInventoryShown = false;
    
    // Events
    private void Start()
    {
        _hiddenInventoryPosition = inventory.transform.position;

        var invSprite = inventory.GetComponent<SpriteRenderer>().sprite;
        var width = (invSprite.rect.width * inventory.transform.localScale.x);
        var widthInUnits = width / invSprite.pixelsPerUnit;
        
        _shownInventoryPosition = new Vector3(widthInUnits, _hiddenInventoryPosition.y);
    }
        
    private void Update()
    {
        var targetPosition = _isInventoryShown ? _shownInventoryPosition : _hiddenInventoryPosition;
        
        if (Math.Abs(transform.position.x - targetPosition.x) < 0.01f) return;
            
        var step = inventoryShowSpeed * Time.deltaTime;
        var seedInvPos = inventory.transform.position;
        
        inventory.transform.position = Vector3.MoveTowards(seedInvPos, targetPosition, step);
    }

    private void OnMouseDown()
    {
        _isInventoryShown = !_isInventoryShown;
    }
}

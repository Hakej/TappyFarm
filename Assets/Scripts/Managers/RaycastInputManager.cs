using System;
using UnityEngine;

public class RaycastInputManager : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hits = Physics2D.RaycastAll(mousePosition, Vector2.zero);
         
            foreach (var hit in hits)
            {
                EventManager.Instance.LeftClickDown(hit.transform);
            }
        }
    }
}

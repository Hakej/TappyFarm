using UnityEngine;

namespace Classes.UnityExtensions
{
    public class RaycastInput
    {
        public static bool IsLMBDownColliding(Collider2D collider2D)
        {
            if (!Input.GetMouseButtonDown(0)) return false;
            
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return collider2D.OverlapPoint(mousePosition);
        }
    }
}
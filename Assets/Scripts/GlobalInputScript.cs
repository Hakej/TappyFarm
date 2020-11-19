using Classes.Enums;
using UnityEngine;

public class GlobalInputScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameManager.Instance.ClearCurrentTool();
        }
    }
}
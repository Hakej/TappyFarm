using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public Transform cursorObj;
    public Transform seedInvObj;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnMouseDown()
    {
        if (gameObject.name == "scythe")
        {
            GMScript.currentTool = "scythe";
        }
        else if (gameObject.name == "seeds")
        {
            //GMScript.currentTool = "seeds";
            seedInvObj.transform.position = new Vector2(6, -4);
        }
        else if (gameObject.name == "bucket")
        {
            GMScript.currentTool = "bucket";
        }
        cursorObj.transform.position = transform.position;
        Debug.Log(GMScript.currentTool);
    }
}
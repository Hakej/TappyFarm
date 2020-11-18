using System.Collections;
using System.Collections.Generic;
using Classes.Enums;
using UnityEngine;

public class TextInfo : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Renderer>().sortingOrder = 6;
    }

    // Update is called once per frame
    private void Update()
    {/*
        if (gameObject.name == "sunflowerTxt")
        {
            GetComponent<TextMesh>().text = $"Sunflower Seeds: {GameHandlerScript.sunFlowerSeeds}";
        }
        else if (gameObject.name == "carrotTxt")
        {
            GetComponent<TextMesh>().text = $"Carrot Seeds: {GameHandlerScript.carrotSeeds}";
        }
        else if (gameObject.name == "potatoTxt")
        {
            GetComponent<TextMesh>().text = $"Potato Seeds: {GameHandlerScript.potatoSeeds}";
        }
        */
    }

    private void OnMouseDown()
    {/*
        GameHandler.currentTool.type = ToolType.Seeds;

        switch (gameObject.name)
        {
            case "sunflowerTxt":
                GameHandler.currentTool.name = "SunflowerPlant";
                break;
            case "carrotTxt":
                GameHandler.currentTool.name = "carrot";
                break;
            case "potatoTxt":
                GameHandler.currentTool.name = "potato";
                break;
        }
        */
    }
}
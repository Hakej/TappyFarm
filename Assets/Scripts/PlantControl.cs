using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantControl : MonoBehaviour
{
    public Sprite noPlantObj;

    public Sprite sunFlower1;
    public Sprite sunFlower2;

    public Sprite potato1;
    public Sprite potato2;

    public Sprite carrot1;
    public Sprite carrot2;

    public float growTime = 0;

    public Transform plotObj;
    public bool watered = false;

    public string currentSeed = null;

    private void Update()
    {
        if (!string.IsNullOrEmpty(currentSeed))
        {
            growTime += Time.deltaTime;
        }

        if (growTime > 5)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            if (watered == true)
            {
                switch (currentSeed)
                {
                    case "sunflower":
                        spriteRenderer.sprite = sunFlower2;
                        break;

                    case "carrot":
                        spriteRenderer.sprite = carrot2;
                        break;

                    case "potato":
                        spriteRenderer.sprite = potato2;
                        break;
                }
            }
            else
            {
                spriteRenderer.sprite = noPlantObj;
                currentSeed = null;
                growTime = 0;
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("clicked on weed");
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if (GMScript.currentTool == "scythe")
        {
            spriteRenderer.sprite = noPlantObj;
        }

        if (spriteRenderer.sprite == noPlantObj)
        {
            if (GMScript.currentTool == "sunflower")
            {
                spriteRenderer.sprite = sunFlower1;
                currentSeed = GMScript.currentTool;
            }
            else if (GMScript.currentTool == "carrot")
            {
                spriteRenderer.sprite = carrot1;
                currentSeed = GMScript.currentTool;
            }
            else if (GMScript.currentTool == "potato")
            {
                spriteRenderer.sprite = potato1;
                currentSeed = GMScript.currentTool;
            }
        }

        if (GMScript.currentTool == "bucket")
        {
            plotObj.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
            watered = true;
        }
    }
}
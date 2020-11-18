using Classes;
using Classes.Enums;
using UnityEngine;

public class SeedsInventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var allPlants = GameHandler.Instance.allPlants;

        if (allPlants.Count == 0) return;

        var index = 0;
        var stepX = 0.4f;
        var minX = -(stepX/2) * (allPlants.Count - 1);
        
        foreach (var plant in allPlants)
        {
            var seed = Instantiate(plant, transform);
            var seedSpriteRenderer = seed.GetComponentInChildren<SpriteRenderer>();
            var seedPlantScript = seed.GetComponent<PlantScript>();

            seedSpriteRenderer.sprite = seedPlantScript.grownSprite;
            seedSpriteRenderer.sortingOrder = 1;
            seedSpriteRenderer.sortingLayerName = "UI";

            seed.name = plant.name;
            seed.transform.localPosition = new Vector3(minX + stepX * index, -0.2f);
            seed.transform.localScale = new Vector3(0.2f, 0.2f);
            
            var seedToolsInventory = seed.AddComponent<ToolsInventory>();
            seedToolsInventory.tool = new Tool(seed.name, ToolType.Seeds);
            
            Destroy(seedPlantScript);

            index++;
        }
    }
}

using Classes;
using Classes.Enums;
using Classes.Extensions;
using UnityEngine;

public class SeedsInventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var allPlants = GameManager.Instance.allPlants;

        if (allPlants.Count == 0) return;
        
        var stepX = 0.4f;
        var minX = -(stepX/2) * (allPlants.Count - 1);
        var currentX = minX;
        
        foreach (var plant in allPlants)
        {
            var seed = Instantiate(plant, transform);
            var seedSpriteRenderer = seed.GetComponentInChildren<SpriteRenderer>();
            var seedPlantScript = seed.GetComponent<PlantScript>();
            
            seedSpriteRenderer.sortingOrder = 1;
            seedSpriteRenderer.sortingLayerName = "UI";

            seed.name = plant.name;
            seed.transform.localPosition = new Vector3(currentX, -0.2f);
            seed.transform.localScale = new Vector3(0.2f, 0.2f);
            
            var seedToolsInventory = seed.AddComponent<ToolsInventory>();
            seedToolsInventory.tool = new Tool(seed.name, ToolType.Seeds);
            
            Destroy(seedPlantScript);

            currentX += stepX;
        }
    }
}

using System;
using Classes.Enums;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlotScript : MonoBehaviour
{
    public GameObject currentPlant;

    [Range(0.0f, 100.0f)] 
    public float weedPlantProbability = 50.0f;

    public SpriteRenderer spriteRenderer;
    public Color wateredPlotColor;

    public bool isWatered = false;
    public float currentWateredTime = 0.0f;
    public float wateredTime = 10.0f;
    
    private Color _normalPlotColor;
    
    // Events
    private void Start()
    {
        EventManager.Instance.onLeftClickDown += OnLeftClickDown;
        
        _normalPlotColor = spriteRenderer.color;
        
        var weedPlantChance = Random.Range(0.0f, 100.0f);
        if (weedPlantProbability < weedPlantChance) return;
        Plant(GameManager.Instance.weedPlant);
    }

    private void OnDestroy()
    {
        if (EventManager.Instance == null) return;
        EventManager.Instance.onLeftClickDown -= OnLeftClickDown;
    }

    private void Update()
    {
        if (!isWatered) return;

        spriteRenderer.color = Color.Lerp(wateredPlotColor, _normalPlotColor, currentWateredTime/wateredTime);
        currentWateredTime += Time.deltaTime;
        
        if (currentWateredTime < wateredTime) return;

        isWatered = false;
        spriteRenderer.color = _normalPlotColor;
    }

    private void OnLeftClickDown(Transform hitTransform)
    {
        if (hitTransform != transform) return;
        
        var gh = GameManager.Instance;
        
        if (gh.currentTool.type == ToolType.Watering)
        {
            Water();
            return;
        }
        
        if (gh.currentTool.type != ToolType.Seeds) return;
        
        if (currentPlant != null)
        {
            Debug.Log("There's something planted already!");
            return;
        }
            
        var foundPlant = gh.allPlants.Find(plant => plant.name == gh.currentTool.name);

        if (foundPlant == null)
        {
            Debug.LogWarning("Invalid seed!");
            return;
        }
        
        Plant(foundPlant);
    }
    
    // Custom methods
    private void Plant(GameObject plant)
    {
        currentPlant = Instantiate(plant, transform);
    }
    
    private void Water()
    {
        isWatered = true;
        currentWateredTime = 0.0f;
    }
}
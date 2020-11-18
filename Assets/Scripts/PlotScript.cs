using Classes.Enums;
using Classes.UnityExtensions;
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
    
    private Collider2D _collider2D;
    
    // Events
    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _normalPlotColor = spriteRenderer.color;
        
        var randomFloat = Random.Range(0.0f, 100.0f);

        if (weedPlantProbability >= randomFloat)
        {
            currentPlant = Instantiate(GameHandler.Instance.weedPlant, transform);
        }
    }

    private void Update()
    {
        if (RaycastInput.IsLMBDownColliding(_collider2D))
        {
            UserInput();
        }

        if (!isWatered) return;

        spriteRenderer.color = Color.Lerp(wateredPlotColor, _normalPlotColor, currentWateredTime/wateredTime);
        currentWateredTime += Time.deltaTime;
        
        if (currentWateredTime < wateredTime) return;

        isWatered = false;
        spriteRenderer.color = _normalPlotColor;
    }
    
    // Custom methods
    private void UserInput()
    {
        var gh = GameHandler.Instance;

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
    
        currentPlant = Instantiate(foundPlant, transform);
    }
    
    private void Water()
    {
        isWatered = true;
        currentWateredTime = 0.0f;
    }
}
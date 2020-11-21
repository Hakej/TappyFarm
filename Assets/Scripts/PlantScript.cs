using Classes;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public Plant plant;
    public ParticleSystem particleSystem;
    
    private PlotScript _plotScript;

    private Vector2 _startingScale;
    private Vector2 _grownScale;
        
    private SpriteRenderer _spriteRenderer;
    
    // Events
    private void Start()
    {
        EventManager.Instance.onLeftClickDown += OnLeftClickDown;
        
        _plotScript = GetComponentInParent<PlotScript>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _grownScale = transform.localScale;
        plant.grownSprite = _spriteRenderer.sprite;

        if (plant.isGrown) return;
        
        _spriteRenderer.sprite = plant.growingSprite;
            
        _startingScale = new Vector2(0.0f, 0.0f);
        transform.localScale = _startingScale;
    }

    private void OnDestroy()
    {
        if (EventManager.Instance == null) return;
        EventManager.Instance.onLeftClickDown -= OnLeftClickDown;
    }

    private void Update()
    {
        if (plant.isGrown) return;

        transform.localScale = Vector2.Lerp(_startingScale, _grownScale, plant.currentGrowTime / plant.growTime);
        
        if (!_plotScript.isWatered) return;
        
        plant.currentGrowTime += Time.deltaTime;
        
        if (plant.currentGrowTime < plant.growTime) return;

        Grow();
    }
    
    private void OnLeftClickDown(Transform hitTransform)
    {
        if (hitTransform != transform) return;
        
        if (!plant.isGrown) return;

        if (GameManager.Instance.currentTool.type != plant.gatheringTool) return;
        
        Gather();
    }

    private void Grow()
    {
        plant.isGrown = true;
        _spriteRenderer.sprite = plant.grownSprite;
        particleSystem.Play();
    }
    
    private void Gather()
    {
        Destroy(gameObject);
    }
}
using Classes;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public Plant plant;
    
    private PlotScript _plotScript;

    private Vector2 _currentScale;
    private Vector2 _grownScale;
        
    private SpriteRenderer _spriteRenderer;
    
    // Events
    private void Start()
    {
        EventManager.Instance.onLeftClickDown += OnLeftClickDown;
        
        _plotScript = GetComponentInParent<PlotScript>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        plant.grownSprite = _spriteRenderer.sprite;
        _spriteRenderer.sprite = plant.growingSprite;
        
        _currentScale = new Vector2(0.0f, 0.0f);
        _grownScale = transform.localScale;

        transform.localScale = _currentScale;
    }

    private void OnDestroy()
    {
        if (EventManager.Instance == null) return;
        EventManager.Instance.onLeftClickDown -= OnLeftClickDown;
    }

    private void Update()
    {
        if (plant.isGrown) return;

        transform.localScale = Vector2.Lerp(_currentScale, _grownScale, plant.currentGrowTime / plant.growTime);
        
        if (!_plotScript.isWatered) return;
        
        plant.currentGrowTime += Time.deltaTime;
        
        if (plant.currentGrowTime < plant.growTime) return;

        Grow();
    }
    
    private void OnLeftClickDown(Transform hitTransform)
    {
        if (hitTransform != transform) return;
        
        if (!plant.isGrown) return;
        
        Gather();
    }

    private void Grow()
    {
        plant.isGrown = true;
        _spriteRenderer.sprite = plant.grownSprite;
    }
    
    private void Gather()
    {
        Destroy(gameObject);
    }
}
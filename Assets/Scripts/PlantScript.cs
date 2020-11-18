using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public float growTime = 5.0f;
    public SpriteRenderer spriteRenderer;
    public Sprite grownSprite;
    
    private PlotScript _plotScript;
    
    private bool _isGrown = false;
    private float _currentGrowTime = 0.0f;

    private Vector2 _currentScale;
    private Vector2 _grownScale;
    
    // Events
    private void Start()
    {
        _plotScript = GetComponentInParent<PlotScript>();
        
        _currentScale = new Vector2(0.0f, 0.0f);
        _grownScale = transform.localScale;
    }

    private void Update()
    {
        if (_isGrown) return;

        transform.localScale = Vector2.Lerp(_currentScale, _grownScale, _currentGrowTime / growTime);
        
        if (!_plotScript.isWatered) return;
        
        _currentGrowTime += Time.deltaTime;
        
        if (_currentGrowTime < growTime) return;
        
        Grow();
    }
    
    private void OnMouseDown()
    {
        if (!_isGrown) return;
        
        Gather();
    }


    // Custom methods
    private void Grow()
    {
        _isGrown = true;
        spriteRenderer.sprite = grownSprite;
    }
    
    private void Gather()
    {
        Destroy(gameObject);
    }
}
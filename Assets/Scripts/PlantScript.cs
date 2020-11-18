using Classes.Enums;
using Classes.UnityExtensions;
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

    private Collider2D _collider2D;
    
    // Events
    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _plotScript = GetComponentInParent<PlotScript>();

        _currentScale = new Vector2(0.0f, 0.0f);
        _grownScale = transform.localScale;
        
        transform.localScale = _currentScale;
    }

    private void Update()
    {
        if (_isGrown)
        {
            if (!RaycastInput.IsLMBDownColliding(_collider2D)) return;

            Gather();
            return;
        }

        transform.localScale = Vector2.Lerp(_currentScale, _grownScale, _currentGrowTime / growTime);
        
        if (!_plotScript.isWatered) return;
        
        _currentGrowTime += Time.deltaTime;
        
        if (_currentGrowTime < growTime) return;
        
        Grow();
    }

    // Custom methods
    private void Grow()
    {
        _isGrown = true;
        spriteRenderer.sprite = grownSprite;
    }
    
    private void Gather()
    {
        if (GameHandler.Instance.currentTool.type != ToolType.None) return;
        
        Destroy(gameObject);
    }
}
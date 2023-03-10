using UnityEngine;

public sealed class Cell : GridItem
{
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;
    public bool IsEmpty { get; set; } = true;

    public override GridItem Init(Grid parent, Vector3 gridPosition)
    {
        base.Init(parent, gridPosition);
        spriteRenderer.color = HasOffset()
            ? offsetColor
            : baseColor;
        return this;
    }
    
    /// <summary>
    /// Checks weather the cell has another color.
    /// </summary>
    /// <returns>
    /// <c>true</c> - if element has offset. <br/>
    /// <c>false</c> - otherwise.
    /// </returns>
    private bool HasOffset() 
        => (X % 2 == 0 && Y % 2 != 0) || (X % 2 != 0 && Y % 2 == 0);
    
    private void OnMouseDown()
    {
        Parent.Target = this;
    }
}

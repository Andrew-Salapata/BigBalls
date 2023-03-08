using UnityEngine;

public class Cell : MonoBehaviour
{
    private int _x;
    private int _y;
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public Vector3 Position => new (_x, _y);

    /// <summary>
    /// Set cell's position and defines the color of the cell
    /// between <see cref="baseColor"/> and <see cref="offsetColor"/>.
    /// </summary>
    /// <param name="xPosition">X position of the cell in the grid.</param>
    /// <param name="yPosition">Y position of the cell in the grid.</param>
    /// <returns>Initiated cell.</returns>
    public Cell Init(int xPosition, int yPosition)
    {
        _x = xPosition;
        _y = yPosition;
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
        => (_x % 2 == 0 && _y % 2 != 0) || (_x % 2 != 0 && _y % 2 == 0);
    
    private void OnMouseDown()
    {
        Debug.Log("Mouse Down");
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse Over");
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse Up");
    }
}

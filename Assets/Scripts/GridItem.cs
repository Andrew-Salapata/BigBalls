using UnityEngine;

public abstract class GridItem : MonoBehaviour
{
    public Vector3 position;
    protected Grid Parent;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected int X => (int)position.x;
    protected int Y => (int)position.y;

    public virtual GridItem Init(Grid parent, Vector3 gridPosition)
    {
        Parent = parent;
        position = gridPosition;
        return this;
    }
}
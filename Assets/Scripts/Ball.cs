using Extensions;
using UnityEngine;
using Random = System.Random;

public class Ball : GridItem
{
    private Cell _gridPosition;
    private static readonly Random Random = new ();

    public Cell GridPosition
    {
        get => _gridPosition;
        set
        {
            _gridPosition = value;
            _gridPosition.IsEmpty = false;
        }
    }

    private void OnMouseDown()
    {
        if (IsSmall) return;
        Parent.BallToMove = this;
    }

    public bool IsSmall => transform.localScale.x == 0.5f;

    public override GridItem Init(Grid parent, Vector3 gridPosition)
    {
        base.Init(parent, gridPosition);
        spriteRenderer.color = Random.RandomizeColor();
        transform.localScale = Random.NextDouble() > 0.5f ? new Vector3(1, 1) : new Vector3(0.5f, 0.5f);
        return this;
    }

    //TODO: find optimal path
    public void MoveTo(Cell target)
    {
        transform.position = target.position;
        target.IsEmpty = false;
        GridPosition.IsEmpty = true;
        GridPosition = target; 
    }

    public void Increase()
    {
        transform.localScale = new Vector3(1, 1);
    }
}

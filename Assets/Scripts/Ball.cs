
using System;
using Extensions;
using UnityEngine;
using Random = System.Random;

public class Ball : MonoBehaviour
{
    private static readonly Random Random = new ();

    private Color _previousColor;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        _previousColor = spriteRenderer.color;
        spriteRenderer.color = Color.grey;
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse Over");
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse Up");
        spriteRenderer.color = _previousColor;
    }

    public void Init()
    {
        spriteRenderer.color = Random.RandomizeColor();
    }
}

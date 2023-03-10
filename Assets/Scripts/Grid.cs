using System.Collections.Generic;
using System.Linq;
using Extensions;
using JetBrains.Annotations;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private readonly List<Cell> _freeCells = new ();
    private readonly List<Ball> _smallBalls = new();
    [CanBeNull] private Ball _ballToMove;

    public Ball BallToMove
    {
        set => _ballToMove = value;
    }

    public Cell Target
    {
        set
        {
            if (_ballToMove is null || value.IsEmpty == false) return;
            UpdateCells(_ballToMove.GridPosition, value);
            _ballToMove.MoveTo(value);
            SetDefaults();
            IncreaseBall();
            AddBall();
        }
    }

    private void IncreaseBall()
    {
        foreach (var ball in _smallBalls)
        {
            ball.Increase();
        }
        _smallBalls.Clear();
    }

    private void SetDefaults()
    {
        _ballToMove = null;
    }

    private void UpdateCells(Cell from, Cell to)
    {
        from.IsEmpty = true;
        to.IsEmpty = false;
        _freeCells.Remove(to);
        _freeCells.Add(from);
    }

    /// <summary>
    /// Width of the play grid.
    /// </summary>
    /// <remarks>
    /// Amount of the cells in a horizontal line; <br/>
    /// Default value is 10.
    /// </remarks>
    [SerializeField] private ushort width;

    /// <summary>
    /// Height of the play grid.
    /// </summary>
    /// <remarks>
    /// Amount of the cells in a vertical line;
    /// </remarks>
    [SerializeField] private ushort height;

    [SerializeField] private ushort ballAmount;

    /// <summary>
    /// Cell type source.
    /// </summary>
    [SerializeField] private Cell cellSource;
    [SerializeField] private Ball ballSource;

    /// <summary>
    /// Camara object.
    /// </summary>
    [SerializeField] private Transform cameraSource;
    
    private void Start()
    {
        JustifyGridSize();
        GenerateGrid();
        JustifyCamera();
        GenerateBalls();
    }

    private void GenerateBalls()
    {
        for (var i = 0; i < ballAmount; ++i)
        {
            AddBall(); // TODO: generate only big balls.
        }
    }

    /// <summary>
    /// Changes grid <see cref="width"/> and <see cref="height"/> to default one.
    /// </summary>
    private void JustifyGridSize()
    {
        width = width > 0 ? width : Constants.DefaultGridSize;
        height = height > 0 ? height : Constants.DefaultGridSize;
    }

    /// <summary>
    /// Generates cells to fill grid's <see cref="width"/> and <see cref="height"/>
    /// </summary>
    private void GenerateGrid()
    {
        for (var x = 0; x < width; x++)
        for (var y = 0; y < height; y++)
            _freeCells.Add((Cell)Instantiate(cellSource, new Vector3(x, y),
                Quaternion.identity).Init(this, new Vector3(x, y)));

    }

    /// <summary>
    /// Locates camera on the center of the grid. 
    /// </summary>
    private void JustifyCamera()
        => cameraSource.transform.position = new Vector3(
            width / 2f - Constants.CameraOffset2D,
            height / 2f - Constants.CameraOffset2D,
            Constants.CameraZOffset);

    // TODO: generate random ball (big or small)
    private void AddBall()
    {
        var cell = _freeCells.PopRandom();
        var ball = (Ball)Instantiate(ballSource, cell.position, Quaternion.identity).Init(this, cell.position);
        ball.GridPosition = cell;
        if (ball.IsSmall)
        {
            _smallBalls.Add(ball);
        }
        if (_freeCells.Any()) return;
        Debug.Log("Stop Game"); // TODO: make game finished.
        
    }
}

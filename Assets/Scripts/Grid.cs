using System.Collections.Generic;
using Extensions;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private readonly List<Cell> _freeCells = new ();

    private readonly List<Cell> _usedCells = new ();
    
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
            AddBall();
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
            _freeCells.Add(Instantiate(cellSource, new Vector3(x, y), Quaternion.identity).Init(x, y));

    }

    /// <summary>
    /// Locates camera on the center of the grid. 
    /// </summary>
    private void JustifyCamera()
        => cameraSource.transform.position = new Vector3(
            width / 2f - Constants.CameraOffset2D,
            height / 2f - Constants.CameraOffset2D,
            Constants.CameraZOffset);

    public void AddBall()
    {
        var cell = _freeCells.PopRandom();
        _usedCells.Add(cell);
        Instantiate(ballSource, cell.Position, Quaternion.identity).Init();
    }

}

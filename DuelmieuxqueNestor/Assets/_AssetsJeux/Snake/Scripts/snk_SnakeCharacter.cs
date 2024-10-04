using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class snk_SnakeCharacter : MonoBehaviour
{
    private Vector3 _actualDirection = Vector3.up;
    private Vector3 _wantedDirection = Vector3.up;


    private snk_GameManager gm => snk_GameManager.Instance;

    [Header("References")]
    [SerializeField] private snk_inputs _Inputs;
    [SerializeField] private TileBase SnakeTile;
    [SerializeField] private snk_snakeVisuals Visuals;
    private Queue<Vector2Int> _queue = new Queue<Vector2Int>();


    private void Start()
    {
        snk_GameManager.Instance.OnTick += OnTick;
        _queue.Enqueue((Vector2Int)transform.position.round());
    }

    private void Update()
    {
        //j'aurais pu mettre ça avant move() mais ça aurait été moins responsif
        UpdateWantedDirection();
    }

    private void UpdateWantedDirection()
    {
        Vector2 input = _Inputs.getInputVector();
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) input.y = 0; else input.x = 0;
        if (input != Vector2.zero && input!= -(Vector2)_actualDirection) _wantedDirection = new Vector3(input.x, input.y, 0);
    }

    bool checkForFruit()
    {
        if(gm.GetTileAt((Vector2Int)transform.position.round()) == snk_GameManager.Instance.fruitTile)
        {
            snk_GameManager.Instance.InvokeOnFruitGathered();
            return true;
        }
        return false;
    }

    bool checkForDangerousTile()
    {
        TileBase tile = gm.GetTileAt((Vector2Int)transform.position.round());
        return tile != null && tile != snk_GameManager.Instance.fruitTile;
    }

    private void UpdateQueue(bool extendSnake)
    {
        _queue.Enqueue((Vector2Int)transform.position.round());
        gm.SetTileAt((Vector2Int)transform.position.round(), SnakeTile);
        if(!extendSnake)
        {
            gm.SetTileAt(_queue.Dequeue(), null);
        }
    }


    void Move()
    {
        _actualDirection = _wantedDirection;
        transform.position =(transform.position + _actualDirection).round();
    }

    void OnTick()
    {
        Move();

        //tilemap checks
        bool dead = checkForDangerousTile();
        bool shouldExtendSnake = checkForFruit();

        UpdateQueue(shouldExtendSnake);
        Visuals.Redraw(_queue);

        if (dead)
        {
            print(gm.GetTileAt((Vector2Int)transform.position.round()));
            print("--");
            enabled = false;
        }
    }

}

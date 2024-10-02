using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class snk_SnakeCharacter : MonoBehaviour
{
    private Vector3 _actualDirection;
    private Vector3 _wantedDirection;

    Tilemap tm;
    [SerializeField] TileBase SnakeTile;

    Queue<Vector2Int> queue = new Queue<Vector2Int>();

    private void Start()
    {
        tm=FindObjectOfType<Tilemap>();
        snk_GameManager.Instance.OnTick += OnTick;

        queue.Enqueue((Vector2Int)transform.position.round());
        //tm.SetTile(transform.position.round(), SnakeTile);
    }

    private void Update()
    {
        //j'aurais pu mettre ça avant move() mais ça aurait été moins responsif
        UpdateWantedDirection();
    }

    private void UpdateWantedDirection()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) input.y = 0; else input.x = 0;
        if (input != Vector2.zero && input!= -(Vector2)_actualDirection) _wantedDirection = new Vector3(input.x, input.y, 0);
    }

    bool checkForFruit()
    {
        if( tm.GetTile(transform.position.round()) == snk_GameManager.Instance.fruitTile)
        {
            snk_GameManager.Instance.InvokeOnFruitGathered();
            return true;
        }
        return false;
    }

    bool checkForDangerousTile()
    {
        TileBase tile = tm.GetTile(transform.position.round());
        return tile != null && tile != snk_GameManager.Instance.fruitTile;
    }

    private void UpdateTilemap(bool extendSnake)
    {
        queue.Enqueue((Vector2Int)transform.position.round());
        tm.SetTile(transform.position.round(), SnakeTile);
        if(!extendSnake)
        {
            tm.SetTile((Vector3Int)queue.Dequeue(), null);
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
        bool dead = checkForDangerousTile();
        bool fruit = checkForFruit();
        UpdateTilemap(fruit);

        if(dead)
        {
            print("tmort connard!");
            print(tm.GetTile(transform.position.round()));
            print("--");
            enabled = false;
        }
    }

}

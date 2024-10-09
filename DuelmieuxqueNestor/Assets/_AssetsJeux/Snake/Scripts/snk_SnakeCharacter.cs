using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Snake
{
    public class snk_SnakeCharacter : MonoBehaviour
    {
        private Vector3 _actualDirection = Vector3.up;
        private Vector3 _wantedDirection = Vector3.up;

        private snk_GameManager gm => snk_GameManager.Instance;
        private snk_TilemapHandler tm => snk_TilemapHandler.Instance;

        [Header("References")]
        [SerializeField] private snk_inputs _Inputs;
        [SerializeField] private TileBase SnakeTile;
        [SerializeField] private snk_snakeVisuals Visuals;
        private Queue<Vector2Int> _queue = new Queue<Vector2Int>();

        [Header("Parameters")]
        public PlayerInfo _PlayerInfo;

        private void Start()
        {
            snk_GameManager.Instance.OnTick += OnTick;
            snk_GameManager.Instance.OnGameOver += onGameOver;
            snk_GameManager.Instance.RegisterSnake(this);

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
            if (input != Vector2.zero && input != -(Vector2)_actualDirection) _wantedDirection = new Vector3(input.x, input.y, 0);
        }

        bool checkForFruit()
        {
            if (tm.GetTileAt((Vector2Int)transform.position.round()) == snk_GameManager.Instance.fruitTile)
            {
                snk_GameManager.Instance.InvokeOnFruitGathered();
                return true;
            }
            return false;
        }

        bool checkForDangerousTile()
        {
            TileBase tile = tm.GetTileAt((Vector2Int)transform.position.round());
            return tile != null && tile != snk_GameManager.Instance.fruitTile;
        }

        private void UpdateQueue(bool extendSnake)
        {
            _queue.Enqueue((Vector2Int)transform.position.round());
            tm.SetTileAt((Vector2Int)transform.position.round(), SnakeTile);
            if (!extendSnake)
            {
                tm.SetTileAt(_queue.Dequeue(), null);
            }
        }


        void Move()
        {
            _actualDirection = _wantedDirection;
            transform.position = (transform.position + _actualDirection).round();

            if (Mathf.Abs(transform.position.y) >= 11) transform.position = new Vector2(transform.position.x, -transform.position.y + 1 * Mathf.Sign(transform.position.y));
            if (Mathf.Abs(transform.position.x) >= 19) transform.position = new Vector2(-transform.position.x + 1 * Mathf.Sign(transform.position.x), transform.position.y);
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
                //print(gm.GetTileAt((Vector2Int)transform.position.round()));
                //print("--");
                snk_GameManager.Instance.UnRegisterSnake(this);
            }
        }

        void onGameOver(PlayerInfo winner)
        {
            if (this._PlayerInfo != winner)
            {
                destroyBody();
            }
        }

        async void destroyBody()
        {
            while (_queue.Count > 0)
            {
                tm.SetTileAt(_queue.Dequeue(), null);
                Visuals.Redraw(_queue);
                await Task.Delay(150);
            }
        }

    }

    [Serializable]
    public class PlayerInfo
    {
        public Color color;
        public string name;
    }
}


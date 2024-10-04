using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class snk_GameManager : MonoBehaviour
{

    [HideInInspector] public List<Vector2Int> freeTiles = new List<Vector2Int>();
    
    //game loop
    private float _frequency = 5;
    private Coroutine _gameLoopCoroutine;

    //singleton
    public static snk_GameManager Instance { get; private set; }
    
    //events
    public event Action OnTick;
    public event Action OnFruitGathered;
    public event Action<PlayerInfo> OnGameOver;


    public TileBase fruitTile;
    [Header("References")]
    [SerializeField] private Tilemap _tilemap;

    [Header("Parameters")]
    [SerializeField] private int fruitCount = 3;


    //Tilemap
    public void RemoveTileAt(Vector2Int pose)
    {
        _tilemap.SetTile((Vector3Int)pose, null);
        freeTiles.Add(pose);
    }

    public void SetTileAt(Vector2Int pose,TileBase tile)
    {
        _tilemap.SetTile((Vector3Int)pose,tile);
        freeTiles.Remove(pose);
    }

    public TileBase GetTileAt(Vector2Int pose)
    {
        return _tilemap.GetTile((Vector3Int)pose);
    }


    void CheckForFreeTiles()
    {
        freeTiles.Clear();
        for(int x = -17; x <= 17; x++) //au secours
        {
            for (int y = -9; y <= 9; y++)
            {
                Debug.DrawRay(new Vector3Int(x, y), Vector3.up*0.5f, Color.red, 1);
                if (_tilemap.GetTile(new Vector3Int(x, y))==null) freeTiles.Add(new Vector2Int(x, y));
            }
        }
    }

    //game manager
    void Awake()
    {
        //singleton
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        CheckForFreeTiles();
    }

    private void Start()
    {
        _gameLoopCoroutine = StartCoroutine(Loop());
        for (int i = 0; i < fruitCount; i++) spawnNewFruit();
    }

    public void InvokeOnFruitGathered()
    {
        OnFruitGathered?.Invoke();
        _frequency += 0.3f;
        spawnNewFruit();
    }

    private void spawnNewFruit()
    {
        SetTileAt(freeTiles[UnityEngine.Random.Range(0, freeTiles.Count-1)],fruitTile);
    }

    private IEnumerator Loop()
    {
        while(enabled)
        {
            yield return new WaitForSeconds(1f/ _frequency);
            OnTick?.Invoke();
        }
    }

    public void triggerGameOver(PlayerInfo WinerPlayerInfo)
    {
        StopCoroutine(_gameLoopCoroutine);
        OnGameOver?.Invoke(WinerPlayerInfo);
    }

}

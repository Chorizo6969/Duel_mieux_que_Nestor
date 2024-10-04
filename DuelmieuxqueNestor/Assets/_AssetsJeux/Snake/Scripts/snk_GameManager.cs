using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class snk_GameManager : MonoBehaviour
{

    public List<Vector2Int> freeTiles = new List<Vector2Int>();
    private float _frequency = 5;

    //singleton
    public static snk_GameManager Instance { get; private set; }
    
    //events
    public event Action OnTick;
    public event Action OnFruitGathered;


    public TileBase fruitTile;
    [Header("Refrences")]
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
        for(int x = 0; x < 10; x++) //au secours
        {
            for (int y = 0; y < 10; y++)
            {
                if(_tilemap.GetTile(new Vector3Int(x, y))==null) freeTiles.Add(new Vector2Int(x, y));
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

    public void InvokeOnFruitGathered()
    {
        OnFruitGathered?.Invoke();
        _frequency += 0.3f;
        spawnNewFruit();
    }

    private void spawnNewFruit()
    {
        SetTileAt(freeTiles[UnityEngine.Random.Range(0, freeTiles.Count)],fruitTile);
    }

    private void Start()
    {
        StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        while(enabled)
        {
            yield return new WaitForSeconds(1f/ _frequency);
            OnTick?.Invoke();
        }
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class snk_GameManager : MonoBehaviour
{
    public static snk_GameManager Instance { get; private set; }
    public event Action OnTick;
    public event Action OnFruitGathered;

    public TileBase fruitTile;


    private float _frequency=5;

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
    }

    public void InvokeOnFruitGathered()
    {
        OnFruitGathered?.Invoke();
        _frequency += 0.5f;
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

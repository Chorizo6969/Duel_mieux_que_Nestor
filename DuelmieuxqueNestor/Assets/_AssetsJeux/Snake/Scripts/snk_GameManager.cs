using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snk_GameManager : MonoBehaviour
{
    public static snk_GameManager Instance { get; private set; }
    public event Action OnTick;

    Coroutine _mainLoop;

    private float _frequency=3;

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

    private void Start()
    {
        _mainLoop = StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        while(enabled)
        {
            yield return new WaitForSeconds(1f/ _frequency);
            OnTick.Invoke();
        }
    }
}

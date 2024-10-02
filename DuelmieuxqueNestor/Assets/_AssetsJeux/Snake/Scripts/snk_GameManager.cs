using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snk_GameManager : MonoBehaviour
{
    private snk_GameManager _instance;
    public snk_GameManager Instance => _instance;
    public Event OnTick;

    Coroutine _mainLoop;

    private float Frequency;

    void Awake()
    {
        //singleton
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
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
            yield return new WaitForSeconds(1);
           
        }
    }
}

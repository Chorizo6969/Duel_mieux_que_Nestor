using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snk_GameManager : MonoBehaviour
{
    private snk_GameManager _instance;
    public snk_GameManager Instance => _instance;
    public Event OnTick;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}

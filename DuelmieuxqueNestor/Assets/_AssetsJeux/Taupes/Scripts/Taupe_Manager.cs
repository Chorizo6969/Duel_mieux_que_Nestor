using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Taupe_Manager : MonoBehaviour
{
    [SerializeField] private List<GameObject> TaupePrefabslist = new List<GameObject>();

    public static Taupe_Manager instance { get;private set; }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void respawnTaupe()
    {
        StartCoroutine(SpawnTaupe());
    }

    IEnumerator SpawnTaupe()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        int TaupeIndex = Random.Range(0, 4);
        Instantiate(TaupePrefabslist[TaupeIndex]);
    }

}

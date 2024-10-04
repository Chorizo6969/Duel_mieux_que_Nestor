using System.Collections;
using UnityEngine;

/// <summary>
/// Script qui gère les plateformes fragiles
/// </summary>
public class Destroy : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(platform);
    }
}

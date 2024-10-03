using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            return;
        }
        Destroy(collision.gameObject);
    }
}

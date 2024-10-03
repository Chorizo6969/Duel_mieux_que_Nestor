using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public bool droite = true;
    private float speed = 2;

    private void Update()
    {
        if (droite)
        {
            gameObject.transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (droite)
            {
                droite = false;
            }
            else
            {
                droite = true;
            }
        }
    }
}

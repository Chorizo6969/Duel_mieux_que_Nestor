using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    [SerializeField]
    private GameObject _papa;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _papa.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Mathf.Sign(collision.transform.position.x - transform.position.x) * 2, ForceMode2D.Impulse);
        }
    }
}

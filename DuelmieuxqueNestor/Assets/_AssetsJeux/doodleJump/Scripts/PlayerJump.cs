using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private GameObject _papa;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Platform")
        {
            _papa.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            _papa.GetComponent<Rigidbody2D>().AddForce(transform.up * 425);
        }
    }
}

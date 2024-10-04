using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private GameObject _papa;

    private GameObject brockenplatform;
    private Vector2 actualpos;
    private Vector2 oldpos;

    private void Start()
    {
        actualpos = Vector2.zero;
        oldpos = Vector2.zero;
    }

    private void Update()
    {
        oldpos = _papa.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        actualpos = _papa.transform.position;
        if (actualpos.y <= oldpos.y)
        {
            if (collision.gameObject.tag == "Platform")
            {
                _papa.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                _papa.GetComponent<Rigidbody2D>().AddForce(transform.up * 425);
            }
            if (collision.gameObject.layer == 8)
            {
                brockenplatform = collision.gameObject;
                _papa.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                _papa.GetComponent<Rigidbody2D>().AddForce(transform.up * 425);
                StartCoroutine(Delay());
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(brockenplatform);
    }
}

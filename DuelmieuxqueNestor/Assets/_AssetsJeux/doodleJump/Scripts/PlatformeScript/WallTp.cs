using UnityEngine;

public class WallTp : MonoBehaviour
{
    [SerializeField]
    private Transform destination;
    [SerializeField]
    private bool _canTp = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && _canTp)
        {
            destination.GetComponent<WallTp>()._canTp = false;
            collision.transform.position = new Vector2(destination.transform.position.x, collision.transform.position.y);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _canTp = true;
        }
    }
}

using UnityEngine;

public class BH_PlayerMovement_1 : MonoBehaviour
{
    public float speed = 10f;

    public string Nb_Player;

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        rb.velocity = new Vector2(moveX, moveY) * speed;
    }

    public void OnDeathPlayer()
    {
        Destroy(gameObject);
    }
}

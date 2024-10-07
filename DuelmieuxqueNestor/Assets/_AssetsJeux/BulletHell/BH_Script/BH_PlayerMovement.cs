using UnityEngine;

public class BH_PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    public bool IsPlayer1;

    public Rigidbody2D rb;

    Vector2 vel;
    [SerializeField] 
    float smoothTime;

    [SerializeField]
    BH_PlayerManager playermanager;

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (IsPlayer1)
        {
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

            Vector2 a = Vector2.zero;
            vel = Vector2.SmoothDamp(vel, new Vector2(moveX, moveY) * speed, ref a, smoothTime);

            rb.velocity = vel;
        }

        else if (!IsPlayer1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveY = 1f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moveY = -1f;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveX = 1f;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveX = -1f;
            }
            Vector2 a = Vector2.zero;
            vel = Vector2.SmoothDamp(vel, new Vector2(moveX, moveY) * speed, ref a, smoothTime);

            rb.velocity = vel;
        }
    }

    public void OnDeathPlayer()
    {
        playermanager.Whodied();
        Destroy(gameObject);
    }
}

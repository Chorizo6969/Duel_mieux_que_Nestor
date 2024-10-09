using System.Collections;
using UnityEngine;

public class BH_Bullet : MonoBehaviour
{
    private BH_BulletManager bulletManager;

    private void Start()
    {
        bulletManager = FindAnyObjectByType<BH_BulletManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            var Player =  collision.gameObject.GetComponent<BH_PlayerMovement>();
            Player.OnDeathPlayer();

        }
        
        if (collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }
}

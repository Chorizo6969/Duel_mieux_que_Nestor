using System.Collections;
using UnityEngine;

public class BH_Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BH_Player_1")
        {
            var Player =  collision.gameObject.GetComponent<BH_PlayerMovement_1>();
            Player.OnDeathPlayer();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BH_Player_2")
        {
            var Player = collision.gameObject.GetComponent<BH_PlayerMovement_2>();
            Player.OnDeathPlayer();
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "BH_Wall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BH_Bullet")
        {
            StartCoroutine(CollisionBullet(collision));          
        }
    }

    private IEnumerator CollisionBullet(Collision2D collision2D)
    {
        collision2D.collider.isTrigger = true;
        yield return new WaitForSeconds(1);
        collision2D.collider.isTrigger = false;

    }
}

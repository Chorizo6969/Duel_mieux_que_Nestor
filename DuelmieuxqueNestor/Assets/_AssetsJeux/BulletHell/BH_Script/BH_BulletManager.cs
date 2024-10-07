using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BH_BulletManager : MonoBehaviour
{
    public List<GameObject> PoolBullet = new List<GameObject>();

    public void AddOnList(GameObject Bullet)
    {
        Bullet.SetActive(false);
        PoolBullet.Add(Bullet);
    }
}

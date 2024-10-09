using System.Collections;
using UnityEngine;

public class BH_BulletInstancier : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform ShootGizmo;
    public float BulletSpeed = 8f;
    public float RotationSpeed = 20f;
    public float CurrentAngle = 0f;
    public float MinAngle = 0f;
    public float MaxAngle = 45f;
    private bool _rotation = true;

    [SerializeField]
    private BH_BulletManager bulletManager;

    private bool Isplaying;



    void Update()
    {
        if (Isplaying == true)
        {
            Rotation();
        }       
    }
    public void StartCanon()
    {
        StartCoroutine(ShootBullet());   
        CurrentAngle = Random.Range(MinAngle, MaxAngle);
        Isplaying = true;
    }

    public void StopCanon()
    {
        Isplaying = false;
        StopAllCoroutines();
    }

    void Rotation()
    {
        float rotationDelta = RotationSpeed * Time.deltaTime;

        if (_rotation)
        {
            CurrentAngle += rotationDelta;
            if (CurrentAngle >= MaxAngle)
            {
                CurrentAngle = MaxAngle;
                _rotation = false;
            }
        }
        else
        {
            CurrentAngle -= rotationDelta;
            if (CurrentAngle <= MinAngle)
            {
                CurrentAngle = MinAngle;
                _rotation = true;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, CurrentAngle);
    }

    private IEnumerator ShootBullet()
    {
        yield return new WaitForSeconds(0.40f);
        GameObject Bullet = Instantiate(BulletPrefab, ShootGizmo.position, ShootGizmo.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.velocity = ShootGizmo.right * BulletSpeed;
        
        StartCoroutine(ShootBullet());
    } 
}

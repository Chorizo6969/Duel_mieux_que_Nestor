using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camscroll : MonoBehaviour
{
    private bool canstart = false;

    [SerializeField]
    private float speedCam = 1;
    [SerializeField]
    private float DelayBeforeStart = 3;

    public Bounds cameraLimits;

    private void Start()
    {
        StartCoroutine(Delay());
    }

    private void Update()
    {
        if (canstart)
        {
            gameObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speedCam);
        }
        cameraLimits.center = transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(cameraLimits.center, cameraLimits.size);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(DelayBeforeStart);
        canstart = true;
    }
}

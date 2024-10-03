using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurePlatform : MonoBehaviour
{
    private PlatformSpawn _platformSpawn;

    [SerializeField]
    private Transform left;

    [SerializeField]
    private Transform right;

    [SerializeField]
    private GameObject PlateformePrefab;

    private void Start()
    {
        StartCoroutine(SafePlateform());
    }

    IEnumerator SafePlateform()
    {
        while (true)
        {
            yield return new WaitForSeconds(300);

            GameObject plateformright = Instantiate(PlateformePrefab);
            plateformright.transform.position = right.transform.position;

            GameObject plateformleft = Instantiate(PlateformePrefab);
            plateformleft.transform.position = left.transform.position;
        }
    }
}

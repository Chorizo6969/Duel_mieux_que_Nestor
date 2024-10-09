using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class utils : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(.5f, 1.5f));
            Destroy( FindAnyObjectByType<GameObject>());
        }
    }

}

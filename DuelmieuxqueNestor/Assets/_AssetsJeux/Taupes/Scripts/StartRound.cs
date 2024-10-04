using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartRound : MonoBehaviour
{
    public Text StartText;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        for (int i = 3; i >0; i--)
        {
            StartText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        Destroy(StartText.gameObject);

        Taupe_Manager.instance.respawnTaupe();

    }

}

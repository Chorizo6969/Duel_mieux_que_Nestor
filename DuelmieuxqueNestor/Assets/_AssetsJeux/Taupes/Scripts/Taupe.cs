using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Taupe : MonoBehaviour
{

    [SerializeField] private KeyCode InputJoueur1;
    [SerializeField] private KeyCode InputJoueur2;

    // Update is called once per frame
    void Update()
    {

       if (Input.GetKeyDown(InputJoueur2)|| Input.GetKeyDown(InputJoueur1))
        {
            Destroy(gameObject);
            UIManager.instance.AddScore(Input.GetKeyDown(InputJoueur1));

            Taupe_Manager.instance.respawnTaupe();
       }
    }
}

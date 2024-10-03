using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float PlayerSpeed;

    [SerializeField]
    private Camscroll _camscroll;

    [SerializeField]
    private bool _joueur1;

    private void Update()
    {
        if (_joueur1) //Joueur 1
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(1, 0, 0) * PlayerSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-1, 0, 0) * PlayerSpeed * Time.deltaTime);
            }
        }
        else //Joueur 2
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(1, 0, 0) * PlayerSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-1, 0, 0) * PlayerSpeed * Time.deltaTime);
            }
        }

        transform.position = _camscroll.cameraLimits.ClosestPoint(transform.position); //Mur du jeu
    }
}

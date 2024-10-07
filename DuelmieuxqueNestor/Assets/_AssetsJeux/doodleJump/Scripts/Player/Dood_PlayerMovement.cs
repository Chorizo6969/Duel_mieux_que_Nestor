using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/// <summary>
/// Script qui gère les déplacements des 2 joueurs
/// </summary>
public class Dood_PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed;

    [SerializeField]
    private Dood_Camscroll _camscroll; //liens vers le script camScroll

    [SerializeField]
    private bool _joueur1; //Pour pouvoir différencier depuis l'inspecteur qui est joueur 1

    private void Update()
    {

        //Debug.Log(_rb.velocity.x);

        if (_joueur1) //Joueur 1
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(1, 0, 0) * _playerSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-1, 0, 0) * _playerSpeed * Time.deltaTime);
            }
        }
        else //Joueur 2
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(1, 0, 0) * _playerSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-1, 0, 0) * _playerSpeed * Time.deltaTime);
            }
        }

        transform.position = _camscroll.CameraLimits.ClosestPoint(transform.position); //On empêche le joueur de sortir des limites du jeu.
    }
}

using UnityEngine;

/// <summary>
/// Script qui gère le comportement des plateformes qui bouge.
/// </summary>
public class Dood_PlatformMove : MonoBehaviour
{
    private bool RightDirection = true; //La plateforme commence par aller vers la droite
    private float _speed = 2;

    private void Update()
    {
        if (RightDirection)
        {
            gameObject.transform.Translate(new Vector3(1, 0, 0) * _speed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.Translate(new Vector3(-1, 0, 0) * _speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Fonction qui vérifie si la plateforme à atteint une des 2 extrémités de son mouvement
    /// </summary>
    /// <param name="collision"> le joueur ou les murs maximum </param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            if (RightDirection)
            {
                RightDirection = false;
            }
            else
            {
                RightDirection = true;
            }
        }
    }
}

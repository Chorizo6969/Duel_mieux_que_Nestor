using UnityEngine;

/// <summary>
/// Script qui gère le comportement des murs du jeu (Si le joueur touche un mur, il doit garder la même pos en y mais de l'autre côté du mur)
/// </summary>
public class Dood_WallTp : MonoBehaviour
{
    [SerializeField]
    private Transform _destination;
    [SerializeField]
    private bool _canTp = true;

    /// <summary>
    /// Fonction qui tp le joueur à l'autre mur
    /// </summary>
    /// <param name="collision"> le Player </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && _canTp)
        {
            _destination.GetComponent<Dood_WallTp>()._canTp = false; //On empêche le joueur de pouvoir se retéléporté tant qu'il est dans le mur
            collision.transform.position = new Vector2(_destination.transform.position.x, collision.transform.position.y);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _canTp = true; //Si il viens de sortir du mur il peut se re tp dans celui-ci
        }
    }
}

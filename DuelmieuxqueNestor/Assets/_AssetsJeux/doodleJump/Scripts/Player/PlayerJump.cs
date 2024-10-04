using System.Collections;
using UnityEngine;

/// <summary>
/// Script qui gère le système de saut du joueur
/// </summary>
public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private GameObject _papa; //Le GameObject player

    private GameObject brockenplatform;

    private Vector2 actualpos;
    private Vector2 oldpos;


    private void Start()
    {
        actualpos = Vector2.zero; //Initialisation des valeurs
        oldpos = Vector2.zero;
    }

    private void Update()
    {
        oldpos = _papa.transform.position; //A chaque frames on update la pos du joueur
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        actualpos = _papa.transform.position; // Au moment ou le joueur touche une plateforme, on va comparé les 2 position calculé
        if (actualpos.y <= oldpos.y) // Si La position calculé à chaque frame est plus grande que la position lors du contact avec la plateforme, alors le personnage tombe
        {
            if (collision.gameObject.layer == 7 || collision.gameObject.layer == 9)
            {
                _papa.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                _papa.GetComponent<Rigidbody2D>().AddForce(transform.up * 425);
            }
            if (collision.gameObject.layer == 8)
            {
                brockenplatform = collision.gameObject;
                _papa.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                _papa.GetComponent<Rigidbody2D>().AddForce(transform.up * 425);
                StartCoroutine(Delay());
            }
        }
    }

    /// <summary>
    /// Coroutine qui gère la destruction de la plateforme fragile après un laps de temps
    /// </summary>
    /// <returns></returns>
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(brockenplatform);
    }
}

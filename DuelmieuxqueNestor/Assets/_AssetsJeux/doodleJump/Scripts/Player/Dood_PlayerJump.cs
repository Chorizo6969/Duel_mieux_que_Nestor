using System.Collections;
using UnityEngine;

/// <summary>
/// Script qui gère le système de saut du joueur
/// </summary>
public class Dood_PlayerJump : MonoBehaviour
{
    [SerializeField]
    private GameObject _papa; //Le GameObject player

    private GameObject _brockenPlatform;

    private Vector2 _actualPos;
    private Vector2 _oldPos;


    private void Start()
    {
        _actualPos = Vector2.zero; //Initialisation des valeurs
        _oldPos = Vector2.zero;
    }

    private void Update()
    {
        _oldPos = _papa.transform.position; //A chaque frames on update la pos du joueur
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _actualPos = _papa.transform.position; // Au moment ou le joueur touche une plateforme, on va comparé les 2 position calculé
        if (_actualPos.y <= _oldPos.y) // Si La position calculé à chaque frame est plus grande que la position lors du contact avec la plateforme, alors le personnage tombe
        {
            if (collision.gameObject.layer == 6)
            {
                /*if (_papa.GetComponent<Rigidbody2D>().velocity.x < 0)
                {
                    _papa.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    _papa.GetComponent<Rigidbody2D>().AddForce(transform.right * 425);
                }
                else
                {
                    _papa.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    _papa.GetComponent<Rigidbody2D>().AddForce(transform.right * -425);
                }*/
            }
            if (collision.gameObject.layer == 7 || collision.gameObject.layer == 9)
            {
                _papa.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                _papa.GetComponent<Rigidbody2D>().AddForce(transform.up * 425);
            }
            if (collision.gameObject.layer == 8)
            {
                _brockenPlatform = collision.gameObject;
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
        yield return new WaitForSeconds(0.5f);
        Destroy(_brockenPlatform);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scrit qui g�re la zone qui d�truit les plateformes petit � petit
/// </summary>
public class Dood_CleanLevel : MonoBehaviour
{
    private bool _canRestart;

    private void Start()
    {
        _canRestart = false;
        Time.timeScale = 1;
    }

    /// <summary>
    /// Fonction qui d�truit tput ce qui rentre dans la zone
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.layer == 6) //Si c'est 1 joueur...
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false; //on emp�che une �galit�
            collision.GetComponent<Dood_PartyResults>().Death(); //On active les �v�nement li�s � la mort d'un joueur
            _canRestart = true; //On autorise le restart
            Time.timeScale = 0; //pause
        }
    }

    private void Update()
    {
        if (_canRestart)
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("Doodle_Jump");
                Time.timeScale = 1;
            }
        }
    }
}

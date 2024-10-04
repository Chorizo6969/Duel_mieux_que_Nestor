using UnityEngine;
using UnityEngine.SceneManagement;

public class CleanLevel : MonoBehaviour
{
    private bool _canRestart;

    private void Start()
    {
        _canRestart = false;
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.layer == 6)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.GetComponent<PartyResults>().Death();
            _canRestart = true;
            Time.timeScale = 0;
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

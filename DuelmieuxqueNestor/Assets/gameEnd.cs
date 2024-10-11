using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Snake
{
    public class gameEnd : MonoBehaviour
    {
        [SerializeField] string s;
        TMP_Text text;

        Coroutine c;
        // Start is called before the first frame update
        void Start()
        {
            TryGetComponent<TMP_Text>(out text);
            text.text = "";
            snk_GameManager.Instance.OnGameOver += cligne;
        }

        void cligne(PlayerInfo winner)
        {
            c = StartCoroutine(clignotter());
        }

        private void OnDestroy()
        {
            StopCoroutine(c);
        }

        IEnumerator clignotter()
        {
            while (true)
            {
                text.text = s;
                yield return new WaitForSeconds(.5f);
                text.text = "";
                yield return new WaitForSeconds(.5f);

            }
        }

    }
}
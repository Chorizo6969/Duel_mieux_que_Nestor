using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Dood_StartGame : MonoBehaviour
{
    private List<string> _TimeBeforeStart = new List<string>() { "3","2","1","GO"};

    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private GameObject _player1;
    [SerializeField] 
    private GameObject _player2;
    [SerializeField]
    private GameObject _canvas;
    [SerializeField]
    private GameObject _canvas2;

    private void Start()
    {
        _player1.GetComponent<Rigidbody2D>().gravityScale = 0;
        _player1.GetComponent<Dood_PlayerMovement>().enabled = false;
        _player2.GetComponent<Dood_PlayerMovement>().enabled = false;
        _player2.GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(UpdateText());
    }

    IEnumerator UpdateText()
    {
        while (_TimeBeforeStart.Count != 0)
        {
            _text.text = _TimeBeforeStart[0].ToString();
            yield return new WaitForSeconds(0.5f);
            _TimeBeforeStart.RemoveAt(0);
        }
        _text.text = "";
        _player1.GetComponent<Rigidbody2D>().gravityScale = 2;
        _player2.GetComponent<Rigidbody2D>().gravityScale = 2;
        _player1.GetComponent<Dood_PlayerMovement>().enabled = true;
        _player2.GetComponent<Dood_PlayerMovement>().enabled = true;
        yield return new WaitForSeconds(4);
        Destroy(_canvas);
        Destroy(_canvas2);
    }
}

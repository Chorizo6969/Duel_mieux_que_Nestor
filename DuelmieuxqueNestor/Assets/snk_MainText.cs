using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Snake
{
    public class snk_MainText : MonoBehaviour
    {
        TMP_Text txt;

        private void Awake()
        {
            txt = GetComponent<TMP_Text>();
        }
        private void Start()
        {
            txt.text = "";
            snk_GameManager.Instance.OnGameOver += onGameOver;
        }

        public void setText(string newText)
        {
            txt.text = newText;
        }

        void onGameOver(PlayerInfo winner)
        {
            txt.text = winner.name + " Wins !";
        }
    }


}
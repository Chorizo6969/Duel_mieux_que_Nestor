using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text ScoreText;
    public Text ScoreTextJ2;
    private int Score;
    private int ScoreJ2;
    public Text VictoryText;
    [SerializeField] private GameObject RestartButton;
    [SerializeField] private GameObject MenuButton;
    [SerializeField] private GameObject BG;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        VictoryText.enabled = false;
        ScoreTextJ2.text = "Joueur 2 : " + 0;
        ScoreText.text = "Joueur 1 : " + 0;
    }

    // Update is called once per frame
    void CheckVictory()
    {
        if (Score == 5)
        {
            VictoryText.text = "Victoire Joueur 1 !";
        }

        else if (ScoreJ2 == 5)
        {
            VictoryText.text = "Victoire Joueur 2 !";
        }
        else return;

        VictoryText.enabled = true;
        RestartMenuButton();
    }

    public void AddScore(bool j1 = false)
    {

        if (j1)
        {
            Score += 1;
            ScoreText.text = "Joueur 1 : " + Score.ToString();
        }

        else
        {
            ScoreJ2 += 1;
            ScoreTextJ2.text = "Joueur 2 : " + ScoreJ2.ToString();
        }

        CheckVictory();
    }

    public void RestartMenuButton()
    {
        Time.timeScale = 0;
        RestartButton.SetActive(true);
        MenuButton.SetActive(true);
        BG.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Joshua");
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Joshua");
    }
}

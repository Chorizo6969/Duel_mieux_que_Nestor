using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BH_PlayerManager : MonoBehaviour
{
    public List<GameObject> PlayerList;

    public TextMeshProUGUI Countdown;
    [SerializeField]
    float RemainingTime;
    bool countdownisfinish;

    [SerializeField]
    List<BH_BulletInstancier> BulletInstanciers;

    public TextMeshProUGUI TextFinish;

    private void Start()
    {
        Time.timeScale = 1.0f; 
    }

    private void Update()
    {
        if (!countdownisfinish)
        {
            if (RemainingTime <= 0f)
            {
                Countdown.gameObject.SetActive(false);
                foreach (var x in BulletInstanciers)
                {
                    x.StartCanon();
                }
                countdownisfinish = true;
            }
            else
            {
                RemainingTime -= Time.deltaTime;
                int seconds = Mathf.FloorToInt(RemainingTime % 60);
                Countdown.text = seconds.ToString();
            }
        }
    }

    public void Whodied()
    {
        if (PlayerList == null)
        {
            foreach (var x in BulletInstanciers)
            {
                x.StopCanon();
            }

            TextFinish.gameObject.SetActive(true);
            TextFinish.text = "Match Nul";
        }
        else if (PlayerList.Count == 1)
        {
            foreach (var x in BulletInstanciers)
            {
                x.StopCanon();
            }

            TextFinish.gameObject.SetActive(true);
            TextFinish.text = PlayerList[0].name + " a gagné";
        }
    }
}

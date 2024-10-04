using TMPro;
using UnityEngine;

public class PartyResults : MonoBehaviour
{
    [SerializeField]
    private string victoryText;
    [SerializeField]
    private TextMeshProUGUI afficheText;



    private void Start()
    {
        afficheText.gameObject.SetActive(false);
        afficheText.text = victoryText.ToString();
    }
    public void Death()
    {
        afficheText.gameObject.SetActive(true);
    }
}

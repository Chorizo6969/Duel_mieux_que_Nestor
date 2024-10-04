using TMPro;
using UnityEngine;

/// <summary>
/// Script qui gère le résultat de la partie à la mort du joueur
/// </summary>
public class Dood_PartyResults : MonoBehaviour
{
    [SerializeField]
    private string _victoryText;
    [SerializeField]
    private TextMeshProUGUI _afficheText;


    private void Start()
    {
        _afficheText.gameObject.SetActive(false);
        _afficheText.text = _victoryText.ToString();
    }

    public void Death()
    {
        _afficheText.gameObject.SetActive(true); //Affichage du texte pour connaître le résultat.
    }
}

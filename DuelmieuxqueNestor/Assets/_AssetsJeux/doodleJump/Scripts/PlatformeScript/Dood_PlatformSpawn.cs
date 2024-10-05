using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script qui gère l'apparition des plateformes dans le jeu (la vitesse ainsi que l'origine)
/// </summary>
public class Dood_PlatformSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _spawnList; // Nombre de point d'apparition possible
    [SerializeField]
    private GameObject _plateformePrefab;
    [SerializeField]
    private GameObject _plateformePrefabBrocken;
    [SerializeField]
    private GameObject _plateformePrefabMove;

    private float _spawnSpeed = 0.7f; // vitesse d'apparition des plateformes
    private int _numberBeforeBrockenpPlatform = 0;
    private int _numberBeforeMovePlateform = 0;

    private void Start()
    {
        StartCoroutine(PlateformPrefab());
    }

    /// <summary>
    /// Coroutine qui Instancie les plateformes de façon aléatoire selon des points d'apparition ainsi que 3 préfab différents
    /// </summary>
    /// <returns>Retourne un délai d'attente entre les apparition de pla</returns>
    IEnumerator PlateformPrefab()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnSpeed);
            int index = Random.Range(0, _spawnList.Count); //On choisit un endroit pour faire apparaitre la futur plateforme
            _numberBeforeBrockenpPlatform = Random.Range(0, 5);
            _numberBeforeMovePlateform = Random.Range(0, 5);
            if (_numberBeforeMovePlateform == 0)
            {
                _numberBeforeBrockenpPlatform--;
                GameObject plateform = Instantiate(_plateformePrefabMove);
                plateform.transform.position = new Vector3(0, _spawnList[index].transform.position.y, _spawnList[index].transform.position.z); //On centre la plateforme mouvante pour éviter divers problème de centrage de platforme
            }
            else if (_numberBeforeBrockenpPlatform == 0)
            {
                _numberBeforeMovePlateform--;
                GameObject plateform = Instantiate(_plateformePrefabBrocken);
                plateform.transform.position = _spawnList[index].transform.position;
            }
            else
            {
                GameObject plateform = Instantiate(_plateformePrefab);
                plateform.transform.position = _spawnList[index].transform.position;
            }
        }

    }

    /// <summary>
    /// Coroutine qui augmente la vitesse de spawn des plateformes ( car le jeu tourne de + en + vite)
    /// </summary>
    /// <returns> Retourne un délai d'attente de 7 secondes (en lien avec le script camscroll) </returns>
    IEnumerator SpeedSpawnUp() //Ou alors Time scale * 2 ?
    {
        yield return new WaitForSeconds(7);
        _spawnSpeed += 0.25f;
    }
}

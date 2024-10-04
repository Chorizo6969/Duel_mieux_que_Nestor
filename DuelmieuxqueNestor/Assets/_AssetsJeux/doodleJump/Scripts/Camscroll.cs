using System.Collections;
using UnityEngine;

/// <summary>
/// Script qqui gère le scroll de la caméra (ainsi que les limites du terrain de jeu
/// </summary>
public class Camscroll : MonoBehaviour
{
    private bool canstart = false;

    [SerializeField]
    private float _speedCam;
    [SerializeField]
    private float _delayBeforeStart = 3; //Délai avant de commencer le scroll de la caméra

    public Bounds CameraLimits;

    private void Start()
    {
        StartCoroutine(Delay());
        StartCoroutine(SpeedUp());
    }

    private void Update()
    {
        if (canstart)
        {
            gameObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * _speedCam);
        }
        CameraLimits.center = transform.position;
    }

    /// <summary>
    /// Fonction pour montre visuelement les limites du terrain de jeu sur la scene
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(CameraLimits.center, CameraLimits.size);
    }

    /// <summary>
    /// Coroutine qui lance un délai avant de commencer le scroll de la cam
    /// </summary>
    /// <returns></returns>
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delayBeforeStart);
        canstart = true;
    }

    /// <summary>
    /// Coroutine pour accélérer la vitesse du scroll
    /// </summary>
    /// <returns></returns>
    IEnumerator SpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(7);
            _speedCam += 0.25f;
        }
    }
}

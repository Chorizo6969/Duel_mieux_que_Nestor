using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> spawnList;
    [SerializeField]
    private GameObject PlateformePrefab;
    [SerializeField]
    private GameObject PlateformePrefabBrocken;
    [SerializeField]
    private GameObject PlateformePrefabMove;

    private int _numberbeforebrockenplatform = 0;
    private int _numberbeforemoveplateform = 0;

    private void Start()
    {
        StartCoroutine(PlateformPrefab());
    }

    IEnumerator PlateformPrefab()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            int index = Random.Range(0, spawnList.Count);
            _numberbeforebrockenplatform = Random.Range(0, 5);
            _numberbeforemoveplateform = Random.Range(0, 5);
            if (_numberbeforemoveplateform == 0)
            {
                _numberbeforebrockenplatform--;
                GameObject plateform = Instantiate(PlateformePrefabMove);
                plateform.transform.position = new Vector3(0, spawnList[index].transform.position.y, spawnList[index].transform.position.z);
            }
            else if (_numberbeforebrockenplatform == 0)
            {
                _numberbeforemoveplateform--;
                GameObject plateform = Instantiate(PlateformePrefabBrocken);
                plateform.transform.position = spawnList[index].transform.position;
            }
            else
            {
                GameObject plateform = Instantiate(PlateformePrefab);
                plateform.transform.position = spawnList[index].transform.position;
            }
        }
    }
}

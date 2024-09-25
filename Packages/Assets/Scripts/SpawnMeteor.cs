using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;

    [HideInInspector] public int meteorCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLittleMeteor", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (meteorCount == 5)
        {
            SpawnBigMeteor();
        }

        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameOver == true)
        {
            CancelInvoke();
        }
    }

    void SpawnLittleMeteor()
    {
        Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

    void SpawnBigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }
}

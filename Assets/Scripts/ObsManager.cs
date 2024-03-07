using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawns;
    [SerializeField] private ObjectPooling objectPooling;
    [SerializeField] private float counter;

    // Start is called before the first frame update
    void Start()
    {
        spawns[0] = transform.GetChild(0).gameObject.transform;
        spawns[1] = transform.GetChild(1).gameObject.transform;
        objectPooling = GameObject.Find("Pool").GetComponent<ObjectPooling>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= 3)
        {
            ThrowEnemy();
            counter = 0;
        }
    }

    void ThrowEnemy()
    {
        int setSpawn = Random.Range(0, 2);
        GameObject tempObstacle = objectPooling.RequestObject();
        tempObstacle.transform.position = spawns[setSpawn].position;
    }
}

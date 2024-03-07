using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    #region Vars
    public float speed;
    private ObjectPooling objectPooling;
    private GamManager gamManager;
    #endregion

    private void Start()
    {
        objectPooling = GameObject.Find("Pool").GetComponent<ObjectPooling>();
        gamManager = GameObject.Find("ObstacleManager").GetComponent<GamManager>();
    }

    private void Update()
    {
        Move();    
    }

    void Move()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Wall"))
        {
            objectPooling.DespawnObject(gameObject);
            if (collision.GetComponent<PlayerMov>() != null)
            {
                collision.GetComponent<PlayerMov>().HitBySomeSh();
                gamManager.killed();
            }
        }
    }
}

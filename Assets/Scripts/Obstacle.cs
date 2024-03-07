using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    ObjectPooling objectPooling;

    private void Start()
    {
        objectPooling = GameObject.Find("Pool").GetComponent<ObjectPooling>();
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
        }
    }
}

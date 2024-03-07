using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamManager : MonoBehaviour
{
    #region Vars
    private PanelManager panelManager;
    private ObjectPooling objectPooling;
    [SerializeField] private Transform[] spawns;
    [SerializeField] GameObject player;
    [SerializeField] GameObject panel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScoreText;
    private bool isAlive = true;
    private float counter;
    private float counter2;
    private float score;
    private float speed = 0;
    #endregion

    void Start()
    {
        spawns[0] = transform.GetChild(0).gameObject.transform;
        spawns[1] = transform.GetChild(1).gameObject.transform;
        objectPooling = GameObject.Find("Pool").GetComponent<ObjectPooling>();
        panelManager = GameObject.Find("Canvas").GetComponent<PanelManager>();
    }

    void Update()
    {
        Count();
    }

    void ThrowEnemy()
    {
        int setSpawn = Random.Range(0, 2);
        GameObject tempObstacle = objectPooling.RequestObject();
        tempObstacle.GetComponent<Obstacle>().speed += speed;
        tempObstacle.transform.position = spawns[setSpawn].position;
    }

    void Count()
    {
        if (!isAlive) return;

        counter += Time.deltaTime;
        counter2 += Time.deltaTime;
        score = Mathf.Round(counter);
        scoreText.text = ("" + score);
        if (score % 10 == 0 && score != 0)
        {
            speed += .3f * Time.deltaTime;
        }
        if (counter2 >= 3)
        {
            ThrowEnemy();
            counter2 = 0;
        }
    }

    public void killed()
    {
        isAlive = false;
        panelManager.EnablePanel(3);
        finalScoreText.text = ("\n" + "YOU GOT HIT \n" + "\n" + "Time lived: \n" + "\n" + score);
        scoreText.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void restartGame()
    {
        counter = 0;
        counter2 = 0;
        speed = 0;
        player.SetActive(true);
        panel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        objectPooling.DespawnAll();
        isAlive = true;
        Time.timeScale = 1;
    }
}

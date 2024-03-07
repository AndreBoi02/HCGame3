using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    #region Vars
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject menu;
    #endregion

    void Start()
    {
        Time.timeScale = 0;
    }

    public void startGame()
    {
        Time.timeScale = 1.0f;
        level.SetActive(true);
        score.SetActive(true);
        menu.SetActive(false);
    }
}

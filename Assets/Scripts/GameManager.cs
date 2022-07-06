using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject bombAmount;
    [SerializeField] GameObject healthAmount;
    [SerializeField] GameObject weaponLevel;

    int points = 0;

    [SerializeField] GameObject endPanel;
    [SerializeField] TMP_Text endText;

    [SerializeField] GameObject explode;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        endPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void DropItem(Transform pos)
    {
        int rand = Random.Range(0, 100);
        if (rand > 50 && rand < 80)
        {
            Instantiate(healthAmount, pos.position, Quaternion.identity);
        }
        else if (rand >= 80 && rand < 95)
        {
            Instantiate(bombAmount, pos.position, Quaternion.identity);
        } else if (rand >= 95)
        {
            Instantiate(weaponLevel, pos.position, Quaternion.identity);
        }
    }


    public void EnemyDestroy(Transform pos)
    {
        DropItem(pos);
        points++;
        Debug.Log("Points: " + points);
    }

    public void End(bool win)
    {
        if(win)
        {
            endPanel.SetActive(true);
            endText.text = "YOU WIN!!!";
        } else
        {
            endPanel.SetActive(true);
            endText.text = "YOU LOSE!!!";
        }
        Time.timeScale = 0;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void InstantiateExplode(Transform pos)
    {
        Instantiate(explode, pos.position, Quaternion.identity);
    }
}

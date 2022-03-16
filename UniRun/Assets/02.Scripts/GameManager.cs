using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameover = false;
    public Text scoreText;
    public GameObject gameoverUI;

    private int score = 0;

    public GameObject menuPanel;

    public int hpCount = 2;
    public Text hpText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        hpText.text = hpCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score :" + score;
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }

    public void OnMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OffMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public bool Crash()  //���ǹ� �ȿ� ������ ������ �ȵ�... ��ȯ������ ���Ե� ����
                         //���ǹ��� else��
                         //���ǹ� �ۿ� ���� false; (�� Ÿ�� �Լ�)
    {
        //hpCount--;
        //hpText.text = hpCount.ToString();

        
        hpText.text = "" + --hpCount; //1 > PlayerController
        if (hpCount <= 0) return true;
        return false;
    }
}


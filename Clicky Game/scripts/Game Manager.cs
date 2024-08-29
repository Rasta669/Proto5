using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    //private SceneManager sceneManager;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public Button restartButton;
    private int gameScore;
    public bool gameActive;
    private float spawnRate = 1.0f;
    public GameObject gameHome;
    // Start is called before the first frame update
    void Start()
    {
        gameHome.SetActive(true);
        //Gettin the restart button and disabling it
        restartButton.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    IEnumerator SpawnTarget(int spawnDifficult)
    {
        spawnRate /= spawnDifficult;

        while (gameActive)
        {   
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void EndGame()
    {
        gameActive = false;
        gameHome.SetActive(false);
        gameOverText.SetActive(!gameActive);
        restartButton.gameObject.SetActive(!gameActive);  
          
    }

    public void RestartGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        

    }

    public void StartGame(int difficult)
    {
        gameActive = true;
        gameOverText.SetActive(false);
        gameScore = 0;
        UpdateScore(gameScore);
        StartCoroutine(SpawnTarget(difficult));
        gameHome.SetActive(!gameActive);    
        
    }

    public void TestButton()
    {
        Debug.Log("Button Clicked");
    }

    public void UpdateScore(int score)
    {
        gameScore += score;
        scoreText.text = "Score:" + gameScore;
    }
    }

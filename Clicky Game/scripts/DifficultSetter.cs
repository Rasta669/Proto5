using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultSetter : MonoBehaviour
{
    public Button difficultButton;
    public GameManager gameManager;
    public int difficultScore;
    // Start is called before the first frame update
    void Start()
    {
        difficultButton = GetComponent<Button>();
        //Getting our game manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void SetDifficulty()
    {
        Debug.Log(difficultButton.name);
        gameManager.StartGame(difficultScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

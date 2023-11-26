using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public bool isGameOver = false;
    public bool isGameStarted = false;
    public int gameScore = 0;

    public static GameManager Instance { get { return instance;  } }

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Update() {
        
    }

    public void StartGame() {
        isGameStarted = true;
    }

    public void GameOver() {
        isGameOver = true;
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Obstacle")) {
            gameScore++;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Graphic gameTitle;
    [SerializeField] Graphic gameSubtitle;
    [SerializeField] Graphic gameOverTitle;
    [SerializeField] Graphic gameOverSubtitle;
    [SerializeField] Graphic score;
    [SerializeField] float fadeTime = 0.5f;

    private void Start() {
        gameOverTitle.CrossFadeAlpha(0, 0f, true);
        gameOverSubtitle.CrossFadeAlpha(0, 0f, true);
        score.CrossFadeAlpha(0, 0f, true);
    }

    void Update()
    {
        if(GameManager.Instance.isGameStarted) {
            gameTitle.CrossFadeAlpha(0, fadeTime, true);
            gameSubtitle.CrossFadeAlpha(0, fadeTime, true);
            score.CrossFadeAlpha(1, fadeTime, true);
        }
        if(GameManager.Instance.isGameOver) {
            gameOverTitle.CrossFadeAlpha(1, fadeTime, true);
            gameOverSubtitle.CrossFadeAlpha(1, fadeTime, true);
        }
        score.gameObject.GetComponent<TextMeshProUGUI>().text = "SCORE:" + GameManager.Instance.gameScore;
    }
}

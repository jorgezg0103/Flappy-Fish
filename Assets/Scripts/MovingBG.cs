using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBG : MonoBehaviour
{

    [SerializeField] List<GameObject> foreground;
    [SerializeField] List<GameObject> midground;
    [SerializeField] List<GameObject> farground;

    private float bgOffset;

    [SerializeField] float foregroundSpeed = 5;
    [SerializeField] float midgroundSpeed = 3;
    [SerializeField] float fargroundSpeed = 1;


    void Start()
    {
        bgOffset = foreground[1].transform.position.x;
    }

    void Update()
    {
        if(!GameManager.Instance.isGameOver && GameManager.Instance.isGameStarted) {
            moveBackground();
        }
    }

    void moveBackground() {
        for(int i = 0; i < 2; i++) {
            foreground[i].transform.Translate(Vector2.left * foregroundSpeed * Time.deltaTime);
            midground[i].transform.Translate(Vector2.left * midgroundSpeed * Time.deltaTime);
            farground[i].transform.Translate(Vector2.left * fargroundSpeed * Time.deltaTime);
            resetPosIfNeeded(foreground[i]);
            resetPosIfNeeded(midground[i]);
            resetPosIfNeeded(farground[i]);
        }
    }

    void resetPosIfNeeded(GameObject background) {
        if(background.transform.position.x <= -bgOffset) {
            background.transform.position = new Vector2(bgOffset, 0);
        }
    }
}

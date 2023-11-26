using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D playerRB;
    [SerializeField] float thrust = 5;

    private bool isDead = false;
    private float rotationDivider = 10f;

    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        playerRB.gravityScale = 0;
    }

    void Update()
    {
        if(!isDead && Input.GetMouseButtonDown(0)) {
            if(GameManager.Instance.isGameStarted) {
                Flap();
            }
            else {
                GameManager.Instance.StartGame();
                Flap();
                playerRB.gravityScale = 1;
            }
        }
        else if(Input.GetMouseButtonDown(0)) {
            GameManager.Instance.RestartGame();
        }
        if(!isDead)
            rotateFish();
    }

    void Flap() {
        playerRB.velocity = Vector2.zero;
        playerRB.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        Debug.Log(playerRB.velocity.y);
    }

    void rotateFish() {
        float angle;
        if(playerRB.velocity.y >= 0) {
            angle = Mathf.Lerp(0, 25, playerRB.velocity.y / rotationDivider);
        }
        else {
            angle = Mathf.Lerp(0, -75, -playerRB.velocity.y / rotationDivider);
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Obstacle")) {
            GameManager.Instance.GameOver();
            isDead = true;
        }
    }
}

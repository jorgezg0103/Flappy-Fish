using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private const int screenOffset = -12;
    [SerializeField] private float speed = 5;


    void Update() {
        if(!GameManager.Instance.isGameOver) {
            if(transform.position.x >= screenOffset) {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else {
                this.gameObject.SetActive(false);
            }
        }
    }
}

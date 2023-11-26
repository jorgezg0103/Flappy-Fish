using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitsManager : MonoBehaviour
{

    [SerializeField] GameObject topLimit;
    [SerializeField] GameObject bottomLimit;

    void SetLimitsInCameraBoundaries() {
        float topLimitHeight = topLimit.transform.localScale.y / 2;
        float bottomLimitHeight = bottomLimit.transform.localScale.y / 2;

        topLimit.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 1));
        bottomLimit.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 1));

        topLimit.transform.Translate(new Vector3(0, topLimitHeight, 0));
        bottomLimit.transform.Translate(new Vector3(0, -bottomLimitHeight, 0));
    }

    void SetLimitsWidthAndHeight() {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;

        Vector3 currentTopLimitScale = topLimit.transform.localScale;
        Vector3 currentBottomLimitScale = bottomLimit.transform.localScale;
        currentTopLimitScale.x = width;
        currentBottomLimitScale.x = width;
        topLimit.transform.localScale = currentTopLimitScale;
        bottomLimit.transform.localScale = currentBottomLimitScale;
    }

    void Start()
    {
        SetLimitsInCameraBoundaries();
        SetLimitsWidthAndHeight();
    }

}

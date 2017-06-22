using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTo2DWorldPosition : MonoBehaviour {

    public static Vector3 ScreenToWorld()
    {
        Vector3 position = Vector3.zero;
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0);
            position = Camera.main.ScreenToWorldPoint(touchPosition);
        }
        return position;
    }
}

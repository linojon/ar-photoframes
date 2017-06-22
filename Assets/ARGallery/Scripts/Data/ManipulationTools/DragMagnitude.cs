using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMagnitude  {
   public static float scaleSpeed = 0.5f;

   public static float GetScale(float currentScale)
    {
        
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // ... change the currentScale size based on the change in distance between the touches.
            currentScale += deltaMagnitudeDiff * scaleSpeed;

            // Make sure the currentScale size never drops below zero.
            return Mathf.Max(currentScale, 0.1f);
        }
        else
        {
            return currentScale;
        }
    }
}

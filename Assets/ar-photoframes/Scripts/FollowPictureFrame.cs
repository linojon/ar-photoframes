using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPictureFrame : MonoBehaviour
{

    private Transform trackedTransform;
	// Use this for initialization
	void Start ()
	{
	  AppStateManager.instance.OnPictureFrameChange.AddListener(UpdatePictureFrameTarget);
	}

    void UpdatePictureFrameTarget(PictureFrame pictureFrame)
    {
        trackedTransform= pictureFrame.transform;
   
    }
	
	// Update is called once per frame
	void Update () {

	    if (trackedTransform != null && AppStateManager.instance.CurrentAppState != AppState.FRAME)
	    {
	        transform.position = trackedTransform.position;
	    }
	    else
	    {
            if(AppStateManager.instance.currentWallTarget)
            transform.position = AppStateManager.instance.currentWallTarget.transform.position;
        }
    }
}

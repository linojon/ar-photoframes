using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class PictureFrameEvent : UnityEvent<PictureFrameView>
{
}

/// <summary>
/// Took place of the PictureFrameDisplay. This script now just updates the augment when the data is changed.
/// Subscribes itself to the controller. Edits the Image and frame , sends found and lost events.
/// </summary>
public class PictureFrameView : MonoBehaviour,ITrackableEventHandler
{
    [Tooltip("This is set at run time")]
    public string Id;
    public Renderer ImageRenderer;
    [SerializeField]
    private GameObject currentPrefab;
    [SerializeField]
    public Transform FrameSpawnPoint;
    [SerializeField]
    private TrackableBehaviour trackableBehaviour;
    private PictureFrame pictureFrame;
 

    public readonly PictureFrameEvent OnPictureFrameFound = new PictureFrameEvent();
    public readonly PictureFrameEvent OnPictureFrameLost = new PictureFrameEvent();
    // Use this for initialization
    void Start ()
	{
	    Id = trackableBehaviour.TrackableName;
        trackableBehaviour.RegisterTrackableEventHandler(this);
        if (pictureFrame == null)
        {
         
            GalleryController galleryController = FindObjectOfType<GalleryController>();
            //Subscribes to value changes in the pictureframe.cs
            pictureFrame = galleryController.RegisterFrame(this);
	        pictureFrame.OnImageTextureChange.AddListener(SetImage);
	        pictureFrame.OnGameObjectChange.AddListener(SetFramePrefab);
          
	    }

	}

    private void SetFramePrefab(GameObject framePrefab)
    {
        if (currentPrefab == framePrefab) return;

        if (currentPrefab != null)
            Destroy(currentPrefab);
        currentPrefab = CreateFrame(framePrefab);
    }

    private void SetImage(Texture imageTexture)
    {
        if (ImageRenderer.material.mainTexture != imageTexture)
        {
            ImageRenderer.material.mainTexture = imageTexture;
        }
    }

    //The application could be optimized by using object pooling
    private GameObject CreateFrame(GameObject frameGameObject)
    {
        //Creates a new gameobject with the same position and rotation as FrameSpawnPoint. It also sets the frame as a child
        //of FrameSpawnPoint. 
        GameObject newFrame = Instantiate(frameGameObject, FrameSpawnPoint.position, FrameSpawnPoint.rotation, FrameSpawnPoint);
        return newFrame;
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnPictureFrameFound.Invoke(this);
        }
        else
        {
            OnPictureFrameLost.Invoke(this);
        }
    }
}

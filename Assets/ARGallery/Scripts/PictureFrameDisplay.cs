using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(ImageTargetBehaviour))]
public class PictureFrameDisplay : MonoBehaviour
{

    public Renderer ImageRenderer;
    public Transform FrameSpawnPoint;

    [SerializeField]
    private GameObject pictureFramePrefab;
    private GameObject currentPrefab;


    public void UpdateFramePrefab(GameObject framePrefab)
    {
        if (pictureFramePrefab == framePrefab) return;

        if(currentPrefab != null)
            Destroy(currentPrefab);
        currentPrefab = CreateFrame(framePrefab);
    }

    public void UpdateImage(Texture imageTexture)
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


   
}

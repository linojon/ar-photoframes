using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureFrame : MonoBehaviour {

    [SerializeField]
    private Renderer imageRenderer;

    [SerializeField]
    private Transform frameSpawnPoint;

    private Texture ImageTexture;
    private GameObject currentFrame;
   

    // Use this for initialization
    void Start () {
        imageRenderer.gameObject.SetActive(false);
        frameSpawnPoint.gameObject.SetActive(false);
    }

    public void SetTexture(Texture imageTexture)
    {
        imageRenderer.gameObject.SetActive(true);
        print(imageTexture);
        if (imageRenderer.material.mainTexture != imageTexture)
        {
            imageRenderer.material.mainTexture = imageTexture;
        }
    }

    public void SetFrame(GameObject frameGameObject)
    {
        frameSpawnPoint.gameObject.SetActive(true);
        if (currentFrame == frameGameObject) return;

        if (currentFrame != null)
            Destroy(currentFrame);
        currentFrame = CreateFrame(frameGameObject);
    }

    //The application could be optimized by using object pooling
    private GameObject CreateFrame(GameObject frameGameObject)
    {
        //Creates a new gameobject with the same position and rotation as FrameSpawnPoint. It also sets the frame as a child
        //of FrameSpawnPoint. 
        GameObject newFrame = Instantiate(frameGameObject, frameSpawnPoint.position, frameSpawnPoint.rotation, frameSpawnPoint);
        return newFrame;
    }
}

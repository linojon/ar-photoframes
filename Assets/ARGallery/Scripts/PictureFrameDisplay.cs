using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PictureFrameDisplay : MonoBehaviour
{

    public Renderer ImageRenderer;
    public Transform FrameSpawnPoint;
    private GameObject currentPrefab;
    private ImageOption[] imageOptions;
    private FrameOption[] frameOptions;
    private bool showOptions;
    void Start()
    {
        RegisterOptions();
    }

    void RegisterOptions()
    {
       imageOptions = GetComponentsInChildren<ImageOption>();
        for (int i = 0; i < imageOptions.Length; i++)
        {
            imageOptions[i].OnImageOptionSelected.AddListener(UpdateImage);
        }

       frameOptions = GetComponentsInChildren<FrameOption>();
        for (int i = 0; i < frameOptions.Length; i++)
        {
            frameOptions[i].OnImageOptionSelected.AddListener(UpdateFramePrefab);
        }
    }

    void HideOptions()
    {
        for (int i = 0; i < imageOptions.Length; i++)
        {
            imageOptions[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < frameOptions.Length; i++)
        {
            frameOptions[i].gameObject.SetActive(false);
        }

    }

    void ShowOptions()
    {
        for (int i = 0; i < imageOptions.Length; i++)
        {
            imageOptions[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < frameOptions.Length; i++)
        {
            frameOptions[i].gameObject.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (showOptions)
        {
            ShowOptions();
        }
        else
        {
           HideOptions();
        }

        showOptions = !showOptions;
    }


    public void UpdateFramePrefab(GameObject framePrefab)
    {
        if (currentPrefab == framePrefab) return;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AugmentedFrame : MonoBehaviour
{

    [SerializeField]
    private Renderer imageRenderer;

    [SerializeField]
    private Transform frameSpawnPoint;
    private GameObject currentFramePrefab;
    public PictureFrame targetPictureFrame { get; private set; }
    private Vector3 startScale;


    public void SetFrame(PictureFrame pictureFrame)
    {
        startScale = transform.lossyScale;
        targetPictureFrame = pictureFrame;
        imageRenderer.gameObject.SetActive(false);
        frameSpawnPoint.gameObject.SetActive(false);
        targetPictureFrame.OnImageTextureChange.AddListener(SetTexture);
        targetPictureFrame.OnDelete.AddListener(Delete);
        targetPictureFrame.OnGameObjectChange.AddListener(SetFrame);
    }

    void OnMouseDown()
    {
        GalleryController galleryController = FindObjectOfType<GalleryController>();
        galleryController.FrameSelected(this);
    }

    void SetFrame(GameObject frameGameObject)
    {
        frameSpawnPoint.gameObject.SetActive(true);
        if (currentFramePrefab == frameGameObject) return;

        if (currentFramePrefab != null)
            Destroy(currentFramePrefab);
        currentFramePrefab = CreateFrame(frameGameObject);
    }

    void SetTexture(Texture imageTexture)
    {
        imageRenderer.gameObject.SetActive(true);
 
        if (imageRenderer.material.mainTexture != imageTexture)
        {
            imageRenderer.material.mainTexture = imageTexture;
        }
    }

    void Update()
    {
        if (targetPictureFrame != null)
        {
            transform.localPosition = targetPictureFrame.position;
            transform.localScale = startScale+ targetPictureFrame.scale;
        }
    }

    //The application could be optimized by using object pooling
    private GameObject CreateFrame(GameObject frameGameObject)
    {
        //Creates a new gameobject with the same position and rotation as FrameSpawnPoint. It also sets the frame as a child
        //of FrameSpawnPoint. 
        GameObject newFrame = Instantiate(frameGameObject, frameSpawnPoint.position, frameSpawnPoint.rotation, frameSpawnPoint);
        return newFrame;
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}

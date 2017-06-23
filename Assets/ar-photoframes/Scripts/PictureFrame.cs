using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        //Because the texture does not have a z scale we save it
        float currentZScale = transform.localScale.z;
        //https://forum.unity3d.com/threads/getting-original-size-of-texture-asset-in-pixels.165295/
        Vector2Int imgSize = ImageHeader.GetDimensions(AssetDatabase.GetAssetPath(imageTexture));
        Vector3 renderSize = imageRenderer.transform.localScale;
        float aspectRatioRender = renderSize.x / renderSize.y;
        float aspectRatioTexture = imgSize.x / imgSize.y;
        //https://stackoverflow.com/questions/6565703/math-algorithm-fit-image-to-screen-retain-aspect-ratio
        Vector3 aspect1 = new Vector3(imgSize.x * renderSize.y / imgSize.y, renderSize.y, currentZScale);
        Vector3 aspect2 = new Vector3(renderSize.x, imgSize.y * renderSize.x / imgSize.x, currentZScale);
        transform.localScale = aspectRatioRender > aspectRatioTexture ? aspect1 : aspect2;
        //transform.localScale = correctedSize/ aspectRatio*.1f;
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

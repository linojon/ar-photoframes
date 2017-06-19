


using UnityEngine;

[System.Serializable]
public class PictureFrame
{

    private string id;
    private GameObject pictureFramePrefab;
    private Texture image;

    public PictureFrame CompareFrameById(string Id)
    {
        if (id == Id)
        {
            return this;
        }
        else
        {
            return null;
        }
    }

    public PictureFrame(string id)
    {
        this.id = id;
    }

    public void SetImage(Texture imageTexture)
    {
        image = imageTexture;
    }

    public void SetFramePrefab(GameObject prefab)
    {
        pictureFramePrefab = prefab;
    }

    public GameObject GetCurrentFrameObject()
    {
        return pictureFramePrefab;
    }

    public Texture GetCurrentImage()
    {
        return image;
    }
}




using UnityEngine;

[System.Serializable]
public class PictureFrame
{

    public string id;
    public GameObject PictureFrameObject;
    public Texture Image;

    public PictureFrame CompareFrameById(string Id)
    {
        if (id == Id)
            return this;
    }
}

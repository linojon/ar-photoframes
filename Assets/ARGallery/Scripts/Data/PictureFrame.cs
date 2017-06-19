


using UnityEngine;

[System.Serializable]
public class PictureFrame
{

    private string id;
    public GameObject PictureFrameObject;
    public Texture Image;

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
}

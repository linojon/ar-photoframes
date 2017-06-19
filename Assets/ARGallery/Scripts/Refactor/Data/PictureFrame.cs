using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectEvent : UnityEvent<GameObject>
{
}

public class ImageTextureEvent : UnityEvent<Texture>
{
}
/// <summary>
/// This script is based of of FrameOptions.cs script.
/// It containes the information that is stored on a picture frame.
/// The events that were originally in the Options are moved here so that they
/// can inform other scripts when the data was changed. They work as "Observed values" =  
/// </summary>
[System.Serializable]
public class PictureFrame
{
    private string Id;
    private Texture ImageTexture;
    private GameObject prefabGameObject;

    public readonly ImageTextureEvent OnImageTextureChange = new ImageTextureEvent();
    public readonly GameObjectEvent OnGameObjectChange = new GameObjectEvent();

    public PictureFrame(string id)
    {
        Id = id;
    }

    public void SetImageTexture(Texture texture)
    {
        ImageTexture = texture;
        OnImageTextureChange.Invoke(ImageTexture);
    }

    public void SetGameObjectPrefab(GameObject gameObject)
    {
        prefabGameObject = gameObject;
        OnGameObjectChange.Invoke(gameObject);
    }

    public bool CompareId(string compareId)
    {
        return Id == compareId;
    }
}

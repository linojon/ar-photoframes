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
    private int id;
    private Texture ImageTexture;
    private GameObject prefabGameObject;
    //Public because they can be modified and read
    public Vector3 scale = Vector3.one;
    public Vector3 position = Vector3.zero;

    public readonly ImageTextureEvent OnImageTextureChange = new ImageTextureEvent();
    public readonly GameObjectEvent OnGameObjectChange = new GameObjectEvent();
    public readonly UnityEvent OnDelete = new UnityEvent();

    public PictureFrame(int id)
    {
        this.id = id;
    }

    public int GetID()
    {
        return id;
    }

    public void SetImageTexture(Texture texture)
    {
        ImageTexture = texture;
        OnImageTextureChange.Invoke(texture);
    }

    public void SetGameObjectPrefab(GameObject gameObject)
    {
        prefabGameObject = gameObject;
        OnGameObjectChange.Invoke(gameObject);
    }

    public void MoveFrame(Vector3 newPosition)
    {
        position = newPosition;
    }

    public void DeleteFrame()
    {
        OnDelete.Invoke();
    }

    public void ScaleFrame(Vector3 newScale)
    {
        scale = newScale;
    }


    public bool CompareId(int compareId)
    {
        return id == compareId;
    }
}

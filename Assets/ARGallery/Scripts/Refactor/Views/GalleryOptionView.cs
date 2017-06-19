using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All of the options were combined into one generic script that says what data
/// it holds. It it requires a box collided because the Mouse Down Event works using a 
/// physics raycast.
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class GalleryOptionView : MonoBehaviour
{

    [SerializeField]
    private int optionIndex;

    [SerializeField]
    private bool isImageOption;

    [SerializeField]
    private GalleryOptions galleryOptions;

    public readonly GameObjectEvent OnGameObjectSelected = new GameObjectEvent();
    public readonly ImageTextureEvent OnImageTextureSelected = new ImageTextureEvent();

    private void OnMouseDown()
    {
        print("Option Selected");
        ReturnData();
    }

    private void ReturnData()
    {
        if (isImageOption)
        {
            OnImageTextureSelected.Invoke(getTextureOption(optionIndex));
        }
        else
        {
            OnGameObjectSelected.Invoke(getPrefabOption(optionIndex));
        }
    }

    public void ShowOption(bool showImage)
    {
        //Enables and disables this GameObject based on the isImageOption value.
        gameObject.SetActive(isImageOption == showImage);
    }

    Texture getTextureOption(int index)
    {
        return galleryOptions.Textures[index];
    }

    GameObject getPrefabOption(int index)
    {
        return galleryOptions.FramePrefabs[index];
    }
}

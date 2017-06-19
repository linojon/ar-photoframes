using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryController : MonoBehaviour
{
    private string currentFrameId;
    private GalleryModel galleryModel = new GalleryModel();
    private GalleryOptionView[] galleryOptionViews = new GalleryOptionView[0];
    private bool optionsVisable;

    void Start()
    {
        RegisterOptions();
    }


    public void ToggleOptions()
    {
        optionsVisable = !optionsVisable;
        if (optionsVisable)
        {
            ShowOptions();
        }
        else
        {
            HideOptions();
        }
    }

    public void ShowImageOptions(bool showImages)
    {
        ShowOptions(showImages);
    }

    public PictureFrame RegisterFrame(PictureFrameView pictureFrameView)
    {
        PictureFrame registeredPictureFrame = galleryModel.FindFrameById(pictureFrameView.Id);
        if (registeredPictureFrame == null)
        {
            //show options if object is new
            pictureFrameView.OnPictureFrameFound.AddListener(SetCurrentFrame);
            pictureFrameView.OnPictureFrameLost.AddListener(LoseFrame);
            return galleryModel.CreatePictureFrame(pictureFrameView.Id);
        }
        else
        {
            //Hide options if object is old
            return registeredPictureFrame;
        }
    }

    private void RegisterOptions()
    {
        //"True" will search child gameobjects even if they are disabled
        galleryOptionViews = GetComponentsInChildren<GalleryOptionView>(true);

        for (int i = 0; i < galleryOptionViews.Length; i++)
        {
            galleryOptionViews[i].OnImageTextureSelected.AddListener(ImageSelected);
            galleryOptionViews[i].OnGameObjectSelected.AddListener(PrefabSelected);
        }
    }

    private void SetCurrentFrame(PictureFrameView pictureFrameView)
    {
        PictureFrame registeredPictureFrame = galleryModel.FindFrameById(pictureFrameView.Id);
        if (registeredPictureFrame == null)
        {
            //show options if object is new
            ShowOptions();
            currentFrameId = pictureFrameView.Id;
        }
        else
        {
            currentFrameId = pictureFrameView.Id;
        }
    }

    private void LoseFrame(PictureFrameView pictureFrameView)
    {
        if (currentFrameId == pictureFrameView.Id)
        {
            currentFrameId = "";
            HideOptions();
        }
          
    }


    private void ImageSelected(Texture imageTexture)
    {
        galleryModel.SetTextureImage(currentFrameId, imageTexture);
    }

    private void PrefabSelected(GameObject prefabGameObject)
    {
        galleryModel.SetFramePrefab(currentFrameId,prefabGameObject);
    }

    //The default value of showing images is false
    private void ShowOptions(bool showImages = false)
    {
        optionsVisable = true;
        for (int i = 0; i < galleryOptionViews.Length; i++)
        {
            galleryOptionViews[i].ShowOption(showImages);
        }
    }

    private void HideOptions()
    {
        optionsVisable = false;
        for (int i = 0; i < galleryOptionViews.Length; i++)
        {
            galleryOptionViews[i].gameObject.SetActive(false);
        }
    }
}

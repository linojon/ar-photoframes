using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryController : MonoBehaviour
{
    [SerializeField]
    private ClickableObject pictureClickableObject;

    [SerializeField]
    private ClickableObject frameClickableObject;

    private string currentFrameId;
    private GalleryModel galleryModel = new GalleryModel();
    private GalleryOptionView[] galleryOptionViews = new GalleryOptionView[0];
    private bool optionsVisable;

    void Start()
    {
        RegisterOptions();
        RegisterClickableObjects();
        HideText();
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
            HideText();
        }
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
        currentFrameId = pictureFrameView.Id;
        ShowOptions();
    }

    private void LoseFrame(PictureFrameView pictureFrameView)
    {
        if (currentFrameId == pictureFrameView.Id)
        {
            currentFrameId = "";
            HideOptions();
            HideText();
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
        ToggleText(showImages);
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

    private void ShowImages()
    {
        ShowOptions(true);
    }

    private void ShowFrames()
    {
        ShowOptions();
    }

    private void RegisterClickableObjects()
    {
        pictureClickableObject.OnObjectClicked.AddListener(ShowImages);
        frameClickableObject.OnObjectClicked.AddListener(ShowFrames);
    }

    private void ToggleText(bool showImages)
    {
        if (showImages)
        {
            pictureClickableObject.gameObject.SetActive(false);
            frameClickableObject.gameObject.SetActive(true);
        }
        else
        {
            pictureClickableObject.gameObject.SetActive(true);
            frameClickableObject.gameObject.SetActive(false);
        }
    }

    private void HideText()
    {
        frameClickableObject.gameObject.SetActive(false);
        pictureClickableObject.gameObject.SetActive(false);
    }
}

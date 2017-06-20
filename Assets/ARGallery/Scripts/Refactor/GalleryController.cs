using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryController : MonoBehaviour
{

    [SerializeField]
    private Text HelpText;

    [SerializeField]
    private PicturePhotoOptions photoOptions;

    [SerializeField]
    private PictureFrameOptions frameOptions;

    private string currentFrameId;
    private GalleryModel galleryModel = new GalleryModel();
    private bool optionsVisable;

    void Start()
    {
        RegisterOptions();
        HideOptions();
    }

    void Update()
    {
        if (string.IsNullOrEmpty(currentFrameId))
        {
            HelpText.text = "Searching for target.";
        }
        else
        {
            if (optionsVisable == true)
            {
                HelpText.text = "Click on the frame to close.";
            }

            if (optionsVisable == false)
            {
                HelpText.text = "Click on the picture to open options.";
            }
        }
    }


    public void ToggleOptions()
    {
        optionsVisable = !optionsVisable;
        if (optionsVisable)
        {
            ShowFrameOptions();
        }
        else
        {
            HideOptions();
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
        photoOptions.OnImageTextureSelected.AddListener(ImageSelected);
        frameOptions.OnGameObjectSelected.AddListener(PrefabSelected);
    }

    private void SetCurrentFrame(PictureFrameView pictureFrameView)
    {  
        currentFrameId = pictureFrameView.Id;
        ShowFrameOptions();
    }

    private void LoseFrame(PictureFrameView pictureFrameView)
    {
        if (currentFrameId == pictureFrameView.Id)
        {
            currentFrameId = "";
            HideOptions();
        }
          
    }

    private void HideOptions()
    {
        photoOptions.Hide();
        frameOptions.Hide();
    }

    public void ShowFrameOptions()
    {
        optionsVisable = true;
        photoOptions.Hide();
        frameOptions.Show();
    }

    public void ShowPhotoOptons()
    {
        optionsVisable = true;
        photoOptions.Show();
        frameOptions.Hide();
    }

    private void ImageSelected(Texture imageTexture)
    {
        galleryModel.SetTextureImage(currentFrameId, imageTexture);
    }

    private void PrefabSelected(GameObject prefabGameObject)
    {
        galleryModel.SetFramePrefab(currentFrameId,prefabGameObject);
    }

 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTool : PictureToolBase
{
    public Texture[] ImageTextures;
    public ClickableObject[] ImageClickableObjects;
    [SerializeField]
    private ClickableObject nextButton;
    [SerializeField]
    private ClickableObject previousButton;
    [SerializeField]
    private ClickableObject confirmButton;
    //The items per page is calculated by the number of images shown at start.
    private int indexOffset;

    void Start()
    {
        HideButtons();
        DisableClickableObjects();
        SubscribeButtons();

    }
    public override void InitTool(PictureFrame targetPictureFrame)
    {
        ShowButtons();
        EnableClickableObjects();
        UpdateImages();
        base.InitTool(targetPictureFrame);
    }

    public override void UpdateTool()
    {

    }

    public override void ExitTool()
    {
        HideButtons();
        DisableClickableObjects();
        base.ExitTool();
    }

    private void SubscribeButtons()
    {
        previousButton.OnObjectClicked.AddListener(PreviousPage);
        nextButton.OnObjectClicked.AddListener(NextPage);
        confirmButton.OnObjectClicked.AddListener(ConfirmImage);
        for (int i = 0; i < ImageClickableObjects.Length; i++)
        {
            ImageClickableObjects[i].OnGameObjectClicked.AddListener(ObjectClicked);
        }
    }

    void ConfirmImage()
    {
        AppStateManager.instance.SetState(AppState.MODIFY);
    }

    void DisableClickableObjects()
    {
        for (int i = 0; i < ImageClickableObjects.Length; i++)
        {
            ImageClickableObjects[i].gameObject.SetActive(false);
        }
    }

    void EnableClickableObjects()
    {
        for (int i = 0; i < ImageClickableObjects.Length; i++)
        {
            ImageClickableObjects[i].gameObject.SetActive(true);
        }
    }

    void ObjectClicked(GameObject clickedGameObject)
    {
        TargetPictureFrame.SetTexture(clickedGameObject.GetComponent<Renderer>().material.mainTexture);
    }


    private void UpdateImages()
    {
        for (int i = 0; i < ImageClickableObjects.Length; i++)
        {
            print(ImageTextures[i + indexOffset]);
            //Sets the texture for the images based on index
            ImageClickableObjects[i].GetComponent<Renderer>().material.mainTexture = ImageTextures[i + indexOffset];
        }
    }

    private void NextPage()
    {
        if ((indexOffset + ImageClickableObjects.Length) < ImageTextures.Length)
        {
            indexOffset++;
        }
        UpdateImages();
    }

    private void PreviousPage()
    {
        if ((indexOffset - 1) >= 0)
        {
            indexOffset--;
        }
        UpdateImages();
    }

    private void ShowButtons()
    {
        previousButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        confirmButton.gameObject.SetActive(true);

    }

    private void HideButtons()
    {
        previousButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        confirmButton.gameObject.SetActive(false);
    }

}

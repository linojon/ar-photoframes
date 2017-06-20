using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePhotoOptions : GalleryOptionsBase
{
   
    public readonly ImageTextureEvent OnImageTextureSelected = new ImageTextureEvent();
    [SerializeField]
    private List<Texture> textureOptions;
    [SerializeField]
    private ClickableObject nextButton;
    [SerializeField]
    private ClickableObject previousButton;

    //The items per page is calculated by the number of images shown at start.
    private int indexOffset;

    void Start()
    {
        UpdateImages();
        nextButton.OnObjectClicked.AddListener(NextPage);
        previousButton.OnObjectClicked.AddListener(PreviousPage);
    }

    private void NextPage()
    {
        if ((indexOffset + clickableObjects.Count) < textureOptions.Count )
        {
            indexOffset++;
        }
        UpdateImages();
    }

    private void PreviousPage()
    {
        if ((indexOffset - 1)>=0)
        {
            indexOffset--;
        }
        UpdateImages();
    }

    private void UpdateImages()
    {
        for (int i = 0; i < clickableObjects.Count; i++)
        {
            print(textureOptions[i + indexOffset]);
            //Sets the texture for the images based on index
            clickableObjects[i].GetComponent<Renderer>().material.mainTexture = textureOptions[i + indexOffset];
        }
    }

    protected override void OptionSelected(ClickableObject selectedClickableObject)
    {
        int indexOfClickableObject = clickableObjects.IndexOf(selectedClickableObject);
        //We add the number of images that were shuffled through
        int indexOfOption = indexOfClickableObject + indexOffset;
        if (indexOfOption < textureOptions.Count)
        {
            OnImageTextureSelected.Invoke(textureOptions[indexOfOption]);
        }
    }

    public override void Show()
    {
        previousButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        base.Show();
    }

    public override void Hide()
    {
        previousButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        base.Hide();
    }
}

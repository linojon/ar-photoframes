using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureFrameOptions : GalleryOptionsBase
{

    public readonly GameObjectEvent OnGameObjectSelected = new GameObjectEvent();
    [SerializeField]
    private List<GameObject>framePrefabs;

    protected override void OptionSelected(ClickableObject SelectedClickableObject)
    {
        int indexOfClickableObject = clickableObjects.IndexOf(SelectedClickableObject);
        if (indexOfClickableObject < framePrefabs.Count)
        {
            OnGameObjectSelected.Invoke(framePrefabs[indexOfClickableObject]);
        }
    }
}

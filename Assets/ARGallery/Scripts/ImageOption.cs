using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ImageOptionSelected : UnityEvent<Texture>
{
}

public class ImageOption : MonoBehaviour 
{
    public Texture TextureOption;
    public ImageOptionSelected OnImageOptionSelected = new ImageOptionSelected();

    void OnMouseDown()
    {
        OnImageOptionSelected.Invoke(TextureOption);
        print("Image Selected");
    }
}

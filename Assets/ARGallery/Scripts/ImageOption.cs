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
    private Texture textureOption;
    public ImageOptionSelected OnImageOptionSelected = new ImageOptionSelected();

    void Start()
    {
        textureOption = GetComponent<Renderer>().material.mainTexture;
    }
    void OnMouseDown()
    {
        OnImageOptionSelected.Invoke(textureOption);
        print("Image Selected");
    }
}

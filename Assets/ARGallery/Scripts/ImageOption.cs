using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class ImageOption : MonoBehaviour 
{
    private Texture textureOption;


    void Start()
    {
        textureOption = GetComponent<Renderer>().material.mainTexture;
    }
    void OnMouseDown()
    {
        print("Image Selected");
    }
}

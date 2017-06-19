using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// We are going to store all of the options in a scriptable object. This is method has expandability to 
/// get information from JSON and other data sources.
/// </summary>
[CreateAssetMenu(fileName = "GalleryOptions", menuName = "Gallery/GalleryOptions")]
public class GalleryOptions : ScriptableObject
{
    public List<GameObject> FramePrefabs;
    public List<Texture> Textures;
}

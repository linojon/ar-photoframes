using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(ImageTargetBehaviour))]
public class PictureFrameDisplay : MonoBehaviour
{

    public Texture ImageTexture;
    //The application could be optimized by using object pooling
    public GameObject FrameSpawnPoint;

    [SerializeField]
    private PictureFrame pictureFrame;
    private ImageTargetBehaviour imageTargetBehaviour;

    void Start()
    {
        imageTargetBehaviour = GetComponent<ImageTargetBehaviour>();
        pictureFrame = new PictureFrame(imageTargetBehaviour.name);
    }
}

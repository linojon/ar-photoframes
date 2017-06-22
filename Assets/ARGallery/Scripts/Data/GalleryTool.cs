using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GalleryTool : MonoBehaviour
{
    public string Description;
    public AppState TargetState;
    protected bool isReady = false;
    protected PictureFrame TargetPictureFrame;
    protected GalleryController Controller;

    public bool IsReady
    {
        get { return isReady; }
    }

    void Awake()
    {
        Controller = FindObjectOfType<GalleryController>();
    }

    public virtual void InitTool(PictureFrame targetPictureFrame)
    {
        TargetPictureFrame = targetPictureFrame;
        isReady = true;
    }

    public virtual void ExitTool()
    {
        isReady = false;
    }

    public abstract void UpdateTool();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PictureToolBase : MonoBehaviour {

    public AppState TargetState;
    protected bool isReady = false;
    protected PictureFrame TargetPictureFrame;

    public bool IsReady
    {
        get { return isReady; }
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

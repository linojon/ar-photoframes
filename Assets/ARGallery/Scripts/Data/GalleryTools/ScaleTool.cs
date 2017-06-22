using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleTool : GalleryTool
{

    public Button FinishedScalingImage;
    private float currentScale = 1;

    void Start()
    {
        FinishedScalingImage.gameObject.SetActive(false);
        FinishedScalingImage.onClick.AddListener(FinishScale);
    }

    void FinishScale()
    {
        Controller.SwitchState(AppState.MODIFY);
    }
    public override void InitTool(PictureFrame targetPictureFrame)
    {
        FinishedScalingImage.gameObject.SetActive(true);
        base.InitTool(targetPictureFrame);
    }

    public override void UpdateTool()
    {
       TargetPictureFrame.scale = TargetPictureFrame.scale *DragMagnitude.GetScale(currentScale);
    }

    public override void ExitTool()
    {
        FinishedScalingImage.gameObject.SetActive(false);
        base.ExitTool();
    }
}

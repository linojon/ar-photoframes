using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTool : GalleryTool
{
    public Button FrameOptionButton;
    public Texture imageOption;

    void Start()
    {
        FrameOptionButton.gameObject.SetActive(false);
        FrameOptionButton.onClick.AddListener(PlaceFrame);
    }

    public void PlaceFrame()
    {
        Controller.SwitchState(AppState.MODIFY);
    }

    public override void InitTool(PictureFrame targetPictureFrame)
    {
        FrameOptionButton.gameObject.SetActive(true);
        base.InitTool(targetPictureFrame);
    }

    public override void UpdateTool()
    {
        TargetPictureFrame.SetImageTexture(imageOption);
    }

    public override void ExitTool()
    {
        FrameOptionButton.gameObject.SetActive(false);
        base.ExitTool();
    }
}

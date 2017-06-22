using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameTool : GalleryTool
{
    public Button FrameOptionButton;
    public GameObject frameOption;
    void Start()
    {
        FrameOptionButton.gameObject.SetActive(false);
        frameOption.SetActive(false);
        FrameOptionButton.onClick.AddListener(PlaceFrame);
    }

    public void PlaceFrame()
    {
        Controller.SelectFrame(frameOption);
    }

    public override void InitTool(PictureFrame targetPictureFrame)
    {
        frameOption.SetActive(true);
        FrameOptionButton.gameObject.SetActive(true);
        base.InitTool(targetPictureFrame);
    }

    public override void UpdateTool()
    {

    }

    public override void ExitTool()
    {
        FrameOptionButton.gameObject.SetActive(false);
        frameOption.SetActive(false);
        base.ExitTool();
    }
}

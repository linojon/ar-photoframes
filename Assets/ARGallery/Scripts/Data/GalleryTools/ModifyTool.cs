using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyTool : GalleryTool
{
    public Button MoveButton;
    public Button PictureButton;
    public Button FrameButton;
    public Button ResizeButton;
    public Button RemoveButton;
    public Button CloseButton;

    void Start()
    {
        MoveButton.gameObject.SetActive(false);
        PictureButton.gameObject.SetActive(false);
        FrameButton.gameObject.SetActive(false);
        ResizeButton.gameObject.SetActive(false);
        RemoveButton.gameObject.SetActive(false);
        CloseButton.gameObject.SetActive(false);

        MoveButton.onClick.AddListener(MoveTool);
        PictureButton.onClick.AddListener(PictureTool);
        FrameButton.onClick.AddListener(FrameTool);
        ResizeButton.onClick.AddListener(ResizeTool);
        RemoveButton.onClick.AddListener(RemoveTool);
        CloseButton.onClick.AddListener(Close);
    }
    public override void InitTool(PictureFrame targetPictureFrame)
    {
        MoveButton.gameObject.SetActive(true);
        PictureButton.gameObject.SetActive(true);
        FrameButton.gameObject.SetActive(true);
        ResizeButton.gameObject.SetActive(true);
        RemoveButton.gameObject.SetActive(true);
        CloseButton.gameObject.SetActive(true);

        base.InitTool(targetPictureFrame);
    }

    public override void UpdateTool()
    {

    }

    void MoveTool()
    {
        Controller.SwitchState(AppState.POSITION);
    }
    void PictureTool()
    {
        Controller.SwitchState(AppState.IMAGE);
    }
    void FrameTool()
    {
        Controller.SwitchState(AppState.FRAME);
    }
    void ResizeTool()
    {
        Controller.SwitchState(AppState.RESIZE);
    }
    void RemoveTool()
    {
        Controller.SwitchState(AppState.REMOVE);
    }
    void Close()
    {
        Controller.SwitchState(AppState.VIEWING);
    }

    public override void ExitTool()
    {

        MoveButton.gameObject.SetActive(false);
        PictureButton.gameObject.SetActive(false);
        FrameButton.gameObject.SetActive(false);
        ResizeButton.gameObject.SetActive(false);
        RemoveButton.gameObject.SetActive(false);
        CloseButton.gameObject.SetActive(false);

        base.ExitTool();
    }
}


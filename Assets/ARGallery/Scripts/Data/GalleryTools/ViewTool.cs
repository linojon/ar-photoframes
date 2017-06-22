using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTool : GalleryTool
{

    public Button CreateButton;
   

    void Start()
    {
        CreateButton.onClick.AddListener(CreateNewFrame);
        CreateButton.gameObject.SetActive(false);
    }

    void CreateNewFrame()
    {
        Controller.AddNewFrame();
    }

    public override void InitTool(PictureFrame targetPictureFrame)
    {
        CreateButton.gameObject.SetActive(true);
        base.InitTool(targetPictureFrame);
    }

    public override void UpdateTool()
    {

    }

    public override void ExitTool()
    {
        CreateButton.gameObject.SetActive(false);
        base.ExitTool();
    }
}


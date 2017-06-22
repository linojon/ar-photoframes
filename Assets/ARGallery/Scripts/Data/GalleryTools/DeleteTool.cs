using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTool : GalleryTool
{

    public override void InitTool(PictureFrame targetPictureFrame)
    {
        Controller.DeleteFrame(targetPictureFrame.GetID());
        base.InitTool(targetPictureFrame);
    }

    public override void UpdateTool()
    {

    }

    public override void ExitTool()
    {
        base.ExitTool();
    }
}

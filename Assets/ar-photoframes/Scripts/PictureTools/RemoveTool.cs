using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTool : PictureToolBase
{


    public override void InitTool(PictureFrame targetPictureFrame)
    {
      
        base.InitTool(targetPictureFrame);
        //This doesn't follow good design. Help?
        if (targetPictureFrame)
        {
            Destroy(targetPictureFrame.gameObject);
        }
        AppStateManager.instance.SetState(AppState.VIEW);
    }

    public override void UpdateTool()
    {

    }

    public override void ExitTool()
    {
        base.ExitTool();
    }
}

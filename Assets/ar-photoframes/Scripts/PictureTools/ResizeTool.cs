using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeTool : PictureToolBase {

    public ClickableObject ConfirmScale;
    private float currentScale = 1;

    void Start()
    {
        ConfirmScale.gameObject.SetActive(false);
        ConfirmScale.OnObjectClicked.AddListener(FinishScale);
    }
    void FinishScale()
    {
        AppStateManager.instance.SetState(AppState.MODIFY);
    }

    public override void InitTool(PictureFrame targetPictureFrame)
    {
        ConfirmScale.gameObject.SetActive(true);
        base.InitTool(targetPictureFrame);
    }

    public override void UpdateTool()
    {
        //ToDO DragMagnitude.GetScale(currentScale)
        TargetPictureFrame.transform.localScale = TargetPictureFrame.transform.localScale * 1;
    }

    public override void ExitTool()
    {
        ConfirmScale.gameObject.SetActive(false);
        base.ExitTool();
    }
}

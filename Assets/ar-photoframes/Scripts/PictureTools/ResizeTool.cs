using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResizeTool : PictureToolBase {

    public ClickableObject ConfirmScale;
    private float currentScale = 1;
    //This is used to make sure that we didn't go into the position tool with out mouse button down.
    private bool mouseButtonUp;
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
        initialScale = targetPictureFrame.transform.localScale;
        base.InitTool(targetPictureFrame);
    }

    Vector3 startPosition = Vector3.zero;
    Vector3 currentPosition = Vector3.zero;
    private Vector3 initialScale = Vector3.zero;
    public override void UpdateTool()
    {
    
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }
        //Checks if pointer is over UI
        if (Input.GetMouseButton(0)  && mouseButtonUp)
        {
            currentPosition = Input.mousePosition;
            float difference = Vector3.Distance(startPosition, currentPosition)/100;

            //ToDO DragMagnitude.GetScale(currentScale)
            TargetPictureFrame.transform.localScale = initialScale + (TargetPictureFrame.transform.localScale * difference);
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            startPosition = Input.mousePosition;
            mouseButtonUp = true;
        }
  
    }

    public override void ExitTool()
    {
        ConfirmScale.gameObject.SetActive(false);
        base.ExitTool();
    }
}

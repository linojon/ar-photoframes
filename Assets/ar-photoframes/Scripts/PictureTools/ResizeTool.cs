using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResizeTool : PictureToolBase {

    public ClickableObject ConfirmScale;
    //This is used to make sure that we didn't go into the position tool with out mouse button down.
    private bool mouseButtonUp;
    //Used to calculate the mouse position
    private Vector3 startPosition = Vector3.zero;
    private Vector3 currentPosition = Vector3.zero;
    private Vector3 initialScale = Vector3.zero;

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
     
        base.InitTool(targetPictureFrame);

        //Note that TargetPictureFrame is set in the base.InitTool
        // lowercase target picture frame is passed through the function.
        ConfirmScale.gameObject.SetActive(true);
        initialScale = TargetPictureFrame.transform.localScale;
    }



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
            float difference = (currentPosition-startPosition).magnitude;
            //Scaling down is possible by dragging your mouse to the left.
            int direction = currentPosition.x> startPosition.x ? 1 : -1;
            float scaleFactor = 1 + (difference/Screen.width) * direction;
            TargetPictureFrame.transform.localScale = initialScale * scaleFactor;
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            startPosition = Input.mousePosition;
            initialScale = TargetPictureFrame.transform.localScale;
            mouseButtonUp = true;
        }
  
    }

    public override void ExitTool()
    {
        ConfirmScale.gameObject.SetActive(false);
        base.ExitTool();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PositionTool : GalleryTool
{

    public Button FinishedMovingImage;

    public override void InitTool(PictureFrame targetPictureFrame)
    {
        base.InitTool(targetPictureFrame);
    }

    void Start()
    {
        FinishedMovingImage.gameObject.SetActive(false);
        FinishedMovingImage.onClick.AddListener(PlaceFrame);
    }

    Vector3 initialPosition = Vector3.zero;
    Vector3 mouseStartPosition = Vector3.zero;
    public override void UpdateTool()
    {

        //Checks if pointer is over UI
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 inputPosition = GetMousePositionInPlaneOfLauncher()- mouseStartPosition + initialPosition;
            TargetPictureFrame.position = inputPosition;
            FinishedMovingImage.gameObject.SetActive(true);
        }

        if(Input.GetMouseButtonUp(0))
        {
            initialPosition = TargetPictureFrame.position;
            mouseStartPosition = GetMousePositionInPlaneOfLauncher();
        }
   
    }

    void PlaceFrame()
    {
        Controller.FrameSelected(TargetPictureFrame);
    }
 
   
    Vector3 GetMousePositionInPlaneOfLauncher()
    {
        Vector3 mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(1);
       
        return new Vector3(-mousePosition.y, 0,mousePosition.z);
    }
    public override void ExitTool()
    {
        FinishedMovingImage.gameObject.SetActive(false);
        initialPosition = TargetPictureFrame.position;
        mouseStartPosition = GetMousePositionInPlaneOfLauncher();
        base.ExitTool();
    }
}

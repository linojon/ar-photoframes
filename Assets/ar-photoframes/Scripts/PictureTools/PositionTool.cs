using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PositionTool : PictureToolBase
{

    public ClickableObject FinishedMovingImage;
    public LayerMask WallLayerMask;
    //This is used to make sure that we didn't go into the position tool with out mouse button down.
    private bool mouseButtonUp;
    public override void InitTool(PictureFrame targetPictureFrame)
    {
        FinishedMovingImage.gameObject.SetActive(true);
        mouseButtonUp = false;
        base.InitTool(targetPictureFrame);
    }

    void Start()
    {
        FinishedMovingImage.gameObject.SetActive(false);
        FinishedMovingImage.OnObjectClicked.AddListener(PlaceFrame);
    
    }

    public override void UpdateTool()
    {

        //Checks if pointer is over UI
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()&& mouseButtonUp)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, WallLayerMask))
            {  
                    Debug.DrawLine(ray.origin, hit.point);
                    TargetPictureFrame.transform.position = hit.point; 
            }
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseButtonUp = true;
        }
    

    }

    void PlaceFrame()
    {
       AppStateManager.instance.SetState(AppState.MODIFY);
    }

    public override void ExitTool()
    {
        FinishedMovingImage.gameObject.SetActive(false);
        base.ExitTool();
    }
}


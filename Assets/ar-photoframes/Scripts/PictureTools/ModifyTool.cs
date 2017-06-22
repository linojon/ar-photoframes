using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyTool : PictureToolBase
{
    [SerializeField]
    private GameObject OptionRoot;


    void Start()
    {
        OptionRoot.gameObject.SetActive(false);
    }
    public override void InitTool(PictureFrame targetPictureFrame)
    {
        OptionRoot.gameObject.SetActive(true);
        base.InitTool(targetPictureFrame);
    }

    public override void UpdateTool()
    {
        
    }

    public override void ExitTool()
    {
        OptionRoot.gameObject.SetActive(false);
        base.ExitTool();
    }

}
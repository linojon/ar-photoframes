using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrefabOptionSelected : UnityEvent<GameObject>
{
}
public class FrameOption : MonoBehaviour {
  
        private GameObject prefabOption;
    public PrefabOptionSelected OnImageOptionSelected = new PrefabOptionSelected();

    void Start()
    {
        prefabOption = gameObject;
    }
        void OnMouseDown()
        {
        OnImageOptionSelected.Invoke(prefabOption);
        print("Prefab Selected");
        }
    
}

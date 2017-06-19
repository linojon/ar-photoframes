using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrefabOptionSelected : UnityEvent<GameObject>
{
}
public class FrameOption : MonoBehaviour {
  
        public GameObject PrefabOption;
        public PrefabOptionSelected OnImageOptionSelected = new PrefabOptionSelected();

        void OnMouseDown()
        {
            OnImageOptionSelected.Invoke(PrefabOption);
            print("Prefab Selected");
        }
    
}

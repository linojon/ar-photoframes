using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class FrameOption : MonoBehaviour {
  
        private GameObject prefabOption;
    

    void Start()
    {
        prefabOption = gameObject;
    }
        void OnMouseDown()
        {
          
            print("Prefab Selected");
        }
    
}

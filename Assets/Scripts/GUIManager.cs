using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GUIManager : MonoBehaviour
{
    public EventSystem ES;
    private GameObject StoreSelected;
    // Start is called before the first frame update
    void Start()
    {
        StoreSelected = ES.firstSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (ES.currentSelectedGameObject != StoreSelected)
        {
            if (ES.currentSelectedGameObject == null)
                ES.SetSelectedGameObject(StoreSelected);

            else
                StoreSelected = ES.currentSelectedGameObject;

        }

    }
}

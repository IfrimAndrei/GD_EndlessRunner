using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform parentToReturnTo = null;
    public GameObject minionField;

    public void OnBeginDrag(PointerEventData eventData)
    {
        minionField = GameObject.Find("PlayerMinionField");
        parentToReturnTo = this.transform.parent;
        //GetComponent < CanvasGroup > ().blockRaycast = false;
        Debug.Log("BeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        Debug.Log("Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(minionField.transform);
        
        //GetComponent < CanvasGroup > ().blockRaycast = true;
        Debug.Log("EndDrag");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

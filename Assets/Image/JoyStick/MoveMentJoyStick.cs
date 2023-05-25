using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveMentJoyStick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float radius;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        radius = joystickBG.GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        
    }

    public void positionDown(){
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;

    }

    public void Drag(BaseEventData baseEventData){
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDistance = Vector2.Distance(dragPos, joystickTouchPos);

        if(joystickDistance < radius){
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDistance;
        }
        else{
            joystick.transform.position = joystickTouchPos + joystickVec * radius;
        }
    }

    public void positionUp(){
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;

    }

    public void Update(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        if(horizontal != 0 || vertical != 0){
            joystickVec = new Vector2(horizontal, vertical);
        }

    }


}

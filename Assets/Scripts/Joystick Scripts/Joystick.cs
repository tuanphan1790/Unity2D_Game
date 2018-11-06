using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    private PlayerScript player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Button Left")
        {
            player.SetMoveLeft(true);
        }

        if(gameObject.name =="Button Right")
        {
            player.SetMoveRight(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.StopMoving();
    }
}

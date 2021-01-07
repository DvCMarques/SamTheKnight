using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum InputDir {
    Up,
    Down,
    Left,
    Right
}
public class InputSystem 
{
   
    IPlayerController playerController;
    RaycastHit2D rayHit;
    public InputSystem(Player player) {
        playerController = player.controller;
    }
    public void Update() {

        //Space Key Down
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerController.Jump();
        }

        //Left Mouse Button Down
        if (Input.GetMouseButtonDown(0)) {
            rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (rayHit) {
                if (rayHit.collider.CompareTag("Player")) {
                    playerController.Dead();
                }              
            }
        }

        //Right Mouse Button Down
        if (Input.GetMouseButtonDown(1)) {
            playerController.Attack();
        }

        //Left arrow key
        if (Input.GetKey(KeyCode.LeftArrow)) {
            playerController.Move(InputDir.Left);
        }
        
        //Right arrow key
        if (Input.GetKey(KeyCode.RightArrow)) {
            playerController.Move(InputDir.Right);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) ||Input.GetKeyUp(KeyCode.LeftArrow)) {
            playerController.StopMove();
        }
    }
}

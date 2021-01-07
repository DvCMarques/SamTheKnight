using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    InputSystem inputSystem;
    public Player player;
    private void Start() {
        inputSystem = new InputSystem(player);
    }

    private void Update() {
        inputSystem.Update();
    }
}

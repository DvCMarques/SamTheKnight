using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    Alive,
    Dead
}
public class Player : MonoBehaviour {
    public PlayerState playerState { get; protected set; }
    public IPlayerController controller { get;  protected set; }

    public void Die() {
        playerState = PlayerState.Dead;
    }

    protected virtual void Awake() {
        playerState = PlayerState.Alive;
    }
}

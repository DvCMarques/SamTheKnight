using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sam : Player {


    protected override void Awake() {
        base.Awake();
        controller = new SamController(
        this,
        GetComponent<Animator>(),
        GetComponent<Rigidbody2D>(),
        GetComponent<SpriteRenderer>()
        );
        playerState = PlayerState.Alive;
    }
}

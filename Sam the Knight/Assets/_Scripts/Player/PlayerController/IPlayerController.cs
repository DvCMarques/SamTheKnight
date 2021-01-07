using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerController
{
    void Move(InputDir dir);
    void StopMove();
    void Attack();
    void Jump();
    void Dead();
}

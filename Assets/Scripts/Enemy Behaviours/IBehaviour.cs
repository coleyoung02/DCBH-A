using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IBehaviour
{
    Action OnStateChanged {get; set;}
    bool IsActive {get; }
    void Tick();
}

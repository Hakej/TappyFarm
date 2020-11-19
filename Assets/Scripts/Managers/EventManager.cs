using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public event Action<Transform> onLeftClickDown;
    public void LeftClickDown(Transform hitTransform)
    {
        onLeftClickDown?.Invoke(hitTransform);
    }
}

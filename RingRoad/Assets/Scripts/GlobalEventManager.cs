using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnCoinPicked = new UnityEvent();
    public static UnityEvent ResetPoint = new UnityEvent();
    public static UnityEvent LoseEvent = new UnityEvent();
}

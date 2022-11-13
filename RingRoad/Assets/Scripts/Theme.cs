using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Theme", menuName = "RingRoad/Theme", order = 0)]
public class Theme : ScriptableObject
{
   public Color menuColor;
   public Color playerColor;
   public Color backColor;
   public Color circleColor;
   public Color enemyColor;
}

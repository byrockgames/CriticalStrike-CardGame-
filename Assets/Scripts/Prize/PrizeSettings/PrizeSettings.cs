using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Whell.Prize
{
 [CreateAssetMenu(fileName = "PrizeSettings", menuName = ("Wheel/PrizeSettings"))]
 public class PrizeSettings : ScriptableObject
 {
    public int StartIndex;
    
    [HideInInspector]
    public int WhellArrowPosition;
 } 
}


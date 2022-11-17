using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Whell
{
 [CreateAssetMenu (fileName = "WheelSettings", menuName =("Wheel/WhellSettings"))]
 public class WheelSettings : ScriptableObject
 {
    [Header("Whell System")]
    public float Angle;
    public float RotationSpeed;
    public float RotationDirection;
 }
}
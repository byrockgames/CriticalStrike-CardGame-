using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Whell
{
 public class WheelSystem : MonoBehaviour
 {
    [Header("Whell Settings Script")]
    [SerializeField]private Whell.WheelSettings WheelSettings;

    [Header("Animation Curve Whell")]
    [SerializeField]private List<AnimationCurve> WheelAnimation = new List<AnimationCurve>();

    [Header("Spining Verification")]
    [SerializeField]private bool Spining = false;

    [Header("Canvas Buttons")]
    [SerializeField] private Button Spin;
    
    private void Awake() 
    {
      WheelSettings.Angle = 495;

      Spin.onClick.AddListener(SpinController);
    }

   #region Spin Button
    void SpinController()
    {
      if(!Spining)
       {
          StartCoroutine(WheelFunction(WheelSettings.Angle, WheelSettings.RotationSpeed));
       }
    }
   
    IEnumerator WheelFunction(float EndValue, float Duration)
    {
       Spining = true;
       float time = 0f;

       float StartValue = transform.eulerAngles.z;

       int RandomAnimation = Random.Range(0, WheelAnimation.Count);

       while(time < Duration)
       {
         float ValueToChange = Mathf.Lerp(StartValue, EndValue, WheelAnimation[RandomAnimation].Evaluate(time / Duration));
         transform.eulerAngles = new Vector3(0, 0, ValueToChange);

         time += Time.deltaTime;
         yield return null;
       }

       transform.eulerAngles = new Vector3(0, 0, EndValue);
       Whell.Prize.PrizeSystem.instance.PrizeController();
       WheelSettings.Angle = (WheelSettings.RotationDirection) * 45 * Random.Range(10, 50);
       Spining = false;
    }

    #endregion
 }
}
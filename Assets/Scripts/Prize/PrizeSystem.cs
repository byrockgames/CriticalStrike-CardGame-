using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Whell.Prize
{
 public class PrizeSystem : MonoBehaviour
 {
    public static PrizeSystem instance;

    [Header("Whell Settings Script")]
    [SerializeField] private Whell.WheelSettings WheelSettings;

    [Header("Prize Settings")]
    [SerializeField]private Whell.Prize.PrizeSettings PrizeSettings;

    [Header("Prize List")]
    [SerializeField] private List<GameObject> Prize = new List<GameObject>();
    
    private void Awake() 
    {
      PrizeSettings.WhellArrowPosition = 8;

      for(int i = 0; i< Prize.Count; i++)
      {
        Prize[i].SetActive(false);
      }
    }
    private void Start() 
    {
      if(instance == null)
      {
        instance = this;
      }
    }
    public void PrizeController() 
    {
      int RealValue = (int)(WheelSettings.Angle) % 360;
      int DeviationValue = (int) RealValue / 45;
      PrizeSettings.WhellArrowPosition = ((PrizeSettings.StartIndex - DeviationValue) + 8) % 8;     
      StartCoroutine(PrizePanelController());     
    }

    IEnumerator PrizePanelController()
    {
      yield return new WaitForSeconds(1.5f);
      Prize[PrizeSettings.WhellArrowPosition].SetActive(true);
      PrizeSettings.WhellArrowPosition = 8;
    }
 }
}


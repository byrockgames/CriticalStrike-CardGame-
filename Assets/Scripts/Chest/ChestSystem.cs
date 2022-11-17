using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Chest
{
 public class ChestSystem : MonoBehaviour
 {
   public static ChestSystem instance;

   [Header("Chest")]
   [SerializeField]private GameObject[] ChestObjects;

   [SerializeField]private RectTransform[] UICard;

   [Header("Canvas Panel - Button")]
   [SerializeField]private GameObject ChestPanel;
   [SerializeField]private Button PanelOff;
   
   private void Awake() 
   {
     PanelOff.onClick.AddListener(PanelOffController);
   }
   private void Start() 
   {
     if(instance == null)
     {
       instance = this;
     }
   }
  private void OnEnable()   
   {  
      StartCoroutine(ItemController());
   }
   
   IEnumerator ItemController()
   {      
      foreach(var Item in ChestObjects)
      {
        Item.transform.localScale = Vector3.zero;
      }  

      foreach (var Item in ChestObjects)
      {      
        Item.transform.DOScale(1f, 2f).SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(1f);
       
      }

      foreach(var Card in UICard)
      {
        Card.transform.DOScale(1.25f, 1f).From();
        yield return new WaitForSeconds(0.3f);
      }
   }

   #region Panel Of
   void PanelOffController()
   {
     ChestPanel.SetActive(false);
   }
   #endregion
 }   
}


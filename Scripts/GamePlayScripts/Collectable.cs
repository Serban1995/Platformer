using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
   [SerializeField]
   private bool timeCollectable;

   [SerializeField] private float collectableValue = 15f;

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag(TagManager.PLAYER_TAG))
      {
         SoundManager.instance.Play_CollectableSound();
         
         if (timeCollectable)
         {
            GamePlayController.instance.IncreaseTime(collectableValue);
         }
         else
         {
            GamePlayController.instance.IncreaseAir(collectableValue);
         }
          gameObject.SetActive(false); 
      }
   }
}

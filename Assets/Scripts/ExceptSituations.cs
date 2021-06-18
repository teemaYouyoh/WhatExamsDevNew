using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExceptSituations : MonoBehaviour
{
  public int time = 0;    
  public GameObject afkPanel;
  public GameObject controlTab;
          
    void FixedUpdate () {

        try {

            if (!Input.anyKey)
            {
                time = time + 1;
            }
            else
            {
                time = 0; 
                afkPanel.SetActive(false);
            }

            if (time == 700) // Якщо гравець не рухаеться протягом 7 секунд ...
            {
                throw new Exception("Гравець не рухається"); // ... ми створюємо вийнятковк ситуація ...
                
            }

        } catch (Exception error) { // ... та оброблюємо ії в блоці catch
            afkPanel.SetActive(true); // Активація модального вікна з повідомленням про бездіяльність
            time = 0;
        }

    }

    void Update()
    {
        try {

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {                                                                               
               throw new Exception("Натиснуті клавіши не відповідають клавішам управління"); // Якщо гравець натистув клавішу не управління 
            }

        } catch (Exception error) { // Обробка вийняткової ситуації, якщо виникне якась системна помилка
            controlTab.SetActive(true); // Активація модального вікна з інструкцією по управлінню
            Time.timeScale = 0f; // Зупинка таймера 

            Debug.Log(error.Message);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape)) // Просто закрытие модального окна, это не исключительная ситуация
        {
            controlTab.SetActive(false);
        }
    }
}

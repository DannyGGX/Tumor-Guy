using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if(GameManager.Instance.InspectionScreenActive)
            {
                GameManager.Instance.CloseInspectionScreen();
            }
            else
            {
                GameManager.Instance.PauseToggle();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Die
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    [SerializeField] private TextMeshProUGUI TextComponent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        Cursor.visible = true;
        gameObject.SetActive(false);
    }


    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetAndShowTooltip(string text)
    {
        gameObject.SetActive(true);
        TextComponent.text = text;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}

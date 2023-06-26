using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private string text;

    private void OnMouseEnter()
    {
        TooltipManager.Instance.SetAndShowTooltip(text);
    }

    private void OnMouseExit()
    {
        TooltipManager.Instance.HideTooltip();
    }
}

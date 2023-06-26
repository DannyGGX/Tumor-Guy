using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InspectionScreen : MonoBehaviour
{
    public static InspectionScreen Instance;
    [SerializeField] private InspectionImage[] InspectionItems;
    private ItemIDs[] inspectionItemIDs;
    private GameObject currentInspectionItem;

    [SerializeField] private GameObject exitButton;

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

        CacheItemIDs();
    }
    private void CacheItemIDs()
    {
        inspectionItemIDs = new ItemIDs[InspectionItems.Length];
        for (int i = 0; i < InspectionItems.Length; i++)
        {
            inspectionItemIDs[i] = InspectionItems[i].ItemID;
        }
    }

    public void ShowInspectionItem(ItemIDs item)
    {
        int index = Array.FindIndex(inspectionItemIDs, x => x == item);
        currentInspectionItem = InspectionItems[index].ImageObject;

        ToggleVisibility(true);
        GameManager.Instance.PauseToggle();
    }

    public void CloseInspectionScreen()
    {
        ToggleVisibility(false);
        GameManager.Instance.PauseToggle();
    }

    private void ToggleVisibility(bool isVisable)
    {
        currentInspectionItem.SetActive(isVisable);
        exitButton.SetActive(isVisable);
        GameManager.Instance.InspectionScreenActive = isVisable;
    }
}

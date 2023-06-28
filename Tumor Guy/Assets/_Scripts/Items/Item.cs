using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemIDs itemID;

    private void OnMouseDown()
    {
        ItemInteract();
    }

    public virtual void ItemInteract()
    {
        InspectionScreen.Instance.ShowInspectionItem(itemID);
    }
}

public enum ItemIDs
{
    ChildLetter,
    TumorObservations,
    RebellingNote,
    MapNote,

    SolitaryKey,
    Keycard,

    OfficeTapeRecorder,
}

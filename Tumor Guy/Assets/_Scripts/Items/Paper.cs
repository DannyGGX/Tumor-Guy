using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : Item
{
    [field: SerializeField] public PaperIDs PaperID;

    public override void ItemInteract()
    {
        base.ItemInteract();
        AudioManager.Instance.PlaySoundEffect(SoundNames.PickUpPaper);
    }
}



public enum PaperIDs
{
    ChildLetter,
    Observations,
    RebelNote,
    Map,
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    [field: SerializeField] public KeyIDs KeyID;

    public override void ItemInteract()
    {
        base.ItemInteract();
        if(KeyID == KeyIDs.Keycard)
        {
            AudioManager.Instance.PlaySound(SoundNames.PickUpKeycard);
        }
        else
        {
            AudioManager.Instance.PlaySound(SoundNames.PickUpKey);
        }
        GameManager.Instance.FoundKeys.Add(KeyID);
        TooltipManager.Instance.HideTooltip();
        Destroy(gameObject);
    }
}

public enum KeyIDs
{
    SolitaryKey,
    Keycard,
}

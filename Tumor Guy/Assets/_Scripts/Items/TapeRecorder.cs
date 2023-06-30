using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeRecorder : Item
{
    public override void ItemInteract()
    {
        AudioManager.Instance.PlaySoundEffect(SoundNames.ScientistVoiceTape);
    }
}

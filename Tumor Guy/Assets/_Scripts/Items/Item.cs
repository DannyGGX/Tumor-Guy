using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [field: SerializeField] public AudioClip InteractionSound;
    //[field: SerializeField] public Canvas InspectionImageCanvas;
    //[field: SerializeField] public GameObject InspectionImage;
}

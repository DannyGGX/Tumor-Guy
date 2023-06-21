using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : Item
{
    [field: SerializeField] public PaperIDs PaperID;
}

public enum PaperIDs
{
    ChildDrawing,
    ChildLetter,
    Map,
}

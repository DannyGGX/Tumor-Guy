using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    [field: SerializeField] public KeyIDs KeyID;

}

public enum KeyIDs
{
    Key1,
    Key2,
    MapKey,
    KeyCard
}

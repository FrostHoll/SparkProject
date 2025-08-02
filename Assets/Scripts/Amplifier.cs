using UnityEngine;
using System.Collections;

public struct Amplifier
{
    public StatType Type;
    public float Value;
    public bool IsFlat;

    public Amplifier(StatType type, float value, bool isFlat)
    {
        Type = type;
        Value = value;
        IsFlat = isFlat;
    }
}

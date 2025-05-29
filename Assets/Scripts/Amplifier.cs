using UnityEngine;
using System.Collections;

// HOW TO USE THIS FUCKIN SHIT OLEG VALERYEVICH?????? WHAT DID YOU MEAN BRO WITH THIS STRUCT

public struct Amplifier
{
    StatType Type;
    float Value;
    bool IsFlat;

    public Amplifier(StatType type, float value, bool isFlat)
    {
        Type = type;
        Value = value;
        IsFlat = isFlat;
    }
}

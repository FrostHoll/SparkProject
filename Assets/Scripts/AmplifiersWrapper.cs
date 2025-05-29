using System.Collections.Generic;
using UnityEngine;

public class AmplifiersWrapper : MonoBehaviour
{
    private Dictionary<StatType, List<float>> _additiveAmps = new Dictionary<StatType, List<float>>();
    private Dictionary<StatType, List<float>> _multiplicativeAmps = new Dictionary<StatType, List<float>>();

    public Dictionary<StatType, List<float>> addAmps => _additiveAmps;
    public Dictionary<StatType, List<float>> multAmps => _multiplicativeAmps;

    public void AddAmplifier(StatType type, float value, bool isFlat)
    {
        var targetDict = isFlat ? addAmps : multAmps;

        if (!targetDict.ContainsKey(type))
            targetDict[type] = new List<float>();

        targetDict[type].Add(value);
    }

    public void RemoveAmplifier(StatType type, float value, bool isFlat)
    {
        var targetDict = isFlat ? addAmps : multAmps;

        if (targetDict.TryGetValue(type, out var amps))
            amps.Remove(value);
    }
}
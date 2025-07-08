using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AmplifiersWrapper
{
    private Dictionary<StatType, List<float>> _additiveAmps = new Dictionary<StatType, List<float>>();
    private Dictionary<StatType, List<float>> _multiplicativeAmps = new Dictionary<StatType, List<float>>();


    public void AddAmplifier(Amplifier amp)
    {
        var targetDict = amp.IsFlat ? _additiveAmps : _multiplicativeAmps; //по флажку определяем, в какой словарик добавить усилитель

        if (!targetDict.ContainsKey(amp.Type)) //если в словарике ещё нет опр типа, то мы создаём список для нового типа стата
            targetDict[amp.Type] = new List<float>();

        targetDict[amp.Type].Add(amp.Value);
    }

    public void RemoveAmplifier(Amplifier amp)
    {
        var targetDict = amp.IsFlat ? _additiveAmps : _multiplicativeAmps;

        if (targetDict.TryGetValue(amp.Type, out var amps))
            amps.Remove(amp.Value);
    }

    public float GetModifiedValue(StatType type, float baseValue) //пересчёт определённого типа статов
    {
        float additive = _additiveAmps.TryGetValue(type, out var addAmps) ? addAmps.Sum() : 0f;
        float multiplicative = _multiplicativeAmps.TryGetValue(type, out var multAmps) ? 1f + multAmps.Sum() : 1f;

        return (baseValue + additive) * multiplicative;
    }
}
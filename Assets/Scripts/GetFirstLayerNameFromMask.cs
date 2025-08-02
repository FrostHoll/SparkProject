using UnityEngine;

public static class GetFirstLayerNameFromMask
{
    public static string GetFirstLayerNameFromMaskk(LayerMask mask)
    {
        for (int i = 0; i < 32; i++)
        {
            int layerBit = 1 << i;
            if ((mask.value & layerBit) != 0)
            {
                string layerName = LayerMask.LayerToName(i);

                if (!string.IsNullOrEmpty(layerName))
                {
                    return layerName;
                }
            }
        }
        return "";
    }
}

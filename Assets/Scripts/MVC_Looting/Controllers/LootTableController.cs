using UnityEngine;

public class LootTableController
{
    private LootTableModel _model = new();
    
    public GameObject GetRandomItem()
    {
        return _model.GetRandomItem();
    }
}
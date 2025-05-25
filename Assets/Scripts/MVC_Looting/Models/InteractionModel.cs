public class InteractionModel
{
    public InteractableController NearestItem = null;
    public float MinDistance = float.MaxValue;

    public void SetNearestItem(InteractableController item, float distance)
    {
        if (distance < MinDistance)
        {
            NearestItem = item;
            MinDistance = distance;
        }
    }

    public void ResetNearestItem()
    {
        NearestItem = null;
        MinDistance = float.MaxValue;
    }
}
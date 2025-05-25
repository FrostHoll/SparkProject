using UnityEngine;

public class InteractionController : MonoBehaviour
{
    
    private InteractionModel _model = new();
    private void OnTriggerExit(Collider other)
    {
        _model.ResetNearestItem();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<InteractableController>(out var interactable))
        {
            //Debug.Log("Объект! " + other.gameObject.name);
            var distance = Vector3.Distance(transform.position, other.gameObject.transform.position);
            
            _model.SetNearestItem(interactable, distance);
        }
    }
    
    
    public void Interact()
    {
        if (_model.NearestItem != null)
        {
            _model.NearestItem.Interact();
        }
    }
}
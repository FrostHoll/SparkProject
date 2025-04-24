using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen;

    public Vector3 targetPos;

    private Vector3 initPos;

    public Transform doorObject;

    private void Start()
    {
        initPos = doorObject.localPosition;
    }

    public void ToggleOpen()
    {
        if (isOpen)
        {
            doorObject.localPosition = initPos;
            isOpen = false;
        }
        else
        {
            doorObject.localPosition = targetPos;
            isOpen = true;
        }
    }
}

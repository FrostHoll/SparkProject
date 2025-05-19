

using UnityEngine;

public interface IInteractable
{
    void Interact();
} 
public interface IWhoIsUser // Прикопался, теперь мне уже не нравится, как это выглядит с доп проверками и прочим.
{
    GameObject Player { get; set; }
}


using UnityEngine;

public interface IInteractable
{
    void Interact();
} 
public interface IWhoIsUser // ����������, ������ ��� ��� �� ��������, ��� ��� �������� � ��� ���������� � ������.
{
    GameObject Player { get; set; }
}
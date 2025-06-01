using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject selectionPanel; // GameStart ������Ʈ �巡�� ����

    public void OnSelectCharacter0()
    {
        SelectCharacter(0);
    }

    public void OnSelectCharacter1()
    {
        SelectCharacter(1);
    }

    public void OnSelectCharacter2()
    {
        SelectCharacter(2);
    }

    public void OnSelectCharacter3()
    {
        SelectCharacter(3);
    }

    private void SelectCharacter(int id)
    {
        selectionPanel.SetActive(false); // ? ĳ���� ���� UI �����
        GameManager.Instance.GameStart(id); // ���� ����
    }
}


using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject selectionPanel; // GameStart 오브젝트 드래그 연결

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
        selectionPanel.SetActive(false); // ? 캐릭터 선택 UI 숨기기
        GameManager.Instance.GameStart(id); // 게임 시작
    }
}


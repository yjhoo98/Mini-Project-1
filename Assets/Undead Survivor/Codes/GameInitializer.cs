using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject characterSelectionPanel;

    void Start()
    {
        if (string.IsNullOrEmpty(SessionData.userId))
        {
            Debug.LogWarning("�α��� ���� ���Ӿ� ����");
            return;
        }

        characterSelectionPanel.SetActive(true);
    }

    public void OnCharacterSelected(int id)
    {
        SessionData.characterId = id;
        characterSelectionPanel.SetActive(false);

        GameManager.Instance.GameStart(id);
    }
}

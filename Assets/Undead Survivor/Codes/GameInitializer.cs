using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject characterSelectionPanel;

    void Start()
    {
        if (string.IsNullOrEmpty(SessionData.userId))
        {
            Debug.LogWarning("로그인 없이 게임씬 진입");
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

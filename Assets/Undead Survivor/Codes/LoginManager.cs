using Firebase.Auth;
using Firebase.Extensions;
using TMPro;
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    [Header("UI ����")]
    public TMP_InputField inputEmail;
    public TMP_InputField inputPassword;
    public GameObject loginPanel;
    public GameObject characterGroup; // ĳ���� ���� UI

    private string userId;

    public void OnLoginButtonClick()
    {
        string email = inputEmail.text.Trim();
        string password = inputPassword.text.Trim();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Debug.LogWarning("? �̸��� �Ǵ� ��й�ȣ�� ��� �ֽ��ϴ�.");
            return;
        }

        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogWarning("? �α��� ���� �� ȸ������ �õ�");

                auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(regTask =>
                {
                    if (regTask.IsCanceled || regTask.IsFaulted)
                    {
                        Debug.LogError("? ȸ������ ����: " + regTask.Exception?.Message);
                    }
                    else
                    {
                        Debug.Log("? ȸ������ ����!");
                        userId = regTask.Result.User.UserId;
                        ShowCharacterSelection(userId);
                    }
                });
            }
            else
            {
                Debug.Log("? �α��� ����!");
                userId = task.Result.User.UserId;
                ShowCharacterSelection(userId);
            }
        });
    }

    private void ShowCharacterSelection(string uid)
    {
        GameManager.Instance.SetUser(uid); // UID�� GameManager�� ����
        loginPanel.SetActive(false);
        characterGroup.SetActive(true);   // ĳ���� ���� UI Ȱ��ȭ
    }

    public void OnCharacterSelected(int index)
    {
        GameManager.Instance.SetCharacterId(index); // ���õ� ĳ���� ID ����
    }
}

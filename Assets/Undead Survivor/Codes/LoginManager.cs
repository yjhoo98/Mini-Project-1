using Firebase.Auth;
using Firebase.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField inputEmail;
    public TMP_InputField inputPassword;

    public void OnLoginButtonClick()
    {
        string email = inputEmail.text.Trim();
        string password = inputPassword.text.Trim();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Debug.LogWarning("�̸��� �Ǵ� ��й�ȣ�� ��� �ֽ��ϴ�.");
            return;
        }

        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email, password)
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {
                    Debug.LogError("�α��� ����: " + task.Exception);
                    return;
                }

                SessionData.userId = task.Result.User.UserId;
                SceneManager.LoadScene("GameScene"); // ĳ���� ������ GameScene����
            });
    }
}


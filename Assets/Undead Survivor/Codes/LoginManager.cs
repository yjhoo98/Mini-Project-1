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
            Debug.LogWarning("이메일 또는 비밀번호가 비어 있습니다.");
            return;
        }

        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email, password)
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {
                    Debug.LogError("로그인 실패: " + task.Exception);
                    return;
                }

                SessionData.userId = task.Result.User.UserId;
                SceneManager.LoadScene("GameScene"); // 캐릭터 선택은 GameScene에서
            });
    }
}


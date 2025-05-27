using Firebase;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseInit : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                FirebaseApp app = FirebaseApp.DefaultInstance;

                // ? �� ���� �ʼ��Դϴ�
                app.Options.DatabaseUrl = new System.Uri("https://undeadsurvivor-77af8-default-rtdb.firebaseio.com/");

                Debug.Log("? Firebase �ʱ�ȭ ����");
            }
            else
            {
                Debug.LogError("? Firebase �ʱ�ȭ ����: " + task.Result);
            }
        });
    }
}

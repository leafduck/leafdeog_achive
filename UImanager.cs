using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour// 여기에서는 함수구현만 하고, 싱글턴패턴으로 구한한 함수를 외부에서 가져다쓸거임
{    
    public static UImanager _instance;
    public text noattion ;//화면 중앙에 띄울 작은 알림
     // 외부에서 싱글톤에 접근할 때 사용할 프로퍼티
    public static MySingleton Instance
    {
        get
        {
            // 인스턴스가 없으면 새로 생성
            if (_instance == null)
            {
                // 씬에서 싱글톤 오브젝트를 찾아봅니다.
                _instance = FindObjectOfType<MySingleton>();

                // 씬에 없으면 새로 생성
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("MySingleton");
                    _instance = singletonObject.AddComponent<MySingleton>();
                }
            }

            return _instance;
        }
    }
    
    void Awake(){
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // 처음 생성된 인스턴스를 저장
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }    
    }
    
    






}
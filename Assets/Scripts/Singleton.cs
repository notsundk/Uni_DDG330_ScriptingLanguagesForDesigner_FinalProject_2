using UnityEngine;

// Make object a Singleton
// Currently used on: "Sound_Parent"

public class Singleton : MonoBehaviour
{

    static Object instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}

using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    bool isInit = false;
    
    void Start()
    {
        if (!this.isInit)
        {
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
        this.isInit = true;
    }

}

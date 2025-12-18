using UnityEngine;

public class Unico<T> : MonoBehaviour where T : Unico<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destruir instâncias duplicadas
            return;
        }

        instance = (T)this;
        DontDestroyOnLoad(gameObject); // Manter o objeto vivo entre as cenas
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}

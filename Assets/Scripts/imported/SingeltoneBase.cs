using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class SingeltoneBase<T> : MonoBehaviour where T : MonoBehaviour
{

    [Header("Singeltone")]
    [SerializeField] private bool m_DoNotDerstoyOnLoad;

    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if(Instance != null)
        {
         //   Debug.LogWarning("MonoSingelton: object type already exists, instave will be destoyed = " + typeof(T).Name);
            Destroy(this);
            return;
        }

        Instance = this as T;

        if (m_DoNotDerstoyOnLoad) DontDestroyOnLoad(gameObject);
    }
}

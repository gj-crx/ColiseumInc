using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PrefabManager : MonoBehaviour
{
    public static List<GameObject> BulletPrefabs = new List<GameObject>();

    [SerializeField] private List<GameObject> bulletPrefabs;

    private void Update()
    {
        #if UNITY_EDITOR
            ApplyPrefabs();
        #endif
    }

    private void ApplyPrefabs()
    {
        BulletPrefabs = bulletPrefabs;
    }
}

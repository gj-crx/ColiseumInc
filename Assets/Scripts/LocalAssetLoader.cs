using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LocalAssetLoader
{
    private GameObject cachedObject;

    protected GameObject CachedObject { get { return cachedObject; } }

    public async Task<GameObject> LoadPrefab(string assetID)
    {
        var handle = Addressables.InstantiateAsync(assetID);
        cachedObject =  await handle.Task;
        return cachedObject;
    }

    public void UnloadCachedObject()
    {
        if (cachedObject == null) return;

        cachedObject.SetActive(false);
        Addressables.ReleaseInstance(cachedObject);
        cachedObject = null;
    }
}

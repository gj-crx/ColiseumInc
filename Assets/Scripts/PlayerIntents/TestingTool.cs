using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingTool : MonoBehaviour
{
    public string AssetID;

    private LocalAssetLoader shitloader = new LocalAssetLoader();

    [ContextMenu("Perform testing")]
    private async void Test()
    {
        await shitloader.LoadPrefab(AssetID);

    }
}

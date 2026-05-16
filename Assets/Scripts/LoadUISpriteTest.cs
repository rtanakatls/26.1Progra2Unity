using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class LoadUISpriteTest : MonoBehaviour
{
    [SerializeField] private string spriteAddress;
    private AsyncOperationHandle<Sprite> handle;

    private async void Start()
    {
        handle = Addressables.LoadAssetAsync<Sprite>(spriteAddress);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GetComponent<Image>().sprite = handle.Result;
        }
    }

    private void OnDestroy()
    {
        Addressables.Release(handle);
    }


}

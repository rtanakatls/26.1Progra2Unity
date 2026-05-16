using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class LoadUISpriteByReferenceTest : MonoBehaviour
{
    [SerializeField] private AssetReferenceSprite spriteReference;
    private Sprite loadedSprite;

    private async void Start()
    {

        loadedSprite = await spriteReference.LoadAssetAsync<Sprite>().Task;
        GetComponent<Image>().sprite = loadedSprite;
    }

    private void OnDestroy()
    {
        spriteReference.ReleaseAsset();
    }

}

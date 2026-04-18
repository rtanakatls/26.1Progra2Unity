using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private GenericRuntimeGraph dialogGraph;
    public void DisplayText(string text)
    {
            dialogText.text = text;
    }

    private void Start()
    {
        Resolve();
    }

    private async void Resolve()
    {
        await Task.Yield();
        INodeResolver<TextRuntimeNode> textResolver = new TextResolver();

        foreach(GenericRuntimeNode node in dialogGraph.nodes)
        {
            switch(node)
            {
                case TextRuntimeNode textNode:
                    await textResolver.Resolve(this, textNode);
                    break;
            }
        }
    }
}

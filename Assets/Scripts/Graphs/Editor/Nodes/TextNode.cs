using System;
using UnityEngine;

[Serializable]
public class TextNode : GenericNode
{
    public static readonly string INPUT_PORT_TEXT = "Text";
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort(INPUT_PORT_NAME).Build();
        context.AddInputPort<string>(INPUT_PORT_TEXT).Build();

        context.AddOutputPort(OUTPUT_PORT_NAME).Build();
    }
}

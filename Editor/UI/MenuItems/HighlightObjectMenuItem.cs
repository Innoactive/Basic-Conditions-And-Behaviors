using Innoactive.Creator.Core.Behaviors;
using Innoactive.CreatorEditor.UI;
using UnityEngine;

namespace Innoactive.CreatorEditor.Core.UI.Behaviors
{
    /// <summary>
    /// Menu item which shows <see cref="HighlightObjectBehavior"/> in the step inspector.
    /// </summary>
    public class HighlightObjectMenuItem : StepInspectorMenu.Item<IBehavior>
    {
        /// <inheritdoc />
        public override GUIContent DisplayedName
        {
            get { return new GUIContent("Highlight Object"); }
        }

        /// <inheritdoc />
        public override IBehavior GetNewItem()
        {
            return new HighlightObjectBehavior();
        }
    }
}

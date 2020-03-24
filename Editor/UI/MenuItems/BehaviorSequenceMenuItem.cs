using Innoactive.Creator.Core.Behaviors;
using Innoactive.CreatorEditor.UI;
using UnityEngine;

namespace Innoactive.CreatorEditor.Core.UI.Behaviors
{
    /// <summary>
    /// Menu item which shows <see cref="BehaviorSequence"/> in the step inspector.
    /// </summary>
    public class BehaviorSequenceMenuItem : StepInspectorMenu.Item<IBehavior>
    {
        /// <inheritdoc />
        public override GUIContent DisplayedName
        {
            get
            {
                return new GUIContent("Behaviors Sequence");
            }
        }

        /// <inheritdoc />
        public override IBehavior GetNewItem()
        {
            return new BehaviorSequence();
        }
    }
}

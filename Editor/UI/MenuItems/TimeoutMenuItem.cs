using Innoactive.Creator.Core.Conditions;
using Innoactive.CreatorEditor.UI;
using UnityEngine;

namespace Innoactive.CreatorEditor.Core.UI.Conditions
{
    /// <summary>
    /// Menu item which shows <see cref="TimeoutCondition"/> in the step inspector.
    /// </summary>
    public class TimeoutMenuItem : StepInspectorMenu.Item<ICondition>
    {
        /// <inheritdoc />
        public override GUIContent DisplayedName
        {
            get { return new GUIContent("Timeout"); }
        }

        /// <inheritdoc />
        public override ICondition GetNewItem()
        {
            return new TimeoutCondition();
        }
    }
}

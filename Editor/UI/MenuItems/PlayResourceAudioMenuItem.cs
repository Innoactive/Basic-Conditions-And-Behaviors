using Innoactive.Creator.Core.Audio;
using Innoactive.Creator.Core.Behaviors;
using Innoactive.Creator.Core.Internationalization;
using Innoactive.CreatorEditor.UI;
using UnityEngine;

namespace Innoactive.CreatorEditor.Core.UI.Behaviors
{
    /// <summary>
    /// Menu item which shows <see cref="PlayAudioBehavior"/> using a <see cref="ResourceAudio"/> in the step inspector.
    /// </summary>
    public class PlayResourceAudioMenuItem : StepInspectorMenu.Item<IBehavior>
    {
        /// <inheritdoc />
        public override GUIContent DisplayedName
        {
            get
            {
                return new GUIContent("Audio/Play Audio File");
            }
        }

        /// <inheritdoc />
        public override IBehavior GetNewItem()
        {
            return new PlayAudioBehavior(new ResourceAudio(new LocalizedString()), BehaviorExecutionStages.Activation, true);
        }
    }
}

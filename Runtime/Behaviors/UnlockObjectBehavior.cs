﻿using System.Runtime.Serialization;
using Innoactive.Creator.Core.Attributes;
using Innoactive.Creator.Core.SceneObjects;
using Innoactive.Creator.Core.Utils;

namespace Innoactive.Creator.Core.Behaviors
{
    /// <summary>
    /// Behavior that unlocks the target SceneObject while active, and locks it again on deactivation (unless it was not locked initially)
    /// </summary>
    [DataContract(IsReference = true)]
    public class UnlockObjectBehavior : Behavior<UnlockObjectBehavior.EntityData>
    {
        /// <summary>
        /// The "unlock object" behavior's data.
        /// </summary>
        [DisplayName("Unlock Object")]
        [DataContract(IsReference = true)]
        public class EntityData : IBehaviorData
        {
            /// <summary>
            /// The object to unlock.
            /// </summary>
            [DataMember]
            [DisplayName("Object to unlock")]
            public SceneObjectReference Target { get; set; }

            /// <summary>
            /// If set to true, it will lock the target at the end of the step.
            /// </summary>
            [DataMember]
            [DisplayName("Unlock only during this step")]
            public bool IsOnlyUnlockedInStep { get; set; }

            public bool WasLockedOnActivate { get; set; }

            /// <inheritdoc />
            public Metadata Metadata { get; set; }

            /// <inheritdoc />
            public string Name { get; set; }
        }

        private class ActivatingProcess : InstantProcess<EntityData>
        {
            /// <inheritdoc />
            public override void Start()
            {
                Data.WasLockedOnActivate = Data.Target.Value.IsLocked;
                if (Data.WasLockedOnActivate)
                {
                    Data.Target.Value.SetLocked(false);
                }
            }

            public ActivatingProcess(EntityData data) : base(data)
            {
            }
        }

        private class DeactivatingProcess : InstantProcess<EntityData>
        {
            /// <inheritdoc />
            public override void Start()
            {
                if (Data.WasLockedOnActivate && Data.IsOnlyUnlockedInStep)
                {
                    Data.Target.Value.SetLocked(true);
                }
            }

            public DeactivatingProcess(EntityData data) : base(data)
            {
            }
        }

        public UnlockObjectBehavior() : this("")
        {
        }

        public UnlockObjectBehavior(ISceneObject target) : this(TrainingReferenceUtils.GetNameFrom(target))
        {
        }

        public UnlockObjectBehavior(ISceneObject target, bool isOnlyUnlockedInStep) : this(TrainingReferenceUtils.GetNameFrom(target), isOnlyUnlockedInStep: isOnlyUnlockedInStep)
        {
        }

        public UnlockObjectBehavior(string targetName, string name = "Unlock Object", bool isOnlyUnlockedInStep = true)
        {
            Data.Target = new SceneObjectReference(targetName);
            Data.Name = name;
            Data.IsOnlyUnlockedInStep = isOnlyUnlockedInStep;
        }

        /// <inheritdoc />
        public override IProcess GetActivatingProcess()
        {
            return new ActivatingProcess(Data);
        }

        /// <inheritdoc />
        public override IProcess GetDeactivatingProcess()
        {
            return new DeactivatingProcess(Data);
        }
    }
}

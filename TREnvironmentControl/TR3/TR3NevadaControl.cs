using System.Collections.Generic;
using TREnvironmentEditor;
using TREnvironmentEditor.Helpers;
using TREnvironmentEditor.Model;
using TREnvironmentEditor.Model.Conditions;
using TREnvironmentEditor.Model.Types;
using TRFDControl;
using TRLevelReader.Helpers;
using TRLevelReader.Model;
using TRLevelReader.Model.Enums;

namespace TREnvironmentControl
{
    public class TR3NevadaControl : BaseTR3Control
    {
        public override string Level => TR3LevelNames.NEVADA;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TR3Level level = GetTR3Level(Level);

            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if an alternative ending for cold Nevada is needed to avoid softlock.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 68,
                        EntityType = (short)TR3Entities.UPV
                    },
                    OnTrue = new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Raise trapdoor 121 by default.",
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 121,
                            Flags = 0
                        },
                        //new EMRemoveEntityTriggersFunction
                        //{
                        //    Comments = "Remove the trapdoor triggers, except the dummy.",
                        //    EMType = EMType.RemoveEntityTriggers,
                        //    Entities = new List<int> { 121 },
                        //    ExcludedTypes = new List<FDTrigType> { FDTrigType.Dummy },
                        //},
                        new EMConvertEntityFunction
                        {
                            Comments = "Convert the UPV into a pushblock.",
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 68,
                            NewEntityType = (short)TR3Entities.PushableBlock1,
                        },
                        new EMModifyEntityFunction
                        {
                            Comments = "Hide the pushblock.",
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 68,
                            Flags = 256
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the pushblock to the fence at the end.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 68,
                            TargetLocation = new EMLocation
                            {
                                X = 74240,
                                Y = -5120-2048,
                                Z = 79360,
                                Room = 143,
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Boulder/heavy trigger for activating the pushblock.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TR3Entities.RollingBallOrBarrel,
                            Location = new EMLocation
                            {
                                X = 75264-2048,
                                Y = 2560,
                                Z = 87552,
                                Room = 146,
                                Angle = 16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 75264-1024,
                                    Y = 2560,
                                    Z = 87552,
                                    Room = 146,
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.HeavyTrigger,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 68
                                    }
                                }
                            }
                        },
                        new EMCameraTriggerFunction
                        {
                            Comments = "Add a camera hint.",
                            EMType = EMType.CameraTriggerFunction,
                            AttachToLocations = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 75264-1024,
                                    Y = 2560,
                                    Z = 87552,
                                    Room = 146,
                                }
                            },
                            Camera = new TRCamera
                            {
                                X = 67094,
                                Y = -992,
                                Z = 72596,
                                Room = 144,
                            },
                            LookAtItem = 68,
                            CameraAction = new FDCameraAction
                            {
                                Timer = 10,
                            }
                        },
                        new EMAppendTriggerActionFunction
                        {
                            Comments = "Trigger the boulder from switch 80.",
                            EMType = EMType.AppendTriggerActionFunction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 52736,
                                    Y = -3072,
                                    Z = 61952,
                                    Room = 114,
                                },
                            },
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            }
                        },
                    }
                }
            };

            mapping.Mirrored = new EMEditorSet
            {
                new EMConvertEntityFunction
                {
                    Comments = "Convert two of the planes to the other kind.",
                    EMType = EMType.ConvertEntity,
                    EntityIndex = 8,
                    NewEntityType = (short)TR3Entities.Animating3
                },
                new EMConvertEntityFunction
                {
                    EMType = EMType.ConvertEntity,
                    EntityIndex = 113,
                    NewEntityType = (short)TR3Entities.Animating3
                }
            };

            WriteMapping(mapping);
        }
    }
}

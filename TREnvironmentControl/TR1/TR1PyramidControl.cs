using System.Collections.Generic;
using TREnvironmentEditor;
using TREnvironmentEditor.Helpers;
using TREnvironmentEditor.Model;
using TREnvironmentEditor.Model.Conditions;
using TREnvironmentEditor.Model.Types;
using TRFDControl;
using TRFDControl.FDEntryTypes;
using TRLevelReader.Helpers;
using TRLevelReader.Model;
using TRLevelReader.Model.Enums;
using TRRandomizerCore.Helpers;
using TRRandomizerCore.Secrets;

namespace TREnvironmentControl
{
    public class TR1PyramidControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.PYRAMID;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);

            mapping.NonPurist = new EMEditorSet
            {
                new EMRefaceFunction
                {
                    Comments = "Fix the out of place texture in room 2.",
                    EMType = EMType.Reface,
                    TextureMap = new EMTextureMap
                    {
                        [level.Rooms[2].RoomData.Rectangles[89].Texture] = new EMGeometryMap
                        {
                            [2] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 65 }
                            }
                        }
                    }
                },
                new EMAddFaceFunction
                {
                    Comments = "Add a missing face at the very end of the level.",
                    EMType = EMType.AddFace,
                    Quads = new Dictionary<short, List<TRFace4>>
                    {
                        [66] = new List<TRFace4>
                        {
                            new TRFace4
                            {
                                Texture = level.Rooms[66].RoomData.Rectangles[20].Texture,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[66].RoomData.Rectangles[14].Vertices[1],
                                    level.Rooms[66].RoomData.Rectangles[3].Vertices[0],
                                    level.Rooms[66].RoomData.Rectangles[3].Vertices[3],
                                    level.Rooms[66].RoomData.Rectangles[14].Vertices[2],
                                }
                            }
                        }
                    }
                },
                new EMConvertEntityFunction
                {
                    Comments = "Convert Adam's door into the same style as the one in Atlantis.",
                    EMType = EMType.ConvertEntity,
                    EntityIndex = 86,
                    NewEntityType = (short)TREntities.Door1
                },
                new EMSlantFunction
                {
                    Comments= "Fix the bad geometry in room 25.",
                    EMType = EMType.Slant,
                    SlantType= FDSlantEntryType.CeilingSlant,
                    XSlant = 0,
                    ZSlant = 2,
                    CeilingClicks = -2,
                    Location = new EMLocation
                    {
                        X = 30208,
                        Y = -3584,
                        Z = 45568,
                        Room = 25
                    }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Modify faces to fit above.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 25,
                            FaceIndices = new int[] { 91,93 },
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = -512
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 25,
                            FaceIndices = new int[] { 91 },
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [2] = new TRVertex
                                {
                                    Y = 512
                                }
                            }
                        }
                    }
                },
                new EMAddFaceFunction
                {
                    Comments = "Patch gaps for above.",
                    EMType = EMType.AddFace,
                    Triangles = new Dictionary<short, List<TRFace3>>
                    {
                        [25] = new List<TRFace3>
                        {
                            new TRFace3
                            {
                                Texture = 60,
                                Vertices = new ushort[]
                                {

                                    level.Rooms[25].RoomData.Rectangles[105].Vertices[3],
                                    (ushort)level.Rooms[25].RoomData.Vertices.Length,
                                    level.Rooms[25].RoomData.Rectangles[105].Vertices[0],
                                }
                            },
                            new TRFace3
                            {
                                Texture = 60,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[25].RoomData.Rectangles[87].Vertices[1],
                                    level.Rooms[25].RoomData.Rectangles[105].Vertices[0],
                                    (ushort)(level.Rooms[25].RoomData.Vertices.Length+2),
                                }
                            }
                        }
                    }
                }
            };
            mapping.All = new EMEditorSet
            {

            };

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMMoveEntityFunction
                    {
                        Comments = "Move dart 24.",
                        EMType = EMType.MoveEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EntityIndex = 24,
                        TargetLocation = new EMLocation
                        {
                            X = 46592,
                            Y = -13312,
                            Z = 22016,
                            Room = 20,
                            Angle = -32768
                        }
                    },
                },
                new EMEditorSet
                {
                    new EMConvertEntityFunction
                    {
                        Comments = "Convert the unused Atlantis lever into spikes.",
                        EMType = EMType.ConvertEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EntityIndex = 109,
                        NewEntityType = (short)TREntities.TeethSpikes,
                    },
                    new EMMoveEntityFunction
                    {
                        Comments = "Move them elsewhere.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 109,
                        TargetLocation = new EMLocation
                        {
                            X = 47616,
                            Y = -10752,
                            Z = 30208,
                            Room = 21,
                        }
                    },
                },
                new EMEditorSet
                {
                    new EMConvertEntityFunction
                    {
                        Comments = "Convert the other unused Atlantis lever into a blade.",
                        EMType = EMType.ConvertEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EntityIndex = 111,
                        NewEntityType = (short)TREntities.SwingingBlade,
                    },
                    new EMMoveEntityFunction
                    {
                        Comments = "Move it and trigger it.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 111,
                        TargetLocation = new EMLocation
                        {
                            X = 28160 + 2048,
                            Y = -5120,
                            Z = 41472,
                            Room = 25,
                            Angle = 16384
                        }
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        LocationExpander = new EMLocationExpander
                        {
                            Location = new EMLocation
                            {
                                X = 41472,
                                Y = -9472,
                                Z = 33280,
                                Room = 22
                            },
                            ExpandX = 1,
                            ExpandZ = 3
                        },
                        Actions = new List<EMTriggerAction>
                        {
                            new EMTriggerAction
                            {
                                Parameter = 111
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMAddEntityFunction
                    {
                        Comments = "Add a surprise behind Adam's door.",
                        EMType = EMType.AddEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level.Entities[120].Intensity,
                        Location = new EMLocation
                        {
                            X = 69120,
                            Y = -15616,
                            Z = 11776,
                            Room = 48,
                            Angle = -16384,
                        }
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        LocationExpander = new EMLocationExpander
                        {
                            Location = new EMLocation
                            {
                                X = 58880,
                                Y = -15616,
                                Z = 8704,
                                Room = 36
                            },
                            ExpandX = 7,
                            ExpandZ = 7
                        },
                        TargetTypes = new List<FDTrigType> { FDTrigType.HeavyTrigger },
                        Actions = new List<EMTriggerAction>
                        {
                            new EMTriggerAction
                            {
                                Parameter = -1
                            }
                        }
                    }
                }
            };

            EMEditorSet startingFireArea;
            mapping.AllWithin = new List<List<EMEditorSet>>
            {
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Leave clang-clang 6 alone.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMTriggerFunction
                        {
                            Comments = "Separate the clang-clang trigger from the one for the breakable tile.",
                            EMType = EMType.Trigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 69120,
                                    Y = -14592,
                                    Z = 25088,
                                    Room = 9
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 6
                                    }
                                }
                            }
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 69120,
                                    Y = -11008,
                                    Z = 26112,
                                    Room = 8
                                }
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 6
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the clang-clang to the middle of the breakable tile.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 6,
                            TargetLocation = new EMLocation
                            {
                                X = 69120,
                                Y = -14592,
                                Z = 27136 - 512,
                                Room = 9,
                                Angle = -32768
                            }
                        },
                        new EMConvertEntityFunction
                        {
                            Comments = "Convert the breakable tile into another clang-clang.",
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 2,
                            NewEntityType = (short)TREntities.SlammingDoor,
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move it upstairs.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 2,
                            TargetLocation = new EMLocation
                            {
                                X = 69120,
                                Y = -14592,
                                Z = 27136 + 512,
                                Room = 13,
                                Angle = -32768
                            }
                        },
                        new EMModifyEntityFunction
                        {
                            Comments = "Fix its lighting.",
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 2,
                            Intensity1 = level.Entities[6].Intensity
                        },
                        new EMRemoveTriggerFunction
                        {
                            Comments = "Remove the old trigger.",
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 69120,
                                    Y = -11008,
                                    Z = 26112,
                                    Room = 8
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Replacement triggers for them both.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 69120,
                                    Y = -14592,
                                    Z = 28160 - 1024,
                                    Room = 13
                                },
                                new EMLocation
                                {
                                    X = 69120,
                                    Y = -14592,
                                    Z = 28160 - 3*1024,
                                    Room = 9
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 2
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = 6
                                    }
                                }
                            }
                        },
                    }
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 67072,
                                Y = -15616,
                                Z = 11776,
                                Room = 48,
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
                                    X = 67072 + 1024,
                                    Y = -15616,
                                    Z = 11776,
                                    Room = 48,
                                },
                                new EMLocation
                                {
                                    X = 67072,
                                    Y = -15616,
                                    Z = 11776,
                                    Room = 48,
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction { }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 69120,
                                Y = -15616,
                                Z = 13824,
                                Room = 6,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 69120,
                                    Y = -15616,
                                    Z = 13824 + 1024,
                                    Room = 6,
                                },
                                new EMLocation
                                {
                                    X = 69120,
                                    Y = -15616,
                                    Z = 13824,
                                    Room = 6,
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction { }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 72192,
                                Y = -12544,
                                Z = 23040,
                                Room = 12,
                                Angle = -32768
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 72192,
                                    Y = -12544,
                                    Z = 23040,
                                    Room = 12,
                                },
                                new EMLocation
                                {
                                    X = 72192,
                                    Y = -12544,
                                    Z = 23040 - 1024,
                                    Room = 12,
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction { }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 66048,
                                Y = -14592,
                                Z = 30208 + 512,
                                Room = 16,
                                Angle = -32768
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 66048,
                                    Y = -14592,
                                    Z = 30208,
                                    Room = 16,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction { }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 62976,
                                Y = -13568,
                                Z = 27136 - 512,
                                Room = 17,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 62976,
                                    Y = -13568,
                                    Z = 27136,
                                    Room = 17,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction { }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 53760,
                                Y = -13824,
                                Z = 18944 + 512,
                                Room = 38,
                                Angle = -32768
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 53760,
                                    Y = -13824,
                                    Z = 18944,
                                    Room = 38,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction { }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 53760,
                                Y = -23040,
                                Z = 14848 - 512,
                                Room = 60,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 53760,
                                    Y = -23040,
                                    Z = 14848,
                                    Room = 60,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction { }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 52736 + 512,
                                Y = -23040,
                                Z = 8704,
                                Room = 60,
                                Angle = -16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 52736,
                                    Y = -23040,
                                    Z = 8704,
                                    Room = 60,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction { }
                                }
                            }
                        }
                    },
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 62976,
                                Y = -13568,
                                Z = 27136 - 512 - 2048,
                                Room = 17,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 62976,
                                    Y = -13568,
                                    Z = 27136 - 2048,
                                    Room = 17,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 1
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 53760,
                                Y = -23040,
                                Z = 14848 - 512 - 2048,
                                Room = 60,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 53760,
                                    Y = -23040,
                                    Z = 14848 - 2048,
                                    Room = 60,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 1
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 47616,
                                Y = -12544,
                                Z = 23040 + 512,
                                Room = 21,
                                Angle = -32768
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 47616,
                                    Y = -12544,
                                    Z = 23040,
                                    Room = 21,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 1
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 28160,
                                Y = -5120,
                                Z = 37376 + 512,
                                Room = 24,
                                Angle = -32768
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 28160,
                                    Y = -5120,
                                    Z = 37376,
                                    Room = 24,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 1
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 34304 + 512,
                                Y = -512,
                                Z = 40448,
                                Room = 19,
                                Angle = -16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 34304,
                                    Y = -512,
                                    Z = 40448,
                                    Room = 19,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 1
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 43520,
                                Y = -512,
                                Z = 45568 + 512,
                                Room = 57,
                                Angle = -32768
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 43520,
                                    Y = -512,
                                    Z = 45568,
                                    Room = 57,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 1
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 43520,
                                Y = -512,
                                Z = 45568 + 512 + 3072,
                                Room = 57,
                                Angle = -32768
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 43520,
                                    Y = -512,
                                    Z = 45568+ 3072,
                                    Room = 57,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 1
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Make use of the clang-clang door from Atlantis.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 53760,
                                Y = -1792,
                                Z = 62976 - 512,
                                Room = 55
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 53760,
                                    Y = -1792,
                                    Z = 62976,
                                    Room = 55,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 1
                                    }
                                }
                            }
                        }
                    },
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Leave boulder 94's trigger alone.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            Comments = "Potential trigger shift for boulder 94.",
                            EMType = EMType.MoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            BaseLocation = new EMLocation
                            {
                                X = 55808,
                                Y = -14592,
                                Z = 17920,
                                Room = 38
                            },
                            NewLocation = new EMLocation
                            {
                                X = 54784,
                                Y = -14080,
                                Z = 17920,
                                Room = 38
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            Comments = "Potential trigger shift for boulder 94.",
                            EMType = EMType.MoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            BaseLocation = new EMLocation
                            {
                                X = 55808,
                                Y = -14592,
                                Z = 17920,
                                Room = 38
                            },
                            NewLocation = new EMLocation
                            {
                                X = 56832,
                                Y = -15104,
                                Z = 17920,
                                Room = 38
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            Comments = "Potential trigger shift for boulder 94.",
                            EMType = EMType.MoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            BaseLocation = new EMLocation
                            {
                                X = 55808,
                                Y = -14592,
                                Z = 17920,
                                Room = 38
                            },
                            NewLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -15616,
                                Z = 17920,
                                Room = 38
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            Comments = "Potential trigger shift for boulder 94.",
                            EMType = EMType.MoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            BaseLocation = new EMLocation
                            {
                                X = 55808,
                                Y = -14592,
                                Z = 17920,
                                Room = 38
                            },
                            NewLocation = new EMLocation
                            {
                                X = 58880,
                                Y = -16128,
                                Z = 17920,
                                Room = 38
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            Comments = "Potential trigger shift for boulder 94.",
                            EMType = EMType.MoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            BaseLocation = new EMLocation
                            {
                                X = 55808,
                                Y = -14592,
                                Z = 17920,
                                Room = 38
                            },
                            NewLocation = new EMLocation
                            {
                                X = 59904,
                                Y = -16640,
                                Z = 17920,
                                Room = 38
                            }
                        }
                    },
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Leave boulder 120's trigger alone.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            Comments = "Potential trigger shift for boulder 120.",
                            EMType = EMType.MoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            BaseLocation = new EMLocation
                            {
                                X = 60928,
                                Y = -20224,
                                Z = 15872,
                                Room = 61
                            },
                            NewLocation = new EMLocation
                            {
                                X = 61952,
                                Y = -19712,
                                Z = 15872,
                                Room = 61
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            Comments = "Potential trigger shift for boulder 120.",
                            EMType = EMType.MoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            BaseLocation = new EMLocation
                            {
                                X = 60928,
                                Y = -20224,
                                Z = 15872,
                                Room = 61
                            },
                            NewLocation = new EMLocation
                            {
                                X = 62976,
                                Y = -19200,
                                Z = 15872,
                                Room = 61
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            Comments = "Potential trigger shift for boulder 120.",
                            EMType = EMType.MoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            BaseLocation = new EMLocation
                            {
                                X = 60928,
                                Y = -20224,
                                Z = 15872,
                                Room = 61
                            },
                            NewLocation = new EMLocation
                            {
                                X = 59904,
                                Y = -20736,
                                Z = 15872,
                                Room = 61
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            Comments = "Potential trigger shift for boulder 120.",
                            EMType = EMType.MoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            BaseLocation = new EMLocation
                            {
                                X = 60928,
                                Y = -20224,
                                Z = 15872,
                                Room = 61
                            },
                            NewLocation = new EMLocation
                            {
                                X = 58880,
                                Y = -21248,
                                Z = 15872,
                                Room = 61
                            }
                        }
                    },

                },
                new List<EMEditorSet>
                {
                    //new EMEditorSet
                    //{
                    //    new EMPlaceholderFunction
                    //    {
                    //        Comments = "Leave the starting area alone.",
                    //        EMType = EMType.NOOP
                    //    }
                    //},
                    (startingFireArea = new EMEditorSet
                    {
                        new EMAppendTriggerActionFunction
                        {
                            Comments = "Trigger the fire.",
                            EMType = EMType.AppendTriggerActionFunction,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            Location = new EMLocation
                            {
                                X = 58880,
                                Y = -15616,
                                Z = 11776,
                                Room = 36
                            },
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -4
                                },
                                new EMTriggerAction
                                {
                                    Parameter = -3
                                },
                                new EMTriggerAction
                                {
                                    Parameter = -2
                                },
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            }
                        }
                    }),
                    new EMEditorSet
                    {
                        new EMModifyFaceFunction
                        {
                            Comments = "Push some faces back a bit.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 36,
                                    FaceIndices = new int[] { 49,52,54,56,58,60,62},
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = 2048 + 3072
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = 2048 + 3072
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = 2048 + 3072
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = 2048 + 3072
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 4,
                                    FaceIndices = new int[] { 110,109,108,107,106,105,102 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = 1024,
                                            Y = -768
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = 1024,
                                            Y = -768
                                        },
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove some faces - but not the floor itself.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [36] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]
                                    {
                                        50,48,51,53,55,57,59,61,63,
                                        71,70,72,73,74,75,76,77,78,
                                        86,85,87,88,89,90,91,92,93,
                                        101,100,102,103,104,105,106,107,108,
                                        116,115,117,118,119,120,121,122,123
                                    }
                                },
                                [4] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]
                                    {
                                        54,53,52,51,50,49,48,
                                        67,66,65,64,63,62,61,
                                        80,79,78,77,76,75,74,
                                        94,93,92,91,90,89,87,
                                        111,95,88,103
                                    },
                                    [EMTextureFaceType.Triangles] = new int[] {0,1}
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMAddSoundSourceFunction
                        {
                            Comments = "Add a lava sound source to the bottom of the pit.",
                            EMType = EMType.AddSoundSource,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Source = new TRSoundSource
                            {
                                SoundID = 148,
                                X = 59904-512,
                                Y = 12288-1024,
                                Z = 11776,
                                Flags = 192
                            }
                        },

                        new EMFloorFunction
                        {
                            Comments = "Raise some of the platforms for the jumps back up the pit.",
                            EMType = EMType.Floor,
                            Clicks = -4,
                            Location = new EMLocation
                            {
                                X = 60928,
                                Y = 10240,
                                Z = 7680,
                                Room = 2
                            },
                            SideTexture = 2,
                            Flags = 14
                        },
                        new EMFloorFunction
                        {
                            EMType = EMType.Floor,
                            Clicks = -3,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Y = 5120,
                                Z = 10752,
                                Room = 1
                            },
                            SideTexture = 2,
                            Flags = 13
                        },
                        new EMFloorFunction
                        {
                            EMType = EMType.Floor,
                            Clicks = -3,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Y = 5120,
                                Z = 14848,
                                Room = 1
                            },
                            SideTexture = 2,
                            Flags = 13
                        },
                        new EMFloorFunction
                        {
                            EMType = EMType.Floor,
                            Clicks = -4,
                            Location = new EMLocation
                            {
                                X = 62976,
                                Z = 10752,
                            },
                            SideTexture = 2,
                            Flags = 7
                        },
                        new EMFloorFunction
                        {
                            EMType = EMType.Floor,
                            Clicks = -8,
                            Location = new EMLocation
                            {
                                X = 61952,
                                Z = 7680,
                            },
                            SideTexture = 2,
                            Flags = 14
                        },

                        // Trapdoor 1
                        new EMAddEntityFunction
                        {
                            Comments = "Add trapdoors for the big climb up.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor1,
                            Intensity = level.Entities[114].Intensity,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 57856+2048,
                                Y = 12288-3*1024-7*256,
                                Z = 7680,
                                Room = 2
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 57856+2048,
                                    Y = 12288,
                                    Z = 7680,
                                    Room = 5
                                },
                                new EMLocation
                                {
                                    X = 57856+2048,
                                    Y = 12288,
                                    Z = 7680+1024,
                                    Room = 5
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Dummy,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        // Trapdoor 2
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor1,
                            Intensity = level.Entities[114].Intensity,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Y = 12288-3*1024-256-11*256,
                                Z = 8704+1024,
                                Room = 2,
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
                                    X = 55808,
                                    Y = 12288,
                                    Z = 8704+1024,
                                    Room = 5
                                },
                                new EMLocation
                                {
                                    X = 55808+1024,
                                    Y = 12288,
                                    Z = 8704+1024,
                                    Room = 5
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Dummy,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        // Trigger 1&2
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 60928,
                                    Y = 10240,
                                    Z = 7680,
                                    Room = 2
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -2
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Deactivate the trapdoors.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 55808,
                                    Y = 4352,
                                    Z = 10752,
                                    Room = 1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Antipad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -2
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            },
                            HardVariant = new EMConvertTriggerFunction
                            {
                                Comments = "Timed trapdoors in hard mode.",
                                EMType = EMType.ConvertTrigger,
                                Location = new EMLocation
                                {
                                    X = 60928,
                                    Y = 10240,
                                    Z = 7680,
                                    Room = 2
                                },
                                Timer = 13
                            }
                        },

                        // Trapdoor 3
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor1,
                            Intensity = level.Entities[114].Intensity,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 59904-1024,
                                Y = 4352-1280,
                                Z = 15872,
                                Room = 1,
                                Angle = -32768
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 59904-1024,
                                    Y = 12288,
                                    Z = 15872,
                                    Room = 5
                                },
                                new EMLocation
                                {
                                    X = 59904 - 1024,
                                    Y = 12288,
                                    Z = 15872-1024,
                                    Room = 5
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Dummy,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        // Trapdoor 4
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor1,
                            Intensity = level.Entities[114].Intensity,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 62976,
                                Y = 4352-1280-1280,
                                Z = 14848,
                                Room = 1,
                                Angle = -16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 62976,
                                    Y = 12288,
                                    Z = 14848,
                                    Room = 5
                                },
                                new EMLocation
                                {
                                    X = 62976 - 1024,
                                    Y = 12288,
                                    Z = 14848,
                                    Room = 5
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Dummy,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        // Trapdoor 5
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor1,
                            Intensity = level.Entities[114].Intensity,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 62976,
                                Y = 4352-1280-1280-1024,
                                Z = 14848 - 2048-1024,
                                Room = 1,
                                Angle = -16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 62976,
                                    Y = 12288,
                                    Z = 14848-2048-1024,
                                    Room = 5
                                },
                                new EMLocation
                                {
                                    X = 62976 - 1024,
                                    Y = 12288,
                                    Z = 14848-2048-1024,
                                    Room = 5
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Dummy,
                                Actions = new List<EMTriggerAction>
                                {

                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        // Trigger 3&4&5
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 55808,
                                    Y = 4352,
                                    Z = 14848,
                                    Room = 1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -3
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -2
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Deactivate the trapdoors.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 62976,
                                    Y = -1024,
                                    Z = 10752,
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Antipad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -3
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -2
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            },
                            HardVariant = new EMConvertTriggerFunction
                            {
                                Comments = "Timed trapdoors in hard mode.",
                                EMType = EMType.ConvertTrigger,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = 4352,
                                    Z = 14848,
                                    Room = 1
                                },
                                Timer = 18
                            }
                        },

                        // Trapdoor 6
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor1,
                            Intensity = level.Entities[114].Intensity,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 58880,
                                Y = -2048-1280,
                                Z = 7680,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 58880,
                                    Y = 12288,
                                    Z = 7680,
                                    Room = 5
                                },
                                new EMLocation
                                {
                                    X = 58880,
                                    Y = 12288,
                                    Z = 7680+1024,
                                    Room = 5
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Dummy,
                                Actions = new List<EMTriggerAction>
                                {

                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        // Trapdoor 7
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor1,
                            Intensity = level.Entities[114].Intensity,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Y = -2048-1280-768,
                                Z = 11776,
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
                                    X = 55808,
                                    Y = 12288,
                                    Z = 11776,
                                    Room = 5
                                },
                                new EMLocation
                                {
                                    X = 55808+1024,
                                    Y = 12288,
                                    Z = 11776,
                                    Room = 5
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Dummy,
                                Actions = new List<EMTriggerAction>
                                {

                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        // Trapdoor 6&7
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 61952,
                                    Z = 7680,
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -2
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Deactivate the trapdoors.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 55808,
                                    Y = -5120,
                                    Z = 13824,
                                    Room = 3
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Antipad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -2
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            },
                            HardVariant = new EMConvertTriggerFunction
                            {
                                Comments = "Timed trapdoors in hard mode.",
                                EMType = EMType.ConvertTrigger,
                                Location = new EMLocation
                                {
                                    X = 61952,
                                    Y = -2048,
                                    Z = 7680,
                                },
                                Timer = 13
                            }
                        },

                        new EMMoveEntityFunction
                        {
                            Comments = "Move Lara to the bottom of the pit.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 87,
                            TargetLocation = new EMLocation
                            {
                                X = 62976,
                                Y = 10240,
                                Z = 9728,
                                Room = 2
                            }
                        },

                        new EMCreateRoomFunction
                        {
                            Comments = "Final climb up through new rooms.",
                            EMType = EMType.CreateRoom,
                            Height = 4,
                            Width = 4,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 5,
                                Ceiling = 5,
                                Wall4 = 5
                            },
                            AmbientLighting = level.Rooms[3].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[3].RoomData.Vertices[level.Rooms[3].RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -768,
                                    Z = 2048 - 512,
                                    Intensity1 = 2048,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 2048 + 512,
                                    Y = -768,
                                    Z = 2048 + 512,
                                    Intensity1 = 3072,
                                    Fade1 = 2048,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 55808,
                                Y = -5120,
                                Z = 13824,
                                Room = 3
                            },
                            Location = new EMLocation
                            {
                                X = 55296-3072,
                                Y = -5120-1024-512,
                                Z = 13312-2048,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int>{9}
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 16,
                            Width = 4,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 5,
                                Ceiling = 5,
                                Wall4 = 5
                            },
                            AmbientLighting = level.Rooms[3].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[3].RoomData.Vertices[level.Rooms[3].RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 2048 + 512,
                                    Y = -768,
                                    Z = 2048 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -768-3072,
                                    Z = 2048 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 1024,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 55808,
                                Y = -5120,
                                Z = 13824,
                                Room = 3
                            },
                            Location = new EMLocation
                            {
                                X = 55296-4096,
                                Y = -5120-1024-512,
                                Z = 13312-2048-2048,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-4] = new List<int>{9},
                                [-8] = new List<int>{5},
                                [-12] = new List<int>{6},
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 16,
                            Width = 4,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 5,
                                Ceiling = 5,
                                Wall4 = 5
                            },
                            AmbientLighting = level.Rooms[3].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[3].RoomData.Vertices[level.Rooms[3].RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 2048 + 512,
                                    Y = -768,
                                    Z = 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -512-3072,
                                    Z = 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 1024,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 55808,
                                Y = -5120,
                                Z = 13824,
                                Room = 3
                            },
                            Location = new EMLocation
                            {
                                X = 55296-4096-1024,
                                Y = -5120-1024-12*256-512,
                                Z = 13312-2048,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-4] = new List<int>{10},
                                [-8] = new List<int>{6},
                                [-12] = new List<int>{5},
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 12,
                            Width = 6,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 5,
                                Ceiling = 5,
                                Wall4 = 5
                            },
                            AmbientLighting = level.Rooms[3].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[3].RoomData.Vertices[level.Rooms[3].RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 3072 + 512,
                                    Y = -2048-768,
                                    Z = 1024 + 512,
                                    Intensity1 = 3072-512,
                                    Fade1 = level.Rooms[3].Lights[0].Fade,
                                },
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -512,
                                    Z = 2048 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 1024+512,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 55808,
                                Y = -5120,
                                Z = 13824,
                                Room = 3
                            },
                            Location = new EMLocation
                            {
                                X = 55296-4096-1024,
                                Y = -5120-1024-28*256-512,
                                Z = 13312-3072,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int>{10,14,18},
                                [-4] = new List<int>{13},
                                [-8] = new List<int>{17},
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [8] = new List<int> {6 },
                                [4] = new List<int> {5,9 }
                            }
                        },

                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Make collisional portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [3] = new Dictionary<short, EMLocation[]>
                                {
                                    [-4] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 55808-1024,
                                            Y = -5120,
                                            Z = 13824,
                                            Room = 3
                                        }
                                    }
                                },
                                [-4] = new Dictionary<short, EMLocation[]>
                                {
                                    [3] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 55808,
                                            Y = -5120,
                                            Z = 13824,
                                            Room = -4
                                        }
                                    },
                                    [-3] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 53760,
                                            Y = -6144,
                                            Z = 11776,
                                            Room = -4
                                        }
                                    }
                                },
                                [-3] = new Dictionary<short, EMLocation[]>
                                {
                                    [-4] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 53760,
                                            Y = -6144,
                                            Z = 11776+1024,
                                            Room = -3
                                        }
                                    },
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 52736,
                                            Y = -9216,
                                            Z = 12800,
                                            Room = -3
                                        }
                                    }
                                },
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [-3] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 52736,
                                            Y = -9216,
                                            Z = 12800-1024,
                                            Room = -2
                                        }
                                    },
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 51712,
                                            Y = -12288,
                                            Z = 12800-1024,
                                            Room = -2
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [36] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 54784+1024,
                                            Y = -15360,
                                            Z = 11776,
                                            Room = -1
                                        }
                                    },
                                },
                            },

                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 51712,
                                Y = -12288-1024,
                                Z = 12800,
                                Room = -1
                            },
                            Floor = new EMLocation
                            {
                                X = 51712,
                                Y = -12288,
                                Z = 12800,
                                Room = -2
                            }
                        },
                        new EMVisibilityPortalFunction
                        {
                            Comments = "Make visibility portals.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 3,
                                    AdjoiningRoom = -4,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -6656 - 1024,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -6656 - 1024,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -6656,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -6656,
                                            Z = 7 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -4,
                                    AdjoiningRoom = 3,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -6656 - 1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -6656 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -6656,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -6656,
                                            Z = 3 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -4,
                                    AdjoiningRoom = -3,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -6656 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -6656 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -6656,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -6656,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -3,
                                    AdjoiningRoom = -4,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -6656 - 1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -6656 - 1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -6656,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -6656,
                                            Z = 3 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = -3,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -9728 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -9728 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -9728,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -9728,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -3,
                                    AdjoiningRoom = -2,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -9728 - 1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -9728 - 1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -9728,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -9728,
                                            Z = 3 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -13824,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -13824,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -13824,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -13824,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = -2,
                                    Normal = new TRVertex
                                    {
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -13824,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -13824,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -13824,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -13824,
                                            Z = 2 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = 36,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -15872 - 1024,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -15872 - 1024,
                                            Z = 6 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -15872,
                                            Z = 6 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -15872,
                                            Z = 5 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 36,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -15872 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -15872 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -15872,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -15872,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments= "Remove faces for portals.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-4] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 4,12 }
                                },
                                [-3] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 10,25 }
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 1,21 }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 7,30 }
                                },
                                [0] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 92,71 }
                                },
                                [2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 65 }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber  = 3,
                                    FaceIndex = 22,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = -1536
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1536
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber  = 3,
                                    FaceIndex = 23,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber  = 36,
                                    FaceIndex = 16,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber  = 1,
                                    FaceIndices =  new int[]{ 14,26 },
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -768
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -768
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber  = 0,
                                    FaceIndices =  new int[]{ 70 },
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                    }
                                }
                            }
                        },
                        new EMAddFaceFunction
                        {
                            EMType = EMType.AddFace,
                            Quads = new Dictionary<short, List<TRFace4>>
                            {
                                [3] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 2,
                                        Vertices=  new ushort[]
                                        {
                                            level.Rooms[3].RoomData.Rectangles[19].Vertices[1],
                                            level.Rooms[3].RoomData.Rectangles[25].Vertices[0],
                                            level.Rooms[3].RoomData.Rectangles[25].Vertices[3],
                                            level.Rooms[3].RoomData.Rectangles[19].Vertices[2],
                                        }
                                    }
                                }
                            }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments = "Generate light.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -4,-3,-2,-1 }
                        },

                        new EMMoveCameraFunction
                        {
                            Comments = "Adjust the camera for Adam.",
                            CameraIndex = 0,
                            EMType = EMType.MoveCamera,
                            NewLocation = new EMLocation
                            {
                                X = 61952+2048-1024,
                                Y = -23040+512,
                                Z = 11776,
                                Room = 49
                            }
                        }
                    }
                },

            };

            for (int x = 0; x < 2; x++)
            {
                for (int z = 0; z < 2; z++)
                {
                    int xpos = 59904 + x * 4 * 1024;
                    int zpos = 13824 - z * 4 * 1024;

                    startingFireArea.Insert(0, new EMMovePickupFunction
                    {
                        Comments = "Move any pickups from the target fire tile.",
                        EMType = EMType.MovePickup,
                        SectorLocations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = xpos,
                                Y = -15616,
                                Z = zpos,
                                Room = 36
                            }
                        },
                        TargetLocation = new EMLocation
                        {
                            X = 61952,
                            Y = -15616,
                            Z = 11776,
                            Room = 36
                        }
                    });
                    startingFireArea.Insert(1, new EMFloorFunction
                    {
                        Comments = "Raise the floor a little.",
                        EMType = EMType.Floor,
                        Clicks = -1,
                        FloorTexture = 871,
                        SideTexture = 119,
                        Location = new EMLocation
                        {
                            X = xpos,
                            Y = -15616,
                            Z = zpos,
                            Room = 36
                        }
                    });
                    startingFireArea.Insert(2, new EMAddEntityFunction
                    {
                        Comments = "Add some fire.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.FlameEmitter_N,
                        Location = new EMLocation
                        {
                            X = xpos,
                            Y = -15616 - 256,
                            Z = zpos,
                            Room = 36
                        }
                    });
                }
            }

            mapping.OneOf = new List<EMEditorGroupedSet>
            {
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 19.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[19].RoomData.Rectangles[75].Texture] = new EMGeometryMap
                                {
                                    [19] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 86 }
                                    }
                                }
                            }
                        }
                    },
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 20,
                                Location = new EMLocation
                                {
                                    X = 42496,
                                    Y = -512,
                                    Z = 39424,
                                    Room = 19,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[19].RoomData.Rectangles[86].Texture] = new EMGeometryMap
                                    {
                                        [19] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 84 }
                                        }
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 20,
                                Location = new EMLocation
                                {
                                    X = 42496 - 1024,
                                    Y = -512,
                                    Z = 39424,
                                    Room = 19,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[19].RoomData.Rectangles[86].Texture] = new EMGeometryMap
                                    {
                                        [19] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 75 }
                                        }
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 20,
                                Location = new EMLocation
                                {
                                    X = 42496 - 2*1024,
                                    Y = -512,
                                    Z = 39424,
                                    Room = 19,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[19].RoomData.Rectangles[86].Texture] = new EMGeometryMap
                                    {
                                        [19] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 63 }
                                        }
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 20,
                                Location = new EMLocation
                                {
                                    X = 42496 - 1*1024,
                                    Y = -512,
                                    Z = 39424 + 1024,
                                    Room = 19
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[19].RoomData.Rectangles[86].Texture] = new EMGeometryMap
                                    {
                                        [19] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 79 }
                                        }
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 20,
                                Location = new EMLocation
                                {
                                    X = 42496 - 1*1024,
                                    Y = -512,
                                    Z = 39424 + 1024,
                                    Room = 19,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[19].RoomData.Rectangles[86].Texture] = new EMGeometryMap
                                    {
                                        [19] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 85 }
                                        }
                                    }
                                }
                            }
                        },
                    }
                },
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 63.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[63].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                {
                                    [63] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 16 }
                                    }
                                }
                            }
                        }
                    },
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMRefaceFunction
                            {
                                Comments = "Effectively NOOP.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[63].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [63] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 16 }
                                        }
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 125,
                                Location = new EMLocation
                                {
                                    X = 66048,
                                    Y = -13312,
                                    Z = 18944,
                                    Room = 63,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[63].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [63] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 14 }
                                        }
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 125,
                                Location = new EMLocation
                                {
                                    X = 66048,
                                    Y = -13312,
                                    Z = 18944,
                                    Room = 63
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[63].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [63] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 15 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotation for above.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        RoomNumber = 63,
                                        FaceIndices = new int[] { 15 },
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 3,
                                            [1] = 0,
                                            [2] = 1,
                                            [3] = 2,
                                        }
                                    }
                                }
                            },
                        },
                    }
                }
            };

            mapping.Mirrored = new EMEditorSet
            {
                new EMMoveTriggerFunction
                {
                    Comments = "Move the antipad for the door after the lava flow traps in case there are items to collect on the other side.",
                    EMType = EMType.MoveTrigger,
                    BaseLocation = new EMLocation
                    {
                        X = 31232,
                        Y = -512,
                        Z = 38400,
                        Room = 57,
                    },
                    NewLocation = new EMLocation
                    {
                        X = 31232,
                        Y = -512,
                        Z = 40448,
                        Room = 57,
                    }
                }
            };

            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "If Lara is in room 2 and so are the Atlantis clang-clang doors, convert them into pickups.",
                        EntityIndex = 87,
                        Room = 2,
                        And = new List<BaseEMCondition>
                        {
                            new EMEntityPropertyCondition
                            {
                                EntityIndex = 0,
                                Room = 2
                            },
                        }
                    },
                    OnTrue = new EMEditorSet
                    {
                        new EMConvertEntityFunction
                        {
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 0,
                            NewEntityType = (short)TREntities.LargeMed_S_P,
                        },
                        new EMConvertEntityFunction
                        {
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 1,
                            NewEntityType = (short)TREntities.UziAmmo_S_P,
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -5120,
                                Z = 15872,
                                Room = 3
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -5120,
                                Z = 15872,
                                Room = 3
                            }
                        }
                    }
                }
            };

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();

            mapping.RewardEntities = new List<int> { 49, 50, 51, 52, 122, 123, 124, 126, 127, 128 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 49664,
                            Y = -1792,
                            Z = 71168
                        },
                        new Location
                        {
                            X = 50688,
                            Y = -1792,
                            Z = 71168
                        },
                        new Location
                        {
                            X = 51712,
                            Y = -1792,
                            Z = 71168
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door2,
                            X = 53760,
                            Y = -1792,
                            Z = 71168,
                            Angle = 16384,
                            Intensity = 6400,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 53760,
                            Y = -2304,
                            Z = 61952,
                            Room = 55
                        }
                    },
                    CameraTarget = new Location
                    {
                        X = 53760,
                        Y = -2304,
                        Z = 72137,
                        Room = 55
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 48,
                            LinkedLocation = new EMLocation
                            {
                                X = 53760,
                                Y = -1792,
                                Z = 71168,
                                Room = 55
                            },
                            NewLocation = new EMLocation
                            {
                                X = 48128,
                                Y = -1792,
                                Z = 69632,
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [55] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 52736,
                                            Y = -1792,
                                            Z = 71168,
                                            Room = 55
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [55] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 53760,
                                            Y = -1792,
                                            Z = 71168,
                                            Room = -1
                                        }
                                    }
                                }
                            }
                        },
                        new EMVisibilityPortalFunction
                        {
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 55,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -2816,
                                            Z = 10240
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -2816,
                                            Z = 11264
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1792,
                                            Z = 11264
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1792,
                                            Z = 10240
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 55,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5120,
                                            Y = -2816,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 5120,
                                            Y = -2816,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5120,
                                            Y = -1792,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5120,
                                            Y = -1792,
                                            Z = 2048
                                        },
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 15,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = -1024,
                                        },
                                        [1] = new TRVertex
                                        {
                                            Z = 1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            Z = 1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = -1024
                                        }
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [45] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2, 3, 6, 7, 10, 11, 14, 15 }
                                    }
                                },
                                [50] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 1, 5, 9, 13 }
                                    }
                                },
                                [64] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0, 4, 8, 12 }
                                    }
                                },
                                [62] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 4 }
                                    }
                                }
                            }
                        },
                        new EMAddFaceFunction
                        {
                            EMType = EMType.AddFace,
                            Quads = new Dictionary<short, List<TRFace4>>
                            {
                                [-1] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 45,
                                        Vertices = new ushort[]
                                        {
                                            2, 6, 1, 0
                                        }
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [55] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 30 }
                                }
                            }
                        }
                    }
                }
            };

            WriteSecretRoomMapping(mapping);
        }
    }
}

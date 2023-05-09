using Newtonsoft.Json;
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
    public class TR1AtlantisControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.ATLANTIS;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMConvertEntityFunction
                    {
                        Comments = "Convert one of the end trapdoors into a trap.",
                        EMType = EMType.ConvertEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EntityIndex = 120,
                        NewEntityType = (short)TREntities.RollingBall
                    },
                    new EMModifyEntityFunction
                    {
                        EMType = EMType.ModifyEntity,
                        EntityIndex = 120,
                        Flags = level.Entities[127].Flags
                    },
                    new EMMoveEntityFunction
                    {
                        EMType = EMType.MoveEntity,
                        EntityIndex = 120,
                        TargetLocation = new EMLocation
                        {
                            X = 48640 + 3072,
                            Y = -18688 - 2048 - 512,
                            Z = 45568,
                            Room = 50,
                            Angle = -16384
                        }
                    },
                    new EMRemoveTriggerFunction
                    {
                        EMType = EMType.RemoveTrigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 47616,
                                Y = -16640,
                                Z = 45568,
                                Room = 54
                            },
                            new EMLocation
                            {
                                X = 47616 - 1024,
                                Y = -16640,
                                Z = 45568,
                                Room = 54
                            },
                        }
                    },
                    new EMRemoveTriggerActionFunction
                    {
                        EMType = EMType.RemoveTriggerAction,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 50688,
                                Y = -18688,
                                Z = 49664,
                                Room = 52
                            },
                        },
                        ActionItem = new EMTriggerAction
                        {
                            Parameter = 120
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 48640,
                                Y = -18688,
                                Z = 45568,
                                Room = 50
                            },
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 120
                                }
                            }
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
                                Y = -16640,
                                Z = 39424,
                                Room = 56
                            },
                            new EMLocation
                            {
                                X = 52736 + 1024,
                                Y = -16640,
                                Z = 39424,
                                Room = 56
                            },
                            new EMLocation
                            {
                                X = 52736 + 2048,
                                Y = -16640,
                                Z = 39424,
                                Room = 56
                            },
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            TrigType = FDTrigType.Antipad,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 120
                                }
                            }
                        }
                    },
                },
                new EMEditorSet
                {
                    new EMSwapGroupedSlotsFunction
                    {
                        Comments = "Potential lever shuffle before the scion.",
                        EMType = EMType.SwapGroupedSlots,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityMap = new Dictionary<short, short>
                        {
                            [113] = 114,
                            [114] = 113,
                        }
                    }
                },
            };

            mapping.NonPurist = new EMEditorSet
            {
                new EMRefaceFunction
                {
                    Comments = "Fix the incorrect texture in the starting flip map room.",
                    EMType = EMType.Reface,
                    TextureMap = new EMTextureMap
                    {
                        [84] = new EMGeometryMap
                        {
                            [85] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 19 }
                            }
                        }
                    }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Fix a quad in room 27.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 27,
                            FaceIndex = 14,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = -256
                                },
                                [1] = new TRVertex
                                {
                                    Y = 256
                                }
                            }
                        }
                    }
                },

                new EMSlantFunction
                {
                    Comments = "Modify the shortcut slope in room 40.",
                    EMType = EMType.Slant,
                    FloorClicks = -6,
                    SlantType = FDSlantEntryType.FloorSlant,
                    XSlant = -3,
                    ZSlant = -3,
                    Location = new EMLocation
                    {
                        X = 51712,
                        Y = 768,
                        Z = 56832,
                        Room = 40
                    }
                },
                new EMMovePickupFunction
                {
                    Comments = "Any pickups on the old slope will be moved nearby",
                    EMType = EMType.MovePickup,
                    SectorLocations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 51712,
                            Y = 768,
                            Z = 56832,
                            Room = 40
                        }
                    },
                    TargetLocation = new EMLocation
                    {
                        X = 51712 - 1024,
                        Y = 768,
                        Z = 56832,
                        Room = 40
                    }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Modify faces to fit.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 40,
                            FaceIndex = 57,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = -1024-256
                                },
                                [1] = new TRVertex
                                {
                                    Y = -256-256
                                },
                                [2] = new TRVertex
                                {
                                    Y = -512-256
                                },
                                [3] = new TRVertex
                                {
                                    Y = -1024 - 256-256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 40,
                            FaceIndex = 87,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = 512
                                },
                            }
                        }
                    }
                },
                new EMAddFaceFunction
                {
                    Comments = "Patch the gaps in the walls.",
                    EMType = EMType.AddFace,
                    Quads = new Dictionary<short, List<TRFace4>>
                    {
                        [40] = new List<TRFace4>
                        {
                            new TRFace4
                            {
                                Texture = 26,
                                Vertices = new ushort[]
                                {
                                    (ushort)(level.Rooms[40].RoomData.NumVertices + 2),
                                    (ushort)(level.Rooms[40].RoomData.NumVertices + 1),
                                    level.Rooms[40].RoomData.Rectangles[87].Vertices[1],
                                    (ushort)(level.Rooms[40].RoomData.NumVertices + 4),
                                }
                            },
                            new TRFace4
                            {
                                Texture = 67,
                                Vertices = new ushort[]
                                {
                                    (ushort)(level.Rooms[40].RoomData.NumVertices + 1),
                                    (ushort)(level.Rooms[40].RoomData.NumVertices + 0),
                                    level.Rooms[40].RoomData.Rectangles[61].Vertices[3],
                                    level.Rooms[40].RoomData.Rectangles[61].Vertices[2],
                                }
                            },
                            new TRFace4
                            {
                                Texture = 27,
                                Vertices = new ushort[]
                                {
                                    (ushort)(level.Rooms[40].RoomData.NumVertices + 0),
                                    (ushort)(level.Rooms[40].RoomData.NumVertices + 3),
                                    level.Rooms[40].RoomData.Rectangles[7].Vertices[2],
                                    level.Rooms[40].RoomData.Rectangles[7].Vertices[1],
                                }
                            },
                            new TRFace4
                            {
                                Texture = 27,
                                Vertices = new ushort[]
                                {
                                    (ushort)(level.Rooms[40].RoomData.NumVertices + 3),
                                    (ushort)(level.Rooms[40].RoomData.NumVertices + 2),
                                    level.Rooms[40].RoomData.Rectangles[55].Vertices[3],
                                    level.Rooms[40].RoomData.Rectangles[55].Vertices[2],
                                }
                            },
                        }
                    }
                },
                new EMMoveEntityFunction
                {
                    EMType = EMType.MoveEntity,
                    EntityIndex = 87,
                    TargetLocation = new EMLocation
                    {
                        X = 53760 + 1024,
                        Y = 1408 + 1024,
                        Z = 56832,
                        Room = 40
                    }
                },

                // Return path
                new EMCreateRoomFunction
                {
                    Comments = "Make a return path possible.",
                    EMType = EMType.CreateRoom,
                    Height = 44,
                    Width = 3,
                    Depth = 3,
                    Textures = new EMTextureGroup
                    {
                        Floor = 5,
                        Ceiling = 5,
                        Wall4 = 5
                    },
                    AmbientLighting = level.Rooms[50].AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = level.Rooms[50].RoomData.Vertices[level.Rooms[50].RoomData.Rectangles[2].Vertices[0]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1024 + 512,
                            Y = -9*1024,
                            Z = 2048 - 512,
                            Intensity1 = 4096,
                            Fade1 = level.Rooms[50].Lights[0].Fade,
                        },
                        new EMRoomLight
                        {
                            X = 1024 + 512,
                            Y = -512,
                            Z = 2048 - 512,
                            Intensity1 = 2048,
                            Fade1 = level.Rooms[50].Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 51712 + 1024,
                        Y = -18688,
                        Z = 44544,
                        Room = 50
                    },
                    Location = new EMLocation
                    {
                        X = 51200 - 1024,
                        Y = -18688 + 11264,
                        Z = 44032 + 3072,
                    },
                },
                new EMCreateRoomFunction
                {
                    EMType = EMType.CreateRoom,
                    Height = 44,
                    Width = 3,
                    Depth = 3,
                    Textures = new EMTextureGroup
                    {
                        Floor = 5,
                        Ceiling = 5,
                        Wall4 = 5
                    },
                    AmbientLighting = level.Rooms[50].AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = level.Rooms[50].RoomData.Vertices[level.Rooms[50].RoomData.Rectangles[2].Vertices[0]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1024 + 512,
                            Y = -9*1024,
                            Z = 2048 - 512,
                            Intensity1 = 4096,
                            Fade1 = level.Rooms[50].Lights[0].Fade,
                        },
                        new EMRoomLight
                        {
                            X = 1024 + 512,
                            Y = -512,
                            Z = 2048 - 512,
                            Intensity1 = 2048,
                            Fade1 = level.Rooms[50].Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 51712 + 1024,
                        Y = -18688,
                        Z = 44544,
                        Room = 50
                    },
                    Location = new EMLocation
                    {
                        X = 51200 - 1024,
                        Y = -18688 + 11264 + 11264,
                        Z = 44032 + 3072,
                    },
                },

                new EMVerticalCollisionalPortalFunction
                {
                    EMType = EMType.VerticalCollisionalPortal,
                    Ceiling = new EMLocation
                    {
                        X = 51712,
                        Y = -18688,
                        Z = 48640,
                        Room = 50
                    },
                    Floor = new EMLocation
                    {
                        X = 51712,
                        Y = -18688 + 1024,
                        Z = 48640,
                        Room = -2
                    }
                },
                new EMVerticalCollisionalPortalFunction
                {
                    EMType = EMType.VerticalCollisionalPortal,
                    Ceiling = new EMLocation
                    {
                        X = 51712,
                        Y = -7424,
                        Z = 48640,
                        Room = -2
                    },
                    Floor = new EMLocation
                    {
                        X = 51712,
                        Y = -7424 + 1024,
                        Z = 48640,
                        Room = -1
                    }
                },
                new EMVerticalCollisionalPortalFunction
                {
                    EMType = EMType.VerticalCollisionalPortal,
                    Ceiling = new EMLocation
                    {
                        X = 51712,
                        Y = 3840,
                        Z = 48640,
                        Room = -1
                    },
                    Floor = new EMLocation
                    {
                        X = 51712,
                        Y = 3840 + 1024,
                        Z = 48640,
                        Room = 30
                    }
                },
                new EMVisibilityPortalFunction
                {
                    EMType = EMType.VisibilityPortal,
                    Portals = new List<EMVisibilityPortal>
                    {
                        new EMVisibilityPortal
                        {
                            BaseRoom = 50,
                            AdjoiningRoom = -2,
                            Normal = new TRVertex
                            {
                                Y = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 4 * 1024,
                                    Y = -18688,
                                    Z = 9 * 1024
                                },
                                new TRVertex
                                {
                                    X = 5 * 1024,
                                    Y = -18688,
                                    Z = 9 * 1024
                                },
                                new TRVertex
                                {
                                    X = 5 * 1024,
                                    Y = -18688,
                                    Z = 8 * 1024
                                },
                                new TRVertex
                                {
                                    X = 4 * 1024,
                                    Y = -18688,
                                    Z = 8 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = -2,
                            AdjoiningRoom = 50,
                            Normal = new TRVertex
                            {
                                Y = 1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -18688,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -18688,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -18688,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -18688,
                                    Z = 1 * 1024
                                }
                            }
                        },

                        new EMVisibilityPortal
                        {
                            BaseRoom = -2,
                            AdjoiningRoom = -1,
                            Normal = new TRVertex
                            {
                                Y = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -7424,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -7424,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -7424,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -7424,
                                    Z = 1 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = -1,
                            AdjoiningRoom = -2,
                            Normal = new TRVertex
                            {
                                Y = 1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -7424,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -7424,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -7424,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -7424,
                                    Z = 1 * 1024
                                }
                            }
                        },

                        new EMVisibilityPortal
                        {
                            BaseRoom = -1,
                            AdjoiningRoom = 30,
                            Normal = new TRVertex
                            {
                                Y = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 3840,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 3840,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 3840,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 3840,
                                    Z = 1 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = 30,
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
                                    Y = 3840,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 3840,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 3840,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 3840,
                                    Z = 1 * 1024
                                }
                            }
                        },
                    }
                },
                new EMRemoveFaceFunction
                {
                    Comments = "Remove faces no longer required.",
                    EMType = EMType.RemoveFace,
                    GeometryMap = new EMGeometryMap
                    {
                        [30] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 1 }
                        },
                        [-2] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 0,1 }
                        },
                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 0,1 }
                        },
                        [50] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 90 }
                        },
                    }
                },
                new EMMovePickupFunction
                {
                    Comments = "Any pickups will be moved nearby.",
                    EMType = EMType.MovePickup,
                    SectorLocations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 51712,
                            Y = -18688,
                            Z = 48640,
                            Room = 50
                        }
                    },
                    TargetLocation = new EMLocation
                    {
                        X = 51712 + 1024,
                        Y = -18688,
                        Z = 48640,
                        Room = 50
                    }
                },
                new EMRemoveTriggerFunction
                {
                    Comments= "Remove the triggers that close door 143.",
                    EMType = EMType.RemoveTrigger,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 45568,
                            Y = -14592,
                            Z = 59904,
                            Room = 73
                        },
                        new EMLocation
                        {
                            X = 45568 + 1024,
                            Y = -14592,
                            Z = 59904,
                            Room = 73
                        },
                        new EMLocation
                        {
                            X = 45568 + 2048,
                            Y = -14592,
                            Z = 59904,
                            Room = 73
                        },
                        new EMLocation
                        {
                            X = 45568 + 3072,
                            Y = -14592,
                            Z = 59904,
                            Room = 73
                        },
                        new EMLocation
                        {
                            X = 45568 + 4096,
                            Y = -14592,
                            Z = 59904,
                            Room = 73
                        }
                    }
                },
                new EMTriggerFunction
                {
                    Comments = "Make a timed trigger for the door to open/close.",
                    EMType = EMType.Trigger,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 47616,
                            Y = -13056,
                            Z = 54784,
                            Room = 74
                        }
                    },
                    Trigger = new EMTrigger
                    {
                        Mask = 31,
                        Timer = 20,
                        Actions = new List<EMTriggerAction>
                        {
                            new EMTriggerAction
                            {
                                Parameter = 143
                            }
                        }
                    }
                },
                new EMModifyEntityFunction
                {
                    Comments = "Don't activate the door by default.",
                    EMType = EMType.ModifyEntity,
                    EntityIndex = 143,
                    Flags = 0
                }
            };

            mapping.AllWithin = new List<List<EMEditorSet>>
            {
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMSwapGroupedSlotsFunction
                        {
                            Comments = "Potential lever shuffle in room 78.",
                            EMType = EMType.SwapGroupedSlots,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityMap = new Dictionary<short, short>
                            {
                                [147] = 148,
                                [148] = 149,
                                [149] = 150,
                                [150] = 151,
                                [151] = 147,
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMSwapGroupedSlotsFunction
                        {
                            Comments = "Potential lever shuffle in room 78.",
                            EMType = EMType.SwapGroupedSlots,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityMap = new Dictionary<short, short>
                            {
                                [147] = 149,
                                [148] = 150,
                                [149] = 151,
                                [150] = 147,
                                [151] = 148,
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMSwapGroupedSlotsFunction
                        {
                            Comments = "Potential lever shuffle in room 78.",
                            EMType = EMType.SwapGroupedSlots,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityMap = new Dictionary<short, short>
                            {
                                [147] = 150,
                                [148] = 151,
                                [149] = 147,
                                [150] = 148,
                                [151] = 149,
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMSwapGroupedSlotsFunction
                        {
                            Comments = "Potential lever shuffle in room 78.",
                            EMType = EMType.SwapGroupedSlots,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityMap = new Dictionary<short, short>
                            {
                                [147] = 151,
                                [148] = 147,
                                [149] = 148,
                                [150] = 149,
                                [151] = 150,
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMSwapGroupedSlotsFunction
                        {
                            Comments = "Potential lever shuffle in room 78.",
                            EMType = EMType.SwapGroupedSlots,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityMap = new Dictionary<short, short>
                            {
                                [148] = 151,
                                [149] = 148,
                                [150] = 149,
                                [151] = 150,
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMSwapGroupedSlotsFunction
                        {
                            Comments = "Potential lever shuffle in room 78.",
                            EMType = EMType.SwapGroupedSlots,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityMap = new Dictionary<short, short>
                            {
                                [147] = 149,
                                [149] = 151,
                                [150] = 147,
                                [151] = 150,
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMSwapGroupedSlotsFunction
                        {
                            Comments = "Potential lever shuffle in room 78.",
                            EMType = EMType.SwapGroupedSlots,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityMap = new Dictionary<short, short>
                            {
                                [147] = 148,
                                [148] = 150,
                                [150] = 151,
                                [151] = 147,
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMSwapGroupedSlotsFunction
                        {
                            Comments = "Potential lever shuffle in room 78.",
                            EMType = EMType.SwapGroupedSlots,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityMap = new Dictionary<short, short>
                            {
                                [147] = 151,
                                [148] = 149,
                                [149] = 148,
                                [151] = 147,
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMSwapGroupedSlotsFunction
                        {
                            Comments = "Potential lever shuffle in room 78.",
                            EMType = EMType.SwapGroupedSlots,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityMap = new Dictionary<short, short>
                            {
                                [147] = 149,
                                [148] = 150,
                                [149] = 147,
                                [150] = 148
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMSwapGroupedSlotsFunction
                        {
                            Comments = "Potential lever shuffle in room 78.",
                            EMType = EMType.SwapGroupedSlots,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityMap = new Dictionary<short, short>
                            {
                                [147] = 151,
                                [149] = 147,
                                [151] = 149
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
                            Comments = "Don't move clang-clang #4",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 4,
                            TargetLocation = new EMLocation
                            {
                                X = 54784,
                                Y = 5120,
                                Z = 48640 - 4096,
                                Room = 1,
                                Angle = -16384
                            },
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 54784,
                                    Y = 5120,
                                    Z = 48640,
                                    Room = 1,
                                },
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 4
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 4,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 4
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 4,
                            TargetLocation = new EMLocation
                            {
                                X = 54784 - 1024,
                                Y = 5120 - 256,
                                Z = 48640 - 4096,
                                Room = 28,
                                Angle = -16384
                            },
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 54784,
                                    Y = 5120,
                                    Z = 48640,
                                    Room = 1,
                                },
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 4
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 4,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 4
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 4,
                            TargetLocation = new EMLocation
                            {
                                X = 46592,
                                Y = 2816,
                                Z = 39424,
                                Room = 81,
                                Angle = -32768
                            },
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 54784,
                                    Y = 5120,
                                    Z = 48640,
                                    Room = 1,
                                },
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 4
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 4,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 4
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 4,
                            TargetLocation = new EMLocation
                            {
                                X = 46592,
                                Y = 3328,
                                Z = 32256,
                                Room = 32,
                                Angle = -32768
                            },
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 54784,
                                    Y = 5120,
                                    Z = 48640,
                                    Room = 1,
                                },
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 4
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 4,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 4
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 4,
                            TargetLocation = new EMLocation
                            {
                                X = 60928,
                                Z = 37376,
                                Room = 35
                            },
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 54784,
                                    Y = 5120,
                                    Z = 48640,
                                    Room = 1,
                                },
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 4
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 4,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 4
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 4,
                            TargetLocation = new EMLocation
                            {
                                X = 58880,
                                Z = 36352,
                                Room = 25,
                                Angle = 16384
                            },
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 54784,
                                    Y = 5120,
                                    Z = 48640,
                                    Room = 1,
                                },
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 4
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 4,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 4
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 4,
                            TargetLocation = new EMLocation
                            {
                                X = 62976,
                                Z = 44544,
                                Room = 37,
                                Angle = 16384
                            },
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 54784,
                                    Y = 5120,
                                    Z = 48640,
                                    Room = 1,
                                },
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 4
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 4,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 4
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 4,
                            TargetLocation = new EMLocation
                            {
                                X = 65024,
                                Y = 1024,
                                Z = 54784,
                                Room = 61
                            },
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 54784,
                                    Y = 5120,
                                    Z = 48640,
                                    Room = 1,
                                },
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 4
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 4,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 4
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 4,
                            TargetLocation = new EMLocation
                            {
                                X = 64000,
                                Y = 1024,
                                Z = 56832,
                                Room = 61,
                                Angle = -16384
                            },
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 54784,
                                    Y = 5120,
                                    Z = 48640,
                                    Room = 1,
                                },
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 4
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 4,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 4
                                    }
                                }
                            }
                        },
                    },
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Don't move clang-clang #7",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 7,
                            TargetLocation = new EMLocation
                            {
                                X = 61952 + 1024,
                                Y = 10240,
                                Z = 43520,
                                Room = 8,
                                Angle = 16384
                            },
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            EntityLocation = 7,
                            BaseLocation = new EMLocation
                            {
                                X = 61952,
                                Y = 10240,
                                Z = 43520,
                                Room = 2
                            },
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 7,
                            TargetLocation = new EMLocation
                            {
                                X = 61952 + 2048,
                                Y = 10240,
                                Z = 43520,
                                Room = 8,
                                Angle = 16384
                            },
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            EntityLocation = 7,
                            BaseLocation = new EMLocation
                            {
                                X = 61952,
                                Y = 10240,
                                Z = 43520,
                                Room = 2
                            },
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 7,
                            TargetLocation = new EMLocation
                            {
                                X = 61952 + 3072,
                                Y = 10240,
                                Z = 43520,
                                Room = 8,
                                Angle = 16384
                            },
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            EntityLocation = 7,
                            BaseLocation = new EMLocation
                            {
                                X = 61952,
                                Y = 10240,
                                Z = 43520,
                                Room = 2
                            },
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 7,
                            TargetLocation = new EMLocation
                            {
                                X = 59904,
                                Y = 10240,
                                Z = 40448 - 1024,
                                Room = 6
                            },
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            EntityLocation = 7,
                            BaseLocation = new EMLocation
                            {
                                X = 61952,
                                Y = 10240,
                                Z = 43520,
                                Room = 2
                            },
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 7,
                            TargetLocation = new EMLocation
                            {
                                X = 59904,
                                Y = 10240,
                                Z = 40448 - 2048,
                                Room = 6
                            },
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            EntityLocation = 7,
                            BaseLocation = new EMLocation
                            {
                                X = 61952,
                                Y = 10240,
                                Z = 43520,
                                Room = 2
                            },
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 7,
                            TargetLocation = new EMLocation
                            {
                                X = 66048,
                                Y = 10240,
                                Z = 57856,
                                Room = 17,
                                Angle = -16384
                            },
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            EntityLocation = 7,
                            BaseLocation = new EMLocation
                            {
                                X = 61952,
                                Y = 10240,
                                Z = 43520,
                                Room = 2
                            },
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 7,
                            TargetLocation = new EMLocation
                            {
                                X = 68096,
                                Y = 10240,
                                Z = 55808,
                                Room = 17,
                            },
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            EntityLocation = 7,
                            BaseLocation = new EMLocation
                            {
                                X = 61952,
                                Y = 10240,
                                Z = 43520,
                                Room = 2
                            },
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 7,
                            TargetLocation = new EMLocation
                            {
                                X = 51712 - 1024,
                                Y = 8448,
                                Z = 33280,
                                Room = 22,
                                Angle = 16384
                            },
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            EntityLocation = 7,
                            BaseLocation = new EMLocation
                            {
                                X = 61952,
                                Y = 10240,
                                Z = 43520,
                                Room = 2
                            },
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 7,
                            TargetLocation = new EMLocation
                            {
                                X = 42496,
                                Y = 7680 - 256,
                                Z = 51712,
                                Room = 27,
                                Angle = -32768
                            },
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            EntityLocation = 7,
                            BaseLocation = new EMLocation
                            {
                                X = 61952,
                                Y = 10240,
                                Z = 43520,
                                Room = 2
                            },
                        },
                    }
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMRemoveTriggerFunction
                        {
                            Comments = "Don't move clang-clang #84, but do convert the trigger into a pad so it switches off.",
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 48640,
                                    Y = -384,
                                    Z = 60928,
                                    Room = 69
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 49664,
                                    Y = -256,
                                    Z = 60928,
                                    Room = 69
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
                                        Parameter = 84
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 84,
                            TargetLocation = new EMLocation
                            {
                                X = 50688 - 2048,
                                Y = -256,
                                Z = 60928,
                                Room = 69,
                                Angle = 16384
                            },
                        },
                        new EMRemoveTriggerFunction
                        {
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 48640,
                                    Y = -384,
                                    Z = 60928,
                                    Room = 69
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 84,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 84
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 84,
                            TargetLocation = new EMLocation
                            {
                                X = 47616,
                                Y = -256,
                                Z = 61952 + 1024,
                                Room = 69,
                                Angle = -32768
                            },
                        },
                        new EMRemoveTriggerFunction
                        {
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 48640,
                                    Y = -384,
                                    Z = 60928,
                                    Room = 69
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 84,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 84
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 84,
                            TargetLocation = new EMLocation
                            {
                                X = 47616,
                                Y = -256 + 256,
                                Z = 61952 + 2 * 1024,
                                Room = 69,
                                Angle = -32768
                            },
                        },
                        new EMRemoveTriggerFunction
                        {
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 48640,
                                    Y = -384,
                                    Z = 60928,
                                    Room = 69
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 84,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 84
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 84,
                            TargetLocation = new EMLocation
                            {
                                X = 47616,
                                Y = -256 + 512,
                                Z = 61952 + 3 * 1024,
                                Room = 69,
                                Angle = -32768
                            },
                        },
                        new EMRemoveTriggerFunction
                        {
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 48640,
                                    Y = -384,
                                    Z = 60928,
                                    Room = 69
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 84,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 84
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 84,
                            TargetLocation = new EMLocation
                            {
                                X = 47616 + 2 * 1024,
                                Y = -256 + 512 + 768,
                                Z = 61952 + 4 * 1024,
                                Room = 69,
                                Angle = -16384
                            },
                        },
                        new EMRemoveTriggerFunction
                        {
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 48640,
                                    Y = -384,
                                    Z = 60928,
                                    Room = 69
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 84,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 84
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 84,
                            TargetLocation = new EMLocation
                            {
                                X = 54784,
                                Y = -5120,
                                Z = 47616,
                                Room = 3,
                                Angle = -16384
                            },
                        },
                        new EMRemoveTriggerFunction
                        {
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 48640,
                                    Y = -384,
                                    Z = 60928,
                                    Room = 69
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 84,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 84
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 84,
                            TargetLocation = new EMLocation
                            {
                                X = 38400,
                                Y = -6656,
                                Z = 41472,
                                Room = 90,
                                Angle = -32768
                            },
                        },
                        new EMRemoveTriggerFunction
                        {
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 48640,
                                    Y = -384,
                                    Z = 60928,
                                    Room = 69
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 84,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 84
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 84,
                            TargetLocation = new EMLocation
                            {
                                X = 53760,
                                Y = -8704,
                                Z = 36352,
                                Room = 70,
                                Angle = 16384
                            },
                        },
                        new EMRemoveTriggerFunction
                        {
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 48640,
                                    Y = -384,
                                    Z = 60928,
                                    Room = 69
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 84,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 84
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential clang-clang relocation.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 84,
                            TargetLocation = new EMLocation
                            {
                                X = 61952,
                                Y = -10240,
                                Z = 43520,
                                Room = 4,
                                Angle = 16384
                            },
                        },
                        new EMRemoveTriggerFunction
                        {
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 48640,
                                    Y = -384,
                                    Z = 60928,
                                    Room = 69
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 84,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 84
                                    }
                                }
                            }
                        },
                    },
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a maze before the beginning.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 4,
                            Width = 12,
                            Depth = 10,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                Wall1 = 107,
                                RandomRotationSeed = 12402008
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 6 * 1024 + 512,
                                    Y = -768,
                                    Z = 5 * 1024 + 512,
                                    Intensity1 = level.Rooms[63].Lights[0].Intensity,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                },
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -768,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 4096 + 512,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 2 * 1024 + 512,
                                    Y = -768,
                                    Z = 7 * 1024 + 512,
                                    Intensity1 = 1024,
                                    Fade1 = 512,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368,
                                Y = 10240,
                                Z = 7168 - 1024,
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-1] = new List<int> { 101 },
                                [-127] = new List<int>()
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            Comments = "An extra room above the maze.",
                            EMType = EMType.CreateRoom,
                            Height = 7,
                            Width = 3,
                            Depth = 5,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 12402008
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -768-768,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 1024+256,
                                    Fade1 = 512,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 60416 - 1024,
                                Y = 10240 - 1024,
                                Z = 13312,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-3] = new List<int>{ 7,8 }
                            }
                        },
                        new EMVisibilityPortalFunction
                        {
                            Comments = "Visibility portals for the new rooms.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 63,
                                    AdjoiningRoom = -2,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = 63,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
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
                                            X = 2 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 9 * 1024
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
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Collisional portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [63] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 58880 + 1024,
                                            Y = 10240,
                                            Z = 7680,
                                            Room = 63
                                        },
                                    }
                                },
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [63] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 58880,
                                            Y = 10240,
                                            Z = 7680,
                                            Room = -2
                                        },
                                    },
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 60928,
                                            Y = 10240,
                                            Z = 14848 + 1024,
                                            Room = -2
                                        }
                                    }
                                },
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 60928,
                                Y = 10240 - 1024,
                                Z = 14848,
                                Room = -1
                            },
                            Floor = new EMLocation
                            {
                                X = 60928,
                                Y = 10240,
                                Z = 14848,
                                Room = -2
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Adjust faces and textures.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 63,
                                    FaceIndex = 17,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024
                                        }
                                    }
                                },
                            },
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = -2,
                                    FaceIndices = new int[] { 63,77,146 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 3,
                                        [1] = 0,
                                        [2] = 1,
                                        [3] = 2
                                    }
                                },
                                new EMFaceRotation
                                {
                                    RoomNumber = -2,
                                    FaceIndices = new int[] { 83 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 2,
                                        [1] = 3,
                                        [2] = 0,
                                        [3] = 1
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [808] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 149 }
                                    }
                                },
                                [806] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 63,77,83,146 }
                                    }
                                },
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,29 }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0 }
                                },
                            }
                        },
                        new EMConvertEntityFunction
                        {
                            Comments = "Repurpose and move the doors.",
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 128,
                            NewEntityType = (short)TREntities.LargeMed_S_P,
                        },
                        new EMModifyEntityFunction
                        {
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 128,
                            Intensity1 = level.Entities[182].Intensity,
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 128,
                            TargetLocation = new EMLocation
                            {
                                X = 60928,
                                Y = 8448,
                                Z = 16896,
                                Room = -1
                            }
                        },
                        new EMConvertEntityFunction
                        {
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 129,
                            NewEntityType = (short)TREntities.Door4,
                        },
                        new EMModifyEntityFunction
                        {
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 129,
                            Intensity1 = level.Entities[31].Intensity,
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 129,
                            TargetLocation = new EMLocation
                            {
                                X = 59904,
                                Y = 10240,
                                Z = 7680,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Lara into the maze.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 38,
                            TargetLocation = new EMLocation
                            {
                                X = 68096,
                                Y = 10240,
                                Z = 14848,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments = "Move the flipmap trigger.",
                            EMType= EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 57856,
                                Y = 10240,
                                Z = 10752,
                                Room = 12,
                            },
                            NewLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63,
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Pad to trigger the door at the maze exit.",
                            EMType= EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 69120,
                                    Y = 10240,
                                    Z = 7680,
                                    Room = -2,
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 18,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 129
                                    }
                                }
                            }
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for default mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMConvertTriggerFunction
                            {
                                Comments = "Tight timer in hard mode.",
                                EMType = EMType.ConvertTrigger,
                                Location = new EMLocation
                                {
                                    X = 69120,
                                    Y = 10240,
                                    Z = 7680,
                                    Room = -2,
                                },
                                Timer = 12,
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Re-open the door from the other side.",
                            EMType= EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 57856,
                                    Y = 10240,
                                    Z = 9728,
                                    Room = 63,
                                },
                                new EMLocation
                                {
                                    X = 57856 + 1024,
                                    Y = 10240,
                                    Z = 9728,
                                    Room = 63,
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 129
                                    }
                                }
                            }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments = "Auto-generate vertex lighting in the new room.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1,-2 }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a long drop before the beginning.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 8,
                            Width = 4,
                            Depth = 7,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                RandomRotationSeed = 17042021
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -768,
                                    Z = 2048 - 512,
                                    Intensity1 = 4096,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 45056 - 1024,
                                Y = -18688,// -23040 + 1024,
                                Z = 17408 - 1024,
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 44-8-13,
                            Width = 3,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                RandomRotationSeed = 12482012
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -5*1024 + 256,
                                    Z = 2048 - 512,
                                    Intensity1 = 4096,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                },
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -512,
                                    Z = 2048 - 512,
                                    Intensity1 = 2048,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368 - 14*1024,
                                Y = -24064 + 11264,
                                Z = 7168 + 3*3072,
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 44,
                            Width = 3,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                RandomRotationSeed = 12482012
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -9*1024,
                                    Z = 2048 - 512,
                                    Intensity1 = 4096,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                },
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -512,
                                    Z = 2048 - 512,
                                    Intensity1 = 2048,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368 - 14*1024,
                                Y = -24064 + 2*11264,
                                Z = 7168 + 3*3072,
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 44,
                            Width = 3,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 106,
                                Ceiling = 83,
                                Wall4 = 84,
                                RandomRotationSeed = 12482012
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -9*1024,
                                    Z = 2048 - 512,
                                    Intensity1 = 4096,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                },
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -512,
                                    Z = 2048 - 512,
                                    Intensity1 = 2048,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368 - 14*1024,
                                Y = -24064 + 3*11264,
                                Z = 7168 + 3*3072,
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 4,
                            Depth = 6,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                Wall1 = 107,
                                RandomRotationSeed = 12482012,
                                WallAlignment = Direction.Down
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -1024-512,
                                    Z = 4096 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368 - 14*1024,
                                Y = 9728 + 2*1024,
                                Z = 7168 + 6*1024,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 7,8 },
                                [-2] = new List<int> { 13 },
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 6,
                            Width = 7,
                            Depth = 9,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                Wall1 = 107,
                                RandomRotationSeed = 12482012
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -512-768,
                                    Z = 6 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                },
                                new EMRoomLight
                                {
                                    X = 5 * 1024 + 512,
                                    Y = -1024,
                                    Z = 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368 - 13*1024,
                                Y = 9728 + 2*1024 - 512 - 512,
                                Z = 7168 - 1024// + 6*1024,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-2] = new List<int> { 10,11,12,13,14,15,/*16,*/19,28,37,46 },
                                [-127] = new List<int> { 20,21,22,23,24,25,
                                                         29,30,31,32,33,34,
                                                         38,39,40,41,42,43,
                                                         47,48,49,50,51,52 }
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 12,
                            Width =8,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                Wall1 = 107,
                                RandomRotationSeed = 12482012,
                                WallAlignment = Direction.Down
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -2048-512,
                                    Z = 2048 - 512,
                                    Intensity1 = 2048,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                },
                                new EMRoomLight
                                {
                                    X = 6 * 1024 + 512,
                                    Y = -2048-512,
                                    Z = 1024 + 512,
                                    Intensity1 = 4608,
                                    Fade1 = 1024,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368 - 8*1024,
                                Y = 9728 + 512 + 2048,
                                Z = 7168 - 1024,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-3] = new List<int> { 19 },
                                [-7] = new List<int> { 10 }
                            }
                        },
                        new EMVisibilityPortalFunction
                        {
                            Comments = "Visibility portals for the new rooms.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 63,
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
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 63,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 7 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7 * 1024,
                                            Y = 10240,
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
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = -3,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10752 - 1024,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10752 - 1024,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10752,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10752,
                                            Z = 8 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -3,
                                    AdjoiningRoom = -2,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10752 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10752 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10752,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10752,
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
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 9728,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 9728,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 9728,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 9728,
                                            Z = 5 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -4,
                                    AdjoiningRoom = -3,
                                    Normal = new TRVertex
                                    {
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 9728,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 9728,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 9728,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 9728,
                                            Z = 1 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -4,
                                    AdjoiningRoom = -5,
                                    Normal = new TRVertex
                                    {
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1536,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -1536,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -1536,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1536,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -5,
                                    AdjoiningRoom = -4,
                                    Normal = new TRVertex
                                    {
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1536,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -1536,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -1536,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1536,
                                            Z = 1 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -5,
                                    AdjoiningRoom = -6,
                                    Normal = new TRVertex
                                    {
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -12800,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -12800,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -12800,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -12800,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -6,
                                    AdjoiningRoom = -5,
                                    Normal = new TRVertex
                                    {
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -12800,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -12800,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -12800,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -12800,
                                            Z = 1 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -6,
                                    AdjoiningRoom = -7,
                                    Normal = new TRVertex
                                    {
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -18688,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -18688,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -18688,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -18688,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -7,
                                    AdjoiningRoom = -6,
                                    Normal = new TRVertex
                                    {
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -18688,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -18688,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -18688,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -18688,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Collisional portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [63] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 57856 - 1024,
                                            Y = 10240,
                                            Z = 7680,
                                            Room = 63
                                        },
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [63] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 57856,
                                            Y = 10240,
                                            Z = 7680,
                                            Room = -1
                                        },
                                    },
                                },
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 50688 + 1024,
                                            Y = 10240,
                                            Z = 7680,
                                            Room = -2
                                        },
                                    },
                                    [-3] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 46592,
                                            Y = 10752,
                                            Z = 13824 + 1024,
                                            Room = -2
                                        },
                                    },
                                },
                                [-3] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 46592,
                                            Y = 10752,
                                            Z = 13824,
                                            Room = -1
                                        },
                                    },
                                },
                                //[-6] = new Dictionary<short, EMLocation[]>
                                //{
                                //    [-7] = new EMLocation[]
                                //    {
                                //        new EMLocation
                                //        {
                                //            X = 45568,
                                //            Y = -22016,
                                //            Z = 18944,
                                //            Room = -6
                                //        }
                                //    }
                                //},
                                //[-7] = new Dictionary<short, EMLocation[]>
                                //{
                                //    [-6] = new EMLocation[]
                                //    {
                                //        new EMLocation
                                //        {
                                //            X = 45568,
                                //            Y = -22016,
                                //            Z = 18944 - 1024,
                                //            Room = -7
                                //        }
                                //    }
                                //}
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 45568,
                                Y = 9728,
                                Z = 17920,
                                Room = -4
                            },
                            Floor = new EMLocation
                            {
                                X = 45568,
                                Y = 9728 + 1024,
                                Z = 17920,
                                Room = -3
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 45568,
                                Y = -1536,
                                Z = 17920,
                                Room = -5
                            },
                            Floor = new EMLocation
                            {
                                X = 45568,
                                Y = -1536 + 1024,
                                Z = 17920,
                                Room = -4
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 45568,
                                Y = -12800,
                                Z = 17920,
                                Room = -6
                            },
                            Floor = new EMLocation
                            {
                                X = 45568,
                                Y = -12800 + 1024,
                                Z = 17920,
                                Room = -5
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 45568,
                                Y = -18688,
                                Z = 17920,
                                Room = -7
                                //50285, -18688, 45656
                            },
                            Floor = new EMLocation
                            {
                                X = 45568,
                                Y = -18688 + 1024,
                                Z = 17920,
                                Room = -6
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Change some faces/textures.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 63,
                                    FaceIndex = 2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -7,
                                    FaceIndex = 45,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -7,
                                    FaceIndex = 23,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 1024
                                        }
                                    }
                                },
                            },
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = -7,
                                    FaceIndices = new int[] { 23 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 1,
                                        [1] = 2,
                                        [2] = 3,
                                        [3] = 0
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [35] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 4 }
                                    },
                                },
                                [106] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 7 }
                                    },
                                },
                                [806] = new EMGeometryMap
                                {
                                    [-7] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 23,45 }
                                    },
                                },
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 53 }
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 28,48 }
                                },
                                [-3] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 19 }
                                },
                                [-4] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 1 }
                                },
                                [-5] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0,1 }
                                },
                                [-6] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0,1 }
                                },
                                [-7] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0,22,44 }
                                },
                            }
                        },
                        new EMFloodFunction
                        {
                            Comments = "Flood the rooms after the drop.",
                            EMType = EMType.Flood,
                            RoomNumbers = new int[] { -2, -3 }
                        },
                        new EMConvertEntityFunction
                        {
                            Comments = "Convert and repurpose the doors.",
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 128,
                            NewEntityType = (short)TREntities.UnderwaterSwitch,
                        },
                        new EMModifyEntityFunction
                        {
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 128,
                            Intensity1 = level.Entities[62].Intensity,
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 128,
                            TargetLocation = new EMLocation
                            {
                                X = 46592,
                                Y = 10240 - 512,
                                Z = 10752,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMConvertEntityFunction
                        {
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 129,
                            NewEntityType = (short)TREntities.Door6,
                        },
                        new EMModifyEntityFunction
                        {
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 129,
                            Intensity1 = level.Entities[64].Intensity,
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 129,
                            TargetLocation = new EMLocation
                            {
                                X = 46592,
                                Y = 10240,
                                Z = 10752 - 1024,
                                Room = -2
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 46592,
                                    Y = 10240,
                                    Z = 10752,
                                    Room = -2
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Switch,
                                SwitchOrKeyRef = 128,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 129
                                    }
                                }
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Lara.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 38,
                            TargetLocation = new EMLocation
                            {
                                X = 45568,
                                Y = -18688,
                                Z = 20992 + 1024,
                                Room = -7,
                                Angle = -32768
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments = "Move the flipmap trigger.",
                            EMType= EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 57856,
                                Y = 10240,
                                Z = 10752,
                                Room = 12,
                            },
                            NewLocation = new EMLocation
                            {
                                X = 58880 - 1024,
                                Y = 10240,
                                Z = 7680,
                                Room = 63,
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Music for the drop.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 45568,
                                    Y = 11776,
                                    Z = 17920,
                                    Room = -3
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Action = FDTrigAction.PlaySoundtrack,
                                        Parameter = 10
                                    }
                                }
                            }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments = "Auto-generate vertex lighting in the new room.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1,-2,-3,-4,-5,-6,-7 }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make an RX-Tech style maze at the beginning.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 4,
                            Width = 5,
                            Depth = 6,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                RandomRotationSeed = 12402008
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -768,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 4608,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 3 * 1024 + 512,
                                    Y = -768,
                                    Z = 4 * 1024 + 512,
                                    Intensity1 = level.Rooms[63].Lights[0].Intensity,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368,
                                Y = 10240,
                                Z = 7168 - 1024,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> {8,9,10,19,20,21}
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 4,
                            Width = 3,
                            Depth = 9,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                RandomRotationSeed = 12402008
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -768,
                                    Z = 4 * 1024 + 512,
                                    Intensity1 = level.Rooms[63].Lights[0].Intensity,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368 + 3072,
                                Y = 10240,
                                Z = 7168 - 1024,
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 4,
                            Width = 7,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                RandomRotationSeed = 12402008
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 3 * 1024 + 512,
                                    Y = -768,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368 + 4096,
                                Y = 10240,
                                Z = 7168 - 1024,
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 4,
                            Width = 7,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                RandomRotationSeed = 12402008
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 3 * 1024 + 512,
                                    Y = -768,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368 + 4096,
                                Y = 10240,
                                Z = 7168 + 5* 1024,
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 4,
                            Width = 3,
                            Depth = 9,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                RandomRotationSeed = 12402008
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -768,
                                    Z = 4 * 1024 + 512,
                                    Intensity1 = level.Rooms[63].Lights[0].Intensity,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368 + 3072*3,
                                Y = 10240,
                                Z = 7168 - 1024,
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 7,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 84,
                                RandomRotationSeed = 17042021
                            },
                            AmbientLighting = level.Rooms[63].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[63].RoomData.Vertices[level.Rooms[63].RoomData.Rectangles[17].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 5 * 1024 + 512,
                                    Y = -768-1024,
                                    Z = 2048 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = level.Rooms[63].Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63
                            },
                            Location = new EMLocation
                            {
                                X = 58368 + 5 * 1024,
                                Y = 10240 + 2048,
                                Z = 7168 + 1024,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-4] = new List<int> {22},
                                [-127] = new List<int> {21}
                            }
                        },
                        new EMVisibilityPortalFunction
                        {
                            Comments = "Visibility portals for the new rooms.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 63,
                                    AdjoiningRoom = -6,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -6,
                                    AdjoiningRoom = 63,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -6,
                                    AdjoiningRoom = -5,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 10240,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 10240,
                                            Z = 5 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -5,
                                    AdjoiningRoom = -6,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 4 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -5,
                                    AdjoiningRoom = -4,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -4,
                                    AdjoiningRoom = -5,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -5,
                                    AdjoiningRoom = -3,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240,
                                            Z = 8 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -3,
                                    AdjoiningRoom = -5,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -4,
                                    AdjoiningRoom = -2,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
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
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
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
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = -3,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240 - 1024,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 7 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 10240,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 10240,
                                            Z = 4 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = -2,
                                    Normal = new TRVertex
                                    {
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 10240,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 10240,
                                            Z = 3 * 1024
                                        }
                                    }
                                },
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Collisional portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [63] = new Dictionary<short, EMLocation[]>
                                {
                                    [-6] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 58880 + 1024,
                                            Y = 10240,
                                            Z = 7680,
                                            Room = 63
                                        },
                                    }
                                },
                                [-6] = new Dictionary<short, EMLocation[]>
                                {
                                    [63] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 58880,
                                            Y = 10240,
                                            Z = 7680,
                                            Room = -6
                                        },
                                    },
                                    [-5] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 62976,
                                            Y = 10240,
                                            Z = 10752,
                                            Room = -6
                                        },
                                    },
                                },
                                [-5] = new Dictionary<short, EMLocation[]>
                                {
                                    [-6] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 62976 - 1024,
                                            Y = 10240,
                                            Z = 10752,
                                            Room = -5
                                        },
                                    },
                                    [-4] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 64000,
                                            Y = 10240,
                                            Z = 7680,
                                            Room = -5
                                        },
                                    },
                                    [-3] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 64000,
                                            Y = 10240,
                                            Z = 13824,
                                            Room = -5
                                        },
                                    }
                                },
                                [-4] = new Dictionary<short, EMLocation[]>
                                {
                                    [-5] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 64000 - 1024,
                                            Y = 10240,
                                            Z = 7680,
                                            Room = -4
                                        },
                                    },
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 69120,
                                            Y = 10240,
                                            Z = 7680,
                                            Room = -4
                                        },
                                    }
                                },
                                [-3] = new Dictionary<short, EMLocation[]>
                                {
                                    [-5] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 64000 - 1024,
                                            Y = 10240,
                                            Z = 13824,
                                            Room = -3
                                        },
                                    },
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 69120,
                                            Y = 10240,
                                            Z = 13824,
                                            Room = -3
                                        },
                                    }
                                },
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [-4] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 69120 - 1024,
                                            Y = 10240,
                                            Z = 7680,
                                            Room = -2
                                        },
                                    },
                                    [-3] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 69120 - 1024,
                                            Y = 10240,
                                            Z = 13824,
                                            Room = -2
                                        },
                                    }
                                },
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 69120,
                                Y = 11264 - 1024,
                                Z = 10752,
                                Room = -2
                            },
                            Floor = new EMLocation
                            {
                                X = 69120,
                                Y = 11264,
                                Z = 10752,
                                Room = -1
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Change some faces/textures.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 63,
                                    FaceIndex = 17,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 9,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 3,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = 1024
                                        }
                                    }
                                },
                            },
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = -1,
                                    FaceIndices = new int[] { 3 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 3,
                                        [1] = 0,
                                        [2] = 1,
                                        [3] = 2
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [806] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3,9 }
                                    },
                                },
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,8,40 }
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,13,27 }
                                },
                                [-3] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,20 }
                                },
                                [-4] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,20 }
                                },
                                [-5] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 3,29,15 }
                                },
                                [-6] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,24 }
                                },
                            }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments = "Auto-generate vertex lighting in the new room.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1,-2,-3,-4,-5,-6 }
                        },
                        new EMConvertEntityFunction
                        {
                            Comments = "Convert and move the doors.",
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 128,
                            NewEntityType = (short)TREntities.Door4,
                        },
                        new EMModifyEntityFunction
                        {
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 128,
                            Intensity1 = level.Entities[31].Intensity,
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 128,
                            TargetLocation = new EMLocation
                            {
                                X = 61952 + 1024,
                                Y = 10240,
                                Z = 10752,
                                Room = -6,
                                Angle = 16384
                            }
                        },
                        new EMConvertEntityFunction
                        {
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 129,
                            NewEntityType = (short)TREntities.Door4,
                        },
                        new EMModifyEntityFunction
                        {
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 129,
                            Intensity1 = level.Entities[31].Intensity,
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 129,
                            TargetLocation = new EMLocation
                            {
                                X = 69120,
                                Y = 10240,
                                Z = 9728 + 1024,
                                Room = -2
                            }
                        },
                        new EMConvertEntityFunction
                        {
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 69,
                            NewEntityType = (short)TREntities.Door4,
                        },
                        new EMModifyEntityFunction
                        {
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 69,
                            Intensity1 = level.Entities[31].Intensity,
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "This door is stolen from the Adam platform.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 69,
                            TargetLocation = new EMLocation
                            {
                                X = 64000 - 1024,
                                Y = 10240,
                                Z = 13824,
                                Room = -3,
                                Angle = -16384
                            }
                        },
                        new EMRemoveCollisionalPortalFunction
                        {
                            Comments = "Remove the unneeded collissional portal.",
                            EMType = EMType.RemoveCollisionalPortal,
                            Location1 = new EMLocation
                            {
                                X = 64000 + 1024,
                                Y = -15616,
                                Z = 45568,
                                Room = 36
                            },
                            Location2 = new EMLocation
                            {
                                X = 64000,
                                Y = -15616,
                                Z = 45568,
                                Room = 48
                            }
                        },
                        new EMAddFaceFunction
                        {
                            Comments = "Add a quad where the door was.",
                            EMType = EMType.AddFace,
                            Quads = new Dictionary<short, List<TRFace4>>
                            {
                                [36] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 812,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[36].RoomData.Rectangles[167].Vertices[3],
                                            level.Rooms[36].RoomData.Rectangles[167].Vertices[2],
                                            level.Rooms[36].RoomData.Rectangles[151].Vertices[0],
                                            level.Rooms[36].RoomData.Rectangles[151].Vertices[3],
                                        }
                                    }
                                }
                            }
                        },

                        new EMTriggerFunction
                        {
                            Comments = "Triggers for the door puzzle.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 69120,
                                    Y = 10240,
                                    Z = 11776,
                                    Room = -2
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 128
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 68096,
                                    Y = 10240,
                                    Z = 13824,
                                    Room = -3
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 69
                                    }
                                }
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
                                    Y = 10240,
                                    Z = 12800,
                                    Room = -5
                                },
                                new EMLocation
                                {
                                    X = 62976,
                                    Y = 10240,
                                    Z = 12800-1024,
                                    Room = -5
                                },
                                new EMLocation
                                {
                                    X = 62976,
                                    Y = 10240,
                                    Z = 12800+1024,
                                    Room = -5
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
                                        Parameter = 128,
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = 129,
                                    }
                                }
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
                                    Y = 10240,
                                    Z = 8704,
                                    Room = -5
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Antipad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 69,
                                    },
                                }
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
                                    Y = 10240,
                                    Z = 8704,
                                    Room = -2
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 129
                                    }
                                }
                            }
                        },

                        new EMMoveEntityFunction
                        {
                            Comments = "Move Lara.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 38,
                            TargetLocation = new EMLocation
                            {
                                X = 66048 - 1024,
                                Y = 12288,
                                Z = 9728,
                                Room = -1,
                                Angle = 16384
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments = "Move the flipmap trigger.",
                            EMType= EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 57856,
                                Y = 10240,
                                Z = 10752,
                                Room = 12,
                            },
                            NewLocation = new EMLocation
                            {
                                X = 58880,
                                Y = 10240,
                                Z = 7680,
                                Room = 63,
                            }
                        },
                    }
                }
            };

            EMCreateRoomFunction func = mapping.AllWithin[4][0][0] as EMCreateRoomFunction;
            foreach (EMLocation loc in JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("atlantismaze.json"))[Level])
            {
                int x = (loc.X - func.Location.X) / 1024;
                int z = (loc.Z - func.Location.Z) / 1024;
                func.FloorHeights[-127].Add(x * func.Depth + z);
            }

            mapping.OneOf = new List<EMEditorGroupedSet>
            {
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 7.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[7].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                {
                                    [7] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 4 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = 7680,
                                    Z = 18944,
                                    Room = 7,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 2 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = 7680,
                                    Z = 18944,
                                    Room = 7,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808 + 1 * 1024,
                                    Y = 7680,
                                    Z = 18944,
                                    Room = 7,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 69 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808 + 2 * 1024,
                                    Y = 7680,
                                    Z = 18944,
                                    Room = 7,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 113 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808 + 3 * 1024,
                                    Y = 7680,
                                    Z = 18944,
                                    Room = 7,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 175 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808 + 4 * 1024,
                                    Y = 7680,
                                    Z = 18944,
                                    Room = 7,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 219 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808 + 5 * 1024,
                                    Y = 7680,
                                    Z = 18944,
                                    Room = 7,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 259 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808 + 6 * 1024,
                                    Y = 7680,
                                    Z = 18944,
                                    Room = 7,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 299 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808 + 7 * 1024,
                                    Y = 7680,
                                    Z = 18944,
                                    Room = 7,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 347 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = 7680,
                                    Z = 18944 + 2 * 1024,
                                    Room = 7,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 8 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = 7680,
                                    Z = 18944 + 3 * 1024,
                                    Room = 7,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 13 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = 7680,
                                    Z = 18944 + 4 * 1024,
                                    Room = 7,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 17 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = 7680,
                                    Z = 18944 + 5 * 1024,
                                    Room = 7,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 21 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808 + 8 * 1024,
                                    Y = 7680,
                                    Z = 18944 + 2 * 1024,
                                    Room = 7,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 448 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808 + 8 * 1024,
                                    Y = 7680,
                                    Z = 18944 + 3 * 1024,
                                    Room = 7,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 450 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808 + 8 * 1024,
                                    Y = 7680,
                                    Z = 18944 + 4 * 1024,
                                    Room = 7,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 452 }
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
                                EntityIndex = 15,
                                Location = new EMLocation
                                {
                                    X = 55808 + 8 * 1024,
                                    Y = 7680,
                                    Z = 18944 + 5 * 1024,
                                    Room = 7,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[7].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                    {
                                        [7] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 454 }
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
                            Comments = "Remove the default lever texture in room 11.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[11].RoomData.Rectangles[38].Texture] = new EMGeometryMap
                                {
                                    [11] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 60 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120,
                                    Y = 9472,
                                    Z = 36352,
                                    Room = 11,
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 56 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 1 * 1024,
                                    Y = 9472,
                                    Z = 36352,
                                    Room = 11,
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 38 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 2 * 1024,
                                    Y = 9472 + 256,
                                    Z = 36352,
                                    Room = 11,
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 28 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 2 * 1024,
                                    Y = 9472 + 256,
                                    Z = 36352,
                                    Room = 11,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 27 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 1 * 1024,
                                    Y = 9472,
                                    Z = 36352,
                                    Room = 11,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 37 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 0 * 1024,
                                    Y = 9472 - 1 * 256,
                                    Z = 36352 - 1 * 1024,
                                    Room = 11,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 59 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 0 * 1024,
                                    Y = 9472 - 1 * 256,
                                    Z = 36352 - 1 * 1024,
                                    Room = 11,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 50 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 0 * 1024,
                                    Y = 9472 - 2 * 256,
                                    Z = 36352 - 2 * 1024,
                                    Room = 11,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 58 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 0 * 1024,
                                    Y = 9472 - 2 * 256,
                                    Z = 36352 - 2 * 1024,
                                    Room = 11,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 45 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 0 * 1024,
                                    Y = 9472 - 3 * 256,
                                    Z = 36352 - 3 * 1024,
                                    Room = 11,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 57 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 0 * 1024,
                                    Y = 9472 - 3 * 256,
                                    Z = 36352 - 3 * 1024,
                                    Room = 11,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 42 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 1 * 1024,
                                    Y = 9472 - 4 * 256,
                                    Z = 36352 - 3 * 1024,
                                    Room = 11,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 32 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 1 * 1024,
                                    Y = 9472 - 4 * 256,
                                    Z = 36352 - 3 * 1024,
                                    Room = 11
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 33 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 2 * 1024,
                                    Y = 9472 - 5 * 256,
                                    Z = 36352 - 3 * 1024,
                                    Room = 11,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 22 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 2 * 1024,
                                    Y = 9472 - 5 * 256,
                                    Z = 36352 - 3 * 1024,
                                    Room = 11
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 23 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 3 * 1024,
                                    Y = 9472 - 6 * 256,
                                    Z = 36352 - 3 * 1024,
                                    Room = 11,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 12 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 69120 - 3 * 1024,
                                    Y = 9472 - 6 * 256,
                                    Z = 36352 - 3 * 1024,
                                    Room = 11
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[60].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 13 }
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
                            Comments = "Remove the default lever texture in room 16.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[16].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                {
                                    [16] = new Dictionary<EMTextureFaceType, int[]>
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
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 73216,
                                    Y = 10752,
                                    Z = 44544,
                                    Room = 16,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [16] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 19 }
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
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 73216,
                                    Y = 10752,
                                    Z = 44544 - 1024,
                                    Room = 16,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [16] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 18 }
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
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 73216,
                                    Y = 10752,
                                    Z = 44544 - 1024,
                                    Room = 16,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [16] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 13 }
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
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 70144,
                                    Y = 8448,
                                    Z = 43520,
                                    Room = 13,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [13] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 70 }
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
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 70144,
                                    Y = 8448,
                                    Z = 43520,
                                    Room = 13
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [13] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 73216,
                                    Y = 10752,
                                    Z = 44544 + 1024,
                                    Room = 15,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [15] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 15 }
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
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 73216,
                                    Y = 10752,
                                    Z = 44544 + 1024,
                                    Room = 15
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [15] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 70144,
                                    Y = 11776,
                                    Z = 45568,
                                    Room = 15
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [15] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
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
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 70144,
                                    Y = 11776,
                                    Z = 45568,
                                    Room = 15,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [15] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 2 }
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
                            Comments = "Remove the default lever texture in room 26.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[26].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                {
                                    [26] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 18 }
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
                                Comments = "Effectively NOOP - reverse the texture change from leader.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[26].RoomData.Rectangles[18].Texture] = new EMGeometryMap
                                    {
                                        [26] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 18 }
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
                                EntityIndex = 56,
                                Location = new EMLocation
                                {
                                    X = 62976,
                                    Y = 8192,
                                    Z = 65024,
                                    Room = 26
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[26].RoomData.Rectangles[18].Texture] = new EMGeometryMap
                                    {
                                        [26] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 56,
                                Location = new EMLocation
                                {
                                    X = 62976,
                                    Y = 8192,
                                    Z = 65024 - 1024,
                                    Room = 26,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[26].RoomData.Rectangles[18].Texture] = new EMGeometryMap
                                    {
                                        [26] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 17 }
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
                                        FaceIndices = new int[]{ 17 },
                                        RoomNumber = 26,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 3,
                                            [1] = 0,
                                            [2] = 1,
                                            [3] = 2
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
                                EntityIndex = 56,
                                Location = new EMLocation
                                {
                                    X = 62976,
                                    Y = 8192,
                                    Z = 65024 - 1024,
                                    Room = 26,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[26].RoomData.Rectangles[18].Texture] = new EMGeometryMap
                                    {
                                        [26] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 13 }
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
                                        FaceIndices = new int[]{ 13 },
                                        RoomNumber = 26,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 3,
                                            [1] = 0,
                                            [2] = 1,
                                            [3] = 2
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
                            Comments = "Remove the default lever texture in room 33.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[33].RoomData.Rectangles[38].Texture] = new EMGeometryMap
                                {
                                    [33] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 39 }
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
                                Comments = "Effectively NOOP - reverse the texture change from leader.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[33].RoomData.Rectangles[39].Texture] = new EMGeometryMap
                                    {
                                        [33] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 39 }
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
                                EntityIndex = 65,
                                Location = new EMLocation
                                {
                                    X = 50688,
                                    Z = 36352,
                                    Room = 33,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[33].RoomData.Rectangles[39].Texture] = new EMGeometryMap
                                    {
                                        [33] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 38 }
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
                                EntityIndex = 65,
                                Location = new EMLocation
                                {
                                    X = 50688 - 2 * 1024,
                                    Y = 512,
                                    Z = 36352,
                                    Room = 33,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[33].RoomData.Rectangles[39].Texture] = new EMGeometryMap
                                    {
                                        [33] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 23 }
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
                                        FaceIndices = new int[]{ 23 },
                                        RoomNumber = 33,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 3,
                                            [1] = 0,
                                            [2] = 1,
                                            [3] = 2
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
                                EntityIndex = 65,
                                Location = new EMLocation
                                {
                                    X = 50688 - 2 * 1024,
                                    Y = 2816,
                                    Z = 36352 - 5 * 1024,
                                    Room = 33,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[33].RoomData.Rectangles[39].Texture] = new EMGeometryMap
                                    {
                                        [33] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 8 }
                                        }
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 65,
                                Location = new EMLocation
                                {
                                    X = 50688 - 2 * 1024,
                                    Y = 2816,
                                    Z = 36352 - 5 * 1024,
                                    Room = 33,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[33].RoomData.Rectangles[39].Texture] = new EMGeometryMap
                                    {
                                        [33] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 27 }
                                        }
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 65,
                                Location = new EMLocation
                                {
                                    X = 50688 - 2 * 1024,
                                    Y = 2816,
                                    Z = 36352 - 6 * 1024,
                                    Room = 33,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[33].RoomData.Rectangles[39].Texture] = new EMGeometryMap
                                    {
                                        [33] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 5 }
                                        }
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 65,
                                Location = new EMLocation
                                {
                                    X = 50688 - 2 * 1024,
                                    Y = 2816,
                                    Z = 36352 - 6 * 1024,
                                    Room = 33,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[33].RoomData.Rectangles[39].Texture] = new EMGeometryMap
                                    {
                                        [33] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 26 }
                                        }
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 65,
                                Location = new EMLocation
                                {
                                    X = 50688 - 2 * 1024,
                                    Y = 2816,
                                    Z = 36352 - 7 * 1024,
                                    Room = 33,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[33].RoomData.Rectangles[39].Texture] = new EMGeometryMap
                                    {
                                        [33] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 25 }
                                        }
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 65,
                                Location = new EMLocation
                                {
                                    X = 50688 - 2 * 1024,
                                    Y = 2816,
                                    Z = 36352 - 7 * 1024,
                                    Room = 33,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[33].RoomData.Rectangles[39].Texture] = new EMGeometryMap
                                    {
                                        [33] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                        }
                                    }
                                }
                            },
                        },
                    }
                },
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 40.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[40].RoomData.Rectangles[431].Texture] = new EMGeometryMap
                                {
                                    [40] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 433 }
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
                                Comments = "Effectively NOOP - reverse the texture change from leader.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[40].RoomData.Rectangles[433].Texture] = new EMGeometryMap
                                    {
                                        [40] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 433 }
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
                                EntityIndex = 83,
                                Location = new EMLocation
                                {
                                    X = 61952,
                                    Y = -256,
                                    Z = 66048,
                                    Room = 40
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[40].RoomData.Rectangles[433].Texture] = new EMGeometryMap
                                    {
                                        [40] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 413 }
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
                                        FaceIndices = new int[]{ 413 },
                                        RoomNumber = 40,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 3,
                                            [1] = 0,
                                            [2] = 1,
                                            [3] = 2
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
                                EntityIndex = 83,
                                Location = new EMLocation
                                {
                                    X = 61952 - 4 * 1024,
                                    Y = 1024,
                                    Z = 66048,
                                    Room = 40
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[40].RoomData.Rectangles[433].Texture] = new EMGeometryMap
                                    {
                                        [40] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 282 }
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
                                        FaceIndices = new int[]{ 282 },
                                        RoomNumber = 40,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 3,
                                            [1] = 0,
                                            [2] = 1,
                                            [3] = 2
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
                                EntityIndex = 83,
                                Location = new EMLocation
                                {
                                    X = 61952 - 5 * 1024,
                                    Y = 1024,
                                    Z = 66048,
                                    Room = 40
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[40].RoomData.Rectangles[433].Texture] = new EMGeometryMap
                                    {
                                        [40] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 249 }
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
                                EntityIndex = 83,
                                Location = new EMLocation
                                {
                                    X = 61952 - 5 * 1024,
                                    Y = 1024,
                                    Z = 66048,
                                    Room = 40,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[40].RoomData.Rectangles[433].Texture] = new EMGeometryMap
                                    {
                                        [40] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 247 }
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
                            Comments = "Remove the default lever texture in room 47.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[47].RoomData.Rectangles[361].Texture] = new EMGeometryMap
                                {
                                    [47] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 346 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Vertex adjustments for above.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    FaceIndex = 346,
                                    RoomNumber = 47,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -512
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 347,
                                    RoomNumber = 47,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = -512
                                        }
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
                                EntityIndex = 106,
                                Location = new EMLocation
                                {
                                    X = 59904,
                                    Y = -13056,
                                    Z = 57856,
                                    Room = 47,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[47].RoomData.Rectangles[346].Texture] = new EMGeometryMap
                                    {
                                        [47] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 361 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 106,
                                Location = new EMLocation
                                {
                                    X = 59904,
                                    Y = -13056,
                                    Z = 57856 + 1024,
                                    Room = 47,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[47].RoomData.Rectangles[346].Texture] = new EMGeometryMap
                                    {
                                        [47] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 363 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 106,
                                Location = new EMLocation
                                {
                                    X = 59904,
                                    Y = -13056,
                                    Z = 57856 + 1024,
                                    Room = 47
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[47].RoomData.Rectangles[346].Texture] = new EMGeometryMap
                                    {
                                        [47] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 351 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 106,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = -15104,
                                    Z = 58880,
                                    Room = 47
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[47].RoomData.Rectangles[346].Texture] = new EMGeometryMap
                                    {
                                        [47] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 287 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 106,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = -15104,
                                    Z = 58880,
                                    Room = 47,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[47].RoomData.Rectangles[346].Texture] = new EMGeometryMap
                                    {
                                        [47] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 286 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 106,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = -10240,
                                    Z = 55808,
                                    Room = 84,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[47].RoomData.Rectangles[346].Texture] = new EMGeometryMap
                                    {
                                        [84] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 30 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 106,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = -10240,
                                    Z = 55808 - 1024,
                                    Room = 84,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[47].RoomData.Rectangles[346].Texture] = new EMGeometryMap
                                    {
                                        [84] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 28 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 106,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = -10240,
                                    Z = 55808 - 2048,
                                    Room = 84,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[47].RoomData.Rectangles[346].Texture] = new EMGeometryMap
                                    {
                                        [84] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 26 }
                                        }
                                    }
                                }
                            },

                        },
                    }
                },
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 88.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[88].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                {
                                    [88] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 17 }
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
                                EntityIndex = 170,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = -5120,
                                    Z = 42496,
                                    Room = 88,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[88].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [88] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 16 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 170,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = -5120,
                                    Z = 42496 - 1024,
                                    Room = 88,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[88].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [88] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 13 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 170,
                                Location = new EMLocation
                                {
                                    X = 53760 - 1024,
                                    Y = -5120,
                                    Z = 42496 - 2048,
                                    Room = 88
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[88].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [88] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 7 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 170,
                                Location = new EMLocation
                                {
                                    X = 53760 - 2 * 1024,
                                    Y = -5120,
                                    Z = 42496 - 2048,
                                    Room = 88
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[88].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [88] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 170,
                                Location = new EMLocation
                                {
                                    X = 53760 - 2 * 1024,
                                    Y = -5120,
                                    Z = 42496 - 2048,
                                    Room = 88,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[88].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [88] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 170,
                                Location = new EMLocation
                                {
                                    X = 53760 - 1 * 1024,
                                    Y = -5120,
                                    Z = 42496 - 2048,
                                    Room = 88,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[88].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [88] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 6 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 170,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = -5120,
                                    Z = 42496 - 2048,
                                    Room = 88,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[88].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [88] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 10 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 170,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = -5120,
                                    Z = 42496 - 2048,
                                    Room = 88,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[88].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [88] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 18 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 170,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = -5120,
                                    Z = 42496 - 1024,
                                    Room = 88,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[88].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [88] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 19 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 170,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = -5120,
                                    Z = 42496,
                                    Room = 88,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[88].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [88] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 20 }
                                        }
                                    }
                                }
                            },

                        },
                    }
                },
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 89.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[89].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                {
                                    [89] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2 }
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
                                EntityIndex = 171,
                                Location = new EMLocation
                                {
                                    X = 43520,
                                    Y = -5120,
                                    Z = 37376,
                                    Room = 89,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[89].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [89] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 171,
                                Location = new EMLocation
                                {
                                    X = 43520 + 1024,
                                    Y = -5120,
                                    Z = 37376,
                                    Room = 89,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[89].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [89] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 7 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 171,
                                Location = new EMLocation
                                {
                                    X = 43520 + 2048,
                                    Y = -5120,
                                    Z = 37376,
                                    Room = 89,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[89].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [89] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 11 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 171,
                                Location = new EMLocation
                                {
                                    X = 43520 + 2048,
                                    Y = -5120,
                                    Z = 37376,
                                    Room = 89,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[89].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [89] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 18 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 171,
                                Location = new EMLocation
                                {
                                    X = 43520 + 2048,
                                    Y = -5120,
                                    Z = 37376 + 1024,
                                    Room = 89,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[89].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [89] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 19 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 171,
                                Location = new EMLocation
                                {
                                    X = 43520 + 2048,
                                    Y = -5120,
                                    Z = 37376 + 2048,
                                    Room = 89,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[89].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [89] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 20 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 171,
                                Location = new EMLocation
                                {
                                    X = 43520 + 2048,
                                    Y = -5120,
                                    Z = 37376 + 2048,
                                    Room = 89,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[89].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [89] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 17 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 171,
                                Location = new EMLocation
                                {
                                    X = 43520 + 2048,
                                    Y = -5120,
                                    Z = 37376 + 1024,
                                    Room = 89,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[89].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [89] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 14 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 171,
                                Location = new EMLocation
                                {
                                    X = 43520 + 1024,
                                    Y = -5120,
                                    Z = 37376,
                                    Room = 89
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[89].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [89] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 8 }
                                        }
                                    }
                                }
                            },

                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 171,
                                Location = new EMLocation
                                {
                                    X = 43520,
                                    Y = -5120,
                                    Z = 37376,
                                    Room = 89
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Lever texture for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[89].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [89] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 4 }
                                        }
                                    }
                                }
                            },

                        },
                    }
                }
            };

            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "If Lara's not in the default starting position, move the flipmap trigger to her new location provided she is in the same room.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 38,
                        X = level.Entities[38].X,
                        Y = level.Entities[38].Y,
                        Z = level.Entities[38].Z,
                        Negate = true,
                        And = new List<BaseEMCondition>
                        {
                            new EMEntityPropertyCondition
                            {
                                ConditionType = EMConditionType.EntityProperty,
                                EntityIndex = 38,
                                Room = level.Entities[38].Room
                            }
                        }
                    },
                    OnTrue = new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = level.Entities[38].X,
                                Y = level.Entities[38].Y,
                                Z = level.Entities[38].Z,
                                Room = level.Entities[38].Room
                            },
                            EntityLocation = 38
                        },
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMModelExistsCondition
                    {
                        Comments = "If Adam or Barney is present, we have to change the scion type as the MiscAnim that normally ends the level will have been overwritten.",
                        ConditionType = EMConditionType.ModelExists,
                        ModelID = 34,
                        Or = new List<BaseEMCondition>
                        {
                            new EMModelExistsCondition
                            {
                                ConditionType = EMConditionType.ModelExists,
                                ModelID = 18
                            }
                        },
                    },
                    OnTrue = new EMEditorSet
                    {
                        new EMConvertModelFunction
                        {
                            Comments = "Convert the scion type to the one from Great Pyramid, so Lara has to shoot it to end the level.",
                            EMType = EMType.ConvertModel,
                            OldModelID = 146,
                            NewModelID = 145
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Add a level-end heavy trigger.",
                            EMType = EMType.Trigger,

                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 52736,
                                    Y = -19200,
                                    Z = 45568,
                                    Room = 50
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
                                        Action = FDTrigAction.EndLevel
                                    }
                                }
                            }
                        }
                    }
                }
            };

            mapping.Mirrored = new EMEditorSet
            {
                new EMMoveEntityFunction
                {
                    Comments = "Moves switch 16 otherwise the door here opens against it.",
                    EMType = EMType.MoveEntity,
                    EntityIndex = 16,
                    TargetLocation = new EMLocation
                    {
                        X = 10752,
                        Y = 7680,
                        Z = 18944,
                        Room = 7
                    }
                },
                new EMRefaceFunction
                {
                    Comments = "Switch the faces for above.",
                    EMType = EMType.Reface,
                    TextureMap = new EMTextureMap
                    {
                        [32] = new EMGeometryMap
                        {
                            [7] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 407 }
                            }
                        },
                        [4] = new EMGeometryMap
                        {
                            [7] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 405 }
                            }
                        }
                    }
                },
                new EMConvertEnemyFunction
                {
                    Comments = "Bacon Lara doesn't work when mirrored, so make an alternative scenario in this room.",
                    EMType = EMType.ConvertEnemy,
                    EntityIndices = new List<int> { 126 },
                    NewEnemyType = EnemyType.Land,
                    Exclusions = new List<short>
                    {
                        (short)TREntities.Doppelganger,
                        (short)TREntities.SkateboardKid,
                        (short)TREntities.Natla
                    }
                },
                new EMMoveEntityFunction
                {
                    Comments = "Move the enemy off the slope otherwise it's likely to get stuck.",
                    EMType = EMType.MoveEntity,
                    EntityIndex = 126,
                    TargetLocation = new EMLocation
                    {
                        X = 41472,
                        Y = -13056,
                        Z = 58880,
                        Room = 10
                    }
                },
                new EMRemoveTriggerFunction
                {
                    Comments = "Remove the redundant camera triggers from the room.",
                    EMType = EMType.RemoveTrigger,
                    Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("redundantbacontriggers.json"))[Level]
                },
                new EMConvertEntityFunction
                {
                    Comments = "Turn the trapdoor into a pickup.",
                    EMType = EMType.ConvertEntity,
                    EntityIndex = 32,
                    NewEntityType = (short)TREntities.UziAmmo_S_P
                },
                new EMMoveEntityFunction
                {
                    Comments = "And move it.",
                    EMType = EMType.MoveEntity,
                    EntityIndex = 32,
                    TargetLocation = new EMLocation
                    {
                        X = 33280,
                        Y = -15104,
                        Z = 57856,
                        Room = 10
                    }
                },
                new EMMoveEntityFunction
                {
                    Comments = "Moves the switch to the other side of the room.",
                    EMType = EMType.MoveEntity,
                    EntityIndex = 30,
                    TargetLocation = new EMLocation
                    {
                        X = 42496,
                        Y = -15104,
                        Z = 65024,
                        Room = 10,
                        Angle = 16384
                    }
                },
                new EMRefaceFunction
                {
                    Comments = "Amend faces for above.",
                    EMType = EMType.Reface,
                    TextureMap = new EMTextureMap
                    {
                        [32] = new EMGeometryMap
                        {
                            [10] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 26 }
                            }
                        },
                        [57] = new EMGeometryMap
                        {
                            [10] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 306 }
                            }
                        }
                    }
                },
                new EMTriggerFunction
                {
                    Comments = "Add a trigger to open the door, now on a timer.",
                    EMType = EMType.Trigger,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 42496,
                            Y = -15104,
                            Z = 65024,
                            Room = 10
                        }
                    },
                    Trigger = new EMTrigger
                    {
                        Mask = 31,
                        TrigType = FDTrigType.Switch,
                        SwitchOrKeyRef = 30,
                        Timer = 18,
                        Actions = new List<EMTriggerAction>
                        {
                            new EMTriggerAction
                            {
                                Parameter = 31
                            }
                        }
                    }
                },
                new EMPlaceholderFunction
                {
                    Comments = "Placeholder for easy mode.",
                    EMType = EMType.NOOP,
                    HardVariant = new EMConvertTriggerFunction
                    {
                        Comments = "Tighter timer in hard mode.",
                        EMType = EMType.ConvertTrigger,
                        Location = new EMLocation
                        {
                            X = 42496,
                            Y = -15104,
                            Z = 65024,
                            Room = 10
                        },
                        Timer = 12
                    }
                }
            };

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();

            mapping.RewardEntities = new List<int> { 183, 184, 185, 186, 187, 188, 189, 190, 191 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 53760,
                            Y = -18688,
                            Z = 41472
                        },
                        new Location
                        {
                            X = 52736,
                            Y = -18688,
                            Z = 41472
                        },
                        new Location
                        {
                            X = 51712,
                            Y = -18688,
                            Z = 41472
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door6,
                            X = 53760,
                            Y = -18688,
                            Z = 41472,
                            Angle = -32768,
                            Intensity = 6400,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 53477,
                            Y = -20036,
                            Z = 49855,
                            Room = 50
                        }
                    },
                    CameraTarget = new Location
                    {
                        X = 53760,
                        Y = -19200,
                        Z = 42496,
                        Room = 50
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 37,
                            LinkedLocation = new EMLocation
                            {
                                X = 53760,
                                Y = -18688,
                                Z = 42496,
                                Room = 50
                            },
                            NewLocation = new EMLocation
                            {
                                X = 50176,
                                Y = -18688,
                                Z = 39936,
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [50] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 53760,
                                            Y = -18688,
                                            Z = 41472,
                                            Room = 50
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [50] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 53760,
                                            Y = -18688,
                                            Z = 42496,
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
                                // From/to scion
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 50,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 7168,
                                            Y = -19712,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -19712,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -18688,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 7168,
                                            Y = -18688,
                                            Z = 2048
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 50,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -19712,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -19712,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -18688,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -18688,
                                            Z = 2048
                                        },
                                    }
                                },

                                // From/to centaur switch
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 51,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -19712,
                                            Z = 4096
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -19712,
                                            Z = 3072
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -18688,
                                            Z = 3072
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -18688,
                                            Z = 4096
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 51,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -19712,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -19712,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -18688,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -18688,
                                            Z = 1024
                                        },
                                    }
                                },

                                // From/to main chamber
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 49,
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
                                            Y = -19712,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -19712,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -18688,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -18688,
                                            Z = 1024
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 49,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -19712,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -19712,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -18688,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -18688,
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
                                    RoomNumber = 50,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 120,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 50,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 97,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 50,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 73,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 51,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 40,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 49,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 1280
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 1280
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 49,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 2,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = 256
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 256
                                        }
                                    }
                                }
                            },
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = 49,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[]{1},
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 2,
                                        [1] = 3,
                                        [2] = 0,
                                        [3] = 1
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
                                        Texture = 34,
                                        Vertices = new ushort[]
                                        {
                                            5, 6, 1, 0
                                        }
                                    }
                                },
                                [50] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 35,
                                        Vertices = new ushort[]
                                        {
                                            180, 179, 95, 117
                                        }
                                    },
                                    new TRFace4
                                    {
                                        Texture = 35,
                                        Vertices = new ushort[]
                                        {
                                            182, 181, 67, 95
                                        }
                                    }
                                },
                                [51] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 35,
                                        Vertices = new ushort[]
                                        {
                                            56, 55, 45, 47
                                        }
                                    }
                                },
                                [49] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 35,
                                        Vertices = new ushort[]
                                        {
                                            246, 245, 244, 243
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
                                [38] = new EMGeometryMap
                                {
                                    [50] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 120, 97, 73 }
                                    }
                                },
                                [113] = new EMGeometryMap
                                {
                                    [51] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 40 }
                                    }
                                },
                                [14] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0, 1, 2, 4, 5, 6, 8, 9, 10, 11 }
                                    }
                                },
                                [34] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3, 7, 11 }
                                    }
                                },
                                [134] = new EMGeometryMap
                                {
                                    [49] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 1 }
                                    }
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

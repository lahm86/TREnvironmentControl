using Newtonsoft.Json;
using System;
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
using TRRandomizerCore.Helpers;
using TRRandomizerCore.Secrets;

namespace TREnvironmentControl
{
    public class TR1ObeliskControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.OBELISK;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);
            TRLevel level3b = GetTR1Level(TRLevelNames.QUALOPEC);
            TRLevel level4 = GetTR1Level(TRLevelNames.FOLLY);
            TRLevel level7b = GetTR1Level(TRLevelNames.TIHOCAN);

            mapping.All = new EMEditorSet
            {
                new EMRemoveTriggerFunction
                {
                    Comments = "Remove the trigger for keyhole 3 in City otherwise glitched secrets can become glitchless (e.g. if Pierre drops the key).",
                    EMType = EMType.RemoveTrigger,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 34304,
                            Z = 26112,
                            Room = 11
                        }
                    }
                },
            };

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMDrainFunction
                    {
                        Comments = "Drain the Obelisk pool.",
                        EMType = EMType.Drain,
                        Tags = new List<EMTag>
                        {
                            EMTag.WaterChange
                        },
                        RoomNumbers = new int[] {3},
                        WaterTextures = new ushort[]{ 6, 196, 197, 198 }
                    }
                },
                new EMEditorSet
                {
                    new EMModifyFaceFunction
                    {
                        Comments = "Move some faces to make way for a pillar.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                RoomNumber = 70,
                                FaceIndex = 400,
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
                                RoomNumber = 70,
                                FaceIndex = 399,
                                FaceType = EMTextureFaceType.Rectangles,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        Y = -512,
                                        Z = 1024
                                    },
                                    [1] = new TRVertex
                                    {
                                        Y = -512,
                                        Z = -1024
                                    },
                                    [2] = new TRVertex
                                    {
                                        Y = -768,
                                        Z = -1024
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -768,
                                        Z = 1024
                                    }
                                }
                            }
                        }
                    },
                    new EMFloorFunction
                    {
                        Comments = "Make a new pillar to reach the top.",
                        EMType = EMType.Floor,
                        Clicks = -9,
                        Location = new EMLocation
                        {
                            X = 62976,
                            Y = 3840,
                            Z = 75264,
                            Room = 70
                        },
                        SideTexture = 68,
                        Flags = 13
                    },
                    new EMHorizontalCollisionalPortalFunction
                    {
                        Comments = "Make a portal to the top.",
                        EMType = EMType.HorizontalCollisionalPortal,
                        Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                        {
                            [70] = new Dictionary<short, EMLocation[]>
                            {
                                [72] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 62976 - 1024,
                                        Y = 1536,
                                        Z = 75264,
                                        Room = 70
                                    }
                                }
                            }
                        }
                    },
                    new EMDrainFunction
                    {
                        Comments = "Drain rooms 69 and 70.",
                        EMType = EMType.Drain,
                        Tags = new List<EMTag>
                        {
                            EMTag.WaterChange
                        },
                        RoomNumbers = new int[] {69,70},
                        WaterTextures = new ushort[]{ 6, 196, 197, 198 }
                    },
                },
                new EMEditorSet
                {
                    new EMFloodFunction
                    {
                        Comments = "Flood rooms 2 and 10.",
                        EMType = EMType.Flood,
                        Tags = new List<EMTag>
                        {
                            EMTag.WaterChange
                        },
                        RoomNumbers = new int[] {2,10}
                    }
                },
                new EMEditorSet
                {
                    new EMMoveEnemyFunction
                    {
                        Comments = "Move the enemy unless it's a water creature.",
                        EMType = EMType.MoveEnemy,
                        AttemptWaterCreature = true,
                        IfLandCreature = true,
                        EntityIndex = 94,
                        Location = new EMLocation
                        {
                            X = 69120,
                            Z = 62976,
                            Room = 75
                        }
                    },
                    new EMRefaceFunction
                    {
                        Comments = "Remove the lever texture and put it upstairs instead.",
                        EMType = EMType.Reface,
                        TextureMap = new EMTextureMap
                        {
                            [level.Rooms[74].RoomData.Rectangles[145].Texture] = new EMGeometryMap
                            {
                                [74] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 151 }
                                }
                            },
                            [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                            {
                                [75] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 98 }
                                }
                            }
                        }
                    },
                    new EMMoveSlotFunction
                    {
                        Comments = "Move the lever upstairs.",
                        EMType = EMType.MoveSlot,
                        EntityIndex = 93,
                        Location = new EMLocation
                        {
                            X = 69120,
                            Z = 62976,
                            Room = 75,
                            Angle = -16384
                        }
                    },
                    new EMFloodFunction
                    {
                        Comments = "Flood room 74.",
                        EMType = EMType.Flood,
                        Tags = new List<EMTag>
                        {
                            EMTag.WaterChange
                        },
                        RoomNumbers = new int[] {74},
                        WaterTextures = new ushort[]{ 6, 196, 197, 198 }
                    },
                },
                new EMEditorSet
                {
                    new EMMoveEntityFunction
                    {
                        Comments = "Move the Khamoon keyhole to the exit doors.",
                        EMType = EMType.MoveEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 3,
                        TargetLocation = new EMLocation
                        {
                            X = 29184,
                            Z = 19968,
                            Room = 11,
                            Angle = -16384
                        }
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Make a new trigger for the final doors.",
                        EMType= EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 29184,
                                Z = 19968,
                                Room = 11
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 1 << 4,
                            TrigType = FDTrigType.Key,
                            SwitchOrKeyRef = 3,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 8
                                },
                                new EMTriggerAction
                                {
                                    Parameter = 9
                                }
                            }
                        }
                    },
                    new EMConvertTriggerFunction
                    {
                        Comments = "Change the mask on one of the slot triggers.",
                        EMType = EMType.ConvertTrigger,
                        Location = new EMLocation
                        {
                            X = 38400,
                            Z = 18944,
                            Room = 11
                        },
                        Mask= 1 << 3,
                    },
                    new EMConvertEntityFunction
                    {
                        Comments = "Convert an unsed switch into a key.",
                        EMType = EMType.ConvertEntity,
                        EntityIndex = 12,
                        NewEntityType = (short)TREntities.Key1_S_P
                    },
                    new EMModifyEntityFunction
                    {
                        Comments = "Fix its lighting.",
                        EMType = EMType.ModifyEntity,
                        EntityIndex = 12,
                        Intensity1 = level.Entities[88].Intensity
                    },
                    new EMMoveEntityFunction
                    {
                        Comments = "Move it somewhere reachable. Conditional changes below may shift it elsewhere.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 12,
                        TargetLocation = new EMLocation
                        {
                            X = 35328,
                            Y = -512,
                            Z = 22016,
                            Room = 11
                        },
                    }
                },
                new EMEditorSet
                {
                    new EMCreateRoomFunction
                    {
                        Comments = "Create a maze at the beginning of the level.",
                        EMType = EMType.CreateRoom,
                        Tags = new List<EMTag>
                        {
                            EMTag.PuzzleRoom
                        },
                        Height = 5,
                        Width = 3,
                        Depth = 8,
                        Textures = new EMTextureGroup
                        {
                            Floor = 31,
                            Ceiling = 40,
                            Wall4 = 40,
                            Wall1 = 98,
                            WallAlignment = Direction.Down,
                        },
                        AmbientLighting = level.Rooms[19].AmbientIntensity,
                        DefaultVertex = new EMRoomVertex
                        {
                            Lighting = level.Rooms[46].RoomData.Vertices[level.Rooms[46].RoomData.Rectangles[0].Vertices[2]].Lighting
                        },
                        Lights = new EMRoomLight[]
                        {
                            new EMRoomLight
                            {
                                X = 1 * 1024 + 512,
                                Y = -768,
                                Z = 2 * 1024 + 512,
                                Intensity1 = 2048,
                                Fade1 = 4096,
                            },
                            new EMRoomLight
                            {
                                X = 1 * 1024 + 512,
                                Y = -768,
                                Z = 5 * 1024 + 512,
                                Intensity1 = 2048,
                                Fade1 = 4096,
                            },
                        },
                        LinkedLocation = new EMLocation
                        {
                            X = 51712,
                            Z = 23040,
                            Room = 19
                        },
                        Location = new EMLocation
                        {
                            X = 51200,
                            Z = 22528-2048
                        },
                    },
                    new EMCreateRoomFunction
                    {
                        EMType = EMType.CreateRoom,
                        Height = 5,
                        Width = 10,
                        Depth = 9,
                        Textures = new EMTextureGroup
                        {
                            Floor = 31,
                            Ceiling = 40,
                            Wall4 = 40,
                            Wall1 = 98,
                            WallAlignment = Direction.Down,
                        },
                        AmbientLighting = level.Rooms[19].AmbientIntensity,
                        DefaultVertex = new EMRoomVertex
                        {
                            Lighting = level.Rooms[46].RoomData.Vertices[level.Rooms[46].RoomData.Rectangles[0].Vertices[2]].Lighting
                        },
                        Lights = new EMRoomLight[]
                        {
                            new EMRoomLight
                            {
                                X = 8 * 1024 + 512,
                                Y = -768,
                                Z = 1 * 1024 + 512,
                                Intensity1 = 2048,
                                Fade1 = 4096,
                            },
                            new EMRoomLight
                            {
                                X = 1 * 1024 + 512,
                                Y = -768,
                                Z = 6 * 1024 + 512,
                                Intensity1 = 2048,
                                Fade1 = 4096,
                            },
                            new EMRoomLight
                            {
                                X = 1 * 1024 + 512,
                                Y = -768,
                                Z = 1 * 1024 + 512,
                                Intensity1 = 512,
                                Fade1 = 512,
                            },
                        },
                        LinkedLocation = new EMLocation
                        {
                            X = 51712,
                            Z = 23040,
                            Room = 19
                        },
                        Location = new EMLocation
                        {
                            X = 51200-2*4096,
                            Z = 22528+3072
                        },
                        FloorHeights= new Dictionary<sbyte, List<int>>
                        {
                            [-127] = new List<int> {  },
                        },
                    },
                    new EMCreateRoomFunction
                    {
                        EMType = EMType.CreateRoom,
                        Height = 4,
                        Width = 3,
                        Depth = 5,
                        Textures = new EMTextureGroup
                        {
                            Floor = 31,
                            Ceiling = 40,
                            Wall4 = 40,
                            Wall1 = 98,
                            WallAlignment = Direction.Down,
                        },
                        AmbientLighting = level.Rooms[19].AmbientIntensity,
                        DefaultVertex = new EMRoomVertex
                        {
                            Lighting = level.Rooms[46].RoomData.Vertices[level.Rooms[46].RoomData.Rectangles[0].Vertices[2]].Lighting
                        },
                        Lights = new EMRoomLight[]
                        {
                            new EMRoomLight
                            {
                                X = 1 * 1024 + 512,
                                Y = -512,
                                Z = 1 * 1024 + 512,
                                Intensity1 = 512,
                                Fade1 = 1024,
                            },
                        },
                        LinkedLocation = new EMLocation
                        {
                            X = 51712,
                            Z = 23040,
                            Room = 19
                        },
                        Location = new EMLocation
                        {
                            X = 51200-2*4096,
                            Y = -1024-256,
                            Z = 22528+1024
                        },
                    },
                    new EMVisibilityPortalFunction
                    {
                        Comments= "Make visibility portals.",
                        EMType = EMType.VisibilityPortal,
                        Portals = new List<EMVisibilityPortal>
                        {
                            new EMVisibilityPortal
                            {
                                BaseRoom = 19,
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
                                        Y = -1024-256,
                                        Z = 2 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Y = -1024-256,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Z = 2 * 1024
                                    }
                                }
                            },
                            new EMVisibilityPortal
                            {
                                BaseRoom = -3,
                                AdjoiningRoom = 19,
                                Normal = new TRVertex
                                {
                                    X = 1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = -1024-256,
                                        Z = 2 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = -1024-256,
                                        Z = 3 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Z = 3 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Z = 2 * 1024
                                    }
                                }
                            },

                            new EMVisibilityPortal
                            {
                                BaseRoom = -3,
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
                                        Y = -1024-256,
                                        Z = 6 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = -1024-256,
                                        Z = 7 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Z = 7 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Z = 6 * 1024
                                    }
                                }
                            },
                            new EMVisibilityPortal
                            {
                                BaseRoom = -2,
                                AdjoiningRoom = -3,
                                Normal = new TRVertex
                                {
                                    X = -1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = 9 * 1024,
                                        Y = -1024-256,
                                        Z = 2 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 9 * 1024,
                                        Y = -1024-256,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 9 * 1024,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 9 * 1024,
                                        Z = 2 * 1024
                                    }
                                }
                            },

                            new EMVisibilityPortal
                            {
                                BaseRoom = -2,
                                AdjoiningRoom = 24,
                                Normal = new TRVertex
                                {
                                    Z = -1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Y = -1024,
                                        Z = 8 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 3 * 1024,
                                        Y = -1024,
                                        Z = 8 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 3 * 1024,
                                        Z = 8 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Z = 8 * 1024
                                    }
                                }
                            },
                            new EMVisibilityPortal
                            {
                                BaseRoom = 24,
                                AdjoiningRoom = -2,
                                Normal = new TRVertex
                                {
                                    Z = 1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = 4 * 1024,
                                        Y = -1024,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 3 * 1024,
                                        Y = -1024,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 3 * 1024,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 4 * 1024,
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
                                        X = 1 * 1024,
                                        Y = -1024-256,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Y = -1024-256,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Y = -1024-256,
                                        Z = 2 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = -1024-256,
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
                                        Y = -1024-256,
                                        Z = 4 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Y = -1024-256,
                                        Z = 4 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Y = -1024-256,
                                        Z = 3 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = -1024-256,
                                        Z = 3 * 1024
                                    }
                                }
                            },
                        }
                    },
                    new EMHorizontalCollisionalPortalFunction
                    {
                        Comments = "Make collisional portals.",
                        EMType = EMType.HorizontalCollisionalPortal,
                        Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                        {
                            [19] = new Dictionary<short, EMLocation[]>
                            {
                                [-3] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 52736,
                                        Z = 23040,
                                        Room = 19
                                    }
                                }
                            },
                            [-3] = new Dictionary<short, EMLocation[]>
                            {
                                [19] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 52736-1024,
                                        Z = 23040,
                                        Room = -3
                                    }
                                },
                                [-2] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 52736-1024,
                                        Z = 27136,
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
                                        Z = 27136,
                                        Room = -2
                                    }
                                },
                                [24] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 45568,
                                        Z = 34304,
                                        Room = -2
                                    }
                                },
                                [-1] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 44544,
                                        Z = 27136-1024,
                                        Room = -2
                                    }
                                },
                            },
                            [24] = new Dictionary<short, EMLocation[]>
                            {
                                [-2] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 45568,
                                        Z = 34304-1024,
                                        Room = 24
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
                            X = 44544,
                            Y = -1280,
                            Z = 27136,
                            Room = -1
                        },
                        Floor = new EMLocation
                        {
                            X = 44544,
                            Y = -1280+1024,
                            Z = 27136,
                            Room = -2
                        },
                    },
                    new EMModifyFaceFunction
                    {
                        Comments = "Amend some faces.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                RoomNumber = -2,
                                FaceIndex = 57,
                                FaceType = EMTextureFaceType.Rectangles,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -768
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -768
                                    }
                                }
                            }
                        },
                        Rotations= new EMFaceRotation[]
                        {
                            new EMFaceRotation
                            {
                                RoomNumber = -2,
                                FaceIndices = new int[] { 74 },
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
                        Comments= "Change some textures.",
                        EMType = EMType.Reface,
                        TextureMap= new EMTextureMap
                        {
                            [98] = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 57 }
                                },
                            },
                            [567] = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 74 }
                                },
                            }
                        }
                    },
                    new EMRemoveFaceFunction
                    {
                        Comments = "Clear faces for portals.",
                        EMType = EMType.RemoveFace,
                        GeometryMap = new EMGeometryMap
                        {
                            [-3] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 10,11,34,35 }
                            },
                            [-2] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 178,179,56,1 }
                            },
                            [-1] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 9 }
                            },
                            [24] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 54 }
                            },
                        }
                    },
                    new EMAddStaticMeshFunction
                    {
                        Comments = "Add a barrier.",
                        EMType = EMType.AddStaticMesh,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 46592,
                                Z = 33280,
                                Room = -2,
                                Angle = -16384
                            }
                        },
                        Mesh = new TR2RoomStaticMesh
                        {
                            MeshID = level.Rooms[18].StaticMeshes[0].MeshID,
                            Intensity1 = level.Rooms[18].StaticMeshes[0].Intensity,
                        }
                    },
                    new EMMoveEntityFunction
                    {
                        Comments = "Rotate the exit door.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 25,
                        TargetLocation = new EMLocation
                        {
                            X = 45568,
                            Z = 34304-1024,
                            Room = 24,
                            Angle = -32768
                        }
                    },
                    new EMMoveEntityFunction
                    {
                        Comments = "Move Lara.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 24,
                        TargetLocation = new EMLocation
                        {
                            X = 42496,
                            Z = 23040,
                            Room = 18,
                            Angle = -16384
                        }
                    },
                    new EMMoveEntityFunction
                    {
                        Comments = "Move a pickup into the new area.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 14,
                        TargetLocation = new EMLocation
                        {
                            X = 44544,
                            Y = -1280,
                            Z = 25088+1024,
                            Room = -1
                        }
                    },
                    new EMMoveTriggerFunction
                    {
                        Comments = "Potential secret location will be moved into the new area.",
                        EMType = EMType.MoveTrigger,
                        BaseLocation = new EMLocation
                        {
                            X = 45568,
                            Z = 34304,
                            Room = 24
                        },
                        NewLocation = new EMLocation
                        {
                            X = 44544,
                            Y = -1280,
                            Z = 25088,
                            Room = -1
                        }
                    },
                    new EMMovePickupFunction
                    {
                        EMType = EMType.MovePickup,
                        SectorLocations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 45568,
                                Z = 34304,
                                Room = 24
                            }
                        },
                        TargetLocation = new EMLocation
                        {
                            X = 44544,
                            Y = -1280,
                            Z = 25088,
                            Room = -1
                        },
                        Types = new List<short>
                        {
                            (short)TREntities.Puzzle2_S_P,
                            (short)TREntities.Puzzle3_S_P,
                            (short)TREntities.Puzzle4_S_P,
                            (short)TREntities.Key1_S_P,
                            (short)TREntities.Key2_S_P,
                            (short)TREntities.Key3_S_P,
                            (short)TREntities.Key4_S_P,
                        }
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Pad for the exit door.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 46592,
                                Z = 33280,
                                Room = -2
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            TrigType = FDTrigType.Pad,
                            Timer = 22,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 25
                                }
                            }
                        },
                        HardVariant = new EMTriggerFunction
                        {
                            Comments = "Much tighter timer for the run.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 46592,
                                    Z = 33280,
                                    Room = -2
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 15,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 25
                                    }
                                }
                            },
                        }
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Keep the door open once we're through.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 45568,
                                Z = 35328,
                                Room = 24
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 25
                                }
                            }
                        }
                    },
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Import some trap models.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.RollingBall,
                                TexturedFace3 = 154,
                                TexturedFace4 = 90
                            },
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.SlammingDoor,
                                TexturedFace3 = 175,
                                TexturedFace4 = 84
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add a boulder and its trigger.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.RollingBall).Intensity,
                        Location = new EMLocation
                        {
                            X = 52736,
                            Z = 26112,
                            Room = -3,
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
                                X = 52736,
                                Z = 26112-3072,
                                Room = -3,
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some clang-clangs and their trigger.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = Array.Find(level7b.Entities, e => e.TypeID == (short)TREntities.SlammingDoor).Intensity,
                        Location = new EMLocation
                        {
                            X = 48640-512,
                            Z = 32256,
                            Room = -2,
                            Angle = 16384
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType= EMType.Trigger,
                        EntityLocation = -1,
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            TrigType = FDTrigType.Pad,
                            Timer = 1,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = Array.Find(level7b.Entities, e => e.TypeID == (short)TREntities.SlammingDoor).Intensity,
                        Location = new EMLocation
                        {
                            X = 44544,
                            Z = 32256-512-1024,
                            Room = -2,
                            Angle = 0
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType= EMType.Trigger,
                        EntityLocation = -1,
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            TrigType = FDTrigType.Pad,
                            Timer = 1,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            }
                        }
                    },
                    new EMGenerateLightFunction
                    {
                        Comments= "Generate light.",
                        EMType = EMType.GenerateLight,
                        RoomIndices = new List<short> { -1,-2,-3 }
                    }
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the boulder model is available and add one.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.RollingBall,
                                TexturedFace3 = 154,
                                TexturedFace4 = 90
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.RollingBall).Intensity,
                        Location = new EMLocation
                        {
                            X = 71168,
                            Y = -768-1024-256,
                            Z = 54784,
                            Room = 68,
                            Angle = -16384
                        }
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        Location = new EMLocation
                        {
                            X = 65024,
                            Z = 54784,
                            Room = 68
                        },
                        Actions = new List<EMTriggerAction>
                        {
                            new EMTriggerAction
                            {
                                Parameter = -1
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the boulder model is available and add one.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.RollingBall,
                                TexturedFace3 = 154,
                                TexturedFace4 = 90
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.RollingBall).Intensity,
                        Location = new EMLocation
                        {
                            X = 71168,
                            Y = -768-1024-256,
                            Z = 54784+3072,
                            Room = 68,
                            Angle = -16384
                        }
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        Location = new EMLocation
                        {
                            X = 65024+2048,
                            Z = 54784+3072,
                            Room = 68
                        },
                        Actions = new List<EMTriggerAction>
                        {
                            new EMTriggerAction
                            {
                                Parameter = -1
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the boulder model is available and add one.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.RollingBall,
                                TexturedFace3 = 154,
                                TexturedFace4 = 90
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.RollingBall).Intensity,
                        Location = new EMLocation
                        {
                            X = 49664,
                            Y = 7680-1024-256,
                            Z = 40448,
                            Room = 58,
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
                                Y = 7680,
                                Z = 44544,
                                Room = 63
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the clang-clang model is available and add one in hard mode.",
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange,
                            EMTag.Hard
                        },
                        EMType = EMType.ImportNonGraphicsModel,
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.SlammingDoor,
                                TexturedFace3 = 175,
                                TexturedFace4 = 84
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = Array.Find(level7b.Entities, e => e.TypeID == (short)TREntities.SlammingDoor).Intensity,
                        Location = new EMLocation
                        {
                            X = 44544,
                            Y = 7680-128,
                            Z = 40448,
                            Room = 58,
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
                                X = 44544,
                                Y = 7680,
                                Z = 40448,
                                Room = 58,
                            },
                            new EMLocation
                            {
                                X = 44544-1024,
                                Y = 7680,
                                Z = 40448,
                                Room = 58,
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            Timer = 1,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            }
                        }
                    }
                },
            };

            EMCreateRoomFunction func = mapping.Any[5][1] as EMCreateRoomFunction;
            foreach (EMLocation loc in JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("obeliskwalls.json"))[Level])
            {
                int x = (loc.X - func.Location.X) / 1024;
                int z = (loc.Z - func.Location.Z) / 1024;
                func.FloorHeights[-127].Add(x * func.Depth + z);
            }

            mapping.AllWithin = new List<List<EMEditorSet>>
            {
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712,
                                Room = 32,
                                Angle = 16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 2048,
                                Room = 32,
                                Angle = 16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 2048,
                                Room = 32,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 3072,
                                Room = 32,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 3072,
                                Room = 32,
                                Angle = 16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 4 * 1024,
                                Room = 32,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 4 * 1024,
                                Room = 32,
                                Angle = 16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 6 * 1024,
                                Room = 32,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 6 * 1024,
                                Room = 32,
                                Angle = 16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 7 * 1024,
                                Room = 32,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 7 * 1024,
                                Room = 32,
                                Angle = 16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 8 * 1024,
                                Room = 32,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 8 * 1024,
                                Room = 32,
                                Angle = 16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 - 8 * 1024,
                                Room = 32,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Z = 51712 + 1 * 1024,
                                Room = 32
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808 + 1 * 1024,
                                Z = 51712 + 1 * 1024,
                                Room = 39,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808 + 2 * 1024,
                                Z = 51712 + 1 * 1024,
                                Room = 39,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808 + 3 * 1024,
                                Z = 51712 + 1 * 1024,
                                Room = 39,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808 + 4 * 1024,
                                Z = 51712 + 1 * 1024,
                                Room = 39,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808 + 5 * 1024,
                                Z = 51712 + 1 * 1024,
                                Room = 39,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808 + 6 * 1024,
                                Z = 51712 + 1 * 1024,
                                Room = 39,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808 + 7 * 1024,
                                Z = 51712 + 1 * 1024,
                                Room = 39,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 33,
                            Location = new EMLocation
                            {
                                X = 55808 + 8 * 1024,
                                Z = 51712 + 1 * 1024,
                                Room = 39,
                                Angle = -32768
                            },
                        }
                    },
                }
            };

            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #15 is in its default position. If not, move the trigger to its new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 15,
                        X = level.Entities[15].X,
                        Y = level.Entities[15].Y,
                        Z = level.Entities[15].Z,
                        Room = level.Entities[15].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMRemoveTriggerActionFunction
                        {
                            Comments = "Remove the trapdoor entry from the pickup.",
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 50688,
                                    Y = 256,
                                    Z = 56832,
                                    Room = 36
                                }
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 22
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments = "Move the trigger.",
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 50688,
                                Y = 256,
                                Z = 56832,
                                Room = 36
                            },
                            EntityLocation = 15
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Replace the dummy trigger below the door.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 50688,
                                    Y = 256,
                                    Z = 56832,
                                    Room = 36
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
                                        Parameter = 22
                                    }
                                }
                            }
                        }
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #16 is in its default position. If not, move the trigger to its new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 16,
                        X = level.Entities[16].X,
                        Y = level.Entities[16].Y,
                        Z = level.Entities[16].Z,
                        Room = level.Entities[16].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMRemoveTriggerActionFunction
                        {
                            Comments = "Remove the trapdoor entry from the pickup.",
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 49664,
                                    Y = 256,
                                    Z = 56192,
                                    Room = 36
                                }
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 19
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments = "Move the trigger",
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 49664,
                                Y = 256,
                                Z = 56192,
                                Room = 36
                            },
                            EntityLocation = 16
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Replace the dummy trigger below the door.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 49664,
                                    Y = 256,
                                    Z = 56192,
                                    Room = 36
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
                                        Parameter = 19
                                    }
                                }
                            }
                        }
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #17 is in its default position. If not, move the trigger to its new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 17,
                        X = level.Entities[17].X,
                        Y = level.Entities[17].Y,
                        Z = level.Entities[17].Z,
                        Room = level.Entities[17].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMRemoveTriggerActionFunction
                        {
                            Comments = "Remove the trapdoor entry from the pickup.",
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 49024,
                                    Y = 256,
                                    Z = 56832,
                                    Room = 36
                                }
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 20
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments = "Move the trigger",
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 49024,
                                Y = 256,
                                Z = 56832,
                                Room = 36
                            },
                            EntityLocation = 17
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Replace the dummy trigger below the door.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 49024,
                                    Y = 256,
                                    Z = 56832,
                                    Room = 36
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
                                        Parameter = 20
                                    }
                                }
                            }
                        }
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #18 is in its default position. If not, move the trigger to its new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 18,
                        X = level.Entities[18].X,
                        Y = level.Entities[18].Y,
                        Z = level.Entities[18].Z,
                        Room = level.Entities[18].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMRemoveTriggerActionFunction
                        {
                            Comments = "Remove the trapdoor entry from the pickup.",
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 49664,
                                    Y = 256,
                                    Z = 57472,
                                    Room = 36
                                }
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 21
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments = "Move the trigger",
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 49664,
                                Y = 256,
                                Z = 57472,
                                Room = 36
                            },
                            EntityLocation = 18
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Replace the dummy trigger below the door.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 49664,
                                    Y = 256,
                                    Z = 57472,
                                    Room = 36
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
                                        Parameter = 21
                                    }
                                }
                            }
                        }
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "If Lara's not in the default starting position, move the flipmap trigger to her new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 24,
                        X = level.Entities[24].X,
                        Y = level.Entities[24].Y,
                        Z = level.Entities[24].Z,
                        Room = level.Entities[24].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = level.Entities[24].X,
                                Y = level.Entities[24].Y,
                                Z = level.Entities[24].Z,
                                Room = level.Entities[24].Room
                            },
                            EntityLocation = 24
                        },
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMSectorContainsSecretCondition
                    {
                        Comments = "If there is a secret in room 74...",
                        ConditionType = EMConditionType.SectorContainsSecret,
                        Location = new EMLocation
                        {
                            X = 68096,
                            Y = 4352,
                            Z = 62976,
                            Room = 74
                        },
                        And = new List<BaseEMCondition>
                        {
                            new EMRoomContainsWaterCondition
                            {
                                Comments = "and the room has been flooded...",
                                ConditionType = EMConditionType.RoomContainsWater,
                                RoomIndex = 74
                            }
                        }
                    },
                    OnTrue = new EMEditorSet
                    {
                        new EMMoveSecretFunction
                        {
                            Comments = "move the secret away from the wall.",
                            EMType = EMType.MoveSecret,
                            SectorLocations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 68096,
                                    Y = 4352,
                                    Z = 62976,
                                    Room = 74
                                }
                            },
                            TargetLocation = new EMLocation
                            {
                                X = 67714,
                                Y = 4352,
                                Z = 63358,
                                Room = 74
                            }
                        }
                    }
                }
            };

            mapping.ConditionalAllWithin = new List<EMConditionalEditorSet>
            {
                new EMConditionalEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "If the spare switch from City is now a key, relocate it.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 12,
                        EntityType = (short)TREntities.Key1_S_P
                    },
                    OnTrue = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMPlaceholderFunction
                            {
                                Comments = "Default location from Any.",
                                EMType = EMType.NOOP,
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveEntityFunction
                            {
                                Comments = "Potential key location.",
                                EMType = EMType.MoveEntity,
                                EntityIndex = 12,
                                TargetLocation = new EMLocation
                                {
                                    X = 37376,
                                    Y = -1280,
                                    Z = 31232,
                                    Room = 67
                                },
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveEntityFunction
                            {
                                Comments = "Potential key location.",
                                EMType = EMType.MoveEntity,
                                EntityIndex = 12,
                                TargetLocation = new EMLocation
                                {
                                    X = 36352,
                                    Y = -3072,
                                    Z = 39424,
                                    Room = 59
                                },
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveEntityFunction
                            {
                                Comments = "Potential key location.",
                                EMType = EMType.MoveEntity,
                                EntityIndex = 12,
                                TargetLocation = new EMLocation
                                {
                                    X = 48640,
                                    Y = 7680,
                                    Z = 50688,
                                    Room = 63
                                },
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveEntityFunction
                            {
                                Comments = "Potential key location.",
                                EMType = EMType.MoveEntity,
                                EntityIndex = 12,
                                TargetLocation = new EMLocation
                                {
                                    X = 34304,
                                    Y = 1024,
                                    Z = 40448,
                                    Room = 62
                                },
                            }
                        }
                    }
                },
                new EMConditionalEditorSet
                {
                    Condition = new EMRoomContainsWaterCondition
                    {
                        Comments = "Check if room 3 contains water and move the slots accordingly.",
                        ConditionType = EMConditionType.RoomContainsWater,
                        RoomIndex = 3
                    },
                    OnTrue = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMPlaceholderFunction
                            {
                                Comments = "Default positions.",
                                EMType = EMType.NOOP
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                Tags = new List<EMTag>
                                {
                                    EMTag.SlotChange
                                },
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = -1024,
                                    Z = 33280,
                                    Room = 67
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 4,
                                Location = new EMLocation
                                {
                                    X = 33280 + 1024,
                                    Y = -1024,
                                    Z = 33280,
                                    Room = 67
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 33280 + 2048,
                                    Y = -1024,
                                    Z = 33280,
                                    Room = 67
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 6,
                                Location = new EMLocation
                                {
                                    X = 33280 + 3072,
                                    Y = -1024,
                                    Z = 33280,
                                    Room = 67
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                Tags = new List<EMTag>
                                {
                                    EMTag.SlotChange
                                },
                                EntityIndex = 4,
                                Location = new EMLocation
                                {
                                    X = 42496,
                                    Y = -2304,
                                    Z = 14848,
                                    Room = 8,
                                    Angle = 16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 42496,
                                    Y = -2304,
                                    Z = 14848 + 1024,
                                    Room = 8,
                                    Angle = 16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 6,
                                Location = new EMLocation
                                {
                                    X = 42496,
                                    Y = -2304,
                                    Z = 14848 + 2048,
                                    Room = 8,
                                    Angle = 16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 42496,
                                    Y = -2304,
                                    Z = 14848 + 3072,
                                    Room = 8,
                                    Angle = 16384
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                Tags = new List<EMTag>
                                {
                                    EMTag.SlotChange
                                },
                                EntityIndex = 4,
                                Location = new EMLocation
                                {
                                    X = 35328,
                                    Y = -512,
                                    Z = 23040,
                                    Room = 11,
                                    Angle = 16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 35328,
                                    Y = -512,
                                    Z = 23040 + 1024,
                                    Room = 11,
                                    Angle = 16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 6,
                                Location = new EMLocation
                                {
                                    X = 35328,
                                    Y = -256,
                                    Z = 23040 + 2048,
                                    Room = 11,
                                    Angle = 16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 35328 - 1024,
                                    Z = 23040 + 2048,
                                    Room = 11,
                                    Angle = -32768
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                Tags = new List<EMTag>
                                {
                                    EMTag.SlotChange
                                },
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 34304,
                                    Y = -3072,
                                    Z = 34304,
                                    Room = 61,
                                    Angle = -16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 4,
                                Location = new EMLocation
                                {
                                    X = 34304,
                                    Y = -3072,
                                    Z = 34304 + 1024,
                                    Room = 61,
                                    Angle = -16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 6,
                                Location = new EMLocation
                                {
                                    X = 34304,
                                    Y = -3072,
                                    Z = 34304 + 2048,
                                    Room = 61,
                                    Angle = -16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 34304,
                                    Y = -3072,
                                    Z = 34304 + 3072,
                                    Room = 61,
                                    Angle = -16384
                                }
                            },
                        }
                    },
                    OnFalse = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMPlaceholderFunction
                            {
                                Comments = "Default positions.",
                                EMType = EMType.NOOP
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                Tags = new List<EMTag>
                                {
                                    EMTag.SlotChange
                                },
                                EntityIndex = 4,
                                Location = new EMLocation
                                {
                                    X = 39424 + 1024,
                                    Y = 1536,
                                    Z = 17920 + 1024,
                                    Room = 3,
                                    Angle = -16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 6,
                                Location = new EMLocation
                                {
                                    X = 39424 - 1024,
                                    Y = 1536,
                                    Z = 19968 - 1024,
                                    Room = 3,
                                    Angle = 16384
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                Tags = new List<EMTag>
                                {
                                    EMTag.SlotChange
                                },
                                EntityIndex = 4,
                                Location = new EMLocation
                                {
                                    X = 39424 + 1024,
                                    Y = 1536,
                                    Z = 17920 + 1024,
                                    Room = 3,
                                    Angle = -16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 6,
                                Location = new EMLocation
                                {
                                    X = 39424 - 1024,
                                    Y = 1536,
                                    Z = 19968 - 1024,
                                    Room = 3,
                                    Angle = 16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 38400 + 1024,
                                    Y = 1536,
                                    Z = 18944 - 1024,
                                    Room = 3
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 40448 - 1024,
                                    Y = 1536,
                                    Z = 18944 + 1024,
                                    Room = 3,
                                    Angle = -32768
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                Tags = new List<EMTag>
                                {
                                    EMTag.SlotChange
                                },
                                EntityIndex = 4,
                                Location = new EMLocation
                                {
                                    X = 36352,
                                    Y = 1792,
                                    Z = 20992,
                                    Room = 3,
                                    Angle = -16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 36352,
                                    Y = 1792,
                                    Z = 20992 - 1024,
                                    Room = 3,
                                    Angle = -16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 6,
                                Location = new EMLocation
                                {
                                    X = 36352,
                                    Y = 1792,
                                    Z = 20992 - 2048,
                                    Room = 3,
                                    Angle = -16384
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 36352,
                                    Y = 1792,
                                    Z = 20992 - 3072,
                                    Room = 3,
                                    Angle = -16384
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                Tags = new List<EMTag>
                                {
                                    EMTag.SlotChange
                                },
                                EntityIndex = 6,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = -1024,
                                    Z = 33280,
                                    Room = 67
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 33280 + 1024,
                                    Y = -1024,
                                    Z = 33280,
                                    Room = 67
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 4,
                                Location = new EMLocation
                                {
                                    X = 33280 + 2048,
                                    Y = -1024,
                                    Z = 33280,
                                    Room = 67
                                }
                            },
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential slot relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 33280 + 3072,
                                    Y = -1024,
                                    Z = 33280,
                                    Room = 67
                                }
                            },
                        },
                    }
                },
            };

            mapping.OneOf = new List<EMEditorGroupedSet>
            {
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 36.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[36].RoomData.Rectangles[66].Texture] = new EMGeometryMap
                                {
                                    [36] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 82 }
                                    }
                                },

                            }
                        },
                    },
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 48640 - 1024,
                                    Y = -768,
                                    Z = 52736,
                                    Room = 36,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[36].RoomData.Rectangles[82].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 66 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 48640 - 1024,
                                    Y = -768,
                                    Z = 52736,
                                    Room = 36,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[36].RoomData.Rectangles[82].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 65 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 48640 + 2 * 1024,
                                    Y = -768,
                                    Z = 52736,
                                    Room = 36,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[36].RoomData.Rectangles[82].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 126 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 48640 + 2 * 1024,
                                    Y = -768,
                                    Z = 52736,
                                    Room = 36,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[36].RoomData.Rectangles[82].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 145 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the lever texture.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        RoomNumber = 36,
                                        FaceIndices = new int[]{ 145 },
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
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 48640 + 1 * 1024,
                                    Y = -768,
                                    Z = 52736 - 1024,
                                    Room = 77,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[36].RoomData.Rectangles[82].Texture] = new EMGeometryMap
                                    {
                                        [77] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 48640 + 1 * 1024,
                                    Y = -768,
                                    Z = 52736 - 1024,
                                    Room = 77,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[36].RoomData.Rectangles[82].Texture] = new EMGeometryMap
                                    {
                                        [77] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        },
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
                            Comments = "Remove the default lever texture in room 38.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[38].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                {
                                    [38] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 17 }
                                    }
                                },

                            }
                        },
                    },
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 37,
                                Location = new EMLocation
                                {
                                    X = 34304,
                                    Y = -5376,
                                    Z = 60928,
                                    Room = 38
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[38].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [38] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 13 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 37,
                                Location = new EMLocation
                                {
                                    X = 34304 - 1024,
                                    Y = -5376,
                                    Z = 60928,
                                    Room = 38
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[38].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [38] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 7 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 37,
                                Location = new EMLocation
                                {
                                    X = 34304 - 1024,
                                    Y = -5376,
                                    Z = 60928,
                                    Room = 38,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[38].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [38] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 6 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 37,
                                Location = new EMLocation
                                {
                                    X = 34304 - 1024,
                                    Y = -5376,
                                    Z = 60928 - 1024,
                                    Room = 38,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[38].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [38] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 37,
                                Location = new EMLocation
                                {
                                    X = 34304 - 1024,
                                    Y = -5376,
                                    Z = 60928 - 1024,
                                    Room = 38,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[38].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [38] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 37,
                                Location = new EMLocation
                                {
                                    X = 34304 + 1024,
                                    Y = -5376,
                                    Z = 60928 - 1024,
                                    Room = 38,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[38].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [38] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 16 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 37,
                                Location = new EMLocation
                                {
                                    X = 34304 + 1024,
                                    Y = -5376,
                                    Z = 60928 - 1024,
                                    Room = 38
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[38].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [38] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 18 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 37,
                                Location = new EMLocation
                                {
                                    X = 34304 + 2048,
                                    Y = -5376,
                                    Z = 60928 - 1024,
                                    Room = 38,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[38].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [38] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 21 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 37,
                                Location = new EMLocation
                                {
                                    X = 34304 + 2048,
                                    Y = -5376,
                                    Z = 60928 - 1024,
                                    Room = 38
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[38].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [38] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 22 }
                                        },
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
                            Comments = "Remove the default lever texture in room 41.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[41].RoomData.Rectangles[141].Texture] = new EMGeometryMap
                                {
                                    [41] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 127 }
                                    }
                                },

                            }
                        },
                    },
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 43520,
                                    Y = -11008,
                                    Z = 52736,
                                    Room = 41,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[41].RoomData.Rectangles[127].Texture] = new EMGeometryMap
                                    {
                                        [41] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 111 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 43520 - 1024,
                                    Y = -11008 + 256,
                                    Z = 52736,
                                    Room = 41,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[41].RoomData.Rectangles[127].Texture] = new EMGeometryMap
                                    {
                                        [41] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 93 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 43520 + 1 * 1024,
                                    Y = -11008 - 256,
                                    Z = 52736 + 1 * 1024,
                                    Room = 41,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[41].RoomData.Rectangles[127].Texture] = new EMGeometryMap
                                    {
                                        [41] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 132 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 43520 - 3 * 1024,
                                    Y = -11008 + 512,
                                    Z = 52736,
                                    Room = 41,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[41].RoomData.Rectangles[127].Texture] = new EMGeometryMap
                                    {
                                        [41] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 60 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 43520 - 2048,
                                    Y = -11008,
                                    Z = 52736 + 4 * 1024,
                                    Room = 41
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[41].RoomData.Rectangles[127].Texture] = new EMGeometryMap
                                    {
                                        [41] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 88 }
                                        },
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
                            Comments = "Remove the default lever texture in room 41.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[41].RoomData.Rectangles[72].Texture] = new EMGeometryMap
                                {
                                    [41] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 56 }
                                    }
                                },

                            }
                        },
                    },
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 39424 + 1024,
                                    Y = -11008,
                                    Z = 56832,
                                    Room = 41
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[41].RoomData.Rectangles[56].Texture] = new EMGeometryMap
                                    {
                                        [41] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 72 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 39424 - 2 * 1024,
                                    Y = -11008 - 1024,
                                    Z = 56832,
                                    Room = 41
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[41].RoomData.Rectangles[56].Texture] = new EMGeometryMap
                                    {
                                        [41] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 23 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 39424 - 2 * 1024,
                                    Y = -11008 - 1024,
                                    Z = 56832,
                                    Room = 41,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[41].RoomData.Rectangles[56].Texture] = new EMGeometryMap
                                    {
                                        [41] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 21 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 39424 + 4 * 1024,
                                    Y = -11008,
                                    Z = 56832,
                                    Room = 41,
                                    Angle= 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[41].RoomData.Rectangles[56].Texture] = new EMGeometryMap
                                    {
                                        [41] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 141 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 44,
                                Location = new EMLocation
                                {
                                    X = 39424 - 1024,
                                    Y = -11008 + 512,
                                    Z = 56832 - 4096,
                                    Room = 41,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[41].RoomData.Rectangles[56].Texture] = new EMGeometryMap
                                    {
                                        [41] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 28 }
                                        },
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
                        new EMCopyRoomFunction
                        {
                            Comments = "Copy the end room.",
                            EMType = EMType.CopyRoom,
                            RoomIndex = 9,
                            LinkedLocation = new EMLocation
                            {
                                X = 19968,
                                Y = 1280,
                                Z = 20992,
                                Room = 9
                            },
                            NewLocation = new EMLocation
                            {
                                X = 19456 - 9 * 1024,
                                Y = 1280 + 1280 + 256,
                                Z = 20480 - 2048
                            },
                        },
                        new EMVisibilityPortalFunction
                        {
                            Comments = "Make visibility portals.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 9,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[1].Vertices[2]].Vertex,
                                        level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[5].Vertices[1]].Vertex,
                                        level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[4].Vertices[2]].Vertex,
                                        level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[0].Vertices[1]].Vertex,
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 9,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[109].Vertices[0]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[109].Vertices[0]].Vertex.Y + 1536),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[109].Vertices[0]].Vertex.Z,
                                        },
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[105].Vertices[3]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[105].Vertices[3]].Vertex.Y + 1536),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[105].Vertices[3]].Vertex.Z,
                                        },
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[104].Vertices[0]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[104].Vertices[0]].Vertex.Y + 1536),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[104].Vertices[0]].Vertex.Z,
                                        },
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[108].Vertices[3]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[108].Vertices[3]].Vertex.Y + 1536),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[108].Vertices[3]].Vertex.Z,
                                        },
                                    }
                                }
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Make collisional portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [9] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 19968 - 1024,
                                            Y = 1280,
                                            Z = 20992,
                                            Room = 9
                                        },
                                        new EMLocation
                                        {
                                            X = 19968 - 1024,
                                            Y = 1280,
                                            Z = 20992 + 1024,
                                            Room = 9
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [9] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 19968,
                                            Y = 1280,
                                            Z = 20992,
                                            Room = -1
                                        },
                                        new EMLocation
                                        {
                                            X = 19968,
                                            Y = 1280,
                                            Z = 20992 + 1024,
                                            Room = -1
                                        }
                                    }
                                },
                            }
                        },
                        new EMCopyRoomFunction
                        {
                            Comments = "Rinse and repeat.",
                            EMType = EMType.CopyRoom,
                            RoomIndex = -1,
                            LinkedLocation = new EMLocation
                            {
                                X = 11776,
                                Y = 2816,
                                Z = 20992,
                                Room = -1
                            },
                            NewLocation = new EMLocation
                            {
                                X = 11264 - 9 * 1024,
                                Y = 2816 + 1280 + 256,
                                Z = 20480 - 2048
                            },
                        },
                        new EMVisibilityPortalFunction
                        {
                            Comments = "Make visibility portals.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[1].Vertices[2]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[1].Vertices[2]].Vertex.Y + 1536),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[1].Vertices[2]].Vertex.Z,
                                        },
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[5].Vertices[1]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[5].Vertices[1]].Vertex.Y + 1536),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[5].Vertices[1]].Vertex.Z,
                                        },
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[4].Vertices[2]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[4].Vertices[2]].Vertex.Y + 1536),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[4].Vertices[2]].Vertex.Z,
                                        },
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[0].Vertices[1]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[0].Vertices[1]].Vertex.Y + 1536),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[0].Vertices[1]].Vertex.Z,
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = -2,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[109].Vertices[0]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[109].Vertices[0]].Vertex.Y + 1536*2),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[109].Vertices[0]].Vertex.Z,
                                        },
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[105].Vertices[3]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[105].Vertices[3]].Vertex.Y + 1536*2),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[105].Vertices[3]].Vertex.Z,
                                        },
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[104].Vertices[0]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[104].Vertices[0]].Vertex.Y + 1536*2),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[104].Vertices[0]].Vertex.Z,
                                        },
                                        new TRVertex
                                        {
                                            X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[108].Vertices[3]].Vertex.X,
                                            Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[108].Vertices[3]].Vertex.Y + 1536*2),
                                            Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[108].Vertices[3]].Vertex.Z,
                                        },
                                    }
                                }
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Make collisional portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 11776 - 1024,
                                            Y = 2816,
                                            Z = 20992,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 11776 - 1024,
                                            Y = 2816,
                                            Z = 20992 + 1024,
                                            Room = -2
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 11776,
                                            Y = 2816,
                                            Z = 20992,
                                            Room = -1
                                        },
                                        new EMLocation
                                        {
                                            X = 11776,
                                            Y = 2816,
                                            Z = 20992 + 1024,
                                            Room = -1
                                        }
                                    }
                                },
                            }
                        },
                        new EMConvertEntityFunction
                        {
                            Comments = "Take another unused switch from City, and turn it into a door.",
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 28,
                            NewEntityType = (short)TREntities.Door5
                        },
                        new EMModifyEntityFunction
                        {
                            Comments = "Fix its lighting.",
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 28,
                            Intensity1 = level.Entities[0].Intensity
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the converted switch to the new room.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 28,
                            TargetLocation = new EMLocation
                            {
                                X = 19968,
                                Y = 1280,
                                Z = 20992,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add another door.",
                            EMType = EMType.AddEntity,
                            Intensity = level.Entities[1].Intensity,
                            TypeID = level.Entities[1].TypeID,
                            Location = new EMLocation
                            {
                                X = 19968,
                                Y = 1280,
                                Z = 20992 + 1024,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the original doors into the new room for easier trigger management.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 11776,
                                Y = 2816,
                                Z = 20992,
                                Room = -1,
                                Angle = 16384
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 11776,
                                Y = 2816,
                                Z = 20992 + 1024,
                                Room = -1,
                                Angle = 16384
                            }
                        },
                        new EMAddFaceFunction
                        {
                            Comments = "Make fake final doors.",
                            EMType = EMType.AddFace,
                            Quads = new Dictionary<short, List<TRFace4>>
                            {
                                [-1] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 577,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[9].RoomData.Rectangles[1].Vertices[2],
                                            level.Rooms[9].RoomData.Rectangles[1].Vertices[1],
                                            level.Rooms[9].RoomData.Rectangles[0].Vertices[2],
                                            level.Rooms[9].RoomData.Rectangles[0].Vertices[1],
                                        }
                                    },
                                    new TRFace4
                                    {
                                        Texture = 581,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[9].RoomData.Rectangles[5].Vertices[2],
                                            level.Rooms[9].RoomData.Rectangles[5].Vertices[1],
                                            level.Rooms[9].RoomData.Rectangles[4].Vertices[2],
                                            level.Rooms[9].RoomData.Rectangles[4].Vertices[1],
                                        }
                                    }
                                }
                            }
                        },
                        new EMRemoveTriggerFunction
                        {
                            Comments = "Remove the end level triggers.",
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 384,
                                    Z = 23040,
                                    Room = 9
                                },
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 256,
                                    Z = 22016,
                                    Room = 9
                                },
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 256,
                                    Z = 22016 - 1024,
                                    Room = 9
                                },
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 384,
                                    Z = 22016 - 2048,
                                    Room = 9
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Door triggers.",
                            EMType = EMType.Trigger,
                            ExpandedLocations = new EMLocationExpander
                            {
                                Location = new EMLocation
                                {
                                    X = 15872,
                                    Y = 1920,
                                    Z = 19968,
                                    Room = -2,
                                },
                                ExpandX = 1,
                                ExpandZ = 4
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 0,
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = 1,
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "More door triggers.",
                            EMType = EMType.Trigger,
                            ExpandedLocations = new EMLocationExpander
                            {
                                Location = new EMLocation
                                {
                                    X = 24064,
                                    Y = 384,
                                    Z = 19968,
                                    Room = 9,
                                },
                                ExpandX = 1,
                                ExpandZ = 4
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = 28,
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "New end level triggers.",
                            EMType = EMType.Trigger,
                            ExpandedLocations = new EMLocationExpander
                            {
                                Location = new EMLocation
                                {
                                    X = 7680,
                                    Y = 3456 - 256,
                                    Z = 19968,
                                    Room = -1
                                },
                                ExpandX = 1,
                                ExpandZ = 4
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Action = FDTrigAction.EndLevel
                                    }
                                }
                            }
                        }
                    },
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMPlaceholderFunction
                            {
                                Comments = "No puzzle.",
                                EMType = EMType.NOOP
                            }
                        },
                        new EMEditorSet
                        {
                            new EMRemoveTriggerFunction
                            {
                                Comments = "Remove the triggers in the second room.",
                                EMType = EMType.RemoveTrigger,
                                Tags = new List<EMTag>
                                {
                                    EMTag.PuzzleRoom
                                },
                                Rooms = new List<int> { -2 }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the doors.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 16896,
                                        Y = 1536,
                                        Z = 20992,
                                        Room = -2
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
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
                                        X = 15872,
                                        Y = 1920,
                                        Z = 19968,
                                        Room = -2
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 1,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
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
                                        X = 13824,
                                        Y = 2432,
                                        Z = 23040,
                                        Room = -2
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 2,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
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
                                        X = 14848,
                                        Y = 2048,
                                        Z = 22016,
                                        Room = -2
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 3,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
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
                                        X = 11776,
                                        Y = 2816,
                                        Z = 20992,
                                        Room = -2
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 4,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Puzzle antipads",
                                EMType = EMType.Trigger,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    TrigType = FDTrigType.Antipad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
                                        }
                                    }
                                },
                                Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("obeliskpuzzleantipads1.json"))[TRLevelNames.OBELISK]
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Reface the pad tiles.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [567] = new EMGeometryMap
                                    {
                                        [-2] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 0,41,53,60,78 }
                                        }
                                    }
                                }
                            },
                            new EMRemoveStaticMeshFunction
                            {
                                Comments = "Remove the palm trees for easier navigation.",
                                EMType = EMType.RemoveStaticMesh,
                                ClearFromRooms = new Dictionary<ushort, List<int>>
                                {
                                    [0] = new List<int> {-2},
                                    [1] = new List<int> {-2},
                                    [2] = new List<int> {-2},
                                },
                                HardVariant = new EMPlaceholderFunction
                                {
                                    Comments = "Palm trees remain in hard mode.",
                                    EMType = EMType.NOOP,
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMRemoveTriggerFunction
                            {
                                Comments = "Remove the triggers in the second room.",
                                EMType = EMType.RemoveTrigger,
                                Tags = new List<EMTag>
                                {
                                    EMTag.PuzzleRoom
                                },
                                Rooms = new List<int> { -2 }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the doors.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 16896,
                                        Y = 1536,
                                        Z = 22016,
                                        Room = -2
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
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
                                        X = 15872,
                                        Y = 1792,
                                        Z = 20992,
                                        Room = -2
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 1,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
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
                                        X = 17920,
                                        Y = 1408,
                                        Z = 23040,
                                        Room = -2
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 2,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
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
                                        X = 12800,
                                        Y = 2560,
                                        Z = 20992,
                                        Room = -2
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 3,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
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
                                        X = 12800,
                                        Y = 2560,
                                        Z = 22016,
                                        Room = -2
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 4,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter =0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Puzzle antipads",
                                EMType = EMType.Trigger,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    TrigType = FDTrigType.Antipad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
                                        }
                                    }
                                },
                                Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("obeliskpuzzleantipads2.json"))[TRLevelNames.OBELISK]
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Reface the pad tiles.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [567] = new EMGeometryMap
                                    {
                                        [-2] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 14,18,64,81,98 }
                                        }
                                    }
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Bait.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.LargeMed_S_P,
                                Intensity = level.Entities[14].Intensity,
                                Location = new EMLocation
                                {
                                    X = 11776,
                                    Y = 2816,
                                    Z = 22016,
                                    Room = -2
                                }
                            },
                            new EMRemoveStaticMeshFunction
                            {
                                Comments = "Remove the palm trees for easier navigation.",
                                EMType = EMType.RemoveStaticMesh,
                                ClearFromRooms = new Dictionary<ushort, List<int>>
                                {
                                    [0] = new List<int> {-2},
                                    [1] = new List<int> {-2},
                                    [2] = new List<int> {-2},
                                },
                                HardVariant = new EMPlaceholderFunction
                                {
                                    Comments = "Palm trees remain in hard mode.",
                                    EMType = EMType.NOOP,
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMKillLaraFunction
                            {
                                Comments = "Create death stairs.",
                                EMType = EMType.KillLara,
                                Tags = new List<EMTag>
                                {
                                    EMTag.PuzzleRoom
                                },
                                Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("obeliskdeathstairs.json"))[TRLevelNames.OBELISK]
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Death tile hints.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [5] = new EMGeometryMap
                                    {
                                        [-2] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 68,65,79,82,54,51,38,34,36,40,19,15 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate one of the tiles.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        RoomNumber = -2,
                                        FaceIndices = new int[] { 68 },
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
                            new EMAddEntityFunction
                            {
                                Comments = "Add a camera target as a warning.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.CameraTarget_N,
                                Location = new EMLocation
                                {
                                    X = 15360,
                                    Y = -256,
                                    Z = 21504,
                                    Room = -2
                                },
                                HardVariant = new EMPlaceholderFunction
                                {
                                    Comments = "No hint in hard mode.",
                                    EMType = EMType.NOOP
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Look at the roof, Lara.",
                                EMType = EMType.Trigger,
                                ExpandedLocations = new EMLocationExpander
                                {
                                    Location  =new EMLocation
                                    {
                                        X = 17920,
                                        Y = 1280,
                                        Z = 20992,
                                        Room = -2
                                    },
                                    ExpandX = 2,
                                    ExpandZ= 2,
                                },
                                Trigger= new EMTrigger
                                {
                                    Mask = 31,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Action = FDTrigAction.LookAtItem,
                                            Parameter = -1
                                        }
                                    }
                                },
                                HardVariant = new EMPlaceholderFunction
                                {
                                    Comments = "No hint in hard mode.",
                                    EMType = EMType.NOOP
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMRemoveTriggerFunction
                            {
                                Comments = "Remove the triggers in the second room.",
                                EMType = EMType.RemoveTrigger,
                                Tags = new List<EMTag>
                                {
                                    EMTag.PuzzleRoom
                                },
                                Rooms = new List<int> { -2 }
                            },
                            new EMCopyRoomFunction
                            {
                                Comments = "Copy the room again to become a tile hint.",
                                EMType = EMType.CopyRoom,
                                RoomIndex = -2,
                                NewLocation = new EMLocation
                                {
                                    X = 10240,
                                    Y = 2816,
                                    Z = 18432 + 4 * 1024
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Change faces to be able to see in.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [820] = new EMGeometryMap
                                    {
                                        [-3] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 27,26,44,58,45,59,73,72,87,86,101,100 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate some to look a bit better.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        RoomNumber = -3,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 58,73 },
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 1,
                                            [1] = 2,
                                            [2] = 3,
                                            [3] = 0
                                        }
                                    },
                                    new EMFaceRotation
                                    {
                                        RoomNumber = -3,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 45 },
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
                            new EMVisibilityPortalFunction
                            {
                                Comments = "Make a one-way visibility portal.",
                                EMType = EMType.VisibilityPortal,
                                Portals = new List<EMVisibilityPortal>
                                {
                                    new EMVisibilityPortal
                                    {
                                        BaseRoom = -3,
                                        AdjoiningRoom = -1,
                                        Normal = new TRVertex
                                        {
                                            Z = -1
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[27].Vertices[0]].Vertex.X,
                                                Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[27].Vertices[0]].Vertex.Y + 1536),
                                                Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[27].Vertices[0]].Vertex.Z,
                                            },
                                            new TRVertex
                                            {
                                                X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[27].Vertices[1]].Vertex.X,
                                                Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[27].Vertices[1]].Vertex.Y + 1536),
                                                Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[27].Vertices[1]].Vertex.Z,
                                            },
                                            new TRVertex
                                            {
                                                X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[26].Vertices[2]].Vertex.X,
                                                Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[26].Vertices[2]].Vertex.Y + 1536),
                                                Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[26].Vertices[2]].Vertex.Z,
                                            },
                                            new TRVertex
                                            {
                                                X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[26].Vertices[3]].Vertex.X,
                                                Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[26].Vertices[3]].Vertex.Y + 1536),
                                                Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[26].Vertices[3]].Vertex.Z,
                                            }
                                        }
                                    },
                                    new EMVisibilityPortal
                                    {
                                        BaseRoom = -3,
                                        AdjoiningRoom = -1,
                                        Normal = new TRVertex
                                        {
                                            Z = -1
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[45].Vertices[3]].Vertex.X,
                                                Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[45].Vertices[3]].Vertex.Y + 1536),
                                                Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[45].Vertices[3]].Vertex.Z,
                                            },
                                            new TRVertex
                                            {
                                                X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[101].Vertices[1]].Vertex.X,
                                                Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[101].Vertices[1]].Vertex.Y + 1536),
                                                Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[101].Vertices[1]].Vertex.Z,
                                            },
                                            new TRVertex
                                            {
                                                X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[100].Vertices[2]].Vertex.X,
                                                Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[100].Vertices[2]].Vertex.Y + 1536),
                                                Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[100].Vertices[2]].Vertex.Z,
                                            },
                                            new TRVertex
                                            {
                                                X = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[44].Vertices[3]].Vertex.X,
                                                Y = (short)(level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[44].Vertices[3]].Vertex.Y + 1536),
                                                Z = level.Rooms[9].RoomData.Vertices[level.Rooms[9].RoomData.Rectangles[44].Vertices[3]].Vertex.Z,
                                            },
                                        }
                                    }
                                }
                            },
                            new EMAddFaceFunction
                            {
                                Comments = "Make fake doors in the hint room.",
                                EMType = EMType.AddFace,
                                Quads = new Dictionary<short, List<TRFace4>>
                                {
                                    [-1] = new List<TRFace4>
                                    {
                                        new TRFace4
                                        {
                                            Texture = 577,
                                            Vertices = new ushort[]
                                            {
                                                level.Rooms[9].RoomData.Rectangles[1].Vertices[2],
                                                level.Rooms[9].RoomData.Rectangles[1].Vertices[1],
                                                level.Rooms[9].RoomData.Rectangles[0].Vertices[2],
                                                level.Rooms[9].RoomData.Rectangles[0].Vertices[1],
                                            }
                                        },
                                        new TRFace4
                                        {
                                            Texture = 581,
                                            Vertices = new ushort[]
                                            {
                                                level.Rooms[9].RoomData.Rectangles[5].Vertices[2],
                                                level.Rooms[9].RoomData.Rectangles[5].Vertices[1],
                                                level.Rooms[9].RoomData.Rectangles[4].Vertices[2],
                                                level.Rooms[9].RoomData.Rectangles[4].Vertices[1],
                                            }
                                        },
                                        new TRFace4
                                        {
                                            Texture = 577,
                                            Vertices = new ushort[]
                                            {
                                                level.Rooms[9].RoomData.Rectangles[109].Vertices[0],
                                                level.Rooms[9].RoomData.Rectangles[109].Vertices[3],
                                                level.Rooms[9].RoomData.Rectangles[108].Vertices[0],
                                                level.Rooms[9].RoomData.Rectangles[108].Vertices[3],
                                            }
                                        },
                                        new TRFace4
                                        {
                                            Texture = 581,
                                            Vertices = new ushort[]
                                            {
                                                level.Rooms[9].RoomData.Rectangles[105].Vertices[0],
                                                level.Rooms[9].RoomData.Rectangles[105].Vertices[3],
                                                level.Rooms[9].RoomData.Rectangles[104].Vertices[0],
                                                level.Rooms[9].RoomData.Rectangles[104].Vertices[3],
                                            }
                                        },
                                    }
                                }
                            },
                            new EMRemoveStaticMeshFunction
                            {
                                Comments = "Remove the palm trees for easier navigation.",
                                EMType = EMType.RemoveStaticMesh,
                                ClearFromRooms = new Dictionary<ushort, List<int>>
                                {
                                    [0] = new List<int> {-3,-1},
                                    [1] = new List<int> {-3,-1},
                                    [2] = new List<int> {-3,-1},
                                },
                                HardVariant = new EMMoveStaticMeshFunction
                                {
                                    Comments = "Correct the palm tree positions.",
                                    EMType = EMType.MoveStaticMesh,
                                    Relocations = new Dictionary<short, Dictionary<int, EMLocation>>
                                    {
                                        [-1] = new Dictionary<int, EMLocation>
                                        {

                                        }
                                    }
                                },
                            },
                            new EMFloodFunction
                            {
                                Comments = "Flood the hint room.",
                                EMType = EMType.Flood,
                                RoomNumbers = new int[]{ -1 }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the doors.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 16896,
                                        Y = 1664,
                                        Z = 19968,
                                        Room = -3
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the doors.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 15872,
                                        Y = 1920,
                                        Z = 23040,
                                        Room = -3
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 1,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the doors.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 14848,
                                        Y = 2048,
                                        Z = 22016,
                                        Room = -3
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 2,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the doors.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 12800,
                                        Y = 2688,
                                        Z = 19968,
                                        Room = -3
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 3,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the doors.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 12800,
                                        Y = 2560,
                                        Z = 22016,
                                        Room = -3
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 4,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Puzzle antipads",
                                EMType = EMType.Trigger,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    TrigType = FDTrigType.Antipad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 0
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 1
                                        }
                                    }
                                },
                                Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("obeliskpuzzleantipads3.json"))[TRLevelNames.OBELISK]
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Reface the pad tiles.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [574] = new EMGeometryMap
                                    {
                                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 84,60,50,22,14 }
                                        }
                                    }
                                }
                            },
                        },
                    }
                }
            };

            mapping.ConditionalOneOf = new List<EMConditionalGroupedSet>
            {
                new EMConditionalGroupedSet
                {
                    Condition = new EMRoomContainsWaterCondition
                    {
                        Comments = "Check if room 74 has been flooded and move the lever accordingly.",
                        ConditionType = EMConditionType.RoomContainsWater,
                        RoomIndex = 74
                    },
                    OnTrue = new EMEditorGroupedSet
                    {
                        Leader = new EMEditorSet
                        {
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 75.",
                                EMType = EMType.Reface,
                                Tags = new List<EMTag>
                                {
                                    EMTag.SlotChange
                                },
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[75].RoomData.Rectangles[84].Texture] = new EMGeometryMap
                                    {
                                        [75] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 98 }
                                        }
                                    },

                                }
                            },
                        },
                        Followers = new List<EMEditorSet>
                        {
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 69120 - 1024,
                                        Z = 62976 + 1024,
                                        Room = 75,
                                        Angle = -32768
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [75] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 84 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 69120 - 2048,
                                        Z = 62976 + 1024,
                                        Room = 75,
                                        Angle = -32768
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [75] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 68 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 69120 - 2048,
                                        Y = -1024,
                                        Z = 62976,
                                        Room = 75,
                                        Angle = -16384
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [75] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 64 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 69120 + 1024,
                                        Z = 62976,
                                        Room = 75,
                                        Angle = 16384
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [75] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 131 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 69120 + 1024,
                                        Z = 62976 - 1024,
                                        Room = 75,
                                        Angle = 16384
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [75] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 128 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 69120 + 1024,
                                        Z = 62976 - 2048,
                                        Room = 75,
                                        Angle = 16384
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [75] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 125 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 69120 + 1024,
                                        Z = 62976 - 2048,
                                        Room = 75,
                                        Angle = -32768,
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [75] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 109 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 69120 + 1024,
                                        Z = 62976 + 1024,
                                        Room = 75,
                                        Angle = 16384,
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [75] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 134 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 69120 + 1024,
                                        Z = 62976 + 2048,
                                        Room = 75,
                                        Angle = 16384,
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [75] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 137 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 69120 + 1024,
                                        Z = 62976 + 3072,
                                        Room = 75,
                                        Angle = 16384,
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [75] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 140 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 69120 + 1024,
                                        Z = 62976 + 3072,
                                        Room = 75
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [75] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 122 }
                                            },
                                        }
                                    }
                                },
                            },
                        }
                    },
                    OnFalse = new EMEditorGroupedSet
                    {
                        Leader = new EMEditorSet
                        {
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 74.",
                                EMType = EMType.Reface,
                                Tags = new List<EMTag>
                                {
                                    EMTag.SlotChange
                                },
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[74].RoomData.Rectangles[145].Texture] = new EMGeometryMap
                                    {
                                        [74] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 151 }
                                        }
                                    }
                                }
                            },
                        },
                        Followers = new List<EMEditorSet>
                        {
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 66048,
                                        Y = 4352,
                                        Z = 64000 - 1024,
                                        Room = 74,
                                        Angle = 16384
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [74] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 145 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 66048 + 1024,
                                        Y = 4352,
                                        Z = 64000 - 2048,
                                        Room = 74
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [74] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 148 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 66048 + 1024,
                                        Y = 4352,
                                        Z = 64000 + 1024,
                                        Room = 74,
                                        Angle = -32768
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [74] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 155 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 66048 + 1024,
                                        Y = 4352,
                                        Z = 64000 - 3072,
                                        Room = 74,
                                        Angle = 16384
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [74] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 165 }
                                            },
                                        }
                                    }
                                },
                                new EMModifyFaceFunction
                                {
                                    Comments = "Rotate the face to match the lever texture.",
                                    EMType = EMType.ModifyFace,
                                    Rotations = new EMFaceRotation[]
                                    {
                                        new EMFaceRotation
                                        {
                                            RoomNumber = 74,
                                            FaceIndices = new int[]{ 165 },
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
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 66048 + 2048,
                                        Y = 4352 - 1024,
                                        Z = 64000 - 3072,
                                        Room = 74,
                                        Angle = 16384
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [74] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 189 }
                                            },
                                        }
                                    }
                                },
                                new EMModifyFaceFunction
                                {
                                    Comments = "Rotate the face to match the lever texture.",
                                    EMType = EMType.ModifyFace,
                                    Rotations = new EMFaceRotation[]
                                    {
                                        new EMFaceRotation
                                        {
                                            RoomNumber = 74,
                                            FaceIndices = new int[]{ 189 },
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
                                }
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 66048 + 4096,
                                        Y = 4352 - 2048,
                                        Z = 64000 - 3072,
                                        Room = 74,
                                        Angle = 16384
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [74] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 227 }
                                            },
                                        }
                                    }
                                },
                            },
                            new EMEditorSet
                            {
                                new EMMoveSlotFunction
                                {
                                    Comments = "Potential lever relocation.",
                                    EMType = EMType.MoveSlot,
                                    EntityIndex = 93,
                                    Location = new EMLocation
                                    {
                                        X = 66048 + 4096,
                                        Y = 4352 - 2048,
                                        Z = 64000 - 3072,
                                        Room = 74,
                                        Angle = -32768
                                    }
                                },
                                new EMRefaceFunction
                                {
                                    Comments = "Refacing for above.",
                                    EMType = EMType.Reface,
                                    TextureMap = new EMTextureMap
                                    {
                                        [level.Rooms[74].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                        {
                                            [74] = new Dictionary<EMTextureFaceType, int[]>
                                            {
                                                [EMTextureFaceType.Rectangles] = new int[] { 213 }
                                            },
                                        }
                                    }
                                },
                            },
                        }
                    }
                },

            };

            int midZ = level.Rooms[9].Info.Z + 3072;
            EMMoveStaticMeshFunction meshFunc = mapping.OneOf[4].Followers[4][6].HardVariant as EMMoveStaticMeshFunction;//mapping.ConditionalOneOf[1].OnTrue.Followers[4][6].HardVariant as EMMoveStaticMeshFunction;
            for (int i = 0; i < level.Rooms[9].NumStaticMeshes; i++)
            {
                TRRoomStaticMesh mesh = level.Rooms[9].StaticMeshes[i];
                int zdiff = midZ - (int)mesh.Z;
                ushort angle = mesh.Rotation;
                if (angle == 0)
                {
                    angle = 32768;
                }
                else if (angle == 32768)
                {
                    angle = 0;
                }

                meshFunc.Relocations[-1][i] = new EMLocation
                {
                    Z = 2 * zdiff,
                    Angle = (short)angle
                };
            }

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();
            TRLevel level = GetTR1Level(Level);

            mapping.RewardEntities = new List<int> { 52, 53, 54, 55, 56, 99, 100 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 50688,
                            Y = -1024,
                            Z = 17920
                        },
                        new Location
                        {
                            X = 50688 - 1024,
                            Y = -1024,
                            Z = 17920
                        },
                        new Location
                        {
                            X = 50688 - 2048,
                            Y = -1024,
                            Z = 17920
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door2,
                            X = 41472,
                            Y = -1024,
                            Z = 17920,
                            Angle = -16384,
                            Intensity = 6400,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 31401,
                            Y = -1648,
                            Z = 16922,
                            Room = 11
                        }
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 18,
                            LinkedLocation = new EMLocation
                            {
                                X = 41472,
                                Z = 16896,
                                Room = 11
                            },
                            NewLocation = new EMLocation
                            {
                                X = 40960,
                                Y = -1024,
                                Z = 16384,
                            }
                        },
                        new EMCeilingFunction
                        {
                            EMType = EMType.Ceiling,
                            CeilingHeights = new Dictionary<int, sbyte>
                            {
                                [-1] = -8
                            },
                            AmendVertices = true
                        },
                        new EMVisibilityPortalFunction
                        {
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 11,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[356].Vertices[0]].Vertex,
                                        level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[356].Vertices[1]].Vertex,
                                        level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[356].Vertices[2]].Vertex,
                                        level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[356].Vertices[3]].Vertex,
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 11,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -2048,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -2048,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1024,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1024,
                                            Z = 1024
                                        },
                                    }
                                }
                            }
                        },
                        new EMReplaceCollisionalPortalFunction
                        {
                            EMType = EMType.ReplaceCollisionalPortal,
                            Room = 11,
                            X = 15,
                            Z = 4,
                            AdjoiningRoom = -1
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [11] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 42496 - 1024,
                                            Y = -1024,
                                            Z = 17920,
                                            Room = -1
                                        }
                                    }
                                }
                            }
                        },
                        new EMRemoveStaticMeshFunction
                        {
                            EMType = EMType.RemoveStaticMesh,
                            ClearFromRooms = new Dictionary<ushort, List<int>>
                            {
                                [34] = new List<int>{-1}
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
                                        Texture = level.Rooms[18].RoomData.Rectangles[35].Texture,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[18].RoomData.Rectangles[35].Vertices[1],
                                            level.Rooms[18].RoomData.Rectangles[34].Vertices[0],
                                            level.Rooms[18].RoomData.Rectangles[34].Vertices[3],
                                            level.Rooms[18].RoomData.Rectangles[35].Vertices[2],
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
                                [11] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 356 }
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

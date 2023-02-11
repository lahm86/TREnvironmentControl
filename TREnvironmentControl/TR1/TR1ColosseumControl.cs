using Newtonsoft.Json;
using System;
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
    public class TR1ColosseumControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.COLOSSEUM;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);
            TRLevel level2 = GetTR1Level(TRLevelNames.VILCABAMBA);
            TRLevel level3b = GetTR1Level(TRLevelNames.QUALOPEC);
            TRLevel level7b = GetTR1Level(TRLevelNames.TIHOCAN);

            mapping.NonPurist = new EMEditorSet
            {
                new EMTriggerFunction
                {
                    Comments = "Fix the bat triggers for room 71 - param 74 is duplicated so the third bat doesn't spawn.",
                    EMType = EMType.Trigger,
                    Replace = true,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 55808,
                            Y = -4608,
                            Z = 61952,
                            Room = 70
                        },
                        new EMLocation
                        {
                            X = 53760,
                            Y = -4608,
                            Z = 64000,
                            Room = 70
                        }
                    },
                    Trigger = new EMTrigger
                    {
                        Mask = 31,
                        Actions = new List<EMTriggerAction>
                        {
                            new EMTriggerAction
                            {
                                Parameter = 73
                            },
                            new EMTriggerAction
                            {
                                Parameter = 74
                            },
                            new EMTriggerAction
                            {
                                Parameter = 75
                            }
                        }
                    }
                },
                new EMSlantFunction
                {
                    Comments = "Change the shortcut slope at the beginning.",
                    EMType = EMType.Slant,
                    Location = new EMLocation
                    {
                        X = 76288,
                        Y = -2304,
                        Z = 49664,
                        Room = 8
                    },
                    SlantType = FDSlantEntryType.FloorSlant,
                    ZSlant = 3
                },
                new EMSlantFunction
                {
                    EMType = EMType.Slant,
                    Location = new EMLocation
                    {
                        X = 76288,
                        Y = -2304,
                        Z = 49664-1024,
                        Room = 8
                    },
                    SlantType = FDSlantEntryType.FloorSlant,
                    XSlant = 4,
                    ZSlant = -3
                },
                new EMModifyFaceFunction
                {
                    Comments = "Modify faces to match the new slope.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 8,
                            FaceIndex = 271,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = 256
                                },
                                [1] = new TRVertex
                                {
                                    Y = 256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 8,
                            FaceIndex = 272,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [1] = new TRVertex
                                {
                                    Y = 256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 8,
                            FaceIndex = 269,
                            FaceType = EMTextureFaceType.Rectangles,
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
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 8,
                            FaceIndex = 270,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = 256
                                },
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 8,
                            FaceIndices = new int[] {17,18 },
                            FaceType = EMTextureFaceType.Triangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [2] = new TRVertex
                                {
                                    Y = 256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 8,
                            FaceIndex = 16,
                            FaceType = EMTextureFaceType.Triangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = 256
                                },
                                [1] = new TRVertex
                                {
                                    Y = 256
                                },
                                [2] = new TRVertex
                                {
                                    Y = 256
                                }
                            }
                        }
                    }
                },
                new EMMovePickupFunction
                {
                    Comments = "Any pickups on the old slope will be moved elsewhere.",
                    EMType = EMType.MovePickup,
                    SectorLocations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 76288,
                            Y = -2304,
                            Z = 49664,
                            Room = 8
                        }
                    },
                    TargetLocation = new EMLocation
                    {
                        X = 75264,
                        Y = -2816,
                        Z = 50688,
                        Room = 10
                    }
                },
                new EMAddStaticMeshFunction
                {
                    Comments = "Block the shortcut into the end area.",
                    EMType = EMType.AddStaticMesh,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 39424-155,
                            Y = -4608,
                            Z = 45568-30,
                            Room = 81,
                            Angle = -32768
                        },
                    },
                    Mesh = new TR2RoomStaticMesh
                    {
                        MeshID = level.Rooms[80].StaticMeshes[0].MeshID,
                        Intensity1 = level.Rooms[80].StaticMeshes[0].Intensity,
                    },
                    IgnoreSectorEntities= true,
                },
                new EMImportTextureFunction
                {
                    Comments = "Restore the intended Colosseum roof from the beta version.",
                    EMType = EMType.ImportTexture,
                    Bitmap = @"Resources\TR1\Textures\Source\Static\Colosseum\Segments.png",
                    Tile = 3,
                    X = 128
                }
            };

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMFloodFunction
                    {
                        Comments = "Flood the crocodile pit.",
                        EMType = EMType.Flood,
                        Tags = new List<EMTag>
                        {
                            EMTag.WaterChange
                        },
                        RoomNumbers = new int[] { 87 },
                        WaterTextures = new ushort[] { 18, 19, 20, 21 }
                    },
                    new EMMoveEnemyFunction
                    {
                        Comments = "Move the enemies unless they are water creatures.",
                        EMType = EMType.MoveEnemy,
                        AttemptWaterCreature = false,
                        IfLandCreature = true,
                        EntityIndex = 82,
                        Location = new EMLocation
                        {
                            X = 67072,
                            Y = -2304,
                            Z = 56832,
                            Room = 2
                        }
                    },
                    new EMMoveEnemyFunction
                    {
                        EMType = EMType.MoveEnemy,
                        AttemptWaterCreature = false,
                        IfLandCreature = true,
                        EntityIndex = 83,
                        Location = new EMLocation
                        {
                            X = 61952,
                            Y = -2304,
                            Z = 56832,
                            Room = 2
                        }
                    },
                    new EMSlantFunction
                    {
                        Comments = "Make a ramp.",
                        EMType = EMType.Slant,
                        FloorClicks = -1,
                        SlantType = FDSlantEntryType.FloorSlant,
                        XSlant = -1,
                        Location = new EMLocation
                        {
                            X = 67072,
                            Y = -2304,
                            Z = 55808,
                            Room = 2
                        },
                    },
                    new EMModifyFaceFunction
                    {
                        Comments = "Move some faces to fit the ramp.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                RoomNumber = 2,
                                FaceIndex = 81,
                                FaceType = EMTextureFaceType.Rectangles,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -256,
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                RoomNumber = 2,
                                FaceIndex = 79,
                                FaceType = EMTextureFaceType.Rectangles,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                }
                            }
                        }
                    },
                    new EMAddFaceFunction
                    {
                        Comments = "Patch gaps.",
                        EMType = EMType.AddFace,
                        Quads = new Dictionary<short, List<TRFace4>>
                        {
                            [2] = new List<TRFace4>
                            {
                                new TRFace4
                                {
                                    Texture = 13,
                                    Vertices = new ushort[]{ 177,178,92,93 }
                                }
                            }
                        },
                        Triangles = new Dictionary<short, List<TRFace3>>
                        {
                            [2] = new List<TRFace3>
                            {
                                new TRFace3
                                {
                                    Texture = 15,
                                    Vertices = new ushort[]{ 93,107, 177 }
                                }
                            }
                        }
                    },
                },
                new EMEditorSet
                {
                    new EMFloorFunction
                    {
                        Comments = "Make a step to reach the final lever room.",
                        EMType = EMType.Floor,
                        Clicks = -1,
                        Location = new EMLocation
                        {
                            X = 35328,
                            Y = -256,
                            Z = 64000,
                            Room = 39
                        },
                        SideTexture = 74
                    },
                    new EMFloorFunction
                    {
                        Comments = "Make a block to get back out of the final area.",
                        EMType = EMType.Floor,
                        Clicks = -7,
                        Location = new EMLocation
                        {
                            X = 35328,
                            Y = -512,
                            Z = 51712,
                            Room = 38
                        },
                        FloorTexture = 72
                    },
                    new EMModifyFaceFunction
                    {
                        Comments = "Move some faces to fit the block.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                RoomNumber = 38,
                                FaceIndex = 21,
                                FaceType = EMTextureFaceType.Rectangles,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [1] = new TRVertex
                                    {
                                        X = -1024,
                                        Z = 1024
                                    },
                                    [2] = new TRVertex
                                    {
                                        X = -1024,
                                        Z = 1024
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                RoomNumber = 38,
                                FaceIndex = 15,
                                FaceType = EMTextureFaceType.Rectangles,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        X = -1024,
                                        Z = 1024
                                    },
                                    [3] = new TRVertex
                                    {
                                        X = -1024,
                                        Z = 1024
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                RoomNumber = 38,
                                FaceIndices = new int[] { 17, 23 },
                                FaceType = EMTextureFaceType.Rectangles,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                }
                            }
                        }
                    },

                    new EMRefaceFunction
                    {
                        Comments = "Retexture squished faces.",
                        EMType = EMType.Reface,
                        TextureMap = new EMTextureMap
                        {
                            [76] = new EMGeometryMap
                            {
                                [38] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 17, 23 }
                                }
                            }
                        }
                    },

                    new EMAddFaceFunction
                    {
                        Comments = "Patch gaps.",
                        EMType = EMType.AddFace,
                        Quads = new Dictionary<short, List<TRFace4>>
                        {
                            [38] = new List<TRFace4>
                            {
                                new TRFace4
                                {
                                    Texture = 76,
                                    Vertices = new ushort[]{ 35,34,36,30  }
                                },
                                new TRFace4
                                {
                                    Texture = 76,
                                    Vertices = new ushort[]{ 34,33,5,38 }
                                }
                            }
                        }
                    },

                    new EMDrainFunction
                    {
                        Comments = "Finally, drain the final area.",
                        EMType = EMType.Drain,
                        Tags = new List<EMTag>
                        {
                            EMTag.WaterChange
                        },
                        RoomNumbers = new int[] { 39, 38, 31, 58 },
                        WaterTextures = new ushort[] { 18, 19, 20, 21 }
                    },
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the clang-clang model is available.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.SlammingDoor,
                                TexturedFace4 = 63,
                                TexturedFace3 = 63
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some clang-clang doors.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = Array.Find(level7b.Entities, e => e.TypeID == (short)TREntities.SlammingDoor).Intensity,
                        Location = new EMLocation
                        {
                            X = 60928,
                            Y = -3584,
                            Z = 52736 - 512,
                            Room = 7,
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 60928,
                            Y = -3584,
                            Z = 51712,
                            Room = 33
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
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
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the clang-clang model is available.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.SlammingDoor,
                                TexturedFace4 = 63,
                                TexturedFace3 = 63
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some clang-clang doors.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = Array.Find(level7b.Entities, e => e.TypeID == (short)TREntities.SlammingDoor).Intensity,
                        Location = new EMLocation
                        {
                            X = 56832,
                            Y = -4608,
                            Z = 27136 - 512,
                            Room = 45,
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 56832,
                            Y = -4608,
                            Z = 27136 - 1024,
                            Room = 45
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
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
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the clang-clang model is available.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.SlammingDoor,
                                TexturedFace4 = 63,
                                TexturedFace3 = 63
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some clang-clang doors.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = Array.Find(level7b.Entities, e => e.TypeID == (short)TREntities.SlammingDoor).Intensity,
                        Location = new EMLocation
                        {
                            X = 55808,
                            Y = -4608,
                            Z = 62976 - 512,
                            Room = 71,
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 55808,
                            Y = -4608,
                            Z = 64000,
                            Room = 71
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
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
                        Comments = "Add some clang-clang doors.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = Array.Find(level7b.Entities, e => e.TypeID == (short)TREntities.SlammingDoor).Intensity,
                        Location = new EMLocation
                        {
                            X = 54784 - 512,
                            Y = -4608,
                            Z = 64000,
                            Room = 71,
                            Angle = 16384
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 55808,
                            Y = -4608,
                            Z = 64000,
                            Room = 71
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
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
                },
                new EMEditorSet
                {
                    new EMAddEntityFunction
                    {
                        Comments = "Add a boulder.",
                        EMType = EMType.AddEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.RollingBall).Intensity,
                        Flags = 0x100,
                        Location = new EMLocation
                        {
                            X = 55808,
                            Y = -7040 - 1024,
                            Z = 67072,
                            Room = 44,
                            Angle = -32768
                        },
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 55808,
                                Y = -4608,
                                Z = 64000,
                                Room = 71
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
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the falling ceiling model is available.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.FallingCeiling1,
                                TexturedFace4 = 72,
                                TexturedFace3 = 79
                            },
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some falling ceiling.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.FallingCeiling1,
                        Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.FallingCeiling1).Intensity,
                        Location = new EMLocation
                        {
                            X = 35328,
                            Y = -4608 - 2048-256,
                            Z = 32256,
                            Room = 37,
                            Angle = 16384
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 35328-1024,
                            Y = -4608,
                            Z = 32256,
                            Room = 37,
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 35328,
                                Y = -4608,
                                Z = 33280,
                                Room = 37,
                            },
                            new EMLocation
                            {
                                X = 36352,
                                Y = -4608,
                                Z = 32256,
                                Room = 37,
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
                        Comments = "Ensure the swinging blade model is available.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.SwingingBlade,
                                TextureMap = new Dictionary<ushort, ushort>
                                {
                                    [666] = 80,
                                    [667] = 80,
                                    [668] = 80,
                                    [669] = 910,
                                    [670] = 80,
                                    [671] = 716,
                                    [672] = 716,
                                    [673] = 716,
                                    [674] = 716,
                                    [675] = 716,
                                    [676] = 716,
                                    [677] = 716,
                                }
                            },
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add a blade.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SwingingBlade,
                        Intensity = Array.Find(level2.Entities, e => e.TypeID == (short)TREntities.SwingingBlade).Intensity,
                        Location = new EMLocation
                        {
                            X = 56832,
                            Y = -4608,
                            Z = 30208,
                            Room = 75
                        },
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        Location = new EMLocation
                        {
                            X = 57856,
                            Y = -8192,
                            Z = 72192,
                            Room= 44
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
                        Comments = "Import the trapdoor model.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.Trapdoor1,
                                TexturedFace4 = 80
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add a trapdoor to exit the pool.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.Trapdoor1,
                        Intensity = Array.Find(level2.Entities, e => e.TypeID == (short)TREntities.Trapdoor1).Intensity,
                        Flags = 0x3E00,
                        Location = new EMLocation
                        {
                            X = 74240,
                            Y = 1024+768,
                            Z = 43520,
                            Room = 3
                        },
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        EntityLocation = -1,
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
                    new EMTriggerFunction
                    {
                        Comments = "Pad to raise the trapdoor.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 81408,
                                Y = 3072,
                                Z = 43520,
                                Room = 5
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            TrigType = FDTrigType.Pad,
                            Timer = 10,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            }
                        },
                        HardVariant = new EMTriggerFunction
                        {
                            Comments = "A tighter timed run.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 81408,
                                    Y = 3072,
                                    Z = 43520,
                                    Room = 5
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 7,
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
                    new EMRefaceFunction
                    {
                        Comments = "Change the texture under the pad.",
                        EMType = EMType.Reface,
                        TextureMap =  new EMTextureMap
                        {
                            [63] = new EMGeometryMap
                            {
                                [5] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 73 }
                                }
                            }
                        }
                    },
                    new EMDrainFunction
                    {
                        Comments = "Drain the starting pool.",
                        EMType = EMType.Drain,
                        Tags = new List<EMTag>
                        {
                            EMTag.WaterChange
                        },
                        RoomNumbers = new int[] { 3,5 },
                        WaterTextures = new ushort[] { 18, 19, 20, 21 }
                    }
                }
            };

            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMSectorContainsSecretCondition
                    {
                        Comments = "If there is a secret in the crocodile pit...",
                        ConditionType = EMConditionType.SectorContainsSecret,
                        Location = new EMLocation
                        {
                            X = 67072,
                            Y = -512,
                            Z = 55808,
                            Room = 87
                        },
                        And = new List<BaseEMCondition>
                        {
                            new EMRoomContainsWaterCondition
                            {
                                Comments = "and the room has been flooded...",
                                ConditionType = EMConditionType.RoomContainsWater,
                                RoomIndex = 87
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
                                    X = 67072,
                                    Y = -512,
                                    Z = 55808,
                                    Room = 87
                                }
                            },
                            TargetLocation = new EMLocation
                            {
                                X = 66690,
                                Y = -512,
                                Z = 55426,
                                Room = 87
                            }
                        }
                    }
                }
            };

            mapping.ConditionalAllWithin = new List<EMConditionalEditorSet>
            {
                new EMConditionalEditorSet
                {
                    Condition = new EMRoomContainsWaterCondition
                    {
                        Comments = "If the end room has been drained, add an additional puzzle room.",
                        ConditionType = EMConditionType.RoomContainsWater,
                        RoomIndex = 58,
                    },
                    OnFalse = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMCreateRoomFunction
                            {
                                Comments = "Make a set of platforming rooms.",
                                EMType = EMType.CreateRoom,
                                Tags = new List<EMTag>
                                {
                                    EMTag.PuzzleRoom
                                },
                                Height = 16,
                                Width = 6,
                                Depth = 10,
                                Textures = new EMTextureGroup
                                {
                                    Floor = 63,
                                    Ceiling = 72,
                                    Wall4 = 72,
                                    Wall1 = 74,
                                    WallAlignment = Direction.Down
                                },
                                AmbientLighting = level.Rooms[46].AmbientIntensity,
                                DefaultVertex = new EMRoomVertex
                                {
                                    Lighting = level.Rooms[46].RoomData.Vertices[level.Rooms[46].RoomData.Rectangles[0].Vertices[2]].Lighting
                                },
                                Lights = new EMRoomLight[]
                                {
                                    new EMRoomLight
                                    {
                                        X = 4 * 1024 + 512,
                                        Y = -3072-256,
                                        Z = 8 * 1024 + 512,
                                        Intensity1 = 1024,
                                        Fade1 = 4096,
                                    },
                                    new EMRoomLight
                                    {
                                        X = 3 * 1024 + 512,
                                        Y = -3072-256,
                                        Z = 1 * 1024 + 512,
                                        Intensity1 = 2048,
                                        Fade1 = 4096,
                                    },
                                },
                                LinkedLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -512,
                                    Z = 97792,
                                    Room = 58
                                },
                                Location = new EMLocation
                                {
                                    X = 34816 - 5*1024,
                                    Y = -512 +3072,
                                    Z = 97280 - 7*1024
                                },
                                FloorHeights= new Dictionary<sbyte, List<int>>
                                {
                                    [-127] = new List<int> { 41,42,43,44,45,46,47,12,13,14,15,16,17,18,24,25,26,27,28 },
                                    [-7] = new List<int> { 38,48 },
                                    [-8] = new List<int> { 34 },
                                    //[-12] = new List<int> { 66,18 },
                                    //[-3] = new List<int> { 26 },
                                    //[-1] = new List<int> { 13,21 },
                                },
                                CeilingHeights = new Dictionary<sbyte, List<int>>
                                {
                                    //[2] = new List<int> { 10,13 },
                                }
                            },
                            new EMCreateRoomFunction
                            {
                                EMType = EMType.CreateRoom,
                                Height = 16,
                                Width = 5,
                                Depth = 10,
                                Textures = new EMTextureGroup
                                {
                                    Floor = 63,
                                    Ceiling = 72,
                                    Wall4 = 72,
                                    Wall1 = 74,
                                    WallAlignment = Direction.Down
                                },
                                AmbientLighting = level.Rooms[46].AmbientIntensity,
                                DefaultVertex = new EMRoomVertex
                                {
                                    Lighting = level.Rooms[46].RoomData.Vertices[level.Rooms[46].RoomData.Rectangles[0].Vertices[2]].Lighting
                                },
                                Lights = new EMRoomLight[]
                                {
                                    new EMRoomLight
                                    {
                                        X = 2 * 1024 + 512,
                                        Y = -3072-256,
                                        Z = 3 * 1024 + 512,
                                        Intensity1 = 2048,
                                        Fade1 = 4096,
                                    },
                                    new EMRoomLight
                                    {
                                        X = 3 * 1024 + 512,
                                        Y = -3072-256,
                                        Z = 8 * 1024 + 512,
                                        Intensity1 = 2048,
                                        Fade1 = 4096,
                                    },
                                },
                                LinkedLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -512,
                                    Z = 97792,
                                    Room = 58
                                },
                                Location = new EMLocation
                                {
                                    X = 34816 - 8*1024,
                                    Y = -512 +3072,
                                    Z = 97280 - 7*1024
                                },
                                FloorHeights= new Dictionary<sbyte, List<int>>
                                {
                                    [-127] = new List<int> { 11,14,21,33,15,16,17,26 },
                                    [-8] = new List<int> { 13 },
                                    [-12] = new List<int> { 36 },
                                },
                            },
                            new EMCreateRoomFunction
                            {
                                EMType = EMType.CreateRoom,
                                Height = 16,
                                Width = 4,
                                Depth = 10,
                                Textures = new EMTextureGroup
                                {
                                    Floor = 63,
                                    Ceiling = 72,
                                    Wall4 = 72,
                                    Wall3 = 76,
                                    Wall1 = 74,
                                    WallAlignment = Direction.Down
                                },
                                AmbientLighting = level.Rooms[46].AmbientIntensity,
                                DefaultVertex = new EMRoomVertex
                                {
                                    Lighting = level.Rooms[46].RoomData.Vertices[level.Rooms[46].RoomData.Rectangles[0].Vertices[2]].Lighting
                                },
                                Lights = new EMRoomLight[]
                                {
                                    new EMRoomLight
                                    {
                                        X = 2 * 1024 + 512,
                                        Y = -1024-256,
                                        Z = 1 * 1024 + 512,
                                        Intensity1 = 4096+1024,
                                        Fade1 = 1024,
                                    },
                                    new EMRoomLight
                                    {
                                        X = 2 * 1024 + 512,
                                        Y = -3072-256,
                                        Z = 6 * 1024 + 512,
                                        Intensity1 = 2048,
                                        Fade1 = 4096,
                                    },
                                },
                                LinkedLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -512,
                                    Z = 97792,
                                    Room = 58
                                },
                                Location = new EMLocation
                                {
                                    X = 34816 - 10*1024,
                                    Y = -512 +3072,
                                    Z = 97280 - 7*1024
                                },
                                FloorHeights= new Dictionary<sbyte, List<int>>
                                {
                                    [-127] = new List<int> { 22,23,25,18 },
                                    [-8] = new List<int> { 24 },
                                    [-3] = new List<int> { 26 },
                                    [-2] = new List<int> { 13 },
                                    [-1] = new List<int> { 21 },
                                },
                                CeilingHeights = new Dictionary<sbyte, List<int>>
                                {
                                    [4] = new List<int> { 24 }
                                }
                            },
                            new EMCreateRoomFunction
                            {
                                EMType = EMType.CreateRoom,
                                Height = 5,
                                Width = 20,
                                Depth = 3,
                                Textures = new EMTextureGroup
                                {
                                    Floor = 72,
                                    Ceiling = 72,
                                    Wall4 = 72,
                                    Wall1 = 74,
                                    WallAlignment = Direction.Down
                                },
                                AmbientLighting = level.Rooms[46].AmbientIntensity,
                                DefaultVertex = new EMRoomVertex
                                {
                                    Lighting = level.Rooms[46].RoomData.Vertices[level.Rooms[46].RoomData.Rectangles[0].Vertices[2]].Lighting
                                },
                                Lights = new EMRoomLight[]
                                {
                                    new EMRoomLight
                                    {
                                        X = 3 * 1024 + 512,
                                        Y = -512,
                                        Z = 1 * 1024 + 512,
                                        Intensity1 = 2048,
                                        Fade1 = 4096,
                                    },
                                },
                                LinkedLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -512,
                                    Z = 97792,
                                    Room = 58
                                },
                                Location = new EMLocation
                                {
                                    X = 34816 - 10*1024,
                                    Y = -512 +3072 - 16*256,
                                    Z = 97280 - 1*1024
                                },
                                FloorHeights= new Dictionary<sbyte, List<int>>
                                {
                                    [-1] = new List<int> { 7,10,13,16,19,22,25,28,31,34,37,40,43,46,49,52,55 },
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
                                        BaseRoom = 58,
                                        AdjoiningRoom = -4,
                                        Normal = new TRVertex
                                        {
                                            X = 1,
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = -512 - 1024,
                                                Z = 18 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = -512 - 1024,
                                                Z = 19 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = -512,
                                                Z = 19 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = -512,
                                                Z = 18 * 1024
                                            }
                                        }
                                    },
                                    new EMVisibilityPortal
                                    {
                                        BaseRoom = -4,
                                        AdjoiningRoom = 58,
                                        Normal = new TRVertex
                                        {
                                            X = -1,
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = 5 * 1024,
                                                Y = -512 - 1024,
                                                Z = 9 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 5 * 1024,
                                                Y = -512 - 1024,
                                                Z = 8 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 5 * 1024,
                                                Y = -512,
                                                Z = 8 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 5 * 1024,
                                                Y = -512,
                                                Z = 9 * 1024
                                            }
                                        }
                                    },

                                    new EMVisibilityPortal
                                    {
                                        BaseRoom = -4,
                                        AdjoiningRoom = -3,
                                        Normal = new TRVertex
                                        {
                                            X = 1,
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560 - 4096,
                                                Z = 1 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560 - 4096,
                                                Z = 2 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560,
                                                Z = 2 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560,
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
                                            X = -1,
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 2560 - 4096,
                                                Z = 2 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 2560 - 4096,
                                                Z = 1 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 2560,
                                                Z = 1 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 2560,
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
                                            X = 1,
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560 - 4096,
                                                Z = 8 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560 - 4096,
                                                Z = 9 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560,
                                                Z = 9 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560,
                                                Z = 8 * 1024
                                            }
                                        }
                                    },
                                    new EMVisibilityPortal
                                    {
                                        BaseRoom = -2,
                                        AdjoiningRoom = -3,
                                        Normal = new TRVertex
                                        {
                                            X = -1,
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 2560 - 4096,
                                                Z = 9 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 2560 - 4096,
                                                Z = 8 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 2560,
                                                Z = 8 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 2560,
                                                Z = 9 * 1024
                                            }
                                        }
                                    },

                                    new EMVisibilityPortal
                                    {
                                        BaseRoom = -2,
                                        AdjoiningRoom = -1,
                                        Normal = new TRVertex
                                        {
                                            Y = 1,
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = -1536,
                                                Z = 7 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 2 * 1024,
                                                Y = -1536,
                                                Z = 7 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 2 * 1024,
                                                Y = -1536,
                                                Z = 8 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = -1536,
                                                Z = 8 * 1024
                                            }
                                        }
                                    },
                                    new EMVisibilityPortal
                                    {
                                        BaseRoom = -1,
                                        AdjoiningRoom = -2,
                                        Normal = new TRVertex
                                        {
                                            Y = -1,
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
                                }
                            },
                            new EMHorizontalCollisionalPortalFunction
                            {
                                Comments = "Make collisional portals.",
                                EMType = EMType.HorizontalCollisionalPortal,
                                Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                                {
                                    [58] = new Dictionary<short, EMLocation[]>
                                    {
                                        [-4] = new EMLocation[]
                                        {
                                            new EMLocation
                                            {
                                                X = 35328 - 1024,
                                                Y = -512,
                                                Z = 98816,
                                                Room = 58
                                            }
                                        }
                                    },
                                    [-4] = new Dictionary<short, EMLocation[]>
                                    {
                                        [58] = new EMLocation[]
                                        {
                                            new EMLocation
                                            {
                                                X = 35328,
                                                Y = -512,
                                                Z = 98816,
                                                Room = -4
                                            }
                                        },
                                        [-3] = new EMLocation[]
                                        {
                                            new EMLocation
                                            {
                                                X = 31232 - 1024,
                                                Y = -512,
                                                Z = 91648,
                                                Room = -4
                                            }
                                        },
                                    },
                                    [-3] = new Dictionary<short, EMLocation[]>
                                    {
                                        [-4] = new EMLocation[]
                                        {
                                            new EMLocation
                                            {
                                                X = 31232,
                                                Y = -512,
                                                Z = 91648,
                                                Room = -3
                                            }
                                        },
                                        [-2] = new EMLocation[]
                                        {
                                            new EMLocation
                                            {
                                                X = 28160 - 1024,
                                                Y = -512,
                                                Z = 98816,
                                                Room = -3
                                            }
                                        },
                                    },
                                    [-2] = new Dictionary<short, EMLocation[]>
                                    {
                                        [-3] = new EMLocation[]
                                        {
                                            new EMLocation
                                            {
                                                X = 28160,
                                                Y = -512,
                                                Z = 98816,
                                                Room = -2
                                            }
                                        },
                                    }
                                }
                            },
                            new EMVerticalCollisionalPortalFunction
                            {
                                EMType = EMType.VerticalCollisionalPortal,
                                Ceiling = new EMLocation
                                {
                                    X = 26112,
                                    Y = -1536,
                                    Z = 97792,
                                    Room = -1
                                },
                                Floor = new EMLocation
                                {
                                    X = 26112,
                                    Y = -1536 + 1024,
                                    Z = 97792,
                                    Room = -2
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Change some textures.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [72] = new EMGeometryMap
                                    {
                                        [-4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 100,108,60 }
                                        },
                                        [-3] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 12,121 }
                                        },
                                        [-2] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 22,83,88 }
                                        },
                                    },
                                    [917] = new EMGeometryMap
                                    {
                                        [-4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 0 }
                                        },
                                        [-3] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 18 }
                                        },
                                        [-2] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 69 }
                                        },
                                    }
                                }
                            },
                            new EMClickFunction
                            {
                                Comments = "Make the first jump easier.",
                                EMType = EMType.Slant,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = 768,
                                    Z = 98816,
                                    Room = -4
                                },
                                FloorClicks = -1,
                                HardVariant = new EMPlaceholderFunction
                                {
                                    Comments = "Placeholder for hard mode.",
                                    EMType = EMType.NOOP
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = -4,
                                        FaceIndex = 102,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [1] = new TRVertex
                                            {
                                                X = 1024,
                                                Z = -1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 1024,
                                                Z = -1024
                                            }
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = -4,
                                        FaceIndex = 105,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = 1024,
                                                Z = -1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = 1024,
                                                Z = -1024
                                            }
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = -4,
                                        FaceIndex = 100,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = -256
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = -256
                                            },
                                            [2] = new TRVertex
                                            {
                                                Y = -256
                                            },
                                            [3] = new TRVertex
                                            {
                                                Y = -256
                                            }
                                        }
                                    }
                                },
                                HardVariant = new EMPlaceholderFunction
                                {
                                    Comments = "Placeholder for hard mode.",
                                    EMType = EMType.NOOP
                                }
                            },
                            new EMRemoveFaceFunction
                            {
                                Comments = "Remove redundant faces.",
                                EMType = EMType.RemoveFace,
                                GeometryMap = new EMGeometryMap
                                {
                                    [58] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 53 }
                                    },
                                    [-4] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 115,2,3,4,5 }
                                    },
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 20,21,22,23,84,85,86,87 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 60,115,116,117,118 }
                                    },
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0 }
                                    }
                                }
                            },
                            new EMKillLaraFunction
                            {
                                Comments = "Add death tiles.",
                                EMType = EMType.KillLara,
                                Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("colosseumdeath.json"))[Level]
                            },
                            new EMImportNonGraphicsModelFunction
                            {
                                Comments = "Import the moving block and trapdoor models.",
                                EMType = EMType.ImportNonGraphicsModel,
                                Data = new List<EMMeshTextureData>
                                {
                                    new EMMeshTextureData
                                    {
                                        ModelID = (short)TREntities.MovingBlock,
                                        TexturedFace4 = 72
                                    },
                                    new EMMeshTextureData
                                    {
                                        ModelID = (short)TREntities.Trapdoor1,
                                        TexturedFace4 = 80
                                    }
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Add a moving block.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.MovingBlock,
                                Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.MovingBlock).Intensity,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = 2560,
                                    Z = 91648,
                                    Room= -4,
                                    Angle = -16384
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Trigger it after the first jump in easy mode.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 33280,
                                        Y = 512,
                                        Z = 94720,
                                        Room = -4
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
                                },
                                HardVariant = new EMTriggerFunction
                                {
                                    Comments = "Triggers are on the floor instead, plus the block will return to its original spot after 5 seconds.",
                                    EMType = EMType.Trigger,
                                    ExpandedLocations = new EMLocationExpander
                                    {
                                        Location = new EMLocation
                                        {
                                            X = 32256,
                                            Y = 2560,
                                            Z = 92672,
                                            Room = -4
                                        },
                                        ExpandX = 2,
                                        ExpandZ = 2
                                    },
                                    Trigger = new EMTrigger
                                    {
                                        Mask = 31,
                                        Timer = 5,
                                        Actions = new List<EMTriggerAction>
                                        {
                                            new EMTriggerAction
                                            {
                                                Parameter = -1
                                            }
                                        }
                                    },
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Add a trapdoor in easy mode for the 4th jump.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.Trapdoor1,
                                Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                                Flags = 0x3E00,
                                Location = new EMLocation
                                {
                                    X = 30208,
                                    Y = 2560 - 8 * 256,
                                    Z = 94720,
                                    Room = -3
                                },
                                HardVariant = new EMAddEntityFunction
                                {
                                    Comments = "Add spikes under the block's target in hard mode as we can't add a death tile here.",
                                    EMType = EMType.AddEntity,
                                    TypeID = (short)TREntities.TeethSpikes,
                                    Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                                    Location = new EMLocation
                                    {
                                        X = 33280 - 2048,
                                        Y = 2560,
                                        Z = 91648,
                                        Room= -4
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Trapdoor dummy trigger.",
                                EMType = EMType.Trigger,
                                EntityLocation = -1,
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
                                },
                                HardVariant = new EMPlaceholderFunction
                                {
                                    Comments = "Not required in hard mode.",
                                    EMType = EMType.NOOP
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Trigger the trapdoor on the 3rd jump.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 28160,
                                        Y = 512,
                                        Z = 93696,
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
                                            Parameter = -1
                                        }
                                    }
                                },
                                HardVariant = new EMPlaceholderFunction
                                {
                                    Comments = "No trigger needed in hard mode.",
                                    EMType = EMType.NOOP
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Add another moving block.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.MovingBlock,
                                Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.MovingBlock).Intensity,
                                Location = new EMLocation
                                {
                                    X = 30208,
                                    Y = 2560,
                                    Z = 98816,
                                    Room= -3,
                                    Angle = -16384
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Trigger the moving block.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 30208,
                                        Y = -512,
                                        Z = 96768,
                                        Room = -3,
                                    },
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
                                },
                                HardVariant = new EMTriggerFunction
                                {
                                    Comments = "The hard variant will return the block to its original spot after 5 seconds.",
                                    EMType = EMType.Trigger,
                                    ExpandedLocations = new EMLocationExpander
                                    {
                                        Location = new EMLocation
                                        {
                                            X = 30208 - 1024,
                                            Y = 2560,
                                            Z = 98816 - 1024,
                                            Room = -3,
                                        },
                                        ExpandX = 2,
                                        ExpandZ = 2
                                    },
                                    Trigger = new EMTrigger
                                    {
                                        Mask = 31,
                                        Timer = 5,
                                        Actions = new List<EMTriggerAction>
                                        {
                                            new EMTriggerAction
                                            {
                                                Parameter = -1
                                            }
                                        }
                                    },
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "An additional trapdoor to make exiting easier.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.Trapdoor1,
                                Intensity = Array.Find(level2.Entities, e => e.TypeID == (short)TREntities.Trapdoor1).Intensity,
                                Flags = 0x3E00,
                                Location = new EMLocation
                                {
                                    X = 26112,
                                    Z = 95744,
                                    Room= -2,
                                    Angle = 16384
                                },
                                HardVariant = new EMAddEntityFunction
                                {
                                    Comments = "Same idea with the spikes under the block.",
                                    EMType = EMType.AddEntity,
                                    TypeID = (short)TREntities.TeethSpikes,
                                    Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                                    Location = new EMLocation
                                    {
                                        X = 30208 - 2048,
                                        Y = 2560,
                                        Z = 98816,
                                        Room= -3,
                                    }
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Add a trapdoor to exit.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.Trapdoor1,
                                Intensity = Array.Find(level2.Entities, e => e.TypeID == (short)TREntities.Trapdoor1).Intensity,
                                Flags = 0x3E00,
                                Location = new EMLocation
                                {
                                    X = 26112,
                                    Y = -1536+6*256,
                                    Z = 97792,
                                    Room= -2,
                                    Angle = 16384
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments ="Trapdoor dummy trigger.",
                                EMType = EMType.Trigger,
                                EntityLocation = -1,
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
                            new EMTriggerFunction
                            {
                                Comments = "Trapdoor dummy trigger.",
                                EMType = EMType.Trigger,
                                EntityLocation = -2,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    TrigType = FDTrigType.Dummy,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = -2
                                        }
                                    }
                                },
                                HardVariant = new EMPlaceholderFunction
                                {
                                    Comments = "Not required in hard mode.",
                                    EMType = EMType.NOOP
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pad to raise the trapdoor(s).",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 27136,
                                        Y = 2304,
                                        Z = 91648,
                                        Room = -2,
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
                                },
                                HardVariant = new EMTriggerFunction
                                {
                                    Comments = "The hard variant sets the trapdoor on a 15 second timer.",
                                    EMType = EMType.Trigger,
                                    Locations = new List<EMLocation>
                                    {
                                        new EMLocation
                                        {
                                            X = 27136,
                                            Y = 2304,
                                            Z = 91648,
                                            Room = -2,
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
                                                Parameter = -1
                                            }
                                        }
                                    },
                                }
                            },
                            new EMMoveCameraFunction
                            {
                                Comments = "Move the original camera to the new end tunnel.",
                                EMType = EMType.MoveCamera,
                                CameraIndex = 2,
                                NewLocation = new EMLocation
                                {
                                    X = 27136,
                                    Y = -1792 - 640,
                                    Z = 97792,
                                    Room = -1
                                }
                            },
                            new EMRemoveTriggerFunction
                            {
                                Comments = "Clear all triggers from the original end tunnel.",
                                EMType = EMType.RemoveTrigger,
                                Rooms = new List<int> { 58 }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Add placeholder triggers in the new end room.",
                                EMType = EMType.Trigger,
                                ExpandedLocations = new EMLocationExpander
                                {
                                    Location = new EMLocation
                                    {
                                        X = 28160,
                                        Y = -1792,
                                        Z = 97792,
                                        Room = -1,
                                    },
                                    ExpandX = 7,
                                    ExpandZ = 1
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction { }
                                    }
                                }
                            },
                            new EMCameraTriggerFunction
                            {
                                Comments = "Add a camera action to the end room triggers.",
                                EMType = EMType.CameraTriggerFunction,
                                CameraIndex = 2,
                                AttachToRooms = new short[] { -1 },
                                CameraAction = new FDCameraAction
                                {
                                    Value = 34816
                                }
                            },
                            new EMRemoveTriggerActionFunction
                            {
                                EMType = EMType.RemoveTriggerAction,
                                ActionItem = new EMTriggerAction
                                {
                                },
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 28160,
                                        Y = -1792,
                                        Z = 97792,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 28160 + 1 * 1024,
                                        Y = -1792,
                                        Z = 97792,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 28160 + 2 * 1024,
                                        Y = -1792,
                                        Z = 97792,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 28160 + 3 * 1024,
                                        Y = -1792,
                                        Z = 97792,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 28160 + 4 * 1024,
                                        Y = -1792,
                                        Z = 97792,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 28160 + 5 * 1024,
                                        Y = -1792,
                                        Z = 97792,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 28160 + 6 * 1024,
                                        Y = -1792,
                                        Z = 97792,
                                        Room = -1,
                                    },
                                }
                            },
                            new EMAppendTriggerActionFunction
                            {
                                Comments = "Append the end-level trigger.",
                                EMType = EMType.AppendTriggerActionFunction,
                                Location = new EMLocation
                                {
                                    X = 28160 + 6 * 1024,
                                    Y = -1792,
                                    Z = 97792,
                                    Room = -1,
                                },
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Action = FDTrigAction.EndLevel
                                    }
                                }
                            },
                            new EMGenerateLightFunction
                            {
                                Comments= "Generate light.",
                                EMType = EMType.GenerateLight,
                                RoomIndices = new List<short> {-1,-2,-3,-4}
                            }
                        },
                        new EMEditorSet
                        {
                            new EMCreateRoomFunction
                            {
                                Comments = "An easier variant of above.",
                                EMType = EMType.CreateRoom,
                                Tags = new List<EMTag>
                                {
                                    EMTag.PuzzleRoom
                                },
                                Height = 16,
                                Width = 6,
                                Depth = 10,
                                Textures = new EMTextureGroup
                                {
                                    Floor = 72,
                                    Ceiling = 72,
                                    Wall4 = 72,
                                    Wall3 = 76,
                                    Wall1 = 74,
                                    WallAlignment = Direction.Down
                                },
                                AmbientLighting = level.Rooms[46].AmbientIntensity,
                                DefaultVertex = new EMRoomVertex
                                {
                                    Lighting = level.Rooms[46].RoomData.Vertices[level.Rooms[46].RoomData.Rectangles[0].Vertices[2]].Lighting
                                },
                                Lights = new EMRoomLight[]
                                {
                                    new EMRoomLight
                                    {
                                        X = 4 * 1024 + 512,
                                        Y = -3072-256,
                                        Z = 8 * 1024 + 512,
                                        Intensity1 = 1024,
                                        Fade1 = 4096,
                                    },
                                    new EMRoomLight
                                    {
                                        X = 3 * 1024 + 512,
                                        Y = -3072,
                                        Z = 5 * 1024 + 512,
                                        Intensity1 = 3072,
                                        Fade1 = 4096,
                                    },
                                    new EMRoomLight
                                    {
                                        X = 3 * 1024 + 512,
                                        Y = -3072-256,
                                        Z = 1 * 1024 + 512,
                                        Intensity1 = 2048,
                                        Fade1 = 4096,
                                    },
                                    new EMRoomLight
                                    {
                                        X = 1 * 1024 + 512,
                                        Y = -2048,
                                        Z = 3 * 1024 + 512,
                                        Intensity1 = 1500,
                                        Fade1 = 4096,
                                    },
                                },
                                LinkedLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -512,
                                    Z = 97792,
                                    Room = 58
                                },
                                Location = new EMLocation
                                {
                                    X = 34816 - 5*1024,
                                    Y = -512 +3072,
                                    Z = 97280 - 7*1024
                                },
                                FloorHeights= new Dictionary<sbyte, List<int>>
                                {
                                    [-127] = new List<int> { 41,42,43,44,45,46,47,15,16,17,18,25,26,27,28,23,22,24 },
                                    [-7] = new List<int> { 38,48,31 },
                                    [-11] = new List<int> { 12 },
                                    [-4] = new List<int> { 13 },
                                },
                                CeilingHeights = new Dictionary<sbyte, List<int>>
                                {
                                    [8] = new List<int> { 14, },
                                    [2] = new List<int> { 12,13 },
                                }
                            },
                            new EMCreateRoomFunction
                            {
                                EMType = EMType.CreateRoom,
                                Height = 4,
                                Width = 20,
                                Depth = 3,
                                Textures = new EMTextureGroup
                                {
                                    Floor = 72,
                                    Ceiling = 72,
                                    Wall4 = 72,
                                    Wall1 = 74,
                                    WallAlignment = Direction.Down
                                },
                                AmbientLighting = level.Rooms[46].AmbientIntensity,
                                DefaultVertex = new EMRoomVertex
                                {
                                    Lighting = level.Rooms[46].RoomData.Vertices[level.Rooms[46].RoomData.Rectangles[0].Vertices[2]].Lighting
                                },
                                Lights = new EMRoomLight[]
                                {
                                    new EMRoomLight
                                    {
                                        X = 16 * 1024 + 512,
                                        Y = -512,
                                        Z = 1 * 1024 + 512,
                                        Intensity1 = 2048,
                                        Fade1 = 4096,
                                    },
                                },
                                LinkedLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -512,
                                    Z = 97792,
                                    Room = 58
                                },
                                Location = new EMLocation
                                {
                                    X = 34816 - 23*1024,
                                    Y = -512 +3072,
                                    Z = 97280 - 4*1024
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
                                        BaseRoom = 58,
                                        AdjoiningRoom = -2,
                                        Normal = new TRVertex
                                        {
                                            X = 1,
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = -512 - 1024,
                                                Z = 18 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = -512 - 1024,
                                                Z = 19 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = -512,
                                                Z = 19 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = -512,
                                                Z = 18 * 1024
                                            }
                                        }
                                    },
                                    new EMVisibilityPortal
                                    {
                                        BaseRoom = -2,
                                        AdjoiningRoom = 58,
                                        Normal = new TRVertex
                                        {
                                            X = -1,
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = 5 * 1024,
                                                Y = -512 - 1024,
                                                Z = 9 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 5 * 1024,
                                                Y = -512 - 1024,
                                                Z = 8 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 5 * 1024,
                                                Y = -512,
                                                Z = 8 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 5 * 1024,
                                                Y = -512,
                                                Z = 9 * 1024
                                            }
                                        }
                                    },

                                    new EMVisibilityPortal
                                    {
                                        BaseRoom = -2,
                                        AdjoiningRoom = -1,
                                        Normal = new TRVertex
                                        {
                                            X = 1,
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560 - 1024,
                                                Z = 4 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560 - 1024,
                                                Z = 5 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560,
                                                Z = 5 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Y = 2560,
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
                                            X = -1,
                                        },
                                        Vertices = new TRVertex[]
                                        {
                                            new TRVertex
                                            {
                                                X = 19 * 1024,
                                                Y = 2560 - 1024,
                                                Z = 2 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 19 * 1024,
                                                Y = 2560 - 1024,
                                                Z = 1 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 19 * 1024,
                                                Y = 2560,
                                                Z = 1 * 1024
                                            },
                                            new TRVertex
                                            {
                                                X = 19 * 1024,
                                                Y = 2560,
                                                Z = 2 * 1024
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
                                    [58] = new Dictionary<short, EMLocation[]>
                                    {
                                        [-2] = new EMLocation[]
                                        {
                                            new EMLocation
                                            {
                                                X = 35328 - 1024,
                                                Y = -512,
                                                Z = 98816,
                                                Room = 58
                                            }
                                        }
                                    },
                                    [-2] = new Dictionary<short, EMLocation[]>
                                    {
                                        [58] = new EMLocation[]
                                        {
                                            new EMLocation
                                            {
                                                X = 35328,
                                                Y = -512,
                                                Z = 98816,
                                                Room = -2
                                            }
                                        },
                                        [-1] = new EMLocation[]
                                        {
                                            new EMLocation
                                            {
                                                X = 30208,
                                                Y = 2560,
                                                Z = 94720,
                                                Room = -2
                                            }
                                        },
                                    },
                                    [-1] = new Dictionary<short, EMLocation[]>
                                    {
                                        [-2] = new EMLocation[]
                                        {
                                            new EMLocation
                                            {
                                                X = 30208 + 1024,
                                                Y = 2560,
                                                Z = 94720,
                                                Room = -1
                                            }
                                        }
                                    },

                                }
                            },
                            new EMRemoveFaceFunction
                            {
                                Comments = "Remove redundant faces.",
                                EMType = EMType.RemoveFace,
                                GeometryMap = new EMGeometryMap
                                {
                                    [58] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 53 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 138,32 }
                                    },
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 72 }
                                    }
                                }
                            },
                            new EMImportNonGraphicsModelFunction
                            {
                                Comments = "Import the moving block model.",
                                EMType = EMType.ImportNonGraphicsModel,
                                Data = new List<EMMeshTextureData>
                                {
                                    new EMMeshTextureData
                                    {
                                        ModelID = (short)TREntities.MovingBlock,
                                        TexturedFace4 = 72
                                    },
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Add a moving block and its triggers.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.MovingBlock,
                                Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.MovingBlock).Intensity,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = 2560,
                                    Z = 94720,
                                    Room= -2,
                                    Angle = -16384
                                }
                            },
                            new EMTriggerFunction
                            {
                                EMType = EMType.Trigger,
                                ExpandedLocations = new EMLocationExpander
                                {
                                    Location = new EMLocation
                                    {
                                        X = 33280,
                                        Y = 2560,
                                        Z = 92672,
                                        Room = -2
                                    },
                                    ExpandX = 1,
                                    ExpandZ = 6
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    Timer = 2,
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
                                Comments = "Add some spikes.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.TeethSpikes,
                                Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = 2560,
                                    Z = 94720 + 3072,
                                    Room= -2,
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Add some spikes.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.TeethSpikes,
                                Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = 2560,
                                    Z = 94720 + 2048,
                                    Room= -2,
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Add some spikes.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.TeethSpikes,
                                Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = 2560,
                                    Z = 94720 + 1024,
                                    Room= -2,
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Add some spikes.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.TeethSpikes,
                                Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = 2560,
                                    Z = 94720 - 1024,
                                    Room= -2,
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Add some spikes.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.TeethSpikes,
                                Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = 2560,
                                    Z = 94720 - 2048,
                                    Room= -2,
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Add some spikes.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.TeethSpikes,
                                Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                                Location = new EMLocation
                                {
                                    X = 32256,
                                    Y = 2560,
                                    Z = 91648,
                                    Room= -2,
                                }
                            },
                            new EMAddEntityFunction
                            {
                                Comments = "Add some spikes.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.TeethSpikes,
                                Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                                Location = new EMLocation
                                {
                                    X = 32256 - 1024,
                                    Y = 2560,
                                    Z = 91648,
                                    Room= -2,
                                }
                            },

                            new EMMoveCameraFunction
                            {
                                Comments = "Move the original camera to the new end tunnel.",
                                EMType = EMType.MoveCamera,
                                CameraIndex = 2,
                                NewLocation = new EMLocation
                                {
                                    X = 29184,
                                    Y = 2560 - 640,
                                    Z = 94720,
                                    Room = -1
                                }
                            },
                            new EMRemoveTriggerFunction
                            {
                                Comments = "Clear all triggers from the original end tunnel.",
                                EMType = EMType.RemoveTrigger,
                                Rooms = new List<int> { 58 }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Add placeholder triggers in the new end room.",
                                EMType = EMType.Trigger,
                                ExpandedLocations = new EMLocationExpander
                                {
                                    Location = new EMLocation
                                    {
                                        X = 22016,
                                        Y = 2560,
                                        Z = 94720,
                                        Room = -1,
                                    },
                                    ExpandX = 7,
                                    ExpandZ = 1
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction { }
                                    }
                                }
                            },
                            new EMCameraTriggerFunction
                            {
                                Comments = "Add a camera action to the end room triggers.",
                                EMType = EMType.CameraTriggerFunction,
                                CameraIndex = 2,
                                AttachToRooms = new short[] { -1 },
                                CameraAction = new FDCameraAction
                                {
                                    Value = 34816
                                }
                            },
                            new EMRemoveTriggerActionFunction
                            {
                                EMType = EMType.RemoveTriggerAction,
                                ActionItem = new EMTriggerAction
                                {
                                },
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 22016,
                                        Y = 2560,
                                        Z = 94720,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 22016 + 1024,
                                        Y = 2560,
                                        Z = 94720,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 22016 + 2*1024,
                                        Y = 2560,
                                        Z = 94720,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 22016 + 3*1024,
                                        Y = 2560,
                                        Z = 94720,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 22016 + 4*1024,
                                        Y = 2560,
                                        Z = 94720,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 22016 + 5*1024,
                                        Y = 2560,
                                        Z = 94720,
                                        Room = -1,
                                    },
                                    new EMLocation
                                    {
                                        X = 22016 + 6*1024,
                                        Y = 2560,
                                        Z = 94720,
                                        Room = -1,
                                    },
                                }
                            },
                            new EMAppendTriggerActionFunction
                            {
                                Comments = "Append the end-level trigger.",
                                EMType = EMType.AppendTriggerActionFunction,
                                Location = new EMLocation
                                {
                                    X = 22016,
                                    Y = 2560,
                                    Z = 94720,
                                    Room = -1,
                                },
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Action = FDTrigAction.EndLevel
                                    }
                                }
                            },

                            new EMGenerateLightFunction
                            {
                                Comments = "Generate light.",
                                EMType = EMType.GenerateLight,
                                RoomIndices = new List<short> { -1,-2 }
                            }
                        }
                    },
                }
            };

            mapping.AllWithin = new List<List<EMEditorSet>>
            {
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Leave block 51 where it is.",
                            EMType = EMType.NOOP,
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move block 51 forward.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 51,
                            TargetLocation = new EMLocation
                            {
                                X = 30208,
                                Y = -6144,
                                Z = 19968 - 1024,
                                Room = 55
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move block 51 back.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 51,
                            TargetLocation = new EMLocation
                            {
                                X = 30208,
                                Y = -6144,
                                Z = 19968 + 1024,
                                Room = 55
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move block 51 somewhere obscure.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 51,
                            TargetLocation = new EMLocation
                            {
                                X = 60928,
                                Y = -2048,
                                Z = 48640,
                                Room = 32
                            }
                        }
                    }
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352,
                                Y = -4096,
                                Z = 50688,
                                Room = 24,
                                Angle = 16384
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 3*1024,
                                Y = -4096,
                                Z = 50688,
                                Room = 24
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 3*1024,
                                Y = -4096,
                                Z = 50688,
                                Room = 24,
                                Angle = -16384
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 3*1024,
                                Y = -4096,
                                Z = 50688 - 1024,
                                Room = 24,
                                Angle = -16384
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 3*1024,
                                Y = -4096,
                                Z = 50688 - 4 * 1024,
                                Room = 24,
                                Angle = -16384
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 3*1024,
                                Y = -4096,
                                Z = 50688 - 5 * 1024,
                                Room = 24,
                                Angle = -16384
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 3*1024,
                                Y = -4096,
                                Z = 50688 - 6 * 1024,
                                Room = 24,
                                Angle = -16384
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 3*1024,
                                Y = -4096,
                                Z = 50688 - 6 * 1024,
                                Room = 24,
                                Angle = -32768
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 2*1024,
                                Y = -4096,
                                Z = 50688 - 6 * 1024,
                                Room = 24,
                                Angle = -32768
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 1*1024,
                                Y = -4096,
                                Z = 50688 - 6 * 1024,
                                Room = 24,
                                Angle = -32768
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 0*1024,
                                Y = -4096,
                                Z = 50688 - 6 * 1024,
                                Room = 24,
                                Angle = -32768
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 0*1024,
                                Y = -4096,
                                Z = 50688 - 6 * 1024,
                                Room = 24,
                                Angle = 16384
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 0*1024,
                                Y = -4096,
                                Z = 50688 - 5 * 1024,
                                Room = 24,
                                Angle = 16384
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 1*1024,
                                Y = -4096 + 256,
                                Z = 50688 - 2 * 1024,
                                Room = 24,
                                Angle = -16384
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 2*1024,
                                Y = -4096 + 256,
                                Z = 50688 - 4 * 1024,
                                Room = 24,
                                Angle = 0
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 3*1024,
                                Y = -4096,
                                Z = 50688 - 3 * 1024,
                                Room = 24,
                                Angle = 16384
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential keyhole relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 23,
                            Location = new EMLocation
                            {
                                X = 36352 - 3*1024,
                                Y = -4096,
                                Z = 50688 - 2 * 1024,
                                Room = 24,
                                Angle = 16384
                            }
                        },
                    }
                }
            };

            mapping.OneOf = new List<EMEditorGroupedSet>
            {
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 44.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[44].RoomData.Rectangles[41].Texture] = new EMGeometryMap
                                {
                                    [44] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 47 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Move the face to fit the rest of the room.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 44,
                                    FaceIndex = 47,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -512,
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -512,
                                        },
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = -8192,
                                    Z = 72192,
                                    Room = 44,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[47].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 41 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Move faces to fit the original lever layout.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 41,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 48,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Z = -1024,
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = -1024,
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = -1024,
                                            },
                                            [3] = new TRVertex
                                            {
                                                Z = -1024,
                                            },
                                        }
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 57856 - 1024,
                                    Y = -8192,
                                    Z = 72192,
                                    Room = 44,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[47].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 33 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Move faces to fit the original lever layout.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 33,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 48,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = -1024,
                                                Z = -1024,
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = -2048,
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = -2048,
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = -1024,
                                                Z = -1024,
                                            },
                                        }
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 57856 - 2048,
                                    Y = -8192,
                                    Z = 72192,
                                    Room = 44,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[47].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 18 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Move faces to fit the original lever layout.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 18,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 48,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = -1024,
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = -1024,
                                            },
                                        }
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 57856 - 2048,
                                    Y = -8192,
                                    Z = 72192 + 1024,
                                    Room = 44,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[47].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 21 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Move faces to fit the original lever layout.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 21,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 48,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = 2 * 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = 2 * 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                            },
                                        }
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 57856 - 2048,
                                    Y = -8192,
                                    Z = 72192 + 2 * 1024,
                                    Room = 44,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[47].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 24 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Move faces to fit the original lever layout.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 24,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 48,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = 1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = 3 * 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = 3 * 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = 1024
                                            },
                                        }
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 57856 - 2048,
                                    Y = -8192,
                                    Z = 72192 + 2 * 1024,
                                    Room = 44
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[47].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 25 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Move faces to fit the original lever layout.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 25,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 48,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = 2 * 1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = -2 * 1024,
                                                Z = 3 * 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = -2 * 1024,
                                                Z = 3 * 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = -3 * 1024,
                                                Z = 2 * 1024
                                            },
                                        }
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 57856 - 1024,
                                    Y = -8192,
                                    Z = 72192 + 2 * 1024,
                                    Room = 44
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[47].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 38 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Move faces to fit the original lever layout.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 38,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 48,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = -2 * 1024,
                                                Z = 2 * 1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = -1 * 1024,
                                                Z = 3 * 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = -1 * 1024,
                                                Z = 3 * 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = -2 * 1024,
                                                Z = 2 * 1024
                                            },
                                        }
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = -8192,
                                    Z = 72192 + 2 * 1024,
                                    Room = 44
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[47].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 46 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Move faces to fit the original lever layout.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 46,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 48,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = -1 * 1024,
                                                Z = 2 * 1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = 0 * 1024,
                                                Z = 3 * 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 0 * 1024,
                                                Z = 3 * 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = -1 * 1024,
                                                Z = 2 * 1024
                                            },
                                        }
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 57856 + 1024,
                                    Y = -8192,
                                    Z = 72192 + 2 * 1024,
                                    Room = 44
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[47].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 53 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Move faces to fit the original lever layout.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 53,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 48,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = 0 * 1024,
                                                Z = 2 * 1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Z = 3 * 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Z = 3 * 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = 0 * 1024,
                                                Z = 2 * 1024
                                            },
                                        }
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 57856 + 1024,
                                    Y = -8192,
                                    Z = 72192 + 2 * 1024,
                                    Room = 44,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[47].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 52 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Move faces to fit the original lever layout.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 52,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 48,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Z = 1 * 1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = 0 * 1024,
                                                Z = 2 * 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 0 * 1024,
                                                Z = 2 * 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = 1 * 1024,
                                                Z = 1 * 1024
                                            },
                                        }
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = -8192,
                                    Z = 72192 + 1024,
                                    Room = 44,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[47].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 49 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Move faces to fit the original lever layout.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 49,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = 512,
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 44,
                                        FaceIndex = 48,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Z = 1024
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
                                                Z = 1024
                                            },
                                        }
                                    }
                                }
                            },
                        }
                    }
                }
            };

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();

            mapping.RewardEntities = new List<int> { 43, 44, 45, 46, 60, 85 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 33280,
                            Y = -2304,
                            Z = 64000
                        },
                        new Location
                        {
                            X = 32256,
                            Y = -2304,
                            Z = 64000
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door5,
                            X = 34304,
                            Y = -2304,
                            Z = 64000,
                            Angle = 16384,
                            Intensity = 6400,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 37423,
                            Y = -3385,
                            Z = 62658,
                            Room = 40
                        }
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 23,
                            LinkedLocation = new EMLocation
                            {
                                X = 34304,
                                Y = -2304,
                                Z = 64000,
                                Room = 40
                            },
                            NewLocation = new EMLocation
                            {
                                X = 30720,
                                Y = -2304,
                                Z = 62464,
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [40] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 33280,
                                            Y = -2304,
                                            Z = 64000,
                                            Room = 40
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [40] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 34304,
                                            Y = -2304,
                                            Z = 64000,
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
                                    BaseRoom = 40,
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
                                            Y = -3328,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -3328,
                                            Z = 3072
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -2304,
                                            Z = 3072
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -2304,
                                            Z = 2048
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 40,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3072,
                                            Y = -3328,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 3072,
                                            Y = -3328,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3072,
                                            Y = -2304,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3072,
                                            Y = -2304,
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
                                    RoomNumber = 40,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 6,
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
                                }
                            },
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = -1,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[]{ 5 },
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
                                    RoomNumber = -1,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[]{ 1,6 },
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
                                [74] = new EMGeometryMap
                                {
                                    [40] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 6 }
                                    }
                                },
                                [72] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 1, 2, 3, 4, 6, 7, 8 }
                                    }
                                },
                                [4] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 5 }
                                    }
                                },
                                [2] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0 }
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

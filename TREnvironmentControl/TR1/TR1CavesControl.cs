using Newtonsoft.Json;
using System.Collections.Generic;
using TREnvironmentEditor;
using TREnvironmentEditor.Helpers;
using TREnvironmentEditor.Model;
using TREnvironmentEditor.Model.Types;
using TRFDControl;
using TRLevelReader.Helpers;
using TRLevelReader.Model;
using TRLevelReader.Model.Enums;
using TRRandomizerCore.Helpers;
using TRRandomizerCore.Secrets;

namespace TREnvironmentControl
{
    public class TR1CavesControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.CAVES;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);
            TRLevel level2 = GetTR1Level(TRLevelNames.VILCABAMBA);
            TRLevel level3b = GetTR1Level(TRLevelNames.QUALOPEC);
            TRLevel level4 = GetTR1Level(TRLevelNames.FOLLY);

            mapping.All = new EMEditorSet
            {
            };

            mapping.NonPurist = new EMEditorSet
            {
                new EMAddFaceFunction
                {
                    Comments = "Patch two holes in the roof in room 10 and another in room 1.",
                    EMType = EMType.AddFace,
                    Triangles = new Dictionary<short, List<TRFace3>>
                    {
                        [10] = new List<TRFace3>
                        {
                            new TRFace3
                            {
                                Texture = 72,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[10].RoomData.Rectangles[89].Vertices[1],
                                    level.Rooms[10].RoomData.Triangles[11].Vertices[0],
                                    level.Rooms[10].RoomData.Rectangles[89].Vertices[2]
                                }
                            },
                            new TRFace3
                            {
                                Texture = 72,
                                Vertices = new ushort[]
                                {


                                    level.Rooms[10].RoomData.Rectangles[279].Vertices[1],
                                    level.Rooms[10].RoomData.Rectangles[277].Vertices[3],
                                    level.Rooms[10].RoomData.Rectangles[299].Vertices[0],
                                }
                            }
                        },
                        [30] = new List<TRFace3>
                        {
                            new TRFace3
                            {
                                Texture = 72,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[30].RoomData.Rectangles[150].Vertices[3],
                                    level.Rooms[30].RoomData.Rectangles[175].Vertices[2],
                                    level.Rooms[30].RoomData.Rectangles[150].Vertices[0],
                                }
                            },
                            new TRFace3
                            {
                                Texture = 72,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[30].RoomData.Triangles[21].Vertices[0],
                                    level.Rooms[30].RoomData.Rectangles[176].Vertices[3],
                                    level.Rooms[30].RoomData.Rectangles[176].Vertices[2],
                                }
                            }
                        }
                    },
                    Quads = new Dictionary<short, List<TRFace4>>
                    {
                        [1] = new List<TRFace4>
                        {
                            new TRFace4
                            {
                                Texture = level.Rooms[1].RoomData.Rectangles[101].Texture,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[1].RoomData.Rectangles[102].Vertices[0],
                                    level.Rooms[1].RoomData.Rectangles[73].Vertices[1],
                                    level.Rooms[1].RoomData.Rectangles[73].Vertices[0],
                                    level.Rooms[1].RoomData.Rectangles[75].Vertices[0],
                                }
                            }
                        }
                    }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Patch a hole in the wall in room 14.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            FaceIndex = 108,
                            RoomNumber = 14,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = 256
                                },
                                [1] = new TRVertex
                                {
                                    Y = -512
                                }
                            }
                        }
                    }
                },
                new EMTriggerFunction
                {
                    Comments = "Reopen the doors in room 26 to make a return path possible.",
                    EMType = EMType.Trigger,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 26112,
                            Y = 6656,
                            Z = 88576,
                            Room = 31
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
                                Parameter = 43
                            },
                            new EMTriggerAction
                            {
                                Parameter = 44
                            }
                        }
                    }
                },
                new EMRefaceFunction
                {
                    Comments = "Refacing for above and to fix a quad in room 6.",
                    EMType = EMType.Reface,
                    TextureMap = new EMTextureMap
                    {
                        [82] = new EMGeometryMap
                        {
                            [31] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 8 }
                            }
                        },
                        [27] = new EMGeometryMap
                        {
                            [6] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 179 }
                            }
                        },
                    }
                }
            };

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the spikes model is available.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.TeethSpikes,
                                TexturedFace3 = 33,
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some spikes.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.TeethSpikes,
                        Intensity = level3b.Entities[2].Intensity,
                        Location = new EMLocation
                        {
                            X = 48640,
                            Y = 7680,
                            Z = 57856,
                            Room = 10,
                        }
                    },
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the spikes model is available.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.TeethSpikes,
                                TexturedFace3 = 33,
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some spikes.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.TeethSpikes,
                        Intensity = level3b.Entities[2].Intensity,
                        Location = new EMLocation
                        {
                            X = 44544,
                            Y = 4352,
                            Z = 62976,
                            Room = 30,
                        }
                    },
                },
                new EMEditorSet
                {
                    new EMAddEntityFunction
                    {
                        Comments = "Add a blade before the wolf pit.",
                        EMType = EMType.AddEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        TypeID = (short)TREntities.SwingingBlade,
                        Intensity = level2.Entities[56].Intensity,
                        Location = new EMLocation
                        {
                            X = 8704,
                            Y = 5888,
                            Z = 82432,
                            Room = 26,
                        }
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 8704,
                                Y = 5888,
                                Z = 81408,
                                Room = 26,
                            }
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
                    new EMAddEntityFunction
                    {
                        Comments = "Add a blade in room 30.",
                        EMType = EMType.AddEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        TypeID = (short)TREntities.SwingingBlade,
                        Intensity = level2.Entities[56].Intensity,
                        Location = new EMLocation
                        {
                            X = 39424,
                            Y = 4352,
                            Z = 62976 + 512,
                            Room = 30,
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
                                X = 36352,
                                Y = 4608,
                                Z = 69120,
                                Room = 32,
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
                        Comments = "Ensure the boulder model is available.",
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EMType = EMType.ImportNonGraphicsModel,
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.RollingBall,
                                TexturedFace3 = 33,
                                TexturedFace4 = 1
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add a boulder.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level3b.Entities[45].Intensity,
                        Location = new EMLocation
                        {
                            X = 49664,
                            Y = 4608 - 1024 - 256,
                            Z = 68096,
                            Room = 33,
                            Angle = -32768
                        }
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        LocationExpander = new EMLocationExpander
                        {
                            Location = new EMLocation
                            {
                                X = 47616,
                                Y = 4608,
                                Z = 66048,
                                Room = 33,
                            },
                            ExpandX = 4,
                            ExpandZ = 1
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
                        Comments = "Ensure the boulder model is available.",
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EMType = EMType.ImportNonGraphicsModel,
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.RollingBall,
                                TexturedFace3 = 33,
                                TexturedFace4 = 1
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some boulders.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level3b.Entities[45].Intensity,
                        Location = new EMLocation
                        {
                            X = 34304,
                            Y = 3840 - 1024 - 1024,
                            Z = 85504,
                            Room = 34
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level3b.Entities[45].Intensity,
                        Location = new EMLocation
                        {
                            X = 34304 - 1024,
                            Y = 3840 - 1024 - 1024,
                            Z = 85504,
                            Room = 34
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 33280,
                                Y = 4608,
                                Z = 88576,
                                Room = 34,
                            },
                            new EMLocation
                            {
                                X = 33280 + 1024,
                                Y = 4608,
                                Z = 88576,
                                Room = 34,
                            },
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
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
                    }
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the boulder model is available.",
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EMType = EMType.ImportNonGraphicsModel,
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.RollingBall,
                                TexturedFace3 = 33,
                                TexturedFace4 = 1
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some boulders.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level3b.Entities[45].Intensity,
                        Location = new EMLocation
                        {
                            X = 77312,
                            Y =  -4608+512,
                            Z = 60928,
                            Room = 1,
                            Angle = -32768
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level3b.Entities[45].Intensity,
                        Location = new EMLocation
                        {
                            X = 77312 + 1024,
                            Y =  -4608+512,
                            Z = 60928,
                            Room = 1,
                            Angle = -32768
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level3b.Entities[45].Intensity,
                        Location = new EMLocation
                        {
                            X = 77312 + 2*1024,
                            Y =  -4608+512,
                            Z = 60928,
                            Room = 1,
                            Angle = -32768
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        ExpandedLocations = new EMLocationExpander
                        {
                            Location = new EMLocation
                            {
                                X = 74240,
                                Z = 57856,
                                Room = 1
                            },
                            ExpandX = 7,
                            ExpandZ = 1
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
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
                    }
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the clang-clang model is available.",
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EMType = EMType.ImportNonGraphicsModel,
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.SlammingDoor,
                                TexturedFace4 = 47,
                                TexturedFace3 = 137
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some clang-clang doors.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = level3b.Entities[32].Intensity,
                        Location = new EMLocation
                        {
                            X = 50688,
                            Y = 4608,
                            Z = 77312 - 512,
                            Room = 33,
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 49664,
                            Y = 4608,
                            Z = 76288,
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
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EMType = EMType.ImportNonGraphicsModel,
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.SlammingDoor,
                                TexturedFace4 = 47,
                                TexturedFace3 = 137
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some clang-clang doors.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = level3b.Entities[32].Intensity,
                        Location = new EMLocation
                        {
                            X = 14848,
                            Y = 7424 - 256,
                            Z = 96768 - 512 - 1024,
                            Room = 37,
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 14848,
                            Y = 7680,
                            Z = 97792,
                            Room = 37
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
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EMType = EMType.ImportNonGraphicsModel,
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.SlammingDoor,
                                TexturedFace4 = 47,
                                TexturedFace3 = 137
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some clang-clang doors.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = level3b.Entities[32].Intensity,
                        Location = new EMLocation
                        {
                            X = 32256 - 512,
                            Y = 4352,
                            Z = 47616,
                            Room = 12,
                            Angle = 16384
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 32256 - 1024,
                            Y = 4352,
                            Z = 47616,
                            Room = 12,
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
                        Comments = "Ensure the trapdoor and Thor's hammer models are available.",
                        Tags = new List<EMTag>
                        {
                            EMTag.PuzzleRoom
                        },
                        EMType = EMType.ImportNonGraphicsModel,
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.ThorHammerHandle,
                                TextureMap = new Dictionary<ushort, ushort>
                                {
                                    [750] = 176, // Top of handle
                                    [751] = 176, // Base
                                    [752] = 202, // Centre decoration
                                    [753] = 202, // Centre decoration
                                }
                            },
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.ThorHammerBlock,
                                TexturedFace4 = 44
                            },
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.Trapdoor1,
                                TexturedFace4 = 1
                            }
                        }
                    },
                    new EMConvertEntityFunction
                    {
                        Comments = "Convert the collapsible tiles in room 35 into trapdoors and move them slightly.",
                        EMType = EMType.ConvertEntity,
                        EntityIndex = 50,
                        NewEntityType = (short)TREntities.Trapdoor1
                    },
                    new EMConvertEntityFunction
                    {
                        EMType = EMType.ConvertEntity,
                        EntityIndex = 51,
                        NewEntityType = (short)TREntities.Trapdoor1
                    },
                    new EMMoveEntityFunction
                    {
                        EMType = EMType.MoveEntity,
                        EntityIndex = 50,
                        TargetLocation = new EMLocation
                        {
                            X = 36352,
                            Y = 2560 - 512,
                            Z = 75264 - 1024,
                            Room = 32,
                        }
                    },
                    new EMMoveEntityFunction
                    {
                        EMType = EMType.MoveEntity,
                        EntityIndex = 51,
                        TargetLocation = new EMLocation
                        {
                            X = 36352,
                            Y = 2560 - 512,
                            Z = 75264,
                            Room = 32,
                            Angle = -32768
                        }
                    },
                    new EMConvertTriggerFunction
                    {
                        EMType = EMType.ConvertTrigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 36352,
                                Y = 2560 - 512,
                                Z = 75264 - 1024,
                                Room = 32
                            },
                            new EMLocation
                            {
                                X = 36352,
                                Y = 2560 - 512,
                                Z = 75264,
                                Room = 32
                            }
                        },
                        TrigType = FDTrigType.Dummy
                    },
                    new EMCreateRoomFunction
                    {
                        Comments = "Thor's hammer needs its own room.",
                        EMType = EMType.CreateRoom,
                        Height = 24,
                        Width = 5,
                        Depth = 9,
                        Textures = new EMTextureGroup
                        {
                            Floor = 1,
                            Ceiling = 1,
                            Wall4 = 14,
                            Wall2 = 43,
                            WallAlignment = Direction.Down
                        },
                        AmbientLighting = level.Rooms[11].AmbientIntensity,
                        DefaultVertex = new EMRoomVertex
                        {
                            Lighting = level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[16].Vertices[2]].Lighting
                        },
                        Lights = new EMRoomLight[]
                        {
                            new EMRoomLight
                            {
                                X = 2 * 1024 + 512,
                                Y = -512,
                                Z = 7 * 1024 + 512,
                                Intensity1 = 3100,
                                Fade1 = 2048,
                            },
                        },
                        LinkedLocation = new EMLocation
                        {
                            X = 38400,
                            Y = 1536,
                            Z = 74240,
                            Room = 35
                        },
                        Location = new EMLocation
                        {
                            X = 37888,
                            Y = 1536,
                            Z = 73728 - 4096 - 4096 - 1024
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
                                BaseRoom = 35,
                                AdjoiningRoom = -1,
                                Normal = new TRVertex
                                {
                                    X = -1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = 8 * 1024,
                                        Y = 1536 - 1024-512,
                                        Z = 3 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 8 * 1024,
                                        Y = 1536 - 1024-512,
                                        Z = 2 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 8 * 1024,
                                        Y = 1536,
                                        Z = 2 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 8 * 1024,
                                        Y = 1536,
                                        Z = 3 * 1024
                                    }
                                }
                            },
                            new EMVisibilityPortal
                            {
                                BaseRoom = -1,
                                AdjoiningRoom = 35,
                                Normal = new TRVertex
                                {
                                    X = 1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = 1536 - 1024-512,
                                        Z = 7 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = 1536 - 1024-512,
                                        Z = 8 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = 1536,
                                        Z = 8 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = 1536,
                                        Z = 7 * 1024
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
                            [35] = new Dictionary<short, EMLocation[]>
                            {
                                [-1] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 38400 + 1024,
                                        Y = 1536,
                                        Z = 72192,
                                        Room = 35
                                    },
                                }
                            },
                            [-1] = new Dictionary<short, EMLocation[]>
                            {
                                [35] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 38400,
                                        Y = 1536,
                                        Z = 72192,
                                        Room = 35
                                    },
                                },
                            },
                        }
                    },
                    new EMModifyFaceFunction
                    {
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                FaceIndex = 57,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = -1,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -512
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
                            [43] = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 57 }
                                }
                            },
                            [163] = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 84 }
                                }
                            }
                        }
                    },
                    new EMRemoveFaceFunction
                    {
                        EMType = EMType.RemoveFace,
                        GeometryMap = new EMGeometryMap
                        {
                            [35] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 169,170 }
                            },
                            [-1] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 56 }
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add the hammer.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.ThorHammerHandle,
                        Intensity = level4.Entities[63].Intensity,
                        Location = new EMLocation
                        {
                            X = 40448,
                            Y = 1536,
                            Z = 69120 - 1024,
                            Room = -1,
                        },
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 40448,
                                Y = 1536,
                                Z = 72192 - 1024,
                                Room = -1
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
                                    Parameter = -1
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
                                X = 40448,
                                Y = 1536,
                                Z = 69120 - 1024,
                                Room = -1,
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
                                    Parameter = 50
                                },
                                new EMTriggerAction
                                {
                                    Parameter = 51
                                }
                            }
                        }
                    },
                    new EMGenerateLightFunction
                    {
                        Comments = "Auto-generate vertex lighting in the new room.",
                        EMType = EMType.GenerateLight,
                        RoomIndices = new List<short> { -1, }
                    }
                },
            };

            mapping.AllWithin = new List<List<EMEditorSet>>
            {
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Leave the ending as-is.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            Comments = "Make copies of the end room - two extra to go through, one as a puzzle mirror hint.",
                            EMType = EMType.CopyRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            RoomIndex = 11,
                            NewLocation = new EMLocation
                            {
                                X = 43008 - 4096,
                                Y = 7168 + 512,
                                Z = 86016 - 1024
                            },
                        },
                        new EMCopyRoomFunction
                        {
                            Comments = "Duplicate the end room twice.",
                            EMType = EMType.CopyRoom,
                            RoomIndex = 11,
                            LinkedLocation = new EMLocation
                            {
                                X = 42496,
                                Y = 7168,
                                Z = 85504,
                                Room = 11
                            },
                            NewLocation = new EMLocation
                            {
                                X = 43008 - 2048,
                                Y = 7168 + 512,
                                Z = 86016 - 1024
                            },
                        },
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 11,
                            LinkedLocation = new EMLocation
                            {
                                X = 42496,
                                Y = 7168,
                                Z = 85504,
                                Room = 11
                            },
                            NewLocation = new EMLocation
                            {
                                X = 43008 - 2048,
                                Y = 7168 + 1024,
                                Z = 86016 + 6*1024 - 1024
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
                                    BaseRoom = 11,
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
                                            Y = 7168 - 2048,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 7168 - 2048,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 7168,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168,
                                            Z = 7 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = 11,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 7168 - 2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168 - 2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 7168,
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
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168 - 2048 + 512,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 7168 - 2048 + 512,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 7168 + 512,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168 + 512,
                                            Z = 7 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
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
                                            Y = 7168 - 2048 + 512,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168 - 2048 + 512,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168 + 512,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 7168 + 512,
                                            Z = 1 * 1024
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
                                            Y = 7680 - 2048 - 512,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7680 - 2048 - 512,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7680,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7680,
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
                                [11] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 42496,
                                            Y = 7168,
                                            Z = 85504 + 1024,
                                            Room = 11
                                        },
                                        new EMLocation
                                        {
                                            X = 42496 + 1024,
                                            Y = 7168,
                                            Z = 85504 + 1024,
                                            Room = 11
                                        }
                                    }
                                },
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [11] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 42496,
                                            Y = 7168,
                                            Z = 85504,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 42496 + 1024,
                                            Y = 7168,
                                            Z = 85504,
                                            Room = -2
                                        }
                                    },
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 42496,
                                            Y = 7680,
                                            Z = 91648 + 1024,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 42496 + 1024,
                                            Y = 7680,
                                            Z = 91648 + 1024,
                                            Room = -2
                                        },
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 42496,
                                            Y = 7680,
                                            Z = 91648,
                                            Room = -1
                                        },
                                        new EMLocation
                                        {
                                            X = 42496 + 1024,
                                            Y = 7680,
                                            Z = 91648,
                                            Room = -1
                                        },
                                    }
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add additional doors.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door1,
                            Intensity = level.Entities[12].Intensity,
                            Location = new EMLocation
                            {
                                X = 42496,
                                Y = 7168 + 512,
                                Z = 85504 + 6 * 1024,
                                Angle = level.Entities[12].Angle,
                                Room = -2
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door2,
                            Intensity = level.Entities[13].Intensity,
                            Location = new EMLocation
                            {
                                X = 42496 + 1024,
                                Y = 7168 + 512,
                                Z = 85504 + 6 * 1024,
                                Angle = level.Entities[13].Angle,
                                Room = -2
                            }
                        },
                        new EMAddFaceFunction
                        {
                            Comments = "Add fake final doors.",
                            EMType = EMType.AddFace,
                            Quads = new Dictionary<short, List<TRFace4>>
                            {
                                [-1] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 707,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[11].RoomData.Rectangles[19].Vertices[3],
                                            level.Rooms[11].RoomData.Rectangles[19].Vertices[2],
                                            level.Rooms[11].RoomData.Rectangles[16].Vertices[3],
                                            level.Rooms[11].RoomData.Rectangles[16].Vertices[2],
                                        }
                                    },
                                    new TRFace4
                                    {
                                        Texture = 707,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[11].RoomData.Rectangles[33].Vertices[3],
                                            level.Rooms[11].RoomData.Rectangles[33].Vertices[2],
                                            level.Rooms[11].RoomData.Rectangles[31].Vertices[3],
                                            level.Rooms[11].RoomData.Rectangles[31].Vertices[2],
                                        }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Modify faces in the solution room.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    FaceIndex = 34,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Z = -1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = -1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = -1024,
                                            Y = -512
                                        },
                                        [3] = new TRVertex
                                        {
                                            Z = -1024,
                                            Y = -512
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 35,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = -1024,
                                            Z = -2048
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = -2048,
                                            Z = -1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = -2048,
                                            Y = -512,
                                            Z = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = -1024,
                                            Z = -2048,
                                            Y = -512
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 39,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = -1024,
                                            Y = 512
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 512,
                                            Z = 1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            Z = 1024,
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = -1024,
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 38,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = -2048,
                                            Y = 512,
                                            Z = 1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = -1024,
                                            Y = 512,
                                            Z = 2048
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = -1024,
                                            Z = 2048,
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = -2048,
                                            Z = 1024
                                        },
                                    }
                                },
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Retexture some faces as hints and fake doors in the solution room.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [707] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 34,35,38,39 }
                                    }
                                },
                                [170] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0,7,23,31 }
                                    }
                                },
                                [44] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 4,20,25,27,10,13,29,16 }
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove faces to see the puzzle solution.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,6,9,12,15,18 }
                                },
                                [-3] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 36,37 }
                                },
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Rotate the original doors so they open inwards.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 12,
                            TargetLocation = new EMLocation
                            {
                                X = 42496 + 1024,
                                Y = 7168,
                                Z = 85504 + 1024,
                                Room = 11
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 13,
                            TargetLocation = new EMLocation
                            {
                                X = 42496 - 0,
                                Y = 7168,
                                Z = 85504 + 1024,
                                Room = 11
                            }
                        },
                        new EMAddStaticMeshFunction
                        {
                            EMType = EMType.AddStaticMesh,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 42496 - 512,
                                    Y = 7680,
                                    Z = 86528 + 1024,
                                    Room = -3,
                                    Angle = 16384
                                },
                                new EMLocation
                                {
                                    X = 42496 - 512,
                                    Y = 7680,
                                    Z = 86528 + 2048,
                                    Room = -3,
                                    Angle = -16384
                                },
                                new EMLocation
                                {
                                    X = 42496 - 512,
                                    Y = 7680,
                                    Z = 86528 + 1024 + 4096,
                                    Room = -3,
                                    Angle = 16384
                                },
                            },
                            Mesh = new TR2RoomStaticMesh
                            {
                                Intensity1 = level.Rooms[24].StaticMeshes[0].Intensity,
                                MeshID = level.Rooms[24].StaticMeshes[0].MeshID,
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments = "Move the end-level triggers.",
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 42496,
                                Y = 7168,
                                Z = 83456,
                                Room = 11
                            },
                            NewLocation = new EMLocation
                            {
                                X = 42496,
                                Y = 7168,
                                Z = 83456 + 12*1024,
                                Room = -1
                            },
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 42496 + 1024,
                                Y = 7168,
                                Z = 83456,
                                Room = 11
                            },
                            NewLocation = new EMLocation
                            {
                                X = 42496 + 1024,
                                Y = 7168,
                                Z = 83456 + 12*1024,
                                Room = -1
                            },
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger the extra doors.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 42496,
                                    Y = 7168,
                                    Z = 83456,
                                    Room = 11
                                },
                                new EMLocation
                                {
                                    X = 42496 + 1024,
                                    Y = 7168,
                                    Z = 83456,
                                    Room = 11
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 12
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = 13
                                    }
                                }
                            }
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMTriggerFunction
                            {
                                Comments = "Puzzle antipads.",
                                EMType = EMType.Trigger,
                                Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("cavesantipads1.json"))[Level],
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
                                }
                            },
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Puzzle pads.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 43520,
                                    Y = 7680,
                                    Z = 86528,
                                    Room = -2
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 1 | 1 << 1,
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
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 42496,
                                    Y = 7680,
                                    Z = 87552,
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
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 43520,
                                    Y = 7680,
                                    Z = 88576,
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
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 42496,
                                    Y = 7680,
                                    Z = 91648,
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
                                        Parameter = -2
                                    },
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
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a maze at the end of the level.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 8,
                            Width = 12,
                            Depth = 12,
                            Textures = new EMTextureGroup
                            {
                                Floor = 1,
                                Ceiling = 1,
                                Wall4 = 14,
                                Wall2 = 43,
                                WallAlignment = Direction.Down
                            },
                            AmbientLighting = level.Rooms[11].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[16].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 5 * 1024 + 512,
                                    Y = -256,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 10 * 1024 + 512,
                                    Y = -256,
                                    Z = 10 * 1024 + 512,
                                    Intensity1 = 3400,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -256,
                                    Z = 10 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -256,
                                    Z = 7 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 42496,
                                Y = 7168,
                                Z = 85504,
                                Room = 11
                            },
                            Location = new EMLocation
                            {
                                X = 43008 - 2048 - 4096,
                                Y = 7168,
                                Z = 86016 - 1024
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-2] = new List<int> { 19 },
                                [-127] = new List<int>()
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            Comments = "Final room towards Vilcabamba.",
                            EMType = EMType.CreateRoom,
                            Height = 12,
                            Width = 6,
                            Depth = 8,
                            Textures = new EMTextureGroup
                            {
                                Floor = 1,
                                Ceiling = 1,
                                Wall4 = 14,
                                Wall3 = 127,
                                Wall2 = 43,
                                Wall1 = 152,
                                WallAlignment = Direction.Down
                            },
                            AmbientLighting = level.Rooms[11].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[16].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -256 - 1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 2 * 1024,
                                    Y = -256 - 1024,
                                    Z = 6 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 2048,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 42496,
                                Y = 7168,
                                Z = 85504,
                                Room = 11
                            },
                            Location = new EMLocation
                            {
                                X = 43008 - 3 * 4096 + 2048,
                                Y = 7168 + 1024,
                                Z = 86016 + 4096 + 3072
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-4] = new List<int> { 33,34 },
                                [-3] = new List<int> { 25,26 },
                                [-2] = new List<int> { 9,10,17,18 },
                                [-1] = new List<int> { 11,19 },
                                [-127] = new List<int> { 27,28,29,30,35,36,37,38 }
                            }
                        },
                        new EMAddRoomSpriteFunction
                        {
                            Comments = "Add some decoration.",
                            EMType = EMType.AddRoomSprite,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 34249,
                                    Y = 7680,
                                    Z = 94358,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 33990,
                                    Y = 7680,
                                    Z = 94633,
                                    Room = -1
                                }
                            },
                            Texture = 150,
                            Vertex = new EMRoomVertex
                            {
                                Lighting = 2048
                            }
                        },
                        new EMAddRoomSpriteFunction
                        {
                            EMType = EMType.AddRoomSprite,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 34304,
                                    Y = 7680,
                                    Z = 94720,
                                    Room = -1
                                },
                            },
                            Texture = 149,
                            Vertex = new EMRoomVertex
                            {
                                Lighting = 2048
                            }
                        },
                        new EMAddRoomSpriteFunction
                        {
                            EMType = EMType.AddRoomSprite,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 41472,
                                    Y = 7168,
                                    Z = 92672,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 39424,
                                    Y = 7168,
                                    Z = 88576,
                                    Room = -2
                                }
                            },
                            Texture = 155,
                            Vertex = new EMRoomVertex
                            {
                                Lighting = 2048
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
                                    BaseRoom = 11,
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
                                            Y = 7168 - 2048,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 7168 - 2048,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 7168,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168,
                                            Z = 7 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = 11,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 7 * 1024,
                                            Y = 7168 - 2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 7168 - 2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 7168,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7 * 1024,
                                            Y = 7168,
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
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168 - 2048,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168 - 2048,
                                            Z = 11 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168,
                                            Z = 11 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 7168,
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
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 7168 - 2048,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 7168 - 2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 7168,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 7168,
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
                                [11] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 42496,
                                            Y = 7168,
                                            Z = 85504 + 1024,
                                            Room = 11
                                        },
                                        new EMLocation
                                        {
                                            X = 42496 + 1024,
                                            Y = 7168,
                                            Z = 85504 + 1024,
                                            Room = 11
                                        }
                                    }
                                },
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [11] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 42496,
                                            Y = 7168,
                                            Z = 85504,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 42496 + 1024,
                                            Y = 7168,
                                            Z = 85504,
                                            Room = -2
                                        }
                                    },
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 38400 - 1024,
                                            Y = 7168,
                                            Z = 94720,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 38400 - 1024,
                                            Y = 7168,
                                            Z = 94720 + 1024,
                                            Room = -2
                                        },
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 38400,
                                            Y = 7168,
                                            Z = 94720,
                                            Room = -1
                                        },
                                        new EMLocation
                                        {
                                            X = 38400,
                                            Y = 7168,
                                            Z = 94720 + 1024,
                                            Room = -1
                                        },
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [707] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 31 }
                                    },
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 36,67 }
                                    },
                                },
                                [170] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 157,163 }
                                    }
                                },
                                [82] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 269 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Adjust end faces for fake doors.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 36,67 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
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
                                }
                            },
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    FaceIndices = new int[] { 163,157 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -2,
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
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove faces for the portals.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 41,42,47,48,155,156,179,180 }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 86,87,94,95,35,66 }
                                },
                            }
                        },

                        new EMMoveEntityFunction
                        {
                            Comments = "Rotate the original doors so they open inwards.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 12,
                            TargetLocation = new EMLocation
                            {
                                X = 42496 + 1024,
                                Y = 7168,
                                Z = 85504 + 1024,
                                Room = 11
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 13,
                            TargetLocation = new EMLocation
                            {
                                X = 42496 - 0,
                                Y = 7168,
                                Z = 85504 + 1024,
                                Room = 11
                            }
                        },

                        new EMAddEntityFunction
                        {
                            Comments = "Add final doors and a lever.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door1,
                            Intensity = level.Entities[35].Intensity,
                            Location = new EMLocation
                            {
                                X = 38400,
                                Y = 7168,
                                Z = 94720,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door2,
                            Intensity = level.Entities[35].Intensity,
                            Location = new EMLocation
                            {
                                X = 38400,
                                Y = 7168,
                                Z = 94720 + 1024,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.WallSwitch,
                            Intensity = level.Entities[42].Intensity,
                            Location = new EMLocation
                            {
                                X = 45568,
                                Y = 7168,
                                Z = 90624,
                                Room = -2,
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Open the doors to Vilcabamba.",
                            EMType = EMType.Trigger,
                            EntityLocation = -1,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                SwitchOrKeyRef = -1,
                                TrigType = FDTrigType.Switch,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -3
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -2
                                    }
                                }
                            },
                            HardVariant = new EMTriggerFunction
                            {
                                Comments = "Make it a timed run in hard mode.",
                                EMType = EMType.Trigger,
                                EntityLocation = -1,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    SwitchOrKeyRef = -1,
                                    Timer = 18,
                                    TrigType = FDTrigType.Switch,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = -3
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = -2
                                        }
                                    }
                                },
                            }
                        },

                        new EMImportNonGraphicsModelFunction
                        {
                            Comments = "Ensure the moving block model is available.",
                            EMType = EMType.ImportNonGraphicsModel,
                            Data = new List<EMMeshTextureData>
                            {
                                new EMMeshTextureData
                                {
                                    ModelID = (short)TREntities.MovingBlock,
                                    TexturedFace4 = 707,
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a moving block in front of the lever for the doors.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.MovingBlock,
                            Intensity = level3b.Entities[49].Intensity,
                            Location = new EMLocation
                            {
                                X = 45568,
                                Y = 7168,
                                Z = 90624 - 1024,
                                Room = -2,
                                Angle = -32768
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Pad to move the block.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 38400,
                                    Y = 6656,
                                    Z = 92672,
                                    Room = -2
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    },
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "A couple of antipads for it too.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 42496,
                                    Y = 7168,
                                    Z = 90624,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 42496,
                                    Y = 7168,
                                    Z = 90624 - 2048,
                                    Room = -2
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
                                        Parameter = -1
                                    },
                                }
                            }
                        },

                        new EMMoveTriggerFunction
                        {
                            Comments = "Move the end-level triggers.",
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 42496,
                                Y = 7168,
                                Z = 83456,
                                Room = 11
                            },
                            NewLocation = new EMLocation
                            {
                                X = 34304,
                                Y = 8192,
                                Z = 98816,
                                Room = -1
                            },
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 42496 + 1024,
                                Y = 7168,
                                Z = 83456,
                                Room = 11
                            },
                            NewLocation = new EMLocation
                            {
                                X = 34304 + 1024,
                                Y = 8192,
                                Z = 98816,
                                Room = -1
                            },
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger the initial doors.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 42496,
                                    Y = 7168,
                                    Z = 83456,
                                    Room = 11
                                },
                                new EMLocation
                                {
                                    X = 42496 + 1024,
                                    Y = 7168,
                                    Z = 83456,
                                    Room = 11
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 12
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = 13
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
                    }
                },
            };

            EMCreateRoomFunction func = mapping.AllWithin[0][2][0] as EMCreateRoomFunction;
            foreach (EMLocation loc in JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("cavesmazewalls.json"))[Level])
            {
                int x = (loc.X - func.Location.X) / 1024;
                int z = (loc.Z - func.Location.Z) / 1024;
                func.FloorHeights[-127].Add(x * func.Depth + z);
            }

            mapping.ConditionalAllWithin = new List<EMConditionalEditorSet>
            {
            };
            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
            };
            mapping.ConditionalOneOf = new List<EMConditionalGroupedSet>
            {

            };

            mapping.OneOf = new List<EMEditorGroupedSet>
            {
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 9.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [1] = new EMGeometryMap
                                {
                                    [9] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3 }
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 49664,
                                    Y = 7680,
                                    Z = 57856,
                                    Room = 9,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 58880,
                                    Y = 6400,
                                    Z = 57856,
                                    Room = 9
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 58880,
                                    Y = 6400,
                                    Z = 57856,
                                    Room = 9,
                                    Angle = 16384
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 58880,
                                    Y = 6400,
                                    Z = 57856 - 1024,
                                    Room = 9,
                                    Angle = 16384
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 58880,
                                    Y = 6400,
                                    Z = 57856 - 1024,
                                    Room = 9,
                                    Angle = -32768
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
                                [14] = new EMGeometryMap
                                {
                                    [26] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 513 }
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 24064,
                                    Y = 6912,
                                    Z = 81408,
                                    Room = 26,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [26] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 481 }
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
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 24064 - 1024,
                                    Y = 6912,
                                    Z = 81408,
                                    Room = 26,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [26] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 453 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the new lever face.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        RoomNumber = 26,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 453 },
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
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 24064 - 2048,
                                    Y = 6912,
                                    Z = 81408,
                                    Room = 26,
                                    Angle = -32768
                                }
                            }
                        },

                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 17920,
                                    Y = 8960,
                                    Z = 81408,
                                    Room = 27,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [27] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 234 }
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
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 14848,
                                    Y = 8960,
                                    Z = 81408,
                                    Room = 27,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [27] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 173 }
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
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 14848 - 1024,
                                    Y = 8960,
                                    Z = 81408,
                                    Room = 27,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [27] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 152 }
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
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 14848 - 2048,
                                    Y = 8960,
                                    Z = 81408,
                                    Room = 27,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [27] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 116 }
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
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 14848 - 2048 - 1024,
                                    Y = 8960,
                                    Z = 81408,
                                    Room = 27,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [27] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 97 }
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
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 14848 - 2048 - 1024,
                                    Y = 8960,
                                    Z = 81408,
                                    Room = 27,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [27] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 96 }
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
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 11776,
                                    Y = 8960,
                                    Z = 86528,
                                    Room = 27
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [27] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 106 }
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
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 12800,
                                    Y = 8960,
                                    Z = 93696,
                                    Room = 27,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [27] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 146 }
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
                                EntityIndex = 42,
                                Location = new EMLocation
                                {
                                    X = 24064,
                                    Y = 6912,
                                    Z = 92672,
                                    Room = 26,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [26] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 536 }
                                        }
                                    }
                                }
                            }
                        }
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
                                [14] = new EMGeometryMap
                                {
                                    [33] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 84 }
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 52,
                                Location = new EMLocation
                                {
                                    X = 48640,
                                    Y = 4608,
                                    Z = 79360,
                                    Room = 33,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [33] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 91 }
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
                                EntityIndex = 52,
                                Location = new EMLocation
                                {
                                    X = 47616,
                                    Y = 4352,
                                    Z = 62976,
                                    Room = 33,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [33] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 52,
                                Location = new EMLocation
                                {
                                    X = 44544,
                                    Y = 7168,
                                    Z = 62976,
                                    Room = 24,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [24] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 127 }
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
                                EntityIndex = 52,
                                Location = new EMLocation
                                {
                                    X = 44544,
                                    Y = 7168,
                                    Z = 78336,
                                    Room = 24
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [82] = new EMGeometryMap
                                    {
                                        [24] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 148 }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            mapping.Mirrored = new EMEditorSet
            {
            };

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();
            
            mapping.RewardEntities = new List<int> { 48, 58, 59 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 51712,
                            Y = 5120,
                            Z = 81408
                        },
                        new Location
                        {
                            X = 50688,
                            Y = 5120,
                            Z = 81408
                        },
                        new Location
                        {
                            X = 50688,
                            Y = 5120,
                            Z = 82432
                        },
                        new Location
                        {
                            X = 51712,
                            Y = 5120,
                            Z = 82432
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door4,
                            X = 50688,
                            Y = 4608,
                            Z = 79360,
                            Angle = -32768,
                            Intensity = 6400,
                            Room = 33
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 50932,
                            Y = 3990,
                            Z = 70755,
                            Room = 33
                        }
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 36,
                            LinkedLocation = new EMLocation
                            {
                                X = 50688,
                                Y = 4608,
                                Z = 79360,
                                Room = 33
                            },
                            NewLocation = new EMLocation
                            {
                                X = 49152,
                                Y = 5120,
                                Z = 78848
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [33] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 50688,
                                            Y = 4608,
                                            Z = 80384
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [33] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 50688,
                                            Y = 4608,
                                            Z = 79360
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
                                    BaseRoom = -1,
                                    AdjoiningRoom = 33,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Z = 1 * 1024,
                                            Y = 3584
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Z = 1 * 1024,
                                            Y = 3584
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Z = 1 * 1024,
                                            Y = 4608
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Z = 1 * 1024,
                                            Y = 4608
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 33,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Z = 18 * 1024,
                                            Y = 3584
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Z = 18 * 1024,
                                            Y = 3584
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Z = 18 * 1024,
                                            Y = 4608
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Z = 18 * 1024,
                                            Y = 4608
                                        }
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
                                    FaceIndex = 0,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex { Z = -1024 },
                                        [3] = new TRVertex { Z = -1024 },
                                        [0] = new TRVertex { Y = -512 },
                                        [1] = new TRVertex { Y = -512 },
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
                                        Vertices = new ushort[]{ 23, 22, 7, 8 },
                                        Texture = 1
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [1] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3, 6, 11, 14 }
                                    }
                                },
                                [57] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0 }
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [33] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 191, 193 }
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

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
    internal class TR1ValleyControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.VALLEY;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);
            TRLevel level2 = GetTR1Level(TRLevelNames.VILCABAMBA);
            TRLevel level3b = GetTR1Level(TRLevelNames.QUALOPEC);
            TRLevel level7b = GetTR1Level(TRLevelNames.TIHOCAN);

            mapping.All = new EMEditorSet
            {
            };

            mapping.NonPurist = new EMEditorSet
            {
                new EMModifyFaceFunction
                {
                    Comments = "Patch the hole in the wall in room 27.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 27,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 135,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y =  -512
                                },
                                [3] = new TRVertex
                                {
                                    Y = 256
                                }
                            }
                        }
                    }
                },
                new EMRefaceFunction
                {
                    Comments = "Fix the out of place ToQ texture.",
                    EMType = EMType.Reface,
                    TextureMap = new EMTextureMap
                    {
                        [69] = new EMGeometryMap
                        {
                            [6] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Triangles] = new int[] { 0 }
                            }
                        }
                    }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Patch the hole in the wall in room 51.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 51,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 165,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y =  256
                                },
                                [1] = new TRVertex
                                {
                                    Y = -768
                                }
                            }
                        }
                    }
                },
                new EMAddFaceFunction
                {
                    Comments = "Add the missing underwater texture when entering the tomb and at the top of the waterfall.",
                    EMType = EMType.AddFace,
                    Quads = new Dictionary<short, List<TRFace4>>
                    {
                        [90] = new List<TRFace4>
                        {
                            new TRFace4
                            {
                                Vertices = new ushort[]
                                {
                                    level.Rooms[90].RoomData.Rectangles[50].Vertices[1],
                                    level.Rooms[90].RoomData.Rectangles[50].Vertices[0],
                                    level.Rooms[90].RoomData.Rectangles[69].Vertices[1],
                                    level.Rooms[90].RoomData.Rectangles[69].Vertices[0],
                                },
                                Texture = level.Rooms[23].RoomData.Rectangles[49].Texture
                            }
                        },
                        [26] = new List<TRFace4>
                        {
                            new TRFace4
                            {
                                Vertices = new ushort[]
                                {
                                    level.Rooms[26].RoomData.Rectangles[1].Vertices[2],
                                    level.Rooms[26].RoomData.Rectangles[1].Vertices[1],
                                    level.Rooms[26].RoomData.Rectangles[0].Vertices[1],
                                    level.Rooms[26].RoomData.Rectangles[0].Vertices[0],
                                },
                                Texture = level.Rooms[23].RoomData.Rectangles[49].Texture
                            }
                        },
                    },
                    Triangles = new Dictionary<short, List<TRFace3>>
                    {
                        [9] = new List<TRFace3>
                        {
                            new TRFace3
                            {
                                Texture = level.Rooms[9].RoomData.Triangles[0].Texture,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[9].RoomData.Rectangles[50].Vertices[3],
                                    level.Rooms[9].RoomData.Rectangles[50].Vertices[2],
                                    level.Rooms[9].RoomData.Rectangles[49].Vertices[0],
                                }
                            }
                        }
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
                                TexturedFace3 = 109,
                            },
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
                            X = 37376,
                            Y = 4864,
                            Z = 58880,
                            Room = 29,
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
                                TexturedFace3 = 109,
                            },
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
                            X = 37376,
                            Y = 2304,
                            Z = 43520,
                            Room = 30,
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
                                TexturedFace3 = 109,
                            },
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
                            X = 38400,
                            Y = 3584,
                            Z = 42496,
                            Room = 30,
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
                                TexturedFace3 = 109,
                            },
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
                            X = 38400 + 1024,
                            Y = 3584,
                            Z = 42496,
                            Room = 30,
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
                                TexturedFace3 = 109,
                            },
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
                            X = 28160,
                            Y = -2048,
                            Z = 85504,
                            Room = 7,
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
                                TexturedFace3 = 109,
                            },
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
                            X = 38400,
                            Y = -512,
                            Z = 88576,
                            Room = 5,
                        }
                    },
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the boulder model is available.",
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
                                TexturedFace3 = 109,
                                TexturedFace4 = 105,
                            },
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add a boulder.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.RollingBall).Intensity,
                        Location = new EMLocation
                        {
                            X = 36352,
                            Z = 45568,
                            Room = 27,
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
                                Y = 3072,
                                Z = 49664,
                                Room = 27
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
                                TexturedFace4 = 104,
                                TexturedFace3 = 20
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some clang-clang doors.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = level7b.Entities[32].Intensity,
                        Location = new EMLocation
                        {
                            X = 40448 - 512,
                            Y = -2048,
                            Z = 75264,
                            Room = 14,
                            Angle = 16384
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 40448 - 1024,
                            Y = -2048,
                            Z = 75264,
                            Room = 14,
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
                                TexturedFace4 = 104,
                                TexturedFace3 = 20
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some clang-clang doors.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = level7b.Entities[32].Intensity,
                        Location = new EMLocation
                        {
                            X = 34304 - 512,
                            Y = -2304,
                            Z = 85504,
                            Room = 3,
                            Angle = 16384
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 32256,
                            Y = -2048,
                            Z = 85504,
                            Room = 7,
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
                                TexturedFace4 = 104,
                                TexturedFace3 = 20
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some clang-clang doors.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = level7b.Entities[32].Intensity,
                        Location = new EMLocation
                        {
                            X = 41472 - 512,
                            Y = 6272,
                            Z = 75264,
                            Room = 50,
                            Angle = 16384
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 42496,
                            Y = 6528,
                            Z = 75264,
                            Room = 50,
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
            };
            mapping.AllWithin = new List<List<EMEditorSet>>
            {
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "No change to the level start.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a trap/puzzle area at the start.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 24,
                            Width = 3,
                            Depth = 10,
                            Textures = new EMTextureGroup
                            {
                                Floor = 8,
                                Ceiling = 3,
                                Wall4 = 3,
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
                                    X = 1 * 1024 + 512,
                                    Y = -4096 - 1024 - 512,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -1024-512-256,
                                    Z = 8 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = -256,
                                Z = 78336,
                                Room = 0
                            },
                            Location = new EMLocation
                            {
                                X = 26624 - 2048,
                                Y = -256 - 2048 - 256 - 512,
                                Z = 77824 - 4096
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-18] = new List<int> { 11 },
                                [-15] = new List<int> { 12 },
                                [-9] = new List<int> { 14 },
                                [-7] = new List<int> { 16 },
                                //[-6] = new List<int> { 44 },
                                //[-7] = new List<int> { 27 },
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                //[4] = new List<int> { 18 },
                                [7] = new List<int> { 12 },
                                [10] = new List<int> { 13 },
                                [13] = new List<int> { 14,15,16,17 },

                                [16] = new List<int> { 18 },
                            }
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            SlantType = FDSlantEntryType.CeilingSlant,
                            ZSlant = 3,
                            LocationExpander = new EMLocationExpander
                            {
                                Location = new EMLocation
                                {
                                    X = 28160 - 2048,
                                    Y = -2304,
                                    Z = 77312 - 1024,
                                    Room = -1
                                },
                                ExpandZ = 3,
                                ExpandX = 1
                            }
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            SlantType = FDSlantEntryType.FloorSlant,
                            ZSlant = -3,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 28160 - 2048,
                                    Y = -2304,
                                    Z = 77312 - 2048,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 28160 - 2048,
                                    Y = -2304,
                                    Z = 77312 - 1024,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 28160 - 2048,
                                    Y = -2304,
                                    Z = 77312 + 1024,
                                    Room = -1
                                },
                            }
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            SlantType = FDSlantEntryType.CeilingSlant,
                            XSlant = -1,
                            ZSlant = 1,
                            Location = new EMLocation
                            {
                                X = 26112,
                                Y = -3072,
                                Z = 82432,
                                Room = -1
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 5,
                            Width = 5,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 8,
                                Ceiling = 3,
                                Wall4 = 3,
                                Wall1 = 83,
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
                                    X = 1 * 1024 + 512,
                                    Y = -1024,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 3 * 1024 + 512,
                                    Y = -512,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = -256,
                                Z = 78336,
                                Room = 0
                            },
                            Location = new EMLocation
                            {
                                X = 26624 - 1024,
                                Y = -256 - 2048 - 256 - 512 - 768,
                                Z = 77824 + 3072
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-1] = new List<int> {4,7}
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 20,
                            Width = 5,
                            Depth = 6,
                            Textures = new EMTextureGroup
                            {
                                Floor = 149,
                                Ceiling = 0,
                                Wall4 = 3,
                                Wall1 = 83,
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
                                    X = 1 * 1024 + 512,
                                    Y = -2048+256,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 3 * 1024 + 512,
                                    Y = -4096-512,
                                    Z = 4 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = -256,
                                Z = 78336,
                                Room = 0
                            },
                            Location = new EMLocation
                            {
                                X = 26624 -1024,
                                Y = 2045+256-1024,
                                Z = 77824
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 8,9,10,16 },
                                [-13] = new List<int> { 22 },
                                [-4] = new List<int> { 15 },
                                [-9] = new List<int> { 19 },
                                [-2] = new List<int> { 7 },
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [10] = new List<int> { 7 },
                                [12] = new List<int> { 15 },

                                [2] = new List<int> { 14,20 },
                            }
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            SlantType = FDSlantEntryType.CeilingSlant,
                            ZSlant = -1,
                            XSlant = 1,
                            Location = new EMLocation
                            {
                                X = 27136,
                                Y = 1024,
                                Z = 79360,
                                Room = -1
                            },
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            SlantType = FDSlantEntryType.FloorSlant,
                            ZSlant = 1,
                            XSlant = -1,
                            Location = new EMLocation
                            {
                                X = 27136,
                                Y = 1024,
                                Z = 79360,
                                Room = -1
                            },
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            SlantType = FDSlantEntryType.CeilingSlant,
                            ZSlant = 2,
                            XSlant = 1,
                            Location = new EMLocation
                            {
                                X = 28160,
                                Z = 81408,
                                Room = -1
                            },
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            SlantType = FDSlantEntryType.CeilingSlant,
                            CeilingClicks = -1,
                            ZSlant = -1,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 28160,
                                    Z = 81408 - 1024,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 28160 + 1024,
                                    Z = 81408 - 1024,
                                    Room = -1
                                },
                            },
                            HardVariant = new EMSlantFunction
                            {
                                EMType = EMType.Slant,
                                SlantType = FDSlantEntryType.CeilingSlant,

                                ZSlant = 1,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 28160,
                                        Z = 81408 - 1024,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 28160 + 1024,
                                        Z = 81408 - 1024,
                                        Room = -1
                                    },
                                },
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
                                    BaseRoom = -3,
                                    AdjoiningRoom = -2,
                                    Normal = new TRVertex
                                    {
                                        X = -1,
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -4096 - 1024,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -4096 - 1024,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -4096,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -4096,
                                            Z = 9 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
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
                                            Y = -4096 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -4096 - 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -4096,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -4096,
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
                                        Y = -1,
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -3840,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -3840,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -3840,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -3840,
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
                                        Y = 1,
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -3840,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -3840,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -3840,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -3840,
                                            Z = 5 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 0,
                                    Normal = new TRVertex
                                    {
                                        Z = 1,
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -256 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -256 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -256,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 0,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = -1,
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -256 - 1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -256 - 1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -256,
                                            Z = 4 * 1024
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
                                [-3] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 27136,
                                            Y = -4096,
                                            Z = 82432,
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
                                            X = 27136 - 1024,
                                            Y = -4096,
                                            Z = 82432,
                                            Room = -3
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 29184 - 1024,
                                            Y = -2304,
                                            Z = 82432,
                                            Room = -1
                                        }
                                    },
                                    [0] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 27136,
                                            Y = -256,
                                            Z = 78336,
                                            Room = -1
                                        }
                                    },
                                },
                                [0] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 27136,
                                            Y = -256,
                                            Z = 78336 + 1024,
                                            Room = 0
                                        }
                                    },
                                },
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 29184,
                                Y = -3840,
                                Z = 82432,
                                Room = -2
                            },
                            Floor = new EMLocation
                            {
                                X = 29184,
                                Y = -3840 + 1024,
                                Z = 82432,
                                Room = -1
                            },
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [6] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 36 }
                                    }
                                },
                                [5] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 37 }
                                    }
                                },

                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Move some faces around to match the geometry.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 0,10,34 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 768
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 11,17,35 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
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
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 6 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [3] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 2 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 14,37 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = -768
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 12,36 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -768
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 29 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = -768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 21 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 32,49 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -256
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 67 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -256
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 60 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -512
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 71 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 69 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 73 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 0 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = 256
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = 512
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 6 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = 256
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 512
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 2 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [3] = new TRVertex
                                        {
                                            Y = 256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 4 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = 256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 10 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 512
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 256
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 1 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 12 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [3] = new TRVertex
                                        {
                                            Y = 256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 7 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 3 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 5 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 35 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -768
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 32 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 60 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -768
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 36 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 37 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                    }
                                },
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Specific face modifications based on default/hard mode.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 14,40 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 48,24,33 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
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
                                    FaceIndices = new int[] { 48,24 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 29 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 53 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -256
                                        },
                                    }
                                },
                            },
                            HardVariant = new EMModifyFaceFunction
                            {
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        FaceIndices = new int[] { 24,48,14,40 },
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = -1,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [2] = new TRVertex
                                            {
                                                Y = -256
                                            },
                                            [3] = new TRVertex
                                            {
                                                Y = -256
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        FaceIndices = new int[] { 29 },
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = -1,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = -256
                                            },
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        FaceIndices = new int[] { 53 },
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = -1,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [1] = new TRVertex
                                            {
                                                Y = -256
                                            },
                                        }
                                    },
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-3] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 4,13,25,50,33,15 }
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,9 }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 11,74,31 }
                                },
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments= "Additional face to be removed in default mode only.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 70 }
                                },
                            },
                            HardVariant= new EMPlaceholderFunction
                            {
                                EMType = EMType.NOOP
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Reposition Lara.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -7296 - 768,
                                Z = 77312 - 2048,
                                Room = -3
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Spin the door around so it opens properly.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 27136,
                                Y = -256,
                                Z = 78336 + 1024,
                                Room = 0
                            }
                        },
                        new EMImportNonGraphicsModelFunction
                        {
                            Comments = "Ensure the spikes models is available.",
                            EMType = EMType.ImportNonGraphicsModel,
                            Data = new List<EMMeshTextureData>
                            {
                                new EMMeshTextureData
                                {
                                    ModelID = (short)TREntities.TeethSpikes,
                                    TexturedFace3 = 109,
                                },
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
                                X = 26112,
                                Y = -3072,
                                Z = 77312,
                                Room = -3,
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.TeethSpikes,
                            Intensity = level3b.Entities[2].Intensity,
                            Location = new EMLocation
                            {
                                X = 26112,
                                Y = -3072,
                                Z = 77312 + 2048,
                                Room = -3,
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "A med in default mode.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.LargeMed_S_P,
                            Intensity = level3b.Entities[14].Intensity,
                            Location = new EMLocation
                            {
                                X = 26112,
                                Y = -3072,
                                Z = 77312 + 4096,
                                Room = -3,
                            },
                            HardVariant= new EMAddEntityFunction
                            {
                                Comments = "More spikes in hard mode.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.TeethSpikes,
                                Intensity = level3b.Entities[2].Intensity,
                                Location = new EMLocation
                                {
                                    X = 26112,
                                    Y = -3072,
                                    Z = 77312 + 4096,
                                    Room = -3,
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.TeethSpikes,
                            Intensity = level3b.Entities[2].Intensity,
                            Location = new EMLocation
                            {
                                X = 26112,
                                Y = -3072,
                                Z = 77312 + 4096 + 1024,
                                Room = -3,
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.TeethSpikes,
                            Intensity = level3b.Entities[2].Intensity,
                            Location = new EMLocation
                            {
                                X = 28160,
                                Y = 1024,
                                Z = 79360,
                                Room = -1,
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.TeethSpikes,
                            Intensity = level3b.Entities[2].Intensity,
                            Location = new EMLocation
                            {
                                X = 28160,
                                Y = 1024,
                                Z = 79360 + 1024,
                                Room = -1,
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.TeethSpikes,
                            Intensity = level3b.Entities[2].Intensity,
                            Location = new EMLocation
                            {
                                X = 28160 + 1024,
                                Y = 1024,
                                Z = 79360 + 1024,
                                Room = -1,
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.TeethSpikes,
                            Intensity = level3b.Entities[2].Intensity,
                            Location = new EMLocation
                            {
                                X = 28160 + 1024,
                                Y = 1024,
                                Z = 79360 + 2048,
                                Room = -1,
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Switch for the door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.WallSwitch,
                            Intensity = level.Entities[10].Intensity,
                            Location = new EMLocation
                            {
                                X = 28160,
                                Z = 81408,
                                Room = -1,
                                Angle = -16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = -1,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Switch,
                                SwitchOrKeyRef = -1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 1
                                    }
                                }
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments = "Potential secret location will be moved into the new room.",
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 27136,
                                Y = -256,
                                Z = 78336,
                                Room = 0
                            },
                            NewLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -3072,
                                Z = 79360,
                                Room = -3
                            }
                        },
                        new EMMovePickupFunction
                        {
                            EMType = EMType.MovePickup,
                            SectorLocations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 27136,
                                    Y = -256,
                                    Z = 78336,
                                    Room = 0
                                }
                            },
                            TargetLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -3072,
                                Z = 78978,
                                Room = -3
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
                        new EMGenerateLightFunction
                        {
                            Comments = "Auto-generate vertex lighting in the new room.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1,-2,-3 }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a block puzzle room.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 4,
                            Width = 8,
                            Depth = 7,
                            Textures = new EMTextureGroup
                            {
                                Floor = 8,
                                Ceiling = 3,
                                Wall4 = 3,
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
                                    Y = -256,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = -256,
                                Z = 78336,
                                Room = 0
                            },
                            Location = new EMLocation
                            {
                                X = 26624 - 2048,
                                Y = -256,
                                Z = 77824
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-1] = new List<int> { 29 },
                                [-127] = new List<int> { 11,16,18,32,33,36,37,39}
                            }
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            SlantType = FDSlantEntryType.FloorSlant,
                            XSlant = 1,
                            Location = new EMLocation
                            {
                                X = 29184,
                                Y = -256,
                                Z = 79360,
                                Room = -1
                            },
                        },
                        new EMVisibilityPortalFunction
                        {
                            Comments = "Add visibility portals.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 0,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -256 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -256 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -256,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 0,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = -1,
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -256 - 1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -256 - 1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -256,
                                            Z = 4 * 1024
                                        }
                                    }
                                },
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Add collisional portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [0] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 27136,
                                            Y = -256,
                                            Z = 78336,
                                            Room = -1
                                        }
                                    }
                                },
                                [0] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 27136,
                                            Y = -256,
                                            Z = 78336 + 1024,
                                            Room = 0
                                        }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Amend some faces to match the geometry.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    FaceIndex = 46,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 256
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 49,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
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
                                    FaceIndex = 53,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = 256
                                        }
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change a texture to look like the door to Vilcabamba.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [771] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 70 }
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove some faces.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 20,31 }
                                }
                            }
                        },
                        new EMImportNonGraphicsModelFunction
                        {
                            Comments = "Ensure the pushblock model is available.",
                            EMType = EMType.ImportNonGraphicsModel,
                            Data = new List<EMMeshTextureData>
                            {
                                new EMMeshTextureData
                                {
                                    ModelID = (short)TREntities.PushBlock2,
                                    TexturedFace4 = 108,
                                },
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add some pushblocks.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.PushBlock2,
                            Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.PushBlock1).Intensity,
                            Location = new EMLocation
                            {
                                X = 30208,
                                Y = -256,
                                Z = 81408,
                                Room = -1,
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.PushBlock2,
                            Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.PushBlock1).Intensity,
                            Location = new EMLocation
                            {
                                X = 28160,
                                Y = -256,
                                Z = 79360,
                                Room = -1,
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.PushBlock2,
                            Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.PushBlock1).Intensity,
                            Location = new EMLocation
                            {
                                X = 27136,
                                Y = -256,
                                Z = 83456,
                                Room = -1
                            }
                        },
                        new EMConvertEntityFunction
                        {
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 1,
                            NewEntityType = (short)TREntities.PushBlock2
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 1,
                            TargetLocation = new EMLocation
                            {
                                X = 27136,
                                Y = -256,
                                Z = 78336 + 1024,
                                Room = -1,
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Reposition Lara.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 31232,
                                Y = -256,
                                Z = 79360,
                                Room = -1
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments = "Potential secret location will be moved into the new room.",
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 27136,
                                Y = -256,
                                Z = 78336,
                                Room = 0
                            },
                            NewLocation = new EMLocation
                            {
                                X = 27136,
                                Y = -256,
                                Z = 83456,
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
                                    X = 27136,
                                    Y = -256,
                                    Z = 78336,
                                    Room = 0
                                }
                            },
                            TargetLocation = new EMLocation
                            {
                                X = 27136,
                                Y = -256,
                                Z = 83456,
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
                        new EMGenerateLightFunction
                        {
                            Comments = "Auto-generate vertex lighting in the new room.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1 }
                        }
                    }
                }
            };
            mapping.ConditionalAllWithin = new List<EMConditionalEditorSet>
            {
            };

            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #33 is in its default position. If not, move the trigger to its new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 33,
                        X = level.Entities[33].X,
                        Y = level.Entities[33].Y,
                        Z = level.Entities[33].Z,
                        Room = level.Entities[33].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = level.Entities[33].X,
                                Y = level.Entities[33].Y,
                                Z = level.Entities[33].Z,
                                Room = level.Entities[33].Room
                            },
                            EntityLocation = 33
                        },
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #40 is in its default position. If not, move the trigger to its new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 40,
                        X = level.Entities[40].X,
                        Y = level.Entities[40].Y,
                        Z = level.Entities[40].Z,
                        Room = level.Entities[40].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = level.Entities[40].X,
                                Y = level.Entities[40].Y,
                                Z = level.Entities[40].Z,
                                Room = level.Entities[40].Room
                            },
                            EntityLocation = 40
                        },
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #53 is in its default position. If not, move the trigger to its new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 53,
                        X = level.Entities[53].X,
                        Y = level.Entities[53].Y,
                        Z = level.Entities[53].Z,
                        Room = level.Entities[53].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = level.Entities[53].X,
                                Y = level.Entities[53].Y,
                                Z = level.Entities[53].Z,
                                Room = level.Entities[53].Room
                            },
                            EntityLocation = 53
                        },
                    }
                }
            };

            mapping.ConditionalOneOf = new List<EMConditionalGroupedSet>
            {
            };

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();
            TRLevel level = GetTR1Level(Level);

            TRRoom room50 = level.Rooms[50];
            mapping.RewardEntities = new List<int> { 14, 18, 19, 20, 31, 58, 59, 60, 61, 62, 63 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 44544,
                            Y = 6656,
                            Z = 79360
                        },
                        new Location
                        {
                            X = 44544 - 1024,
                            Y = 6656,
                            Z = 79360
                        },
                        new Location
                        {
                            X = 44544 - 2048,
                            Y = 6656,
                            Z = 79360
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door6,
                            X = 43520,
                            Y = 6656,
                            Z = 75264,
                            Angle = -32768,
                            Intensity = level.Entities[41].Intensity,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 38876,
                            Y = 5283,
                            Z = 75227,
                            Room = 50
                        }
                    },
                    Room = new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 4,
                            Width = 5,
                            Depth = 6,
                            Textures = new EMTextureGroup
                            {
                                Floor = 3,
                                Ceiling = 3,
                            },
                            AmbientLighting = room50.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = room50.RoomData.Vertices[room50.RoomData.Rectangles[23].Vertices[3]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 2*1024 + 512,
                                    Y = -768,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 3072,
                                    Fade1 = room50.Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 43520,
                                Y = 6656,
                                Z = 75264,
                                Room = 50
                            },
                            Location = new EMLocation
                            {
                                X = 41984 - 1024,
                                Y = 6656,
                                Z = 74752,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 7,15,19 },
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
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 6656 - 1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 6656 - 1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 6656,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 6656,
                                            Z = 4 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 50,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 6656 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 6656 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 6656,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 6656,
                                            Z = 1 * 1024
                                        }
                                    }
                                }
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
                                            X = 43520,
                                            Y = 6656,
                                            Z = 75264 + 1024,
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
                                            X = 43520,
                                            Y = 6656,
                                            Z = 75264,
                                            Room = -1
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
                                [119] = new EMGeometryMap
                                {
                                    [50] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 25 }
                                    }
                                },
                                [1] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2,14,15,19,23 }
                                    }
                                },
                                [2] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3,30,27 }
                                    }
                                },
                                [0] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 31,7,11,6 }
                                    }
                                },
                                [5] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 10,22,35 }
                                    }
                                },
                                [6] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 34 }
                                    }
                                },
                                [4] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 26 }
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
                                    FaceIndex = 25,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = 50,
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
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 16 }
                                }
                            }
                        },

                        new EMRemoveTriggerFunction
                        {
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 43520,
                                    Y = 6656,
                                    Z = 75264,
                                    Room = 50
                                }
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            EMType  = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 43520,
                                Y = 6656,
                                Z = 75264 - 1024,
                                Room = 50
                            },
                            NewLocation = new EMLocation
                            {
                                X = 43520,
                                Y = 6656,
                                Z = 75264 - 2048,
                                Room = 50
                            },
                        },
                    }
                }
            };

            WriteSecretRoomMapping(mapping);
        }
    }
}

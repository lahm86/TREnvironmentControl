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
    public class TR1SanctuaryControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.SANCTUARY;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);
            TRLevel level2 = GetTR1Level(TRLevelNames.VILCABAMBA);
            TRLevel level3b = GetTR1Level(TRLevelNames.QUALOPEC);
            TRLevel level4 = GetTR1Level(TRLevelNames.FOLLY);

            TRRoom room29 = level.Rooms[29];

            mapping.All = new EMEditorSet
            {
                new EMTriggerFunction
                {
                    Comments = "Ensure the enemies in room 15 are always triggered rather than only from the invisible platform.",
                    EMType = EMType.Trigger,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 47616,
                            Y = -5376,
                            Z = 33280,
                            Room = 14
                        }
                    },
                    Trigger = new EMTrigger
                    {
                        Mask = 31,
                        Actions = new List<EMTriggerAction>
                        {
                            new EMTriggerAction
                            {
                                Parameter = 34
                            },
                            new EMTriggerAction
                            {
                                Parameter = 35
                            }
                        }
                    }
                }
            };

            mapping.NonPurist = new EMEditorSet
            {
                new EMAddFaceFunction
                {
                    Comments = "Patch the hole in the sphinx.",
                    EMType = EMType.AddFace,
                    Triangles = new Dictionary<short, List<TRFace3>>
                    {
                        [0] = new List<TRFace3>
                        {
                            new TRFace3
                            {
                                Texture = level.Rooms[1].RoomData.Triangles[29].Texture,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[0].RoomData.Rectangles[115].Vertices[1],
                                    level.Rooms[0].RoomData.Rectangles[116].Vertices[1],
                                    level.Rooms[0].RoomData.Rectangles[116].Vertices[0],
                                }
                            }
                        }
                    }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Unstretch a face in the sphinx flipmap area.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 54,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 4,
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
                        }
                    }
                },
                new EMAddFaceFunction
                {
                    Comments = "Add triangles to patch gaps in the sphinx area.",
                    EMType = EMType.AddFace,
                    Triangles = new Dictionary<short, List<TRFace3>>
                    {
                        [53] = new List<TRFace3>
                        {
                            new TRFace3
                            {
                                Texture = level.Rooms[21].RoomData.Triangles[15].Texture,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[53].RoomData.Rectangles[48].Vertices[3],
                                    level.Rooms[53].RoomData.Rectangles[77].Vertices[2],
                                    level.Rooms[53].RoomData.Rectangles[51].Vertices[0],
                                }
                            }
                        },
                        [54] = new List<TRFace3>
                        {
                            new TRFace3
                            {
                                Texture = level.Rooms[22].RoomData.Triangles[0].Texture,
                                Vertices = new ushort[]
                                {
                                    (ushort)(level.Rooms[54].RoomData.Vertices.Length + 1),
                                    (ushort)(level.Rooms[54].RoomData.Vertices.Length),
                                    level.Rooms[54].RoomData.Rectangles[3].Vertices[1]
                                }
                            }
                        }
                    }
                },
                new EMSlantFunction
                {
                    Comments = "Amend the slant near door 27 to get rid of the shortcut.",
                    EMType = EMType.Slant,
                    Location = new EMLocation
                    {
                        X = 35328,
                        Y = -10240,
                        Z = 55808,
                        Room = 12
                    },
                    SlantType = FDSlantEntryType.FloorSlant,
                    XSlant = -3,
                },
                new EMModifyFaceFunction
                {
                    Comments = "Modify the faces to match the slant.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 12,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndices = new int[]{ 49,53},
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
                            RoomNumber = 12,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 47,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [1] = new TRVertex
                                {
                                    Y = 256
                                },
                                [2] = new TRVertex
                                {
                                    Y = 256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 3,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 41,
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
                        }
                    },
                },
                new EMMovePickupFunction
                {
                    Comments = "Any pickups on the old slope will be moved to the floor.",
                    EMType = EMType.MovePickup,
                    SectorLocations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 35328,
                            Y = -10240,
                            Z = 55808,
                            Room = 12
                        }
                    },
                    TargetLocation = new EMLocation
                    {
                        X = 34304,
                        Y = -10496,
                        Z = 55808,
                        Room = 12
                    }
                },
            };

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMSlantFunction
                    {
                        Comments = "Raise a slant slightly to allow exiting.",
                        EMType = EMType.Slant,
                        FloorClicks = -2,
                        SlantType = FDSlantEntryType.FloorSlant,
                        XSlant = 1,
                        ZSlant = 2,
                        Location = new EMLocation
                        {
                            X = 39424,
                            Y = 4096,
                            Z = 33280,
                            Room = 36
                        }
                    },
                    new EMModifyFaceFunction
                    {
                        Comments = "Face modifications for above.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                FaceIndex = 65,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 36,
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
                                        Y = -256-256
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -256-256
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 67,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 36,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        Y = -256-256
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -256-256
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 71,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 36,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -256 - 256
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 66,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 36,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        X = -1024,
                                        Y = 1792 - 256
                                    },
                                    [1] = new TRVertex
                                    {
                                        Y = 1792 + 256,
                                        Z = -1024
                                    },
                                    [2] = new TRVertex
                                    {
                                        Y = 1792 + 512,
                                    },
                                    [3] = new TRVertex
                                    {
                                        X = -1024,
                                        Y = 1792 + 256,
                                        Z = 1024
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 64,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 36,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        X = -1024,
                                        Y = 1792 + 256
                                    },
                                    [1] = new TRVertex
                                    {
                                        X = 1024,
                                        Y = 1792,

                                    },
                                    [2] = new TRVertex
                                    {
                                        X = 1024,
                                        Y = 1792 + 256,
                                        Z = 1024
                                    },
                                    [3] = new TRVertex
                                    {
                                        X = -1024,
                                        Y = 1792 + 512,
                                        Z = 1024
                                    },
                                }
                            }
                        }
                    },
                    new EMRefaceFunction
                    {
                        Comments = "Refacing for above.",
                        EMType = EMType.Reface,
                        TextureMap = new EMTextureMap
                        {
                            [51] = new EMGeometryMap
                            {
                                [36] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 64,66 }
                                }
                            }
                        }
                    },
                    new EMCopyVertexAttributesFunction
                    {
                        Comments = "Amend lighting.",
                        EMType = EMType.CopyVertexAttributes,
                        FaceMap = new Dictionary<short, Dictionary<EMTextureFaceType, Dictionary<int, int>>>
                        {
                            [36] = new Dictionary<EMTextureFaceType, Dictionary<int, int>>
                            {
                                [EMTextureFaceType.Rectangles] = new Dictionary<int, int>
                                {
                                    [65] = 64,
                                    [54] = 66
                                }
                            }
                        }
                    },
                    new EMDrainFunction
                    {
                        Comments = "Drain room 36.",
                        EMType = EMType.Drain,
                        Tags = new List<EMTag>
                        {
                            EMTag.WaterChange
                        },
                        RoomNumbers = new int[] { 36 },
                        WaterTextures = new ushort[] { 107, 108, 110, 156 }
                    }
                },
                new EMEditorSet
                {
                    new EMSlantFunction
                    {
                        Comments = "Raise a slant slightly to allow exiting.",
                        EMType = EMType.Slant,
                        FloorClicks = -3,
                        SlantType = FDSlantEntryType.FloorSlant,
                        XSlant = -1,
                        ZSlant = -2,
                        Location = new EMLocation
                        {
                            X = 30208,
                            Y = 2816,
                            Z = 36352,
                            Room = 19
                        }
                    },
                    new EMModifyFaceFunction
                    {
                        Comments = "Face modifications for above.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                FaceIndex = 76,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 19,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                    [1] = new TRVertex
                                    {
                                        Y = -512-512-256
                                    },
                                    [2] = new TRVertex
                                    {
                                        Y = -512-512-256
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 90,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 19,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [1] = new TRVertex
                                    {
                                        Y = -256-256
                                    },
                                    [2] = new TRVertex
                                    {
                                        Y = -256-256
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 78,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 19,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -512-512-256
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 77,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 19,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        Y = 2048 - 512
                                    },
                                    [1] = new TRVertex
                                    {
                                        Y = 2048 - 256 - 512,
                                    },
                                    [2] = new TRVertex
                                    {
                                        Y = 3072 - 512,
                                        Z = 1024
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = 2048,
                                        Z = 1024
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 63,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 19,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        Y = 2048 - 256 - 512,
                                    },
                                    [1] = new TRVertex
                                    {
                                        X = 1024,
                                        Y = 768,
                                        Z = -1024
                                    },
                                    [2] = new TRVertex
                                    {
                                        X = 1024,
                                        Y = 2048,
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = 2048 + 512,
                                        Z = 1024
                                    },
                                }
                            }
                        }
                    },
                    new EMRefaceFunction
                    {
                        Comments = "Refacing for above.",
                        EMType = EMType.Reface,
                        TextureMap = new EMTextureMap
                        {
                            [51] = new EMGeometryMap
                            {
                                [19] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 77,63 }
                                }
                            }
                        }
                    },
                    new EMDrainFunction
                    {
                        Comments = "Drain room 19.",
                        EMType = EMType.Drain,
                        Tags = new List<EMTag>
                        {
                            EMTag.WaterChange
                        },
                        RoomNumbers = new int[] { 19 },
                        WaterTextures = new ushort[] { 107, 108, 110, 156 }
                    }
                },
                new EMEditorSet
                {
                    new EMSlantFunction
                    {
                        Comments = "Random step in the corridor of doom.",
                        EMType = EMType.Slant,
                        SlantType = FDSlantEntryType.FloorSlant,
                        XSlant = 1,
                        FloorClicks = -1,
                        Location = new EMLocation
                        {
                            X = 26112,
                            Y = 17152,
                            Z = 49664,
                            Room = 27
                        }
                    },
                    new EMSlantFunction
                    {
                        EMType = EMType.Slant,
                        SlantType = FDSlantEntryType.FloorSlant,
                        XSlant = 1,
                        Location = new EMLocation
                        {
                            X = 26112 + 1024,
                            Y = 17152,
                            Z = 49664,
                            Room = 27
                        }
                    },
                    new EMModifyFaceFunction
                    {
                        Comments = "Face modifications for above.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                FaceIndex = 8,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 27,
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
                                    [2] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 12,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 27,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [1] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                    [2] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 15,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 27,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [3] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 11,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 27,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 14,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 27,
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
                                FaceIndex = 10,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 27,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                }
                            },
                        }
                    },
                    new EMAddFaceFunction
                    {
                        Comments = "Plug a gap.",
                        EMType = EMType.AddFace,
                        Quads = new Dictionary<short, List<TRFace4>>
                        {
                            [27] = new List<TRFace4>
                            {
                                new TRFace4
                                {
                                    Texture = 96,
                                    Vertices = new ushort[]
                                    {
                                        (ushort)(level.Rooms[27].RoomData.NumVertices + 2),
                                        (ushort)(level.Rooms[27].RoomData.NumVertices + 1),
                                        level.Rooms[27].RoomData.Rectangles[4].Vertices[0],
                                        level.Rooms[27].RoomData.Rectangles[4].Vertices[3],
                                    }
                                }
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMSlantFunction
                    {
                        Comments = "Another random step in the corridor of doom.",
                        EMType = EMType.Slant,
                        SlantType = FDSlantEntryType.FloorSlant,
                        XSlant = -1,
                        FloorClicks = -1,
                        Location = new EMLocation
                        {
                            X = 26112,
                            Y = 6656,
                            Z = 44544,
                            Room = 25
                        }
                    },
                    new EMSlantFunction
                    {
                        EMType = EMType.Slant,
                        SlantType = FDSlantEntryType.FloorSlant,
                        XSlant = -1,
                        Location = new EMLocation
                        {
                            X = 26112 - 1024,
                            Y = 6656,
                            Z = 44544,
                            Room = 25
                        }
                    },
                    new EMModifyFaceFunction
                    {
                        Comments = "Face modifications for above.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                FaceIndex = 8,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 25,
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
                                    [2] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 4,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 25,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [1] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                    [2] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 6,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 25,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [3] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 10,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 25,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 7,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 25,
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
                                FaceIndex = 11,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 25,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                }
                            },
                        }
                    },
                    new EMAddFaceFunction
                    {
                        Comments = "Plug a gap.",
                        EMType = EMType.AddFace,
                        Quads = new Dictionary<short, List<TRFace4>>
                        {
                            [25] = new List<TRFace4>
                            {
                                new TRFace4
                                {
                                    Texture = 96,
                                    Vertices = new ushort[]
                                    {
                                        (ushort)(level.Rooms[25].RoomData.NumVertices + 2),
                                        (ushort)(level.Rooms[25].RoomData.NumVertices + 1),
                                        level.Rooms[25].RoomData.Rectangles[12].Vertices[0],
                                        level.Rooms[25].RoomData.Rectangles[12].Vertices[3],
                                    }
                                }
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMSlantFunction
                    {
                        Comments = "Another random step in the corridor of doom.",
                        EMType = EMType.Slant,
                        SlantType = FDSlantEntryType.FloorSlant,
                        ZSlant = -1,
                        FloorClicks = -1,
                        Location = new EMLocation
                        {
                            X = 28160,
                            Y = 1792,
                            Z = 47616,
                            Room = 43
                        }
                    },
                    new EMSlantFunction
                    {
                        EMType = EMType.Slant,
                        SlantType = FDSlantEntryType.FloorSlant,
                        ZSlant = -1,
                        Location = new EMLocation
                        {
                            X = 28160,
                            Y = 1792,
                            Z = 47616 - 1024,
                            Room = 43
                        }
                    },
                    new EMModifyFaceFunction
                    {
                        Comments = "Face modifications for above.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                FaceIndex = 9,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 43,
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
                                        Y = -512
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 6,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 43,
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
                                FaceIndex = 17,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 43,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [3] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 18,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 43,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                }
                            },
                            new EMFaceModification
                            {
                                FaceIndex = 8,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 43,
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
                                FaceIndex = 11,
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 43,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [2] = new TRVertex
                                    {
                                        Y = -512
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -256
                                    },
                                }
                            },
                        }
                    },
                    new EMAddFaceFunction
                    {
                        Comments = "Plug a gap.",
                        EMType = EMType.AddFace,
                        Quads = new Dictionary<short, List<TRFace4>>
                        {
                            [43] = new List<TRFace4>
                            {
                                new TRFace4
                                {
                                    Texture = 96,
                                    Vertices = new ushort[]
                                    {
                                        (ushort)(level.Rooms[43].RoomData.NumVertices + 3),
                                        (ushort)(level.Rooms[43].RoomData.NumVertices + 2),
                                        level.Rooms[43].RoomData.Rectangles[12].Vertices[1],
                                        level.Rooms[43].RoomData.Rectangles[12].Vertices[0],
                                    }
                                }
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the Damocles sword model is available.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.DamoclesSword,
                                TextureMap = new Dictionary<ushort, ushort>
                                {
                                    [745] = 109, // Top of handle
                                    [746] = 109, // Top of handle
                                    [747] = 109, // Handle
                                    [748] = 109, // Handle edge
                                    [749] = 127   // Blade
                                }
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some swords.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DamoclesSword,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.DamoclesSword).Intensity,
                        Location = new EMLocation
                        {
                            X = 40448,
                            Y = -6912-2432,
                            Z = 47616,
                            Room = 1
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DamoclesSword,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.DamoclesSword).Intensity,
                        Location = new EMLocation
                        {
                            X = 40448,
                            Y = -6912-2432,
                            Z = 47616+2048,
                            Room = 1
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
                                Y = -5888,
                                Z = 48640,
                                Room = 2
                            }
                        },
                        Trigger= new EMTrigger
                        {
                            Mask = 31,
                            OneShot = true,
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
                                TexturedFace4 = 2,
                                TexturedFace3 = 14
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add falling ceiling.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.FallingCeiling1,
                        Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.FallingCeiling1).Intensity,
                        Location = new EMLocation
                        {
                            X = 26112,
                            Y = -13056-2048-256,
                            Z = 55808,
                            Room = 16,
                            Angle = -32768
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 26112,
                            Y = -13056,
                            Z = 53760,
                            Room = 16,
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 27136,
                                Y = -13312,
                                Z = 55808,
                                Room = 16
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
                                    [666] = 102,
                                    [667] = 102,
                                    [668] = 102,
                                    [669] = 680,
                                    [670] = 102,
                                    [671] = 87,
                                    [672] = 87,
                                    [673] = 87,
                                    [674] = 87,
                                    [675] = 87,
                                    [676] = 87,
                                    [677] = 87,
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
                            X = 28160,
                            Y = -1792-256,
                            Z = 34304,
                            Room = 40,
                            Angle = -32768
                        },
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        Location = new EMLocation
                        {
                            X = 28160,
                            Y = -1792,
                            Z = 41472,
                            Room= 39
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
                                    [666] = 102,
                                    [667] = 102,
                                    [668] = 102,
                                    [669] = 680,
                                    [670] = 102,
                                    [671] = 87,
                                    [672] = 87,
                                    [673] = 87,
                                    [674] = 87,
                                    [675] = 87,
                                    [676] = 87,
                                    [677] = 87,
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
                            X = 25088,
                            Y = 3072,
                            Z = 53760+1024,
                            Room= 61
                        },
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 25088,
                                Y = 3072,
                                Z = 53760,
                                Room= 61
                            }
                        },
                        Trigger = new EMTrigger
                        {
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
                                TexturedFace4 = 1,
                                TexturedFace3 = 11
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
                            X = 28160,
                            Y = 512-1024-512,
                            Z = 44544,
                            Room= 43
                        },
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 28160,
                                Y = 2304,
                                Z = 48640,
                                Room= 43
                            }
                        },
                        Trigger = new EMTrigger
                        {
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
                                TexturedFace4 = 1,
                                TexturedFace3 = 11
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
                            X = 28160,
                            Y = 16384-1024-512,
                            Z = 49664,
                            Room= 27,Angle = -16384
                        },
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 25088,
                                Y = 17664,
                                Z = 49664,
                                Room= 27
                            }
                        },
                        Trigger = new EMTrigger
                        {
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
                            EMTag.TrapChange,
                            EMTag.Hard
                        },
                        EMType = EMType.ImportNonGraphicsModel,
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.RollingBall,
                                TexturedFace4 = 1,
                                TexturedFace3 = 11
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
                            X = 18944+1024,
                            Y = 512-2048,
                            Z = 52736,
                            Room= 57,
                            Angle = 16384
                        },
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 24064-2048,
                                Y = 4608,
                                Z = 52736,
                                Room= 57
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            }
                        }
                    },
                    new EMMovePickupFunction
                    {
                        Comments = "Move any pickups in case the boulder blocks them.",
                        EMType = EMType.MovePickup,
                        SectorLocations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 27136,
                                Y = 4608,
                                Z = 52736,
                                Room = 57
                            }
                        },
                        TargetLocation = new EMLocation
                        {
                            X = 27136-1024,
                            Y = 4608,
                            Z = 52736,
                            Room = 57
                        }
                    }
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
                                TexturedFace3 = 127
                            },
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some spikes.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.TeethSpikes,
                        Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                        Location = new EMLocation
                        {
                            X = 44544,
                            Y = -9472,
                            Z = 33280,
                            Room= 15
                        },
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
                                TexturedFace3 = 156
                            },
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some spikes.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.TeethSpikes,
                        Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                        Location = new EMLocation
                        {
                            X = 45568,
                            Y = -8704,
                            Z = 54784,
                            Room= 3
                        },
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
                                TexturedFace4 = 1,
                                TexturedFace3 = 11
                            },
                        }
                    },
                    new EMConvertEntityFunction
                    {
                        Comments = "Convert the doors to Obelisk into boulders.",
                        EMType = EMType.ConvertEntity,
                        EntityIndex = 69,
                        NewEntityType = (short)TREntities.RollingBall
                    },
                    new EMConvertEntityFunction
                    {
                        EMType = EMType.ConvertEntity,
                        EntityIndex = 70,
                        NewEntityType = (short)TREntities.RollingBall
                    },
                    new EMMoveEntityFunction
                    {
                        Comments= "Reposition the first one and trigger it.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 69,
                        TargetLocation = new EMLocation
                        {
                            X = 41472,
                            Y = -4352,
                            Z = 48640,
                            Room = 2,
                            Angle = -16384
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType= EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 37376,
                                Y = -4096,
                                Z = 48640,
                                Room = 41
                            }
                        },
                        Trigger= new EMTrigger
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
                    new EMMoveEntityFunction
                    {
                        Comments= "Reposition the second one and trigger it.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 70,
                        TargetLocation = new EMLocation
                        {
                            X = 34304,
                            Y = -4096,
                            Z = 40448,
                            Room = 38,
                            Angle = -32768
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType= EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 34304,
                                Y = -2560,
                                Z = 36352,
                                Room = 37
                            }
                        },
                        Trigger= new EMTrigger
                        {
                            Mask = 31,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 70
                                }
                            }
                        }
                    },
                    new EMAddFaceFunction
                    {
                        Comments = "Fill the holes in the wall where the doors were.",
                        EMType = EMType.AddFace,
                        Quads = new Dictionary<short, List<TRFace4>>
                        {
                            [60] = new List<TRFace4>
                            {
                                new TRFace4
                                {
                                    Texture = 677,
                                    Vertices = new ushort[]
                                    {
                                        level.Rooms[60].RoomData.Rectangles[1].Vertices[2],
                                        level.Rooms[60].RoomData.Rectangles[1].Vertices[1],
                                        level.Rooms[60].RoomData.Rectangles[0].Vertices[2],
                                        level.Rooms[60].RoomData.Rectangles[0].Vertices[1],
                                    }
                                },
                                new TRFace4
                                {
                                    Texture = 681,
                                    Vertices = new ushort[]
                                    {
                                        level.Rooms[60].RoomData.Rectangles[5].Vertices[3],
                                        level.Rooms[60].RoomData.Rectangles[5].Vertices[2],
                                        level.Rooms[60].RoomData.Rectangles[4].Vertices[2],
                                        level.Rooms[60].RoomData.Rectangles[4].Vertices[1],
                                    }
                                }
                            }
                        }
                    }
                }
            };

            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #54 is in its default position. If not, move the trigger to its new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 54,
                        X = level.Entities[54].X,
                        Y = level.Entities[54].Y,
                        Z = level.Entities[54].Z,
                        Room = level.Entities[54].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = level.Entities[54].X,
                                Y = level.Entities[54].Y,
                                Z = level.Entities[54].Z,
                                Room = level.Entities[54].Room
                            },
                            EntityLocation = 54
                        },
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMModelExistsCondition
                    {
                        Comments = "If Adam or Barney is present, we have to change the scion pickup as the MiscAnim that normally ends the level will have been overwritten.",
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
                        new EMConvertSpriteSequenceFunction
                        {
                            Comments = "Convert the scion type to the one Pierre drops.",
                            EMType = EMType.ConvertSpriteSequence,
                            OldSpriteID = 143,
                            NewSpriteID = 144
                        },
                        new EMRemoveStaticMeshFunction
                        {
                            Comments = "Get rid of the pedestal.",
                            EMType = EMType.RemoveStaticMesh,
                            ClearFromRooms = new Dictionary<ushort, List<int>>
                            {
                                [13] = new List<int> { 62 }
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the scion to the ground and further up the corridor.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 73,
                            TargetLocation = new EMLocation
                            {
                                X = 39424,
                                Y = 3072,
                                Z = 59904,
                                Room = 63
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Add a level-end pickup trigger.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 39424,
                                    Y = 3072,
                                    Z = 59904,
                                    Room = 63
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pickup,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 73
                                    },
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

            mapping.AllWithin = new List<List<EMEditorSet>>
            {
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Default keyhole position.",
                            EMType = EMType.NOOP
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 34304,
                                Y = -4096,
                                Z = 40448,
                                Room = 38
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 34304,
                                Y = -4096,
                                Z = 40448,
                                Room = 38,
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 34304,
                                Y = -3584,
                                Z = 39424,
                                Room = 38,
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 34304,
                                Y = -3072,
                                Z = 38400,
                                Room = 38,
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 34304,
                                Y = -2560,
                                Z = 37376,
                                Room = 38,
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 33280,
                                Y = -1536,
                                Z = 37376,
                                Room = 38,
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 32256,
                                Y = -512,
                                Z = 37376,
                                Room = 38,
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 31232,
                                Y = 512,
                                Z = 37376,
                                Room = 38,
                                Angle = 16384
                            },
                        }
                    },
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944,
                                Y = 512,
                                Z = 53760,
                                Room = 56
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 1024,
                                Y = 512,
                                Z = 53760,
                                Room = 56
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 2 * 1024,
                                Y = 512,
                                Z = 53760,
                                Room = 56
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 3 * 1024,
                                Y = 512,
                                Z = 53760,
                                Room = 56
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 4 * 1024,
                                Y = 512,
                                Z = 53760,
                                Room = 56
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 4 * 1024,
                                Y = 512,
                                Z = 53760,
                                Room = 56,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 4 * 1024,
                                Y = 512,
                                Z = 53760 - 1 * 1024,
                                Room = 56,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 4 * 1024,
                                Y = 512,
                                Z = 53760 - 2 * 1024,
                                Room = 56,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 4 * 1024,
                                Y = 512,
                                Z = 53760 - 7 * 1024,
                                Room = 56,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 4 * 1024,
                                Y = 512,
                                Z = 53760 - 8 * 1024,
                                Room = 56,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 4 * 1024,
                                Y = 512,
                                Z = 53760 - 9 * 1024,
                                Room = 56,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 4 * 1024,
                                Y = 512,
                                Z = 53760 - 10 * 1024,
                                Room = 56,
                                Angle = -16384
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 4 * 1024,
                                Y = 512,
                                Z = 53760 - 10 * 1024,
                                Room = 56,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 3 * 1024,
                                Y = 512,
                                Z = 53760 - 10 * 1024,
                                Room = 56,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 2 * 1024,
                                Y = 512,
                                Z = 53760 - 10 * 1024,
                                Room = 56,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944 - 1 * 1024,
                                Y = 512,
                                Z = 53760 - 10 * 1024,
                                Room = 56,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944,
                                Y = 512,
                                Z = 53760 - 10 * 1024,
                                Room = 56,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential slot location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 60,
                            Location = new EMLocation
                            {
                                X = 18944,
                                Y = 512,
                                Z = 53760 - 10 * 1024,
                                Room = 56,
                                Angle = 16384
                            },
                        }
                    },
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Default underwater lever position.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential underwater lever location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 16,
                            Location = new EMLocation
                            {
                                X = 31232 + 1024,
                                Y = 23040,
                                Z = 52736,
                                Room = 4
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential underwater lever location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 16,
                            Location = new EMLocation
                            {
                                X = 31232 + 2 * 1024,
                                Y = 23040,
                                Z = 52736,
                                Room = 4
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential underwater lever location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 16,
                            Location = new EMLocation
                            {
                                X = 31232 + 2 * 1024,
                                Y = 23040,
                                Z = 52736,
                                Room = 4,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential underwater lever location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 16,
                            Location = new EMLocation
                            {
                                X = 31232 + 1 * 1024,
                                Y = 23040,
                                Z = 52736,
                                Room = 4,
                                Angle = -32768
                            },
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential underwater lever location.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 16,
                            Location = new EMLocation
                            {
                                X = 31232,
                                Y = 23040,
                                Z = 52736,
                                Room = 4,
                                Angle = -32768
                            },
                        }
                    },
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Don't make a puzzle room off the staircase of doom.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a new room off the staircase of doom.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 16,
                            Width = 7,
                            Depth = 8,
                            Textures = new EMTextureGroup
                            {
                                Floor = 102,
                                Ceiling = 98,
                                Wall4 = 96
                            },
                            AmbientLighting = room29.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = room29.RoomData.Vertices[room29.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 3584,
                                    Y = -1024,
                                    Z = 4096,
                                    Intensity1 = 4096,
                                    Fade1 = room29.Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 24064,
                                Y = 12800,
                                Z = 44544,
                                Room = 29
                            },
                            Location = new EMLocation
                            {
                                X = 17408,
                                Y = 12800,
                                Z = 43008,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-7] = new List<int> { 9,46 },
                                [-3] = new List<int> { 27,28 },
                                [-2] = new List<int> { 18,21,34,37 },
                                [-1] = new List<int> { 17,22,33,38 },
                                [-127] = new List<int> { 10,11,12,13,42,43,44,45 },
                            }
                        },
                        new EMVisibilityPortalFunction
                        {
                            Comments = "Visibility portals for the new room.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 29,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[2].Vertices[0]].Vertex,
                                        level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[2].Vertices[1]].Vertex,
                                        level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[2].Vertices[2]].Vertex,
                                        level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[2].Vertices[3]].Vertex,
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 29,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 512,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 512,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 31,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        level.Rooms[31].RoomData.Vertices[level.Rooms[31].RoomData.Rectangles[2].Vertices[0]].Vertex,
                                        level.Rooms[31].RoomData.Vertices[level.Rooms[31].RoomData.Rectangles[2].Vertices[1]].Vertex,
                                        level.Rooms[31].RoomData.Vertices[level.Rooms[31].RoomData.Rectangles[2].Vertices[2]].Vertex,
                                        level.Rooms[31].RoomData.Vertices[level.Rooms[31].RoomData.Rectangles[2].Vertices[3]].Vertex,
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 31,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 768- 1024 - 768,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 768- 1024 - 768,
                                            Z = 6 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 768,
                                            Z = 6 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 768,
                                            Z = 7 * 1024
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
                                [29] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064 - 1024,
                                            Y = 12800,
                                            Z = 44544,
                                            Room = 29
                                        }
                                    }
                                },
                                [31] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064 - 1024,
                                            Y = 11008,
                                            Z = 49664,
                                            Room = 31
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [29] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064,
                                            Y = 12800,
                                            Z = 44544,
                                            Room = -1
                                        }
                                    },
                                    [31] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064,
                                            Y = 12800,
                                            Z = 49664,
                                            Room = -1
                                        }
                                    },
                                },
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Move some faces around.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 29,
                                    FaceIndex = 2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Z = 1024,
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = 1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = 1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Z = 1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 152,
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
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 166,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = 512
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 512
                                        }
                                    }
                                },

                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change some face textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [675] = new EMGeometryMap
                                {
                                    [29] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                    }
                                }
                            }
                        },
                        new EMRemoveCollisionalPortalFunction
                        {
                            Comments = "Remove the old collisional portal.",
                            EMType = EMType.RemoveCollisionalPortal,
                            Location1 = new EMLocation
                            {
                                X = 24064,
                                Y = 12800,
                                Z = 44544 + 1024,
                                Room = 29
                            },
                            Location2 = new EMLocation
                            {
                                X = 24064,
                                Y = 12800,
                                Z = 44544,
                                Room = 30
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove some redundant faces.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 151, 164, 165 }
                                },
                                [31] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                },
                            }
                        },
                        new EMAddFaceFunction
                        {
                            Comments = "Make a new face - fake door.",
                            EMType = EMType.AddFace,
                            Quads = new Dictionary<short, List<TRFace4>>
                            {
                                [30] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 675,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[30].RoomData.Rectangles[1].Vertices[3],
                                            level.Rooms[30].RoomData.Rectangles[1].Vertices[2],
                                            level.Rooms[30].RoomData.Rectangles[0].Vertices[1],
                                            level.Rooms[30].RoomData.Rectangles[0].Vertices[0],
                                        }
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change some face textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [45] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 5 }
                                    }
                                },
                                [90] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 45,127 }
                                    }
                                },
                                [91] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 53,118 }
                                    }
                                },
                                [99] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 47,56,81,91,115,123 }
                                    }
                                },
                                [94] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 83,85 }
                                    }
                                },
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Move some faces around.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = -1,
                                    FaceIndices = new int[]{ 83,85 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 1,
                                        [1] = 2,
                                        [2] = 3,
                                        [3] = 0
                                    }
                                },
                            }
                        },
                        new EMAddStaticMeshFunction
                        {
                            Comments = "Add a coffin.",
                            EMType = EMType.AddStaticMesh,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 18944,
                                    Y = 12800,
                                    Z = 49664,
                                    Room = -1,
                                    Angle = -16384
                                }
                            },
                            Mesh = new TR2RoomStaticMesh
                            {
                                MeshID = 35,
                                Intensity1 = Array.Find(level.Rooms[61].StaticMeshes, s => s.MeshID == 35).Intensity
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a door to the new room.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door4,
                            Intensity = level.Entities[57].Intensity,
                            Location = new EMLocation
                            {
                                X = 24064 - 1024,
                                Y = 11008,
                                Z = 49664,
                                Room = -1,
                                Angle = -16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Lever to activate the door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.WallSwitch,
                            Intensity = level.Entities[21].Intensity,
                            Location = new EMLocation
                            {
                                X = 18944,
                                Y = 12800 - 7*256,
                                Z = 44544,
                                Room = -1
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Timed run to the door.",
                            EMType = EMType.Trigger,
                            EntityLocation = -1,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 10,
                                TrigType = FDTrigType.Switch,
                                SwitchOrKeyRef = -1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -2
                                    }
                                }
                            },
                            HardVariant = new EMTriggerFunction
                            {
                                Comments = "Very tight timer in hard mode.",
                                EMType = EMType.Trigger,
                                EntityLocation = -1,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    Timer = 6,
                                    TrigType = FDTrigType.Switch,
                                    SwitchOrKeyRef = -1,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = -2
                                        }
                                    }
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Keep the door open once on the other side.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 28160,
                                    Y = 9472,
                                    Z = 49664,
                                    Room = 31
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -2
                                    }
                                }
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a new room off the staircase of doom.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 16,
                            Width = 7,
                            Depth = 8,
                            Textures = new EMTextureGroup
                            {
                                Floor = 102,
                                Ceiling = 21,
                                Wall4 = 2,
                                Wall2 = 35,
                                Wall1 = 138,
                                WallAlignment = Direction.Down
                            },
                            AmbientLighting = room29.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = room29.RoomData.Vertices[room29.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 3584,
                                    Y = -1024,
                                    Z = 4096,
                                    Intensity1 = 4096,
                                    Fade1 = room29.Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 24064,
                                Y = 12800,
                                Z = 44544,
                                Room = 29
                            },
                            Location = new EMLocation
                            {
                                X = 17408,
                                Y = 12800,
                                Z = 43008,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-7] = new List<int> { 46},

                                [-1] = new List<int> { 18,21,34,37 },
                                [-3] = new List<int> { 19,20,35,36 },
                                [-127] = new List<int> { 10,11,12,13,42,43,44,45 },
                            }
                        },
                        new EMVisibilityPortalFunction
                        {
                            Comments = "Visibility portals for the new room.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 29,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[2].Vertices[0]].Vertex,
                                        level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[2].Vertices[1]].Vertex,
                                        level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[2].Vertices[2]].Vertex,
                                        level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[2].Vertices[3]].Vertex,
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 29,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 512,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 512,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 31,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        level.Rooms[31].RoomData.Vertices[level.Rooms[31].RoomData.Rectangles[2].Vertices[0]].Vertex,
                                        level.Rooms[31].RoomData.Vertices[level.Rooms[31].RoomData.Rectangles[2].Vertices[1]].Vertex,
                                        level.Rooms[31].RoomData.Vertices[level.Rooms[31].RoomData.Rectangles[2].Vertices[2]].Vertex,
                                        level.Rooms[31].RoomData.Vertices[level.Rooms[31].RoomData.Rectangles[2].Vertices[3]].Vertex,
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 31,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 768- 1024 - 768,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 768- 1024 - 768,
                                            Z = 6 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 768,
                                            Z = 6 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 12800 - 1024 - 768,
                                            Z = 7 * 1024
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
                                [29] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064 - 1024,
                                            Y = 12800,
                                            Z = 44544,
                                            Room = 29
                                        }
                                    }
                                },
                                [31] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064 - 1024,
                                            Y = 11008,
                                            Z = 49664,
                                            Room = 31
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [29] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064,
                                            Y = 12800,
                                            Z = 44544,
                                            Room = -1
                                        }
                                    },
                                    [31] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064,
                                            Y = 12800,
                                            Z = 49664,
                                            Room = -1
                                        }
                                    },
                                },
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Move some faces around.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 29,
                                    FaceIndex = 2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Z = 1024,
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = 1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = 1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Z = 1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 145,
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
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 158,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = -1024 - 256
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024 - 256
                                        }
                                    }
                                },
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change some face textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [675] = new EMGeometryMap
                                {
                                    [29] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                    }
                                },
                                [35] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 145 }
                                    }
                                },
                                [872] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 14 }
                                    }
                                },

                                [105] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 65,101 }
                                    }
                                },
                                [104] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 94,72 }
                                    }
                                },
                                [100] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 33,133 }
                                    }
                                },
                            }
                        },
                        new EMRemoveCollisionalPortalFunction
                        {
                            Comments = "Remove the old collisional portal.",
                            EMType = EMType.RemoveCollisionalPortal,
                            Location1 = new EMLocation
                            {
                                X = 24064,
                                Y = 12800,
                                Z = 44544 + 1024,
                                Room = 29
                            },
                            Location2 = new EMLocation
                            {
                                X = 24064,
                                Y = 12800,
                                Z = 44544,
                                Room = 30
                            }
                        },
                        new EMAddFaceFunction
                        {
                            Comments = "Make a new face - fake door.",
                            EMType = EMType.AddFace,
                            Quads = new Dictionary<short, List<TRFace4>>
                            {
                                [30] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 675,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[30].RoomData.Rectangles[1].Vertices[3],
                                            level.Rooms[30].RoomData.Rectangles[1].Vertices[2],
                                            level.Rooms[30].RoomData.Rectangles[0].Vertices[1],
                                            level.Rooms[30].RoomData.Rectangles[0].Vertices[0],
                                        }
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove some redundant faces.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [31] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 144,157,159 }
                                },
                            }
                        },
                        new EMAddStaticMeshFunction
                        {
                            Comments = "Add some coffins.",
                            EMType = EMType.AddStaticMesh,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 18944 + 1024,
                                    Y = 12800 - 256,
                                    Z = 49664 - 1024,
                                    Room = -1,
                                    Angle = -16384
                                },
                                new EMLocation
                                {
                                    X = 18944 + 1024,
                                    Y = 12800 - 256,
                                    Z = 49664 - 4 * 1024,
                                    Room = -1,
                                    Angle = -16384
                                },
                                new EMLocation
                                {
                                    X = 18944 + 3 * 1024,
                                    Y = 12800 - 256,
                                    Z = 49664 - 1024,
                                    Room = -1,
                                    Angle = 16384
                                },
                                new EMLocation
                                {
                                    X = 18944 + 3 * 1024,
                                    Y = 12800 - 256,
                                    Z = 49664 - 4 * 1024,
                                    Room = -1,
                                    Angle = 16384
                                }
                            },
                            Mesh = new TR2RoomStaticMesh
                            {
                                MeshID = 35,
                                Intensity1 = Array.Find(level.Rooms[61].StaticMeshes, s => s.MeshID == 35).Intensity
                            }
                        },
                        new EMAddStaticMeshFunction
                        {
                            Comments = "Add some pedestals.",
                            EMType = EMType.AddStaticMesh,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 22016,
                                    Y = 12032,
                                    Z = 47616 - 512,
                                    Room = -1,
                                    Angle = 16384
                                },
                                new EMLocation
                                {
                                    X = 22016 - 2048,
                                    Y = 12032,
                                    Z = 47616 - 512,
                                    Room = -1,
                                    Angle = -16384
                                }
                            },
                            Mesh = new TR2RoomStaticMesh
                            {
                                MeshID = 13,
                                Intensity1 = Array.Find(level.Rooms[61].StaticMeshes, s => s.MeshID == 35).Intensity
                            }
                        },
                        new EMAddRoomSpriteFunction
                        {
                            Comments = "Add some troll items.",
                            EMType = EMType.AddRoomSprite,
                            Texture = 8,
                            Vertex = new EMRoomVertex
                            {
                                Lighting = level.Entities[28].Intensity,
                            },
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 22016,
                                    Y = 12032 - 640 + 118,
                                    Z = 47616 - 512,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 22016 - 2048,
                                    Y = 12032 - 640 + 118,
                                    Z = 47616 - 512,
                                    Room = -1
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a door to the new room.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door4,
                            Intensity = level.Entities[57].Intensity,
                            Location = new EMLocation
                            {
                                X = 24064 - 1024,
                                Y = 11008,
                                Z = 49664,
                                Room = -1,
                                Angle = -16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Pushblock to activate the door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.PushBlock1,
                            Intensity = level.Entities[68].Intensity,
                            Location = new EMLocation
                            {
                                X = 18944,
                                Y = 12800,
                                Z = 44544,
                                Room = -1
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Actual medi.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.SmallMed_S_P,
                            Intensity = level.Entities[28].Intensity,
                            Location = new EMLocation
                            {
                                X = 18944,
                                Y = 12800,
                                Z = 44544,
                                Room = -1
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Heavy trigger for the pushblock.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 18944,
                                    Y = 12800,
                                    Z = 49664,
                                    Room = -1
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
                                        Parameter = -3
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a new room off the staircase of doom.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 4,
                            Width = 4,
                            Depth = 8,
                            Textures = new EMTextureGroup
                            {
                                Floor = 102,
                                Ceiling = 98,
                                Wall4 = 96
                            },
                            AmbientLighting = room29.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = room29.RoomData.Vertices[room29.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024+512,
                                    Y = -512,
                                    Z = 1024+512,
                                    Intensity1 = 2048,
                                    Fade1 = room29.Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 24064,
                                Y = 12800,
                                Z = 44544,
                                Room = 29
                            },
                            Location = new EMLocation
                            {
                                X = 17408 + 4096 + 1024,
                                Y = 12800,
                                Z = 43008 - 6 * 1024,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 18, 19, 20, 21, 22,}
                            }
                        },
                        new EMVisibilityPortalFunction
                        {
                            Comments = "Visibility portals for the new room.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 29,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[3].Vertices[0]].Vertex.X,
                                            Y = (short)(level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[3].Vertices[0]].Vertex.Y + 512),
                                            Z = level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[3].Vertices[0]].Vertex.Z,
                                        },
                                        new TRVertex
                                        {
                                            X = level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[3].Vertices[1]].Vertex.X,
                                            Y = (short)(level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[3].Vertices[1]].Vertex.Y + 512),
                                            Z = level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[3].Vertices[1]].Vertex.Z,
                                        },
                                        level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[3].Vertices[2]].Vertex,
                                        level.Rooms[29].RoomData.Vertices[level.Rooms[29].RoomData.Rectangles[3].Vertices[3]].Vertex,
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 29,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 12800 - 1024,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 12800 - 1024,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 12800,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 12800,
                                            Z = 7 * 1024
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
                                [29] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064,
                                            Y = 12800,
                                            Z = 44544 - 1024,
                                            Room = 29
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [29] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064,
                                            Y = 12800,
                                            Z = 44544,
                                            Room = -1
                                        }
                                    },
                                },
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Clang-clang a-go-go.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.SlammingDoor,
                            Intensity = level.Entities[31].Intensity,
                            Location = new EMLocation
                            {
                                X = 24064,
                                Y = 12800,
                                Z = 42496 - 1024,
                                Room = -1
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.SlammingDoor,
                            Intensity = level.Entities[31].Intensity,
                            Location = new EMLocation
                            {
                                X = 24064,
                                Y = 12800,
                                Z = 42496 - 2048,
                                Room = -1
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.SlammingDoor,
                            Intensity = level.Entities[31].Intensity,
                            Location = new EMLocation
                            {
                                X = 24064,
                                Y = 12800,
                                Z = 42496 - 3072,
                                Room = -1
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Clang-clang pads.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 12800,
                                    Z = 43520 - 1024,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 12800,
                                    Z = 43520 - 2048,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 12800,
                                    Z = 43520 - 3072,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 12800,
                                    Z = 43520 - 4096,
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
                                        Parameter = -3,
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -2,
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Switch them off.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 12800,
                                    Z = 43520,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 12800,
                                    Z = 38400,
                                    Room = -1
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
                                        Parameter = -3,
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -2,
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
                                    }
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a door to block the main corridor.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door4,
                            Intensity = level.Entities[57].Intensity,
                            Location = new EMLocation
                            {
                                X = 24064,
                                Y = 12800,
                                Z = 44544,
                                Room = 29,
                                Angle = -32768
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Lever to activate the door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.WallSwitch,
                            Intensity = level.Entities[21].Intensity,
                            Location = new EMLocation
                            {
                                X = 24064 + 1024,
                                Y = 12800,
                                Z = 38400,
                                Room = -1,
                                Angle = 16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger the door.",
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
                                        Parameter = -2
                                    }
                                }
                            },
                            HardVariant = new EMTriggerFunction
                            {
                                Comments = "Tight timer to get to the door in hard mode.",
                                EMType = EMType.Trigger,
                                EntityLocation = -1,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    Timer = 8,
                                    TrigType = FDTrigType.Switch,
                                    SwitchOrKeyRef = -1,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = -2
                                        }
                                    }
                                },
                            }
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for default mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMTriggerFunction
                            {
                                Comments = "Keep the door open once on the other side.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 24064,
                                        Y = 11008,
                                        Z = 49664,
                                        Room = 31
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = -2
                                        }
                                    }
                                }
                            },
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Add a lever texture.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [45] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 28 }
                                    }
                                },
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Make way for the portal.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 23 }
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
                                    RoomNumber = 29,
                                    FaceIndex = 3,
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
                        new EMModifyFaceFunction
                        {
                            Comments = "Remove the default lever texture in room 9.",
                            EMType = EMType.ModifyFace,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    FaceIndex = 21,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = 9,
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
                                EntityIndex = 21,
                                Location = new EMLocation
                                {
                                    X = 54784 + 1024,
                                    Y = -8704 + 256,
                                    Z = 56832,
                                    Room = 9
                                },
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Texture changes for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        FaceIndex = 20,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = 1024,
                                                Y = 256
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = 1024,
                                                Y = 256
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 1024,
                                                Y = 256
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = 1024,
                                                Y = 256
                                            }
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        FaceIndex = 45,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [1] = new TRVertex
                                            {
                                                Y = -1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                Y = -1024
                                            }
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
                                EntityIndex = 21,
                                Location = new EMLocation
                                {
                                    X = 54784 + 3 * 1024,
                                    Y = -8704 + 256,
                                    Z = 56832,
                                    Room = 9
                                },
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Texture changes for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        FaceIndex = 20,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256
                                            }
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        FaceIndex = 144,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [1] = new TRVertex
                                            {
                                                Y = -1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                Y = -1024
                                            }
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
                                EntityIndex = 21,
                                Location = new EMLocation
                                {
                                    X = 54784 + 3 * 1024,
                                    Y = -8704 + 256,
                                    Z = 56832,
                                    Room = 9,
                                    Angle = 16384
                                },
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Texture changes for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        FaceIndex = 20,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 256
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256,
                                                Z = - 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256,
                                                Z = - 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 256
                                            }
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        FaceIndex = 161,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
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
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 21,
                                Location = new EMLocation
                                {
                                    X = 54784 + 3 * 1024,
                                    Y = -8704 + 256 - 1024,
                                    Z = 56832 - 2048,
                                    Room = 9,
                                    Angle = 16384
                                },
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Texture changes for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        FaceIndex = 20,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 256 - 1024,
                                                Z = -2 * 1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256 - 1024,
                                                Z = -3 * 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256 - 1024,
                                                Z = -3 * 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 256 - 1024,
                                                Z = -2 * 1024
                                            }
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        FaceIndex = 159,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
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
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 21,
                                Location = new EMLocation
                                {
                                    X = 54784 + 3 * 1024,
                                    Y = -8704 + 256 - 1024 + 256,
                                    Z = 56832 - 2048 - 2048,
                                    Room = 9,
                                    Angle = 16384
                                },
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Texture changes for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        FaceIndex = 20,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 256 - 1024 + 256,
                                                Z = -4 * 1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256 - 1024 + 256,
                                                Z = -5 * 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256 - 1024 + 256,
                                                Z = -5 * 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 256 - 1024 + 256,
                                                Z = -4 * 1024
                                            }
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        FaceIndex = 157,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Y = -1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                Y = -1024
                                            }
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
                                EntityIndex = 21,
                                Location = new EMLocation
                                {
                                    X = 54784 + 3 * 1024,
                                    Y = -8704 + 256 - 1024 + 256,
                                    Z = 56832 - 2048 - 2048 - 4096,
                                    Room = 9,
                                    Angle = 16384
                                },
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Texture changes for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        FaceIndex = 20,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 256 - 1024 + 256,
                                                Z = -8 * 1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256 - 1024 + 256,
                                                Z = -9 * 1024
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 3 * 1024,
                                                Y = 256 - 1024 + 256,
                                                Z = -9 * 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = 4 * 1024,
                                                Y = 256 - 1024 + 256,
                                                Z = -8 * 1024
                                            }
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        FaceIndex = 153,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        RoomNumber = 9,
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

            mapping.RewardEntities = new List<int> { 10, 12 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 40448,
                            Y = 4608,
                            Z = 61952
                        },
                        new Location
                        {
                            X = 39424,
                            Y = 4608,
                            Z = 61952
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door3,
                            X = 37376,
                            Y = 4608,
                            Z = 61952,
                            Angle = -16384,
                            Intensity = 7360,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 23002,
                            Y = 2977,
                            Z = 61719,
                            Room = 61
                        }
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 63,
                            LinkedLocation = new EMLocation
                            {
                                X = 37376,
                                Y = 4608,
                                Z = 61952,
                                Room = 62
                            },
                            NewLocation = new EMLocation
                            {
                                X = 36864,
                                Y = 4608,
                                Z = 60416,
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [62] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 37376 + 1024,
                                            Y = 4608,
                                            Z = 61952,
                                            Room = 62
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [62] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 37376,
                                            Y = 4608,
                                            Z = 61952,
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
                                    BaseRoom = 62,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 11264,
                                            Y = 2560,
                                            Z = 6144
                                        },
                                        new TRVertex
                                        {
                                            X = 11264,
                                            Y = 2560,
                                            Z = 5120
                                        },
                                        new TRVertex
                                        {
                                            X = 11264,
                                            Y = 4608,
                                            Z = 5120
                                        },
                                        new TRVertex
                                        {
                                            X = 11264,
                                            Y = 4608,
                                            Z = 6144
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 62,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 2560,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 2560,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 4608,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 4608,
                                            Z = 1024
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
                                    RoomNumber = 62,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 197,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -2048
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -2048
                                        }
                                    }
                                }
                            }
                        },
                        // Make the invisible ledge trigger normal rather than on pickup
                        new EMConvertTriggerFunction
                        {
                            EMType = EMType.ConvertTrigger,
                            Location = new EMLocation
                            {
                                X = 45568,
                                Y = -8704,
                                Z = 54784,
                                Room = 3
                            },
                            TrigType = FDTrigType.Trigger
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 45568,
                                    Y = -8704,
                                    Z = 54784,
                                    Room = 3
                                }
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 10
                            }
                        }
                    }
                }
            };

            WriteSecretRoomMapping(mapping);
        }
    }
}

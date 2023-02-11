using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
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
    public class TR1MidasControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.MIDAS;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);

            mapping.NonPurist = new EMEditorSet
            {
                new EMModifyFaceFunction
                {
                    Comments = "Patch holes in the wall in rooms 13, 5 and 30.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 13,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 61,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y =  -256
                                },
                                [1] = new TRVertex
                                {
                                    Y =  -256
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
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 13,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 65,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y =  -256
                                },
                                [1] = new TRVertex
                                {
                                    Y =  -256
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
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 13,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 67,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y =  -256
                                },
                                [1] = new TRVertex
                                {
                                    Y =  -256
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
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 13,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 105,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [1] = new TRVertex
                                {
                                    Y =  -256
                                },
                                [2] = new TRVertex
                                {
                                    Y = -256
                                },
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 13,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 108,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [1] = new TRVertex
                                {
                                    Y =  -256
                                },
                                [2] = new TRVertex
                                {
                                    Y = -256
                                },
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 13,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 110,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [1] = new TRVertex
                                {
                                    Y =  -256
                                },
                                [2] = new TRVertex
                                {
                                    Y = -256
                                },
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 13,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 71,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [2] = new TRVertex
                                {
                                    Y =  -256
                                },
                                [3] = new TRVertex
                                {
                                    Y = -256
                                },
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 13,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 112,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [2] = new TRVertex
                                {
                                    Y =  -256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 13,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 68,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y =  -256
                                },
                                [1] = new TRVertex
                                {
                                    Y =  -256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 13,
                            FaceType = EMTextureFaceType.Triangles,
                            FaceIndex = 0,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    X =  -1024
                                },
                                [1] = new TRVertex
                                {
                                    X =  -2048,
                                    Y = -256,
                                    Z = 1024,
                                },
                                [2] = new TRVertex
                                {
                                    X =  -1024,
                                    Y = 256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 13,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 63,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Z =  1024
                                },
                                [1] = new TRVertex
                                {
                                    X =  -1024,
                                    Z = 2048,
                                },
                                [2] = new TRVertex
                                {
                                    X =  -1024,
                                    Y = 256,
                                    Z = 2048,
                                },
                                [3] = new TRVertex
                                {
                                    Y = -256,
                                    Z = 1024,
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 5,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 55,
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
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 30,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 171,
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
                            RoomNumber = 30,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 167,
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
                new EMAdjustVisibilityPortalFunction
                {
                    Comments = "Raise the visibility portals between 9 and 13 to match the face re-arrangement above.",
                    EMType = EMType.AdjustVisibilityPortal,
                    BaseRoom = 9,
                    AdjoiningRoom = 13,
                    VertexChanges = new Dictionary<int, TRVertex>
                    {
                        [0] = new TRVertex
                        {
                            Y = -256
                        },
                        [3] = new TRVertex
                        {
                            Y = -256
                        }
                    }
                },
                new EMAdjustVisibilityPortalFunction
                {
                    Comments = "Raise the visibility portals between 13 and 9 to match the face re-arrangement above.",
                    EMType = EMType.AdjustVisibilityPortal,
                    BaseRoom = 13,
                    AdjoiningRoom = 9,
                    VertexChanges = new Dictionary<int, TRVertex>
                    {
                        [1] = new TRVertex
                        {
                            Y = -256
                        },
                        [2] = new TRVertex
                        {
                            Y = -256
                        }
                    }
                },
                new EMAddFaceFunction
                {
                    Comments = "Add the missing faces in the pit in the OG secret garden area.",
                    EMType = EMType.AddFace,
                    Quads = new Dictionary<short, List<TRFace4>>
                    {
                        [2] = new List<TRFace4>
                        {
                            new TRFace4
                            {
                                Vertices = new ushort[]
                                {
                                    level.Rooms[2].RoomData.Rectangles[40].Vertices[0],
                                    level.Rooms[2].RoomData.Rectangles[40].Vertices[3],
                                    level.Rooms[2].RoomData.Rectangles[46].Vertices[2],
                                    level.Rooms[2].RoomData.Rectangles[46].Vertices[1],
                                },
                                Texture = level.Rooms[2].RoomData.Rectangles[49].Texture
                            },
                            new TRFace4
                            {
                                Vertices = new ushort[]
                                {
                                    level.Rooms[2].RoomData.Rectangles[48].Vertices[3],
                                    level.Rooms[2].RoomData.Rectangles[48].Vertices[2],
                                    level.Rooms[2].RoomData.Rectangles[46].Vertices[1],
                                    level.Rooms[2].RoomData.Rectangles[46].Vertices[0],
                                },
                                Texture = level.Rooms[2].RoomData.Rectangles[49].Texture
                            }
                        },
                    }
                },
                new EMClickFunction
                {
                    Comments = "Remove the shortcut to the levers.",
                    EMType = EMType.Click,
                    FloorClicks = 2,
                    Location = new EMLocation
                    {
                        X = 16896,
                        Y = -6400,
                        Z = 46592,
                        Room = 34
                    }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Move some faces to fit above.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 34,
                            FaceIndex = 0,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = 512
                                },
                                [1] = new TRVertex
                                {
                                    Y = 512
                                },
                                [2] = new TRVertex
                                {
                                    Y = 512
                                },
                                [3] = new TRVertex
                                {
                                    Y = 512
                                },
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 34,
                            FaceIndices = new int[]{26 },
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
                                },
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 34,
                            FaceIndex = 3,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = 512
                                },
                                [1] = new TRVertex
                                {
                                    Y = 512
                                },
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 34,
                            FaceIndex = 7,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = 512
                                },
                                [3] = new TRVertex
                                {
                                    Y = 512
                                },
                            }
                        }
                    },
                },
                new EMAddFaceFunction
                {
                    Comments = "Add a face to patch the gap created from above.",
                    EMType = EMType.AddFace,
                    Quads = new Dictionary<short, List<TRFace4>>
                    {
                        [34] = new List<TRFace4>
                        {
                            new TRFace4
                            {
                                Texture = 30,
                                Vertices = new ushort[] { 12,13,92,91 }
                            }
                        }
                    }
                }
            };

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMConvertTriggerFunction
                    {
                        Comments = "Make the fire room a bit more challenging.",
                        Tags = new List<EMTag>
                        {
                            EMTag.Hard,
                        },
                        EMType = EMType.ConvertTrigger,
                        Timer = 10,
                        Location = new EMLocation
                        {
                            X = 24064,
                            Y = -4352,
                            Z = 53760,
                            Room = 21
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMClickFunction
                    {
                        Comments = "A more challenging jump for the main room in hard mode.",
                        Tags = new List<EMTag>
                        {
                            EMTag.Hard,
                        },
                        EMType = EMType.Click,
                        FloorClicks = -1,
                        Location = new EMLocation
                        {
                            X = 25088,
                            Y = -6400,
                            Z = 40448,
                            Room = 29
                        }
                    },
                    new EMModifyFaceFunction
                    {
                        Comments = "Move some faces to fit above.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                RoomNumber = 29,
                                FaceIndices = new int[] { 87,89,88,91,114 },
                                FaceType = EMTextureFaceType.Rectangles,
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
                                }
                            },
                            new EMFaceModification
                            {
                                RoomNumber = 29,
                                FaceIndex = 87,
                                FaceType = EMTextureFaceType.Rectangles,
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
                        },
                    },
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        EMType = EMType.ImportNonGraphicsModel,
                        Comments = "Import the Damocles sword model.",
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
                                    [745] = 801, // Top of handle
                                    [746] = 801, // Top of handle
                                    [747] = 801, // Handle
                                    [748] = 801, // Handle edge
                                    [749] = 116   // Blade
                                }
                            }
                        }
                    },
                    new EMMoveEntityFunction
                    {
                        Comments = "Move some spikes into the main room.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 44,
                        TargetLocation = new EMLocation
                        {
                            X = 29184,
                            Y = -4352 - 2048-512,
                            Z = 42496,
                            Room = 29
                        }
                    },
                    new EMMoveEntityFunction
                    {
                        EMType = EMType.MoveEntity,
                        EntityIndex = 49,
                        TargetLocation = new EMLocation
                        {
                            X = 29184,
                            Y = -4352 - 2048-512,
                            Z = 42496-1024,
                            Room = 29
                        }
                    },
                    new EMConvertEntityFunction
                    {
                        Comments = "Convert the spikes into swords.",
                        EMType = EMType.ConvertEntity,
                        EntityIndex = 44,
                        NewEntityType = (short)TREntities.DamoclesSword
                    },
                    new EMConvertEntityFunction
                    {
                        EMType = EMType.ConvertEntity,
                        EntityIndex = 49,
                        NewEntityType = (short)TREntities.DamoclesSword
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Trigger the swords.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 29184+2048,
                                Y = -4352,
                                Z = 42496,
                                Room = 29
                            },
                            new EMLocation
                            {
                                X = 29184+2048,
                                Y = -4352,
                                Z = 42496-1024,
                                Room = 29
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            OneShot = true,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 44,
                                },
                                new EMTriggerAction
                                {
                                    Parameter = 49,
                                }
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        EMType = EMType.ImportNonGraphicsModel,
                        Comments = "Import the Damocles sword model.",
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
                                    [745] = 801, // Top of handle
                                    [746] = 801, // Top of handle
                                    [747] = 801, // Handle
                                    [748] = 801, // Handle edge
                                    [749] = 116   // Blade
                                }
                            }
                        }
                    },
                    new EMMoveEntityFunction
                    {
                        Comments = "Move some spikes into the temple room.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 45,
                        TargetLocation = new EMLocation
                        {
                            X = 82432,
                            Y = -4096 - 2048-512,
                            Z = 38400,
                            Room = 6
                        }
                    },
                    new EMMoveEntityFunction
                    {
                        EMType = EMType.MoveEntity,
                        EntityIndex = 54,
                        TargetLocation = new EMLocation
                        {
                            X = 82432,
                            Y = -4096 - 2048-512,
                            Z = 38400+1024,
                            Room = 6
                        }
                    },
                    new EMConvertEntityFunction
                    {
                        Comments = "Convert the spikes into swords.",
                        EMType = EMType.ConvertEntity,
                        EntityIndex = 45,
                        NewEntityType = (short)TREntities.DamoclesSword
                    },
                    new EMConvertEntityFunction
                    {
                        EMType = EMType.ConvertEntity,
                        EntityIndex = 54,
                        NewEntityType = (short)TREntities.DamoclesSword
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Trigger the swords.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 76288-1024,
                                Y = -3072,
                                Z = 38400,
                                Room = 5
                            },
                            new EMLocation
                            {
                                X = 76288-1024,
                                Y = -3072,
                                Z = 38400+1024,
                                Room = 5
                            },
                            new EMLocation
                            {
                                X = 76288-1024,
                                Y = -3072,
                                Z = 38400+2048,
                                Room = 5
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            OneShot = true,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 45,
                                },
                                new EMTriggerAction
                                {
                                    Parameter = 54,
                                }
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMDrainFunction
                    {
                        Comments = "Drain room 18.",
                        EMType = EMType.Drain,
                        Tags = new List<EMTag> { EMTag.WaterChange },
                        RoomNumbers = new int[] { 18 },
                        WaterTextures = new ushort[] { 71, 72, 73, 79 }
                    }
                }
            };

            mapping.AllWithin = new List<List<EMEditorSet>>
            {
                // Starting pool
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Default starting pool.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMFloorFunction
                        {
                            Comments = "Make a block to leave the starting pool.",
                            EMType = EMType.Floor,
                            Clicks = -4,
                            Location = new EMLocation
                            {
                                X = 50688,
                                Z = 39424,
                                Room = 10
                            },
                            SideTexture = 112,
                            FloorTexture = 59
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Retexture faces.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [113] = new EMGeometryMap
                                {
                                    [10] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { level.Rooms[10].RoomData.NumRectangles, level.Rooms[10].RoomData.NumRectangles + 2 }
                                    }
                                }
                            }
                        },
                        new EMRemoveTriggerFunction
                        {
                            Comments = "Remove the camera trigger after the door.",
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 50688,
                                    Z = 37376,
                                    Room = 10
                                }
                            }
                        },
                        new EMDrainFunction
                        {
                            Comments = "Drain the starting area.",
                            EMType = EMType.Drain,
                            Tags = new List<EMTag>
                            {
                                EMTag.WaterChange
                            },
                            RoomNumbers = new int[]{0,10 },
                            WaterTextures = new ushort[]{ 71, 72, 73, 79 }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMRemoveTriggerFunction
                        {
                            Comments = "Clear all the triggers from the beginning.",
                            EMType = EMType.RemoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Rooms = new List<int>{0},
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 50688,
                                    Z = 37376,
                                    Room = 10
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Retexture faces.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                // Normal wall
                                [5] = new EMGeometryMap
                                {
                                    [10] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2,3,4,5,26,27,54,55,68,69,80,81,82,83,84,85,86,87,89,79,64,65,50,51,36,37,22,23,20,21,16,17,12,13,8,9,78,88 }
                                    }
                                },
                                // Half wall
                                [30] = new EMGeometryMap
                                {
                                    [10] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 40,41,69 }
                                    }
                                },
                                // Qrt wall
                                [95] = new EMGeometryMap
                                {
                                    [10] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 69 }
                                    }
                                },
                                // Good floor
                                [842] = new EMGeometryMap
                                {
                                    [10] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 6,18,24,62,66,32,56 }
                                    }
                                },
                                // Bad floor
                                [115] = new EMGeometryMap
                                {
                                    [10] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0,10,14,28,30,34,38,42,44,46,48,52,58,60,70,72,74 }
                                    }
                                },
                                // Door pad
                                [59] = new EMGeometryMap
                                {
                                    [10] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 76 }
                                    }
                                },
                            }
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for default mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMRefaceFunction
                            {
                                Comments = "Two fewer safe tiles.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    // Bad floor
                                    [115] = new EMGeometryMap
                                    {
                                        [10] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 32,56 }
                                        }
                                    },
                                }
                            },
                        },
                        new EMKillLaraFunction
                        {
                            Comments = "Make some death tiles.",
                            EMType = EMType.KillLara,
                            Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("midaspuzzle.json"))[Level],
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for default mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMKillLaraFunction
                            {
                                Comments = "Two additional death tiles in hard mode.",
                                EMType = EMType.KillLara,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 49664,
                                        Z = 40448,
                                        Room = 10
                                    },
                                    new EMLocation
                                    {
                                        X = 51712,
                                        Z = 38400,
                                        Room = 10
                                    }
                                }
                            },
                        },
                        new EMCopyRoomFunction
                        {
                            Comments = "Make a copy of room 72.",
                            EMType = EMType.CopyRoom,
                            RoomIndex = 72,
                            NewLocation = new EMLocation
                            {
                                X = 52224 - 1024,
                                Z = 36864 - 4096,
                                Room = 10
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 52736,
                                Z = 37376,
                                Room = 10
                            },
                        },
                        new EMCopyVertexAttributesFunction
                        {
                            Comments = "Fix the lighting.",
                            EMType = EMType.CopyVertexAttributes,
                            RoomMap = new Dictionary<short, TR3RoomVertex>
                            {
                                [-1] = new TR3RoomVertex
                                {
                                    Lighting = level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[66].Vertices[0]].Lighting
                                }
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
                                    BaseRoom = 10,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[0]].Vertex,
                                        level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[1]].Vertex,
                                        level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[2]].Vertex,
                                        level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[3]].Vertex,
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 10,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[0]].Vertex.X,
                                            Y = (short)(level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[0]].Vertex.Y - 768),
                                            Z = level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[0]].Vertex.Z,
                                        },
                                        new TRVertex
                                        {
                                            X = level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[1]].Vertex.X,
                                            Y = (short)(level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[1]].Vertex.Y - 768),
                                            Z = level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[1]].Vertex.Z,
                                        },
                                        level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[2]].Vertex,
                                        level.Rooms[10].RoomData.Vertices[level.Rooms[10].RoomData.Rectangles[68].Vertices[3]].Vertex,
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 10,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -2048,
                                            Z = 4096,
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = -2048,
                                            Z = 4096,
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Z = 4096,
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Z = 4096,
                                        },
                                    }
                                }
                            }
                        },
                        new EMReplaceCollisionalPortalFunction
                        {
                            Comments = "Make the portal into the new room (replace the dummy one to room 11).",
                            EMType = EMType.ReplaceCollisionalPortal,
                            Room = 10,
                            X = 5,
                            AdjoiningRoom = -1
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Make the portal back to room 10.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [10] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 52736,
                                            Z = 36352 + 1024,
                                        }
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Retexture faces in the new room.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [5] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2,3,6,9,11,12,13, 1,5,8 }
                                    }
                                },
                                [842] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0,4,7 }
                                    }
                                },

                            }
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMRefaceFunction
                            {
                                EMType = EMType.Reface,
                                Comments = "Add a heavy trigger pad hint for the door in hard mode.",
                                TextureMap = new EMTextureMap
                                {
                                    [59] = new EMGeometryMap
                                    {
                                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 4 }
                                        }
                                    },
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
                                    FaceIndex = 69,
                                    RoomNumber = 10,
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
                                },
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove faces for the portals.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [10] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 68 }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 10 }
                                }
                            }
                        },
                        new EMConvertEntityFunction
                        {
                            Comments = "Convert the old camera target into a pushblock.",
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 25,
                            NewEntityType = (short)TREntities.PushBlock1
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move it into the new room.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 25,
                            TargetLocation = new EMLocation
                            {
                                X = 52736,
                                Z = 36352 - 2048,
                                Room = -1
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the door to block the new room.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 24,
                            TargetLocation = new EMLocation
                            {
                                X = 52736,
                                Z = 36352 + 1024,
                                Room = 10
                            }
                        },
                        new EMModifyEntityFunction
                        {
                            Comments = "Fix its lighting",
                            EMType = EMType.ModifyEntity,
                            Intensity1 = level.Entities[88].Intensity
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Pad to open the door.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 52736,
                                    Z = 41472,
                                    Room = 10
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
                                        Parameter = 24
                                    }
                                }
                            },
                            HardVariant = new EMTriggerFunction
                            {
                                Comments = "Timed run to the door in hard mode.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 52736,
                                        Z = 41472,
                                        Room = 10
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    Timer = 21,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 24
                                        }
                                    }
                                },
                            }
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMTriggerFunction
                            {
                                Comments = "The block will re-open the door in hard mode.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 52736,
                                        Z = 36352 - 1024,
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
                                            Parameter = 24
                                        }
                                    }
                                }
                            },
                        },
                        new EMMovePickupFunction
                        {
                            Comments = "Any pickups on death tiles will be moved to the new room.",
                            EMType = EMType.MovePickup,
                            SectorLocations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("midaspuzzle2.json"))[Level],
                            TargetLocation = new EMLocation
                            {
                                X = 52736,
                                Z = 36352 - 2048,
                                Room = -1
                            }
                        },
                        new EMDrainFunction
                        {
                            Comments = "Drain the starting area.",
                            EMType = EMType.Drain,
                            Tags = new List<EMTag>
                            {
                                EMTag.WaterChange
                            },
                            RoomNumbers = new int[]{0,10 },
                            WaterTextures = new ushort[]{ 71, 72, 73, 79 }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            Location = new EMLocation
                            {
                                X = 48640 + 4096,
                                Z = 38400,
                                Room = 10
                            },
                            FloorClicks = -2,
                            SlantType = FDSlantEntryType.FloorSlant,
                            ZSlant = 1
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            Location = new EMLocation
                            {
                                X = 48640 + 4096,
                                Z = 38400 + 1024,
                                Room = 10
                            },
                            FloorClicks = -4,
                            SlantType = FDSlantEntryType.FloorSlant,
                            ZSlant = 2
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            Location = new EMLocation
                            {
                                X = 48640 + 4096,
                                Z = 38400 + 2048,
                                Room = 10
                            },
                            FloorClicks = -6,
                            SlantType = FDSlantEntryType.FloorSlant,
                            ZSlant = 2
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            Location = new EMLocation
                            {
                                X = 48640 + 4096,
                                Z = 38400 + 3072,
                                Room = 10
                            },
                            FloorClicks = -8,
                            SlantType = FDSlantEntryType.FloorSlant,
                            ZSlant = 2
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Move some faces to fit the ramp.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 10,
                                    FaceIndex = 70,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    RoomNumber = 10,
                                    FaceIndex = 72,
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
                                    RoomNumber = 10,
                                    FaceIndex = 74,
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
                                            Y = -1024-512
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024-512
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 10,
                                    FaceIndex = 76,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -2048
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -1024-512
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = -1024-512
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -2048
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 10,
                                    FaceIndices = new int[]{ 88,86,84},
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = -1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = -1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = -1024
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 10,
                                    FaceIndex = 79,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            X = -1024,
                                            Y = 512,
                                            Z = -1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = -1024,
                                            Z = -1024
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 10,
                                    FaceIndex = 89,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -512,
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 10,
                                    FaceIndex = 87,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [3] = new TRVertex
                                        {
                                            Y = -512,
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 10,
                                    FaceIndex = 84,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = 512,
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 10,
                                    FaceIndex = 82,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -256,
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -512,
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 10,
                                    FaceIndex = 78,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 768,
                                            Z = -4096,
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 768,
                                            Z = -4096,
                                        },
                                        [2] = new TRVertex
                                        {
                                            Z = -4096,
                                        },
                                        [3] = new TRVertex
                                        {
                                            Z = -4096,
                                        },
                                    }
                                },
                            }
                        },
                        new EMAddFaceFunction
                        {
                            Comments = "Patch some gaps.",
                            EMType = EMType.AddFace,
                            Triangles = new Dictionary<short, List<TRFace3>>
                            {
                                [10] = new List<TRFace3>
                                {
                                    new TRFace3
                                    {
                                        Texture = 76,
                                        Vertices = new ushort[] { 119,127, 126 }
                                    },
                                    new TRFace3
                                    {
                                        Texture = 76,
                                        Vertices = new ushort[] { 102,105,95 }
                                    }
                                }
                            },
                            Quads = new Dictionary<short, List<TRFace4>>
                            {
                                [10] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 75,
                                        Vertices = new ushort[]{ 100,99,67,70}
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Retexture faces.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [59] = new EMGeometryMap
                                {
                                    [10] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 70,72,74,76 }
                                    }
                                }
                            }
                        },
                        new EMRemoveTriggerFunction
                        {
                            Comments = "Remove the camera trigger after the door.",
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 50688,
                                    Z = 37376,
                                    Room = 10
                                }
                            }
                        },
                        new EMDrainFunction
                        {
                            Comments = "Drain the starting area.",
                            EMType = EMType.Drain,
                            Tags = new List<EMTag>
                            {
                                EMTag.WaterChange
                            },
                            RoomNumbers = new int[]{0,10 },
                            WaterTextures = new ushort[]{ 71, 72, 73, 79 }
                        }
                    },
                },

                // Fire room door
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the fire room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 68,
                            Flags = 17 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: OYYYO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 601,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(14, 2),
                                            new Point(26, 2),
                                            new Point(38, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 601,
                                    Clip = new Rectangle(14, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(2, 2),
                                            new Point(50, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the fire room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 68,
                            Flags = 3 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: OOYYY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 601,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(26, 2),
                                            new Point(38, 2),
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 601,
                                    Clip = new Rectangle(14, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(2, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the fire room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 68,
                            Flags = 3 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: ?OYYY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 601,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(26, 2),
                                            new Point(38, 2),
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(0, 0, 17, 15),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the fire room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 68,
                            Flags = 10 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YOYOY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 601,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(26, 2),
                                            new Point(50, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the fire room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 68,
                            Flags = 10 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: ?OYOY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 601,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(26, 2),
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(0, 0, 17, 15),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the fire room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 68,
                            Flags = 28 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YYOOO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 601,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(14, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the fire room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 68,
                            Flags = 12 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YYOOY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 601,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(14, 2),
                                            new Point(50, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the fire room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 68,
                            Flags = 1 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: OYYYY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 601,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(14, 2),
                                            new Point(26, 2),
                                            new Point(38, 2),
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 601,
                                    Clip = new Rectangle(14, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [601] = new List<Point>
                                        {
                                            new Point(2, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                },

                // Pillar room door
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the pillar room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 69,
                            Flags = 19 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: OOYYO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(26, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(38, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the pillar room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 69,
                            Flags = 19 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: ?OYYO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(26, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(38, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(0, 0, 17, 15),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the pillar room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 69,
                            Flags = 24 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YYYOO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(26, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(2, 2),
                                            new Point(14, 2),
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the pillar room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 69,
                            Flags = 21 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: OYOYO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(26, 2),
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(26, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(14, 2),
                                            new Point(38, 2),
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the pillar room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 69,
                            Flags = 13 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: OYOOY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(26, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(26, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(14, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the pillar room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 69,
                            Flags = 27 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: OOYOO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the pillar room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 69,
                            Flags = 27 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: ?OYOO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(0, 0, 17, 15),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the pillar room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 69,
                            Flags = 16 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YYYYO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 604,
                                    Clip = new Rectangle(26, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [604] = new List<Point>
                                        {
                                            new Point(2, 2),
                                            new Point(14, 2),
                                            new Point(38, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                },

                // Exit room door
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the exit room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 92,
                            Flags = 0
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YYYYY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(14, 2),
                                            new Point(26, 2),
                                            new Point(38, 2),
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the exit room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 92,
                            Flags = 9 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: OYYOY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(14, 2),
                                            new Point(26, 2),
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(14, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(2, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the exit room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 92,
                            Flags = 7 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: OOOYY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(38, 2),
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(14, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(2, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the exit room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 92,
                            Flags = 7 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: ?OOYY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(38, 2),
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(14, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(2, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(0, 0, 17, 15),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the exit room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 92,
                            Flags = 22 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YOOYO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(38, 2),
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(14, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the exit room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 92,
                            Flags = 22 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: ?OOYO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(38, 2),
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(14, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(0, 0, 17, 15),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the exit room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 92,
                            Flags = 29 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: OYOOO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(14, 2),
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(14, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(50, 2),
                                            new Point(2, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the exit room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 92,
                            Flags = 2 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YOYYY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(26, 2),
                                            new Point(38, 2),
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the exit room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 92,
                            Flags = 2 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: ?OYYY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 597,
                                    Clip = new Rectangle(2, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(26, 2),
                                            new Point(38, 2),
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(0, 0, 17, 15),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [597] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                }
                            }
                        }
                    },
                },

                // Viaduct room door
                // Must be done last as other doors may use the obscured texture
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the viaduct room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 70,
                            Flags = 4 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YYOYY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(12, 0, 12, 2),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(62, 1, 1, 8),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 1)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(25, 1, 24, 13),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(1, 1)
                                        }
                                    }
                                },

                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(26, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(50, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(26, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the viaduct room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 70,
                            Flags = 18 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YOYYO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(12, 0, 12, 2),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(62, 1, 1, 8),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 1)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(25, 1, 24, 13),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(1, 1)
                                        }
                                    }
                                },

                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(50, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(14, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the viaduct room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 70,
                            Flags = 18 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: ?OYYO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(12, 0, 12, 2),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(62, 1, 1, 8),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 1)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(25, 1, 24, 13),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(1, 1)
                                        }
                                    }
                                },

                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(50, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(14, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(0, 0, 17, 15),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the viaduct room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 70,
                            Flags = 26 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YOYOO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(12, 0, 12, 2),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(62, 1, 1, 8),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 1)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(25, 1, 24, 13),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(1, 1)
                                        }
                                    }
                                },

                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(50, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(14, 2),
                                            new Point(38, 2),
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the viaduct room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 70,
                            Flags = 26 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: ?OYOO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(12, 0, 12, 2),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(62, 1, 1, 8),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 1)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(25, 1, 24, 13),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(1, 1)
                                        }
                                    }
                                },

                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(50, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(14, 2),
                                            new Point(38, 2),
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(0, 0, 17, 15),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the viaduct room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 70,
                            Flags = 20 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YYOYO.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(12, 0, 12, 2),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(62, 1, 1, 8),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 1)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(25, 1, 24, 13),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(1, 1)
                                        }
                                    }
                                },

                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(50, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(26, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the viaduct room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 70,
                            Flags = 8 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: YYYOY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(12, 0, 12, 2),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(62, 1, 1, 8),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 1)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(25, 1, 24, 13),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(1, 1)
                                        }
                                    }
                                },

                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(26, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(50, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(38, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the viaduct room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 70,
                            Flags = 15 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: OOOOY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(12, 0, 12, 2),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(62, 1, 1, 8),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 1)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(25, 1, 24, 13),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(1, 1)
                                        }
                                    }
                                },

                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(26, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(50, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(2, 2),
                                            new Point(14, 2),
                                            new Point(26, 2),
                                            new Point(38, 2)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the viaduct room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 70,
                            Flags = 15 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: ?OOOY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(12, 0, 12, 2),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(62, 1, 1, 8),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 1)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(25, 1, 24, 13),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(1, 1)
                                        }
                                    }
                                },

                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(26, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(50, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(2, 2),
                                            new Point(14, 2),
                                            new Point(26, 2),
                                            new Point(38, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(0, 0, 17, 15),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Change the viaduct room door mask.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 70,
                            Flags = 14 << 9
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Change the door texture hint: ?OOOY.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(12, 0, 12, 2),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(62, 1, 1, 8),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 1)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(25, 1, 24, 13),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(1, 1)
                                        }
                                    }
                                },

                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(26, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(50, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(50, 2, 11, 11),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(2, 2),
                                            new Point(14, 2),
                                            new Point(26, 2),
                                            new Point(38, 2)
                                        }
                                    }
                                },
                                new TextureOverwrite
                                {
                                    Texture = 605,
                                    Clip = new Rectangle(0, 0, 17, 15),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [605] = new List<Point>
                                        {
                                            new Point(0, 0)
                                        }
                                    }
                                }
                            }
                        }
                    },
                },

                // Gold bar count mixup
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "No action - default lead bar count needed.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMConvertEntityFunction
                        {
                            Comments = "Change one of the lead bars into something else.",
                            EMType = EMType.ConvertEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange,
                                EMTag.TrapChange
                            },
                            EntityIndex = 22,
                            NewEntityType = (short)TREntities.FlameEmitter_N
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move it to a slot position.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 22,
                            TargetLocation = new EMLocation
                            {
                                X = 25088,
                                Y = -5120,
                                Z = 17664,
                                Room = 20
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger it.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088,
                                    Y = -5120,
                                    Z = 17920,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Key,
                                SwitchOrKeyRef = 30,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 22
                                    }
                                }
                            },
                            Replace = true
                        },
                        new EMConvertTriggerFunction
                        {
                            Comments = "Change the other trigger so the door can still open.",
                            EMType = EMType.ConvertTrigger,
                            Location = new EMLocation
                            {
                                X = 25088 - 2048,
                                Y = -5120,
                                Z = 17920,
                                Room = 20
                            },
                            Mask = 3
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Adjust the texture to show 2 x gold bars.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 110,
                                    Clip = new Rectangle(25, 14, 12, 35),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [110] = new List<Point>
                                        {
                                            new Point(40, 14)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMConvertEntityFunction
                        {
                            Comments = "Change one of the lead bars into something else.",
                            EMType = EMType.ConvertEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange,
                                EMTag.TrapChange
                            },
                            EntityIndex = 22,
                            NewEntityType = (short)TREntities.FlameEmitter_N
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move it to a slot position.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 22,
                            TargetLocation = new EMLocation
                            {
                                X = 25088 - 2048,
                                Y = -5120,
                                Z = 17664,
                                Room = 20
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger it.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088 - 2048,
                                    Y = -5120,
                                    Z = 17920,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Key,
                                SwitchOrKeyRef = 31,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 22
                                    }
                                }
                            },
                            Replace = true
                        },
                        new EMConvertTriggerFunction
                        {
                            Comments = "Change the other trigger so the door can still open.",
                            EMType = EMType.ConvertTrigger,
                            Location = new EMLocation
                            {
                                X = 25088,
                                Y = -5120,
                                Z = 17920,
                                Room = 20
                            },
                            Mask = 3
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Adjust the texture to show 2 x gold bars.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 110,
                                    Clip = new Rectangle(25, 14, 12, 35),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [110] = new List<Point>
                                        {
                                            new Point(53, 14)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMConvertEntityFunction
                        {
                            Comments = "Change one of the lead bars into something else.",
                            EMType = EMType.ConvertEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange,
                                EMTag.TrapChange
                            },
                            EntityIndex = 22,
                            NewEntityType = (short)TREntities.FlameEmitter_N
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move it to a slot position.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 22,
                            TargetLocation = new EMLocation
                            {
                                X = 25088 - 2048 - 2048,
                                Y = -5120,
                                Z = 17664,
                                Room = 20
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger it.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088 - 2048 - 2048,
                                    Y = -5120,
                                    Z = 17920,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Key,
                                SwitchOrKeyRef = 32,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 22
                                    }
                                }
                            },
                            Replace = true
                        },
                        new EMConvertTriggerFunction
                        {
                            Comments = "Change the other trigger so the door can still open.",
                            EMType = EMType.ConvertTrigger,
                            Location = new EMLocation
                            {
                                X = 25088 - 2048,
                                Y = -5120,
                                Z = 17920,
                                Room = 20
                            },
                            Mask = 30
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Adjust the texture to show 2 x gold bars.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 110,
                                    Clip = new Rectangle(25, 14, 12, 35),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [109] = new List<Point>
                                        {
                                            new Point(2, 14)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMConvertEntityFunction
                        {
                            Comments = "Change two of the lead bars into something else.",
                            EMType = EMType.ConvertEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange,
                                EMTag.TrapChange
                            },
                            EntityIndex = 40,
                            NewEntityType = (short)TREntities.FlameEmitter_N
                        },
                        new EMConvertEntityFunction
                        {
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 66,
                            NewEntityType = (short)TREntities.FlameEmitter_N
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move them to slot positions.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 40,
                            TargetLocation = new EMLocation
                            {
                                X = 25088,
                                Y = -5120,
                                Z = 17664,
                                Room = 20
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 66,
                            TargetLocation = new EMLocation
                            {
                                X = 25088 - 2048,
                                Y = -5120,
                                Z = 17664,
                                Room = 20
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger them.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088,
                                    Y = -5120,
                                    Z = 17920,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Key,
                                SwitchOrKeyRef = 30,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 40
                                    }
                                }
                            },
                            Replace = true
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088 - 2048,
                                    Y = -5120,
                                    Z = 17920,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Key,
                                SwitchOrKeyRef = 31,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 66
                                    }
                                }
                            },
                            Replace = true
                        },
                        new EMConvertTriggerFunction
                        {
                            Comments = "Change the other trigger so the door can still open.",
                            EMType = EMType.ConvertTrigger,
                            Location = new EMLocation
                            {
                                X = 25088 - 2048 - 2048,
                                Y = -5120,
                                Z = 17920,
                                Room = 20
                            },
                            Mask = 31
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Adjust the texture to show 1 x gold bar.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 110,
                                    Clip = new Rectangle(25, 14, 12, 35),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [110] = new List<Point>
                                        {
                                            new Point(40, 14),
                                            new Point(53, 14)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMConvertEntityFunction
                        {
                            Comments = "Change two of the lead bars into something else.",
                            EMType = EMType.ConvertEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange,
                                EMTag.TrapChange
                            },
                            EntityIndex = 40,
                            NewEntityType = (short)TREntities.FlameEmitter_N
                        },
                        new EMConvertEntityFunction
                        {
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 66,
                            NewEntityType = (short)TREntities.FlameEmitter_N
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move them to slot positions.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 40,
                            TargetLocation = new EMLocation
                            {
                                X = 25088,
                                Y = -5120,
                                Z = 17664,
                                Room = 20
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 66,
                            TargetLocation = new EMLocation
                            {
                                X = 25088 - 2048 - 2048,
                                Y = -5120,
                                Z = 17664,
                                Room = 20
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger them.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088,
                                    Y = -5120,
                                    Z = 17920,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Key,
                                SwitchOrKeyRef = 30,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 40
                                    }
                                }
                            },
                            Replace = true
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088 - 2048 - 2048,
                                    Y = -5120,
                                    Z = 17920,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Key,
                                SwitchOrKeyRef = 32,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 66
                                    }
                                }
                            },
                            Replace = true
                        },
                        new EMConvertTriggerFunction
                        {
                            Comments = "Change the other trigger so the door can still open.",
                            EMType = EMType.ConvertTrigger,
                            Location = new EMLocation
                            {
                                X = 25088 - 2048,
                                Y = -5120,
                                Z = 17920,
                                Room = 20
                            },
                            Mask = 31
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Adjust the texture to show 1 x gold bar.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 110,
                                    Clip = new Rectangle(25, 14, 12, 35),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [110] = new List<Point>
                                        {
                                            new Point(40, 14)
                                        },
                                        [109] = new List<Point>
                                        {
                                            new Point(2, 14)
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMConvertEntityFunction
                        {
                            Comments = "Change two of the lead bars into something else.",
                            EMType = EMType.ConvertEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange,
                                EMTag.TrapChange
                            },
                            EntityIndex = 22,
                            NewEntityType = (short)TREntities.FlameEmitter_N
                        },
                        new EMConvertEntityFunction
                        {
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 66,
                            NewEntityType = (short)TREntities.FlameEmitter_N
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move them to slot positions.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 22,
                            TargetLocation = new EMLocation
                            {
                                X = 25088 - 2048,
                                Y = -5120,
                                Z = 17664,
                                Room = 20
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 66,
                            TargetLocation = new EMLocation
                            {
                                X = 25088 - 2048 - 2048,
                                Y = -5120,
                                Z = 17664,
                                Room = 20
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger them.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088 - 2048,
                                    Y = -5120,
                                    Z = 17920,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Key,
                                SwitchOrKeyRef = 31,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 22
                                    }
                                }
                            },
                            Replace = true
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger them.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088 - 2048 - 2048,
                                    Y = -5120,
                                    Z = 17920,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Key,
                                SwitchOrKeyRef = 32,
                                Timer = 1,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 66
                                    }
                                }
                            },
                            Replace = true
                        },
                        new EMConvertTriggerFunction
                        {
                            Comments = "Change the other trigger so the door can still open.",
                            EMType = EMType.ConvertTrigger,
                            Location = new EMLocation
                            {
                                X = 25088,
                                Y = -5120,
                                Z = 17920,
                                Room = 20
                            },
                            Mask = 31
                        },
                        new EMOverwriteTextureFunction
                        {
                            Comments = "Adjust the texture to show 1 x gold bar.",
                            EMType = EMType.OverwriteTexture,
                            Overwrites = new List<TextureOverwrite>
                            {
                                new TextureOverwrite
                                {
                                    Texture = 110,
                                    Clip = new Rectangle(25, 14, 12, 35),
                                    Targets = new Dictionary<ushort, List<Point>>
                                    {
                                        [110] = new List<Point>
                                        {
                                            new Point(53, 14)
                                        },
                                        [109] = new List<Point>
                                        {
                                            new Point(2, 14)
                                        }
                                    }
                                }
                            }
                        }
                    }
                },

                // OG secret lever
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential OG secret room lever relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 129,
                            Location = new EMLocation
                            {
                                X = 59904 - 1024,
                                Y = 512,
                                Z = 55808,
                                Room = 69
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential OG secret room lever relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 129,
                            Location = new EMLocation
                            {
                                X = 59904 - 1024,
                                Y = 512,
                                Z = 55808,
                                Room = 69,
                                Angle = -16384
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential OG secret room lever relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 129,
                            Location = new EMLocation
                            {
                                X = 59904 - 1024,
                                Y = 512,
                                Z = 55808 - 4*1024,
                                Room = 69,
                                Angle = -16384
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential OG secret room lever relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 129,
                            Location = new EMLocation
                            {
                                X = 59904 - 1024,
                                Y = 512,
                                Z = 55808 - 4*1024,
                                Room = 69,
                                Angle = -32768
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential OG secret room lever relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 129,
                            Location = new EMLocation
                            {
                                X = 59904,
                                Y = 512,
                                Z = 55808 - 4*1024,
                                Room = 69,
                                Angle = -32768
                            }
                        }
                    }
                },

                // Clang-clang#2 move
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Leave clang-clang #2 where it is.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move clang-clang #2.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 2,
                            TargetLocation = new EMLocation
                            {
                                X = 71168-512,
                                Y = -1536,
                                Z = 53760,
                                Room = 73,
                                Angle = 16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 2,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 2
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move clang-clang #2.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 2,
                            TargetLocation = new EMLocation
                            {
                                X = 71168-1024,
                                Y = -1536-128,
                                Z = 53760-512-1024,
                                Room = 73,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 2,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 2
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move clang-clang #2.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 2,
                            TargetLocation = new EMLocation
                            {
                                X = 66048,
                                Y = -4608,
                                Z = 34304-512,
                                Room = 17,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 2,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 2
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move clang-clang #2.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 2,
                            TargetLocation = new EMLocation
                            {
                                X = 40448-512,
                                Y = -3328,
                                Z = 45568,
                                Room = 63,
                                Angle = 16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 2,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 2
                                    }
                                }
                            }
                        }
                    },
                },

                // Clang-clang#3 move
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Leave clang-clang #3 where it is.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move clang-clang #3.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 3,
                            TargetLocation = new EMLocation
                            {
                                X = 39424-512,
                                Y = -3072,
                                Z = 45568,
                                Room = 63,
                                Angle = 16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 3,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 3
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move clang-clang #3.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 3,
                            TargetLocation = new EMLocation
                            {
                                X = 41472,
                                Y = -6400,
                                Z = 33280-512,
                                Room = 41,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 3,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 3
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move clang-clang #3.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 3,
                            TargetLocation = new EMLocation
                            {
                                X = 23040,
                                Y = -5888,
                                Z = 23040-512,
                                Room = 20,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 3,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 3
                                    }
                                }
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move clang-clang #3.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 3,
                            TargetLocation = new EMLocation
                            {
                                X = 44544,
                                Y = -1536,
                                Z = 48640-512,
                                Room = 43,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 3,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 3
                                    }
                                }
                            }
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
                        ConditionType = EMConditionType.EntityProperty,
                        Comments = "If clang-clang #2 has been moved, tidy up the OG triggers.",
                        EntityIndex = 2,
                        Room = 2
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 64000,
                                    Y = -128,
                                    Z = 60928,
                                    Room = 2
                                },
                                new EMLocation
                                {
                                    X = 64000+1024,
                                    Y = -128,
                                    Z = 60928-1024,
                                    Room = 71
                                }
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 2
                            }
                        }
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        ConditionType = EMConditionType.EntityProperty,
                        Comments = "If clang-clang #3 has been moved, tidy up the OG triggers.",
                        EntityIndex = 3,
                        Room = 2
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 64000,
                                    Y = -128,
                                    Z = 60928,
                                    Room = 2
                                },
                                new EMLocation
                                {
                                    X = 64000+1024,
                                    Y = -128,
                                    Z = 60928-1024,
                                    Room = 71
                                }
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 3
                            }
                        }
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "If both have been moved, clear the triggers altogether.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 2,
                        Room = 2,
                        Negate = true,
                        And = new List<BaseEMCondition>
                        {
                            new EMEntityPropertyCondition
                            {
                                ConditionType = EMConditionType.EntityProperty,
                                EntityIndex = 3,
                                Room = 2,
                                Negate = true,
                            }
                        }
                    },
                    OnTrue = new EMEditorSet
                    {
                        new EMRemoveTriggerFunction
                        {
                            EMType = EMType.RemoveTrigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 64000,
                                    Y = -128,
                                    Z = 60928,
                                    Room = 2
                                },
                                new EMLocation
                                {
                                    X = 64000+1024,
                                    Y = -128,
                                    Z = 60928-1024,
                                    Room = 71
                                }
                            },
                        }
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMSectorContainsSecretCondition
                    {
                        Comments= "If there is a secret in this location and room 18 contains water, drain it.",
                        ConditionType = EMConditionType.SectorContainsSecret,
                        Location = new EMLocation
                        {
                            X = 70144,
                            Y = -4864,
                            Z = 33280,
                            Room = 17
                        },
                        And = new List<BaseEMCondition>
                        {
                            new EMRoomContainsWaterCondition
                            {
                                ConditionType = EMConditionType.RoomContainsWater,
                                RoomIndex = 18
                            }
                        }
                    },
                    OnTrue = new EMEditorSet
                    {
                        new EMDrainFunction
                        {
                            EMType = EMType.Drain,
                            RoomNumbers = new int[] { 18 },
                            WaterTextures = new ushort[] { 71, 72, 73, 79 }
                        }
                    }
                }
            };

            mapping.OneOf = new List<EMEditorGroupedSet>
            {
                // Pillar room flipmap lever
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 42.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[42].RoomData.Rectangles[36].Texture] = new EMGeometryMap
                                {
                                    [42] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 37 }
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
                                EntityIndex = 96,
                                Location = new EMLocation
                                {
                                    X = 39424,
                                    Y = -4352,
                                    Z = 27136,
                                    Room = 42,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[42].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 36 }
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
                                EntityIndex = 96,
                                Location = new EMLocation
                                {
                                    X = 39424,
                                    Y = -4352,
                                    Z = 27136,
                                    Room = 42,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[42].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 46 }
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
                                EntityIndex = 96,
                                Location = new EMLocation
                                {
                                    X = 39424,
                                    Y = -4352,
                                    Z = 27136 + 1024,
                                    Room = 42,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[42].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 47 }
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
                                EntityIndex = 96,
                                Location = new EMLocation
                                {
                                    X = 39424 - 1024,
                                    Y = -4352 - 1024,
                                    Z = 27136 + 1024,
                                    Room = 42,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[42].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 40 }
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
                                EntityIndex = 96,
                                Location = new EMLocation
                                {
                                    X = 39424 - 1024,
                                    Y = -4352 - 1024,
                                    Z = 27136 + 1024,
                                    Room = 42,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[42].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 96,
                                Location = new EMLocation
                                {
                                    X = 39424 - 2048,
                                    Y = -4352 - 1024,
                                    Z = 27136 + 1024,
                                    Room = 42,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[42].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 96,
                                Location = new EMLocation
                                {
                                    X = 39424 - 3072,
                                    Y = -4352 - 1024,
                                    Z = 27136 + 1024,
                                    Room = 42,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[42].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 4 }
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
                                EntityIndex = 96,
                                Location = new EMLocation
                                {
                                    X = 39424 - 3072,
                                    Y = -4352 - 1024,
                                    Z = 27136 + 1024,
                                    Room = 42,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[42].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        }
                                    }
                                }
                            }
                        },
                    }
                },
                // Party room lever
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 78.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[78].RoomData.Rectangles[55].Texture] = new EMGeometryMap
                                {
                                    [78] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 41 }
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
                                EntityIndex = 134,
                                Location = new EMLocation
                                {
                                    X = 89600,
                                    Y = -4096,
                                    Z = 37376,
                                    Room = 78,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[78].RoomData.Rectangles[41].Texture] = new EMGeometryMap
                                    {
                                        [78] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 55 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Face rotation for above.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[]{ 55},
                                        RoomNumber = 78,
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
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 134,
                                Location = new EMLocation
                                {
                                    X = 89600,
                                    Y = -4096,
                                    Z = 37376,
                                    Room = 78,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[78].RoomData.Rectangles[41].Texture] = new EMGeometryMap
                                    {
                                        [78] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 38 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Face amendments for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndex = 39,
                                        RoomNumber = 78,
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
                                    },
                                    new EMFaceModification
                                    {
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndex = 38,
                                        RoomNumber = 78,
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
                                EntityIndex = 134,
                                Location = new EMLocation
                                {
                                    X = 89600,
                                    Y = -4096 - 512,
                                    Z = 37376 + 2048,
                                    Room = 78,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[78].RoomData.Rectangles[41].Texture] = new EMGeometryMap
                                    {
                                        [78] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 48 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Face amendments for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndex = 49,
                                        RoomNumber = 78,
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
                                    },
                                    new EMFaceModification
                                    {
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndex = 48,
                                        RoomNumber = 78,
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
                                },
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[]{ 48},
                                        RoomNumber = 78,
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
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 134,
                                Location = new EMLocation
                                {
                                    X = 89600,
                                    Y = -4096 - 512,
                                    Z = 37376 + 2048,
                                    Room = 78,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[78].RoomData.Rectangles[41].Texture] = new EMGeometryMap
                                    {
                                        [78] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 59 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Face amendments for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndex = 59,
                                        RoomNumber = 78,
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
                                    }
                                }
                            },
                            new EMRemoveFaceFunction
                            {
                                Comments = "Remove a redundant face.",
                                EMType = EMType.RemoveFace,
                                GeometryMap = new EMGeometryMap
                                {
                                    [78] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[]{ 58}
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
                                EntityIndex = 134,
                                Location = new EMLocation
                                {
                                    X = 89600 - 2048,
                                    Y = -4096,
                                    Z = 37376 + 2048,
                                    Room = 78,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[78].RoomData.Rectangles[41].Texture] = new EMGeometryMap
                                    {
                                        [78] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 134,
                                Location = new EMLocation
                                {
                                    X = 89600 - 2048,
                                    Y = -4096,
                                    Z = 37376 + 1024,
                                    Room = 78,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[78].RoomData.Rectangles[41].Texture] = new EMGeometryMap
                                    {
                                        [78] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 26 }
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
                new EMMoveEntityFunction
                {
                    Comments = "Moves door 92 so that it can open properly, otherwise Lara has to glitch through.",
                    EMType = EMType.MoveEntity,
                    EntityIndex = 92,
                    TargetLocation = new EMLocation
                    {
                        X = 68096,
                        Y = -4352,
                        Z = 31232,
                        Room = 39
                    }
                },
                new EMMoveTriggerFunction
                {
                    Comments = "Move the trigger that's behind the door above to the next tile.",
                    EMType = EMType.MoveTrigger,
                    BaseLocation = new EMLocation
                    {
                        X = 68096,
                        Y = -4352,
                        Z = 31232,
                        Room = 39
                    },
                    NewLocation = new EMLocation
                    {
                        X = 68096,
                        Y = -4352,
                        Z = 30208,
                        Room = 39
                    }
                },
                new EMSwapGroupedSlotsFunction
                {
                    Comments = "Swap the main room door levers so the bits match up with the clues.",
                    EMType = EMType.SwapGroupedSlots,
                    EntityMap = new Dictionary<short, short>
                    {
                        [81] = 84,
                        [84] = 81,
                        [82] = 85,
                        [85] = 82
                    }
                }
            };

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();

            mapping.RewardEntities = new List<int> { 6, 7, 8, 114, 115, 116, 119, 120 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 26112,
                            Y = -5888,
                            Z = 15872
                        },
                        new Location
                        {
                            X = 27136,
                            Y = -5376,
                            Z = 15872
                        },
                        new Location
                        {
                            X = 27136,
                            Y = -5120,
                            Z = 16896
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door5,
                            X = 25088,
                            Y = -4608,
                            Z = 19968,
                            Angle = -16384,
                            Intensity = 6400,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 20077,
                            Y = -6835,
                            Z = 22059,
                            Room = 20
                        }
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 65,
                            LinkedLocation = new EMLocation
                            {
                                X = 25088,
                                Y = -4608,
                                Z = 19968,
                                Room = 20
                            },
                            NewLocation = new EMLocation
                            {
                                X = 24576,
                                Y = -4096,
                                Z = 14336,
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [20] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 26112,
                                            Y = -4608,
                                            Z = 19968,
                                            Room = 20
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [20] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 25088,
                                            Y = -4096,
                                            Z = 19968,
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
                                    BaseRoom = 20,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 6144,
                                            Y = -5632,
                                            Z = 4096
                                        },
                                        new TRVertex
                                        {
                                            X = 6144,
                                            Y = -5632,
                                            Z = 3072
                                        },
                                        new TRVertex
                                        {
                                            X = 6144,
                                            Y = -4608,
                                            Z = 3072
                                        },
                                        new TRVertex
                                        {
                                            X = 6144,
                                            Y = -4608,
                                            Z = 4096
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 20,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -5632,
                                            Z = 5120
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -5632,
                                            Z = 6144
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -4608,
                                            Z = 6144
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -4608,
                                            Z = 5120
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
                                    RoomNumber = 20,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 109,
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
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 6,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 8,
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
                        },
                        new EMRefaceFunction
                        {
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [95] = new EMGeometryMap
                                {
                                    [20] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 109 }
                                    }
                                },
                                [30] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 6 }
                                    }
                                },
                                [5] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 8 }
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
                                        Texture = 5,
                                        Vertices = new ushort[]
                                        {
                                            0, 1, 8, 7
                                        }
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

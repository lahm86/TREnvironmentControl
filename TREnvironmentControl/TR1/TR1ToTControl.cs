using Newtonsoft.Json;
using System;
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
    public class TR1ToTControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.TIHOCAN;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);
            TRLevel level3b = GetTR1Level(TRLevelNames.QUALOPEC);
            TRLevel level4 = GetTR1Level(TRLevelNames.FOLLY);

            TRRoom room90 = level.Rooms[90];
            TRRoom room38 = level.Rooms[38];
            mapping.NonPurist = new EMEditorSet
            {
                new EMRefaceFunction
                {
                    Comments = "Fix the out of place lever textures in room 89 and ceiling in room 75.",
                    EMType = EMType.Reface,
                    TextureMap = new EMTextureMap
                    {
                        [level.Rooms[89].RoomData.Rectangles[66].Texture] = new EMGeometryMap
                        {
                            [89] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 1, 84 }
                            }
                        },
                        [level.Rooms[75].RoomData.Rectangles[64].Texture] = new EMGeometryMap
                        {
                            [75] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 32 }
                            }
                        }
                    }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Rotations for above.",
                    EMType = EMType.ModifyFace,
                    Rotations = new EMFaceRotation[]
                    {
                        new EMFaceRotation
                        {
                            RoomNumber = 89,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndices = new int[] { 1, 84 },
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
                // Return paths
                new EMCreateRoomFunction
                {
                    Comments = "Create rooms for a return path (scythe room to the beginning).",
                    EMType = EMType.CreateRoom,
                    Height = 4,
                    Width = 4,
                    Depth = 4,
                    Textures = new EMTextureGroup
                    {
                        Floor = 89,
                        Ceiling = 89,
                        Wall4 = 14
                    },
                    AmbientLighting = room38.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room38.RoomData.Vertices[room38.RoomData.Rectangles[0].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -512,
                            Z = 2 * 1024 + 512,
                            Intensity1 = room38.Lights[0].Intensity,
                            Fade1 = 1024+512//room90.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 39424,
                        Y = -5376,
                        Z = 81408,
                        Room = 38
                    },
                    Location = new EMLocation
                    {
                        X = 37888-2048,
                        Y = -5376-1024-256,
                        Z = 79872-1024,
                    },
                    FloorHeights = new Dictionary<sbyte, List<int>>
                    {
                        [-127] = new List<int> { 9 }
                    }
                },
                new EMCreateRoomFunction
                {
                    EMType = EMType.CreateRoom,
                    Height = 4,
                    Width = 3,
                    Depth = 20,
                    Textures = new EMTextureGroup
                    {
                        Floor = 89,
                        Ceiling = 89,
                        Wall4 = 14
                    },
                    AmbientLighting = room38.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room38.RoomData.Vertices[room38.RoomData.Rectangles[0].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -512,
                            Z = 18 * 1024 + 512,
                            Intensity1 = room38.Lights[0].Intensity,
                            Fade1 = 1024//room90.Lights[0].Fade,
                        },
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -512,
                            Z = 1 * 1024 + 512,
                            Intensity1 = room38.Lights[0].Intensity,
                            Fade1 = 1024+512//room90.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 39424,
                        Y = -5376,
                        Z = 81408,
                        Room = 38
                    },
                    Location = new EMLocation
                    {
                        X = 37888-2048,
                        Y = -5376-1024-256-1024,
                        Z = 79872-10240*2+2048,
                    }
                },
                new EMCreateRoomFunction
                {
                    EMType = EMType.CreateRoom,
                    Height = 4,
                    Width = 3,
                    Depth = 20,
                    Textures = new EMTextureGroup
                    {
                        Floor = 89,
                        Ceiling = 89,
                        Wall4 = 14
                    },
                    AmbientLighting = room38.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room38.RoomData.Vertices[room38.RoomData.Rectangles[0].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -512,
                            Z = 18 * 1024 + 512,
                            Intensity1 = room38.Lights[0].Intensity,
                            Fade1 = 1024+512//room90.Lights[0].Fade,
                        },
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -512,
                            Z = 1 * 1024 + 512,
                            Intensity1 = room38.Lights[0].Intensity,
                            Fade1 = 1024+512//room90.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 39424,
                        Y = -5376,
                        Z = 81408,
                        Room = 38
                    },
                    Location = new EMLocation
                    {
                        X = 37888-2048,
                        Y = -5376-1024-256-1024,
                        Z = 79872-10240*4+4096,
                    }
                },
                new EMCreateRoomFunction
                {
                    EMType = EMType.CreateRoom,
                    Height = 4,
                    Width = 3,
                    Depth = 20,
                    Textures = new EMTextureGroup
                    {
                        Floor = 89,
                        Ceiling = 89,
                        Wall4 = 14
                    },
                    AmbientLighting = room38.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room38.RoomData.Vertices[room38.RoomData.Rectangles[0].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -512,
                            Z = 18 * 1024 + 512,
                            Intensity1 = room38.Lights[0].Intensity,
                            Fade1 = 1024+512//room90.Lights[0].Fade,
                        },
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -512,
                            Z = 1 * 1024 + 512,
                            Intensity1 = room38.Lights[0].Intensity,
                            Fade1 = 1024+512//room90.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 39424,
                        Y = -5376,
                        Z = 81408,
                        Room = 38
                    },
                    Location = new EMLocation
                    {
                        X = 37888-2048,
                        Y = -5376-1024-256-1024,
                        Z = 79872-10240*6+4096+2048,
                    }
                },
                new EMCreateRoomFunction
                {
                    EMType = EMType.CreateRoom,
                    Height = 4,
                    Width = 3,
                    Depth = 10,
                    Textures = new EMTextureGroup
                    {
                        Floor = 89,
                        Ceiling = 89,
                        Wall4 = 14
                    },
                    AmbientLighting = room38.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room38.RoomData.Vertices[room38.RoomData.Rectangles[0].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -512,
                            Z = 8 * 1024 + 512,
                            Intensity1 = room38.Lights[0].Intensity,
                            Fade1 = 1024+512//room90.Lights[0].Fade,
                        },
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -512,
                            Z = 1 * 1024 + 512,
                            Intensity1 = room38.Lights[0].Intensity,
                            Fade1 = 1024+512//room90.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 39424,
                        Y = -5376,
                        Z = 81408,
                        Room = 38
                    },
                    Location = new EMLocation
                    {
                        X = 37888-2048,
                        Y = -5376-1024-256-1024,
                        Z = 79872-10240*7+4096+2048+2048,
                    }
                },
                new EMCreateRoomFunction
                {
                    EMType = EMType.CreateRoom,
                    Height = 6,
                    Width = 10,
                    Depth = 3,
                    Textures = new EMTextureGroup
                    {
                        Floor = 89,
                        Ceiling = 89,
                        Wall4 = 14,
                        Wall2 = 115,
                        Wall1 = 117,
                        WallAlignment = Direction.Down
                    },
                    AmbientLighting = room38.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room38.RoomData.Vertices[room38.RoomData.Rectangles[0].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 8*1024 + 512,
                            Y = -1024,
                            Z = 1 * 1024 + 512,
                            Intensity1 = room38.Lights[0].Intensity,
                            Fade1 = 1024+512//room90.Lights[0].Fade,
                        },
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -1024,
                            Z = 1 * 1024 + 512,
                            Intensity1 = room38.Lights[0].Intensity,
                            Fade1 = 1024+768//room90.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 39424,
                        Y = -5376,
                        Z = 81408,
                        Room = 38
                    },
                    Location = new EMLocation
                    {
                        X = 37888-1024,
                        Y = -5376-1024-256-1024+512,
                        Z = 79872-10240*7+4096+2048+2048,
                    },
                    FloorHeights = new Dictionary<sbyte, List<int>>
                    {
                        [-1] = new List<int> { 22},
                        [-2] = new List<int> { 4, 7, 10, 13, 16, 19}
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
                            BaseRoom = 38,
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
                                    Y = -6656-1024,
                                    Z = 5 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 6 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656,
                                    Z = 6 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656,
                                    Z = 5 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = -6,
                            AdjoiningRoom = 38,
                            Normal = new TRVertex
                            {
                                X = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = -6656-1024,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = -6656-1024,
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
                            BaseRoom = -6,
                            AdjoiningRoom = -5,
                            Normal = new TRVertex
                            {
                                Y = 1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
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
                                Y = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 19 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
                                    Z = 19 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
                                    Z = 18 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 18 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = -5,
                            AdjoiningRoom = -4,
                            Normal = new TRVertex
                            {
                                Z = 1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-2048,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-2048,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
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
                                Z = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-2048,
                                    Z = 19 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-2048,
                                    Z = 19 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
                                    Z = 19 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 19 * 1024
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
                                    Y = -6656-2048,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-2048,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
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
                                    X = 1 * 1024,
                                    Y = -6656-2048,
                                    Z = 19 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-2048,
                                    Z = 19 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
                                    Z = 19 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 19 * 1024
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
                                    X = 2 * 1024,
                                    Y = -6656-2048,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-2048,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
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
                                Z = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-2048,
                                    Z = 9 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-2048,
                                    Z = 9 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
                                    Z = 9 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
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
                                X = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-2048,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-2048,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -6656-1024,
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
                                    Y = -6656-2048,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-2048,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -6656-1024,
                                    Z = 1 * 1024
                                }
                            }
                        },

                        new EMVisibilityPortal
                        {
                            BaseRoom = -1,
                            AdjoiningRoom = 17,
                            Normal = new TRVertex
                            {
                                Y = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 8 * 1024,
                                    Y = -7424+256,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 9 * 1024,
                                    Y = -7424+256,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 9 * 1024,
                                    Y = -7424+256,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 8 * 1024,
                                    Y = -7424+256,
                                    Z = 1 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = 17,
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
                                    Y = -7168,
                                    Z = 6 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = -7168,
                                    Z = 6 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = -7168,
                                    Z = 7 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -7168,
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
                        [38] = new Dictionary<short, EMLocation[]>
                        {
                            [-6] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 39424-1024,
                                    Y = -5376,
                                    Z = 81408
                                }
                            },
                        },
                        [-6] = new Dictionary<short, EMLocation[]>
                        {
                            [38] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 39424,
                                    Y = -5376,
                                    Z = 81408
                                }
                            },
                            [-5] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 37376,
                                    Y = -7680+1024,
                                    Z = 79360
                                }
                            },
                        },
                        [-5] = new Dictionary<short, EMLocation[]>
                        {
                            [-4] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 37376,
                                    Y = -7680,
                                    Z = 61952
                                }
                            }
                        },
                        [-4] = new Dictionary<short, EMLocation[]>
                        {
                            [-5] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 37376,
                                    Y = -7680,
                                    Z = 61952+1024
                                }
                            },
                            [-3] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 37376,
                                    Y = -7680,
                                    Z = 43520
                                }
                            }
                        },
                        [-3] = new Dictionary<short, EMLocation[]>
                        {
                            [-4] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 37376,
                                    Y = -7680,
                                    Z = 43520+1024
                                }
                            },
                            [-2] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 37376,
                                    Y = -7680,
                                    Z = 25088
                                }
                            }
                        },
                        [-2] = new Dictionary<short, EMLocation[]>
                        {
                            [-3] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 37376,
                                    Y = -7680,
                                    Z = 25088+1024
                                }
                            },
                            [-1] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 38400,
                                    Y = -7680,
                                    Z = 17920
                                }
                            }
                        },
                        [-1] = new Dictionary<short, EMLocation[]>
                        {
                            [-2] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 38400-1024,
                                    Y = -7680,
                                    Z = 17920
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
                        X = 37376,
                        Y = -7680,
                        Z = 79360 + 1024,
                        Room = -5
                    },
                    Floor = new EMLocation
                    {
                        X = 37376,
                        Y = -7680+1024,
                        Z = 79360 + 1024,
                        Room = -6
                    },
                    InheritFloorBox = true
                },
                new EMVerticalCollisionalPortalFunction
                {
                    EMType = EMType.VerticalCollisionalPortal,
                    Ceiling = new EMLocation
                    {
                        X = 44544 +1024,
                        Y = -7424,
                        Z = 17920,
                        Room = -1
                    },
                    Floor = new EMLocation
                    {
                        X = 44544 +1024,
                        Y = -7424+1024,
                        Z = 17920,
                        Room = 17
                    },
                    InheritFloorBox = true
                },
                new EMRefaceFunction
                {
                    EMType = EMType.Reface,
                    TextureMap = new EMTextureMap
                    {
                        [46] = new EMGeometryMap
                        {
                            [-5] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 1 }
                            },
                            [-4] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 1,70 }
                            },
                            [-3] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 1,70 }
                            },
                            [-2] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 1,30 }
                            },
                        }
                    }
                },
                new EMRemoveFaceFunction
                {
                    Comments = "Remove faces for the portals.",
                    EMType = EMType.RemoveFace,
                    GeometryMap = new EMGeometryMap
                    {
                        [17] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 35 }
                        },
                        [38] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 19 },
                        },
                        [-6] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 1,12 }
                        },
                        [-5] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 4,69 }
                        },
                        [-4] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 4,72 }
                        },
                        [-3] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 4,72 }
                        },
                        [-2] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 3,32 }
                        },
                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 2,32 }
                        },
                    }
                },
                new EMTriggerFunction
                {
                    Comments = "Play some music in the long corridor.",
                    EMType = EMType.Trigger,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 37376,
                            Y = -7680,
                            Z = 79360-1024,
                            Room = -5
                        }
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
                            },
                        }
                    }
                },
                new EMGenerateLightFunction
                {
                    Comments = "Auto-generate vertex lighting in the new rooms.",
                    EMType = EMType.GenerateLight,
                    RoomIndices = new List<short> { -1,-2,-3,-4,-5,-6 }
                },

                new EMCreateRoomFunction
                {
                    Comments = "Create rooms for a return path (temple to pushblock area).",
                    EMType = EMType.CreateRoom,
                    Height = 18,
                    Width = 4,
                    Depth = 4,
                    Textures = new EMTextureGroup
                    {
                        Floor = 89,
                        Ceiling = 89,
                        Wall4 = 14,
                        Wall2 = 115,
                        Wall1 = 117
                    },
                    AmbientLighting = room90.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room90.RoomData.Vertices[room90.RoomData.Rectangles[24].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -3072,
                            Z = 2 * 1024 + 512,
                            Intensity1 = room90.Lights[0].Intensity,
                            Fade1 = 2048//room90.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 27136,
                        Y = 3840,
                        Z = 72192,
                        Room = 90
                    },
                    Location = new EMLocation
                    {
                        X = 26624 - 1024,
                        Y = 3840,
                        Z = 71680 - 3072,
                    },
                    FloorHeights = new Dictionary<sbyte, List<int>>
                    {
                        [-7] = new List<int> { 5 },
                        [-14] = new List<int> { 9 },
                        [-127] = new List<int> { 10 },
                    }
                },
                new EMCreateRoomFunction
                {
                    EMType = EMType.CreateRoom,
                    Height = 18,
                    Width = 4,
                    Depth = 4,
                    Textures = new EMTextureGroup
                    {
                        Floor = 89,
                        Ceiling = 89,
                        Wall4 = 14,
                        Wall2 = 115,
                        Wall1 = 117
                    },
                    AmbientLighting = room90.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room90.RoomData.Vertices[room90.RoomData.Rectangles[24].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -3072,
                            Z = 1 * 1024 + 512,
                            Intensity1 = room90.Lights[0].Intensity,
                            Fade1 = 2048 + 1024,//room90.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 27136,
                        Y = 3840,
                        Z = 72192,
                        Room = 90
                    },
                    Location = new EMLocation
                    {
                        X = 26624 + 1024,
                        Y = 3840 - 3072 - 512,
                        Z = 71680 - 3072,
                    },
                    FloorHeights = new Dictionary<sbyte, List<int>>
                    {
                        [-7] = new List<int> { 9 },
                        [-14] = new List<int> { 10 },
                        [-127] = new List<int> { 6 },
                    }
                },
                new EMCreateRoomFunction
                {
                    EMType = EMType.CreateRoom,
                    Height = 7,
                    Width = 4,
                    Depth = 3,
                    Textures = new EMTextureGroup
                    {
                        Floor = 89,
                        Ceiling = 89,
                        Wall4 = 14,
                        Wall2 = 115,
                        Wall1 = 117
                    },
                    AmbientLighting = room90.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room90.RoomData.Vertices[room90.RoomData.Rectangles[24].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -1024,
                            Z = 1 * 1024 + 512,
                            Intensity1 = room90.Lights[0].Intensity,
                            Fade1 = 2048,//room90.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 27136,
                        Y = 3840,
                        Z = 72192,
                        Room = 90
                    },
                    Location = new EMLocation
                    {
                        X = 26624 + 2048,
                        Y = 3840 - 3072 - 512 - 3072 - 512,
                        Z = 71680 - 1024,
                    },
                    FloorHeights = new Dictionary<sbyte, List<int>>
                    {
                        //[-7] = new List<int> { 9 },
                        //[-14] = new List<int> { 10 },
                        //[-127] = new List<int> { 6 },
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
                            BaseRoom = 90,
                            AdjoiningRoom = -3,
                            Normal = new TRVertex
                            {
                                Z = 1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 10 * 1024,
                                    Y = 3840 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 9 * 1024,
                                    Y = 1536,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 9 * 1024,
                                    Y = 3840,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 10 * 1024,
                                    Y = 3840,
                                    Z = 1 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = -3,
                            AdjoiningRoom = 90,
                            Normal = new TRVertex
                            {
                                Z = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 1536,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 3840 - 1024,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 3840,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 3840,
                                    Z = 3 * 1024
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
                                    X = 3 * 1024,
                                    Y = 256 - 1024,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 256 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 256,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 256,
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
                                    Y = 256 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 256 - 1024,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 256,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 256,
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
                                    X = 2 * 1024,
                                    Y = -3328 - 1024,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = -3328 - 1024,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = -3328,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -3328,
                                    Z = 3 * 1024
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
                                    X = 2 * 1024,
                                    Y = -3328 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -3328 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -3328,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -3328,
                                    Z = 1 * 1024
                                }
                            }
                        },

                        new EMVisibilityPortal
                        {
                            BaseRoom = -1,
                            AdjoiningRoom = 81,
                            Normal = new TRVertex
                            {
                                X = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = -4096 - 1024,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = -4096 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = -4096,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = -4096,
                                    Z = 2 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = 81,
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
                                    Y = -4096 - 1024,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -4096 - 1024,
                                    Z = 4 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -4096,
                                    Z = 4 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -4096,
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
                        [90] = new Dictionary<short, EMLocation[]>
                        {
                            [-3] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 27136,
                                    Y = 3840,
                                    Z = 72192 - 1024,
                                    Room = 90
                                }
                            }
                        },
                        [-3] = new Dictionary<short, EMLocation[]>
                        {
                            [90] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 27136,
                                    Y = 3840,
                                    Z = 72192,
                                    Room = -3
                                }
                            },
                            [-2] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 28160 + 1024,
                                    Y = 256,
                                    Z = 70144,
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
                                    Y = 256,
                                    Z = 70144,
                                    Room = -2
                                }
                            },
                            [-1] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 30208,
                                    Y = -3328,
                                    Z = 71168 + 1024,
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
                                    X = 30208,
                                    Y = -3328,
                                    Z = 71168,
                                    Room = -1
                                }
                            },
                            [81] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 32256,
                                    Y = -4096,
                                    Z = 72192,
                                    Room = -1
                                }
                            }
                        },
                        [81] = new Dictionary<short, EMLocation[]>
                        {
                            [-1] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 32256 - 1024,
                                    Y = -4096,
                                    Z = 72192,
                                    Room = 81
                                }
                            }
                        }
                    }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Amend some faces for the portals.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            FaceIndex = 19,
                            FaceType = EMTextureFaceType.Rectangles,
                            RoomNumber = -3,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [2] = new TRVertex
                                {
                                    Y = 1024
                                },
                                [3] = new TRVertex
                                {
                                    Y = -256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            FaceIndex = 12,
                            FaceType = EMTextureFaceType.Rectangles,
                            RoomNumber = -1,
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
                    }
                },
                new EMRemoveFaceFunction
                {
                    Comments = "Remove other faces for the portals.",
                    EMType = EMType.RemoveFace,
                    GeometryMap = new EMGeometryMap
                    {
                        [90] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 325 },
                            [EMTextureFaceType.Triangles] = new int[] { 40 }
                        },
                        [-3] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 17,18,32 }
                        },
                        [-2] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 2,32 }
                        },
                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 6,13 }
                        },
                        [81] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 10,12 }
                        },
                    }
                },
                new EMAddEntityFunction
                {
                    Comments = "Add a door.",
                    EMType = EMType.AddEntity,
                    TypeID = (short)TREntities.Door1,
                    Intensity = level.Entities[52].Intensity,
                    Location = new EMLocation
                    {
                        X = 32256,
                        Y = -4096,
                        Z = 72192,
                        Room = 81,
                        Angle = 16384
                    }
                },
                new EMTriggerFunction
                {
                    Comments = "Trigger the door and the other one in this room in case it wasn't opened before.",
                    EMType = EMType.Trigger,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 30208,
                            Y = -3328,
                            Z = 71168,
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
                                Parameter = -1
                            },
                            new EMTriggerAction
                            {
                                Parameter = 52
                            }
                        }
                    }
                },
                new EMGenerateLightFunction
                {
                    Comments = "Auto-generate vertex lighting in the new rooms.",
                    EMType = EMType.GenerateLight,
                    RoomIndices = new List<short> { -1,-2,-3 }
                }
            };

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMCopyRoomFunction
                    {
                        Comments = "Make a copy of room 27.",
                        EMType = EMType.CopyRoom,
                        Tags = new List<EMTag>
                        {
                            EMTag.PuzzleRoom
                        },
                        RoomIndex = 27,
                        LinkedLocation = new EMLocation
                        {
                            X = 32256,
                            Y = -4096,
                            Z = 65024,
                            Room = 77
                        },
                        NewLocation = new EMLocation
                        {
                            X = 30720 - 5 * 1024,
                            Y = -4096,
                            Z = 63488,
                        },
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Make a new door.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.Door1,
                        Intensity = level.Entities[56].Intensity,
                        //Flags = 1 << 9,
                        Location = new EMLocation
                        {
                            X = 32256,
                            Y = -4096,
                            Z = 68096 - 3 * 1024,
                            Room = 77,
                            Angle = 16384
                        }
                    },
                    new EMCopyRoomFunction
                    {
                        Comments = "Make a copy of room 3.",
                        EMType = EMType.CopyRoom,
                        RoomIndex = 3,
                        LinkedLocation = new EMLocation
                        {
                            X = 32256,
                            Y = -4096,
                            Z = 65024,
                            Room = 77
                        },
                        NewLocation = new EMLocation
                        {
                            X = 30720 - 6 * 1024,
                            Y = -4096,
                            Z = 63488 - 3 * 1024,
                        },
                    },
                    new EMDrainFunction
                    {
                        Comments = "Drain the new room.",
                        EMType = EMType.Drain,
                        RoomNumbers = new int[]{ -1 },
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add a boulder.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level.Entities[61].Intensity,
                        Location = new EMLocation
                        {
                            X = 26112,
                            Y = -6912 - 1024 - 256,
                            Z = 61952,
                            Room = -1,
                        },
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Trigger the boulder.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 26112,
                                Y = -4352,
                                Z = 65024,
                                Room = -1,
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
                                }
                            }
                        }
                    },
                    new EMTriggerFunction
                    {
                        Comments = "The boulder triggers the exit door.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 26112,
                                Y = -4864,
                                Z = 64000,
                                Room = -1,
                            },
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            TrigType = FDTrigType.HeavyTrigger,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 51
                                }
                            }
                        }
                    },
                    new EMReplaceTriggerActionParameterFunction
                    {
                        Comments = "Make the keys open the new door.",
                        EMType = EMType.ReplaceTriggerActionParameterFunction,
                        Action = new EMTriggerAction
                        {
                            Parameter = -2
                        },
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 32256,
                                Y = -4096,
                                Z = 69120,
                                Room = 77
                            },
                            new EMLocation
                            {
                                X = 32256,
                                Y = -4096,
                                Z = 69120 - 2048,
                                Room = 77
                            },
                        }
                    },
                    new EMHorizontalCollisionalPortalFunction
                    {
                        Comments = "Make collisional portals.",
                        EMType = EMType.HorizontalCollisionalPortal,
                        Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                        {
                            [77] = new Dictionary<short, EMLocation[]>
                            {
                                [-2] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 32256 - 1024,
                                        Y = -4096,
                                        Z = 65024,
                                    }
                                }
                            },
                            [-2] = new Dictionary<short, EMLocation[]>
                            {
                                [77] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 32256,
                                        Y = -4096,
                                        Z = 65024,
                                    }
                                },
                                [-1] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 26112,
                                        Y = -4096,
                                        Z = 65024,
                                    }
                                },
                            },
                            [-1] = new Dictionary<short, EMLocation[]>
                            {
                                [-2] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 26112 + 1024,
                                        Y = -4096,
                                        Z = 65024,
                                    }
                                }
                            },
                        }
                    },
                    new EMVisibilityPortalFunction
                    {
                        Comments = "Visibility portals.",
                        EMType = EMType.VisibilityPortal,
                        Portals = new List<EMVisibilityPortal>
                        {
                            new EMVisibilityPortal
                            {
                                BaseRoom = 77,
                                AdjoiningRoom = -2,
                                Normal = new TRVertex
                                {
                                    X = 1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = level.Rooms[77].RoomData.Vertices[level.Rooms[77].RoomData.Rectangles[19].Vertices[0]].Vertex.X,
                                        Y = -5120,
                                        Z = level.Rooms[77].RoomData.Vertices[level.Rooms[77].RoomData.Rectangles[19].Vertices[0]].Vertex.Z,
                                    },
                                    new TRVertex
                                    {
                                        X = level.Rooms[77].RoomData.Vertices[level.Rooms[77].RoomData.Rectangles[19].Vertices[1]].Vertex.X,
                                        Y = -5120,
                                        Z = level.Rooms[77].RoomData.Vertices[level.Rooms[77].RoomData.Rectangles[19].Vertices[1]].Vertex.Z,
                                    },
                                    new TRVertex
                                    {
                                        X = level.Rooms[77].RoomData.Vertices[level.Rooms[77].RoomData.Rectangles[19].Vertices[2]].Vertex.X,
                                        Y = -4096,
                                        Z = level.Rooms[77].RoomData.Vertices[level.Rooms[77].RoomData.Rectangles[19].Vertices[2]].Vertex.Z,
                                    },
                                    new TRVertex
                                    {
                                        X = level.Rooms[77].RoomData.Vertices[level.Rooms[77].RoomData.Rectangles[19].Vertices[3]].Vertex.X,
                                        Y = -4096,
                                        Z = level.Rooms[77].RoomData.Vertices[level.Rooms[77].RoomData.Rectangles[19].Vertices[3]].Vertex.Z,
                                    }
                                }
                            },
                            new EMVisibilityPortal
                            {
                                BaseRoom = -2,
                                AdjoiningRoom = 77,
                                Normal = new TRVertex
                                {
                                    X = -1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = 6 * 1024,
                                        Y = -5120,
                                        Z = 2 * 1024,
                                    },
                                    new TRVertex
                                    {
                                        X = 6 * 1024,
                                        Y = -5120,
                                        Z = 1024,
                                    },
                                    new TRVertex
                                    {
                                        X = 6 * 1024,
                                        Y = -4096,
                                        Z = 1024,
                                    },
                                    new TRVertex
                                    {
                                        X = 6 * 1024,
                                        Y = -4096,
                                        Z = 2048
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
                                        X = 1024,
                                        Y = -5120,
                                        Z = 1024,
                                    },
                                    new TRVertex
                                    {
                                        X = 1024,
                                        Y = -5120,
                                        Z = 2048,
                                    },
                                    new TRVertex
                                    {
                                        X = 1024,
                                        Y = -4096,
                                        Z = 2048,
                                    },
                                    new TRVertex
                                    {
                                        X = 1024,
                                        Y = -4096,
                                        Z = 1024,
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
                                        X = 2048,
                                        Y = -5120,
                                        Z = 5 * 1024,
                                    },
                                    new TRVertex
                                    {
                                        X = 2048,
                                        Y = -5120,
                                        Z = 4096,
                                    },
                                    new TRVertex
                                    {
                                        X = 2048,
                                        Y = -4096,
                                        Z = 4096,
                                    },
                                    new TRVertex
                                    {
                                        X = 2048,
                                        Y = -4096,
                                        Z = 5 * 1024,
                                    }
                                }
                            },

                        }
                    },
                    new EMCopyVertexAttributesFunction
                    {
                        Comments = "Normalize the lighting",
                        EMType = EMType.CopyVertexAttributes,
                        RoomMap = new Dictionary<short, TR3RoomVertex>
                        {
                            [-1] = new TR3RoomVertex
                            {
                                Lighting = level.Rooms[89].RoomData.Vertices[level.Rooms[89].RoomData.Rectangles[92].Vertices[0]].Lighting
                            },
                            [-2] = new TR3RoomVertex
                            {
                                Lighting = level.Rooms[89].RoomData.Vertices[level.Rooms[89].RoomData.Rectangles[92].Vertices[0]].Lighting
                            }
                        }
                    },
                    new EMModifyFaceFunction
                    {
                        Comments = "Adjust some faces.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                RoomNumber = -1,
                                FaceIndex = 18,
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
                                RoomNumber = 77,
                                FaceIndex = 19,
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
                                        Y = -1024
                                    },
                                    [3] = new TRVertex
                                    {
                                        Y = -1024
                                    }
                                }
                            }
                            ,
                            new EMFaceModification
                            {
                                RoomNumber = 77,
                                FaceIndex = 20,
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
                            }
                        },
                        Rotations = new EMFaceRotation[]
                        {
                            new EMFaceRotation
                            {
                                FaceIndices = new int[]{11 },
                                FaceType= EMTextureFaceType.Rectangles,
                                RoomNumber = -1,
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
                            [14] = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 18,17,16,15,4,3,2,7,10,13,14,0,5,8, 1, 6, 9, 12 }
                                },
                                [77] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 3,12,16,20 }
                                }
                            },
                            [204] = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 1,5,9,13,17}
                                }
                            },
                            [235] = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 11}
                                }
                            },
                            [89] = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 0,4,8,12,16}
                                }
                            },
                            [9] = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 18,10,2,19,11,3}
                                }
                            },
                            [11] = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 7,15,14,6}
                                }
                            },
                            [13] = new EMGeometryMap
                            {
                                [77] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 19}
                                }
                            },

                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add a trap.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = level.Entities[64].Intensity,
                        Location = new EMLocation
                        {
                            X = 27136,
                            Y = -4096,
                            Z = 65024,
                            Room = -2,
                            Angle = level.Entities[64].Angle
                        },
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Trigger it.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 27136,
                                Y = -4096,
                                Z = 65024,
                                Room = -2,
                            },
                            new EMLocation
                            {
                                X = 27136 + 1024,
                                Y = -4096,
                                Z = 65024,
                                Room = -2,
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
                                X = 27136 + 2048,
                                Y = -4096,
                                Z = 65024,
                                Room = -2,
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
                                }
                            }
                        }
                    },
                },
                new EMEditorSet
                {
                    new EMAddEntityFunction
                    {
                        Comments = "Add a trap.",
                        EMType = EMType.AddEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = level.Entities[64].Intensity,
                        Location = new EMLocation
                        {
                            X = 20992 - 1024,
                            Y = 3072 + 512,
                            Z = 68096,
                            Room = 100,
                            Angle = level.Entities[64].Angle
                        },
                    },
                    new EMAppendTriggerActionFunction
                    {
                        Comments = "Trigger it.",
                        EMType = EMType.AppendTriggerActionFunction,
                        Location = new EMLocation
                        {
                            X = 20992,
                            Y = 3200,
                            Z = 68096,
                            Room = 100
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
                        Comments = "Add some more traps.",
                        EMType = EMType.AddEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        TypeID = (short)TREntities.DartEmitter,
                        Intensity = level.Entities[13].Intensity,
                        Location = new EMLocation
                        {
                            X = 34304,
                            Y = 3328,
                            Z = 88576,
                            Room = 110
                        },
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DartEmitter,
                        Intensity = level.Entities[13].Intensity,
                        Location = new EMLocation
                        {
                            X = 30208,
                            Y = 3328,
                            Z = 90624,
                            Room = 110,
                            Angle = -32768
                        },
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DartEmitter,
                        Intensity = level.Entities[13].Intensity,
                        Location = new EMLocation
                        {
                            X = 33280,
                            Y = 3328,
                            Z = 91648,
                            Room = 110,
                            Angle = -16384
                        },
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DartEmitter,
                        Intensity = level.Entities[13].Intensity,
                        Location = new EMLocation
                        {
                            X = 31232,
                            Y = 3328,
                            Z = 87552,
                            Room = 110,
                            Angle = 16384
                        },
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Trigger them.",
                        EMType = EMType.Trigger,
                        ExpandedLocations = new EMLocationExpander
                        {
                            Location = new EMLocation
                            {
                                X = 28160,
                                Y = 3840,
                                Z = 85504,
                                Room = 110
                            },
                            ExpandX = 9,
                            ExpandZ = 1
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
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
                    }
                },
                new EMEditorSet
                {
                    new EMAddEntityFunction
                    {
                        Comments = "Add some extra clang-clangs.",
                        EMType = EMType.AddEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = level.Entities[32].Intensity,
                        Location = new EMLocation
                        {
                            X = 52736-512,
                            Y = -256,
                            Z = 17920,
                            Room = 27,
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
                }
            };

            mapping.AllWithin = new List<List<EMEditorSet>>
            {
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential lever relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 41,
                            Location = new EMLocation
                            {
                                X = 52736 + 1 * 1024,
                                Y = -3328,
                                Z = 70144 + 0 * 1024,
                                Room = 72
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential lever relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 41,
                            Location = new EMLocation
                            {
                                X = 52736 - 1 * 1024,
                                Y = -3328,
                                Z = 70144 + 0 * 1024,
                                Room = 72
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential lever relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 41,
                            Location = new EMLocation
                            {
                                X = 52736 - 2 * 1024,
                                Y = -3328,
                                Z = 70144 + 0 * 1024,
                                Room = 72
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential lever relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 41,
                            Location = new EMLocation
                            {
                                X = 52736 - 3 * 1024,
                                Y = -3328,
                                Z = 70144 + 0 * 1024,
                                Room = 71,
                                Angle = -16384
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential lever relocation.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 41,
                            Location = new EMLocation
                            {
                                X = 52736 - 3 * 1024,
                                Y = -3328,
                                Z = 70144 + 0 * 1024,
                                Room = 71,
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
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 41,
                            Location = new EMLocation
                            {
                                X = 52736 - 2 * 1024,
                                Y = -3328,
                                Z = 70144 + 0 * 1024,
                                Room = 72,
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
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 41,
                            Location = new EMLocation
                            {
                                X = 52736 - 1 * 1024,
                                Y = -3328,
                                Z = 70144 + 0 * 1024,
                                Room = 72,
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
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 41,
                            Location = new EMLocation
                            {
                                X = 52736 - 0 * 1024,
                                Y = -3328,
                                Z = 70144 + 0 * 1024,
                                Room = 72,
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
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 41,
                            Location = new EMLocation
                            {
                                X = 52736 + 1 * 1024,
                                Y = -3328,
                                Z = 70144 + 0 * 1024,
                                Room = 72,
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
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 41,
                            Location = new EMLocation
                            {
                                X = 52736 + 2 * 1024,
                                Y = -3328,
                                Z = 70144 + 0 * 1024,
                                Room = 67,
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
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 41,
                            Location = new EMLocation
                            {
                                X = 52736 + 2 * 1024,
                                Y = -3328,
                                Z = 70144 + 0 * 1024,
                                Room = 67,
                                Angle = 16384
                            }
                        }
                    },
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 52736,
                                Y = -3584,
                                Z = 68096 + 1 * 1024,
                                Room = 75,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 52736,
                                Y = -3584 - 1024,
                                Z = 68096 + 2 * 1024,
                                Room = 73,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 52736,
                                Y = -3584 - 1024,
                                Z = 68096 + 2 * 1024,
                                Room = 73,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 52736,
                                Y = -3584,
                                Z = 68096 + 1 * 1024,
                                Room = 75
                            }
                        }
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 52736,
                                Y = -3584,
                                Z = 68096 - 1 * 1024,
                                Room = 75,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 48,
                            Location = new EMLocation
                            {
                                X = 52736,
                                Y = -3584,
                                Z = 68096 - 1 * 1024,
                                Room = 75,
                                Angle = -32768
                            }
                        }
                    },
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 1 * 1024,
                                Y = 512,
                                Z = 82432 + 0 * 1024,
                                Room = 111,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 2 * 1024,
                                Y = 512,
                                Z = 82432 + 0 * 1024,
                                Room = 111,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 3 * 1024,
                                Y = 512,
                                Z = 82432 + 0 * 1024,
                                Room = 111,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 3 * 1024,
                                Y = 512,
                                Z = 82432 + 0 * 1024,
                                Room = 111,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 1 * 256,
                                Z = 82432 + 1 * 1024,
                                Room = 111,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 1 * 256,
                                Z = 82432 + 1 * 1024,
                                Room = 111,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 2 * 256,
                                Z = 82432 + 2 * 1024,
                                Room = 111,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 2 * 256,
                                Z = 82432 + 2 * 1024,
                                Room = 111
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 3 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 3 * 1024,
                                Room = 111,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 4 * 1024,
                                Room = 111,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 4 * 1024,
                                Room = 111,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 5 * 1024,
                                Room = 111,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 6 * 1024,
                                Room = 111,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 7 * 1024,
                                Room = 111,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 8 * 1024,
                                Room = 111,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 9 * 1024,
                                Room = 111,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 10 * 1024,
                                Room = 111,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 10 * 1024,
                                Room = 111
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 1 * 1024,
                                Y = 512,
                                Z = 82432 + 0 * 1024,
                                Room = 111,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 2 * 1024,
                                Y = 512,
                                Z = 82432 + 0 * 1024,
                                Room = 111,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 3 * 1024,
                                Y = 512,
                                Z = 82432 + 0 * 1024,
                                Room = 111,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 3 * 1024,
                                Y = 512,
                                Z = 82432 + 0 * 1024,
                                Room = 111,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 1 * 256,
                                Z = 82432 + 1 * 1024,
                                Room = 111,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 1 * 256,
                                Z = 82432 + 1 * 1024,
                                Room = 111,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 2 * 256,
                                Z = 82432 + 2 * 1024,
                                Room = 111,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 2 * 256,
                                Z = 82432 + 2 * 1024,
                                Room = 111
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 3 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 3 * 1024,
                                Room = 111,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 4 * 1024,
                                Room = 111,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 4 * 1024,
                                Room = 111,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 5 * 1024,
                                Room = 111,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 6 * 1024,
                                Room = 111,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 7 * 1024,
                                Room = 111,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 8 * 1024,
                                Room = 111,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 9 * 1024,
                                Room = 111,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 10 * 1024,
                                Room = 111,
                                Angle = -16384
                            }
                        }
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
                            EntityIndex = 87,
                            Location = new EMLocation
                            {
                                X = 32256 - 4 * 1024,
                                Y = 512 + 3 * 256,
                                Z = 82432 + 10 * 1024,
                                Room = 111
                            }
                        }
                    },
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
                            EntityIndex = 57,
                            Location = new EMLocation
                            {
                                X = 32256 + 0 * 1024,
                                Y = -4096,
                                Z = 67072 + 0 * 1024,
                                Room = 77,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 57,
                            Location = new EMLocation
                            {
                                X = 32256 + 2 * 1024,
                                Y = -4096,
                                Z = 67072 + 0 * 1024,
                                Room = 77,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 57,
                            Location = new EMLocation
                            {
                                X = 32256 + 5 * 1024,
                                Y = -4096,
                                Z = 67072 + 0 * 1024,
                                Room = 77,
                                Angle = -32768
                            }
                        }
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
                            EntityIndex = 57,
                            Location = new EMLocation
                            {
                                X = 32256 + 6 * 1024,
                                Y = -4096,
                                Z = 67072 + 0 * 1024,
                                Room = 77,
                                Angle = 16384
                            }
                        }
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
                            EntityIndex = 57,
                            Location = new EMLocation
                            {
                                X = 32256 + 3 * 1024,
                                Y = -4096,
                                Z = 69120 + 0 * 1024,
                                Room = 77
                            }
                        }
                    },
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
                            EntityIndex = 58,
                            Location = new EMLocation
                            {
                                X = 32256 + 0 * 1024,
                                Y = -4096,
                                Z = 69120 + 0 * 1024,
                                Room = 77
                            }
                        }
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
                            EntityIndex = 58,
                            Location = new EMLocation
                            {
                                X = 32256 + 2 * 1024,
                                Y = -4096,
                                Z = 69120 + 0 * 1024,
                                Room = 77
                            }
                        }
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
                            EntityIndex = 58,
                            Location = new EMLocation
                            {
                                X = 32256 + 4 * 1024,
                                Y = -4096,
                                Z = 69120 + 0 * 1024,
                                Room = 77
                            }
                        }
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
                            EntityIndex = 58,
                            Location = new EMLocation
                            {
                                X = 32256 + 6 * 1024,
                                Y = -4096,
                                Z = 69120 + 0 * 1024,
                                Room = 77
                            }
                        }
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
                            EntityIndex = 58,
                            Location = new EMLocation
                            {
                                X = 32256 + 6 * 1024,
                                Y = -4096,
                                Z = 69120 + 0 * 1024,
                                Room = 77,
                                Angle = 16384
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
                            Comments = "Leave the pushblock where it is.",
                            EMType = EMType.NOOP,
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential pushblock relocation.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 50,
                            TargetLocation = new EMLocation
                            {
                                X = 33280 + 2 * 1024,
                                Y = -4096,
                                Z = 66048,
                                Room = 77
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential pushblock relocation.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 50,
                            TargetLocation = new EMLocation
                            {
                                X = 33280 + 3 * 1024,
                                Y = -4096,
                                Z = 66048,
                                Room = 77
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential pushblock relocation.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 50,
                            TargetLocation = new EMLocation
                            {
                                X = 33280 + 5 * 1024,
                                Y = -4096,
                                Z = 66048,
                                Room = 77
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential pushblock relocation.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 50,
                            TargetLocation = new EMLocation
                            {
                                X = 33280 - 1024,
                                Y = -4096,
                                Z = 66048 - 1024,
                                Room = 77
                            }
                        }
                    }
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Create a puzzle area at the beginning of the level.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 33,
                            Width = 3,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 0,
                                Ceiling = 0,
                                Wall4 = 0,
                                Wall2 = 111,
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
                                    Y = -1024-0,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 1024,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -4096*2+256,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -3328,
                                Z = 1536,
                                Room = 19
                            },
                            Location = new EMLocation
                            {
                                X = 57344-1024,
                                Y = -3328-28*256,
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 9,
                            Width = 9,
                            Depth = 10,
                            Textures = new EMTextureGroup
                            {
                                Floor = 7,
                                Ceiling = 5,
                                Wall4 = 22,
                                Wall3 = 45,
                                Wall2 = 130,
                                Wall1 = 25,
                                WallAlignment = Direction.Up,
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
                                    X = 2 * 1024 + 512,
                                    Y = -768,
                                    Z = 7 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 6 * 1024 + 512,
                                    Y = -768,
                                    Z = 7 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -768,
                                    Z = 6 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 2 * 1024 + 512,
                                    Y = -768,
                                    Z = 5 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 5 * 1024 + 512,
                                    Y = -768,
                                    Z = 4 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -1024-256,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -3328,
                                Z = 1536,
                                Room = 19
                            },
                            Location = new EMLocation
                            {
                                X = 57344-4096,
                                Y = -3328-28*256-26*256,
                                Z = 1024
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> {11,21,31,51,61,71 },
                                [-3] = new List<int> { 41 },
                                [-1] = new List<int> { 23,24,25,26,27,33,34,35,36,37,43,44,45,46,47,53,54,55,56,57,63,64,65,66,67 }
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
                                    BaseRoom = 19,
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
                                            Y = -10496,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = 19,
                                    Normal = new TRVertex
                                    {
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -10496,
                                            Z = 1 * 1024,
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
                                            Y = -18176-1024+256,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -18176-1024+256,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -18176+256,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -18176+256,
                                            Z = 2 * 1024,
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
                                            X = 5 * 1024,
                                            Y = -18176-1024+256,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -18176-1024+256,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -18176+256,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -18176+256,
                                            Z = 1 * 1024,
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
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 57856,
                                            Y = -18176,
                                            Z = 2560,
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
                                            X = 57856,
                                            Y = -18176,
                                            Z = 2560-1024,
                                            Room = -1
                                        }
                                    }
                                }
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 57856,
                                Y = -10496,
                                Z = 1536,
                                Room = -2
                            },
                            Floor= new EMLocation
                            {
                                X = 57856,
                                Y = -10496+1024,
                                Z = 1536,
                                Room = 19
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Rotate some floor faces.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = -1,
                                    FaceIndices = new int[] { 58, 54, 106, 124, 152, 52, 74, 76, 78, 80, 82, 102, 104, 110, 128, 130, 132, 146, 148, 150, 60, 154, 56, 108, 126 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 2,
                                        [1] = 3,
                                        [2] = 0,
                                        [3] = 1,
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [0] = new EMGeometryMap
                                {
                                    [19] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2,5,8,11 }
                                    },
                                },

                                [1034] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 114 }
                                    },
                                },
                                [116] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 58, 54, 106, 124, 152,52, 74,76,78,80,82,102,104,110,128,130,132,146,148,150 }
                                    },
                                },
                                [1037] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        //[EMTextureFaceType.Rectangles] = new int[] { 149,61,103,57,121 }
                                        [EMTextureFaceType.Rectangles] = new int[] { 60,154,56,108,126 }
                                    },
                                },
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove faces for portals.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [19] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0 }
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0,19 }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 96 }
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door3,
                            Intensity = level.Entities[77].Intensity,
                            Location = new EMLocation
                            {
                                X = 57856,
                                Y = -18176+256,
                                Z = 2560,
                                Room = -2
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Fill the puzzle room with antipads for the door, excluding the perimeter.",
                            EMType = EMType.Trigger,
                            Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("totantipads.json"))[Level],
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Antipad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Overwrite specific tiles with normal pads.",
                            EMType = EMType.Trigger,
                            Replace= true,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 55808,
                                    Y = -18432,
                                    Z = 5632+1024,
                                    Room = -1
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
                                        Parameter = -1,
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Replace= true,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 57856,
                                    Y = -18432,
                                    Z = 6656+1024,
                                    Room = -1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 1<<1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Replace= true,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 55808,
                                    Y = -18432,
                                    Z = 7680+1024,
                                    Room = -1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 1<<2,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Replace= true,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 59904,
                                    Y = -18432,
                                    Z = 7680+1024,
                                    Room = -1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 1<<3,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Replace= true,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 57856+1024,
                                    Y = -18432,
                                    Z = 3584+2048,
                                    Room = -1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 1<<4,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
                                    }
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
                                    X = 57856,
                                    Y = -18176,
                                    Z = 2560,
                                    Room = -1
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Move the flipmap trigger to avoid camera issues.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 57856,
                                    Y = 1024,
                                    Z = 2560,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Action = FDTrigAction.FlipMap,
                                        Parameter = 0,
                                    }
                                }
                            }
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            ActionItem = new EMTriggerAction
                            {
                                Action = FDTrigAction.FlipMap,
                            },
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 57856,
                                    Y = 1024,
                                    Z = 2560-1024,
                                    Room = 19
                                }
                            }
                        },
                        new EMMoveCameraFunction
                        {
                            EMType  = EMType.MoveCamera,
                            CameraIndex = 4,
                            NewLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -18176-512+2048+1024,
                                Z = 1536,
                                Room = -2
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments=  "Move Lara into the puzzle room.",
                            EMType= EMType.MoveEntity,
                            EntityIndex = 15,
                            TargetLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -18176+1024,
                                Z = 8704+1024,
                                Room = -1,
                                Angle = -32768
                            }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments= "Generate light.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1,-2}
                        },
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "A variant of above.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 33,
                            Width = 3,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 0,
                                Ceiling = 0,
                                Wall4 = 0,
                                Wall2 = 111,
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
                                    Y = -1024-0,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 1024,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -4096*2+256,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -3328,
                                Z = 1536,
                                Room = 19
                            },
                            Location = new EMLocation
                            {
                                X = 57344-1024,
                                Y = -3328-28*256,
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 9,
                            Width = 9,
                            Depth = 10,
                            Textures = new EMTextureGroup
                            {
                                Floor = 7,
                                Ceiling = 5,
                                Wall4 = 22,
                                Wall3 = 45,
                                Wall2 = 130,
                                Wall1 = 25,
                                WallAlignment = Direction.Up,
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
                                    X = 2 * 1024 + 512,
                                    Y = -768,
                                    Z = 7 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 6 * 1024 + 512,
                                    Y = -768,
                                    Z = 7 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -768,
                                    Z = 6 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 2 * 1024 + 512,
                                    Y = -768,
                                    Z = 5 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 5 * 1024 + 512,
                                    Y = -768,
                                    Z = 4 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -1024-256,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -3328,
                                Z = 1536,
                                Room = 19
                            },
                            Location = new EMLocation
                            {
                                X = 57344-4096,
                                Y = -3328-28*256-26*256,
                                Z = 1024
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> {11,21,31,51,61,71 },
                                [-3] = new List<int> { 41 },
                                [-1] = new List<int> { 23,24,25,26,27,33,34,35,36,37,43,44,45,46,47,53,54,55,56,57,63,64,65,66,67 }
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
                                    BaseRoom = 19,
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
                                            Y = -10496,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = 19,
                                    Normal = new TRVertex
                                    {
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -10496,
                                            Z = 1 * 1024,
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
                                            Y = -18176-1024+256,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -18176-1024+256,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -18176+256,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -18176+256,
                                            Z = 2 * 1024,
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
                                            X = 5 * 1024,
                                            Y = -18176-1024+256,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -18176-1024+256,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -18176+256,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -18176+256,
                                            Z = 1 * 1024,
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
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 57856,
                                            Y = -18176,
                                            Z = 2560,
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
                                            X = 57856,
                                            Y = -18176,
                                            Z = 2560-1024,
                                            Room = -1
                                        }
                                    }
                                }
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 57856,
                                Y = -10496,
                                Z = 1536,
                                Room = -2
                            },
                            Floor= new EMLocation
                            {
                                X = 57856,
                                Y = -10496+1024,
                                Z = 1536,
                                Room = 19
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Rotate some floor faces.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = -1,
                                    FaceIndices = new int[] { 58, 54, 106, 124, 152, 52, 74, 76, 78, 80, 82, 102, 104, 110, 128, 130, 132, 146, 148, 150, 60, 154, 56, 108, 126 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 2,
                                        [1] = 3,
                                        [2] = 0,
                                        [3] = 1,
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [0] = new EMGeometryMap
                                {
                                    [19] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2,5,8,11 }
                                    },
                                },

                                [1034] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 114 }
                                    },
                                },
                                [116] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 56,58, 54, 106, 124, 152,52, 74,76,78,80,82,102,104,110,128,130,132,146,148,150 }
                                    },
                                },
                                [1037] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        //[EMTextureFaceType.Rectangles] = new int[] { 149,61,103,57,121 }
                                        [EMTextureFaceType.Rectangles] = new int[] { 126,76,106,108 }
                                    },
                                },
                                [236] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        //[EMTextureFaceType.Rectangles] = new int[] { 149,61,103,57,121 }
                                        [EMTextureFaceType.Rectangles] = new int[] { 52,60,146,154 }
                                    },
                                },
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove faces for portals.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [19] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0 }
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0,19 }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 96 }
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door3,
                            Intensity = level.Entities[77].Intensity,
                            Location = new EMLocation
                            {
                                X = 57856,
                                Y = -18176+256,
                                Z = 2560,
                                Room = -2
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
                                    TexturedFace4 = 28
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add some moving blocks.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.MovingBlock,
                            Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.MovingBlock).Intensity,
                            Location = new EMLocation
                            {
                                X = 59904,
                                Y = -17408,
                                Z = 8704,
                                Room = -1,
                                Angle = -32768
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.MovingBlock,
                            Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.MovingBlock).Intensity,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Y = -17408,
                                Z = 4608,
                                Room = -1
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.MovingBlock,
                            Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.MovingBlock).Intensity,
                            Location = new EMLocation
                            {
                                X = 59904,
                                Y = -17408,
                                Z = 4608,
                                Room = -1,
                                Angle = -16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.MovingBlock,
                            Intensity = Array.Find(level3b.Entities, e => e.TypeID == (short)TREntities.MovingBlock).Intensity,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Y = -17408,
                                Z = 8704,
                                Room = -1,
                                Angle = 16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Pads to move the blocks.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 58880,
                                    Y = -17408,
                                    Z = 5632,
                                    Room = -1
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
                                        Parameter = -4,
                                    },
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
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 58880-2048,
                                    Y = -17408,
                                    Z = 5632,
                                    Room = -1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 1<<1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -4,
                                    },
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
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 58880-1024,
                                    Y = -17408,
                                    Z = 5632+1024,
                                    Room = -1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 1<<2,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -4,
                                    },
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
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 58880-1024,
                                    Y = -17408,
                                    Z = 5632+2048,
                                    Room = -1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = (1<<3)|(1<<4),
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -4,
                                    },
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
                            Comments = "Antipad for the blocks.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 57856,
                                    Y = -17920,
                                    Z = 2560,
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
                                        Parameter = -4,
                                    },
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
                            Comments = "Hidden pads under the blocks for the door.",
                            EMType = EMType.Trigger,
                            EntityLocation = -4,
                            Trigger = new EMTrigger
                            {
                                Mask = 1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -5,
                                    },
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Hidden pads under the blocks for the door.",
                            EMType = EMType.Trigger,
                            EntityLocation = -3,
                            Trigger = new EMTrigger
                            {
                                Mask = 1<<1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -5,
                                    },
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Hidden pads under the blocks for the door.",
                            EMType = EMType.Trigger,
                            EntityLocation = -2,
                            Trigger = new EMTrigger
                            {
                                Mask = 1<<2,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -5,
                                    },
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Hidden pads under the blocks for the door.",
                            EMType = EMType.Trigger,
                            EntityLocation = -1,
                            Trigger = new EMTrigger
                            {
                                Mask = (1<<3)|(1<<4),
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -5,
                                    },
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Move the flipmap trigger to avoid camera issues.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 57856,
                                    Y = 1024,
                                    Z = 2560,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Action = FDTrigAction.FlipMap,
                                        Parameter = 0,
                                    }
                                }
                            }
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            ActionItem = new EMTriggerAction
                            {
                                Action = FDTrigAction.FlipMap,
                            },
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 57856,
                                    Y = 1024,
                                    Z = 2560-1024,
                                    Room = 19
                                }
                            }
                        },
                        new EMMoveCameraFunction
                        {
                            EMType  = EMType.MoveCamera,
                            CameraIndex = 4,
                            NewLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -18176-512+2048+1024,
                                Z = 1536,
                                Room = -2
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments=  "Move Lara into the puzzle room.",
                            EMType= EMType.MoveEntity,
                            EntityIndex = 15,
                            TargetLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -18176+1024,
                                Z = 8704+1024,
                                Room = -1,
                                Angle = -32768
                            }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments= "Generate light.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1,-2}
                        },
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Create a pushblock buffer room.",
                            EMType = EMType.CreateRoom,
                            Height = 4,
                            Width = 3,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                            },
                            AmbientLighting = level.Rooms[19].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[46].RoomData.Vertices[level.Rooms[46].RoomData.Rectangles[0].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -3328,
                                Z = 1536,
                                Room = 19
                            },
                            Location = new EMLocation
                            {
                                X = 57856 - 1024 - 512,
                                Y = -17408-3072,
                                Z = 6656 - 1024 - 512
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            Comments = "Another variant of above.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 33,
                            Width = 3,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 0,
                                Ceiling = 0,
                                Wall4 = 0,
                                Wall2 = 111,
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
                                    Y = -1024-0,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 1024,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -4096*2+256,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -3328,
                                Z = 1536,
                                Room = 19
                            },
                            Location = new EMLocation
                            {
                                X = 57344-1024,
                                Y = -3328-28*256,
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 13,
                            Width = 9,
                            Depth = 10,
                            Textures = new EMTextureGroup
                            {
                                Floor = 7,
                                Ceiling = 5,
                                Wall4 = 22,
                                Wall3 = 45,
                                Wall2 = 130,
                                Wall1 = 25,
                                WallAlignment = Direction.Up,
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
                                    X = 2 * 1024 + 512,
                                    Y = -768,
                                    Z = 7 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 6 * 1024 + 512,
                                    Y = -768,
                                    Z = 7 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -768,
                                    Z = 6 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 2 * 1024 + 512,
                                    Y = -768,
                                    Z = 5 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 5 * 1024 + 512,
                                    Y = -768,
                                    Z = 4 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -1024-256,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -3328,
                                Z = 1536,
                                Room = 19
                            },
                            Location = new EMLocation
                            {
                                X = 57344-4096,
                                Y = -3328-28*256-26*256,
                                Z = 1024
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> {11,21,31,51,61,71 },
                                [-3] = new List<int> { 41 },
                                [-1] = new List<int> { 23,24,25,26,27,33,34,35,36,37,43,44,45,46,47,53,54,55,56,57,63,64,65,66,67 }
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [4] = new List<int>
                                {
                                    12,13,14,15,16,17,18,
                                    22,23,24,25,26,27,28,
                                    32,33,34,35,36,37,38,
                                    41,42,43,44,46,47,48,
                                    52,53,54,55,56,57,58,
                                    62,63,64,65,66,67,68,
                                    72,73,74,75,76,77,78
                                }
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 4,
                            Width = 9,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 7,
                                Ceiling = 7,
                                Wall4 = 7
                            },
                            AmbientLighting = level.Rooms[19].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[46].RoomData.Vertices[level.Rooms[46].RoomData.Rectangles[0].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -3328,
                                Z = 1536,
                                Room = 19
                            },
                            Location = new EMLocation
                            {
                                X = 57344-4096,
                                Y = -3328-28*256-26*256,
                                Z = 1024+4096+2048+3072
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
                                    BaseRoom = 19,
                                    AdjoiningRoom = -3,
                                    Normal = new TRVertex
                                    {
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -10496,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -3,
                                    AdjoiningRoom = 19,
                                    Normal = new TRVertex
                                    {
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -10496,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -10496,
                                            Z = 1 * 1024,
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
                                            Y = -18176-1024+256,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -18176-1024+256,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -18176+256,
                                            Z = 2 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -18176+256,
                                            Z = 2 * 1024,
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
                                            X = 5 * 1024,
                                            Y = -18176-1024+256,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -18176-1024+256,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -18176+256,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -18176+256,
                                            Z = 1 * 1024,
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
                                            X = 57856,
                                            Y = -18176,
                                            Z = 2560,
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
                                            X = 57856,
                                            Y = -18176,
                                            Z = 2560-1024,
                                            Room = -2
                                        }
                                    }
                                }
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 57856,
                                Y = -10496,
                                Z = 1536,
                                Room = -3
                            },
                            Floor= new EMLocation
                            {
                                X = 57856,
                                Y = -10496+1024,
                                Z = 1536,
                                Room = 19
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 57856,
                                Y = -20480,
                                Z = 6656,
                                Room = -4
                            },
                            Floor= new EMLocation
                            {
                                X = 57856,
                                Y = -20480+1024,
                                Z = 6656,
                                Room = -2
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Rotate some floor faces.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = -2,
                                    FaceIndices = new int[] { 52,54,56,58,60,74,76,78,80,82,102,104,106,112,114,128,130,132,134,136,150,152,154,156,158 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 2,
                                        [1] = 3,
                                        [2] = 0,
                                        [3] = 1,
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [0] = new EMGeometryMap
                                {
                                    [19] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2,5,8,11 }
                                    },
                                },
                                [5] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 108,109,110,111 }
                                    },
                                },

                                [1034] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 118 }
                                    },
                                },
                                [14] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 52,54,56,58,60,74,76,78,80,82,102,104,106,112,114,128,130,132,134,136,150,152,154,156,158 }
                                    },
                                },
                                [1037] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 130,76,80,134 }
                                    },
                                },
                                [10] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 114,102,97}
                                    },
                                },
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove faces for portals.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [19] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0 }
                                },
                                [-3] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0,19 }
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 96 }
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door3,
                            Intensity = level.Entities[77].Intensity,
                            Location = new EMLocation
                            {
                                X = 57856,
                                Y = -18176+256,
                                Z = 2560,
                                Room = -3
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a pushblock.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.PushBlock1,
                            Flags = level4.Entities[20].Flags,
                            Intensity = level4.Entities[20].Intensity,
                            Location = new EMLocation
                            {
                                X = 57856,
                                Y = -17408-4096,
                                Z = 6656,
                                Room = -4
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a boulder.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.RollingBall,
                            Location = new EMLocation
                            {
                                X = 60928,
                                Y = -17152,
                                Z = 11776,
                                Room = -1,
                                Angle= -16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Pads to trigger the boulder.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 56832,
                                    Y = -17408,
                                    Z = 5632,
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
                                        Parameter = -1,
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
                                    X = 56832+2048,
                                    Y = -17408,
                                    Z = 5632,
                                    Room = -2
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 1<<1,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
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
                                    X = 56832,
                                    Y = -17408,
                                    Z = 5632+2048,
                                    Room = -2
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 1<<2,
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
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
                                    X = 56832+2048,
                                    Y = -17408,
                                    Z = 5632+2048,
                                    Room = -2
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = (1<<3)|(1<<4),
                                TrigType = FDTrigType.Pad,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Heavy trigger for the boulder to activate the pushblock.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 54784,
                                    Y = -17152,
                                    Z = 11776,
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
                                        Parameter = -2,
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Pushblock triggers the door.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 56832+1024,
                                    Y = -17408,
                                    Z = 5632-1024,
                                    Room = -2
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 1|(1<<1)|(1<<2),
                                TrigType = FDTrigType.HeavyTrigger,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -3,
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
                                    X = 56832+1024,
                                    Y = -17408,
                                    Z = 5632-1024+4096,
                                    Room = -2
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = (1<<3)|(1<<4),
                                TrigType = FDTrigType.HeavyTrigger,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -3,
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Move the flipmap trigger to avoid camera issues.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 57856,
                                    Y = 1024,
                                    Z = 2560,
                                    Room = 20
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Action = FDTrigAction.FlipMap,
                                        Parameter = 0,
                                    }
                                }
                            }
                        },
                        new EMRemoveTriggerActionFunction
                        {
                            EMType = EMType.RemoveTriggerAction,
                            ActionItem = new EMTriggerAction
                            {
                                Action = FDTrigAction.FlipMap,
                            },
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 57856,
                                    Y = 1024,
                                    Z = 2560-1024,
                                    Room = 19
                                }
                            }
                        },
                        new EMMoveCameraFunction
                        {
                            EMType  = EMType.MoveCamera,
                            CameraIndex = 4,
                            NewLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -18176-512+2048+1024,
                                Z = 1536,
                                Room = -3
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments=  "Move Lara into the puzzle room.",
                            EMType= EMType.MoveEntity,
                            EntityIndex = 15,
                            TargetLocation = new EMLocation
                            {
                                X = 57856,
                                Y = -18176+1024,
                                Z = 8704+1024,
                                Room = -2,
                                Angle = -32768
                            }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments= "Generate light.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -2,-3}
                        },
                    },
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
                            Comments = "Remove the default lever texture in room 23.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[23].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                {
                                    [23] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3 }
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
                                EntityIndex = 17,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = 3584,
                                    Z = 15872,
                                    Room = 23,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[23].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [23] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 17,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = 3584,
                                    Z = 15872 + 1 * 1024,
                                    Room = 23,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[23].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [23] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 17,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = 3584,
                                    Z = 15872 + 2 * 1024,
                                    Room = 23,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[23].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [23] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 9 }
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
                                EntityIndex = 17,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = 3584,
                                    Z = 15872 + 3 * 1024,
                                    Room = 22,
                                    Angle = -16384
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 17,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = 3584,
                                    Z = 15872 + 3 * 1024,
                                    Room = 22
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 17,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = 3584,
                                    Z = 15872 + 3 * 1024,
                                    Room = 22,
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
                                EntityIndex = 17,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = 3584,
                                    Z = 15872 + 2 * 1024,
                                    Room = 23,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[23].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [23] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 12 }
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
                                EntityIndex = 17,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = 3584,
                                    Z = 15872 + 1 * 1024,
                                    Room = 23,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[23].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [23] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 17,
                                Location = new EMLocation
                                {
                                    X = 57856,
                                    Y = 3584,
                                    Z = 15872,
                                    Room = 23,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[23].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [23] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 10 }
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
                            Comments = "Remove the default lever texture in room 21 and 52.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[21].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                {
                                    [21] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                    },
                                    [52] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 56832,
                                    Y = -256,
                                    Z = 15872 + 1024,
                                    Room = 21,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[21].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 6 }
                                        },
                                        [52] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 56832,
                                    Y = -256,
                                    Z = 15872 + 2 * 1024,
                                    Room = 21
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[21].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 10 }
                                        },
                                        [52] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 56832 + 2 * 1024,
                                    Y = -256,
                                    Z = 15872 + 2 * 1024,
                                    Room = 21
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[21].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 34 }
                                        },
                                        [52] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 31 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 56832 + 2 * 1024,
                                    Y = -256,
                                    Z = 15872 + 2 * 1024,
                                    Room = 21,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[21].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 37 }
                                        },
                                        [52] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 34 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 56832 + 2 * 1024,
                                    Y = -256,
                                    Z = 15872 + 1 * 1024,
                                    Room = 21,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[21].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 36 }
                                        },
                                        [52] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 33 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 56832 + 2 * 1024,
                                    Y = -256,
                                    Z = 15872 + 0 * 1024,
                                    Room = 21,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[21].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 35 }
                                        },
                                        [52] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 32 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 56832 + 2 * 1024,
                                    Y = -256,
                                    Z = 15872 + 0 * 1024,
                                    Room = 21,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[21].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 27 }
                                        },
                                        [52] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 24 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 56832 + 0 * 1024,
                                    Y = -256,
                                    Z = 15872 + 0 * 1024,
                                    Room = 21,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[21].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        },
                                        [52] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
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
                            Comments = "Remove the default lever texture in room 28.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[28].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                {
                                    [28] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2 }
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
                                EntityIndex = 20,
                                Location = new EMLocation
                                {
                                    X = 42496 + 0 * 1024,
                                    Y = -6144,
                                    Z = 13824 + 0 * 1024,
                                    Room = 28,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[28].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 20,
                                Location = new EMLocation
                                {
                                    X = 42496 + 1 * 1024,
                                    Y = -6144,
                                    Z = 13824 + 0 * 1024,
                                    Room = 28,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[28].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 20,
                                Location = new EMLocation
                                {
                                    X = 42496 + 1 * 1024,
                                    Y = -6144,
                                    Z = 13824 + 0 * 1024,
                                    Room = 28
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[28].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 8 }
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
                                EntityIndex = 20,
                                Location = new EMLocation
                                {
                                    X = 42496 + 0 * 1024,
                                    Y = -6144,
                                    Z = 13824 + 0 * 1024,
                                    Room = 28
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[28].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 4 }
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
                            Comments = "Remove the default lever texture in room 49.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[49].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                {
                                    [49] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 14 }
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
                                EntityIndex = 33,
                                Location = new EMLocation
                                {
                                    X = 45568 + 0 * 1024,
                                    Y = -6144,
                                    Z = 71168 + 0 * 1024,
                                    Room = 49,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[49].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [49] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 33,
                                Location = new EMLocation
                                {
                                    X = 45568 + 0 * 1024,
                                    Y = -6144,
                                    Z = 71168 + 0 * 1024,
                                    Room = 49,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[49].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [49] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 33,
                                Location = new EMLocation
                                {
                                    X = 45568 + 0 * 1024,
                                    Y = -6144,
                                    Z = 71168 - 1 * 1024,
                                    Room = 49,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[49].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [49] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 15 }
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
                                EntityIndex = 33,
                                Location = new EMLocation
                                {
                                    X = 45568 + 0 * 1024,
                                    Y = -6144,
                                    Z = 71168 - 1 * 1024,
                                    Room = 49,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[49].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [49] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 10 }
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
                            Comments = "Remove the default lever texture in room 94.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[94].RoomData.Rectangles[94].Texture] = new EMGeometryMap
                                {
                                    [94] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 108 }
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
                                EntityIndex = 75,
                                Location = new EMLocation
                                {
                                    X = 12800 + 0 * 1024,
                                    Z = 81408 + 0 * 1024,
                                    Room = 94,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[94].RoomData.Rectangles[108].Texture] = new EMGeometryMap
                                    {
                                        [94] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 116 }
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
                                EntityIndex = 75,
                                Location = new EMLocation
                                {
                                    X = 12800 + 0 * 1024,
                                    Z = 81408 - 1 * 1024,
                                    Room = 94,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[94].RoomData.Rectangles[108].Texture] = new EMGeometryMap
                                    {
                                        [94] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 114 }
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
                                EntityIndex = 75,
                                Location = new EMLocation
                                {
                                    X = 12800 + 0 * 1024,
                                    Z = 81408 - 2 * 1024,
                                    Room = 94,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[94].RoomData.Rectangles[108].Texture] = new EMGeometryMap
                                    {
                                        [94] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 112 }
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
                                EntityIndex = 75,
                                Location = new EMLocation
                                {
                                    X = 12800 - 5 * 1024,
                                    Z = 81408 - 0 * 1024,
                                    Room = 94
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[94].RoomData.Rectangles[108].Texture] = new EMGeometryMap
                                    {
                                        [94] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 42 }
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
                            Comments = "Remove the default lever texture in room 108.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[108].RoomData.Rectangles[28].Texture] = new EMGeometryMap
                                {
                                    [108] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 15 }
                                    }
                                },
                                [level.Rooms[108].RoomData.Rectangles[27].Texture] = new EMGeometryMap
                                {
                                    [108] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 14 }
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
                                EntityIndex = 79,
                                Location = new EMLocation
                                {
                                    X = 29184 + 1 * 1024,
                                    Y = 5632,
                                    Z = 79360 + 0 * 1024,
                                    Room = 108
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[108].RoomData.Rectangles[15].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 28 }
                                        }
                                    },
                                    [level.Rooms[108].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 27 }
                                        }
                                    },
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 79,
                                Location = new EMLocation
                                {
                                    X = 29184 + 2 * 1024,
                                    Y = 5632,
                                    Z = 79360 - 1 * 1024,
                                    Room = 108,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[108].RoomData.Rectangles[15].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 43 }
                                        }
                                    },
                                    [level.Rooms[108].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 42 }
                                        }
                                    },
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 79,
                                Location = new EMLocation
                                {
                                    X = 29184 + 2 * 1024,
                                    Y = 5632,
                                    Z = 79360 - 2 * 1024,
                                    Room = 108,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[108].RoomData.Rectangles[15].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 41 }
                                        }
                                    },
                                    [level.Rooms[108].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 40 }
                                        }
                                    },
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 79,
                                Location = new EMLocation
                                {
                                    X = 29184 + 2 * 1024,
                                    Y = 5632,
                                    Z = 79360 - 2 * 1024,
                                    Room = 108,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[108].RoomData.Rectangles[15].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 32 }
                                        }
                                    },
                                    [level.Rooms[108].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 31 }
                                        }
                                    },
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 79,
                                Location = new EMLocation
                                {
                                    X = 29184 + 1 * 1024,
                                    Y = 5632,
                                    Z = 79360 - 2 * 1024,
                                    Room = 108,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[108].RoomData.Rectangles[15].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 19 }
                                        }
                                    },
                                    [level.Rooms[108].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 18 }
                                        }
                                    },
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 79,
                                Location = new EMLocation
                                {
                                    X = 29184 + 0 * 1024,
                                    Y = 5632,
                                    Z = 79360 - 2 * 1024,
                                    Room = 108,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[108].RoomData.Rectangles[15].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 5 }
                                        }
                                    },
                                    [level.Rooms[108].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 4 }
                                        }
                                    },
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 79,
                                Location = new EMLocation
                                {
                                    X = 29184 + 0 * 1024,
                                    Y = 5632,
                                    Z = 79360 - 2 * 1024,
                                    Room = 108,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[108].RoomData.Rectangles[15].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        }
                                    },
                                    [level.Rooms[108].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                        }
                                    },
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 79,
                                Location = new EMLocation
                                {
                                    X = 29184 + 0 * 1024,
                                    Y = 5632,
                                    Z = 79360 - 1 * 1024,
                                    Room = 108,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[108].RoomData.Rectangles[15].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 9 }
                                        }
                                    },
                                    [level.Rooms[108].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 8 }
                                        }
                                    },
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 79,
                                Location = new EMLocation
                                {
                                    X = 29184 + 0 * 1024,
                                    Y = 5632,
                                    Z = 79360 - 0 * 1024,
                                    Room = 108,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[108].RoomData.Rectangles[15].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 13 }
                                        }
                                    },
                                    [level.Rooms[108].RoomData.Rectangles[14].Texture] = new EMGeometryMap
                                    {
                                        [108] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 12 }
                                        }
                                    },
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
                            Comments = "Remove the default block floor textures in room 77.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[77].RoomData.Rectangles[114].Texture] = new EMGeometryMap
                                {
                                    [77] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 90,41,94,45 }
                                    }
                                },

                            }
                        },
                    },
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the first block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the second block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 62976,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the third block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the fourth block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 62976,
                                    Room = 77
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[77].RoomData.Rectangles[90].Texture] = new EMGeometryMap
                                    {
                                        [77] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 68,92,64,43 }
                                        }
                                    },

                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the first block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 32256,
                                    Y = -4096,
                                    Z = 60928,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the second block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 32256,
                                    Y = -4096,
                                    Z = 60928 + 2 * 1024,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the third block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 32256,
                                    Y = -4096,
                                    Z = 60928 + 1024,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the fourth block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 32256,
                                    Y = -4096,
                                    Z = 60928 + 3 * 1024,
                                    Room = 77
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[77].RoomData.Rectangles[90].Texture] = new EMGeometryMap
                                    {
                                        [77] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 0,6,9,13 }
                                        }
                                    },

                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the first block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 36352,
                                    Y = -4096,
                                    Z = 65024,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the second block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 37376,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the third block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the fourth block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 65024,
                                    Room = 77
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[77].RoomData.Rectangles[90].Texture] = new EMGeometryMap
                                    {
                                        [77] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 140,120,96,68 }
                                        }
                                    },

                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the first block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304,
                                    Y = -4096,
                                    Z = 67072 + 1024,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the second block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304 + 3 * 1024,
                                    Y = -4096,
                                    Z = 67072 + 1024,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the third block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304 + 1024,
                                    Y = -4096,
                                    Z = 67072 + 1024,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the fourth block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304 + 2 * 1024,
                                    Y = -4096,
                                    Z = 67072 + 1024,
                                    Room = 77
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[77].RoomData.Rectangles[90].Texture] = new EMGeometryMap
                                    {
                                        [77] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 152,126,104,80 }
                                        }
                                    },
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Adjust the texture below the clang-clang room.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 77,
                                        FaceIndex = 8,
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
                                            }
                                        }
                                    }
                                }
                            },
                            new EMFloorFunction
                            {
                                Comments = "Make a step for the clang-clang room.",
                                EMType = EMType.Floor,
                                Clicks = -1,
                                Location = new EMLocation
                                {
                                    X = 32256,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                SideTexture = 91,
                                Flags = 13
                            },
                            new EMMoveEntityFunction
                            {
                                Comments = "Undo the door shift.",
                                EMType = EMType.MoveEntity,
                                EntityIndex = 56,
                                TargetLocation = new EMLocation
                                {
                                    X = 32256,
                                    Y = -6400 + 256,
                                    Z = 61952,
                                    Room = 77,
                                    Angle = 16384
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the first block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304,
                                    Y = -4096,
                                    Z = 61952 + 2048,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the second block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304 + 1024,
                                    Y = -4096,
                                    Z = 61952 + 1024,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the third block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the fourth block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304,
                                    Y = -4096,
                                    Z = 61952 + 1024,
                                    Room = 77
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[77].RoomData.Rectangles[90].Texture] = new EMGeometryMap
                                    {
                                        [77] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 64,66,68,92 }
                                        }
                                    },

                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the first block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304,
                                    Y = -4096,
                                    Z = 61952 + 1024,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the second block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 61952,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304 + 1024,
                                    Y = -4096,
                                    Z = 61952 + 1024,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the third block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 33280,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304 - 1024,
                                    Y = -4096,
                                    Z = 61952 + 1024,
                                    Room = 77
                                },
                            },
                            new EMMoveTriggerFunction
                            {
                                Comments = "Move the fourth block heavy trigger.",
                                EMType = EMType.MoveTrigger,
                                BaseLocation = new EMLocation
                                {
                                    X = 35328,
                                    Y = -4096,
                                    Z = 64000,
                                    Room = 77
                                },
                                NewLocation = new EMLocation
                                {
                                    X = 34304,
                                    Y = -4096,
                                    Z = 61952 + 2048,
                                    Room = 77
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[77].RoomData.Rectangles[90].Texture] = new EMGeometryMap
                                    {
                                        [77] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 43,66,68,92 }
                                        }
                                    },

                                }
                            },
                        },
                    }
                }
            };

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();

            mapping.RewardEntities = new List<int> { 0, 1, 7, 8 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 35328,
                            Y = 3840,
                            Z = 96768
                        },
                        new Location
                        {
                            X = 35328,
                            Y = 3840,
                            Z = 95744
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door1,
                            X = 35328,
                            Y = 3840,
                            Z = 93696,
                            Angle = -32768,
                            Intensity = 6400,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 35574,
                            Y = 2581,
                            Z = 84215,
                            Room = 110
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
                                X = 35328,
                                Y = 3840,
                                Z = 93696,
                                Room = 110
                            },
                            NewLocation = new EMLocation
                            {
                                X = 33792,
                                Y = 3840,
                                Z = 93184,
                            }
                        },
                        new EMDrainFunction
                        {
                            EMType = EMType.Drain,
                            RoomNumbers = new int[] { -1 }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [110] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 35328,
                                            Y = 3840,
                                            Z = 94720,
                                            Room = 110
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [110] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 35328,
                                            Y = 3840,
                                            Z = 93696,
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
                                    BaseRoom = 110,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 8192,
                                            Y = 2816,
                                            Z = 13312
                                        },
                                        new TRVertex
                                        {
                                            X = 9216,
                                            Y = 2816,
                                            Z = 13312
                                        },
                                        new TRVertex
                                        {
                                            X = 9216,
                                            Y = 3840,
                                            Z = 13312
                                        },
                                        new TRVertex
                                        {
                                            X = 8192,
                                            Y = 3840,
                                            Z = 13312
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 110,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = 2816,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 2816,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 3840,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = 3840,
                                            Z = 1024
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
                                    RoomNumber = 110,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 311,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
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
                                    RoomNumber = -1,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = -1024,
                                            Z = 3 * 1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = 1024,
                                            Z = 3 * 1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = 1024,
                                            Z = 3 * 1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = -1024,
                                            Z = 3 * 1024
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
                                    FaceIndices = new int[]{ 2, 6, 9,10,11,12 },
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
                                    RoomNumber = -1,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[]{ 1,5,8 },
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
                                [7] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0, 4, 7 }
                                    }
                                },
                                [222] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 1, 5, 8 }
                                    }
                                },
                                [116] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2, 9, 10, 12 }
                                    }
                                },
                                [231] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3, 6, 11 }
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [110] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 309 }
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

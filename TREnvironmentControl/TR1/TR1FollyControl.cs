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
    public class TR1FollyControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.FOLLY;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);
            TRLevel level1 = GetTR1Level(TRLevelNames.CAVES);
            TRLevel level3b = GetTR1Level(TRLevelNames.QUALOPEC);
            TRLevel level7b = GetTR1Level(TRLevelNames.TIHOCAN);

            TRRoom room0 = level.Rooms[0];
            TRRoom room41 = level.Rooms[41];
            mapping.NonPurist = new EMEditorSet
            {
                new EMRemoveTriggerActionFunction
                {
                    Comments = "Remove the music action from the end keyholes - they don't work because of the mask so just kill the ambient track.",
                    EMType = EMType.RemoveTriggerAction,
                    ActionItem = new EMTriggerAction
                    {
                        Action = FDTrigAction.PlaySoundtrack,
                        Parameter = 15
                    },
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 31232,
                            Y = 23296,
                            Z = 40448,
                            Room = 42
                        },
                        new EMLocation
                        {
                            X = 31232,
                            Y = 23296,
                            Z = 40448 + 1024,
                            Room = 42
                        },
                        new EMLocation
                        {
                            X = 31232,
                            Y = 23296,
                            Z = 40448 + 2048,
                            Room = 42
                        },
                        new EMLocation
                        {
                            X = 31232,
                            Y = 23296,
                            Z = 40448 + 3072,
                            Room = 42
                        }
                    }
                },
                new EMTriggerFunction
                {
                    Comments = "Add it instead to the hidden boulder room so it activates when all keys are used.",
                    EMType = EMType.Trigger,
                    Trigger = new EMTrigger
                    {
                        Mask = 31,
                        TrigType = FDTrigType.HeavyTrigger,
                        Actions = new List<EMTriggerAction>
                        {
                            new EMTriggerAction
                            {
                                Action = FDTrigAction.PlaySoundtrack,
                                Parameter = 15
                            }
                        }
                    },
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 28160,
                            Y = 22528,
                            Z = 44544,
                            Room = 54
                        }
                    }
                },
                
                // Return path
                new EMCreateRoomFunction
                {
                    Comments = "Make a return path available.",
                    EMType = EMType.CreateRoom,
                    Height = 18,
                    Width = 4,
                    Depth = 4,
                    Textures = new EMTextureGroup
                    {
                        Floor = 18,
                        Ceiling = 18,
                        Wall4 = 7,
                        Wall3 = 122,
                        Wall2 = 57,
                        Wall1 = 20
                    },
                    AmbientLighting = room41.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room41.RoomData.Vertices[room41.RoomData.Rectangles[24].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -3072,
                            Z = 2 * 1024 + 512,
                            Intensity1 = room41.Lights[0].Intensity,
                            Fade1 = room41.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 33280,
                        Y = 11008,
                        Z = 41472,
                        Room = 41
                    },
                    Location = new EMLocation
                    {
                        X = 32768 - 3072,
                        Y = 11008,
                        Z = 40960 - 2048,
                    },
                    FloorHeights = new Dictionary<sbyte, List<int>>
                    {
                        [-7] = new List<int> { 6 },
                        [-14] = new List<int> { 5 },
                        [-127] = new List<int> { 9 },
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
                        Floor = 18,
                        Ceiling = 18,
                        Wall4 = 7,
                        Wall3 = 122,
                        Wall2 = 57,
                        Wall1 = 20
                    },
                    AmbientLighting = room41.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room41.RoomData.Vertices[room41.RoomData.Rectangles[24].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -3072,
                            Z = 2 * 1024 + 512,
                            Intensity1 = room41.Lights[0].Intensity,
                            Fade1 = room41.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 31232,
                        Y = 7424,
                        Z = 40448,
                        Room = -1
                    },
                    Location = new EMLocation
                    {
                        X = 30720 - 3072,
                        Y = 7424,
                        Z = 39936 - 1024,
                    },
                    FloorHeights = new Dictionary<sbyte, List<int>>
                    {
                        [-7] = new List<int> { 6 },
                        [-14] = new List<int> { 10 },
                    }
                },
                new EMCreateRoomFunction
                {
                    EMType = EMType.CreateRoom,
                    Height = 14,
                    Width = 6,
                    Depth = 5,
                    Textures = new EMTextureGroup
                    {
                        Floor = 18,
                        Ceiling = 18,
                        Wall4 = 7,
                        Wall3 = 122,
                        Wall2 = 57,
                        Wall1 = 58
                    },
                    AmbientLighting = room41.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room41.RoomData.Vertices[room41.RoomData.Rectangles[24].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 3*1024 + 512,
                            Y = -3072,
                            Z = 2 * 1024 + 512,
                            Intensity1 = room41.Lights[0].Intensity,
                            Fade1 = room41.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 30208,
                        Y = 3840,
                        Z = 41472,
                        Room = -1
                    },
                    Location = new EMLocation
                    {
                        X = 29696 - 4096,
                        Y = 3840,
                        Z = 40960,
                    },
                    FloorHeights = new Dictionary<sbyte, List<int>>
                    {
                        [-4] = new List<int> { 13 },
                        [-10] = new List<int> { 8 },
                        [-127] = new List<int> { 6,16,18 },
                    }
                },
                new EMCreateRoomFunction
                {
                    EMType = EMType.CreateRoom,
                    Height = 8,
                    Width = 4,
                    Depth = 5,
                    Textures = new EMTextureGroup
                    {
                        Floor = 18,
                        Ceiling = 18,
                        Wall4 = 7,
                        Wall3 = 122,
                        Wall2 = 57,
                        Wall1 = 20
                    },
                    AmbientLighting = room41.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room41.RoomData.Vertices[room41.RoomData.Rectangles[24].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 2*1024 + 512,
                            Y = -1280,
                            Z = 3 * 1024 + 512,
                            Intensity1 = room41.Lights[0].Intensity,
                            Fade1 = room41.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 27136,
                        Y = 1280,
                        Z = 44544,
                        Room = -1
                    },
                    Location = new EMLocation
                    {
                        X = 26624 - 2048,
                        Y = 1280,
                        Z = 44032,
                    },
                    FloorHeights = new Dictionary<sbyte, List<int>>
                    {
                        [-1] = new List<int> { 12 },
                        [-2] = new List<int> { 13 },
                        [-3] = new List<int> { 8 },
                        [-127] = new List<int> { 6,7 },
                    }
                },
                new EMCreateRoomFunction
                {
                    EMType = EMType.CreateRoom,
                    Height = 6,
                    Width = 3,
                    Depth = 6,
                    Textures = new EMTextureGroup
                    {
                        Floor = 0,
                        Ceiling = 18,
                        Wall4 = 7,
                        Wall3 = 122,
                        Wall2 = 57,
                        Wall1 = 20
                    },
                    AmbientLighting = room41.AmbientIntensity,
                    DefaultVertex = new EMRoomVertex
                    {
                        Lighting = room0.RoomData.Vertices[room0.RoomData.Rectangles[33].Vertices[1]].Lighting
                    },
                    Lights = new EMRoomLight[]
                    {
                        new EMRoomLight
                        {
                            X = 1*1024 + 512,
                            Y = -768,
                            Z = 3 * 1024 + 512,
                            Intensity1 = room41.Lights[0].Intensity,
                            Fade1 = room41.Lights[0].Fade,
                        }
                    },
                    LinkedLocation = new EMLocation
                    {
                        X = 26112,
                        Y = 512,
                        Z = 47616,
                        Room = -1
                    },
                    Location = new EMLocation
                    {
                        X = 25600 - 2048,
                        Y = 512,
                        Z = 47104 - 4096,
                    },
                    FloorHeights = new Dictionary<sbyte, List<int>>
                    {
                        [-1] = new List<int> { 10 },
                        [-2] = new List<int> { 9,8,7 },
                        //[-3] = new List<int> { 8 },
                        //[-127] = new List<int> { 6,7 },
                    }
                },
                new EMVisibilityPortalFunction
                {
                    EMType = EMType.VisibilityPortal,
                    Portals = new List<EMVisibilityPortal>
                    {
                        new EMVisibilityPortal
                        {
                            BaseRoom = 41,
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
                                    Y = 11008 - 6*256,
                                    Z = 6 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 11008 - 6*256,
                                    Z = 7 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 11008,
                                    Z = 7 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 11008,
                                    Z = 6 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = -5,
                            AdjoiningRoom = 41,
                            Normal = new TRVertex
                            {
                                X = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 11008 - 6*256,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 11008 - 6*256,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 11008,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 11008,
                                    Z = 3 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = -5,
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
                                    Y = 7424 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 7424 - 1024,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 7424,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 7424,
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
                                X = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 7424 - 1024,
                                    Z = 2 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 7424 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 7424,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 7424,
                                    Z = 2 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = -4,
                            AdjoiningRoom = -3,
                            Normal = new TRVertex
                            {
                                Z = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 3840 - 1024,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 3840 - 1024,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 3840,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 3840,
                                    Z = 3 * 1024
                                }
                            }
                        },
                        new EMVisibilityPortal
                        {
                            BaseRoom = -3,
                            AdjoiningRoom = -4,
                            Normal = new TRVertex
                            {
                                Z = 1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 5 * 1024,
                                    Y = 3840 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 4 * 1024,
                                    Y = 3840 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 4 * 1024,
                                    Y = 3840,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 5 * 1024,
                                    Y = 3840,
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
                                    Y = 1280 - 1024,
                                    Z = 4 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 1280 - 1024,
                                    Z = 4 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 1280,
                                    Z = 4 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 1280,
                                    Z = 4 * 1024
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
                                    Y = 1280 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 1280 - 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 1280,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 1280,
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
                                    Y = 256 - 1024,
                                    Z = 3 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 256 - 1024,
                                    Z = 4 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 256,
                                    Z = 4 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = 256,
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
                                X = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 256 - 1024,
                                    Z = 5 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 256 - 1024,
                                    Z = 4 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = 256,
                                    Z = 4 * 1024
                                },
                                new TRVertex
                                {
                                    X = 3 * 1024,
                                    Y = 256,
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
                                Z = 1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Z = 1 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
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
                                Z = -1
                            },
                            Vertices = new TRVertex[]
                            {
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Y = -1024,
                                    Z = 10 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Y = -1024,
                                    Z = 10 * 1024
                                },
                                new TRVertex
                                {
                                    X = 2 * 1024,
                                    Z = 10 * 1024
                                },
                                new TRVertex
                                {
                                    X = 1 * 1024,
                                    Z = 10 * 1024
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
                        [41] = new Dictionary<short, EMLocation[]>
                        {
                            [-5] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 33280 - 1024,
                                    Y = 11008,
                                    Z = 41472,
                                    Room = 41
                                }
                            }
                        },
                        [-5] = new Dictionary<short, EMLocation[]>
                        {
                            [41] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 33280,
                                    Y = 11008,
                                    Z = 41472,
                                    Room = -5
                                }
                            },
                            [-4] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 31232 - 1024,
                                    Y = 7424,
                                    Z = 40448,
                                    Room = -5
                                }
                            },
                        },
                        [-4] = new Dictionary<short, EMLocation[]>
                        {
                            [-5] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 31232,
                                    Y = 7424,
                                    Z = 40448,
                                    Room = -4
                                }
                            },
                            [-3] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 30208,
                                    Y = 3840,
                                    Z = 41472 + 1024,
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
                                    X = 30208,
                                    Y = 3840,
                                    Z = 41472,
                                    Room = -3
                                }
                            },
                            [-2] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 27136,
                                    Y = 1280,
                                    Z = 44544 + 1024,
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
                                    X = 27136,
                                    Y = 1280,
                                    Z = 44544,
                                    Room = -2
                                }
                            },
                            [-1] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 26112 - 1024,
                                    Y = 512,
                                    Z = 47616,
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
                                    X = 26112,
                                    Y = 256,
                                    Z = 47616,
                                    Room = -1
                                }
                            },
                            [0] = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 25088,
                                    Z = 43520,
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
                                    X = 25088,
                                    Z = 43520 + 1024,
                                    Room = 0
                                }
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
                            FaceIndex = 25,
                            FaceType = EMTextureFaceType.Rectangles,
                            RoomNumber = -5,
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
                            FaceIndex = 3,
                            FaceType = EMTextureFaceType.Rectangles,
                            RoomNumber = -2,
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
                            FaceIndex = 35,
                            FaceType = EMTextureFaceType.Rectangles,
                            RoomNumber = 0,
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
                            FaceIndex = 33,
                            FaceType = EMTextureFaceType.Rectangles,
                            RoomNumber = 0,
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
                new EMRefaceFunction
                {
                    EMType = EMType.Reface,
                    TextureMap = new EMTextureMap
                    {
                        [57] = new EMGeometryMap
                        {
                            [-5] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 25 }
                            }
                        },
                        [18] = new EMGeometryMap
                        {
                            [-1] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 13 }
                            }
                        },
                        [53] = new EMGeometryMap
                        {
                            [0] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 35 }
                            }
                        },
                        [30] = new EMGeometryMap
                        {
                            [0] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 35 }
                            }
                        },
                    }
                },
                new EMRemoveFaceFunction
                {
                    EMType = EMType.RemoveFace,
                    GeometryMap = new EMGeometryMap
                    {
                        [41] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 26 }
                        },
                        [-5] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 24,2 }
                        },
                        [-4] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 30,42 }
                        },
                        [-3] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 64,16 }
                        },
                        [-2] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 15,2 }
                        },
                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                        {
                            [EMTextureFaceType.Rectangles] = new int[] { 19,4 }
                        },
                        //[0] = new Dictionary<EMTextureFaceType, int[]>
                        //{
                        //    [EMTextureFaceType.Rectangles] = new int[] { 33 }
                        //},
                    }
                },
                new EMAddEntityFunction
                {
                    Comments = "Add a door.",
                    EMType = EMType.AddEntity,
                    TypeID = (short)TREntities.Door7,
                    Intensity = level.Entities[86].Intensity,
                    Location = new EMLocation
                    {
                        X = 25088,
                        Z = 43520,
                        Room = -1,
                        Angle = -32768
                    }
                },
                new EMTriggerFunction
                {
                    Comments = "Trigger the door.",
                    EMType = EMType.Trigger,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 25088,
                            Z = 43520 + 3072,
                            Room = -1
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
                    EMType = EMType.AddEntity,
                    TypeID = (short)TREntities.SmallMed_S_P,
                    Intensity = level.Entities[94].Intensity,
                    Location = new EMLocation
                    {
                        X = 28160,
                        Y = 3840,
                        Z = 42496,
                        Room = -3
                    }
                }
            };

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the dart model is available.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.DartEmitter,
                                TexturedFace4 = 9
                            },
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.Dart_H,
                                TexturedFace4 = 9,
                                TexturedFace3 = 33
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some darts.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DartEmitter,
                        Intensity = Array.Find(level1.Entities, e => e.TypeID == (short)TREntities.DartEmitter).Intensity,
                        Location = new EMLocation
                        {
                            X = 20992,
                            Y = -256,
                            Z = 42496,
                            Room = 55,
                            Angle = -32768
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DartEmitter,
                        Intensity = Array.Find(level1.Entities, e => e.TypeID == (short)TREntities.DartEmitter).Intensity,
                        Location = new EMLocation
                        {
                            X = 22016,
                            Y = -256,
                            Z = 37376,
                            Room = 55
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        ExpandedLocations = new EMLocationExpander
                        {
                            Location = new EMLocation
                            {
                                X = 20992,
                                Y = -512,
                                Z = 37376,
                                Room = 55
                            },
                            ExpandX = 2,
                            ExpandZ = 6
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
                                TexturedFace4 = 9,
                                TexturedFace3 = 33
                            },
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
                            X = 23040,
                            Y = -3072,
                            Z = 36352 - 512,
                            Room = 6,
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 23040,
                            Y = -3072,
                            Z = 35328,
                            Room = 6,
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
                                TexturedFace4 = 18,
                                TexturedFace3 = 90
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
                            X = 45568,
                            Y = 16128 - 2048,
                            Z = 41472,
                            Room = 48,
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 48640,
                            Y = 15616,
                            Z = 42496,
                            Room = 48,
                        }
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        Location = new EMLocation
                        {
                            X = 44544,
                            Y = 15872,
                            Z = 41472,
                            Room = 48,
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
                                TexturedFace4 = 18,
                                TexturedFace3 = 90
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
                            X = 58880,
                            Y = 13056+768,
                            Z = 40448 + 1024,
                            Room = 25,
                        },
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        Location = new EMLocation
                        {
                            X = 57856,
                            Y = 19200,
                            Z = 43520,
                            Room = 25,
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
                        Comments = "Add a blade.",
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SwingingBlade,
                        Intensity = Array.Find(level7b.Entities, e => e.TypeID == (short)TREntities.SwingingBlade).Intensity,
                        Location = new EMLocation
                        {
                            X = 42496,
                            Y = -768,
                            Z = 39424,
                            Room = 2,
                            Angle= 16384
                        },
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        Location = new EMLocation
                        {
                            X = 42496 - 1024,
                            Y = -768,
                            Z = 39424,
                            Room = 2,
                        },
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

            mapping.AllWithin = new List<List<EMEditorSet>>
            {
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "NOOP - leave the first heavy trigger as-is.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            Comments = "Move the first heavy trigger back a tile.",
                            EMType = EMType.MoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            BaseLocation = new EMLocation
                            {
                                X = 32256 - 1024,
                                Y = 256,
                                Z = 36352
                            },
                            NewLocation = new EMLocation
                            {
                                X = 32256 - 2048,
                                Y = 256,
                                Z = 36352
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Refacing for above.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [13] = new EMGeometryMap
                                {
                                    [0] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 119 }
                                    }
                                },
                                [11] = new EMGeometryMap
                                {
                                    [0] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 137 }
                                    }
                                },
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
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[] { 119 },
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
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[] { 137 },
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
                    }
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "NOOP - leave the second heavy trigger as-is.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            Comments = "Move the second heavy trigger forward a tile.",
                            EMType = EMType.MoveTrigger,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            BaseLocation = new EMLocation
                            {
                                X = 32256 + 1024,
                                Y = 256,
                                Z = 36352
                            },
                            NewLocation = new EMLocation
                            {
                                X = 32256 + 2048,
                                Y = 256,
                                Z = 36352
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Refacing for above.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [13] = new EMGeometryMap
                                {
                                    [0] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 206 }
                                    }
                                },
                                [11] = new EMGeometryMap
                                {
                                    [0] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 188 }
                                    }
                                },
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
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[] { 206 },
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
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[] { 188 },
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
                    }
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "NOOP - leave the keyholes where they are.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Neptune keyhole.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 80,
                            Location = new EMLocation
                            {
                                X = 36352,
                                Y = 20224,
                                Z = 36352,
                                Room = 3,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Atlas keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 81,
                            Location = new EMLocation
                            {
                                X = 36352 + 2048,
                                Y = 20224,
                                Z = 36352,
                                Room = 3,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Damocles keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 82,
                            Location = new EMLocation
                            {
                                X = 36352 + 1024,
                                Y = 20224,
                                Z = 36352,
                                Room = 3,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Thor keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 83,
                            Location = new EMLocation
                            {
                                X = 36352 + 3072,
                                Y = 20224,
                                Z = 36352,
                                Room = 3,
                                Angle = -32768
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Neptune keyhole.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 80,
                            Location = new EMLocation
                            {
                                X = 43520,
                                Y = 23296 - 512,
                                Z = 41472 - 2048,
                                Room = 42,
                                Angle = 16384
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Atlas keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 81,
                            Location = new EMLocation
                            {
                                X = 43520,
                                Y = 23296 - 768,
                                Z = 41472 - 3072,
                                Room = 42,
                                Angle = 16384
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Damocles keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 82,
                            Location = new EMLocation
                            {
                                X = 43520,
                                Y = 23296,
                                Z = 41472,
                                Room = 42,
                                Angle = 16384
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Thor keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 83,
                            Location = new EMLocation
                            {
                                X = 43520,
                                Y = 23296 - 256,
                                Z = 41472 - 1024,
                                Room = 42,
                                Angle = 16384
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Neptune keyhole.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 80,
                            Location = new EMLocation
                            {
                                X = 50688,
                                Y = 13056,
                                Z = 43520 + 1024,
                                Room = 47,
                                Angle = 16384
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Atlas keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 81,
                            Location = new EMLocation
                            {
                                X = 50688,
                                Y = 13056,
                                Z = 43520 + 3072,
                                Room = 47,
                                Angle = 16384
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Damocles keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 82,
                            Location = new EMLocation
                            {
                                X = 50688,
                                Y = 13056,
                                Z = 43520,
                                Room = 47,
                                Angle = 16384
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Thor keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 83,
                            Location = new EMLocation
                            {
                                X = 50688,
                                Y = 13056,
                                Z = 43520 + 2048,
                                Room = 47,
                                Angle = 16384
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Neptune keyhole.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 80,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Y = 17152,
                                Z = 37376,
                                Room = 43,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Atlas keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 81,
                            Location = new EMLocation
                            {
                                X = 55808 + 2048,
                                Y = 17152,
                                Z = 37376,
                                Room = 43,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Damocles keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 82,
                            Location = new EMLocation
                            {
                                X = 55808 + 1024,
                                Y = 17152,
                                Z = 37376,
                                Room = 43,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Thor keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 83,
                            Location = new EMLocation
                            {
                                X = 55808 + 3072,
                                Y = 17152,
                                Z = 37376,
                                Room = 43,
                                Angle = -32768
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Neptune keyhole.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 80,
                            Location = new EMLocation
                            {
                                X = 55808 + 1024,
                                Y = 17152 - 1024,
                                Z = 37376,
                                Room = 43,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Atlas keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 81,
                            Location = new EMLocation
                            {
                                X = 55808 + 2048 + 1024,
                                Y = 17152,
                                Z = 37376,
                                Room = 43,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Damocles keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 82,
                            Location = new EMLocation
                            {
                                X = 55808 + 1024 + 1024,
                                Y = 17152,
                                Z = 37376,
                                Room = 43,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Thor keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 83,
                            Location = new EMLocation
                            {
                                X = 55808 + 3072 + 1024,
                                Y = 17152 - 1024,
                                Z = 37376,
                                Room = 43,
                                Angle = -32768
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Neptune keyhole.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 80,
                            Location = new EMLocation
                            {
                                X = 36352 + 3072,
                                Y = 12288 - 768,
                                Z = 36352,
                                Room = 18,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Atlas keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 81,
                            Location = new EMLocation
                            {
                                X = 36352,
                                Y = 12288,
                                Z = 36352,
                                Room = 18,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Damocles keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 82,
                            Location = new EMLocation
                            {
                                X = 36352 + 2048,
                                Y = 12288 - 512,
                                Z = 36352,
                                Room = 18,
                                Angle = -32768
                            }
                        },
                        new EMMoveSlotFunction
                        {
                            Comments = "Move the Thor keyhole.",
                            EMType = EMType.MoveSlot,
                            EntityIndex = 83,
                            Location = new EMLocation
                            {
                                X = 36352 + 1024,
                                Y = 12288 - 256,
                                Z = 36352,
                                Room = 18,
                                Angle = -32768
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
                            Comments = "Move Thor's block.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 19,
                            TargetLocation = new EMLocation
                            {
                                X = 56832 - 1024,
                                Y = 13056,
                                Z = 37376,
                                Room = 16
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Thor's block.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 19,
                            TargetLocation = new EMLocation
                            {
                                X = 56832 + 1024,
                                Y = 13056,
                                Z = 37376,
                                Room = 16
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Thor's block.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 19,
                            TargetLocation = new EMLocation
                            {
                                X = 56832 + 2048,
                                Y = 13056,
                                Z = 37376,
                                Room = 16
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Thor's block.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 19,
                            TargetLocation = new EMLocation
                            {
                                X = 56832 + 3072,
                                Y = 13056,
                                Z = 37376,
                                Room = 16
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Thor's block.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 19,
                            TargetLocation = new EMLocation
                            {
                                X = 56832 + 4096,
                                Y = 13056,
                                Z = 37376,
                                Room = 16
                            }
                        }
                    }
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Thor's other block.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 20,
                            TargetLocation = new EMLocation
                            {
                                X = 60928,
                                Y = 13056,
                                Z = 41472 + 1024,
                                Room = 16
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Thor's other block.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 20,
                            TargetLocation = new EMLocation
                            {
                                X = 60928,
                                Y = 13056,
                                Z = 41472 + 2048,
                                Room = 16
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Thor's other block.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 20,
                            TargetLocation = new EMLocation
                            {
                                X = 60928 + 1024,
                                Y = 13056,
                                Z = 41472 + 3072,
                                Room = 16
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Thor's other block.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 20,
                            TargetLocation = new EMLocation
                            {
                                X = 60928 - 1024,
                                Y = 13056,
                                Z = 41472 - 1024,
                                Room = 16
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Thor's other block.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 20,
                            TargetLocation = new EMLocation
                            {
                                X = 55808,
                                Y = 13056,
                                Z = 44544,
                                Room = 16
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Thor's other block.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 20,
                            TargetLocation = new EMLocation
                            {
                                X = 55808 + 1024,
                                Y = 13056,
                                Z = 38400,
                                Room = 16
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
                            Comments = "Make an Atlas-style trap/puzzle area at the end (a bit like Tinnos).",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 20,
                            Width = 10,
                            Depth = 5,
                            Textures = new EMTextureGroup
                            {
                                Floor = 42,
                                Ceiling = 18,
                                Wall4 = 7,
                                Wall2 = 130,
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
                                    X = 1 * 1024 + 512,
                                    Y = -4096,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 512,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 3 * 1024 + 512,
                                    Y = -4096,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 8 * 1024 + 512,
                                    Y = -2048,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 3000,
                                    Fade1 = 3072,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            Location = new EMLocation
                            {
                                X = 26624 - 9*1024,
                                Y = 23296,
                                Z = 37888 - 2048
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-2] = new List<int> { 38 },
                                [-4] = new List<int> { 31,36 },
                                [-6] = new List<int> { 28,33 },
                                [-8] = new List<int> { 21,26 },
                                [-10] = new List<int> { 18,23 },
                                [-12] = new List<int> { 11,13,6,7,8,16 },
                                [-127] = new List<int> { 12 }
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [4] = new List<int> { 11,13 },
                            }
                        },
                        new EMCopyRoomFunction
                        {
                            Comments = "Copy the original end room again.",
                            EMType = EMType.CopyRoom,
                            RoomIndex = 46,
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            NewLocation = new EMLocation
                            {
                                X = 26624 - 13*1024,
                                Y = 23296 - 3072,
                                Z = 37888 - 1024
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
                                    BaseRoom = 46,
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
                                            Y = 23296-2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 23296-2048,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 23296,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 23296,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = 46,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 9 * 1024,
                                            Y = 23296-2048,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 9 * 1024,
                                            Y = 23296-2048,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 9 * 1024,
                                            Y = 23296,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 9 * 1024,
                                            Y = 23296,
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
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 20224-2048,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 20224-2048,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 20224,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 20224,
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
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 20224-2048,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 20224-2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 20224,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 20224,
                                            Z = 2 * 1024
                                        }
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
                                [46] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 27136 - 1024,
                                            Y = 23296,
                                            Z = 38400,
                                            Room = 46
                                        }
                                    }
                                },
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [46] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 27136,
                                            Y = 23296,
                                            Z = 38400,
                                            Room = -2
                                        }
                                    },
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 18944 - 1024,
                                            Y = 20224,
                                            Z = 38400,
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
                                            X = 18944,
                                            Y = 20224,
                                            Z = 38400,
                                            Room = -1
                                        }
                                    }
                                }
                            }
                        },
                        new EMSlantFunction
                        {
                            Comments = "Make some slopes.",
                            EMType = EMType.Slant,
                            SlantType = FDSlantEntryType.FloorSlant,
                            XSlant = -4,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 20992,
                                    Y = 20736,
                                    Z = 37376,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992 + 1024,
                                    Y = 20736,
                                    Z = 37376 + 2048,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992 + 2048,
                                    Y = 20736,
                                    Z = 37376,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992 + 3072,
                                    Y = 20736,
                                    Z = 37376 + 2048,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992 + 4096,
                                    Y = 20736,
                                    Z = 37376,
                                    Room = -2
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "AMend some faces to match the geometry.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = 1024,
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 1024,
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -2,
                                    FaceIndices = new int[] { 28,71,107,66,101},
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
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [812] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                    }
                                },
                                [144] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 33,59, 76,96,113 }
                                    }
                                }
                            }
                        },
                        new EMAddFaceFunction
                        {
                            Comments = "Add triangles to fill gaps.",
                            EMType = EMType.AddFace,
                            Triangles = new Dictionary<short, List<TRFace3>>
                            {
                                [-2] = new List<TRFace3>
                                {
                                    new TRFace3
                                    {
                                        Texture = 75,
                                        Vertices = new ushort[]
                                        {
                                            77,169,58
                                        }
                                    },
                                    new TRFace3
                                    {
                                        Texture = 75,
                                        Vertices = new ushort[]
                                        {
                                            113,171,94
                                        }
                                    },
                                    new TRFace3
                                    {
                                        Texture = 75,
                                        Vertices = new ushort[]
                                        {
                                            52,54,74
                                        }
                                    },
                                    new TRFace3
                                    {
                                        Texture = 75,
                                        Vertices = new ushort[]
                                        {
                                            90,91,111
                                        }
                                    },
                                    new TRFace3
                                    {
                                        Texture = 75,
                                        Vertices = new ushort[]
                                        {
                                            33,25,164
                                        }
                                    },

                                    new TRFace3
                                    {
                                        Texture = 75,
                                        Vertices = new ushort[]
                                        {
                                            82,64,166
                                        }
                                    },
                                    new TRFace3
                                    {
                                        Texture = 75,
                                        Vertices = new ushort[]
                                        {
                                            119,101,168
                                        }
                                    },
                                    new TRFace3
                                    {
                                        Texture = 75,
                                        Vertices = new ushort[]
                                        {
                                            47,56,24
                                        }
                                    },

                                    new TRFace3
                                    {
                                        Texture = 75,
                                        Vertices = new ushort[]
                                        {
                                            76,92,63
                                        }
                                    },
                                    new TRFace3
                                    {
                                        Texture = 75,
                                        Vertices = new ushort[]
                                        {
                                            109,126,100
                                        }
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments= "Remove redundant faces.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [46] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,3 }
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 140,141,9,10,
                                    55,91,127,
                                    84,119,
                                    63,99,116,81,45
                                    }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                }
                            }
                        },
                        new EMKillLaraFunction
                        {
                            Comments= "Add death tiles.",
                            EMType = EMType.KillLara,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 20992,
                                    Y = 23296,
                                    Z = 38400,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992+1024,
                                    Y = 23296,
                                    Z = 38400,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992+2048,
                                    Y = 23296,
                                    Z = 38400,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992+3072,
                                    Y = 23296,
                                    Z = 38400,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992+4096,
                                    Y = 23296,
                                    Z = 38400,
                                    Room = -2
                                },
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments= "Move the end-level trigger.",
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 27136 + 1024,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            NewLocation = new EMLocation
                            {
                                X = 14848 + 1024,
                                Y = 20224,
                                Z = 38400,
                                Room = -1
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments= "Trigger the original end door.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 27136 + 1024,
                                    Y = 23296,
                                    Z = 38400,
                                    Room = 46
                                },
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 91
                                    }
                                }
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Rotate the end door to open inwards.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 91,
                            TargetLocation = new EMLocation
                            {
                                X = 27136 - 1024,
                                Y = 23296,
                                Z = 38400,
                                Room = 46,
                                Angle = (short)(level.Entities[91].Angle * -1)
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add boulders.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.RollingBall,
                            Intensity = level.Entities[93].Intensity,
                            Location = new EMLocation
                            {
                                X = 18944 + 1024,
                                Y = 20224,
                                Z = 37376,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.RollingBall,
                            Intensity = level.Entities[93].Intensity,
                            Flags = 0x100,
                            Location = new EMLocation
                            {
                                X = 18944,
                                Y = 20224-1024,
                                Z = 37376,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.RollingBall,
                            Intensity = level.Entities[93].Intensity,
                            Location = new EMLocation
                            {
                                X = 18944 + 1024,
                                Y = 20224,
                                Z = 37376 + 2048,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.RollingBall,
                            Intensity = level.Entities[93].Intensity,
                            Flags = 0x100,
                            Location = new EMLocation
                            {
                                X = 18944,
                                Y = 20224-1024,
                                Z = 37376 + 2048,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger the boulders.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 24064-1024,
                                    Y = 22272,
                                    Z = 37376,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 22272,
                                    Z = 37376,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 24064 + 1024,
                                    Y = 22272,
                                    Z = 37376,
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
                                        Parameter = -4
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
                                    X = 24064-1024,
                                    Y = 22272,
                                    Z = 37376 + 2048,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 24064,
                                    Y = 22272,
                                    Z = 37376 + 2048,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 24064 + 1024,
                                    Y = 22272,
                                    Z = 37376 + 2048,
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
                                        Parameter = -2
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
                                    X = 20992 -1024,
                                    Y = 20736,
                                    Z = 37376,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992,
                                    Y = 20736,
                                    Z = 37376,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992 + 1024,
                                    Y = 20736,
                                    Z = 37376,
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
                                        Parameter = -4
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -3
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
                                    X = 20992 -1024,
                                    Y = 20736,
                                    Z = 37376+2048,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992,
                                    Y = 20736,
                                    Z = 37376+2048,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 20992 + 1024,
                                    Y = 20736,
                                    Z = 37376+2048,
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
                                        Parameter = -2
                                    },
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
                            EMType= EMType.GenerateLight,
                            RoomIndices = new List<short> { -1,-2 }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a Neptune-style trap/puzzle area at the end.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 8,
                            Width = 11,
                            Depth = 5,
                            Textures = new EMTextureGroup
                            {
                                Floor = 42,
                                Ceiling = 18,
                                Wall4 = 7,
                                Wall2 = 130,
                                WallAlignment = Direction.Up
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
                                    X = 1 * 1024 + 512,
                                    Y = -768,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 512,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 5 * 1024 + 512,
                                    Y = -768,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 9 * 1024 + 512,
                                    Y = -768,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            Location = new EMLocation
                            {
                                X = 26624 - 9*1024,
                                Y = 23296 + 8*256,
                                Z = 37888 - 2048
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 6,8,11,13,21,23,26,28,31,33,41,43,46,48 }
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [4] = new List<int> { 12,22,27,32,42 },
                            }
                        },
                        new EMCopyRoomFunction
                        {
                            Comments = "Copy the original end room again.",
                            EMType = EMType.CopyRoom,
                            RoomIndex = 46,
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            NewLocation = new EMLocation
                            {
                                X = 26624 - 12*1024,
                                Y = 23296,
                                Z = 37888 - 1024
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
                                    BaseRoom = 46,
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
                                            Y = 23296,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 23296,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 23296,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 23296,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = 46,
                                    Normal = new TRVertex
                                    {
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 9 * 1024,
                                            Y = 23296,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 9 * 1024,
                                            Y = 23296,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 10 * 1024,
                                            Y = 23296,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 10 * 1024,
                                            Y = 23296,
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
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 23296,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 23296,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 23296,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 23296,
                                            Z = 2 * 1024
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
                                            Y = 23296,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 23296,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 23296,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 23296,
                                            Z = 2 * 1024
                                        }
                                    }
                                }
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            Comments = "Make collisional portals.",
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 27136,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            Floor = new EMLocation
                            {
                                X = 27136,
                                Y = 23296 + 1024,
                                Z = 38400,
                                Room = -2
                            },
                            InheritFloorBox = true
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 18944,
                                Y = 23296,
                                Z = 38400,
                                Room = -1
                            },
                            Floor = new EMLocation
                            {
                                X = 18944,
                                Y = 23296 + 1024,
                                Z = 38400,
                                Room = -2
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments= "Add water textures and a fake door.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [62] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 1,70 }
                                    },
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 20 }
                                    },
                                    [46] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0 }
                                    }
                                },
                                [812] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                    }
                                },
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments= "Amend some faces in the final room.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 3,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = 4096,
                                            Z = 1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = 4096,
                                            Z = -1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = 4096,
                                            Z = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = 4096,
                                            Z = 1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 2,
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
                        new EMAddFaceFunction
                        {
                            Comments= "Patch a gap in the final room.",
                            EMType = EMType.AddFace,
                            Quads = new Dictionary<short, List<TRFace4>>
                            {
                                [-1] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[46].RoomData.Rectangles[24].Texture,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[46].RoomData.Rectangles[24].Vertices[1],
                                            level.Rooms[46].RoomData.Rectangles[22].Vertices[0],
                                            level.Rooms[46].RoomData.Rectangles[22].Vertices[3],
                                            level.Rooms[46].RoomData.Rectangles[24].Vertices[2],
                                        }
                                    }
                                }
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments= "Move the end-level trigger.",
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 27136 + 1024,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            NewLocation = new EMLocation
                            {
                                X = 14848+2048,
                                Y = 20224,
                                Z = 38400,
                                Room = -1
                            }
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMImportNonGraphicsModelFunction
                            {
                                Comments= "Import the clang-clang model.",
                                EMType = EMType.ImportNonGraphicsModel,
                                Data = new List<EMMeshTextureData>
                                {
                                    new EMMeshTextureData
                                    {
                                        ModelID = (short)TREntities.SlammingDoor,
                                        TexturedFace4 = 9,
                                        TexturedFace3 = 33
                                    }
                                }
                            },
                        },
                        new EMConvertEntityFunction
                        {
                            Comments = "Convert the end door into a blade.",
                            EMType = EMType.ConvertEntity,
                            EntityIndex = 91,
                            NewEntityType = (short)TREntities.SwingingBlade,
                        },
                        new EMMoveEntityFunction
                        {
                            Comments= "Move it underwater.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 91,
                            TargetLocation = new EMLocation
                            {
                                X = 25088,
                                Y = 25344,
                                Z = 38400,
                                Room = -2,
                                Angle = -16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add another blade.",
                            EMType = EMType.AddEntity,
                            Intensity = level.Entities[91].Intensity,
                            TypeID = (short)TREntities.SwingingBlade,
                            Location = new EMLocation
                            {
                                X = 25088 - 4096,
                                Y = 25344,
                                Z = 38400,
                                Room = -2,
                                Angle = 16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger the blades.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088 + 2048,
                                    Y = 25344,
                                    Z = 38400,
                                    Room = -2
                                }
                            },
                            Trigger= new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 91
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMAddEntityFunction
                            {
                                Comments = "Add clang-clang doors.",
                                EMType = EMType.AddEntity,
                                Intensity = level.Entities[91].Intensity,
                                TypeID = (short)TREntities.SlammingDoor,
                                Location = new EMLocation
                                {
                                    X = 25088 - 1024 - 512,
                                    Y = 25344,
                                    Z = 38400,
                                    Room = -2,
                                    Angle = -16384
                                }
                            },
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMTriggerFunction
                            {
                                Comments = "Trigger the clang-clang doors.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 25088 -1024,
                                        Y = 25344,
                                        Z = 38400,
                                        Room = -2
                                    }
                                },
                                Trigger= new EMTrigger
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
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMAddEntityFunction
                            {
                                Comments= "Add a boulder.",
                                EMType = EMType.AddEntity,
                                Intensity = level.Entities[91].Intensity,
                                TypeID = (short)TREntities.RollingBall,
                                Location = new EMLocation
                                {
                                    X = 18944,
                                    Y = 25344-1024-512,
                                    Z = 38400,
                                    Room = -2,
                                    Angle = 16384
                                }
                            },
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMTriggerFunction
                            {
                                Comments= "Trigger the boulder.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 20992,
                                        Y = 25344,
                                        Z = 38400,
                                        Room = -2
                                    }
                                },
                                Trigger= new EMTrigger
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
                        new EMFloodFunction
                        {
                            Comments = "Flood the trap room.",
                            EMType= EMType.Flood,
                            RoomNumbers = new int[] { -2 }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments= "Generate light.",
                            EMType= EMType.GenerateLight,
                            RoomIndices = new List<short> { -1,-2 }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make an extra platforming set of rooms at the end (is there a Greek God of Platforming?)",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom,
                                EMTag.Hard,
                            },
                            Height = 10,
                            Width = 6,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 42,
                                Ceiling = 18,
                                Wall4 = 15,
                                Wall3 = 109,
                                Wall2 = 81,
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
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 3 * 1024 + 512,
                                    Y = -512,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1700,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            Location = new EMLocation
                            {
                                X = 26624 - 5*1024,
                                Y = 23296,
                                Z = 37888 - 1024
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-7] = new List<int> { 4 },
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [2] = new List<int> { 10,13 },
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 10,
                            Width = 5,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 42,
                                Ceiling = 18,
                                Wall4 = 15,
                                Wall3 = 109,
                                Wall2 = 81,
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
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            Location = new EMLocation
                            {
                                X = 26624 - 5*1024,
                                Y = 23296 - 10*256,
                                Z = 37888 - 1024
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-7] = new List<int> { 4 },
                                [-3] = new List<int> { 10 },
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [3] = new List<int> { 10 },
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 10,
                            Width = 5,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 42,
                                Ceiling = 18,
                                Wall4 = 15,
                                Wall3 = 109,
                                Wall2 = 81,
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
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            Location = new EMLocation
                            {
                                X = 26624 - 5*1024,
                                Y = 23296 - 20*256,
                                Z = 37888 - 1024
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-7] = new List<int> { 4 },
                                [-3] = new List<int> { 10 },
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [3] = new List<int> { 10 },
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 10,
                            Width = 5,
                            Depth = 3,
                            Textures = new EMTextureGroup
                            {
                                Floor = 42,
                                Ceiling = 18,
                                Wall4 = 15,
                                Wall3 = 109,
                                Wall2 = 81,
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
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            Location = new EMLocation
                            {
                                X = 26624 - 5*1024,
                                Y = 23296 - 30*256,
                                Z = 37888 - 1024
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-6] = new List<int> { 4 },
                                [-2] = new List<int> { 10 },
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [4] = new List<int> { 10 },
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            Comments = "Final room to Colosseum.",
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 3,
                            Depth = 6,
                            Textures = new EMTextureGroup
                            {
                                Floor = 42,
                                Ceiling = 18,
                                Wall4 = 67,
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
                                    X = 1 * 1024 + 512,
                                    Y = -512,
                                    Z = 3 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1700,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 27136,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            Location = new EMLocation
                            {
                                X = 26624 - 0*1024,
                                Y = 23296 - 0,
                                Z = 37888 - 4096-1024
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
                                    BaseRoom = -5,
                                    AdjoiningRoom = -4,
                                    Normal = new TRVertex
                                    {
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 20736,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 20736,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 20736,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 20736,
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
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 20736,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 20736,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 20736,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 20736,
                                            Z = 1 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -4,
                                    AdjoiningRoom = -3,
                                    Normal = new TRVertex
                                    {
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 18176,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 18176,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 18176,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 18176,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -3,
                                    AdjoiningRoom = -4,
                                    Normal = new TRVertex
                                    {
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 18176,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 18176,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 18176,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 18176,
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
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 15616,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 15616,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 15616,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 15616,
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
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 15616,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 15616,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 15616,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 15616,
                                            Z = 1 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -5,
                                    AdjoiningRoom = 46,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 23296-2048,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 23296-2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 23296,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 23296,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 46,
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
                                            Y = 23296-2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 23296-2048,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 23296,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 23296,
                                            Z = 1 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 46,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 23296-2048,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 23296-2048,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 23296,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 23296,
                                            Z = 5 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 46,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 23296-2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 23296-2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 23296,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 23296,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            Comments = "Make collisional portals.",
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling= new EMLocation
                            {
                                X = 24064,
                                Y = 20736,
                                Z = 38400,
                                Room = -4
                            },
                            Floor = new EMLocation
                            {
                                X = 24064,
                                Y = 20736 + 1024,
                                Z = 38400,
                                Room = -5
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling= new EMLocation
                            {
                                X = 24064,
                                Y = 18176,
                                Z = 38400,
                                Room = -3
                            },
                            Floor = new EMLocation
                            {
                                X = 24064,
                                Y = 18176 + 1024,
                                Z = 38400,
                                Room = -4
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling= new EMLocation
                            {
                                X = 24064,
                                Y = 15616,
                                Z = 38400,
                                Room = -2
                            },
                            Floor = new EMLocation
                            {
                                X = 24064,
                                Y = 15616 + 1024,
                                Z = 38400,
                                Room = -3
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [46] = new Dictionary<short, EMLocation[]>
                                {
                                    [-5] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 26112,
                                            Y = 23296,
                                            Z = 38400,
                                            Room = 46
                                        }
                                    },
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 28160,
                                            Y = 23296,
                                            Z = 37376,
                                            Room = 46
                                        }
                                    }
                                },
                                [-5] = new Dictionary<short, EMLocation[]>
                                {
                                    [46] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 26112 + 1024,
                                            Y = 23296,
                                            Z = 38400,
                                            Room = -5
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [46] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 28160,
                                            Y = 23296,
                                            Z = 37376 + 1024,
                                            Room = -1
                                        }
                                    }
                                },
                            }
                        },
                        new EMSlantFunction
                        {
                            Comments = "Make slopes to reach the top.",
                            EMType = EMType.Slant,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 23040,
                                    Y = 21504,
                                    Z = 38400,
                                    Room = -5
                                },
                                new EMLocation
                                {
                                    X = 23040,
                                    Y = 20736,
                                    Z = 38400,
                                    Room = -4
                                },
                                new EMLocation
                                {
                                    X = 23040,
                                    Y = 17408,
                                    Z = 38400,
                                    Room = -3
                                }
                            },
                            SlantType = FDSlantEntryType.FloorSlant,
                            XSlant = -3
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088,
                                    Y = 20736,
                                    Z = 38400,
                                    Room = -4
                                },
                                new EMLocation
                                {
                                    X = 25088,
                                    Y = 17408,
                                    Z = 38400,
                                    Room = -3
                                }
                            },
                            SlantType = FDSlantEntryType.FloorSlant,
                            XSlant = 3
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088,
                                    Y = 15104,
                                    Z = 38400,
                                    Room = -2
                                }
                            },
                            SlantType = FDSlantEntryType.FloorSlant,
                            XSlant = 2
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Amend faces to match the geometry.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    FaceIndex = 0,
                                    RoomNumber = -5,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = 768
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 7,
                                    RoomNumber = -5,
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
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 17,
                                    RoomNumber = -4,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 768
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 0,
                                    RoomNumber = -4,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = 768
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 7,
                                    RoomNumber = -4,
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
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 17,
                                    RoomNumber = -3,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 768
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 0,
                                    RoomNumber = -3,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = 768
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 7,
                                    RoomNumber = -3,
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
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 17,
                                    RoomNumber = -2,
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
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndex = 3,
                                    RoomNumber = -5,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    FaceIndex = 4,
                                    RoomNumber = -5,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    FaceIndices = new int[] { 3,21 },
                                    RoomNumber = -4,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    FaceIndices = new int[] { 4,19 },
                                    RoomNumber = -4,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    FaceIndices = new int[] { 3,21 },
                                    RoomNumber = -3,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    FaceIndices = new int[] { 4,19 },
                                    RoomNumber = -3,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    FaceIndices = new int[] { 21 },
                                    RoomNumber = -2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = 512
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 19 },
                                    RoomNumber = -2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [3] = new TRVertex
                                        {
                                            Y = 512
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 7 },
                                    RoomNumber = -1,
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
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments= "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [15] = new EMGeometryMap
                                {
                                    [-5] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3,4,7 }
                                    },
                                    [-4] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3,4,7 }
                                    },
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3,4,7 }
                                    }
                                },
                                [138] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                    },
                                },

                                [68] = new EMGeometryMap
                                {
                                    [-5] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 29,21 }
                                    },
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 27,19,13,5 }
                                    }
                                },
                                [67] = new EMGeometryMap
                                {
                                    [-5] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 19,25 }
                                    },
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3,11,17,23 }
                                    }
                                },
                                [93] = new EMGeometryMap
                                {
                                    [-5] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 28,20 }
                                    },
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 4,12,18,26 }
                                    }
                                },
                                [76] = new EMGeometryMap
                                {
                                    [-5] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 18,24 }
                                    },
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2,10,16,22 }
                                    }
                                },
                                [812] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 7 }
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments= "Remove redundant faces.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-5] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 6,26,27, 8 }
                                },
                                [-4] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 5,6, 12,8 }
                                },
                                [-3] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 5,6, 12,8 }
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 5,12 }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 6,24,25 }
                                },
                                [46] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,3,10,11 }
                                }
                            }
                        },
                        new EMMoveTriggerFunction
                        {
                            Comments= "Move the end-level trigger.",
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 27136 + 1024,
                                Y = 23296,
                                Z = 38400,
                                Room = 46
                            },
                            NewLocation = new EMLocation
                            {
                                X = 27136 + 1024,
                                Y = 23296,
                                Z = 38400 - 3072,
                                Room = -1
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments= "Move the end door.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 91,
                            TargetLocation = new EMLocation
                            {
                                X = 28160,
                                Y = 23296,
                                Z = 37376+1024,
                                Room = 46
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a lever for the door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.WallSwitch,
                            Intensity = level.Entities[7].Intensity,
                            Location = new EMLocation
                            {
                                X = 23040,
                                Y = 14080,
                                Z = 38400,
                                Room = -2,
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
                                SwitchOrKeyRef = -1,
                                TrigType = FDTrigType.Switch,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 91
                                    }
                                }
                            }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments = "Generate light.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1,-2,-3,-4,-5 }
                        }
                    }
                }
            };

            mapping.OneOf = new List<EMEditorGroupedSet>
            {
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Move the first pushblock into the ceiling and hide it.",
                            EMType = EMType.ModifyEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            EntityIndex = 0,
                            Invisible = true
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 32256,
                                Y = -5632,
                                Z = 36352,
                                Room = 1
                            }
                        }
                    },
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMModifyEntityFunction
                            {
                                Comments = "Effectively NOOP - undo the leader actions.",
                                EMType = EMType.ModifyEntity,
                                EntityIndex = 0,
                                Invisible = false
                            },
                            new EMMoveEntityFunction
                            {
                                EMType = EMType.MoveEntity,
                                EntityIndex = 0,
                                TargetLocation = new EMLocation
                                {
                                    X = 32256,
                                    Y = 256,
                                    Z = 36352,
                                    Room = 0
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
                            Comments = "Remove the default lever texture in room 2.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[2].RoomData.Rectangles[130].Texture] = new EMGeometryMap
                                {
                                    [2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 124 }
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
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 46592 + 1024,
                                    Y = -1280,
                                    Z = 39424 + 1024,
                                    Room = 2,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [2] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 130 }
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
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 46592 + 1024,
                                    Y = -1280,
                                    Z = 39424 - 1024,
                                    Room = 2
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [2] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 126 }
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
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 46592 - 1024,
                                    Y = -1280,
                                    Z = 39424 - 2048,
                                    Room = 2,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [2] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 72 }
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
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 46592 - 1024,
                                    Y = -1280,
                                    Z = 39424 + 2048,
                                    Room = 2
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [2] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 88 }
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
                                EntityIndex = 7,
                                Location = new EMLocation
                                {
                                    X = 46592 - 5 * 1024,
                                    Y = -1280 + 512,
                                    Z = 39424 - 2048,
                                    Room = 2,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [2] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 1 }
                                        }
                                    }
                                }
                            },
                        }
                    }
                },
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
                                [level.Rooms[36].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                {
                                    [36] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3, 9, /*5, 57, 91, 116*/ }
                                    }
                                },
                                [level.Rooms[36].RoomData.Rectangles[12].Texture] = new EMGeometryMap
                                {
                                    [36] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2, 8 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Rotations and tweaks for above.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = 36,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[] { 3 },
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 2,
                                        [1] = 3,
                                        [2] = 0,
                                        [3] = 1
                                    }
                                }
                            },
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 36,
                                    FaceIndices = new int[] { 5, 57, 91, 116, 139, 141, 143 },
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
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 36,
                                    FaceIndices = new int[] { 4, 56, 90, 115, 138, 140, 142 },
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 41472,
                                    Y = -2816,
                                    Z = 34304 - 1024,
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
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        }
                                    },
                                    [level.Rooms[36].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 41472,
                                    Y = -2816,
                                    Z = 34304 - 1024,
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
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 5 }
                                        }
                                    },
                                    [level.Rooms[36].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 4 }
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 41472 + 1024,
                                    Y = -2816,
                                    Z = 34304 - 1024,
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
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 57 }
                                        }
                                    },
                                    [level.Rooms[36].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 56 }
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 41472 + 2 * 1024,
                                    Y = -2816,
                                    Z = 34304 - 1024,
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
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 91 }
                                        }
                                    },
                                    [level.Rooms[36].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 90 }
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 41472 + 3 * 1024,
                                    Y = -2816,
                                    Z = 34304 - 1024,
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
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 116 }
                                        }
                                    },
                                    [level.Rooms[36].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 115 }
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 41472 + 3 * 1024,
                                    Y = -2816,
                                    Z = 34304 - 1024,
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
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 139 }
                                        }
                                    },
                                    [level.Rooms[36].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 138 }
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 41472 + 3 * 1024,
                                    Y = -2816,
                                    Z = 34304,
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
                                    [level.Rooms[2].RoomData.Rectangles[124].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 141 }
                                        }
                                    },
                                    [level.Rooms[36].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 140 }
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
                            Comments = "Remove the default lever texture in room 13.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[13].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                {
                                    [13] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 8 }
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
                                EntityIndex = 18,
                                Location = new EMLocation
                                {
                                    X = 43520,
                                    Y = 10752,
                                    Z = 34304 - 1024,
                                    Room = 13,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[13].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                                    {
                                        [13] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 18,
                                Location = new EMLocation
                                {
                                    X = 43520,
                                    Y = 10752,
                                    Z = 34304 - 1024,
                                    Room = 13,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[13].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                                    {
                                        [13] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 4 }
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
                                EntityIndex = 18,
                                Location = new EMLocation
                                {
                                    X = 43520 + 1 * 1024,
                                    Y = 10752,
                                    Z = 34304 - 1024,
                                    Room = 13,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[13].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                                    {
                                        [13] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 18,
                                Location = new EMLocation
                                {
                                    X = 43520 + 2 * 1024,
                                    Y = 10752,
                                    Z = 34304 - 1024,
                                    Room = 13,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[13].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                                    {
                                        [13] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 18,
                                Location = new EMLocation
                                {
                                    X = 43520 + 3 * 1024,
                                    Y = 10752,
                                    Z = 34304 - 1024,
                                    Room = 14,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[13].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                                    {
                                        [14] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        },
                                        [50] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 18,
                                Location = new EMLocation
                                {
                                    X = 43520 + 3 * 1024,
                                    Y = 10752,
                                    Z = 34304 + 1024,
                                    Room = 14
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[13].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                                    {
                                        [14] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 9 }
                                        },
                                        [50] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 18,
                                Location = new EMLocation
                                {
                                    X = 43520 + 2 * 1024,
                                    Y = 10752,
                                    Z = 34304 + 1024,
                                    Room = 13
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[13].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                                    {
                                        [13] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 37 }
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
                                EntityIndex = 18,
                                Location = new EMLocation
                                {
                                    X = 43520 + 1 * 1024,
                                    Y = 10752,
                                    Z = 34304 + 1024,
                                    Room = 13
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[13].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                                    {
                                        [13] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 18,
                                Location = new EMLocation
                                {
                                    X = 43520,
                                    Y = 10752,
                                    Z = 34304 + 1024,
                                    Room = 13
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[13].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                                    {
                                        [13] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 18,
                                Location = new EMLocation
                                {
                                    X = 43520,
                                    Y = 10752,
                                    Z = 34304 + 1024,
                                    Room = 13,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[13].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                                    {
                                        [13] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 12 }
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
                            Comments = "Remove the default lever texture in room 20.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[20].RoomData.Rectangles[108].Texture] = new EMGeometryMap
                                {
                                    [20] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 110 }
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
                                EntityIndex = 49,
                                Location = new EMLocation
                                {
                                    X = 40448,
                                    Y = 13568,
                                    Z = 41472,
                                    Room = 20,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[20].RoomData.Rectangles[110].Texture] = new EMGeometryMap
                                    {
                                        [20] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 106 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Vertex changes for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 20,
                                        FaceIndex = 106,
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
                                            }
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 20,
                                        FaceIndex = 107,
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
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 49,
                                Location = new EMLocation
                                {
                                    X = 40448 - 1024,
                                    Y = 13568,
                                    Z = 41472 - 1024,
                                    Room = 20,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[20].RoomData.Rectangles[110].Texture] = new EMGeometryMap
                                    {
                                        [20] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 100 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Vertex changes for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 20,
                                        FaceIndex = 100,
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
                                            }
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 20,
                                        FaceIndex = 101,
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
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 49,
                                Location = new EMLocation
                                {
                                    X = 40448 - 1024,
                                    Y = 13568,
                                    Z = 41472 + 1024,
                                    Room = 20,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[20].RoomData.Rectangles[110].Texture] = new EMGeometryMap
                                    {
                                        [20] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 108 }
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
                                EntityIndex = 49,
                                Location = new EMLocation
                                {
                                    X = 40448 - 1024,
                                    Y = 18176,
                                    Z = 41472 + 1024,
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
                                    [level.Rooms[20].RoomData.Rectangles[110].Texture] = new EMGeometryMap
                                    {
                                        [23] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 148 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Vertex changes for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 23,
                                        FaceIndex = 148,
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
                                            }
                                        }
                                    },
                                    new EMFaceModification
                                    {
                                        RoomNumber = 23,
                                        FaceIndex = 147,
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
                                },
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        RoomNumber = 23,
                                        FaceIndices = new int[]{ 148 },
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
                            Comments = "Remove the default lever texture in room 21.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[20].RoomData.Rectangles[156].Texture] = new EMGeometryMap
                                {
                                    [21] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 51,
                                Location = new EMLocation
                                {
                                    X = 39424 - 1*1024,
                                    Y = 16128,
                                    Z = 42496 - 6*1024,
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
                                    [level.Rooms[21].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 83 }
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
                                EntityIndex = 51,
                                Location = new EMLocation
                                {
                                    X = 35328,
                                    Y = 13568,
                                    Z = 42496,
                                    Room = 20,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[21].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                    {
                                        [20] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 51,
                                Location = new EMLocation
                                {
                                    X = 39424 - 2*1024,
                                    Y = 16128,
                                    Z = 42496 - 6*1024,
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
                                    [level.Rooms[21].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 74 }
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
                                EntityIndex = 51,
                                Location = new EMLocation
                                {
                                    X = 39424 - 3*1024,
                                    Y = 16128,
                                    Z = 42496 - 6*1024,
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
                                    [level.Rooms[21].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 53 }
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
                                EntityIndex = 51,
                                Location = new EMLocation
                                {
                                    X = 39424 - 3*1024,
                                    Y = 16128,
                                    Z = 42496 - 6*1024,
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
                                    [level.Rooms[21].RoomData.Rectangles[151].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 51 }
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
                            Comments = "Remove the default lever texture in room 3.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[3].RoomData.Rectangles[77].Texture] = new EMGeometryMap
                                {
                                    [3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 85 }
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
                                EntityIndex = 9,
                                Location = new EMLocation
                                {
                                    X = 38400 + 1024,
                                    Y = 20224,
                                    Z = 41472 - 1024,
                                    Room = 3,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[3].RoomData.Rectangles[85].Texture] = new EMGeometryMap
                                    {
                                        [3] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 106 }
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
                                EntityIndex = 9,
                                Location = new EMLocation
                                {
                                    X = 38400 + 2 * 1024,
                                    Y = 20224,
                                    Z = 41472,
                                    Room = 3
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[3].RoomData.Rectangles[85].Texture] = new EMGeometryMap
                                    {
                                        [3] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 135 }
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
                                EntityIndex = 9,
                                Location = new EMLocation
                                {
                                    X = 38400 + 1 * 1024,
                                    Y = 20224,
                                    Z = 41472 + 1024,
                                    Room = 3,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[3].RoomData.Rectangles[85].Texture] = new EMGeometryMap
                                    {
                                        [3] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 133 }
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
                                EntityIndex = 9,
                                Location = new EMLocation
                                {
                                    X = 39424,
                                    Y = 16128,
                                    Z = 40448,
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
                                    [level.Rooms[3].RoomData.Rectangles[85].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 117 }
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
                        new EMRemoveTriggerActionFunction
                        {
                            Comments = "Remove one of the swords from the default trigger.",
                            EMType = EMType.RemoveTriggerAction,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 34
                            },
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 17920,
                                    Y = 18944,
                                    Z = 45568,
                                    Room = 38
                                }
                            }
                        }
                    },
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMMoveEntityFunction
                            {
                                Comments = "A wild sword appears.",
                                EMType = EMType.MoveEntity,
                                EntityIndex = 34,
                                TargetLocation = new EMLocation
                                {
                                    X = 47616,
                                    Y = 16128 - 2048 - 256,
                                    Z = 47616,
                                    Room = 48
                                }
                            },
                            new EMTriggerFunction
                            {
                                EMType= EMType.Trigger,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    OneShot = true,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 34
                                        }
                                    }
                                },
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 45568,
                                        Y = 15872,
                                        Z = 41472,
                                        Room = 48
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveEntityFunction
                            {
                                Comments = "A wild sword appears.",
                                EMType = EMType.MoveEntity,
                                EntityIndex = 34,
                                TargetLocation = new EMLocation
                                {
                                    X = 30208,
                                    Y = -3328 - 2048,
                                    Z = 33280,
                                    Room = 58
                                }
                            },
                            new EMTriggerFunction
                            {
                                EMType= EMType.Trigger,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    OneShot = true,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 34
                                        }
                                    }
                                },
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 30208,
                                        Y = -3328,
                                        Z = 33280 + 2048,
                                        Room = 58
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveEntityFunction
                            {
                                Comments = "A wild sword appears.",
                                EMType = EMType.MoveEntity,
                                EntityIndex = 34,
                                TargetLocation = new EMLocation
                                {
                                    X = 47616,
                                    Y = 18688 - 2048,
                                    Z = 41472,
                                    Room = 24
                                }
                            },
                            new EMTriggerFunction
                            {
                                EMType= EMType.Trigger,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    OneShot = true,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 34
                                        }
                                    }
                                },
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 44544,
                                        Y = 18176,
                                        Z = 41472,
                                        Room = 62
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveEntityFunction
                            {
                                Comments = "A wild sword appears.",
                                EMType = EMType.MoveEntity,
                                EntityIndex = 34,
                                TargetLocation = new EMLocation
                                {
                                    X = 29184,
                                    Y = 23296 - 2048,
                                    Z = 38400,
                                    Room = 46
                                }
                            },
                            new EMModifyEntityFunction
                            {
                                EMType = EMType.ModifyEntity,
                                EntityIndex = 34,
                                Flags = 15 << 9,
                            },
                            new EMAppendTriggerActionFunction
                            {
                                EMType= EMType.AppendTriggerActionFunction,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 34
                                    }
                                },
                                Location = new EMLocation
                                {
                                    X = 28160,
                                    Y = 22528,
                                    Z = 41472,
                                    Room = 54
                                }
                            }
                        }
                    }
                }
            };

            for (int x = 0; x < 4; x++)
            {
                for (int z = 0; z < 2; z++)
                {
                    mapping.OneOf[0].Followers.Add(new EMEditorSet
                    {
                        new EMAddEntityFunction
                        {
                            Comments = "Make a lever to activate the block.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.WallSwitch,
                            Location = new EMLocation
                            {
                                X = 29184 + x * 3072,
                                Y = 0,
                                Z = 38400 + z * 2048,
                                Room = 0,
                                Angle = -16384
                            },
                            Intensity = level.Entities[7].Intensity
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger for the new lever.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 29184 + x * 3072,
                                    Y = 0,
                                    Z = 38400 + z * 2048,
                                    Room = 0
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                SwitchOrKeyRef = -1,
                                TrigType = FDTrigType.Switch,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 0
                                    }
                                }
                            }
                        }
                    });
                }
            }

            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #71 is in its default position. If not, alter the trigger to a regular one instead of pickup.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 71,
                        X = level.Entities[71].X,
                        Y = level.Entities[71].Y,
                        Z = level.Entities[71].Z,
                        Room = level.Entities[71].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMConvertTriggerFunction
                        {
                            EMType = EMType.ConvertTrigger,
                            Location = new EMLocation
                            {
                                X = level.Entities[71].X,
                                Y = level.Entities[71].Y,
                                Z = level.Entities[71].Z,
                                Room = level.Entities[71].Room
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
                                    X = level.Entities[71].X,
                                    Y = level.Entities[71].Y,
                                    Z = level.Entities[71].Z,
                                    Room = level.Entities[71].Room
                                },
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 71
                            }
                        }
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "If Lara is in room 51, extend the trigger for the door to the other side of the room.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 104,
                        Room = 51
                    },
                    OnTrue = new EMEditorSet
                    {
                        new EMDuplicateTriggerFunction
                        {
                            EMType = EMType.DuplicateTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 15872,
                                Z = 40448,
                                Room = 51
                            },
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 15872,
                                    Z = 39424,
                                    Room = 51
                                }
                            }
                        }
                    }
                },
            };

            mapping.Mirrored = new EMEditorSet
            {
                new EMMirrorStaticMeshFunction
                {
                    Comments = "Mirror the door baricade static mesh again so it looks normal (barricades themselves can't currently be mirrored).",
                    EMType = EMType.MirrorStaticMesh,
                    MeshIDs = new uint[] { 33 }
                },
                new EMRefaceFunction
                {
                    Comments = "Swap the faces on either side of the door.",
                    EMType = EMType.Reface,
                    TextureMap = new EMTextureMap
                    {
                        [132] = new EMGeometryMap
                        {
                            [42] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 18, 20 }
                            }
                        },
                        [135] = new EMGeometryMap
                        {
                            [42] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 10, 12 }
                            }
                        }
                    }
                },
                new EMMirrorObjectTexture
                {
                    Comments = "Mirror the object textures of the above faces.",
                    EMType = EMType.MirrorObjectTexture,
                    Textures = new ushort[] { 132, 135 }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Rotate the faces again to match.",
                    EMType = EMType.ModifyFace,
                    Rotations = new EMFaceRotation[]
                    {
                        new EMFaceRotation
                        {
                            RoomNumber = 42,
                            FaceIndices = new int[] { 10, 12, 18, 20 },
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
            };

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();

            mapping.RewardEntities = new List<int> { 16, 17, 22, 98, 99, 105, 106 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 33280,
                            Y = 22528,
                            Z = 51712
                        },
                        new Location
                        {
                            X = 32256,
                            Y = 22528,
                            Z = 51712
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door1,
                            X = 32256,
                            Y = 23296,
                            Z = 45568,
                            Angle = -32768,
                            Intensity = 6400,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 34431,
                            Y = 21866,
                            Z = 35329,
                            Room = 42
                        }
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 41,
                            LinkedLocation = new EMLocation
                            {
                                X = 32256,
                                Y = 23296,
                                Z = 45568,
                                Room = 42
                            },
                            NewLocation = new EMLocation
                            {
                                X = 30720,
                                Y = 23808,
                                Z = 45056,
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [42] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 32256,
                                            Y = 23296,
                                            Z = 46592,
                                            Room = 42
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [42] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 30720,
                                            Y = 23808,
                                            Z = 45056,
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
                                    BaseRoom = 42,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = 22272,
                                            Z = 11264
                                        },
                                        new TRVertex
                                        {
                                            X = 3072,
                                            Y = 22272,
                                            Z = 11264
                                        },
                                        new TRVertex
                                        {
                                            X = 3072,
                                            Y = 23296,
                                            Z = 11264
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = 23296,
                                            Z = 11264
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 42,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = 22272,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 22272,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 23552,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = 23552,
                                            Z = 1024
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
                                [-1] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 7,
                                        Vertices = new ushort[]
                                        {
                                            58, 57, 55, 59
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
                                    FaceIndex = 3,
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
                                            Y = 1024 + 256
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 1024 + 256
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
                                [42] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 77 }
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

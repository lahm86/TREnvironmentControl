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
    public class TR1MinesControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.MINES;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);

            mapping.NonPurist = new EMEditorSet
            {
                new EMAddStaticMeshFunction
                {
                    Comments = "Anti-speedrun barriers.",
                    EMType = EMType.AddStaticMesh,
                    IgnoreSectorEntities = true,
                    Mesh = new TR2RoomStaticMesh
                    {
                        MeshID = 19,
                        Intensity1 = Array.Find(level.Rooms[10].StaticMeshes, s => s.MeshID == 19).Intensity
                    },
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 55808,
                            Y = -3072,
                            Z = 54784,
                            Room = 17
                        },
                        new EMLocation
                        {
                            X = 55808 - 1024,
                            Y = -3072,
                            Z = 54784,
                            Room = 17
                        },
                        new EMLocation
                        {
                            X = 55808 + 1024,
                            Y = -3072,
                            Z = 54784,
                            Room = 17
                        }
                    }
                },
                new EMAddFaceFunction
                {
                    Comments = "Fix the gap in the wall in room 35.",
                    EMType = EMType.AddFace,
                    Triangles = new Dictionary<short, List<TRFace3>>
                    {
                        [35] = new List<TRFace3>
                        {
                            new TRFace3
                            {
                                Texture = level.Rooms[35].RoomData.Triangles[2].Texture,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[35].RoomData.Rectangles[4].Vertices[1],
                                    level.Rooms[35].RoomData.Rectangles[0].Vertices[0],
                                    level.Rooms[35].RoomData.Rectangles[0].Vertices[3],
                                }
                            }
                        }
                    }
                },
                new EMSlantFunction
                {
                    Comments = "Increase the slope near the boat.",
                    EMType = EMType.Slant,
                    FloorClicks = -1,
                    SlantType = FDSlantEntryType.FloorSlant,
                    XSlant = -3,
                    Location = new EMLocation
                    {
                        X = 47616,
                        Y = -6400,
                        Z = 26112,
                        Room = 3
                    }
                },
                new EMSlantFunction
                {
                    EMType = EMType.Slant,
                    FloorClicks = -1,
                    SlantType = FDSlantEntryType.FloorSlant,
                    XSlant = -3,
                    Location = new EMLocation
                    {
                        X = 47616,
                        Y = -6400,
                        Z = 26112,
                        Room = 16
                    }
                },
                new EMSlantFunction
                {
                    EMType = EMType.Slant,
                    FloorClicks = -1,
                    SlantType = FDSlantEntryType.FloorSlant,
                    XSlant = 5,
                    Location = new EMLocation
                    {
                        X = 46592,
                        Y = -6144,
                        Z = 26112,
                        Room = 3
                    }
                },
                new EMSlantFunction
                {
                    EMType = EMType.Slant,
                    FloorClicks = -1,
                    SlantType = FDSlantEntryType.FloorSlant,
                    XSlant = 5,
                    Location = new EMLocation
                    {
                        X = 46592,
                        Y = -6144,
                        Z = 26112,
                        Room = 16
                    }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Move some faces to fit the ramp.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 3,
                            FaceIndex = 117,
                            FaceType = EMTextureFaceType.Rectangles,
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
                            RoomNumber = 16,
                            FaceIndex = 117,
                            FaceType = EMTextureFaceType.Rectangles,
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
                            RoomNumber = 3,
                            FaceIndex = 17,
                            FaceType = EMTextureFaceType.Triangles,
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
                            RoomNumber = 3,
                            FaceIndex = 11,
                            FaceType = EMTextureFaceType.Triangles,
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
                            RoomNumber = 16,
                            FaceIndex = 17,
                            FaceType = EMTextureFaceType.Triangles,
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
                            RoomNumber = 16,
                            FaceIndex = 11,
                            FaceType = EMTextureFaceType.Triangles,
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
                            RoomNumber = 3,
                            FaceIndex = 119,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = -256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 16,
                            FaceIndex = 119,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y = -256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 3,
                            FaceIndex = 87,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [2] = new TRVertex
                                {
                                    Y = -256
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 16,
                            FaceIndex = 87,
                            FaceType = EMTextureFaceType.Rectangles,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [2] = new TRVertex
                                {
                                    Y = -256
                                }
                            }
                        },

                        new EMFaceModification
                        {
                            RoomNumber = 3,
                            FaceIndex = 82,
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
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 16,
                            FaceIndex = 82,
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
                        },
                    }
                },
                new EMMovePickupFunction
                {
                    Comments = "Any pickups on the old slope will be moved to the floor.",
                    EMType = EMType.MovePickup,
                    SectorLocations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 47616,
                            Y = -6400,
                            Z = 26112,
                            Room = 3
                        }
                    },
                    TargetLocation = new EMLocation
                    {
                        X = 46592,
                        Y = -5632,
                        Z = 25088,
                        Room = 3
                    }
                },
                new EMMoveCameraFunction
                {
                    Comments = "Move the boat camera so you don't see the already moved boat in the flipmap.",
                    EMType = EMType.MoveCamera,
                    CameraIndex = 7,
                    NewLocation = new EMLocation
                    {
                        X = 53760,
                        Y = -7296,
                        Z = 26112+2048,
                        Room = 3
                    }
                },
                new EMModifyFaceFunction
                {
                    Comments = "Fix the z-fighting in room 55.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 55,
                            FaceIndex = 8,
                            FaceType = EMTextureFaceType.Rectangles,
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
                        }
                    }
                }
            };

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMRemoveTriggerFunction
                    {
                        Comments = "Remove the original boulder pads in room 38.",
                        EMType = EMType.RemoveTrigger,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("minesboulders1.json"))[Level],
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Make combined pads further up the slope.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 95744,
                                Y = -9728,
                                Z = 32256,
                                Room = 38
                            },
                            new EMLocation
                            {
                                X = 95744,
                                Y = -9728,
                                Z = 32256 + 1024,
                                Room = 38
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
                                    Parameter = 38
                                },
                                new EMTriggerAction
                                {
                                    Parameter = 39
                                }
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMRemoveTriggerFunction
                    {
                        Comments = "Remove the original boulder triggers from room 56.",
                        EMType = EMType.RemoveTrigger,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("minesboulders2.json"))[Level],
                    },
                    new EMTriggerFunction
                    {
                        Comments = "New trigger further up the slope.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 61952,
                                Y = -1920,
                                Z = 64000,
                                Room = 54
                            },
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            TrigType = FDTrigType.Trigger,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 49
                                },
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMCreateWallFunction
                    {
                        Comments = "Make some walls near the cowboy area.",
                        EMType = EMType.CreateWall,
                        Tags = new List<EMTag>
                        {
                            EMTag.PuzzleRoom
                        },
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 60928,
                                Y = -3584,
                                Z = 49664,
                                Room = 21
                            },
                            new EMLocation
                            {
                                X = 60928 + 2048,
                                Y = -3584,
                                Z = 49664,
                                Room = 21
                            }
                        },
                        EntityMoveLocation = new EMLocation
                        {
                            X = 61952,
                            Y = -3584,
                            Z = 48640,
                            Room = 21
                        }
                    },
                    new EMMovePickupFunction
                    {
                        Comments = "If the fuse is in its default spot, move it too.",
                        EMType = EMType.MovePickup,
                        SectorLocations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 61952,
                                Y = -3072,
                                Z = 51712,
                                Room = 17
                            }
                        },
                        TargetLocation = new EMLocation
                        {
                            X = 61952,
                            Y = -3584,
                            Z = 48640 - 1024,
                            Room = 21
                        }
                    },
                    new EMRemoveCollisionalPortalFunction
                    {
                        Comments = "Remove the extra portals.",
                        EMType = EMType.RemoveCollisionalPortal,
                        Location1 = new EMLocation
                        {
                            X = 60928,
                            Y = -3584,
                            Z = 49664 + 1024,
                            Room = 21
                        },
                        Location2 = new EMLocation
                        {
                            X = 60928,
                            Y = -3584,
                            Z = 49664,
                            Room = 17
                        },
                    },
                    new EMRemoveCollisionalPortalFunction
                    {
                        EMType = EMType.RemoveCollisionalPortal,
                        Location1 = new EMLocation
                        {
                            X = 60928 + 2048,
                            Y = -3584,
                            Z = 49664 + 1024,
                            Room = 21
                        },
                        Location2 = new EMLocation
                        {
                            X = 60928 + 2048,
                            Y = -3584,
                            Z = 49664,
                            Room = 17
                        },
                    },
                    new EMAdjustVisibilityPortalFunction
                    {
                        Comments = "Reduce the size of the visibility portals.",
                        EMType = EMType.AdjustVisibilityPortal,
                        BaseRoom = 21,
                        AdjoiningRoom = 17,
                        VertexChanges = new Dictionary<int, TRVertex>
                        {
                            [0] = new TRVertex
                            {
                                X = 1024
                            },
                            [1] = new TRVertex
                            {
                                X = 1024
                            },
                            [2] = new TRVertex
                            {
                                X = -1024
                            },
                            [3] = new TRVertex
                            {
                                X = -1024
                            }
                        }
                    },
                    new EMAdjustVisibilityPortalFunction
                    {
                        EMType = EMType.AdjustVisibilityPortal,
                        BaseRoom = 17,
                        AdjoiningRoom = 21,
                        VertexChanges = new Dictionary<int, TRVertex>
                        {
                            [0] = new TRVertex
                            {
                                X = 1024
                            },
                            [1] = new TRVertex
                            {
                                X = 1024
                            },
                            [2] = new TRVertex
                            {
                                X = -1024
                            },
                            [3] = new TRVertex
                            {
                                X = -1024
                            }
                        }
                    },
                    new EMModifyFaceFunction
                    {
                        Comments = "Move some faces for the walls.",
                        EMType = EMType.ModifyFace,
                        Modifications = new EMFaceModification[]
                        {
                            new EMFaceModification
                            {
                                RoomNumber = 21,
                                FaceType = EMTextureFaceType.Rectangles,
                                FaceIndex = 11,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [1] = new TRVertex
                                    {
                                        X = 1024,
                                        Y = -512,
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
                                RoomNumber = 21,
                                FaceType = EMTextureFaceType.Rectangles,
                                FaceIndex = 41,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        X = -1024,
                                        Y = -512,
                                        Z = -1024
                                    },
                                    [3] = new TRVertex
                                    {
                                        X = -1024,
                                        Z = -1024
                                    }
                                }
                            },
                            new EMFaceModification
                            {
                                RoomNumber = 21,
                                FaceType = EMTextureFaceType.Rectangles,
                                FaceIndex = 9,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        Y = -1024 - 512 - 256,
                                    },
                                    [1] = new TRVertex
                                    {
                                        X = 1024,
                                        Y = -1024 - 512 - 256,
                                        Z = 1024
                                    },
                                    [2] = new TRVertex
                                    {
                                        X = 1024
                                    },
                                    [3] = new TRVertex
                                    {
                                        Z = -1024
                                    }
                                }
                            },
                            new EMFaceModification
                            {
                                RoomNumber = 21,
                                FaceType = EMTextureFaceType.Rectangles,
                                FaceIndex = 37,
                                VertexChanges = new Dictionary<int, TRVertex>
                                {
                                    [0] = new TRVertex
                                    {
                                        X = -1024,
                                        Y = -1024 - 512 - 256,
                                        Z = 1024
                                    },
                                    [1] = new TRVertex
                                    {
                                        Y = -1024 - 512 - 256,
                                    },
                                    [2] = new TRVertex
                                    {
                                        Z = -1024
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
                        Comments = "Replace some textures.",
                        EMType = EMType.Reface,
                        TextureMap = new EMTextureMap
                        {
                            [level.Rooms[21].RoomData.Rectangles[41].Texture] = new EMGeometryMap
                            {
                                [21] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 9,37 }
                                }
                            }
                        }
                    },
                    new EMAddFaceFunction
                    {
                        Comments = "Add faces in the other room.",
                        EMType = EMType.AddFace,
                        Quads = new Dictionary<short, List<TRFace4>>
                        {
                            [17] = new List<TRFace4>
                            {
                                new TRFace4
                                {
                                    Texture = level.Rooms[21].RoomData.Rectangles[41].Texture,
                                    Vertices = new ushort[]
                                    {
                                        level.Rooms[17].RoomData.Rectangles[215].Vertices[3],
                                        level.Rooms[17].RoomData.Rectangles[215].Vertices[2],
                                        level.Rooms[17].RoomData.Rectangles[214].Vertices[1],
                                        level.Rooms[17].RoomData.Rectangles[214].Vertices[0],
                                    }
                                },
                                new TRFace4
                                {
                                    Texture = level.Rooms[21].RoomData.Rectangles[41].Texture,
                                    Vertices = new ushort[]
                                    {
                                        level.Rooms[17].RoomData.Rectangles[167].Vertices[3],
                                        level.Rooms[17].RoomData.Rectangles[167].Vertices[2],
                                        level.Rooms[17].RoomData.Rectangles[166].Vertices[1],
                                        level.Rooms[17].RoomData.Rectangles[166].Vertices[0],
                                    }
                                }
                            }
                        }
                    },
                    new EMRemoveFaceFunction
                    {
                        Comments = "Remove spare faces.",
                        EMType = EMType.RemoveFace,
                        GeometryMap = new EMGeometryMap
                        {
                            [21] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 10,38 }
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add a keyhole - the key itself will be added in ConditionalAllWithin.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.Keyhole1,
                        Intensity = -1,
                        Location = new EMLocation
                        {
                            X = 61952 + 1024,
                            Y = -3584,
                            Z = 49664 - 1024,
                            Room = 21
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add a door.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.Door1,
                        Intensity = level.Entities[9].Intensity,
                        Location = new EMLocation
                        {
                            X = 61952,
                            Y = -3584,
                            Z = 49664 - 1024,
                            Room = 21,
                            Angle = -32768
                        }
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Keyhole trigger to pass.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 61952 + 1024,
                                Y = -3584,
                                Z = 49664 - 1024,
                                Room = 21
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            TrigType = FDTrigType.Key,
                            SwitchOrKeyRef = -2,
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
                    new EMRemoveTriggerFunction
                    {
                        Comments = "Remove the boulder triggers for item 58.",
                        EMType = EMType.RemoveTrigger,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 59904,
                                Y = 1664,
                                Z = 96768,
                                Room = 60
                            },
                            new EMLocation
                            {
                                X = 59904,
                                Y = 1664,
                                Z = 96768 + 1024,
                                Room = 60
                            },
                            new EMLocation
                            {
                                X = 59904,
                                Y = 1664,
                                Z = 96768 + 2048,
                                Room = 60
                            }
                        }
                    },
                    new EMTriggerFunction
                    {
                        Comments = "New trigger further up the slope.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 56832,
                                Y = 896,
                                Z = 94720,
                                Room = 61
                            },
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            TrigType = FDTrigType.Trigger,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 58
                                },
                            }
                        }
                    }
                },
            };

            TRRoom room45 = level.Rooms[45];
            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #71 is in its default position. If not, add a trigger for doors 64 & 70 to avoid softlock for any non-purists if they need to go back.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 71,
                        X = level.Entities[71].X,
                        Y = level.Entities[71].Y,
                        Z = level.Entities[71].Z,
                        Room = level.Entities[71].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 49664,
                                    Y = -9984,
                                    Z = 93696,
                                    Room = 68
                                },
                                new EMLocation
                                {
                                    X = 49664,
                                    Y = -9984,
                                    Z = 92672,
                                    Room = 68
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 64
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = 70
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
                        Comments = "Check if key item #42 is in its default position. If not, ensure it is visible and add a replacement item on the conveyor belt.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 42,
                        X = level.Entities[42].X,
                        Y = level.Entities[42].Y,
                        Z = level.Entities[42].Z,
                        Room = level.Entities[42].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMModifyEntityFunction
                        {
                            Comments = "Make it visible.",
                            EMType = EMType.ModifyEntity,
                            EntityIndex = 42,
                            Invisible = false
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add some ammo where the fuse used to be.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.ShotgunAmmo_S_P,
                            Intensity = level.Entities[42].Intensity,
                            Flags = level.Entities[42].Flags,
                            Location = new EMLocation
                            {
                                X = level.Entities[42].X,
                                Y = level.Entities[42].Y,
                                Z = level.Entities[42].Z,
                                Room = level.Entities[42].Room
                            }
                        },
                        new EMRemoveStaticMeshFunction
                        {
                            Comments = "Remove the fuse static mesh from the conveyor belt.",
                            EMType = EMType.RemoveStaticMesh,
                            ClearFromRooms = new Dictionary<ushort, List<int>>
                            {
                                [36] = new List<int> { 45 }
                            }
                        },
                        new EMAddRoomSpriteFunction
                        {
                            Comments = "Add a sprite instead for the ammo.",
                            EMType = EMType.AddRoomSprite,
                            Texture = 4,
                            Vertex = new EMRoomVertex
                            {
                                Lighting = level.Entities[42].Intensity,
                            },
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 78487,
                                    Y = -6912,
                                    Z = 48631,
                                    Room = 45
                                }
                            }
                        },
                        new EMReplaceTriggerActionParameterFunction
                        {
                            Comments = "Replace the switch trigger item.",
                            EMType = EMType.ReplaceTriggerActionParameterFunction,
                            EntityLocations = new List<int> { 79 },
                            Action = new EMTriggerAction
                            {
                                Parameter = -1
                            }
                        }
                    }
                }
            };

            mapping.ConditionalAllWithin = new List<EMConditionalEditorSet>
            {
                new EMConditionalEditorSet
                {
                    Condition = new EMSectorIsWallCondition
                    {
                        Comments = "If the portal between rooms 21 and 17 has been reduced, a key is now needed to pass.",
                        ConditionType = EMConditionType.SectorIsWall,
                        Location = new EMLocation
                        {
                            X = 60928,
                            Y = -3584,
                            Z = 49664,
                            Room = 21
                        },
                    },
                    OnTrue = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMAddEntityFunction
                            {
                                Comments = "Potential key location.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.Key1_S_P,
                                Intensity = level.Entities[16].Intensity,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = -7168,
                                    Z = 24064,
                                    Room = 3
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMAddEntityFunction
                            {
                                Comments = "Put the key in the shack.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.Key1_S_P,
                                Intensity = level.Entities[16].Intensity,
                                Flags = 256,
                                Location = new EMLocation
                                {
                                    X = 68096,
                                    Y = -7168,
                                    Z = 28160,
                                    Room = 94
                                }
                            },
                            new EMAppendTriggerActionFunction
                            {
                                Comments = "Trigger the key once the fuses are used (same method as pistols).",
                                EMType = EMType.AppendTriggerActionFunction,
                                Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("mineskeytriggers.json"))[Level],
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
                                Comments = "Potential key location.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.Key1_S_P,
                                Intensity = level.Entities[16].Intensity,
                                Location = new EMLocation
                                {
                                    X = 61952,
                                    Y = -10496,
                                    Z = 29184,
                                    Room = 32
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMAddEntityFunction
                            {
                                Comments = "Potential key location.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.Key1_S_P,
                                Intensity = level.Entities[16].Intensity,
                                Location = new EMLocation
                                {
                                    X = 77312,
                                    Y = -10240,
                                    Z = 24064,
                                    Room = 42
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMAddEntityFunction
                            {
                                Comments = "Potential key location.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.Key1_S_P,
                                Intensity = level.Entities[16].Intensity,
                                Location = new EMLocation
                                {
                                    X = 82432,
                                    Y = -10240,
                                    Z = 27136,
                                    Room = 35
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMAddEntityFunction
                            {
                                Comments = "Potential key location.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.Key1_S_P,
                                Intensity = level.Entities[16].Intensity,
                                Location = new EMLocation
                                {
                                    X = 99840,
                                    Y = -7808,
                                    Z = 31232,
                                    Room = 37
                                }
                            }
                        },
                    }
                }
            };

            TRRoom room82 = level.Rooms[82];
            mapping.AllWithin = new List<List<EMEditorSet>>
            {
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
                            EntityIndex = 76,
                            Location = new EMLocation
                            {
                                X = 34304,
                                Y = -8704,
                                Z = 92672 + 1024,
                                Room = 72
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
                            EntityIndex = 76,
                            Location = new EMLocation
                            {
                                X = 34304 + 2048,
                                Y = -8704 - 256,
                                Z = 92672 + 1024,
                                Room = 72
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
                            EntityIndex = 76,
                            Location = new EMLocation
                            {
                                X = 34304 + 2048,
                                Y = -8704 - 256,
                                Z = 92672,
                                Room = 72,
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
                            EntityIndex = 76,
                            Location = new EMLocation
                            {
                                X = 50688,
                                Y = -9984,
                                Z = 90624,
                                Room = 68,
                                Angle = 16384
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
                            EntityIndex = 76,
                            Location = new EMLocation
                            {
                                X = 50688,
                                Y = -9984,
                                Z = 90624,
                                Room = 68,
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
                            EntityIndex = 76,
                            Location = new EMLocation
                            {
                                X = 48640,
                                Y = -9984,
                                Z = 94720,
                                Room = 67,
                                Angle = 16384
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
                            EntityIndex = 76,
                            Location = new EMLocation
                            {
                                X = 48640,
                                Y = -9984,
                                Z = 94720 + 1024,
                                Room = 67,
                                Angle = 16384
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
                            EntityIndex = 76,
                            Location = new EMLocation
                            {
                                X = 47616,
                                Y = -9984,
                                Z = 91648,
                                Room = 80,
                                Angle = 16384
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
                            EntityIndex = 76,
                            Location = new EMLocation
                            {
                                X = 47616,
                                Y = -9984,
                                Z = 91648 - 1024,
                                Room = 80,
                                Angle = 16384
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
                            EntityIndex = 76,
                            Location = new EMLocation
                            {
                                X = 47616,
                                Y = -9984,
                                Z = 91648 - 2048,
                                Room = 80,
                                Angle = 16384
                            },
                        }
                    },
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a new area 'in Atlantis' - trapdoor timed run to the end.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 44,
                            Width = 3,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 5,
                                Ceiling = 147,
                                Wall4 = 147,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -9*1024,
                                    Z = 2048,
                                    Intensity1 = 4096,
                                    Fade1 = room82.Lights[0].Fade,
                                },
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -512,
                                    Z = 2048,
                                    Intensity1 = 2048,
                                    Fade1 = room82.Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 25600 - 2048,
                                Y = -8704 + 23*256+12*256,
                                Z = 92160 - 1024,
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 5,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 147,
                                Ceiling = 5,
                                Wall4 = 147,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+2048,//room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 2048 + 512,
                                    Y = -1024,
                                    Z = 2048,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 - 1024,
                                Y = 256 + 2048,
                                Z = 93184 - 2048,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 13 }
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 24,
                            Width = 8,
                            Depth = 9,
                            Textures = new EMTextureGroup
                            {
                                Floor = 125,
                                Ceiling = 125,
                                Wall4 = 125,
                                Wall2 = 128,
                                Wall1 = 126,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting =4096+1024,// room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 4 * 1024,
                                    Y = -1 * 1024,
                                    Z = 4096,
                                    Intensity1 = 3072,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024,
                                    Y = -5 * 1024,
                                    Z = 7 * 1024,
                                    Intensity1 = 4096,
                                    Fade1 = 4096,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 + 1024,
                                Y = 256,
                                Z = 93184 - 2048 - 4096,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-1] = new List<int> { 14 },
                                [-2] = new List<int> { 23 },
                                [-3] = new List<int> { 24 },
                                [-8] = new List<int> { 51 },
                                [-16] = new List<int> { 34,43 },
                                [-127] = new List<int> { 16,25,52,60,61,55,10 }
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 4,
                            Depth = 7,
                            Textures = new EMTextureGroup
                            {
                                Floor = 125,
                                Ceiling = 125,
                                Wall4 = 125,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+1024,
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 2048,
                                    Y = -1024,
                                    Z = 2048,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 + 3072,
                                Y = 256 - 4096,
                                Z = 93184 + 1024,
                            },
                        },

                        new EMVisibilityPortalFunction
                        {
                            Comments = "Visibility portals for the new rooms.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 82,
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
                                            Y = -11008,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -11008,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -8704,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -8704,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -4,
                                    AdjoiningRoom = 82,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -11008,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -11008,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -8704,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -8704,
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
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
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
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 1 * 1024
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
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 256,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 256,
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
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 6 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 6 * 1024
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
                                            X = 3 * 1024,
                                            Y = -5888,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -5888,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -5888 + 2048,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -5888 + 2048,
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
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -5888,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -5888,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -5888 + 2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -5888 + 2048,
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
                                [82] = new Dictionary<short, EMLocation[]>
                                {
                                    [-4] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 26112 - 1024,
                                            Y = -8960,
                                            Z = 92672,
                                            Room = 82
                                        },
                                        new EMLocation
                                        {
                                            X = 26112 - 1024,
                                            Y = -8960,
                                            Z = 92672 + 1024,
                                            Room = 82
                                        }
                                    }
                                },
                                [-4] = new Dictionary<short, EMLocation[]>
                                {
                                    [82] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 26112,
                                            Y = -8960,
                                            Z = 92672,
                                            Room = -4
                                        },
                                        new EMLocation
                                        {
                                            X = 26112,
                                            Y = -8960,
                                            Z = 92672 + 1024,
                                            Room = -4
                                        }
                                    },
                                },
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 29184,
                                            Y = -3840,
                                            Z = 94720 + 1024,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 29184 + 1024,
                                            Y = -3840,
                                            Z = 94720 + 1024,
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
                                            X = 29184,
                                            Y = -3840,
                                            Z = 94720,
                                            Room = -1
                                        },
                                        new EMLocation
                                        {
                                            X = 29184 + 1024,
                                            Y = -3840,
                                            Z = 94720,
                                            Room = -1
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
                                X = 25088,
                                Y = 256,
                                Z = 93696,
                                Room = -4
                            },
                            Floor = new EMLocation
                            {
                                X = 25088,
                                Y = 256 + 1024,
                                Z = 93696,
                                Room = -3
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 25088,
                                Y = 256,
                                Z = 93696 - 1024,
                                Room = -4
                            },
                            Floor = new EMLocation
                            {
                                X = 25088,
                                Y = 256 + 1024,
                                Z = 93696 - 1024,
                                Room = -3
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 27136,
                                Y = 256,
                                Z = 93696,
                                Room = -2
                            },
                            Floor = new EMLocation
                            {
                                X = 27136,
                                Y = 256 + 1024,
                                Z = 93696,
                                Room = -3
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
                                    RoomNumber = -4,
                                    FaceIndices = new int[]{ 69 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
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
                                    RoomNumber = -4,
                                    FaceIndices = new int[]{ 23 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -4,
                                    FaceIndices = new int[]{ 68 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = 768
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -4,
                                    FaceIndices = new int[]{ 22 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndices = new int[]{ 22 },
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
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndices = new int[]{ 44 },
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
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[] { 182,212,148,96,56,128,164,88,14},
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 2,
                                        [1] = 3,
                                        [2] = 0,
                                        [3] = 1
                                    }
                                },
                                new EMFaceRotation
                                {
                                    RoomNumber = -2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[] { 105,132,168,126,80,0,196 },
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
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[] { 72 },
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
                                    FaceIndices = new int[] { 44 },
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 2,
                                        [1] = 3,
                                        [2] = 0,
                                        [3] = 1
                                    }
                                },
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [5] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 40 }
                                    }
                                },
                                [147] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 13,19 }
                                    }
                                },
                                [148] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 80 }
                                    }
                                },
                                [65] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 74,126,166,102 }
                                    }
                                },
                                [84] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 100,132,162,98 }
                                    }
                                },
                                [81] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 22,182 }
                                    }
                                },
                                [78] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 22,105,134,56 }
                                    }
                                },
                                [72] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 74,148 }
                                    }
                                },
                                [75] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 100,0,196,88 }
                                    }
                                },
                                [73] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 102,212,14,118 }
                                    }
                                },
                                [79] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 130,168,204,96,72 }
                                    }
                                },
                                [63] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 70,164 }
                                    }
                                },
                                [85] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 128 }
                                    }
                                },
                                [588] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 22,44 }
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
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 116,117,144,145 }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 4,5,28,29,23,45 }
                                }
                            }
                        },

                        new EMFloodFunction
                        {
                            Comments = "Flood the second room.",
                            EMType = EMType.Flood,
                            RoomNumbers = new int[] { -3 }
                        },
                        new EMKillLaraFunction
                        {
                            Comments = "Death tiles in the challenge room.",
                            EMType = EMType.KillLara,
                            Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("minesend.json"))[Level]
                        },
                        new EMAddSoundSourceFunction
                        {
                            Comments = "Add a lava sound source.",
                            EMType = EMType.AddSoundSource,
                            Source = new TRSoundSource
                            {
                                SoundID = 148,
                                X = 29686,
                                Y = 256,
                                Z = 91133,
                                Flags = 192
                            }
                        },

                        new EMRemoveTriggerFunction
                        {
                            Comments = "Get rid of the normal end level trigger.",
                            EMType = EMType.RemoveTrigger,
                            Rooms = new List<int> { 82 }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Add end level triggers to the final room.",
                            EMType = EMType.Trigger,
                            ExpandedLocations = new EMLocationExpander
                            {
                                Location = new EMLocation
                                {
                                    X = 29184,
                                    Y = -3840,
                                    Z = 97792 + 1024,
                                    Room = -1
                                },
                                ExpandX = 2,
                                ExpandZ = 1
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
                        },

                        new EMAddEntityFunction
                        {
                            Comments = "Add doors to the final room.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door3,
                            Intensity = level.Entities[73].Intensity,
                            Location = new EMLocation
                            {
                                X = 29184,
                                Y = -3840,
                                Z = 94720,
                                Room = -2,
                                Angle = -32768
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door4,
                            Intensity = level.Entities[74].Intensity,
                            Location = new EMLocation
                            {
                                X = 29184 + 1024,
                                Y = -3840,
                                Z = 94720,
                                Room = -2,
                                Angle = -32768
                            }
                        },
                        
                        // Trapdoors
                        new EMAddEntityFunction
                        {
                            Comments = "Trapdoors to reach the top.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor2,
                            Intensity = 6144,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 32256,
                                Y = -1024 - 768,
                                Z = 90624,
                                Room = -2,
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
                                    X = 32256,
                                    Y = 256,
                                    Z = 90624,
                                    Room = -2,
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

                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor2,
                            Intensity = 6144,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 31232,
                                Y = -1024 - 768-1024,
                                Z = 88576,
                                Room = -2,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                   X = 31232,
                                    Y = 256,
                                    Z = 88576,
                                    Room = -2,
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

                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor2,
                            Intensity = 6144,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 31232 - 3072,
                                Y = -1024 - 768-1024-1024,
                                Z = 88576,
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
                                    X = 31232 - 3072,
                                    Y = 256,
                                    Z = 88576,
                                    Room = -2,
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

                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor2,
                            Intensity = 6144,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 27136,
                                Y = -1024 - 768-1024-1024,
                                Z = 91648,
                                Room = -2,
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
                                    X = 27136,
                                    Y = 256,
                                    Z = 91648,
                                    Room = -2,
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

                        new EMTriggerFunction
                        {
                            Comments = "A little music.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 27136,
                                    Z = 92672,
                                    Room = -2,
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Action= FDTrigAction.PlaySoundtrack,
                                        Parameter = 12
                                    },
                                }
                            }
                        },
                        new EMCameraTriggerFunction
                        {
                            EMType = EMType.CameraTriggerFunction,
                            AttachToLocations = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 27136,
                                    Z = 92672,
                                    Room = -2,
                                }
                            },
                            Camera = new TRCamera
                            {
                                X = 30928,
                                Y = -4866 - 256,
                                Z = 86775,
                                Room = -2
                            },
                            //LookAtItem = ushort.MaxValue,
                            CameraAction = new FDCameraAction
                            {
                                Once = true,
                                MoveTimer = 2
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "A pad to activate the trapdoors and final doors.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 28160,
                                    Y = -512,
                                    Z = 93696,
                                    Room = -2,
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pad,
                                Timer = 28,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -6
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -5
                                    },
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
                        },
                        new EMPlaceholderFunction
                        {
                            Comments= "Placeholder for default mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMConvertTriggerFunction
                            {
                                Comments = "Tighten the timer in hard mode.",
                                EMType = EMType.ConvertTrigger,
                                Location = new EMLocation
                                {
                                    X = 28160,
                                    Y = -512,
                                    Z = 93696,
                                    Room = -2,
                                },
                                Timer = 17
                            }
                        },

                        new EMGenerateLightFunction
                        {
                            Comments = "Auto-generate vertex lighting in the new rooms.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1,-2,-3,-4 }
                        }
                    },
                    new EMEditorSet
                    {
                        // -7 Big drop
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a drop from Mines into a new puzzle area.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 44,
                            Width = 4,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 5,
                                Ceiling = 147,
                                Wall4 = 147,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 2048,
                                    Y = -9*1024,
                                    Z = 2048,
                                    Intensity1 = 4096,
                                    Fade1 = room82.Lights[0].Fade,
                                },
                                new EMRoomLight
                                {
                                    X = 1024+512,
                                    Y = -1280,
                                    Z = 1024+512,
                                    Intensity1 = 4096,
                                    Fade1 = room82.Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 25600 - 3072,
                                Y = -8704 + 23*256+12*256,
                                Z = 92160 - 1024,
                            },
                        },
                        // -6 Bottom pool
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a pool at the bottom of the drop.",
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 6,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 147,
                                Ceiling = 5,
                                Wall4 = 147,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+2048,//room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 2048,
                                    Y = -1024,
                                    Z = 2048,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 - 2048,
                                Y = 256 + 2048,
                                Z = 93184 - 2048,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 13,17 }
                            }
                        },
                        // -5 UW maze
                        new EMCreateRoomFunction
                        {
                            Comments = "Make an underwater maze.",
                            EMType = EMType.CreateRoom,
                            Height = 4,
                            Width = 14,
                            Depth = 14,
                            Textures = new EMTextureGroup
                            {
                                Floor = 147,
                                Ceiling = 147,
                                Wall4 = 147,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+2048,
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 2048 + 512,
                                    Y = -768,
                                    Z = 2048 + 3072 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 6 * 1024 + 512,
                                    Y = -768,
                                    Z = 11 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -768,
                                    Z = 8 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 11 * 1024 + 512,
                                    Y = -768,
                                    Z = 12 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 10 * 1024 + 512,
                                    Y = -768,
                                    Z = 5 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 7 * 1024 + 512,
                                    Y = -768,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 + 2048,
                                Y = 256 + 1024,
                                Z = 93184 - 2048 - 10 * 1024,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { }
                            }
                        },
                        // -4 Path to AW maze
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a link corridor between the underwater and above water mazes.",
                            EMType = EMType.CreateRoom,
                            Height = 5,
                            Width = 3,
                            Depth = 6,
                            Textures = new EMTextureGroup
                            {
                                Floor = 147,
                                Ceiling = 147,
                                Wall4 = 147,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+1024,//room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 2048 - 512,
                                    Y = -1024,
                                    Z = 2048,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 + 13 * 1024,
                                Y = 256,
                                Z = 93184 - 4096,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-1] = new List<int> { 7,8,9 },
                            }
                        },
                        // -3 AW maze
                        new EMCreateRoomFunction
                        {
                            Comments = "Make an above water maze.",
                            EMType = EMType.CreateRoom,
                            Height = 4,
                            Width = 13,
                            Depth = 8,
                            Textures = new EMTextureGroup
                            {
                                Floor = 147,
                                Ceiling = 147,
                                Wall4 = 147,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+2048,
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 11 * 1024 + 512,
                                    Y = -768,
                                    Z = 3 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 2048 + 512,
                                    Y = -768,
                                    Z = 2048 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 9 * 1024 + 512,
                                    Y = -768,
                                    Z = 5 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 6 * 1024 + 512,
                                    Y = -768,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 + 2048,
                                Z = 93184 - 2048 - 4 * 1024,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { }
                            }
                        },
                        // -2 Switch room
                        new EMCreateRoomFunction
                        {
                            Comments = "Room from above water maze back to the pool.",
                            EMType = EMType.CreateRoom,
                            Height = 7,
                            Width = 6,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 147,
                                Ceiling = 147,
                                Wall4 = 147,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+2048,
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 2048 + 512,
                                    Y = -1024,
                                    Z = 2048 - 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 - 2048,
                                Y = 0,
                                Z = 93184 - 2048 - 2048,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-1] = new List<int> { 6,13 },
                                [-2] = new List<int> { 9 },
                                [-3] = new List<int> { 5 },
                                [-127] = new List<int> { 10,14,18 }
                            }
                        },
                        // -1 Final door area
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a final room leading to Atlantis.",
                            EMType = EMType.CreateRoom,
                            Height = 9,
                            Width = 4,
                            Depth = 10,
                            Textures = new EMTextureGroup
                            {
                                Floor = 125,
                                Ceiling = 125,
                                Wall4 = 125,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+1024,
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 2048,
                                    Y = -1024,
                                    Z = 2048,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 + 3072 + 3072,
                                Y = 256,
                                Z = 93184 + 1024 - 18 * 1024,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-1] = new List<int> { 11,12,13,14,15,16,17,21,22,23,24,25,26,27 },
                                [-127] = new List<int> { 18 }
                            }
                        },

                        new EMVisibilityPortalFunction
                        {
                            Comments = "Visibility portals for the new rooms.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                // Default end-level into big drop
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 82,
                                    AdjoiningRoom = -7,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -11008,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -11008,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -8704,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -8704,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -7,
                                    AdjoiningRoom = 82,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -11008,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -11008,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -8704,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -8704,
                                            Z = 3 * 1024
                                        }
                                    }
                                },
                                // Big drop into pool
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
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
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
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        }
                                    }
                                },
                                // Pool into UW maze
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
                                            X = 5 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 256,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 256+1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 256+1024,
                                            Z = 2 * 1024
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
                                            Y = 256,
                                            Z = 12 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 13 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256+1024,
                                            Z = 13 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256 + 1024,
                                            Z = 12 * 1024
                                        }
                                    }
                                },
                                // Big drop into switch room
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -7,
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
                                            Y = 256 - 4096,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256 - 4096,
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
                                    BaseRoom = -2,
                                    AdjoiningRoom = -7,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256 - 4096,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256 - 4096,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -256,
                                            Z = 3 * 1024
                                        }
                                    }
                                },
                                // Switch room into AW maze
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
                                            X = 5 * 1024,
                                            Y = -1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
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
                                            Y = -1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Z = 3 * 1024
                                        }
                                    }
                                },
                                // AW maze into UW path
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -3,
                                    AdjoiningRoom = -4,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 12 * 1024,
                                            Y = -1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 12 * 1024,
                                            Y = -1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 12 * 1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 12 * 1024,
                                            Z = 4 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -4,
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
                                            Y = -1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                // UW path into UW maze
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
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
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
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 12 * 1024,
                                            Y = 256,
                                            Z = 12 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 13 * 1024,
                                            Y = 256,
                                            Z = 12 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 13 * 1024,
                                            Y = 256,
                                            Z = 13 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 12 * 1024,
                                            Y = 256,
                                            Z = 13 * 1024
                                        }
                                    }
                                },
                                // UW maze into Atlantis
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
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
                                            Y = 256,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 8 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -5,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7 * 1024,
                                            Y = 256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 256,
                                            Z = 4 * 1024
                                        }
                                    }
                                },
                            }
                        },

                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Collisional portals between all the new rooms.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                // Default end-level into big drop
                                // Big drop into switch room
                                // Switch room into AW maze
                                [82] = new Dictionary<short, EMLocation[]>
                                {
                                    [-7] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 26112 - 1024,
                                            Y = -8960,
                                            Z = 92672,
                                            Room = 82
                                        },
                                        new EMLocation
                                        {
                                            X = 26112 - 1024,
                                            Y = -8960,
                                            Z = 92672 + 1024,
                                            Room = 82
                                        }
                                    }
                                },
                                [-7] = new Dictionary<short, EMLocation[]>
                                {
                                    [82] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 26112,
                                            Y = -8960,
                                            Z = 92672,
                                            Room = -7
                                        },
                                        new EMLocation
                                        {
                                            X = 26112,
                                            Y = -8960,
                                            Z = 92672 + 1024,
                                            Room = -7
                                        }
                                    },
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064,
                                            Y = 256,
                                            Z = 92672 - 1024,
                                            Room = -7
                                        },
                                    },
                                },
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [-7] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 24064,
                                            Y = 256,
                                            Z = 92672,
                                            Room = -2
                                        },
                                    },
                                    [-3] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 27136 + 1024,
                                            Z = 90624,
                                            Room = -2
                                        },
                                    }
                                },
                                // Bottom pool into UW maze
                                [-6] = new Dictionary<short, EMLocation[]>
                                {
                                    [-5] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 28160,
                                            Y = 1280,
                                            Z = 93696,
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
                                            X = 28160 - 1024,
                                            Y = 1280,
                                            Z = 93696,
                                            Room = -5
                                        },
                                    }
                                },
                                // AW maze into switch room and UW path room
                                [-3] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 27136,
                                            Z = 90624,
                                            Room = -3
                                        },
                                    },
                                    [-4] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 38400 + 1024,
                                            Z = 90624,
                                            Room = -3
                                        },
                                    },
                                },
                                // UW path room into AW maze
                                [-4] = new Dictionary<short, EMLocation[]>
                                {
                                    [-3] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 38400,
                                            Z = 90624,
                                            Room = -4
                                        },
                                    },
                                },
                            }
                        },

                        // Big drop into pool
                        new EMVerticalCollisionalPortalFunction
                        {
                            Comments = "Collisional portals between the big drop and pool below.",
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 25088,
                                Y = 256,
                                Z = 93696,
                                Room = -7
                            },
                            Floor = new EMLocation
                            {
                                X = 25088,
                                Y = 256 + 1024,
                                Z = 93696,
                                Room = -6
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 25088,
                                Y = 256,
                                Z = 93696 - 1024,
                                Room = -7
                            },
                            Floor = new EMLocation
                            {
                                X = 25088,
                                Y = 256 + 1024,
                                Z = 93696 - 1024,
                                Room = -6
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 25088 - 1024,
                                Y = 256,
                                Z = 93696,
                                Room = -7
                            },
                            Floor = new EMLocation
                            {
                                X = 25088 - 1024,
                                Y = 256 + 1024,
                                Z = 93696,
                                Room = -6
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 25088 - 1024,
                                Y = 256,
                                Z = 93696 - 1024,
                                Room = -7
                            },
                            Floor = new EMLocation
                            {
                                X = 25088 - 1024,
                                Y = 256 + 1024,
                                Z = 93696 - 1024,
                                Room = -6
                            }
                        },
                        // UW maze into AW path
                        new EMVerticalCollisionalPortalFunction
                        {
                            Comments = "Collisional portals between the UW maze and path to the AW maze.",
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 39424,
                                Y = 256,
                                Z = 93696,
                                Room = -4
                            },
                            Floor = new EMLocation
                            {
                                X = 39424,
                                Y = 256 + 1024,
                                Z = 93696,
                                Room = -5
                            }
                        },
                        // UW maze into Atlantis
                        new EMVerticalCollisionalPortalFunction
                        {
                            Comments = "Collisional portals between the UZ maze and final room.",
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 33280,
                                Y = 256,
                                Z = 84480,
                                Room = -1
                            },
                            Floor = new EMLocation
                            {
                                X = 33280,
                                Y = 256 + 1024,
                                Z = 84480,
                                Room = -5
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
                                    RoomNumber = -7,
                                    FaceIndices = new int[]{ 95 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -768
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -7,
                                    FaceIndices = new int[]{ 60 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -7,
                                    FaceIndices = new int[]{ 94 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -7,
                                    FaceIndices = new int[]{ 59 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -7,
                                    FaceIndices = new int[]{ 13 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = 512
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = 512
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndices = new int[]{ 37,5 },
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
                            },
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [147] = new EMGeometryMap
                                {
                                    [-6] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 23,29 }
                                    }
                                },
                                [5] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 62 }
                                    },
                                    [-4] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 13 }
                                    },
                                    [-5] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 145,324 }
                                    }
                                },
                                [588] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 5,37 }
                                    }
                                },
                                [127] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 12 }
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
                                [-7] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 14 }
                                },
                                [-6] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 33 }
                                },
                                [-5] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 35 }
                                },
                                [-4] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                },
                                [-3] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 10,152 }
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 8,9,32 }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 4,36 }
                                }
                            }
                        },
                        new EMFloodFunction
                        {
                            Comments = "Flood the pool after the drop and the maze.",
                            EMType = EMType.Flood,
                            RoomNumbers = new int[] { -5,-6 }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door3,
                            Intensity = level.Entities[74].Intensity,
                            Location = new EMLocation
                            {
                                X = 33280,
                                Z = 83456 - 1*1024,
                                Room = -1
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add doors to the final room.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door4,
                            Intensity = level.Entities[74].Intensity,
                            Location = new EMLocation
                            {
                                X = 33280 - 1024,
                                Z = 83456 - 1*1024,
                                Room = -1
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Switch for the doors.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.WallSwitch,
                            Intensity = level.Entities[96].Intensity,
                            Location = new EMLocation
                            {
                                X = 28160,
                                Z = 90624,
                                Room = -3,
                                Angle = 16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Timed swim to Atlantis.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 28160,
                                    Z = 90624,
                                    Room = -3,
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Switch,
                                SwitchOrKeyRef = -1,
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
                                        Action = FDTrigAction.PlaySoundtrack,
                                        Parameter = 20
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
                                    X = 28160,
                                    Z = 90624,
                                    Room = -3,
                                },
                                Timer = 28,
                            }
                        },
                        new EMRemoveTriggerFunction
                        {
                            Comments = "Get rid of the normal end level trigger.",
                            EMType = EMType.RemoveTrigger,
                            Rooms = new List<int> { 82 }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Add end level triggers to the final room.",
                            EMType = EMType.Trigger,
                            ExpandedLocations = new EMLocationExpander
                            {
                                Location = new EMLocation
                                {
                                    X = 33280-1024,
                                    Z = 80384 - 2048,
                                    Room = -1
                                },
                                ExpandX = 2,
                                ExpandZ = 1
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
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "A pickup for explorers.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.UziAmmo_S_P,
                            Intensity = level.Entities[68].Intensity,
                            Location = new EMLocation
                            {
                                X = 39424,
                                Y = 1280,
                                Z = 82432,
                                Room = -5
                            }
                        },

                        new EMGenerateLightFunction
                        {
                            Comments = "Auto-generate vertex lighting in the new rooms.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1,-2,-3,-4,-5,-6,-7 }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Tinnos-style fire room ending.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 44,
                            Width = 3,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 5,
                                Ceiling = 147,
                                Wall4 = 147,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -9*1024,
                                    Z = 2048,
                                    Intensity1 = 4096,
                                    Fade1 = room82.Lights[0].Fade,
                                },
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -512,
                                    Z = 2048,
                                    Intensity1 = 2048,
                                    Fade1 = room82.Lights[0].Fade,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 25600 - 2048,
                                Y = -8704 + 23*256+12*256,
                                Z = 92160 - 1024,
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 3,
                            Depth = 8,
                            Textures = new EMTextureGroup
                            {
                                Floor = 147,
                                Ceiling = 5,
                                Wall4 = 147,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+2048,//room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -1024-512,
                                    Z = 6*1024,
                                    Intensity1 = 2048,
                                    Fade1 = 387,
                                },
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -1024-512,
                                    Z = 2*1024,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 - 1024,
                                Y = 256 + 2048,
                                Z = 93184 - 2048-4096,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-4] = new List<int> { 9,10,11 }
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 9,
                            Width = 5,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 125,
                                Ceiling = 125,
                                Wall4 = 125,
                                Wall1 = 126,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+2048,//room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1024 + 512,
                                    Y = -512,
                                    Z = 2*1024,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 3*1024 + 512,
                                    Y = -768,
                                    Z = 2*1024,
                                    Intensity1 = 3072,
                                    Fade1 = 2048,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 - 1024,
                                Y = 256 + 2048-2048,
                                Z = 93184 - 2048-4096,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-1] = new List<int> { 9,10,13,14 }
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 20,
                            Width = 7,
                            Depth = 8,
                            Textures = new EMTextureGroup
                            {
                                Floor = 125,
                                Ceiling = 125,
                                Wall4 = 125,
                                Wall2 = 128,
                                Wall1 = 126,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+2048,//room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1*1024 + 512,
                                    Y = -512-2048,
                                    Z = 4*1024,
                                    Intensity1 = 3072,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 5*1024 + 512,
                                    Y = -2048-2048-512,
                                    Z = 4*1024,
                                    Intensity1 = 3072,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 5*1024,
                                    Y = -2048-512,
                                    Z = 2*1024,
                                    Intensity1 = 2500,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 4*1024+512,
                                    Y = -1024-512,
                                    Z = 6*1024+512,
                                    Intensity1 = 2500,
                                    Fade1 = 2048,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 - 1024+3072,
                                Y = 256 + 2048-2048-256+1024+1024,
                                Z = 93184 - 2048-4096-2048,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-9] = new List<int> { 5*8+3,3*8+2 },
                                [-8] = new List<int> { 2*8+4,1*8+1 },
                                [-7] = new List<int> { 2*8+6 },
                                [-6] = new List<int> { 4*8+5 },
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 20,
                            Width = 7,
                            Depth = 8,
                            Textures = new EMTextureGroup
                            {
                                Floor = 125,
                                Ceiling = 125,
                                Wall4 = 125,
                                Wall2 = 128,
                                Wall1 = 126,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+2048,//room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 5*1024 + 512,
                                    Y = -512-2048,
                                    Z = 4*1024,
                                    Intensity1 = 3072,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 1*1024 + 512,
                                    Y = -2048-2048-512,
                                    Z = 4*1024,
                                    Intensity1 = 3072,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 2*1024,
                                    Y = -2048-512,
                                    Z = 2*1024,
                                    Intensity1 = 2500,
                                    Fade1 = 2048,
                                },
                                new EMRoomLight
                                {
                                    X = 2*1024+512,
                                    Y = -1024-512,
                                    Z = 6*1024+512,
                                    Intensity1 = 2500,
                                    Fade1 = 2048,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 - 1024+3072+3072+2048,
                                Y = 256 + 2048-2048-256+1024+1024,
                                Z = 93184 - 2048-4096-2048,
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-5] = new List<int> { 5*8+5 },
                                [-6] = new List<int> { 1*8+6 },
                                [-8] = new List<int> { 3*8+4 },
                                [-9] = new List<int> { 3*8+1 },
                            },
                            HardVariant = new EMCreateRoomFunction
                            {
                                Comments = "Difficult final jump in hard mode.",
                                EMType = EMType.CreateRoom,
                                Height = 20,
                                Width = 7,
                                Depth = 8,
                                Textures = new EMTextureGroup
                                {
                                    Floor = 125,
                                    Ceiling = 125,
                                    Wall4 = 125,
                                    Wall2 = 128,
                                    Wall1 = 126,
                                    WallAlignment = Direction.Down,
                                    RandomRotationSeed = 18541712
                                },
                                AmbientLighting = room82.AmbientIntensity,
                                DefaultVertex = new EMRoomVertex
                                {
                                    Lighting = 4096+2048,//room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                                },
                                Lights = new EMRoomLight[]
                                {
                                    new EMRoomLight
                                    {
                                        X = 5*1024 + 512,
                                        Y = -512-2048,
                                        Z = 4*1024,
                                        Intensity1 = 3072,
                                        Fade1 = 2048,
                                    },
                                    new EMRoomLight
                                    {
                                        X = 1*1024 + 512,
                                        Y = -2048-2048-512,
                                        Z = 4*1024,
                                        Intensity1 = 3072,
                                        Fade1 = 2048,
                                    },
                                    new EMRoomLight
                                    {
                                        X = 2*1024,
                                        Y = -2048-512,
                                        Z = 2*1024,
                                        Intensity1 = 2500,
                                        Fade1 = 2048,
                                    },
                                    new EMRoomLight
                                    {
                                        X = 2*1024+512,
                                        Y = -1024-512,
                                        Z = 6*1024+512,
                                        Intensity1 = 2500,
                                        Fade1 = 2048,
                                    }
                                },
                                LinkedLocation = new EMLocation
                                {
                                    X = 26112,
                                    Y = -8704,
                                    Z = 92672,
                                    Room = 82
                                },
                                Location = new EMLocation
                                {
                                    X = 24576 - 1024+3072+3072+2048,
                                    Y = 256 + 2048-2048-256+1024+1024,
                                    Z = 93184 - 2048-4096-2048,
                                },
                                FloorHeights = new Dictionary<sbyte, List<int>>
                                {
                                    [-6] = new List<int> { 1*8+6,5*8+5 },
                                    [-8] = new List<int> { 3*8+4 },
                                    [-9] = new List<int> { 3*8+1 },
                                },
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 6,
                            Depth = 4,
                            Textures = new EMTextureGroup
                            {
                                Floor = 125,
                                Ceiling = 125,
                                Wall4 = 125,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 18541712
                            },
                            AmbientLighting = room82.AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = 4096+2048,//room82.RoomData.Vertices[room82.RoomData.Rectangles[2].Vertices[0]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1*1024 + 512,
                                    Y = -512,
                                    Z = 2*1024,
                                    Intensity1 = 3072,
                                    Fade1 = 2048,
                                }
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 26112,
                                Y = -8704,
                                Z = 92672,
                                Room = 82
                            },
                            Location = new EMLocation
                            {
                                X = 24576 - 1024+3072+3072+2048+4096+1024,
                                Y = 256 + 2048-2048-256,
                                Z = 93184 - 2048-4096,
                            },
                        },

                        new EMVisibilityPortalFunction
                        {
                            Comments = "Visibility portals for the new rooms.",
                            EMType = EMType.VisibilityPortal,
                            Portals = new List<EMVisibilityPortal>
                            {
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 82,
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
                                            Y = -11008,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -11008,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -8704,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -8704,
                                            Z = 1 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -6,
                                    AdjoiningRoom = 82,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -11008,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -11008,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -8704,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -8704,
                                            Z = 3 * 1024
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
                                            Y = 256,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 7 * 1024
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
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 1 * 1024
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
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
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
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 256,
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
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -2048,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
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
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -2048,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -2048,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
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
                                            X = 6 * 1024,
                                            Y = -3072,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = -3072,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 2048,
                                            Z = 7 * 1024
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
                                            Y = -3072,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -3072,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 2048,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 2048,
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
                                            Y = -2048,
                                            Z = 5 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = -2048,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Z = 5 * 1024
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
                                            Y = -2048,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -2048,
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
                                [82] = new Dictionary<short, EMLocation[]>
                                {
                                    [-6] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 26112 - 1024,
                                            Y = -8960,
                                            Z = 92672,
                                            Room = 82
                                        },
                                        new EMLocation
                                        {
                                            X = 26112 - 1024,
                                            Y = -8960,
                                            Z = 92672 + 1024,
                                            Room = 82
                                        }
                                    }
                                },
                                [-6] = new Dictionary<short, EMLocation[]>
                                {
                                    [82] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 26112,
                                            Y = -8960,
                                            Z = 92672,
                                            Room = -6
                                        },
                                        new EMLocation
                                        {
                                            X = 26112,
                                            Y = -8960,
                                            Z = 92672 + 1024,
                                            Room = -6
                                        }
                                    },
                                },
                                [-5] = new Dictionary<short, EMLocation[]>
                                {
                                    [-4] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 25088+1024,
                                            Y = 1280,
                                            Z = 89600,
                                            Room = -5
                                        },
                                        new EMLocation
                                        {
                                            X = 25088+1024,
                                            Y = 1280,
                                            Z = 89600-1024,
                                            Room = -5
                                        }
                                    },
                                },
                                [-4] = new Dictionary<short, EMLocation[]>
                                {
                                    [-3] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 27136+1024,
                                            Z = 89600,
                                            Room = -4
                                        },
                                        new EMLocation
                                        {
                                            X = 27136+1024,
                                            Z = 89600-1024,
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
                                            X = 27136,
                                            Z = 89600,
                                            Room = -3
                                        },
                                        new EMLocation
                                        {
                                            X = 27136,
                                            Z = 89600-1024,
                                            Room = -3
                                        }
                                    },
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 32256+1024,
                                            Z = 91648,
                                            Room = -3
                                        },
                                        new EMLocation
                                        {
                                            X = 32256+1024,
                                            Z = 91648-1*1024,
                                            Room = -3
                                        },
                                        new EMLocation
                                        {
                                            X = 32256+1024,
                                            Z = 91648-2*1024,
                                            Room = -3
                                        },
                                        new EMLocation
                                        {
                                            X = 32256+1024,
                                            Z = 91648-3*1024,
                                            Room = -3
                                        },
                                        new EMLocation
                                        {
                                            X = 32256+1024,
                                            Z = 91648-4*1024,
                                            Room = -3
                                        },
                                        new EMLocation
                                        {
                                            X = 32256+1024,
                                            Z = 91648-5*1024,
                                            Room = -3
                                        },
                                    }
                                },
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [-3] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 32256,
                                            Z = 91648,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 32256,
                                            Z = 91648-1*1024,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 32256,
                                            Z = 91648-2*1024,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 32256,
                                            Z = 91648-3*1024,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 32256,
                                            Z = 91648-4*1024,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 32256,
                                            Z = 91648-5*1024,
                                            Room = -2
                                        },
                                    },
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 37376+1024,
                                            Z = 89600,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 37376+1024,
                                            Z = 89600-1024,
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
                                            X = 37376,
                                            Z = 89600,
                                            Room = -1
                                        },
                                        new EMLocation
                                        {
                                            X = 37376,
                                            Z = 89600-1024,
                                            Room = -1
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
                                X = 25088,
                                Y = 256,
                                Z = 93696,
                                Room = -6
                            },
                            Floor = new EMLocation
                            {
                                X = 25088,
                                Y = 256 + 1024,
                                Z = 93696,
                                Room = -5
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 25088,
                                Y = 256,
                                Z = 93696 - 1024,
                                Room = -6
                            },
                            Floor = new EMLocation
                            {
                                X = 25088,
                                Y = 256 + 1024,
                                Z = 93696 - 1024,
                                Room = -5
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 25088,
                                Y = 256,
                                Z = 89600,
                                Room = -4
                            },
                            Floor = new EMLocation
                            {
                                X = 25088,
                                Y = 256 + 1024,
                                Z = 89600,
                                Room = -5
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 25088,
                                Y = 256,
                                Z = 89600 - 1024,
                                Room = -4
                            },
                            Floor = new EMLocation
                            {
                                X = 25088,
                                Y = 256 + 1024,
                                Z = 89600 - 1024,
                                Room = -5
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
                                    RoomNumber = -6,
                                    FaceIndices = new int[]{ 69 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
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
                                    RoomNumber = -6,
                                    FaceIndices = new int[]{ 23 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -512
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -6,
                                    FaceIndices = new int[]{ 68 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = 768
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = 1024
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -6,
                                    FaceIndices = new int[]{ 22 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 768
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndices = new int[]{ 39 },
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
                                    RoomNumber = -3,
                                    FaceIndices = new int[]{ 206 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            Y = 512
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = 512
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -2,
                                    FaceIndices = new int[]{ 23 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
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
                                    RoomNumber = -1,
                                    FaceIndices = new int[]{ 30 },
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
                                    RoomNumber = -1,
                                    FaceIndices = new int[] { 30 },
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 2,
                                        [1] = 3,
                                        [2] = 0,
                                        [3] = 1
                                    }
                                },
                                new EMFaceRotation
                                {
                                    RoomNumber = -3,
                                    FaceIndices = new int[] { 120,152,24 },
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 2,
                                        [1] = 3,
                                        [2] = 0,
                                        [3] = 1
                                    }
                                },
                                new EMFaceRotation
                                {
                                    RoomNumber = -3,
                                    FaceIndices = new int[] { 8,33,17,103,40 },
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
                                    RoomNumber = -2,
                                    FaceIndices = new int[] { 0,52 },
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
                                    RoomNumber = -2,
                                    FaceIndices = new int[] { 163,137,101,130,66,126 },
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
                                    FaceIndices = new int[] { 156,149,108 },
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
                            Comments = "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [5] = new EMGeometryMap
                                {
                                    [-4] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0,9 }
                                    }
                                },
                                [147] = new EMGeometryMap
                                {
                                    [-5] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 10,14 }
                                    }
                                },
                                [127] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 5 }
                                    }
                                },
                                [126] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 23 }
                                    }
                                },
                                [149] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0,80,174 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 42,172 }
                                    }
                                },
                                [138] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 72,96,141 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 95,81 }
                                    }
                                },
                                [65] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 127,107 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 97,19,86 }
                                    }
                                },
                                [84] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 132,74 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 26,62 }
                                    }
                                },
                                [81] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 17,54 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 156 }
                                    }
                                },
                                [78] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 8,33,111,86,120,152,40, }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 52,72,178,163,137,149,108 }
                                    }
                                },
                                [72] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 24 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0,101 }
                                    }
                                },
                                [75] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 68,137,198,103 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 130 }
                                    }
                                },
                                [73] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 63,143,179 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 66,126 }
                                    }
                                },
                                [79] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 33,120,12}
                                    }
                                },
                                [63] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 98 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 64,122,118 }
                                    }
                                },
                                [85] = new EMGeometryMap
                                {
                                    [-3] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 189,164 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 70,91 }
                                    }
                                },
                                [588] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 30,39 }
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
                                [-4] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 28,29,36,37 }
                                },
                                [-3] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 21,22,28,29,
                                    209,197,185,178,173,158,
                                    208,196,184,176,172,157,
                                    207,195,183,176,171,156,
                                    193,194,181,182,169,170,154,155}
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 169,170,160,161,
                                    2,3,4,5,6,14,15,16,17,18,24,25,28,29,30,31,32,35,36,37,38,39,44,45,46,47}
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,3,8,9,31,38 }
                                }
                            }
                        },

                        new EMKillLaraFunction
                        {
                            Comments= "Add death tiles",
                            EMType = EMType.KillLara,
                            Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("minesdeath.json"))[Level],
                        },
                        new EMAddSoundSourceFunction
                        {
                            Comments = "Add a lava sound source.",
                            EMType = EMType.AddSoundSource,
                            Source = new TRSoundSource
                            {
                                SoundID = 148,
                                X = 32782,
                                Y = 2048,
                                Z = 89059,
                                Flags = 192
                            }
                        },

                        new EMAddEntityFunction
                        {
                            Comments = "Add some embers.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.LavaEmitter_N,
                            Location = new EMLocation
                            {
                                X = 33280-1024,
                                Y = 2048,
                                Z = 89600+1024,
                                Room = -2
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.LavaEmitter_N,
                            Location = new EMLocation
                            {
                                X = 36352,
                                Y = 2048,
                                Z = 87552,
                                Room = -2
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger the embers.",
                            EMType  = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 26112,
                                    Z = 89600,
                                    Room = -4
                                },
                                new EMLocation
                                {
                                    X = 26112,
                                    Z = 89600-1024,
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
                                        Parameter = -2
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },

                        new EMRemoveTriggerFunction
                        {
                            Comments = "Get rid of the normal end level trigger.",
                            EMType = EMType.RemoveTrigger,
                            Rooms = new List<int> { 82 }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Add end level triggers to the final room.",
                            EMType = EMType.Trigger,
                            ExpandedLocations = new EMLocationExpander
                            {
                                Location = new EMLocation
                                {
                                    X = 40448,
                                    Z = 89600-1024,
                                    Room = -1
                                },
                                ExpandX = 1,
                                ExpandZ = 2
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
                        },

                        new EMAddEntityFunction
                        {
                            Comments = "Add doors to the final room.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door3,
                            Intensity = level.Entities[73].Intensity,
                            Location = new EMLocation
                            {
                                X = 38400-1024,
                                Z = 89600,
                                Room = -1,
                                Angle = -16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door4,
                            Intensity = level.Entities[74].Intensity,
                            Location = new EMLocation
                            {
                                X = 38400-1024,
                                Z = 89600-1024,
                                Room = -1,
                                Angle = -16384
                            }
                        },

                        new EMAddEntityFunction
                        {
                            Comments = "Add a switch for the doors.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.WallSwitch,
                            Intensity = level.Entities[5].Intensity,
                            Location = new EMLocation
                            {
                                X = 28160,
                                Z = 86528,
                                Room = -3,
                                Angle = -32768
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Trigger the doors.",
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
                                Comments = "Timed run in hard mode.",
                                EMType = EMType.Trigger,
                                EntityLocation = -1,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    SwitchOrKeyRef = -1,
                                    TrigType = FDTrigType.Switch,
                                    Timer = 18,
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
                                            Action = FDTrigAction.PlaySoundtrack,
                                            Parameter = 16
                                        }
                                    }
                                },
                            }
                        },
                        new EMCameraTriggerFunction
                        {
                            Comments = "Add a camera (default mode only).",
                            EMType = EMType.CameraTriggerFunction,
                            Camera = new TRCamera
                            {
                                X = 33280-1024-512,
                                Y = 2048-2048+256,
                                Z = 89600+1024,
                                Room = -2
                            },
                            AttachToItems = new int[]{ -1 },
                            LookAtItem = -2,
                            CameraAction = new FDCameraAction
                            {
                                Timer = 5
                            },
                            HardVariant = new EMPlaceholderFunction
                            {
                                EMType = EMType.NOOP
                            }
                        },

                        new EMFloodFunction
                        {
                            Comments = "Flood the second room.",
                            EMType = EMType.Flood,
                            RoomNumbers = new int[] { -5 }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments = "Generate light.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short>{ -1,-2,-3,-4,-5,-6}
                        }
                    }
                }
            };

            EMCreateRoomFunction func = mapping.AllWithin[1][1][2] as EMCreateRoomFunction;
            foreach (EMLocation loc in JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("mineswaterwalls.json"))[Level])
            {
                int x = (loc.X - func.Location.X) / 1024;
                int z = (loc.Z - func.Location.Z) / 1024;
                func.FloorHeights[-127].Add(x * func.Depth + z);
            }
            func = mapping.AllWithin[1][1][4] as EMCreateRoomFunction;
            foreach (EMLocation loc in JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("minesabovewaterwalls.json"))[Level])
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
                            Comments = "Remove the default lever texture in room 11.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[11].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                {
                                    [11] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 10 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 38400,
                                    Y = -5632,
                                    Z = 25088,
                                    Room = 11,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 38400,
                                    Y = -5632,
                                    Z = 25088 - 1024,
                                    Room = 11,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 38400,
                                    Y = -5632,
                                    Z = 25088,
                                    Room = 11,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 9 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 38400,
                                    Y = -5632,
                                    Z = 25088 - 1024,
                                    Room = 11,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 6 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 38400,
                                    Y = -5632,
                                    Z = 25088 - 2048,
                                    Room = 11,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 38400,
                                    Y = -5632,
                                    Z = 25088 - 2048,
                                    Room = 11,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 38400 + 1024,
                                    Y = -5632,
                                    Z = 25088 - 2048,
                                    Room = 11,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 38400 + 1024,
                                    Y = -5632,
                                    Z = 25088 - 2048,
                                    Room = 11
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 38400 + 3072,
                                    Y = -5632,
                                    Z = 25088,
                                    Room = 11,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 44544 - 2048,
                                    Y = -5632,
                                    Z = 23040,
                                    Room = 11,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[11].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [11] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 51 }
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
                            Comments = "Remove the default lever texture in room 12.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[5].RoomData.Rectangles[36].Texture] = new EMGeometryMap
                                {
                                    [12] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 37 }
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
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = -5376,
                                    Z = 31232,
                                    Room = 12,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[12].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [12] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = -5376,
                                    Z = 31232 + 1024,
                                    Room = 12,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[12].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [12] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = -5376,
                                    Z = 31232 + 1024,
                                    Room = 12
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[12].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [12] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 41 }
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
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 55808 + 1024,
                                    Y = -5376,
                                    Z = 31232 + 1024,
                                    Room = 12
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[12].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [12] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 54 }
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
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 55808 + 1024,
                                    Y = -5376,
                                    Z = 31232 - 1024,
                                    Room = 5,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[12].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [5] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 55808 + 1024,
                                    Y = -5376,
                                    Z = 31232 - 2*1024,
                                    Room = 5,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[12].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [5] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 55808 + 1024,
                                    Y = -5376,
                                    Z = 31232 - 3*1024,
                                    Room = 5,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[12].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [5] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 56832,
                                    Y = -7936,
                                    Z = 36352,
                                    Room = 12
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[12].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [12] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 10,
                                Location = new EMLocation
                                {
                                    X = 56832,
                                    Y = -7936,
                                    Z = 36352,
                                    Room = 12,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[12].RoomData.Rectangles[37].Texture] = new EMGeometryMap
                                    {
                                        [12] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 70 }
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
                            Comments = "Remove the default lever texture in room 14.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[14].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                {
                                    [14] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 12 }
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
                                EntityIndex = 13,
                                Location = new EMLocation
                                {
                                    X = 58880,
                                    Y = -6144,
                                    Z = 44544,
                                    Room = 14,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[14].RoomData.Rectangles[12].Texture] = new EMGeometryMap
                                    {
                                        [14] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 10 }
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
                                EntityIndex = 13,
                                Location = new EMLocation
                                {
                                    X = 58880 - 1024,
                                    Y = -6144,
                                    Z = 44544,
                                    Room = 14,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[14].RoomData.Rectangles[12].Texture] = new EMGeometryMap
                                    {
                                        [14] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 6 }
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
                                EntityIndex = 13,
                                Location = new EMLocation
                                {
                                    X = 58880 - 1024,
                                    Y = -6144,
                                    Z = 44544,
                                    Room = 14
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[14].RoomData.Rectangles[12].Texture] = new EMGeometryMap
                                    {
                                        [14] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 7 }
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
                                EntityIndex = 13,
                                Location = new EMLocation
                                {
                                    X = 58880,
                                    Y = -6144,
                                    Z = 44544,
                                    Room = 14
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[14].RoomData.Rectangles[12].Texture] = new EMGeometryMap
                                    {
                                        [14] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 11 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to suit the lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 11 },
                                        RoomNumber = 14,
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
                                EntityIndex = 13,
                                Location = new EMLocation
                                {
                                    X = 60928,
                                    Y = -3840,
                                    Z = 44544,
                                    Room = 21
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[14].RoomData.Rectangles[12].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 13,
                                Location = new EMLocation
                                {
                                    X = 60928,
                                    Y = -3840,
                                    Z = 44544,
                                    Room = 21,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[14].RoomData.Rectangles[12].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 13,
                                Location = new EMLocation
                                {
                                    X = 60928 + 1024,
                                    Y = -3840,
                                    Z = 44544,
                                    Room = 21,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Remove the default lever texture in room 11.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[14].RoomData.Rectangles[12].Texture] = new EMGeometryMap
                                    {
                                        [21] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 14 }
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
                            Comments = "Remove the default lever texture in room 27.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[27].RoomData.Rectangles[22].Texture] = new EMGeometryMap
                                {
                                    [27] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 6 }
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
                                    [level.Rooms[27].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [27] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 6 }
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
                                EntityIndex = 24,
                                Location = new EMLocation
                                {
                                    X = 52736 + 1024,
                                    Y = -4352,
                                    Z = 57856 - 1024,
                                    Room = 27,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[27].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [27] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 24,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = -3072,
                                    Z = 61952,
                                    Room = 27
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[27].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [27] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 33 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to suit the lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 33 },
                                        RoomNumber = 27,
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
                                EntityIndex = 24,
                                Location = new EMLocation
                                {
                                    X = 53760 + 1024,
                                    Y = -3072,
                                    Z = 61952,
                                    Room = 17
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[27].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [17] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 24,
                                Location = new EMLocation
                                {
                                    X = 53760 + 2048,
                                    Y = -3072,
                                    Z = 61952,
                                    Room = 17
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[27].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [17] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 24,
                                Location = new EMLocation
                                {
                                    X = 53760 + 4096,
                                    Y = -3072 + 256,
                                    Z = 61952,
                                    Room = 17
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[27].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [17] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 114 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to suit the lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 114 },
                                        RoomNumber = 17,
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
                                EntityIndex = 24,
                                Location = new EMLocation
                                {
                                    X = 59904,
                                    Y = -2304,
                                    Z = 62976,
                                    Room = 54,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[27].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [54] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 7 }
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
                                EntityIndex = 24,
                                Location = new EMLocation
                                {
                                    X = 59904,
                                    Y = -2304,
                                    Z = 62976,
                                    Room = 54,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[27].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [54] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 11 }
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
                            Comments = "Remove the default lever texture in room 40.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[40].RoomData.Rectangles[12].Texture] = new EMGeometryMap
                                {
                                    [40] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 9 }
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
                                    [level.Rooms[40].RoomData.Rectangles[9].Texture] = new EMGeometryMap
                                    {
                                        [40] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 9 }
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
                                EntityIndex = 40,
                                Location = new EMLocation
                                {
                                    X = 46592,
                                    Y = -3840,
                                    Z = 51712,
                                    Room = 40,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[40].RoomData.Rectangles[9].Texture] = new EMGeometryMap
                                    {
                                        [40] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 40,
                                Location = new EMLocation
                                {
                                    X = 46592,
                                    Y = -3840,
                                    Z = 51712 - 1024,
                                    Room = 40,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[40].RoomData.Rectangles[9].Texture] = new EMGeometryMap
                                    {
                                        [40] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 11 }
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
                                EntityIndex = 40,
                                Location = new EMLocation
                                {
                                    X = 46592,
                                    Y = -3840,
                                    Z = 51712 - 1024,
                                    Room = 40,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[40].RoomData.Rectangles[9].Texture] = new EMGeometryMap
                                    {
                                        [40] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 5 }
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
                                EntityIndex = 40,
                                Location = new EMLocation
                                {
                                    X = 46592,
                                    Y = -3840,
                                    Z = 51712,
                                    Room = 40,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[40].RoomData.Rectangles[9].Texture] = new EMGeometryMap
                                    {
                                        [40] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 8 }
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
                            Comments = "Remove the default lever texture in room 44.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[44].RoomData.Rectangles[12].Texture] = new EMGeometryMap
                                {
                                    [44] = new Dictionary<EMTextureFaceType, int[]>
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
                            new EMRefaceFunction
                            {
                                Comments = "Effectively NOOP.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 76288,
                                    Y = -11008,
                                    Z = 20992,
                                    Room = 44,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 41,
                                Location = new EMLocation
                                {
                                    X = 76288,
                                    Y = -11008,
                                    Z = 20992,
                                    Room = 44
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[44].RoomData.Rectangles[17].Texture] = new EMGeometryMap
                                    {
                                        [44] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 15 }
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
                            Comments = "Remove the default lever texture in room 64.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[64].RoomData.Rectangles[4].Texture] = new EMGeometryMap
                                {
                                    [64] = new Dictionary<EMTextureFaceType, int[]>
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
                            new EMRefaceFunction
                            {
                                Comments = "Effectively NOOP.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[64].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [64] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 59,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = -10240,
                                    Z = 93696,
                                    Room = 64
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[64].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [64] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 4 }
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
                            Comments = "Remove the default lever texture in room 64.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[67].RoomData.Rectangles[33].Texture] = new EMGeometryMap
                                {
                                    [67] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 38 }
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
                                    [level.Rooms[67].RoomData.Rectangles[38].Texture] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 51712,
                                    Y = -9984,
                                    Z = 95744,
                                    Room = 67,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[67].RoomData.Rectangles[38].Texture] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 51712,
                                    Y = -9984,
                                    Z = 95744,
                                    Room = 67,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[67].RoomData.Rectangles[38].Texture] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 51712 - 1024,
                                    Y = -9984,
                                    Z = 95744,
                                    Room = 67,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[67].RoomData.Rectangles[38].Texture] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 20 }
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 51712 - 1024,
                                    Y = -9984,
                                    Z = 95744 + 1024,
                                    Room = 67,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[67].RoomData.Rectangles[38].Texture] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 51712 - 1024,
                                    Y = -9984,
                                    Z = 95744 + 2048,
                                    Room = 67,
                                    Angle = -16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[67].RoomData.Rectangles[38].Texture] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 26 }
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 51712,
                                    Y = -9984,
                                    Z = 95744 + 2048,
                                    Room = 67,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[67].RoomData.Rectangles[38].Texture] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 41 }
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
                                EntityIndex = 66,
                                Location = new EMLocation
                                {
                                    X = 51712,
                                    Y = -9984,
                                    Z = 95744 + 2048,
                                    Room = 67,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[67].RoomData.Rectangles[38].Texture] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 47 }
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
                            new EMRefaceFunction
                            {
                                Comments = "Effectively NOOP.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[89].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [89] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 79,
                                Location = new EMLocation
                                {
                                    X = 75264,
                                    Y = -6656,
                                    Z = 51712,
                                    Room = 89,
                                    Angle = -32768
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
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
                            }
                        },
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever location.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 79,
                                Location = new EMLocation
                                {
                                    X = 75264 + 1024,
                                    Y = -6656,
                                    Z = 51712,
                                    Room = 89,
                                    Angle = 16384
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Add a lever texture.",
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
                            }
                        },
                    }
                },
            };

            mapping.Mirrored = new EMEditorSet
            {
                new EMMoveEntityFunction
                {
                    Comments = "Moves door 62 so that it can open properly, otherwise Lara has to glitch through.",
                    EMType = EMType.MoveEntity,
                    EntityIndex = 62,
                    TargetLocation = new EMLocation
                    {
                        X = 46592,
                        Y = -11264,
                        Z = 96768,
                        Room = 65,
                        Angle = -32768
                    }
                }
            };

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();

            mapping.RewardEntities = new List<int> { 90, 91, 94, 95, 98, 99, 100 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 38400,
                            Y = -8960,
                            Z = 82432
                        },
                        new Location
                        {
                            X = 38400,
                            Y = -8960,
                            Z = 83456
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door1,
                            X = 38400,
                            Y = -8960,
                            Z = 85504,
                            Intensity = 6400,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 38588,
                            Y = -10187,
                            Z = 99477,
                            Room = 80
                        }
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 40,
                            LinkedLocation = new EMLocation
                            {
                                X = 38400,
                                Y = -8960,
                                Z = 85504,
                                Room = 80
                            },
                            NewLocation = new EMLocation
                            {
                                X = 36864,
                                Y = -8960,
                                Z = 80896,
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [80] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 38400,
                                            Y = -8960,
                                            Z = 84480,
                                            Room = 80
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [80] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 38400,
                                            Y = -8960,
                                            Z = 85504,
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
                                    BaseRoom = 80,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = -9984,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -9984,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -8960,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = -8960,
                                            Z = 1024
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 80,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -9984,
                                            Z = 4096
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = -9984,
                                            Z = 4096
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = -8960,
                                            Z = 4096
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -8960,
                                            Z = 4096
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
                                    FaceIndex = 9,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = 1024,
                                            Z = -3072
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = -1024,
                                            Z = -3072
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = -1024,
                                            Z = -3072
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = 1024,
                                            Z = -3072
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 80,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 2,
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
                        new EMRefaceFunction
                        {
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [7] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0, 3, 6 }
                                    }
                                },
                                [2] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 1, 2, 4, 5, 7, 8, 9, 10, 11, 12 }
                                    }
                                },
                                [10] = new EMGeometryMap
                                {
                                    [80] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2 }
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

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
    public class TR1VilcabambaControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.VILCABAMBA;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);
            TRLevel level3b = GetTR1Level(TRLevelNames.QUALOPEC);
            TRLevel level4 = GetTR1Level(TRLevelNames.FOLLY);
            TRLevel level7b = GetTR1Level(TRLevelNames.TIHOCAN);

            mapping.All = new EMEditorSet
            {
            };
            mapping.NonPurist = new EMEditorSet
            {
                new EMRefaceFunction
                {
                    Comments = "Fix an out of place texture in room 26.",
                    EMType = EMType.Reface,
                    TextureMap = new EMTextureMap
                    {
                        [level.Rooms[26].RoomData.Rectangles[425].Texture] = new EMGeometryMap
                        {
                            [26] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 403 }
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
                                TexturedFace3 = 135,
                                TexturedFace4 = 12
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
                            X = 52736,
                            Y = -2048,
                            Z = 28160,
                            Room = 40,
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
                                X = 54784,
                                Z = 28160,
                                Room = 40,
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
                                TexturedFace3 = 135,
                                TexturedFace4 = 12
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
                            X = 78336,
                            Y = -1024 - 2048,
                            Z = 19968,
                            Room = 13,
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
                            X = 78336 - 1024,
                            Y = -1024 - 2048,
                            Z = 19968,
                            Room = 13,
                            Angle = -32768
                        }
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 78336,
                                Y = -1024,
                                Z = 19968 - 3072,
                                Room = 13,
                            },
                            new EMLocation
                            {
                                X = 78336 - 1024,
                                Y = -1024,
                                Z = 19968 - 3072,
                                Room = 13,
                            },
                        },
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
                                    [745] = 3, // Top of handle
                                    [746] = 3, // Top of handle
                                    [747] = 11, // Handle
                                    [748] = 3, // Handle edge
                                    [749] = 39   // Blade
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
                            X = 61952 + 1024,
                            Y = -2048 - 512,
                            Z = 39424 + 1024,
                            Room = 16
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DamoclesSword,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.DamoclesSword).Intensity,
                        Location = new EMLocation
                        {
                            X = 61952 - 1024,
                            Y = -2048 - 512,
                            Z = 39424 + 1024,
                            Room = 16
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 61952,
                                Z = 38400,
                                Room = 18,
                            },
                        },
                        Trigger = new EMTrigger
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
                                TexturedFace4 = 5,
                                TexturedFace3 = 26
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
                            X = 26112 - 512,
                            Y = -4608,
                            Z = 18944,
                            Room = 51,
                            Angle = 16384
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 25088,
                            Y = -4864,
                            Z = 18944 ,
                            Room = 51,
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
                                TexturedFace4 = 5,
                                TexturedFace3 = 26
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
                            X = 23040 - 512,
                            Y = -1024,
                            Z = 29184,
                            Room = 61,
                            Angle = 16384
                        },
                        TargetRelocation = new EMLocation
                        {
                            X = 22016,
                            Y = -1024,
                            Z = 29184 ,
                            Room = 61,
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
                    new EMMoveEntityFunction
                    {
                        Comments = "Switch the angle of one of the blades in room 61.",
                        EMType = EMType.MoveEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EntityIndex = 58,
                        TargetLocation = new EMLocation
                        {
                            X = 26112,
                            Y = -1024,
                            Z = 29184,
                            Room = 61,
                            Angle = 16384
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMAddEntityFunction
                    {
                        Comments = "Add another random blade.",
                        EMType = EMType.AddEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        TypeID = (short)TREntities.SwingingBlade,
                        Intensity = level.Entities[58].Intensity,
                        Location = new EMLocation
                        {
                            X = 9728,
                            Y = -1536,
                            Z = 25088,
                            Room = 80,
                            Angle = -16384
                        },
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 9728 + 1024,
                                Y = -1536,
                                Z = 25088,
                                Room = 80,
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
                            Comments = "Remove the default lever texture in room 9.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [5] = new EMGeometryMap
                                {
                                    [9] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 51 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 64000,
                                    Y = 0,
                                    Z = 37376,
                                    Room = 15
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [15] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 64000 + 1024,
                                    Y = 0,
                                    Z = 37376,
                                    Room = 15
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [15] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 90 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 64000 + 1024 + 2048,
                                    Y = 0,
                                    Z = 37376,
                                    Room = 15
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [15] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 167 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 64000 + 1024 + 2048 + 1024,
                                    Y = 0,
                                    Z = 37376,
                                    Room = 15
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [15] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 214 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 64000 + 1024 + 2048 + 2048,
                                    Y = 0,
                                    Z = 37376,
                                    Room = 15
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [15] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 258 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 64000 + 1024 + 2048 + 2048 + 1024,
                                    Y = 0,
                                    Z = 37376,
                                    Room = 15
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [15] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 300 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 66048,
                                    Y = 0,
                                    Z = 40448,
                                    Room = 10,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [10] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 66048,
                                    Y = 0,
                                    Z = 40448 + 2048 + 1024,
                                    Room = 10,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [10] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 34 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 56832,
                                    Y = 0,
                                    Z = 40448,
                                    Room = 5,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [5] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 129 }
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
                                EntityIndex = 16,
                                Location = new EMLocation
                                {
                                    X = 55808,
                                    Y = 0,
                                    Z = 43520,
                                    Room = 5,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [5] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 45 }
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
                            Comments = "Remove the default lever texture in room 67.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [174] = new EMGeometryMap
                                {
                                    [67] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 4 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Modify vertices for above to match the rest of the room.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 67,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 4,
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
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Modify vertices for above to match the rest of the room.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 67,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 3,
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
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 28160,
                                    Y = -7936,
                                    Z = 34304 + 1024,
                                    Room = 67,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 28160,
                                    Y = -7936,
                                    Z = 34304 + 2048,
                                    Room = 67,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 28160,
                                    Y = -7936,
                                    Z = 34304 + 2048,
                                    Room = 67
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 28160 + 1024,
                                    Y = -7936,
                                    Z = 34304 + 2048,
                                    Room = 67
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 28160 + 1024 + 2048,
                                    Y = -7936,
                                    Z = 34304 + 2048,
                                    Room = 67
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 28160 + 1024 + 2048,
                                    Y = -7936,
                                    Z = 34304 + 2048,
                                    Room = 67,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 62 }
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
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 28160 + 1024 + 2048,
                                    Y = -7936,
                                    Z = 34304 + 1024,
                                    Room = 67,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 60 }
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
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 28160 + 1024 + 2048,
                                    Y = -7936,
                                    Z = 34304,
                                    Room = 67,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 28160 + 1024 + 2048,
                                    Y = -7936,
                                    Z = 34304,
                                    Room = 67,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 48 }
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
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 28160 + 2048,
                                    Y = -7936,
                                    Z = 34304,
                                    Room = 67,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 28160,
                                    Y = -7936,
                                    Z = 34304,
                                    Room = 67,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [67] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 26112,
                                    Y = -6912,
                                    Z = 39424,
                                    Room = 83,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [83] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 38 }
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
                                        RoomNumber = 83,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 38 },
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
                                EntityIndex = 71,
                                Location = new EMLocation
                                {
                                    X = 31232,
                                    Y = -5632,
                                    Z = 36352,
                                    Room = 70,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [70] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 65 }
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
                            Comments = "Remove the default lever texture in room 58.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [174] = new EMGeometryMap
                                {
                                    [58] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 10 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Modify vertices for above to match the rest of the room.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 58,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 10,
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
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Modify vertices for above to match the rest of the room.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 58,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 9,
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 28160,
                                    Y = -7936,
                                    Z = 22016 + 1024,
                                    Room = 58,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [58] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 28160,
                                    Y = -7936,
                                    Z = 22016 + 1024,
                                    Room = 58
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [58] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 28160 + 2048,
                                    Y = -7936,
                                    Z = 22016 + 1024,
                                    Room = 58
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [58] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 43 }
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 28160 + 2048 + 1024,
                                    Y = -7936,
                                    Z = 22016 + 1024,
                                    Room = 58
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [58] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 28160 + 2048 + 1024,
                                    Y = -7936,
                                    Z = 22016 + 1024,
                                    Room = 58,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [58] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 60 }
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 28160 + 2048 + 1024,
                                    Y = -7936,
                                    Z = 22016,
                                    Room = 58,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [58] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 28160 + 2048 + 1024,
                                    Y = -7936,
                                    Z = 22016 - 1024,
                                    Room = 58,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [58] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 28160 + 2048 + 1024,
                                    Y = -7936,
                                    Z = 22016 - 1024,
                                    Room = 58,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [58] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 28160 + 2048,
                                    Y = -7936,
                                    Z = 22016 - 1024,
                                    Room = 58,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [58] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 34 }
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 28160,
                                    Y = -7936,
                                    Z = 22016 - 1024,
                                    Room = 58,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [58] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 28160,
                                    Y = -7936,
                                    Z = 22016 - 1024,
                                    Room = 58,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [58] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 32256,
                                    Y = -7680,
                                    Z = 18944,
                                    Room = 57
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [57] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
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
                            Comments = "Remove the default lever texture in room 9.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [171] = new EMGeometryMap
                                {
                                    [81] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 58 }
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
                                EntityIndex = 84,
                                Location = new EMLocation
                                {
                                    X = 17920 + 1024,
                                    Y = -2816,
                                    Z = 33280,
                                    Room = 81,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [81] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 67 }
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
                                EntityIndex = 84,
                                Location = new EMLocation
                                {
                                    X = 17920 - 1024,
                                    Y = -2816,
                                    Z = 33280,
                                    Room = 81,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [81] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 49 }
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
                                EntityIndex = 84,
                                Location = new EMLocation
                                {
                                    X = 17920 - 1024 - 2048,
                                    Y = -2816,
                                    Z = 33280,
                                    Room = 81,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [81] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 84,
                                Location = new EMLocation
                                {
                                    X = 17920 - 1024 - 2048 - 2048,
                                    Y = -2816,
                                    Z = 33280,
                                    Room = 81,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [81] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 84,
                                Location = new EMLocation
                                {
                                    X = 17920 - 1024 - 2048 - 2048,
                                    Y = -2816,
                                    Z = 33280 + 1024,
                                    Room = 81
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [81] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 20 }
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
                                        RoomNumber = 81,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 20 },
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
                                EntityIndex = 84,
                                Location = new EMLocation
                                {
                                    X = 17920 - 2048,
                                    Y = -2816,
                                    Z = 33280 + 1024,
                                    Room = 81
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [81] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 44 }
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
                                EntityIndex = 84,
                                Location = new EMLocation
                                {
                                    X = 17920,
                                    Y = -2816,
                                    Z = 33280 - 2048,
                                    Room = 72
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [72] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 124 }
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
                                EntityIndex = 84,
                                Location = new EMLocation
                                {
                                    X = 11776,
                                    Y = -2816,
                                    Z = 20992,
                                    Room = 79,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [79] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 84,
                                Location = new EMLocation
                                {
                                    X = 18944,
                                    Y = -2816,
                                    Z = 25088,
                                    Room = 76
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [76] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 48 }
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
                                EntityIndex = 84,
                                Location = new EMLocation
                                {
                                    X = 8704,
                                    Y = -1024,
                                    Z = 35328,
                                    Room = 66,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [47] = new EMGeometryMap
                                    {
                                        [66] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 21 }
                                        }
                                    }
                                }
                            },

                        },
                    }
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
                            Comments = "Potential new position for the skull keyhole.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 9,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Y = 0,
                                Z = 29184,
                                Room = 5
                            }
                        }
                    }
                }
            };

            for (int i = 0; i < 7; i++)
            {
                mapping.AllWithin[0].Add(new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the skull keyhole.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 9,
                        Location = new EMLocation
                        {
                            X = 56832,
                            Y = 0,
                            Z = 29184 + i * 1024,
                            Room = 5,
                            Angle = 16384
                        }
                    }
                });
                if (i > 0 && i < 5)
                {
                    mapping.AllWithin[0].Add(new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the skull keyhole.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 9,
                            Location = new EMLocation
                            {
                                X = 56832,
                                Y = 0,
                                Z = 29184 + i * 1024,
                                Room = 5,
                                Angle = -16384
                            }
                        }
                    });
                }
            }

            mapping.AllWithin[0].Add(new EMEditorSet
            {
                new EMMoveSlotFunction
                {
                    Comments = "Potential new position for the skull keyhole.",
                    EMType = EMType.MoveSlot,
                    Tags = new List<EMTag>
                    {
                        EMTag.SlotChange
                    },
                    EntityIndex = 9,
                    Location = new EMLocation
                    {
                        X = 55808,
                        Y = 0,
                        Z = 34304,
                        Room = 5,
                        Angle = -32768
                    }
                }
            });
            mapping.AllWithin[0].Add(new EMEditorSet
            {
                new EMMoveSlotFunction
                {
                    Comments = "Potential new position for the skull keyhole.",
                    EMType = EMType.MoveSlot,
                    EntityIndex = 9,
                    Tags = new List<EMTag>
                    {
                        EMTag.SlotChange
                    },
                    Location = new EMLocation
                    {
                        X = 55808,
                        Y = -1024,
                        Z = 34304,
                        Room = 5,
                        Angle = -32768
                    }
                },
                new EMAddEntityFunction
                {
                    Comments = "Block to reach the keyhole.",
                    EMType = EMType.AddEntity,
                    TypeID = (short)TREntities.PushBlock1,
                    Intensity = level.Entities[0].Intensity,
                    Location = new EMLocation
                    {
                        X =55808,
                        Y = 0,
                        Z = 44544,
                        Room = 5
                    }
                }
            });
            mapping.AllWithin[0].Add(new EMEditorSet
            {
                new EMMoveSlotFunction
                {
                    Comments = "Potential new position for the skull keyhole.",
                    EMType = EMType.MoveSlot,
                    Tags = new List<EMTag>
                    {
                        EMTag.SlotChange
                    },
                    EntityIndex = 9,
                    Location = new EMLocation
                    {
                        X = 54784,
                        Y = 0,
                        Z = 23040,
                        Room = 34
                    }
                }
            });

            mapping.AllWithin.Add(new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800,
                            Y = -768,
                            Z = 31232,
                            Room = 71
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800 + 2048,
                            Y = -768,
                            Z = 31232,
                            Room = 71
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800 + 2048 + 2048,
                            Y = -768,
                            Z = 31232,
                            Room = 71
                        }
                    }
                }
                ,
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800 + 2048 + 2048 + 2048,
                            Y = -768,
                            Z = 31232,
                            Room = 71
                        }
                    }
                }
                ,
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800 + 2048 + 2048 + 2048,
                            Y = -768,
                            Z = 31232,
                            Room = 71,
                            Angle = 16384
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800 + 2048 + 2048 + 2048,
                            Y = -768,
                            Z = 31232 - 1024,
                            Room = 71,
                            Angle = 16384
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800 + 2048 + 2048 + 2048,
                            Y = -768,
                            Z = 31232 - 1024 - 2048,
                            Room = 71,
                            Angle = 16384
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800 + 2048 + 2048 + 2048,
                            Y = -768,
                            Z = 31232 - 1024 - 2048 - 1024,
                            Room = 71,
                            Angle = 16384
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800 + 2048 + 2048 + 2048,
                            Y = -768,
                            Z = 31232 - 1024 - 2048 - 1024,
                            Room = 71,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800 + 2048 + 2048,
                            Y = -768,
                            Z = 31232 - 1024 - 2048 - 1024,
                            Room = 71,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800 + 2048,
                            Y = -768,
                            Z = 31232 - 1024 - 2048 - 1024,
                            Room = 71,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800,
                            Y = -768,
                            Z = 31232 - 1024 - 2048 - 1024,
                            Room = 71,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the idol slot.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 79,
                        Location = new EMLocation
                        {
                            X = 12800,
                            Y = -768,
                            Z = 31232 - 1024 - 2048,
                            Room = 71,
                            Angle = -16384
                        }
                    }
                }
            });

            mapping.AllWithin.Add(new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 83456 - 2048,
                            Y = 1792,
                            Z = 28160,
                            Room = 26,
                            Angle = 16384
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 83456 - 2048 - 2048,
                            Y = 1792,
                            Z = 28160,
                            Room = 26,
                            Angle = -16384
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 83456 - 2048 - 2048 - 2048,
                            Y = 1792,
                            Z = 28160,
                            Room = 26,
                            Angle = 16384
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 83456 - 2048 - 2048 - 2048 - 2048,
                            Y = 1792,
                            Z = 28160,
                            Room = 26,
                            Angle = -16384
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 82432,
                            Y = 1792 - 256,
                            Z = 26112,
                            Room = 26,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 82432 - 4096,
                            Y = 1792 - 256,
                            Z = 26112,
                            Room = 26,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 82432 - 4096 - 4096,
                            Y = 1792,
                            Z = 26112,
                            Room = 26,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 82432,
                            Y = 1792 - 512,
                            Z = 26112 - 3*1024,
                            Room = 26,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 82432 - 4096,
                            Y = 1792 - 512,
                            Z = 26112 - 3*1024,
                            Room = 26,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 82432 - 4096 - 4096,
                            Y = 1792 - 256,
                            Z = 26112 - 3*1024,
                            Room = 26,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 82432,
                            Y = 1792,
                            Z = 26112 - 6*1024,
                            Room = 26,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 82432 - 4096,
                            Y = 1792,
                            Z = 26112 - 6*1024,
                            Room = 26,
                            Angle = -32768
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMMoveSlotFunction
                    {
                        Comments = "Potential new position for the underwater OG secret room lever.",
                        EMType = EMType.MoveSlot,
                        Tags = new List<EMTag>
                        {
                            EMTag.SlotChange
                        },
                        EntityIndex = 30,
                        Location = new EMLocation
                        {
                            X = 82432 - 4096 - 4096,
                            Y = 1792 - 256,
                            Z = 26112 - 6*1024,
                            Room = 26,
                            Angle = -32768
                        }
                    }
                },
            });

            mapping.AllWithin.Add(new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMPlaceholderFunction
                    {
                        Comments = "No additional end room.",
                        EMType = EMType.NOOP
                    }
                },
                new EMEditorSet
                {
                    new EMCreateRoomFunction
                    {
                        Comments = "Make an additional end area.",
                        EMType = EMType.CreateRoom,
                        Tags = new List<EMTag>
                        {
                            EMTag.PuzzleRoom
                        },
                        Height = 4,
                        Width = 4,
                        Depth = 6,
                        Textures = new EMTextureGroup
                        {
                            Floor = 2,
                            Ceiling = 6,
                            Wall4 = 128,
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
                                Y = -256,
                                Z = 4 * 1024 + 512,
                                Intensity1 = 3000,
                                Fade1 = 2048,
                            },
                            new EMRoomLight
                            {
                                X = 1 * 1024 + 512,
                                Y = -256,
                                Z = 1 * 1024 + 512,
                                Intensity1 = 1791,
                                Fade1 = 2048,
                            },
                        },
                        LinkedLocation = new EMLocation
                        {
                            X = 8704,
                            Y = -1024,
                            Z = 28160,
                            Room = 87
                        },
                        Location = new EMLocation
                        {
                            X = 8192 - 1024,
                            Z = 27648 - 4096
                        },
                        FloorHeights= new Dictionary<sbyte, List<int>>
                        {
                            [-127] = new List<int> { 14,15,16, }
                        }
                    },
                    new EMCreateRoomFunction
                    {
                        Comments = "Make an additional end area.",
                        EMType = EMType.CreateRoom,
                        Height = 9,
                        Width = 7,
                        Depth = 8,
                        Textures = new EMTextureGroup
                        {
                            Floor = 6,
                            Ceiling = 150,
                            Wall4 = 171,
                            Wall3 = 174,
                            Wall2 = 173,
                            Wall1 = 172,
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
                                X = 3 * 1024 + 512,
                                Y = -1024,
                                Z = 4 * 1024 + 512,
                                Intensity1 = 1791,
                                Fade1 = 3097,
                            },
                        },
                        LinkedLocation = new EMLocation
                        {
                            X = 8704,
                            Y = -1024,
                            Z = 28160,
                            Room = 87
                        },
                        Location = new EMLocation
                        {
                            X = 8192,
                            Y = 2048+256,
                            Z = 27648 - 2*4096 - 1024
                        },
                        FloorHeights= new Dictionary<sbyte, List<int>>
                        {
                            [-1] = new List<int> { 25 },
                            [-2] = new List<int> { 14,30,46 },
                            [-127] = new List<int> { 9,17,22,33,38,41 }
                        }
                    },
                    new EMCreateRoomFunction
                    {
                        Comments = "Make an additional end area.",
                        EMType = EMType.CreateRoom,
                        Height = 4,
                        Width = 4,
                        Depth = 5,
                        Textures = new EMTextureGroup
                        {
                            Floor = 1,
                            Ceiling = 14,
                            Wall4 = 14,
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
                                Y = -256,
                                Z = 1 * 1024 + 512,
                                Intensity1 = 3000,
                                Fade1 = 2048,
                            },
                        },
                        LinkedLocation = new EMLocation
                        {
                            X = 8704,
                            Y = -1024,
                            Z = 28160,
                            Room = 87
                        },
                        Location = new EMLocation
                        {
                            X = 8192 + 2048,
                            Y = 2048,
                            Z = 27648 - 3*4096
                        },
                        FloorHeights= new Dictionary<sbyte, List<int>>
                        {
                            [-127] = new List<int> { 12,13, }
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
                                BaseRoom = 87,
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
                                        Y = -1024,
                                        Z = 2 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Y = -1024,
                                        Z = 2 * 1024
                                    },
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
                                    }
                                }
                            },
                            new EMVisibilityPortal
                            {
                                BaseRoom = -3,
                                AdjoiningRoom = 87,
                                Normal = new TRVertex
                                {
                                    Y = 1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = -1024,
                                        Z = 4 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Y = -1024,
                                        Z = 4 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Y = -1024,
                                        Z = 5 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = -1024,
                                        Z = 5 * 1024
                                    }
                                }
                            },

                            new EMVisibilityPortal
                            {
                                BaseRoom = -3,
                                AdjoiningRoom = -2,
                                Normal = new TRVertex
                                {
                                    Y = -1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Z = 2 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 3 * 1024,
                                        Z = 2 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 3 * 1024,
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
                                BaseRoom = -2,
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
                                        Z = 6 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Z = 6 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Z = 7 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
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
                                    Z = 1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = 4 * 1024,
                                        Y = 1024,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 3 * 1024,
                                        Y = 1024,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 3 * 1024,
                                        Y = 2048,
                                        Z = 1 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 4 * 1024,
                                        Y = 2048,
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
                                    Z = -1
                                },
                                Vertices = new TRVertex[]
                                {
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = 1024,
                                        Z = 4 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Y = 1024,
                                        Z = 4 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 2 * 1024,
                                        Y = 2048,
                                        Z = 4 * 1024
                                    },
                                    new TRVertex
                                    {
                                        X = 1 * 1024,
                                        Y = 2048,
                                        Z = 4 * 1024
                                    }
                                }
                            },
                        }
                    },
                    new EMVerticalCollisionalPortalFunction
                    {
                        Comments = "Make collisional portals.",
                        EMType = EMType.VerticalCollisionalPortal,
                        Ceiling = new EMLocation
                        {
                            X = 8704,
                            Y = -1024,
                            Z = 28160,
                            Room = 87
                        },
                        Floor = new EMLocation
                        {
                            X = 8704,
                            Z = 28160,
                            Room = -3
                        }
                    },
                    new EMVerticalCollisionalPortalFunction
                    {
                        EMType = EMType.VerticalCollisionalPortal,
                        Ceiling = new EMLocation
                        {
                            X = 9728,
                            Z = 25088,
                            Room = -3
                        },
                        Floor = new EMLocation
                        {
                            X = 9728,
                            Y = 1024,
                            Z = 25088,
                            Room = -2
                        }
                    },
                    new EMHorizontalCollisionalPortalFunction
                    {
                        EMType = EMType.HorizontalCollisionalPortal,
                        Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                        {
                            [-3] = new Dictionary<short, EMLocation[]>
                            {
                                [87] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 8704,
                                        Z = 28160 + 1024,
                                        Room = -3
                                    }
                                }
                            },
                            [-2] = new Dictionary<short, EMLocation[]>
                            {
                                [-1] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 11776,
                                        Y = 2048,
                                        Z = 18944,
                                        Room = -2
                                    }
                                },
                                [-3] = new EMLocation[]
                                {
                                    new EMLocation
                                    {
                                        X = 9728 - 1024,
                                        Y = 2048,
                                        Z = 25088,
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
                                        X = 11776,
                                        Y = 2048,
                                        Z = 18944 + 1024,
                                        Room = -1
                                    }
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
                            [694] = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 110 }
                                }
                            },
                            [2] = new EMGeometryMap
                            {
                                [87] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 13,9,4 }
                                }
                            },
                            [128] = new EMGeometryMap
                            {
                                [87] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 7,12,16,15,11,8,3,2,6 }
                                }
                            },
                            [6] = new EMGeometryMap
                            {
                                [87] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 1,5,10,14 }
                                }
                            },
                            [level.Rooms[87].RoomData.Rectangles[15].Texture] = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 12,17 }
                                }
                            },
                            [level.Rooms[87].RoomData.Rectangles[11].Texture] = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 4,7 }
                                }
                            },
                            [level.Rooms[87].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 1,6,8,15,16 }
                                }
                            },
                            [level.Rooms[87].RoomData.Rectangles[7].Texture] = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0,2,9,13 }
                                }
                            },
                        }
                    },
                    new EMModifyFaceFunction
                    {
                        EMType = EMType.ModifyFace,
                        Rotations = new EMFaceRotation[]
                        {
                            new EMFaceRotation
                            {
                                FaceIndices = new int[] { 3 },
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 87,
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
                    new EMRemoveFaceFunction
                    {
                        Comments = "Remove faces for portals.",
                        EMType = EMType.RemoveFace,
                        GeometryMap = new EMGeometryMap
                        {
                            [87] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 0 }
                            },
                            [-3] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 13,17 }
                            },
                            [-2] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 25,52 }
                            },
                            [-1] = new Dictionary<EMTextureFaceType, int[]>
                            {
                                [EMTextureFaceType.Rectangles] = new int[] { 11 }
                            },
                        }
                    },
                    new EMImportNonGraphicsModelFunction
                    {
                        Comments = "Ensure the lightning model is available.",
                        EMType = EMType.ImportNonGraphicsModel,
                        Data = new List<EMMeshTextureData>
                        {
                            new EMMeshTextureData
                            {
                                ModelID = (short)TREntities.ThorLightning,
                                TexturedFace4 = 6,
                                TexturedFace3 = 6
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add some lightning.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.ThorLightning,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.ThorLightning).Intensity,
                        Location = new EMLocation
                        {
                            X = 11776,
                            Y = 2048+256,
                            Z = 22016 + 1024,
                            Room = -2,
                            Angle = -32768
                        },
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        ExpandedLocations = new EMLocationExpander
                        {
                            Location = new EMLocation
                            {
                                X = 9728,
                                Y = 2304,
                                Z = 20992,
                                Room = -2
                            },
                            ExpandX = 5,
                            ExpandZ= 4,
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
                                    Parameter = -1
                                }
                            }
                        }
                    },

                    new EMAddEntityFunction
                    {
                        Comments = "Add a door.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.Door1,
                        Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.Door1).Intensity,
                        Location = new EMLocation
                        {
                            X = 11776,
                            Y = 2048,
                            Z = 18944 + 1024,
                            Room = -2
                        },
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Pad for the door.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 13824,
                                Y = 1792,
                                Z = 25088,
                                Room = -2
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            TrigType = FDTrigType.Pad,
                            Timer = 5,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            }
                        }
                    },

                    new EMMoveTriggerFunction
                    {
                        Comments = "Move the end-level trigger.",
                        EMType = EMType.MoveTrigger,
                        BaseLocation = new EMLocation
                        {
                            X = 9728,
                            Y = -1024,
                            Z = 29184,
                            Room = 87
                        },
                        NewLocation = new EMLocation
                        {
                            X = 11776,
                            Y = 2048,
                            Z = 17920,
                            Room = -1
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
                    new EMMoveTriggerFunction
                    {
                        Comments = "Move the end-level trigger.",
                        EMType = EMType.MoveTrigger,
                        BaseLocation = new EMLocation
                        {
                            X = 9728,
                            Y = -1024,
                            Z = 29184,
                            Room = 87
                        },
                        NewLocation = new EMLocation
                        {
                            X = 9728 - 1024,
                            Y = -1024,
                            Z = 29184 - 1024,
                            Room = 87
                        }
                    },
                    new EMRefaceFunction
                    {
                        Comments = "Change some textures.",
                        EMType = EMType.Reface,
                        TextureMap = new EMTextureMap
                        {
                            [694] = new EMGeometryMap
                            {
                                [87] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                }
                            },
                        }
                    },
                    new EMModifyFaceFunction
                    {
                        EMType = EMType.ModifyFace,
                        Rotations = new EMFaceRotation[]
                        {
                            new EMFaceRotation
                            {
                                FaceIndices = new int[] { 3 },
                                FaceType = EMTextureFaceType.Rectangles,
                                RoomNumber = 87,
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
                                TexturedFace4 = 5,
                                TexturedFace3 = 26
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add clang-clang doors to the end.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SlammingDoor,
                        Intensity = level7b.Entities[32].Intensity,
                        Location = new EMLocation
                        {
                            X = 9728 - 512,
                            Y = -1024,
                            Z = 29184,
                            Room = 87,
                            Angle = 16384
                        },
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
            });

            mapping.ConditionalAllWithin = new List<EMConditionalEditorSet>
            {
            };
            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
            };
            mapping.ConditionalOneOf = new List<EMConditionalGroupedSet>
            {
            };
            mapping.Mirrored = new EMEditorSet
            {
            };

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();

            mapping.RewardEntities = new List<int> { 29, 87, 88, 89 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 8704,
                            Y = -1024,
                            Z = 31232
                        },
                        new Location
                        {
                            X = 9728,
                            Y = -1024,
                            Z = 31232
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door3,
                            X = 11776,
                            Y = -1024,
                            Z = 31232,
                            Angle = 16384,
                            Intensity = -1,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 8689,
                            Y = -1711,
                            Z = 36569,
                            Room = 66
                        }
                    },
                    CameraTarget = new Location
                    {
                        X = 10752,
                        Y = -1536,
                        Z = 32256,
                        Room = 66
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 44,
                            LinkedLocation = new EMLocation
                            {
                                X = 11776,
                                Y = -1024,
                                Z = 31232,
                                Room = 71
                            },
                            NewLocation = new EMLocation
                            {
                                X = 7168,
                                Y = -1024,
                                Z = 29696
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [71] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 10752,
                                            Y = -1024,
                                            Z = 31232,
                                            Room = 71
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [71] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 11776,
                                            Y = -1024,
                                            Z = 31232,
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
                                    BaseRoom = 71,
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
                                            Y = -2048,
                                            Z  = 5120
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -2048,
                                            Z  = 6144
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1024,
                                            Z  = 6144
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1024,
                                            Z  = 5120
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 71,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -2048,
                                            Z  = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -2048,
                                            Z  = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -1024,
                                            Z  = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -1024,
                                            Z  = 2048
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = 66,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -2048,
                                            Z  = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -2048,
                                            Z  = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1024,
                                            Z  = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -1024,
                                            Z  = 1024
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 66,
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
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -2048,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -1024,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1024,
                                            Z = 2048
                                        },
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = 73,
                                    AdjoiningRoom = 66,
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
                                            Z = 4096
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1024,
                                            Z = 4096
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1024,
                                            Z = 1024
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 66,
                                    AdjoiningRoom = 73,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -2048,
                                            Z = 4096
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -2048,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -1024,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = -1024,
                                            Z = 4096
                                        },
                                    }
                                },
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
                                        Texture = 183,
                                        Vertices = new ushort[]
                                        {
                                            2,3,1,0
                                        }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = 73,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[]{ 2,7,10 },
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
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [182] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 6 }
                                    }
                                },

                                [701] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3, 7, 11 }
                                    },
                                    [66] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 7, 38, 57, 81, 84, 87 }
                                    },
                                    [73] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2, 7, 10 }
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [71] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 12 }
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

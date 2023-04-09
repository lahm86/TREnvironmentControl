using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TR1ToQControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.QUALOPEC;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);
            TRLevel level4 = GetTR1Level(TRLevelNames.FOLLY);

            mapping.NonPurist = new EMEditorSet
            {
                new EMModifyFaceFunction
                {
                    Comments = "Patch holes in the wall in room 8.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            RoomNumber = 8,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 107,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y =  512
                                },
                                [1] = new TRVertex
                                {
                                    Y = -1024
                                }
                            }
                        },
                        new EMFaceModification
                        {
                            RoomNumber = 8,
                            FaceType = EMTextureFaceType.Rectangles,
                            FaceIndex = 6,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
                                {
                                    Y =  -1024 - 512
                                },
                                [1] = new TRVertex
                                {
                                    Y = 256
                                }
                            }
                        }
                    }
                },
            };

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMAddEntityFunction
                    {
                        Comments = "Add some boulders.",
                        EMType = EMType.AddEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level.Entities[45].Intensity,
                        Location = new EMLocation
                        {
                            X = 65024,
                            Y = 2560+1024,
                            Z = 73216,
                            Room = 39,
                            Angle = -16384
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level.Entities[45].Intensity,
                        Location = new EMLocation
                        {
                            X = 65024,
                            Y = 2560+1024,
                            Z = 73216 - 1024,
                            Room = 39,
                            Angle = -16384
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level.Entities[45].Intensity,
                        Location = new EMLocation
                        {
                            X = 65024,
                            Y = 2560+1024,
                            Z = 73216 - 2048,
                            Room = 39,
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
                                X = 59904,
                                Y = 6656,
                                Z = 71168,
                                Room = 39
                            },
                            ExpandX = 1,
                            ExpandZ = 3
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
                    new EMAddEntityFunction
                    {
                        Comments = "Add some spikes.",
                        EMType = EMType.AddEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        TypeID = (short)TREntities.TeethSpikes,
                        Intensity = level.Entities[18].Intensity,
                        Location = new EMLocation
                        {
                            X = 57856,
                            Y = 6656,
                            Z = 71168,
                            Room = 39,
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.TeethSpikes,
                        Intensity = level.Entities[18].Intensity,
                        Location = new EMLocation
                        {
                            X = 57856,
                            Y = 6656,
                            Z = 71168 + 1024,
                            Room = 39,
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.TeethSpikes,
                        Intensity = level.Entities[18].Intensity,
                        Location = new EMLocation
                        {
                            X = 57856,
                            Y = 6656,
                            Z = 71168 + 2048,
                            Room = 39,
                        }
                    },
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
                                    [745] = 1016, // Top of handle
                                    [746] = 1016, // Top of handle
                                    [747] = 1016, // Handle
                                    [748] = 1016, // Handle edge
                                    [749] = 16   // Blade
                                }
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        Comments = "Add a sword.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DamoclesSword,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.DamoclesSword).Intensity,
                        Flags = 0x100,
                        Location = new EMLocation
                        {
                            X = 57856 + 1024,
                            Y = 6656 - 2048,
                            Z = 61952,
                            Room = 20
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 59904,
                                Y = 6528,
                                Z = 61952,
                                Room = 47,
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
                        Comments = "Another boulder.",
                        EMType = EMType.AddEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        TypeID = (short)TREntities.RollingBall,
                        Intensity = level.Entities[45].Intensity,
                        Flags = 0x100,
                        Location = new EMLocation
                        {
                            X = 73216,
                            Y = 4096-1024,
                            Z = 65024,
                            Room = 5,
                        }
                    },
                    new EMTriggerFunction
                    {
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 73216,
                                Y = 4608,
                                Z = 71168,
                                Room = 38
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
            };

            mapping.All = new EMEditorSet
            {
                new EMRemoveTriggerFunction
                {
                    Comments = "Get rid of the antipad that kills the music after the double block room.",
                    EMType = EMType.RemoveTrigger,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 59904,
                            Y = 6656,
                            Z = 51712,
                            Room = 25
                        }
                    }
                },
                new EMSwapFaceFunction
                {
                    Comments = "Make a slight change to face order in room 37 to make further modifications here easier.",
                    EMType = EMType.SwapFace,
                    FaceType = EMTextureFaceType.Rectangles,
                    RoomIndex = 37,
                    Swaps = new Dictionary<int, int>
                    {
                        [27] = 42
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
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736,
                                Y = 6656,
                                Z = 59904,
                                Room = 20,
                                Angle = -32768
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 1024,
                                Y = 6656,
                                Z = 59904 - 1024,
                                Room = 20,
                                Angle = -16384
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 1024,
                                Y = 6656,
                                Z = 59904 - 1024,
                                Room = 20,
                                Angle = -32768
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 5 * 1024,
                                Y = 6656,
                                Z = 59904 - 1024,
                                Room = 20,
                                Angle = -32768
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 5 * 1024,
                                Y = 6656,
                                Z = 59904 - 1024,
                                Room = 20,
                                Angle = 16384
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 6 * 1024,
                                Y = 6656,
                                Z = 59904,
                                Room = 20,
                                Angle = -32768
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 6 * 1024,
                                Y = 6656,
                                Z = 59904,
                                Room = 20,
                                Angle = 16384
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 6 * 1024,
                                Y = 6656,
                                Z = 59904 + 4 * 1024,
                                Room = 20,
                                Angle = 16384
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 6 * 1024,
                                Y = 6656,
                                Z = 59904 + 4 * 1024,
                                Room = 20
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 5 * 1024,
                                Y = 6656,
                                Z = 59904 + 5 * 1024,
                                Room = 20,
                                Angle = 16384
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 5 * 1024,
                                Y = 6656,
                                Z = 59904 + 5 * 1024,
                                Room = 20
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 1024,
                                Y = 6656,
                                Z = 59904 + 5 * 1024,
                                Room = 20
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736 + 1024,
                                Y = 6656,
                                Z = 59904 + 5 * 1024,
                                Room = 20,
                                Angle = -16384
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736,
                                Y = 6656,
                                Z = 59904 + 4 * 1024,
                                Room = 20
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveSlotFunction
                        {
                            Comments = "Potential new position for the initial room lever.",
                            EMType = EMType.MoveSlot,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            EntityIndex = 36,
                            Location = new EMLocation
                            {
                                X = 52736,
                                Y = 6656,
                                Z = 59904 + 4 * 1024,
                                Room = 20,
                                Angle = -16384
                            }
                        }
                    }
                },
                new List<EMEditorSet>
                {
                    // Wolf area puzzle
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a trap/puzzle room off room 32.",
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
                                Floor = 33,
                                Ceiling = 33,
                                Wall4 = 31,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 28122214
                            },
                            AmbientLighting = level.Rooms[32].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[16].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 3 * 1024,
                                    Y = -2048,
                                    Z = 5 * 1024,
                                    Intensity1 = 3000,
                                    Fade1 = 4096,
                                },
                                new EMRoomLight
                                {
                                    X = 3 * 1024 + 512,
                                    Y = -2048 - 768,
                                    Z = 8 * 1024 +512,
                                    Intensity1 = 2800,
                                    Fade1 = 3000,
                                },
                                new EMRoomLight
                                {
                                    X = 3 * 1024,
                                    Y = -2048 - 1024,
                                    Z = 1 * 1024 +512,
                                    Intensity1 = 3000,
                                    Fade1 = 3000,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 61952,
                                Y = 6656,
                                Z = 38400,
                                Room = 32
                            },
                            Location = new EMLocation
                            {
                                X = 61440 - 2048,
                                Y = 6656*2 - 3072 - 8*256,
                                Z = 37888 - 9*1024,
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 11,18,41,48 },
                                [-8] = new List<int> { 21,31 },
                                [-6] = new List<int> { 28,38 },
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [2] = new List<int> { 21,31,28,38 },
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 15,
                            Width = 6,
                            Depth = 8,
                            Textures = new EMTextureGroup
                            {
                                Floor = 33,
                                Ceiling = 33,
                                Wall4 = 31,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 28122214
                            },
                            AmbientLighting = level.Rooms[32].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[16].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 3 * 1024,
                                    Y = -3072+512+256+127,
                                    Z = 4 * 1024,
                                    Intensity1 = 2600,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 61952,
                                Y = 6656,
                                Z = 38400,
                                Room = 32
                            },
                            Location = new EMLocation
                            {
                                X = 61440 - 2048,
                                Y = 6656*2 - 1024 - 256,
                                Z = 37888 - 8*1024,
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
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 8192,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 8192,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 8192,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 8192,
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
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 8192,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 8192,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 8192,
                                            Z = 7 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 8192,
                                            Z = 1 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = 32,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 6656 - 2048-512,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 6656 - 2048-512,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 6656,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 6656,
                                            Z = 9 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 32,
                                    AdjoiningRoom = -2,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 9 * 1024,
                                            Y = 6656 - 2048-512,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7 * 1024,
                                            Y = 6656 - 2048-512,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7 * 1024,
                                            Y = 6656,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 9 * 1024,
                                            Y = 6656,
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
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [32] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 61952,
                                            Y = 6656,
                                            Z = 37376 + 1024,
                                            Room = -2
                                        },
                                        new EMLocation
                                        {
                                            X = 61952 + 1024,
                                            Y = 6656,
                                            Z = 37376 + 1024,
                                            Room = -2
                                        }
                                    }
                                },
                                [32] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 61952,
                                            Y = 6656,
                                            Z = 37376,
                                            Room = 32
                                        },
                                        new EMLocation
                                        {
                                            X = 61952 + 1024,
                                            Y = 6656,
                                            Z = 37376,
                                            Room = 32
                                        }
                                    }
                                }
                            }
                        },
                        new EMSlantFunction
                        {
                            Comments = "Slant the ceiling to match room 32.",
                            EMType = EMType.Slant,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 61952,
                                    Y = 6656,
                                    Z = 37376,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 61952,
                                    Y = 6656,
                                    Z = 30208,
                                    Room = -2
                                }
                            },
                            SlantType = FDSlantEntryType.CeilingSlant,
                            XSlant = 2
                        },
                        new EMSlantFunction
                        {
                            EMType = EMType.Slant,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 61952 + 1024,
                                    Y = 6656,
                                    Z = 37376,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 61952 + 1024,
                                    Y = 6656,
                                    Z = 30208,
                                    Room = -2
                                }
                            },
                            SlantType = FDSlantEntryType.CeilingSlant,
                            XSlant = -2
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Modify faces to match the geometry.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    FaceIndices = new int[] { 69 },
                                    RoomNumber = -2,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    FaceIndices = new int[] { 75 },
                                    RoomNumber = -2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 1,
                                        [1] = 2,
                                        [2] = 3,
                                        [3] = 0
                                    }
                                }
                            },
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 69,75 },
                                    RoomNumber = -2,
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
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 99 },
                                    RoomNumber = -2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
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
                                    FaceIndices = new int[] { 45 },
                                    RoomNumber = -2,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    FaceIndices = new int[] { 67,84 },
                                    RoomNumber = -2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -512
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 54,97 },
                                    RoomNumber = -2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [3] = new TRVertex
                                        {
                                            Y = -512
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 49 },
                                    RoomNumber = -2,
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
                                            Y = -512
                                        }
                                    }
                                },
                                new EMFaceModification
                                {
                                    FaceIndices = new int[] { 79 },
                                    RoomNumber = -2,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -512
                                        },
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
                                    FaceIndices = new int[] { 48,78 },
                                    RoomNumber = -2,
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
                                [105] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 48,78 }
                                    }
                                },
                                [36] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 69,99,45,75 }
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove redundant faces.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] {85,95,101,107,113,119,65,71,73,75,77,79,45,51,53,55,57,59,1,11,17,23,29,35 }
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 0,10,16,22,28,34,50,55,57,59,61,63,80,85,87,89,91,93,104,114,120,126,132,138, 72,73,100,101}
                                },
                                [32] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 85,100 }
                                }
                            }
                        },
                        new EMAddStaticMeshFunction
                        {
                            Comments = "Add some skeletons.",
                            EMType = EMType.AddStaticMesh,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 60928,
                                    Y = 12032,
                                    Z = 34304,
                                    Room = -1,
                                    Angle = -32768
                                }
                            },
                            Mesh= new TR2RoomStaticMesh
                            {
                                MeshID = 45,
                                Intensity1 = Array.Find(level.Rooms[33].StaticMeshes, s => s.MeshID == 45).Intensity
                            }
                        },
                        new EMAddStaticMeshFunction
                        {
                            EMType = EMType.AddStaticMesh,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 62976,
                                    Y = 12032,
                                    Z = 32256,
                                    Room = -1,
                                    Angle = -16384
                                }
                            },
                            Mesh= new TR2RoomStaticMesh
                            {
                                MeshID = 48,
                                Intensity1 = Array.Find(level.Rooms[33].StaticMeshes, s => s.MeshID == 48).Intensity
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add breakable tiles to reach the levers.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.FallingBlock,
                            Intensity = 6144,
                            Location = new EMLocation
                            {
                                X = 64000,
                                Y = 8192 - 1024,
                                Z = 36352 - 1024,
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
                                    X = 64000,
                                    Y = 8192 + 1024,
                                    Z = 36352 - 1024,
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
                            TypeID = (short)TREntities.FallingBlock,
                            Intensity = 6144,
                            Location = new EMLocation
                            {
                                X = 64000,
                                Y = 8192-1024-512,
                                Z = 33280 - 1024,
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
                                    X = 64000,
                                    Y = 8192 + 1024,
                                    Z = 33280 - 1024,
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
                        new EMImportNonGraphicsModelFunction
                        {
                            Comments = "Ensure the trapdoor model is available.",
                            EMType = EMType.ImportNonGraphicsModel,
                            Data = new List<EMMeshTextureData>
                            {
                                new EMMeshTextureData
                                {
                                    ModelID = (short)TREntities.Trapdoor1,
                                    TexturedFace4 = 31
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a timed trapdoor as a return path.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor1,
                            Intensity = 6144,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 64000 - 3072,
                                Y = 8192-1024,
                                Z = 33280+1024,
                                Room = -2,
                                Angle = 16384
                            },
                            HardVariant = new EMAddEntityFunction
                            {
                                Comments = "A more difficult position in hard mode.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.Trapdoor1,
                                Intensity = 6144,
                                Flags = 0x3E00,
                                Location = new EMLocation
                                {
                                    X = 64000 - 3072,
                                    Y = 8192-1024-512,
                                    Z = 33280,
                                    Room = -2,
                                    Angle = 16384
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 64000 - 3072,
                                    Y = 8192 + 1024,
                                    Z = 33280+1024,
                                    Room = -1
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
                            },
                            HardVariant = new EMTriggerFunction
                            {
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 64000 - 3072,
                                        Y = 8192 + 1024,
                                        Z = 33280,
                                        Room = -1
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
                                },
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add an additionl door to room 22.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door2,
                            Intensity = level.Entities[40].Intensity,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Y = 6656,
                                Z = 68096 + 2048,
                                Room = 22,
                                Angle = level.Entities[40].Angle
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add switches for the additional door and return trapdoor.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.WallSwitch,
                            Intensity = level.Entities[36].Intensity,
                            Location = new EMLocation
                            {
                                X = 62976,
                                Y = 6144,
                                Z = 30208,
                                Room = -2,
                                Angle = -32768
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.WallSwitch,
                            Intensity = level.Entities[36].Intensity,
                            Location = new EMLocation
                            {
                                X = 62976 - 1024,
                                Y = 6144,
                                Z = 30208,
                                Room = -2,
                                Angle = -32768
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
                                Timer = 10,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        // Trapdoor
                                        Parameter = -4
                                    }
                                }
                            },
                            HardVariant = new EMTriggerFunction
                            {
                                Comments = "The hard variant tightens the timer.",
                                EMType = EMType.Trigger,
                                EntityLocation = -1,
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    TrigType = FDTrigType.Switch,
                                    SwitchOrKeyRef = -1,
                                    Timer = 5,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            // Trapdoor
                                            Parameter = -4
                                        }
                                    }
                                },
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = -2,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Switch,
                                SwitchOrKeyRef = -2,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        // Lifting door
                                        Parameter = -3
                                    }
                                }
                            }
                        },
                        new EMCameraTriggerFunction
                        {
                            Comments = "Append the same camera action as the other door triggers.",
                            EMType = EMType.CameraTriggerFunction,
                            AttachToLocations = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 62976,
                                    Y = 6144,
                                    Z = 30208,
                                    Room = -2,
                                },
                            },
                            CameraIndex = 7,
                            LookAtItem = 43,
                            CameraAction = new FDCameraAction
                            {
                                Value = 32771
                            }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments = "Generate lighting in the new rooms.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1, -2 }
                        }
                    },
                    // Moving block area puzzle
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a trap/puzzle room off room 27.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 5,
                            Width = 3,
                            Depth = 5,
                            Textures = new EMTextureGroup
                            {
                                Floor = 33,
                                Ceiling = 33,
                                Wall4 = 31,
                                Wall1 = 34,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 28122214
                            },
                            AmbientLighting = level.Rooms[32].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[16].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -768,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 2248,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 70144,
                                Y = 8704,
                                Z = 45568,
                                Room = 27
                            },
                            Location = new EMLocation
                            {
                                X = 69632 - 1024,
                                Y = 8704 - 2048 + 256,
                                Z = 45056 - 4*1024,
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-1] = new List<int> { 7,8, },
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 11,
                            Depth = 11,
                            Textures = new EMTextureGroup
                            {
                                Floor = 33,
                                Ceiling = 33,
                                Wall4 = 31,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 28122214
                            },
                            AmbientLighting = level.Rooms[27].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[16].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 8 * 1024 + 512,
                                    Y = -2048+256,
                                    Z = 8 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 8 * 1024 + 512,
                                    Y = -2048+256,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 2 * 1024 + 512,
                                    Y = -2048+256,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                                new EMRoomLight
                                {
                                    X = 2 * 1024 + 512,
                                    Y = -2048+256,
                                    Z = 8 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 1024,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 70144,
                                Y = 8704,
                                Z = 45568,
                                Room = 27
                            },
                            Location = new EMLocation
                            {
                                X = 69632 - 5*1024,
                                Y = 8704 + 256,
                                Z = 45056 - 12*1024,
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int>{ }
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
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 6912,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 6912,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 6912,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 6912,
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
                                        Y = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 6912,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 6912,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = 6912,
                                            Z = 10 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 6912,
                                            Z = 10 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = 27,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 6656 - 1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 6656 - 1024,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = 6656,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 6656,
                                            Z = 4 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 27,
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
                                            Y = 6656 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 6656 - 1024,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 6656,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 6656,
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
                            Ceiling = new EMLocation
                            {
                                X = 70144,
                                Y = 6912,
                                Z = 42496,
                                Room = -2
                            },
                            Floor = new EMLocation
                            {
                                X = 70144,
                                Y = 6912 + 1024,
                                Z = 42496,
                                Room = -1
                            },
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "More collisional portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [-2] = new Dictionary<short, EMLocation[]>
                                {
                                    [27] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 70144,
                                            Y = 6656,
                                            Z = 44544 + 1024,
                                            Room = -2
                                        }
                                    }
                                },
                                [27] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 70144,
                                            Y = 6656,
                                            Z = 44544,
                                            Room = 27
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [-2] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 70144,
                                            Y = 8960,
                                            Z = 42496 + 1024,
                                            Room = -1
                                        }
                                    }
                                },
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Amend some faces.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    FaceIndices = new int[] { 12,54 },
                                    RoomNumber = -1,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    FaceIndices = new int[] { 36,114,132 },
                                    RoomNumber = -1,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    FaceIndices = new int[] { 78 },
                                    RoomNumber = 27,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 3,
                                        [1] = 0,
                                        [2] = 1,
                                        [3] = 2
                                    }
                                },
                            },
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    FaceIndex = 78,
                                    RoomNumber = 27,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [39] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        // Indicates where not to stop and wait for the block to return
                                        [EMTextureFaceType.Rectangles] = new int[] { 36,114,132 }
                                    },
                                    [27] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 78 }
                                    }
                                },
                                [45] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 89 }
                                    },
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0 }
                                    }
                                }
                            }
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMRefaceFunction
                            {
                                Comments = "Change some textures.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [33] = new EMGeometryMap
                                    {
                                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 36,114,132 }
                                        },
                                    },
                                    [36] = new EMGeometryMap
                                    {
                                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            // Indicates where to stop and wait for the block to return
                                            [EMTextureFaceType.Rectangles] = new int[] { 12 }
                                        },
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove a face for a portal.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 16 }
                                },
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add moving blocks to the maze - à la Folklorist Diary.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.MovingBlock,
                            Intensity = level.Entities[49].Intensity,
                            Location = new EMLocation
                            {
                                X = 72192,
                                Y = 8960,
                                Z = 41472,
                                Room = -1,
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
                                    X = 72192 - 1024,
                                    Y = 8960,
                                    Z = 41472,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 72192,
                                    Y = 8960,
                                    Z = 41472,
                                    Room = -1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 4,
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
                            TypeID = (short)TREntities.MovingBlock,
                            Intensity = level.Entities[49].Intensity,
                            Location = new EMLocation
                            {
                                X = 73216,
                                Y = 8960,
                                Z = 36352,
                                Room = -1,
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
                                    X = 73216,
                                    Y = 8960,
                                    Z = 36352 + 1024,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 73216,
                                    Y = 8960,
                                    Z = 36352,
                                    Room = -1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 4,
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
                            TypeID = (short)TREntities.MovingBlock,
                            Intensity = level.Entities[49].Intensity,
                            Location = new EMLocation
                            {
                                X = 68096,
                                Y = 8960,
                                Z = 35328,
                                Room = -1,
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
                                    X = 68096 + 1024,
                                    Y = 8960,
                                    Z = 35328,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 68096,
                                    Y = 8960,
                                    Z = 35328,
                                    Room = -1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 4,
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
                            TypeID = (short)TREntities.MovingBlock,
                            Intensity = level.Entities[49].Intensity,
                            Location = new EMLocation
                            {
                                X = 67072,
                                Y = 8960,
                                Z = 40448,
                                Room = -1
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 67072,
                                    Y = 8960,
                                    Z = 40448 - 1024,
                                    Room = -1
                                },
                                new EMLocation
                                {
                                    X = 67072,
                                    Y = 8960,
                                    Z = 40448,
                                    Room = -1
                                }
                            },
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                Timer = 4,
                                Actions = new List<EMTriggerAction>
                                {
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
                            HardVariant = new EMConvertTriggerFunction
                            {
                                Comments = "Increase the block timers in hard mode.",
                                EMType = EMType.ConvertTrigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 72192 - 1024,
                                        Y = 8960,
                                        Z = 41472,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 72192,
                                        Y = 8960,
                                        Z = 41472,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 73216,
                                        Y = 8960,
                                        Z = 36352 + 1024,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 73216,
                                        Y = 8960,
                                        Z = 36352,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 68096 + 1024,
                                        Y = 8960,
                                        Z = 35328,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 68096,
                                        Y = 8960,
                                        Z = 35328,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 67072,
                                        Y = 8960,
                                        Z = 40448 - 1024,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 67072,
                                        Y = 8960,
                                        Z = 40448,
                                        Room = -1
                                    }
                                },
                                Timer = 10
                            }
                        },
                        new EMImportNonGraphicsModelFunction
                        {
                            Comments = "Import the underwater lever model.",
                            EMType = EMType.ImportNonGraphicsModel,
                            Data = new List<EMMeshTextureData>
                            {
                                new EMMeshTextureData
                                {
                                    ModelID = (short)TREntities.UnderwaterSwitch,
                                    TexturedFace3 = 970,
                                    TextureMap = new Dictionary<ushort, ushort>
                                    {
                                        [693] = 849,
                                        [692] = 970,
                                        [691] = 971,
                                        [690] = 971,
                                        [689] = 970
                                    }
                                },
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add an underwater lever to open the additional door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.UnderwaterSwitch,
                            Intensity = level.Entities[53].Intensity,
                            Location = new EMLocation
                            {
                                X = 66048,
                                Y = 8960 - 768,
                                Z = 35328,
                                Room = -1,
                                Angle = -16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add an additionl door to room 22.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door1,
                            Intensity = level.Entities[40].Intensity,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Y = 6656,
                                Z = 68096 + 2048,
                                Room = 22,
                                Angle = level.Entities[40].Angle
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = -2,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                SwitchOrKeyRef = -2,
                                TrigType = FDTrigType.Switch,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        new EMCameraTriggerFunction
                        {
                            Comments = "Append the same camera action as the other door triggers.",
                            EMType = EMType.CameraTriggerFunction,
                            AttachToLocations = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    X = 66048,
                                    Y = 8960 - 768,
                                    Z = 35328,
                                    Room = -1,
                                },
                            },
                            CameraIndex = 7,
                            LookAtItem = 43,
                            CameraAction = new FDCameraAction
                            {
                                Value = 32771
                            }
                        },
                        new EMFloodFunction
                        {
                            Comments = "Flood the maze.",
                            EMType = EMType.Flood,
                            RoomNumbers = new int[] { -1 }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments = "Generate lighting in the new rooms.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1, -2 }
                        }
                    },
                    // Pushblock area puzzle
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
                            AmbientLighting = level.Rooms[32].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[16].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 49664,
                                Y = 6656,
                                Z = 43520,
                                Room = 37
                            },
                            Location = new EMLocation
                            {
                                X = 52736-512-1024,
                                Y = -1536+1024,
                                Z = 39424-512-1024,
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            Comments = "Make a trap/puzzle room off room 37.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 12,
                            Width = 9,
                            Depth = 10,
                            Textures = new EMTextureGroup
                            {
                                Floor = 33,
                                Ceiling = 33,
                                Wall4 = 31,
                                Wall1 = 34,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 28122214
                            },
                            AmbientLighting = level.Rooms[32].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[16].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -6*256,
                                    Z = 8 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -6*256,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -6*256,
                                    Z = 5 * 1024,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 7 * 1024 + 512,
                                    Y = -6*256,
                                    Z = 5 * 1024,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 49664,
                                Y = 6656,
                                Z = 43520,
                                Room = 37
                            },
                            Location = new EMLocation
                            {
                                X = 49152 - 4096,
                                Y = 6656 - 1024,
                                Z = 43008 - 8*1024,
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-1] = new List<int> { 11,12,13,16,17,18, 71,72,73,76,77,78 },
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [1] = new List<int> { 11,18,21,28,68,78,74,64,54 }
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 16,
                            Width = 9,
                            Depth = 10,
                            Textures = new EMTextureGroup
                            {
                                Floor = 33,
                                Ceiling = 33,
                                Wall4 = 31,
                                Wall1 = 34,
                                WallAlignment = Direction.Down,
                                RandomRotationSeed = 28122214
                            },
                            AmbientLighting = level.Rooms[32].AmbientIntensity,
                            DefaultVertex = new EMRoomVertex
                            {
                                Lighting = level.Rooms[11].RoomData.Vertices[level.Rooms[11].RoomData.Rectangles[16].Vertices[2]].Lighting
                            },
                            Lights = new EMRoomLight[]
                            {
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -6*256,
                                    Z = 8 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -6*256,
                                    Z = 1 * 1024 + 512,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 1 * 1024 + 512,
                                    Y = -6*256,
                                    Z = 5 * 1024,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 7 * 1024 + 512,
                                    Y = -6*256,
                                    Z = 5 * 1024,
                                    Intensity1 = 4096,
                                    Fade1 = 3072,
                                },
                                new EMRoomLight
                                {
                                    X = 4 * 1024 + 512,
                                    Y = -14*256,
                                    Z = 5 * 1024,
                                    Intensity1 = 4096,
                                    Fade1 = 5*1024,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 49664,
                                Y = 6656,
                                Z = 43520,
                                Room = 37
                            },
                            Location = new EMLocation
                            {
                                X = 49152 - 4096,
                                Y = 6656 - 1024 - 12 * 256,
                                Z = 43008 - 8*1024,
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                //[-1] = new List<int> { 11,12,13,16,17,18 },
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [4] = new List<int> { 11,12,13,14,15,16,17,18,71,72,73,74,75,76,77,78,21,31,41,51,61,28,38,48,58,68 },
                                [3] = new List<int> { 22,23,24,25,26,27,32,42,52,62,63,64,65,66,67,37,47,57 }
                            }
                        },

                        new EMVerticalCollisionalPortalFunction
                        {
                            Comments = "Collisional portals.",
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 49664,
                                Y = 5632,
                                Z = 43520,
                                Room = -2
                            },
                            Floor = new EMLocation
                            {
                                X = 49664,
                                Y = 5632 + 1024,
                                Z = 43520,
                                Room = 37
                            }
                        },
                        new EMVerticalCollisionalPortalFunction
                        {
                            EMType = EMType.VerticalCollisionalPortal,
                            Ceiling = new EMLocation
                            {
                                X = 52736,
                                Y = -1536+1024,
                                Z = 39424,
                                Room = -3
                            },
                            Floor = new EMLocation
                            {
                                X = 52736,
                                Y = -1536+2048,
                                Z = 39424,
                                Room = -1
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
                                            Y = 2560,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = 2560,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 8 * 1024,
                                            Y = 2560,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 8 * 1024,
                                            Y = 2560,
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
                                            X = 8 * 1024,
                                            Y = 2560,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 8 * 1024,
                                            Y = 2560,
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
                                            Z = 1 * 1024
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -2,
                                    AdjoiningRoom = 37,
                                    Normal = new TRVertex
                                    {
                                        Y = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 5632,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 5632,
                                            Z = 9 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = 5632,
                                            Z = 8 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 5632,
                                            Z = 8 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 37,
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
                                            Y = 5632,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 5632,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = 5632,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = 5632,
                                            Z = 3 * 1024
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
                                [105] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { /*43*/5 }
                                    }
                                },
                                [41] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 118 }
                                    }
                                },
                            },
                            //HardVariant = new EMRefaceFunction
                            //{
                            //    Comments = "Different lever face in hard mode.",
                            //    EMType = EMType.Reface,
                            //    TextureMap = new EMTextureMap
                            //    {
                            //        [105] = new EMGeometryMap
                            //        {
                            //            [-1] = new Dictionary<EMTextureFaceType, int[]>
                            //            {
                            //                [EMTextureFaceType.Rectangles] = new int[] { 5 }
                            //            }
                            //        },
                            //        [41] = new EMGeometryMap
                            //        {
                            //            [-2] = new Dictionary<EMTextureFaceType, int[]>
                            //            {
                            //                [EMTextureFaceType.Rectangles] = new int[] { 118 }
                            //            }
                            //        },
                            //    },
                            //}
                        },
                        new EMModifyFaceFunction
                        {
                            Comments ="Alter some faces.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = -1,
                                    FaceIndices = new int[] { 5,/*43*/ },
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                    FaceIndices = new int[] { 118 },
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
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove faces for portals.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] {
                                        184,192,197,153,159,162,128,133,135,105,110,112,81,87,89,57,61,9,15,
                                        114,91,64,20,
                                        209,168,140,117,93,66,26,
                                        216,171,143,119,95,68,32,
                                        221,174,145,121,97,71,37,
                                        99,123,147,
                                        122
                                    }
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] {
                                        101,127,157,
                                        33,67,98,124,154,183,225,
                                        28,64,94,121,150,180,220,
                                        23,61,91,119,147,177,215,
                                        18,58,88,117,
                                        13,55,84,114,140,171,205,
                                        8,51,81,111,137,167,200,
                                        76,106,132,162,192
                                    }
                                },
                                [37] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] {
                                        42
                                    }
                                }
                            }
                        },
                        new EMAddStaticMeshFunction
                        {
                            Comments = "Add some statues.",
                            EMType = EMType.AddStaticMesh,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 46592 - 512,
                                    Y = 5632,
                                    Z = 39424 + 512,
                                    Room = -2,
                                    Angle = -16384
                                },
                                new EMLocation
                                {
                                    X = 52736 + 512,
                                    Y = 5632,
                                    Z = 39424 + 512,
                                    Room = -2,
                                    Angle = 16384
                                }
                            },
                            Mesh = new TR2RoomStaticMesh
                            {
                                MeshID = 12,
                                Intensity1 = Array.Find(level.Rooms[39].StaticMeshes, s => s.MeshID == 12).Intensity
                            }
                        },
                        new EMImportNonGraphicsModelFunction
                        {
                            Comments = "Ensure Thor's hammer model is available.",
                            EMType = EMType.ImportNonGraphicsModel,
                            Data = new List<EMMeshTextureData>
                            {
                                new EMMeshTextureData
                                {
                                    ModelID = (short)TREntities.ThorHammerHandle,
                                    TextureMap = new Dictionary<ushort, ushort>
                                    {
                                        [750] = 35, // Top of handle
                                        [751] = 35, // Base
                                        [752] = 35, // Centre decoration
                                        [753] = 35, // Centre decoration
                                    }
                                },
                                new EMMeshTextureData
                                {
                                    ModelID = (short)TREntities.ThorHammerBlock,
                                    TexturedFace4 = 1016
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add the hammer and trigger it.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.ThorHammerHandle,
                            Intensity = level4.Entities[63].Intensity,
                            Location = new EMLocation
                            {
                                X = 49664,
                                Y = 5632,
                                Z = 36352 + 2048,
                                Room = -2,
                            },
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 49664,
                                    Y = 5632,
                                    Z = 42496 - 1024,
                                    Room = -2
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
                        new EMAddEntityFunction
                        {
                            Comments = "Add a pushblock.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.PushBlock1,
                            Flags = level4.Entities[20].Flags,
                            Intensity = level4.Entities[20].Intensity,
                            Location = new EMLocation
                            {
                                X = 46592,
                                Y = -512,
                                Z = 41472,
                                Room = -1,
                            },
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Hammer triggers the pushblock.",
                            EMType = EMType.Trigger,
                            EntityLocation = -2,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.HeavyTrigger,
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
                            Comments = "Add a lever to open the additional door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.WallSwitch,
                            Intensity = level.Entities[53].Intensity,
                            Location = new EMLocation
                            {
                                //X = 46592,
                                //Y = 2560,
                                //Z = 43520,
                                //Room = -1,
                                X = 46592,
                                    Y = 2560,
                                    Z = 36352,
                                    Room = -1,
                                    Angle = -32768
                            },
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add an additionl door to room 22.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door3,
                            Intensity = level.Entities[40].Intensity,
                            Location = new EMLocation
                            {
                                X = 55808,
                                Y = 6656,
                                Z = 68096 + 2048,
                                Room = 22,
                                Angle = level.Entities[40].Angle
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = -2,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                SwitchOrKeyRef = -2,
                                TrigType = FDTrigType.Switch,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        new EMCameraTriggerFunction
                        {
                            Comments = "Append the same camera action as the other door triggers.",
                            EMType = EMType.CameraTriggerFunction,
                            AttachToLocations = new EMLocation[]
                            {
                                new EMLocation
                                {
                                    //X = 46592,
                                    //Y = 2560,
                                    //Z = 43520,
                                    //Room = -1,
                                    X = 46592,
                                    Y = 2560,
                                    Z = 36352,
                                    Room = -1,
                                },
                            },
                            CameraIndex = 7,
                            LookAtItem = 43,
                            CameraAction = new FDCameraAction
                            {
                                Value = 32771
                            }
                        },

                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMAddEntityFunction
                            {
                                Comments = "Add some darts to spice up the platforming.",
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.DartEmitter,
                                Intensity = level.Entities[69].Intensity,
                                Location = new EMLocation
                                {
                                    X = 47616,
                                    Y = 2560,
                                    Z = 36352,
                                    Room = -1
                                }
                            },
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMAddEntityFunction
                            {
                                EMType = EMType.AddEntity,
                                TypeID = (short)TREntities.DartEmitter,
                                Intensity = level.Entities[69].Intensity,
                                Location = new EMLocation
                                {
                                    X = 47616 + 3072,
                                    Y = 2560,
                                    Z = 36352,
                                    Room = -1
                                }
                            },
                        },
                        new EMPlaceholderFunction
                        {
                            Comments = "Placeholder for easy mode.",
                            EMType = EMType.NOOP,
                            HardVariant = new EMTriggerFunction
                            {
                                Comments = "Dart triggers in hard mode.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 46592,
                                        Y = 2560,
                                        Z = 43520,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 46592 + 1024,
                                        Y = 2560,
                                        Z = 43520,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 46592 + 5*1024,
                                        Y = 2560,
                                        Z = 43520,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 46592 + 6*1024,
                                        Y = 2560,
                                        Z = 43520,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 46592 + 6*1024,
                                        Y = 2560,
                                        Z = 43520 - 4*1024,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 46592 + 5*1024,
                                        Y = 2560,
                                        Z = 43520 - 4*1024,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 46592 + 4*1024,
                                        Y = 2560,
                                        Z = 43520 - 4*1024,
                                        Room = -1
                                    },
                                    new EMLocation
                                    {
                                        X = 47616,
                                        Y = 2560,
                                        Z = 36352,
                                        Room = -1
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

                        new EMAddEntityFunction
                        {
                            Comments= "Add another block and its trigger in easy mode.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.PushBlock1,
                            Flags = level4.Entities[20].Flags,
                            Intensity = level4.Entities[20].Intensity,
                            Location = new EMLocation
                            {
                                X = 52736,
                                Y = -512-1024,
                                Z = 39424,
                                Room = -3
                            },
                            HardVariant = new EMPlaceholderFunction
                            {
                                Comments = "No extra block in hard mode.",
                                EMType = EMType.NOOP
                            }
                        },
                        new EMAppendTriggerActionFunction
                        {
                            EMType = EMType.AppendTriggerActionFunction,
                            Location = new EMLocation
                            {
                                X = 49664,
                                Y = 5504,
                                Z = 38400,
                                Room = -2
                            },
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            },
                            HardVariant = new EMPlaceholderFunction
                            {
                                EMType = EMType.NOOP
                            }
                        },

                        new EMGenerateLightFunction
                        {
                            Comments = "Generate lighting in the new rooms.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> { -1, -2 }
                        }
                    }
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Don't move the breakaway ceiling pieces in room 20.",
                            EMType = EMType.NOOP
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the breakaway ceiling pieces in room 20.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 38,
                            TargetLocation = new EMLocation
                            {
                                X = 54784,
                                Y = 2944,
                                Z = 61952 + 1024,
                                Room = 20,
                                Angle = level.Entities[38].Angle
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 39,
                            TargetLocation = new EMLocation
                            {
                                X = 55808 + 1024,
                                Y = 2944,
                                Z = 60928,
                                Room = 20,
                                Angle = level.Entities[39].Angle
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the breakaway ceiling pieces in room 20.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 38,
                            TargetLocation = new EMLocation
                            {
                                X = 54784 + 1024,
                                Y = 2944,
                                Z = 61952,
                                Room = 20,
                                Angle = level.Entities[38].Angle
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 39,
                            TargetLocation = new EMLocation
                            {
                                X = 55808,
                                Y = 2944,
                                Z = 60928 + 1024,
                                Room = 20,
                                Angle = level.Entities[39].Angle
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the breakaway ceiling pieces in room 20.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 39,
                            TargetLocation = new EMLocation
                            {
                                X = 55808 + 1024,
                                Y = 2944,
                                Z = 60928 + 1024,
                                Room = 20,
                                Angle = level.Entities[39].Angle
                            }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the breakaway ceiling pieces in room 20.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 38,
                            TargetLocation = new EMLocation
                            {
                                X = 54784 + 1024,
                                Y = 2944,
                                Z = 61952 + 1024,
                                Room = 20,
                                Angle = level.Entities[38].Angle
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the breakaway ceiling pieces in room 20.",
                            EMType = EMType.MoveEntity,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            EntityIndex = 38,
                            TargetLocation = new EMLocation
                            {
                                X = 54784 + 2048,
                                Y = 2944,
                                Z = 61952 + 1024,
                                Room = 20,
                                Angle = level.Entities[38].Angle
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            EMType = EMType.MoveEntity,
                            EntityIndex = 39,
                            TargetLocation = new EMLocation
                            {
                                X = 55808 - 1024,
                                Y = 2944,
                                Z = 60928,
                                Room = 20,
                                Angle = level.Entities[39].Angle
                            }
                        }
                    },
                }
            };

            int g = 0;
            foreach (EMLocation loc in JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("toqpit.json"))[Level])
            {
                mapping.AllWithin[1][0].Insert(2 + g++, new EMVerticalCollisionalPortalFunction
                {
                    Comments = "Pit portal.",
                    EMType = EMType.VerticalCollisionalPortal,
                    Ceiling = loc,
                    Floor = new EMLocation
                    {
                        X = loc.X,
                        Y = loc.Y + 1024,
                        Z = loc.Z,
                        Room = -1
                    }
                });
            }

            // ToQ pillar maze walls
            EMCreateRoomFunction func = mapping.AllWithin[1][1][1] as EMCreateRoomFunction;
            foreach (EMLocation loc in JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("toquwmaze.json"))[Level])
            {
                int x = (loc.X - func.Location.X) / 1024;
                int z = (loc.Z - func.Location.Z) / 1024;
                func.FloorHeights[-127].Add(x * func.Depth + z);
            }

            // Toq Thor room
            g = 0;
            foreach (EMLocation loc in JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("toqthor.json"))[Level])
            {
                mapping.AllWithin[1][2].Insert(3 + g++, new EMVerticalCollisionalPortalFunction
                {
                    Comments = "Vertical portal.",
                    EMType = EMType.VerticalCollisionalPortal,
                    Ceiling = loc,
                    Floor = new EMLocation
                    {
                        X = loc.X,
                        Y = loc.Y + 1024,
                        Z = loc.Z,
                        Room = -2
                    }
                });
            }

            mapping.OneOf = new List<EMEditorGroupedSet>
            {
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 43.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [32] = new EMGeometryMap
                                {
                                    [43] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 14 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Rotate the face to match the rest of the wall.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    RoomNumber = 43,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[] { 14 },
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
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMMoveSlotFunction
                            {
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 74,
                                Location = new EMLocation
                                {
                                    X = 64000 + 1024,
                                    Y = 6656,
                                    Z = 48640,
                                    Room = 43,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [43] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 28 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the rest of the wall.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        RoomNumber = 43,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 28 },
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
                                EntityIndex = 74,
                                Location = new EMLocation
                                {
                                    X = 64000 + 1024,
                                    Y = 6656,
                                    Z = 48640,
                                    Room = 43,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [43] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 74,
                                Location = new EMLocation
                                {
                                    X = 64000 + 1 * 1024,
                                    Y = 6656,
                                    Z = 48640 + 2 * 1024,
                                    Room = 43,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [43] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 74,
                                Location = new EMLocation
                                {
                                    X = 64000 + 1 * 1024,
                                    Y = 6656,
                                    Z = 48640 + 3 * 1024,
                                    Room = 43,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [43] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 74,
                                Location = new EMLocation
                                {
                                    X = 64000 + 1 * 1024,
                                    Y = 6656,
                                    Z = 48640 + 3 * 1024,
                                    Room = 43
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [43] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 74,
                                Location = new EMLocation
                                {
                                    X = 64000,
                                    Y = 6656,
                                    Z = 48640 + 3 * 1024,
                                    Room = 43
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [43] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 25 }
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
                                EntityIndex = 74,
                                Location = new EMLocation
                                {
                                    X = 64000 - 1024,
                                    Y = 6656,
                                    Z = 48640 + 3 * 1024,
                                    Room = 43
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [43] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 74,
                                Location = new EMLocation
                                {
                                    X = 64000 - 1024,
                                    Y = 6656,
                                    Z = 48640 + 2 * 1024,
                                    Room = 43,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [43] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 8 }
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
                                EntityIndex = 74,
                                Location = new EMLocation
                                {
                                    X = 64000 - 1024,
                                    Y = 6656,
                                    Z = 48640 + 1 * 1024,
                                    Room = 43,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [43] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 74,
                                Location = new EMLocation
                                {
                                    X = 64000 - 1024,
                                    Y = 6656,
                                    Z = 48640,
                                    Room = 43,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [43] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 74,
                                Location = new EMLocation
                                {
                                    X = 64000 - 1024,
                                    Y = 6656,
                                    Z = 48640,
                                    Room = 43,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above and some trolling.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [43] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 2, 5, 8, 11, 25, 37, 46, 44, 45, 42, 38, 28, 14 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Undo the previous rotations.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        RoomNumber = 43,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 14, 28 },
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
                    }
                },
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMRefaceFunction
                        {
                            Comments = "Remove the default lever texture in room 53.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [99] = new EMGeometryMap
                                {
                                    [53] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 16 }
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
                                EntityIndex = 76,
                                Location = new EMLocation
                                {
                                    X = 68096,
                                    Y = 5632,
                                    Z = 42496,
                                    Room = 53
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [53] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 76,
                                Location = new EMLocation
                                {
                                    X = 68096 - 1024,
                                    Y = 5632,
                                    Z = 42496 + 1024,
                                    Room = 53,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [53] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 76,
                                Location = new EMLocation
                                {
                                    X = 68096 - 1024,
                                    Y = 5632,
                                    Z = 42496 + 2 * 1024,
                                    Room = 53,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [53] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 76,
                                Location = new EMLocation
                                {
                                    X = 68096 - 1024,
                                    Y = 5632,
                                    Z = 42496 + 2 * 1024,
                                    Room = 53,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [53] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 76,
                                Location = new EMLocation
                                {
                                    X = 68096 - 1024,
                                    Y = 5632,
                                    Z = 42496 + 1 * 1024,
                                    Room = 53,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [53] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 76,
                                Location = new EMLocation
                                {
                                    X = 68096 - 1024,
                                    Y = 5632,
                                    Z = 42496 - 0 * 1024,
                                    Room = 53,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [53] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 76,
                                Location = new EMLocation
                                {
                                    X = 68096 - 1024,
                                    Y = 5632,
                                    Z = 42496 - 0 * 1024,
                                    Room = 53,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [53] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 76,
                                Location = new EMLocation
                                {
                                    X = 68096,
                                    Y = 5632,
                                    Z = 42496 - 0 * 1024,
                                    Room = 53,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [53] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 12 }
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
                            Comments = "Remove the default lever texture in room 28.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [1013] = new EMGeometryMap
                                {
                                    [28] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 43 }
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
                                    X = 76288,
                                    Y = 6656,
                                    Z = 45568 + 1024,
                                    Room = 28,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 76288,
                                    Y = 6656,
                                    Z = 45568 + 1024,
                                    Room = 28
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 41 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        RoomNumber = 28,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 41 },
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 76288 - 1024,
                                    Y = 6656,
                                    Z = 45568 + 1024,
                                    Room = 28
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 33 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        RoomNumber = 28,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        FaceIndices = new int[] { 33 },
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 76288 - 1024,
                                    Y = 6656,
                                    Z = 45568 + 1024,
                                    Room = 28,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 76288 - 1024,
                                    Y = 6656,
                                    Z = 45568 - 1024,
                                    Room = 28,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 76288 - 1024,
                                    Y = 6656,
                                    Z = 45568 - 1024,
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
                                    [105] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 76288,
                                    Y = 6656,
                                    Z = 45568 - 1024,
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
                                    [105] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 53,
                                Location = new EMLocation
                                {
                                    X = 76288,
                                    Y = 6656,
                                    Z = 45568 - 1024,
                                    Room = 28,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [28] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 42 }
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
                            Comments = "Remove the default lever texture in room 37.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [1013] = new EMGeometryMap
                                {
                                    [37] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 29 }
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
                                EntityIndex = 65,
                                Location = new EMLocation
                                {
                                    X = 49664,
                                    Y = 6656,
                                    Z = 43520,
                                    Room = 37,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [37] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 65,
                                Location = new EMLocation
                                {
                                    X = 49664,
                                    Y = 6656,
                                    Z = 43520,
                                    Room = 37,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [37] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 28 }
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
                            Comments = "Remove the default lever texture in room 35.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [35] = new EMGeometryMap
                                {
                                    [35] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 11 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Stretch the face up to match the rest of the room.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 35,
                                    FaceIndex = 11,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -768
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -768
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
                                EntityIndex = 63,
                                Location = new EMLocation
                                {
                                    X = 55808 + 1024,
                                    Y = 4096,
                                    Z = 45568,
                                    Room = 35,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [35] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 19 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Match the original lever style.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 35,
                                        FaceIndex = 19,
                                        FaceType = EMTextureFaceType.Rectangles,
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
                                        RoomNumber = 35,
                                        FaceIndex = 10,
                                        FaceType = EMTextureFaceType.Rectangles,
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
                                                X = 1024
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = 1024
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
                                EntityIndex = 63,
                                Location = new EMLocation
                                {
                                    X = 55808 + 1024,
                                    Y = 4096,
                                    Z = 45568,
                                    Room = 35,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [35] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 24 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Match the original lever style.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 35,
                                        FaceIndex = 24,
                                        FaceType = EMTextureFaceType.Rectangles,
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
                                        RoomNumber = 35,
                                        FaceIndex = 10,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = 1024,
                                                Z = 1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = 2048
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 2048
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = 1024,
                                                Z = 1024
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
                                EntityIndex = 63,
                                Location = new EMLocation
                                {
                                    X = 55808 + 1024,
                                    Y = 4096,
                                    Z = 45568 + 1024,
                                    Room = 35
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [35] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 23 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Match the original lever style.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 35,
                                        FaceIndex = 23,
                                        FaceType = EMTextureFaceType.Rectangles,
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
                                        RoomNumber = 35,
                                        FaceIndex = 10,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                Z = 2048
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = 2048,
                                                Z = 2048
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = 2048,
                                                Z = 2048
                                            },
                                            [3] = new TRVertex
                                            {
                                                Z = 2048
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
                                EntityIndex = 63,
                                Location = new EMLocation
                                {
                                    X = 55808 - 1024,
                                    Y = 4096,
                                    Z = 45568 + 1024,
                                    Room = 35
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [35] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 7 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Match the original lever style.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 35,
                                        FaceIndex = 7,
                                        FaceType = EMTextureFaceType.Rectangles,
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
                                        RoomNumber = 35,
                                        FaceIndex = 10,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = -2048,
                                                Z = 2048
                                            },
                                            [1] = new TRVertex
                                            {
                                                Z = 2048
                                            },
                                            [2] = new TRVertex
                                            {
                                                Z = 2048
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = -2048,
                                                Z = 2048
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
                                EntityIndex = 63,
                                Location = new EMLocation
                                {
                                    X = 55808 - 1024,
                                    Y = 4096,
                                    Z = 45568 + 1024,
                                    Room = 35,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [35] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 6 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Match the original lever style.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 35,
                                        FaceIndex = 6,
                                        FaceType = EMTextureFaceType.Rectangles,
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
                                        RoomNumber = 35,
                                        FaceIndex = 10,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = -2048,
                                                Z = 1024
                                            },
                                            [1] = new TRVertex
                                            {
                                                X = -1024,
                                                Z = 2048
                                            },
                                            [2] = new TRVertex
                                            {
                                                X = -1024,
                                                Z = 2048
                                            },
                                            [3] = new TRVertex
                                            {
                                                X = -2048,
                                                Z = 1024
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
                                EntityIndex = 63,
                                Location = new EMLocation
                                {
                                    X = 55808 - 1024,
                                    Y = 4096,
                                    Z = 45568,
                                    Room = 35,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [35] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Match the original lever style.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 35,
                                        FaceIndex = 2,
                                        FaceType = EMTextureFaceType.Rectangles,
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
                                        RoomNumber = 35,
                                        FaceIndex = 10,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexChanges = new Dictionary<int, TRVertex>
                                        {
                                            [0] = new TRVertex
                                            {
                                                X = -2048
                                            },
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
                                            [3] = new TRVertex
                                            {
                                                X = -2048
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
                                EntityIndex = 63,
                                Location = new EMLocation
                                {
                                    X = 55808 - 1024,
                                    Y = 4096,
                                    Z = 45568,
                                    Room = 35,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [35] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        }
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Match the original lever style.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 35,
                                        FaceIndex = 3,
                                        FaceType = EMTextureFaceType.Rectangles,
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
                                        RoomNumber = 35,
                                        FaceIndex = 10,
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
                                EntityIndex = 63,
                                Location = new EMLocation
                                {
                                    X = 59904,
                                    Y = 8448,
                                    Z = 48640,
                                    Room = 34,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [105] = new EMGeometryMap
                                    {
                                        [34] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 50 }
                                        },
                                        [35] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        }
                                    }
                                }
                            },
                            new EMAddStaticMeshFunction
                            {
                                Comments = "Add a fake lever.",
                                EMType = EMType.AddStaticMesh,
                                Mesh = new TR2RoomStaticMesh
                                {
                                    MeshID = 15,
                                    Intensity1 = (ushort)(level.Rooms[32].StaticMeshes.ToList().Find(s => s.MeshID == 15).Intensity + 1024 + 512)
                                },
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 55808 - 1024,
                                        Y = 4096,
                                        Z = 45568,
                                        Room = 35
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Match the original lever style.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 35,
                                        FaceIndex = 3,
                                        FaceType = EMTextureFaceType.Rectangles,
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
                                        RoomNumber = 35,
                                        FaceIndex = 10,
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
                                            }
                                        }
                                    }
                                }
                            }
                        },
                    }
                }
            };

            EMEditorGroupedSet set = mapping.OneOf[0];
            EMAddStaticMeshFunction smesh = new EMAddStaticMeshFunction
            {
                Comments = "Add some fake levers.",
                EMType = EMType.AddStaticMesh,
                Mesh = new TR2RoomStaticMesh
                {
                    MeshID = 15,
                    Intensity1 = (ushort)(level.Rooms[32].StaticMeshes.ToList().Find(s => s.MeshID == 15).Intensity + 1024 + 512)
                },
                Locations = new List<EMLocation>
                {
                    new EMLocation
                    {
                        X = 64000,
                        Y = 6656,
                        Z = 48640,
                        Room = 43
                    }
                }
            };
            for (int i = 0; i < set.Followers.Count - 1; i++)
            {
                EMLocation loc = (set.Followers[i].Find(f => f is EMMoveSlotFunction) as EMMoveSlotFunction).Location;
                smesh.Locations.Add(new EMLocation
                {
                    X = loc.X,
                    Y = loc.Y,
                    Z = loc.Z,
                    Room = loc.Room,
                    Angle = (short)(loc.Angle == 0 ? -32768 :
                    (loc.Angle == -32768 ? 0 :
                    (loc.Angle * -1)))
                });
            }
            smesh.Locations.Add(new EMLocation
            {
                X = 64000 + 2 * 1024,
                Y = 6656,
                Z = 48640 + 1 * 1024,
                Room = 43,
            });
            smesh.Locations.Add(new EMLocation
            {
                X = 64000 + 2 * 1024,
                Y = 6656,
                Z = 48640 + 1 * 1024,
                Room = 43,
                Angle = -32768
            });
            set.Followers.Last().Add(smesh);

            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "If Larson has been converted into a (Great Pyramid) scion, add an alternative enemy and a level-end trigger.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 30,
                        EntityType = (short)TREntities.ScionPiece3_S_P
                    },
                    OnTrue = new EMEditorSet
                    {
                        new EMAddStaticMeshFunction
                        {
                            Comments = "Lara took so long to complete ToQ that Larson died.",
                            EMType = EMType.AddStaticMesh,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 39424,
                                    Y = 4864,
                                    Z = 55808,
                                    Room = 11,
                                    Angle = -16384
                                },
                                new EMLocation
                                {
                                    X = 39424,
                                    Y = 4864,
                                    Z = 55808,
                                    Room = 40,
                                    Angle = -16384
                                }
                            },
                            Mesh = new TR2RoomStaticMesh
                            {
                                Intensity1 = 5200,
                                MeshID = 14
                            },
                            IgnoreSectorEntities = true
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move the scion to the mesh location (it's here to avoid potential slope softlock).",
                            EMType = EMType.MoveEntity,
                            EntityIndex= 30,
                            TargetLocation = new EMLocation
                            {
                                X = 39424,
                                Y = 4864,
                                Z = 55808,
                                Room = 11,
                                Angle = 16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Alternative normal enemy to fight.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Raptor,
                            Intensity = -1,
                            Location = new EMLocation
                            {
                                X = 40448,
                                Y = 4864,
                                Z = 56832,
                                Room = 11,
                                Angle = -32768
                            }
                        },
                        new EMConvertEnemyFunction
                        {
                            Comments = "Convert the new enemy into one the level supports.",
                            EMType = EMType.ConvertEnemy,
                            EntityIndices = new List<int> { -1 },
                            NewEnemyType = EnemyType.Land,
                            Exclusions = new List<short>
                            {
                                (short)TREntities.SkateboardKid,
                                (short)TREntities.Natla,
                            }
                        },
                        new EMAppendTriggerActionFunction
                        {
                            Comments = "Trigger the new enemy.",
                            EMType = EMType.AppendTriggerActionFunction,
                            Location = new EMLocation
                            {
                                X = 43520,
                                Y = 9728,
                                Z = 58880,
                                Room = 10,
                            },
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = -1
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Add a heavy trigger to end the level.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 39424,
                                    Y = 4864,
                                    Z = 55808,
                                    Room = 11,
                                },
                                new EMLocation
                                {
                                    X = 39424,
                                    Y = 4864,
                                    Z = 55808,
                                    Room = 40,
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
                                        Action = FDTrigAction.EndLevel
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

            mapping.RewardEntities = new List<int> { 19, 29, 27, 28 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 50688,
                            Y = 6144,
                            Z = 56832
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door1,
                            X = 50688,
                            Y = 6656,
                            Z = 61952,
                            Intensity = 7360,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 58476,
                            Y = 6079,
                            Z = 64424,
                            Room = 20
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
                                X = 50688,
                                Y = 6656,
                                Z = 61952,
                                Room = 19
                            },
                            NewLocation = new EMLocation
                            {
                                X = 49152,
                                Y = 6912,
                                Z = 55296,
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [19] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 50688,
                                            Y = 6656,
                                            Z = 60928,
                                            Room = 19
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [19] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 50688,
                                            Y = 6912,
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
                                    BaseRoom = 19,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 8192,
                                            Y = 5632,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7168,
                                            Y = 5632,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7168,
                                            Y = 6656,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 8192,
                                            Y = 6656,
                                            Z = 1024
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 19,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 5632,
                                            Z = 6144
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = 5632,
                                            Z = 6144
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = 6656,
                                            Z = 6144
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 6656,
                                            Z = 6144
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
                                        Texture = 32,
                                        Vertices = new ushort[]
                                        {
                                            23, 20, 18, 21
                                        }
                                    },
                                    new TRFace4
                                    {
                                        Texture = 39,
                                        Vertices = new ushort[]
                                        {
                                            6, 7, 0, 4
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
                                    FaceIndex = 15,
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
                        },
                        new EMRefaceFunction
                        {
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [32] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2, 5, 8, 11, 14, 16, 17, 18, 19 }
                                    }
                                },
                                [37] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 15 }
                                    }
                                },
                                [31] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0, 3, 6, 9, 12 }
                                    }
                                },
                                [33] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 1, 4, 7, 10, 13 }
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [19] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 34 }
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

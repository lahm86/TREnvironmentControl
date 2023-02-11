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
    public class TR1KhamoonControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.KHAMOON;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);
            TRLevel level2 = GetTR1Level(TRLevelNames.VILCABAMBA);
            TRLevel level4 = GetTR1Level(TRLevelNames.FOLLY);

            mapping.NonPurist = new EMEditorSet
            {
                new EMConvertTriggerFunction
                {
                    Comments = "Convert the triggers for the trapdoors in room 31 and 34 into dummy triggers.",
                    EMType = EMType.ConvertTrigger,
                    TrigType = FDTrigType.Dummy,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 45568,
                            Y = -5888,
                            Z = 28160,
                            Room = 31
                        },
                        new EMLocation
                        {
                            X = 44544,
                            Y = -5888,
                            Z = 28160,
                            Room = 31
                        },
                        new EMLocation
                        {
                            X = 41472,
                            Y = 3840,
                            Z = 43520,
                            Room = 34
                        },
                        new EMLocation
                        {
                            X = 40448,
                            Y = 3328,
                            Z = 43520,
                            Room = 34
                        },
                        new EMLocation
                        {
                            X = 40448,
                            Y = 2816,
                            Z = 44544,
                            Room = 34
                        },
                        new EMLocation
                        {
                            X = 41472,
                            Y = 3328,
                            Z = 44544,
                            Room = 34
                        }
                    }
                },
                new EMAddEntityFunction
                {
                    Comments = "Add the missing enemy to room 25.",
                    EMType = EMType.AddEntity,
                    Location = new EMLocation
                    {
                        X = 44544,
                        Y = -4096,
                        Z = 33280,
                        Room = 25,
                    },
                    Intensity = level.Entities[36].Intensity,
                    Flags = level.Entities[36].Flags,
                    TypeID = (short)TREntities.NonShootingAtlantean_N
                },
                new EMConvertEnemyFunction
                {
                    Comments = "Convert it into something actually in the level.",
                    EMType = EMType.ConvertEnemy,
                    EntityIndices = new List<int>() { -1 },
                    Exclusions = new List<short>
                    {
                        (short)TREntities.Natla,
                        (short)TREntities.SkateboardKid,
                        (short)TREntities.Adam
                    },
                    NewEnemyType = EnemyType.Land,
                    PreferredType = (short)TREntities.NonShootingAtlantean_N
                },
                new EMTriggerFunction
                {
                    Comments = "Trigger the new enemy.",
                    EMType = EMType.Trigger,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 42496,
                            Y = -4096,
                            Z = 32256,
                            Room = 20
                        },
                        new EMLocation
                        {
                            X = 42496,
                            Y = -4096,
                            Z = 32256,
                            Room = 29
                        }
                    },
                    Trigger = new EMTrigger
                    {
                        Mask = 31,
                        TrigType = FDTrigType.Trigger,
                        Actions = new List<EMTriggerAction>
                        {
                            new EMTriggerAction
                            {
                                Parameter = -1
                            }
                        }
                    }
                },
                // Return path
                new EMSlantFunction
                {
                    Comments ="Amend a slant near the beginning to allow returning.",
                    EMType = EMType.Slant,
                    Location = new EMLocation
                    {
                        X = 28160,
                        Y = -768,
                        Z = 14848
                    },
                    SlantType = FDSlantEntryType.FloorSlant,
                    FloorClicks = 1,
                    XSlant = 1
                },
                new EMSlantFunction
                {
                    Comments ="Raise another slant in room 42.",
                    EMType = EMType.Slant,
                    Location = new EMLocation
                    {
                        X = 49664,
                        Y = -128,
                        Z = 35328,
                        Room = 42
                    },
                    SlantType = FDSlantEntryType.FloorSlant,
                    FloorClicks = -1,
                    ZSlant = 2,
                },
                new EMModifyFaceFunction
                {
                    Comments = "Amend some faces for above.",
                    EMType = EMType.ModifyFace,
                    Modifications = new EMFaceModification[]
                    {
                        new EMFaceModification
                        {
                            FaceIndex = 105,
                            VertexChanges = new Dictionary<int, TRVertex>
                            {
                                [0] = new TRVertex
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
                            FaceIndex = 122,
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
                            RoomNumber = 1,
                            FaceType = EMTextureFaceType.Triangles,
                            FaceIndex = 10,
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
                            RoomNumber = 42,
                            FaceIndex = 42,
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
                            RoomNumber = 42,
                            FaceIndices = new int[]{41,43 },
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
                        }
                    },
                },
                new EMAddFaceFunction
                {
                    Comments = "Patch gaps.",
                    EMType = EMType.AddFace,
                    Triangles = new Dictionary<short, List<TRFace3>>
                    {
                        [0] = new List<TRFace3>
                        {
                            new TRFace3
                            {
                                Texture = level.Rooms[1].RoomData.Triangles[10].Texture,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[0].RoomData.Rectangles[103].Vertices[3],
                                    level.Rooms[0].RoomData.Rectangles[103].Vertices[2],
                                    (ushort)level.Rooms[0].RoomData.NumVertices
                                }
                            }
                        },
                        [42] = new List<TRFace3>
                        {
                            new TRFace3
                            {
                                Texture = level.Rooms[1].RoomData.Triangles[10].Texture,
                                Vertices = new ushort[]
                                {
                                    level.Rooms[42].RoomData.Rectangles[59].Vertices[3],
                                    level.Rooms[42].RoomData.Rectangles[41].Vertices[0],
                                    (ushort)(level.Rooms[42].RoomData.NumVertices+3),
                                }
                            }
                        }
                    }
                },
                new EMRemoveTriggerActionFunction
                {
                    Comments = "Remove one of the trapdoor triggers so an escape route is possible beside the cat.",
                    EMType = EMType.RemoveTriggerAction,
                    Locations = new List<EMLocation>
                    {
                        new EMLocation
                        {
                            X = 45568,
                            Y = -8192,
                            Z = 26112,
                            Room = 26
                        }
                    },
                    ActionItem = new EMTriggerAction
                    {
                        Parameter = 55
                    }
                },

            };

            mapping.Any = new List<EMEditorSet>
            {
                new EMEditorSet
                {
                    new EMDrainFunction
                    {
                        Comments = "Drain the Obelisk pool.",
                        EMType = EMType.Drain,
                        Tags = new List<EMTag>
                        {
                            EMTag.WaterChange
                        },
                        RoomNumbers = new int[] {4},
                        WaterTextures = new ushort[]{ 49, 249, 250, 251 }
                    }
                },
                new EMEditorSet
                {
                    new EMFloodFunction
                    {
                        Comments = "Flood room 66.",
                        EMType = EMType.Flood,
                        Tags = new List<EMTag>
                        {
                            EMTag.WaterChange
                        },
                        RoomNumbers = new int[] {66}
                    }
                },
                new EMEditorSet
                {
                    new EMConvertEntityFunction
                    {
                        Comments = "Steal an Obelisk slot and change it into a boulder.",
                        EMType = EMType.ConvertEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EntityIndex = 17,
                        NewEntityType = (short)TREntities.RollingBall
                    },
                    new EMConvertEntityFunction
                    {
                        Comments = "Steal another for bait.",
                        EMType = EMType.ConvertEntity,
                        EntityIndex = 14,
                        NewEntityType = (short)TREntities.LargeMed_S_P
                    },
                    new EMModifyEntityFunction
                    {
                        Comments = "Fix their lighting.",
                        EMType = EMType.ModifyEntity,
                        EntityIndex = 17,
                        Intensity1 = level.Entities[65].Intensity
                    },
                    new EMModifyEntityFunction
                    {
                        EMType = EMType.ModifyEntity,
                        EntityIndex = 14,
                        Intensity1 = level.Entities[37].Intensity
                    },
                    new EMMoveEntityFunction
                    {
                        Comments = "Move them elsewhere.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 17,
                        TargetLocation = new EMLocation
                        {
                            X = 38400,
                            Y = -1024-256,
                            Z = 34304,
                            Room = 32,
                            Angle = 16384
                        }
                    },
                    new EMMoveEntityFunction
                    {
                        EMType = EMType.MoveEntity,
                        EntityIndex = 14,
                        TargetLocation = new EMLocation
                        {
                            X = 38400,
                            Z = 34304,
                            Room = 32
                        }
                    },
                    new EMTriggerFunction
                    {
                        Comments = "Trigger the boulder.",
                        EMType = EMType.Trigger,
                        Locations = new List<EMLocation>
                        {
                            new EMLocation
                            {
                                X = 43520 - 1024,
                                Z = 34304,
                                Room = 32
                            }
                        },
                        Trigger = new EMTrigger
                        {
                            Mask = 31,
                            Actions = new List<EMTriggerAction>
                            {
                                new EMTriggerAction
                                {
                                    Parameter = 17
                                }
                            }
                        }
                    }
                },
                new EMEditorSet
                {
                    new EMConvertEntityFunction
                    {
                        Comments = "Steal an Obelisk slot and change it into spikes.",
                        EMType = EMType.ConvertEntity,
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EntityIndex = 15,
                        NewEntityType = (short)TREntities.TeethSpikes
                    },
                    new EMConvertEntityFunction
                    {
                        Comments = "Steal another.",
                        EMType = EMType.ConvertEntity,
                        EntityIndex = 16,
                        NewEntityType = (short)TREntities.TeethSpikes
                    },
                    new EMMoveEntityFunction
                    {
                        Comments = "Move them elsewhere.",
                        EMType = EMType.MoveEntity,
                        EntityIndex = 15,
                        TargetLocation = new EMLocation
                        {
                            X = 52736,
                            Y = 4096,
                            Z = 41472,
                            Room = 35
                        }
                    },
                    new EMMoveEntityFunction
                    {
                        EMType = EMType.MoveEntity,
                        EntityIndex = 16,
                        TargetLocation = new EMLocation
                        {
                            X = 47616,
                            Y =  4096,
                            Z = 41472,
                            Room = 35
                        }
                    },
                    new EMModifyEntityFunction
                    {
                        Comments = "Fix their lighting.",
                        EMType = EMType.ModifyEntity,
                        EntityIndex = 15,
                        Intensity1 = level.Entities[78].Intensity
                    },
                    new EMModifyEntityFunction
                    {
                        EMType = EMType.ModifyEntity,
                        EntityIndex = 16,
                        Intensity1 = level.Entities[78].Intensity
                    }
                },
                new EMEditorSet
                {
                    new EMAddEntityFunction
                    {
                        Comments = "Add some spikes.",
                        Tags = new List<EMTag>
                        {
                            EMTag.TrapChange
                        },
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.TeethSpikes,
                        Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                        Location = new EMLocation
                        {
                            X = 27136,
                            Y = -512,
                            Z = 20992,
                            Room = 5
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.TeethSpikes,
                        Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                        Location = new EMLocation
                        {
                            X = 27136 + 1024,
                            Y = -512,
                            Z = 20992,
                            Room = 5
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
                        Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                        Location = new EMLocation
                        {
                            X = 40448,
                            Y = -2304,
                            Z = 35328,
                            Room = 28
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.TeethSpikes,
                        Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                        Location = new EMLocation
                        {
                            X = 40448,
                            Y = -2304,
                            Z = 35328-1024,
                            Room = 28
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.TeethSpikes,
                        Intensity = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.TeethSpikes).Intensity,
                        Location = new EMLocation
                        {
                            X = 40448,
                            Y = -2304,
                            Z = 35328-2048,
                            Room = 28
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
                        Comments = "Add some blades.",
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SwingingBlade,
                        Intensity = Array.Find(level2.Entities, e => e.TypeID == (short)TREntities.SwingingBlade).Intensity,
                        Location = new EMLocation
                        {
                            X = 46592,
                            Y = 3840,
                            Z = 41472,
                            Room = 34,
                            Angle= -16384
                        },
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.SwingingBlade,
                        Intensity = Array.Find(level2.Entities, e => e.TypeID == (short)TREntities.SwingingBlade).Intensity,
                        Location = new EMLocation
                        {
                            X = 46592,
                            Y = 3840,
                            Z = 41472-1024,
                            Room = 34,
                            Angle= -16384
                        },
                    },
                    new EMAppendTriggerActionFunction
                    {
                        EMType = EMType.AppendTriggerActionFunction,
                        Location = new EMLocation
                        {
                            X = 49664,
                            Y = 4096,
                            Z = 42496,
                            Room = 65
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
                        Comments = "Ensure the Damocles sword model is available and add some.",
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
                                    [745] = 912, // Top of handle
                                    [746] = 912, // Top of handle
                                    [747] = 909, // Handle
                                    [748] = 912, // Handle edge
                                    [749] = 183   // Blade
                                }
                            }
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DamoclesSword,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.DamoclesSword).Intensity,
                        Flags = 0x100,
                        Location = new EMLocation
                        {
                            X = 39424 - 3072,
                            Y = -4352 - 1280,
                            Z = 46592,
                            Room = 51
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DamoclesSword,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.DamoclesSword).Intensity,
                        Flags = 0x100,
                        Location = new EMLocation
                        {
                            X = 39424 - 4096,
                            Y = -4352 - 1280,
                            Z = 46592 + 2048,
                            Room = 51
                        }
                    },
                    new EMAddEntityFunction
                    {
                        EMType = EMType.AddEntity,
                        TypeID = (short)TREntities.DamoclesSword,
                        Intensity = Array.Find(level4.Entities, e => e.TypeID == (short)TREntities.DamoclesSword).Intensity,
                        Flags = 0x100,
                        Location = new EMLocation
                        {
                            X = 39424 - 2048,
                            Y = -4352 - 1280,
                            Z = 46592 + 2048,
                            Room = 51
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
                                Y = -4352,
                                Z = 45568+0,
                                Room = 51,
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
            };

            mapping.AllWithin = new List<List<EMEditorSet>>
            {
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
                            EntityIndex = 13,
                            Location = new EMLocation
                            {
                                X = 30208,
                                Z = 37376,
                                Room = 12,
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
                            EntityIndex = 13,
                            Location = new EMLocation
                            {
                                X = 30208,
                                Z = 37376 - 1024,
                                Room = 12,
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
                            EntityIndex = 13,
                            Location = new EMLocation
                            {
                                X = 30208,
                                Z = 37376 - 1024,
                                Room = 12,
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
                            EntityIndex = 13,
                            Location = new EMLocation
                            {
                                X = 30208 + 1024,
                                Y = -512,
                                Z = 37376 - 2 * 1024,
                                Room = 12,
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
                            EntityIndex = 13,
                            Location = new EMLocation
                            {
                                X = 30208 + 1024,
                                Y = -512,
                                Z = 37376 - 2 * 1024,
                                Room = 12,
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
                            EntityIndex = 13,
                            Location = new EMLocation
                            {
                                X = 30208 + 1024,
                                Y = -256,
                                Z = 37376 - 1 * 1024,
                                Room = 12,
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
                            EntityIndex = 13,
                            Location = new EMLocation
                            {
                                X = 30208,
                                Y = -4352,
                                Z = 36352,
                                Room = 14,
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
                            EntityIndex = 13,
                            Location = new EMLocation
                            {
                                X = 30208,
                                Y = -4352,
                                Z = 36352,
                                Room = 14,
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
                            EntityIndex = 13,
                            Location = new EMLocation
                            {
                                X = 30208,
                                Y = -4352,
                                Z = 36352,
                                Room = 14,
                                Angle = 16384
                            }
                        },
                    }
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMPlaceholderFunction
                        {
                            Comments = "Don't move pushblock 28.",
                            EMType = EMType.NOOP
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential pushblock relocation.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 28,
                            TargetLocation = new EMLocation
                            {
                                X = 45568 + 1024,
                                Y = -1792,
                                Z = 26112,
                                Room = 18
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential pushblock relocation.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 28,
                            TargetLocation = new EMLocation
                            {
                                X = 45568 - 1024,
                                Y = -1792,
                                Z = 26112,
                                Room = 18
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential pushblock relocation.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 28,
                            TargetLocation = new EMLocation
                            {
                                X = 45568,
                                Y = -1792,
                                Z = 26112 + 1024,
                                Room = 18
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential pushblock relocation.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 28,
                            TargetLocation = new EMLocation
                            {
                                X = 45568 + 1024,
                                Y = -1792,
                                Z = 26112 - 1024,
                                Room = 18
                            }
                        },
                    },
                    new EMEditorSet
                    {
                        new EMMoveEntityFunction
                        {
                            Comments = "Potential pushblock relocation.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 28,
                            TargetLocation = new EMLocation
                            {
                                X = 45568 - 2048,
                                Y = -1792,
                                Z = 26112,
                                Room = 18
                            }
                        },
                    }
                },
                new List<EMEditorSet>
                {
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "Add a set of difficult jumps before the start.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom,
                                EMTag.Hard
                            },
                            Height = 8,
                            Width = 12,
                            Depth = 5,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 43,
                                Wall3 = 247,
                                Wall2 = 127,
                                Wall1 = 202,
                                WallAlignment = Direction.Down,
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
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                                new EMRoomLight
                                {
                                    X = 9 * 1024 + 512,
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 28160,
                                Y = -384,
                                Z = 6656,
                            },
                            Location = new EMLocation
                            {
                                X = 27648 ,
                                Y = -256,
                                Z = 6144-2048
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 6,8 },
                                [-4] = new List<int> { 7 },
                            },
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 12,
                            Depth = 5,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 43,
                                Wall4 = 43,
                                Wall3 = 247,
                                Wall2 = 127,
                                Wall1 = 202,
                                WallAlignment = Direction.Down,
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
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                                new EMRoomLight
                                {
                                    X = 9 * 1024 + 512,
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 28160,
                                Y = -384,
                                Z = 6656,
                            },
                            Location = new EMLocation
                            {
                                X = 27648 ,
                                Y = -256+8*256,
                                Z = 6144-2048
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [-1] = new List<int> {38 },
                                [-5] = new List<int> {51 }
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [4] = new List<int> { 6,8 },
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 12,
                            Depth = 5,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 43,
                                Wall4 = 43,
                                Wall3 = 247,
                                Wall2 = 127,
                                Wall1 = 202,
                                WallAlignment = Direction.Down,
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
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                                new EMRoomLight
                                {
                                    X = 9 * 1024 + 512,
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 28160,
                                Y = -384,
                                Z = 6656,
                            },
                            Location = new EMLocation
                            {
                                X = 27648 ,
                                Y = -256+16*256,
                                Z = 6144-2048
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-4] = new List<int> { 6,8 },
                                [-3] = new List<int> { 53,21 },
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [2] = new List<int> { 18 },
                            }
                        },
                        new EMCreateRoomFunction
                        {
                            EMType = EMType.CreateRoom,
                            Height = 8,
                            Width = 12,
                            Depth = 5,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 43,
                                Wall4 = 43,
                                Wall3 = 247,
                                Wall2 = 127,
                                Wall1 = 202,
                                WallAlignment = Direction.Down,
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
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                                new EMRoomLight
                                {
                                    X = 9 * 1024 + 512,
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 28160,
                                Y = -384,
                                Z = 6656,
                            },
                            Location = new EMLocation
                            {
                                X = 27648 ,
                                Y = -256+24*256,
                                Z = 6144-2048
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 6,8 },
                                [-4] = new List<int> { 53 },
                                [-7] = new List<int> { 51 },
                            },
                            CeilingHeights = new Dictionary<sbyte, List<int>>
                            {
                                [1] = new List<int> { 21,38,53 },
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
                                    BaseRoom = -4,
                                    AdjoiningRoom = 0,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280-1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280-1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 0,
                                    AdjoiningRoom = -4,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280-1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280-1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280,
                                            Z = 3 * 1024
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
                                            X = 2 * 1024,
                                            Y = -256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
                                            Y = -256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
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
                                            Y = -256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
                                            Y = -256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
                                            Y = -256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -256,
                                            Z = 4 * 1024
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
                                            X = 1 * 1024,
                                            Y = -256+8*256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
                                            Y = -256+8*256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
                                            Y = -256+8*256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -256+8*256,
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
                                            Y = -256+8*256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
                                            Y = -256+8*256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
                                            Y = -256+8*256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -256+8*256,
                                            Z = 4 * 1024
                                        }
                                    }
                                },

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
                                            Y = -256+16*256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
                                            Y = -256+16*256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
                                            Y = -256+16*256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -256+16*256,
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
                                            X = 1 * 1024,
                                            Y = -256+16*256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
                                            Y = -256+16*256,
                                            Z = 1 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 11 * 1024,
                                            Y = -256+16*256,
                                            Z = 4 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -256+16*256,
                                            Z = 4 * 1024
                                        }
                                    }
                                },
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Horizontal portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [0] = new Dictionary<short, EMLocation[]>
                                {
                                    [-4] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 29184,
                                            Y = -1280,
                                            Z = 6656,
                                            Room = 0
                                        }
                                    }
                                },
                                [-4] = new Dictionary<short, EMLocation[]>
                                {
                                    [0] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 29184-1024,
                                            Y = -1280,
                                            Z = 6656,
                                            Room = -4
                                        }
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments= "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [627] = new EMGeometryMap
                                {
                                    [-2] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0,10 }
                                    }
                                },
                                [624] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments= "Rotate the trapdoor pad faces.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    FaceIndices = new int[] {0,10},
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -2,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 3,
                                        [1] = 0,
                                        [2] = 1,
                                        [3] = 2
                                    }
                                }
                            },
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 3,
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
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove faces for portals.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-4] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2,5,11,14,20,24,26,30,34,36,40,44,46,50,54,56,60,64,66,70,74,76,80,84,86,90,96,100 }
                                },
                                [-3] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 15,20,22,27,31,33,37,41,43,47,51,53,57,61,63,68,72,75,79,83,85,90,96,98,102,106,112,
                                    0,4,10,14,19,21,26,30,36,40,42,46,50,52,56,60,62,67,71,78,82,84,89,95,97,105,111}
                                },
                                [-2] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] {1,5,11,15,20,22,28,33,40,44,47,52,57,59,63,67,69,73,77,83,87,89,93,97,99,110,115,
                                    4,14,19,21,27,32,35,43,46,51,56,58,62,66,68,72,76,82,86,88,92,96,98,103,109}
                                },
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] {107,89,95,97,78,82,84,67,71,56,60,62,45,50,52,38,41,30,28,23,9,15,17,1,103,2 }
                                },
                                [0] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] {109 }
                                }
                            }
                        },
                        new EMAddStaticMeshFunction
                        {
                            Comments = "Add some static meshes.",
                            EMType = EMType.AddStaticMesh,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 31232,
                                    Y = 5888,
                                    Z = 7680,
                                    Room = -1,
                                    Angle = 16384
                                },
                                new EMLocation
                                {
                                    X = 31232+2048,
                                    Y = 5888,
                                    Z = 7680,
                                    Room = -1,
                                    Angle = 16384
                                },
                                new EMLocation
                                {
                                    X = 35328-1024,
                                    Y = 5888,
                                    Z = 5632,
                                    Room = -1,
                                    Angle = -16384
                                },
                                new EMLocation
                                {
                                    X = 35328+1024,
                                    Y = 5888,
                                    Z = 5632,
                                    Room = -1,
                                    Angle = -16384
                                }
                            },
                            Mesh = new TR2RoomStaticMesh
                            {
                                MeshID = 11,
                                Intensity1 = 6400
                            }
                        },
                        new EMAddStaticMeshFunction
                        {
                            Comments = "Add some static meshes.",
                            EMType = EMType.AddStaticMesh,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 31232+1024,
                                    Y = 5888,
                                    Z = 7680,
                                    Room = -1,
                                    Angle = 0
                                },
                                new EMLocation
                                {
                                    X = 35328,
                                    Y = 5888,
                                    Z = 5632,
                                    Room = -1,
                                    Angle = -32768
                                }
                            },
                            Mesh = new TR2RoomStaticMesh
                            {
                                MeshID = 32,
                                Intensity1 = 6400
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a pickup.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.MagnumAmmo_S_P,
                            Intensity = level.Entities[37].Intensity,
                            Location = new EMLocation
                            {
                                X = 38400,
                                Y = 4864,
                                Z = 7680,
                                Room = -1,
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add trapdoors at the top to exit.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor1,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 36352-1024,
                                Y = -256,
                                Z = 5632,
                                Room = -4,
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 36352-1024,
                                    Y = 5888,
                                    Z = 5632,
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
                            }
                        },
                        new EMAddEntityFunction
                        {
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Trapdoor1,
                            Flags = 0x3E00,
                            Location = new EMLocation
                            {
                                X = 33280-1024,
                                Y = -256-512-256,
                                Z = 5632+2048,
                                Room = -4,
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
                                    X = 33280-1024,
                                    Y = 5888,
                                    Z = 5632+2048,
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
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "A pad for the trapdoors.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 29184,
                                    Y = 2816,
                                    Z = 5632,
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
                                        Parameter = -2,
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
                                    },
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "And an anti-pad for the trapdoors.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 29184,
                                    Y = 2816,
                                    Z = 5632+2048,
                                    Room = -2
                                },
                                new EMLocation
                                {
                                    X = 29184,
                                    Y = -1280,
                                    Z = 6656,
                                    Room = -4
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
                                        Parameter = -2,
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = -1,
                                    },
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Add some music and a camera.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 29184,
                                    Y = 5888,
                                    Z = 6656,
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
                                        Action= FDTrigAction.PlaySoundtrack,
                                        Parameter = 10
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
                                    X = 29184,
                                    Y = 5888,
                                    Z = 6656,
                                    Room = -1
                                }
                            },
                            Camera = new TRCamera
                            {
                                X = 38400,
                                Y = -512-256,
                                Z = 6656,
                                Room = -4
                            },
                            CameraAction = new FDCameraAction
                            {
                                Once = true,
                                MoveTimer = 2
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Lara into the new area.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 29184,
                                Y = 5888,
                                Z = 6656,
                                Room = -1,
                                Angle = 16384
                            }
                        },
                        new EMGenerateLightFunction
                        {
                            Comments = "Generate light.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> {-1,-2,-3,-4 }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "A pad puzzle at the start.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 8,
                            Width = 12,
                            Depth = 5,
                            Textures = new EMTextureGroup
                            {
                                Floor = 83,
                                Ceiling = 83,
                                Wall4 = 43,
                                Wall3 = 247,
                                Wall2 = 127,
                                Wall1 = 202,
                                WallAlignment = Direction.Down,
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
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                                new EMRoomLight
                                {
                                    X = 9 * 1024 + 512,
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 28160,
                                Y = -384,
                                Z = 6656,
                            },
                            Location = new EMLocation
                            {
                                X = 27648 ,
                                Y = -256,
                                Z = 6144-2048
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 6,8,51,53,27,32 },
                                [-4] = new List<int> { 7,52 },
                                [-1] = new List<int> { 17,28,31,37,47 },
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
                                    BaseRoom = -1,
                                    AdjoiningRoom = 0,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280-1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280-1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 0,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280-1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280-1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280,
                                            Z = 3 * 1024
                                        }
                                    }
                                },
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Horizontal portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [0] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 29184,
                                            Y = -1280,
                                            Z = 6656,
                                            Room = 0
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [0] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 29184-1024,
                                            Y = -1280,
                                            Z = 6656,
                                            Room = -1
                                        }
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments= "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [85] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 26,54,60,79,107 }
                                    }
                                },
                                [615] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 120 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments= "Rotate the pad faces.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    FaceIndices = new int[] {26,54,60,79,107},
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 3,
                                        [1] = 0,
                                        [2] = 1,
                                        [3] = 2
                                    }
                                }
                            },
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove faces for portals.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] {2 }
                                },
                                [0] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] {109 }
                                }
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Lara into the new area.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 38400,
                                Y = -1280,
                                Z = 6656,
                                Room = -1,
                                Angle = -16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door1,
                            Intensity= level.Entities[69].Intensity,
                            Location = new EMLocation
                            {
                                X = 29184-1024,
                                Y = -1280,
                                Z = 6656,
                                Room = 0,
                                Angle = -16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments= "Pads for the door.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 37376,
                                    Y = -512,
                                    Z = 6656,
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
                                    X = 35328,
                                    Y = -512,
                                    Z = 6656,
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
                                    X = 34304,
                                    Y = -512,
                                    Z = 5632,
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
                                    X = 33280,
                                    Y = -512,
                                    Z = 7680,
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
                                    X = 31232,
                                    Y = -512,
                                    Z = 6656,
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
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Antipads for the door.",
                            EMType = EMType.Trigger,
                            Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("khamoonantipads3.json"))[Level],
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
                        new EMGenerateLightFunction
                        {
                            Comments = "Generate light.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> {-1, }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "A trickier pad puzzle at the start.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            Height = 8,
                            Width = 12,
                            Depth = 5,
                            Textures = new EMTextureGroup
                            {
                                Floor = 0,
                                Ceiling = 83,
                                Wall4 = 43,
                                Wall3 = 247,
                                Wall2 = 127,
                                Wall1 = 202,
                                WallAlignment = Direction.Down,
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
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                                new EMRoomLight
                                {
                                    X = 9 * 1024 + 512,
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 28160,
                                Y = -384,
                                Z = 6656,
                            },
                            Location = new EMLocation
                            {
                                X = 27648 ,
                                Y = -256,
                                Z = 6144-2048
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 6,8,51,53,26,28,31,33 },
                                [-4] = new List<int> { 7,52 },
                                [-1] = new List<int> { 42,32,27,16,18 }
                            },
                            CeilingHeights= new Dictionary<sbyte, List<int>>
                            {
                                [2] = new List<int> {27,32 }
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
                                    AdjoiningRoom = 0,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280-1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280-1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 0,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280-1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280-1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280,
                                            Z = 3 * 1024
                                        }
                                    }
                                },
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Horizontal portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [0] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 29184,
                                            Y = -1280,
                                            Z = 6656,
                                            Room = 0
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [0] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 29184-1024,
                                            Y = -1280,
                                            Z = 6656,
                                            Room = -1
                                        }
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments= "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [83] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0,109 }
                                    }
                                },
                                [85] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 22,30,52,58,86 }
                                    }
                                },
                                [615] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 112 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments= "Rotate the ceiling hints.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    FaceIndices = new int[] { 22,30,52,58,86 },
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 3,
                                        [1] = 0,
                                        [2] = 1,
                                        [3] = 2
                                    }
                                }
                            },
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove faces for portals.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                },
                                [0] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 109 }
                                }
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Lara into the new area.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 38400,
                                Y = -1280,
                                Z = 6656,
                                Room = -1,
                                Angle = -16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door1,
                            Intensity= level.Entities[69].Intensity,
                            Location = new EMLocation
                            {
                                X = 29184-1024,
                                Y = -1280,
                                Z = 6656,
                                Room = 0,
                                Angle = -16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments= "Pads for the door.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 37376-1024,
                                    Y = -512,
                                    Z = 7680-1024,
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
                                    X = 34304,
                                    Y = -512,
                                    Z = 6656,
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
                                    X = 33280,
                                    Y = -512,
                                    Z = 6656,
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
                                    X = 30208+1024,
                                    Y = -512,
                                    Z = 5632,
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
                                    X = 30208+1024,
                                    Y = -512,
                                    Z = 5632+2048,
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
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Antipads for the door.",
                            EMType = EMType.Trigger,
                            Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("khamoonantipads4.json"))[Level],
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
                        new EMImportNonGraphicsModelFunction
                        {
                            Comments = "Ensure the swinging blade model is available.",
                            EMType = EMType.ImportNonGraphicsModel,
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
                                X = 35328,
                                Y = -256,
                                Z = 6656,
                                Room = -1,
                                Angle= 16384
                            },
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a blade.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.SwingingBlade,
                            Intensity = Array.Find(level2.Entities, e => e.TypeID == (short)TREntities.SwingingBlade).Intensity,
                            Location = new EMLocation
                            {
                                X = 35328-3072,
                                Y = -256,
                                Z = 6656,
                                Room = -1,
                                Angle= -16384
                            },
                        },
                        new EMTriggerFunction
                        {
                            Comments= "Trigger the blades.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 38400,
                                    Y = -1280,
                                    Z = 6656,
                                    Room = -1,
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
                            Comments = "Generate light.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> {-1, }
                        }
                    },
                    new EMEditorSet
                    {
                        new EMCreateRoomFunction
                        {
                            Comments = "A more difficult pad puzzle at the start.",
                            EMType = EMType.CreateRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom,
                                EMTag.Hard
                            },
                            Height = 8,
                            Width = 12,
                            Depth = 5,
                            Textures = new EMTextureGroup
                            {
                                Floor = 0,
                                Ceiling = 83,
                                Wall4 = 43,
                                Wall3 = 247,
                                Wall2 = 127,
                                Wall1 = 202,
                                WallAlignment = Direction.Down,
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
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                                new EMRoomLight
                                {
                                    X = 9 * 1024 + 512,
                                    Y = -1024,
                                    Z = 2 * 1024 + 512,
                                    Intensity1 = 2048,
                                    Fade1 = 4096,
                                },
                            },
                            LinkedLocation = new EMLocation
                            {
                                X = 28160,
                                Y = -384,
                                Z = 6656,
                            },
                            Location = new EMLocation
                            {
                                X = 27648 ,
                                Y = -256,
                                Z = 6144-2048
                            },
                            FloorHeights= new Dictionary<sbyte, List<int>>
                            {
                                [-127] = new List<int> { 6,8,51,53,26,28,31,33 },
                                [-4] = new List<int> { 7,52 },
                            },
                            CeilingHeights= new Dictionary<sbyte, List<int>>
                            {
                                [3] = new List<int> {27,32 }
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
                                    AdjoiningRoom = 0,
                                    Normal = new TRVertex
                                    {
                                        X = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280-1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280-1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -1280,
                                            Z = 2 * 1024
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 0,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        X = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280-1024,
                                            Z = 3 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280-1024,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280,
                                            Z = 2 * 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -1280,
                                            Z = 3 * 1024
                                        }
                                    }
                                },
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            Comments = "Horizontal portals.",
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [0] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 29184,
                                            Y = -1280,
                                            Z = 6656,
                                            Room = 0
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [0] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 29184-1024,
                                            Y = -1280,
                                            Z = 6656,
                                            Room = -1
                                        }
                                    }
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments= "Change some textures.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [83] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0,97 }
                                    }
                                },
                                [85] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 92,58,46,31,15 }
                                    }
                                },
                                [615] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 100 }
                                    }
                                }
                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments= "Rotate the ceiling hints.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    FaceIndices = new int[] {92,58,46,31,15},
                                    FaceType = EMTextureFaceType.Rectangles,
                                    RoomNumber = -1,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 3,
                                        [1] = 0,
                                        [2] = 1,
                                        [3] = 2
                                    }
                                }
                            },
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove faces for portals.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [-1] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] {2 }
                                },
                                [0] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] {109 }
                                }
                            }
                        },
                        new EMMoveEntityFunction
                        {
                            Comments = "Move Lara into the new area.",
                            EMType = EMType.MoveEntity,
                            EntityIndex = 0,
                            TargetLocation = new EMLocation
                            {
                                X = 38400,
                                Y = -1280,
                                Z = 6656,
                                Room = -1,
                                Angle = -16384
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a door.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door1,
                            Intensity= level.Entities[69].Intensity,
                            Location = new EMLocation
                            {
                                X = 29184-1024,
                                Y = -1280,
                                Z = 6656,
                                Room = 0,
                                Angle = -16384
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments= "Pads for the door.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 37376,
                                    Y = -256,
                                    Z = 7680,
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
                                    X = 35328,
                                    Y = -256,
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
                                    X = 33280,
                                    Y = -256,
                                    Z = 6656,
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
                                    X = 32256,
                                    Y = -256,
                                    Z = 5632,
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
                                    X = 30208,
                                    Y = -256,
                                    Z = 7680,
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
                                        Parameter = -1
                                    }
                                }
                            }
                        },
                        new EMKillLaraFunction
                        {
                            Comments = "Death tiles elsewhere.",
                            EMType = EMType.KillLara,
                            Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("khamoondeathtiles.json"))[Level],
                        },
                        new EMImportNonGraphicsModelFunction
                        {
                            Comments = "Ensure the swinging blade model is available.",
                            EMType = EMType.ImportNonGraphicsModel,
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
                                X = 35328,
                                Y = -256,
                                Z = 6656,
                                Room = -1,
                                Angle= 16384
                            },
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a blade.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.SwingingBlade,
                            Intensity = Array.Find(level2.Entities, e => e.TypeID == (short)TREntities.SwingingBlade).Intensity,
                            Location = new EMLocation
                            {
                                X = 35328-3072,
                                Y = -256,
                                Z = 6656,
                                Room = -1,
                                Angle= -16384
                            },
                        },
                        new EMTriggerFunction
                        {
                            Comments= "Trigger the blades.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 38400,
                                    Y = -1280,
                                    Z = 6656,
                                    Room = -1,
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
                            Comments = "Generate light.",
                            EMType = EMType.GenerateLight,
                            RoomIndices = new List<short> {-1, }
                        }
                    }
                }
            };

            foreach (EMLocation loc in JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("khamoonportals-4.json"))[Level])
            {
                mapping.AllWithin[2][0].Insert(4, new EMVerticalCollisionalPortalFunction
                {
                    EMType = EMType.VerticalCollisionalPortal,
                    Comments = "Vertical portal.",
                    Ceiling = loc,
                    Floor = new EMLocation
                    {
                        X = loc.X,
                        Y = loc.Y + 1024,
                        Z = loc.Z,
                        Room = (short)(loc.Room + 1)
                    }
                });
            }
            foreach (EMLocation loc in JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("khamoonportals-3.json"))[Level])
            {
                mapping.AllWithin[2][0].Insert(4, new EMVerticalCollisionalPortalFunction
                {
                    EMType = EMType.VerticalCollisionalPortal,
                    Comments = "Vertical portal.",
                    Ceiling = loc,
                    Floor = new EMLocation
                    {
                        X = loc.X,
                        Y = loc.Y + 1024,
                        Z = loc.Z,
                        Room = (short)(loc.Room + 1)
                    }
                });
            }
            foreach (EMLocation loc in JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("khamoonportals-2.json"))[Level])
            {
                mapping.AllWithin[2][0].Insert(4, new EMVerticalCollisionalPortalFunction
                {
                    EMType = EMType.VerticalCollisionalPortal,
                    Comments = "Vertical portal.",
                    Ceiling = loc,
                    Floor = new EMLocation
                    {
                        X = loc.X,
                        Y = loc.Y + 1024,
                        Z = loc.Z,
                        Room = (short)(loc.Room + 1)
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
                            Comments = "Remove the default lever texture in room 16.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[16].RoomData.Rectangles[7].Texture] = new EMGeometryMap
                                {
                                    [16] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 16 }
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
                                EntityIndex = 25,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = 3328,
                                    Z = 28160,
                                    Room = 16,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [16] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 25,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = 3328,
                                    Z = 28160,
                                    Room = 16,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [16] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 6 }
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
                                EntityIndex = 25,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = 3328,
                                    Z = 28160,
                                    Room = 16,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[16].RoomData.Rectangles[16].Texture] = new EMGeometryMap
                                    {
                                        [16] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 16 }
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
                            Comments = "Remove the default lever texture in room 17.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[17].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                {
                                    [17] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 7 }
                                    }
                                },

                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Modify the faces to match the rest of the room.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 17,
                                    FaceIndex = 6,
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
                                    RoomNumber = 17,
                                    FaceIndex = 7,
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
                                EntityIndex = 27,
                                Location = new EMLocation
                                {
                                    X = 22016,
                                    Y = 1280,
                                    Z = 15872,
                                    Room = 17
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[17].RoomData.Rectangles[7].Texture] = new EMGeometryMap
                                    {
                                        [17] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 10 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Vertex tweaks for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 17,
                                        FaceIndex = 9,
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
                                        RoomNumber = 17,
                                        FaceIndex = 10,
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
                                EntityIndex = 27,
                                Location = new EMLocation
                                {
                                    X = 22016 + 1024,
                                    Y = 1280,
                                    Z = 15872,
                                    Room = 17
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[17].RoomData.Rectangles[7].Texture] = new EMGeometryMap
                                    {
                                        [17] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 19 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Vertex tweaks for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 17,
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
                                        RoomNumber = 17,
                                        FaceIndex = 19,
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
                                EntityIndex = 27,
                                Location = new EMLocation
                                {
                                    X = 22016 + 1024,
                                    Y = 1280,
                                    Z = 15872,
                                    Room = 17,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[17].RoomData.Rectangles[7].Texture] = new EMGeometryMap
                                    {
                                        [17] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 27,
                                Location = new EMLocation
                                {
                                    X = 22016 + 2048,
                                    Y = 1280,
                                    Z = 15872,
                                    Room = 17
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[17].RoomData.Rectangles[7].Texture] = new EMGeometryMap
                                    {
                                        [17] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 27 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Vertex tweaks for above.",
                                EMType = EMType.ModifyFace,
                                Modifications = new EMFaceModification[]
                                {
                                    new EMFaceModification
                                    {
                                        RoomNumber = 17,
                                        FaceIndex = 26,
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
                                        RoomNumber = 17,
                                        FaceIndex = 27,
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
                                EntityIndex = 27,
                                Location = new EMLocation
                                {
                                    X = 27136,
                                    Y = 2304,
                                    Z = 14848,
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
                                    [level.Rooms[17].RoomData.Rectangles[7].Texture] = new EMGeometryMap
                                    {
                                        [3] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 34 }
                                        },
                                    }
                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMConvertEntityFunction
                            {
                                Comments = "Switch the switch into something else.",
                                EMType = EMType.ConvertEntity,
                                EntityIndex = 27,
                                NewEntityType = (short)TREntities.LargeMed_S_P
                            },
                            new EMRemoveTriggerFunction
                            {
                                Comments = "Remove the switch trigger.",
                                EMType = EMType.RemoveTrigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 22016,
                                        Y = 1280,
                                        Z = 15872,
                                        Room = 17
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Make some pads to open the door instead.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 26112,
                                        Y = 2304,
                                        Z = 17920,
                                        Room = 3
                                    },
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 3,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 2
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
                                        X = 28160,
                                        Y = 2304,
                                        Z = 17920,
                                        Room = 3
                                    },
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 2,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 2
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
                                        X = 27136,
                                        Y = 2304,
                                        Z = 18944,
                                        Room = 3
                                    },
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 3,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 2
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
                                        X = 27136,
                                        Y = 2304,
                                        Z = 16896,
                                        Room = 3
                                    },
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 4,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 2
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Antipads for above.",
                                EMType = EMType.Trigger,
                                Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("khamoonantipads1.json"))[TRLevelNames.KHAMOON],
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    TrigType = FDTrigType.Antipad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 2
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
                                    [617] = new EMGeometryMap
                                    {
                                        [3] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 20,32,39,29 }
                                        }
                                    },

                                }
                            },
                        },
                        new EMEditorSet
                        {
                            new EMConvertEntityFunction
                            {
                                Comments = "Switch the switch into something else.",
                                EMType = EMType.ConvertEntity,
                                EntityIndex = 27,
                                NewEntityType = (short)TREntities.ShotgunAmmo_S_P
                            },
                            new EMRemoveTriggerFunction
                            {
                                Comments = "Remove the switch trigger.",
                                EMType = EMType.RemoveTrigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 22016,
                                        Y = 1280,
                                        Z = 15872,
                                        Room = 17
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Make some pads to open the door instead.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 25088,
                                        Y = 2304,
                                        Z = 16896,
                                        Room = 3
                                    },
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 7,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 2
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
                                        X = 26112,
                                        Y = 2304,
                                        Z = 18944,
                                        Room = 3
                                    },
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 3,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 2
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
                                        X = 28160,
                                        Y = 2304,
                                        Z = 16896,
                                        Room = 3
                                    },
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 4,
                                    TrigType = FDTrigType.Pad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 2
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Antipads for above.",
                                EMType = EMType.Trigger,
                                Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("khamoonantipads2.json"))[TRLevelNames.KHAMOON],
                                Trigger = new EMTrigger
                                {
                                    Mask = 31,
                                    TrigType = FDTrigType.Antipad,
                                    Actions = new List<EMTriggerAction>
                                    {
                                        new EMTriggerAction
                                        {
                                            Parameter = 2
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
                                    [617] = new EMGeometryMap
                                    {
                                        [3] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 7,21,36 }
                                        }
                                    },

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
                            Comments = "Remove the default lever texture in room 23.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[23].RoomData.Rectangles[9].Texture] = new EMGeometryMap
                                {
                                    [23] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 10 }
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
                                EntityIndex = 31,
                                Location = new EMLocation
                                {
                                    X = 43520,
                                    Y = -6400,
                                    Z = 22016,
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
                                    [level.Rooms[23].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [23] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 9 }
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
                                EntityIndex = 31,
                                Location = new EMLocation
                                {
                                    X = 43520,
                                    Y = -6400,
                                    Z = 22016 - 1024,
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
                                    [level.Rooms[23].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [23] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 5 }
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
                                EntityIndex = 31,
                                Location = new EMLocation
                                {
                                    X = 43520,
                                    Y = -6400,
                                    Z = 22016 - 1024,
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
                                    [level.Rooms[23].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [23] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 12 }
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
                                EntityIndex = 31,
                                Location = new EMLocation
                                {
                                    X = 43520,
                                    Y = -6400,
                                    Z = 22016,
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
                                    [level.Rooms[23].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                    {
                                        [23] = new Dictionary<EMTextureFaceType, int[]>
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
                                Comments = "Potential (sneaky) lever relocation.",
                                EMType = EMType.MoveSlot,
                                EntityIndex = 31,
                                Location = new EMLocation
                                {
                                    X = 44544,
                                    Y = -4096,
                                    Z = 19968,
                                    Room = 22,
                                    Angle = -16384
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
                            Comments = "Remove the default lever texture in room 25.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[25].RoomData.Rectangles[30].Texture] = new EMGeometryMap
                                {
                                    [25] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 40 }
                                    }
                                },

                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Rotate the face to match the rest of the room.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    FaceIndices = new int[] { 40 },
                                    RoomNumber = 25,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 1,
                                        [1] = 2,
                                        [2] = 3,
                                        [3] = 0,
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
                                EntityIndex = 32,
                                Location = new EMLocation
                                {
                                    X = 44544 - 1024,
                                    Y = -4096,
                                    Z = 33280,
                                    Room = 25,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[25].RoomData.Rectangles[40].Texture] = new EMGeometryMap
                                    {
                                        [25] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 30 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the original lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceIndices = new int[] { 30 },
                                        RoomNumber = 25,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 3,
                                            [1] = 0,
                                            [2] = 1,
                                            [3] = 2,
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
                                EntityIndex = 32,
                                Location = new EMLocation
                                {
                                    X = 44544 - 1024,
                                    Y = -4096,
                                    Z = 33280 + 2048,
                                    Room = 25
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[25].RoomData.Rectangles[40].Texture] = new EMGeometryMap
                                    {
                                        [25] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 35 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the original lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceIndices = new int[] { 35 },
                                        RoomNumber = 25,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 3,
                                            [1] = 0,
                                            [2] = 1,
                                            [3] = 2,
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
                                EntityIndex = 32,
                                Location = new EMLocation
                                {
                                    X = 44544 - 2048,
                                    Y = -4096,
                                    Z = 33280 + 2048,
                                    Room = 25
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[25].RoomData.Rectangles[40].Texture] = new EMGeometryMap
                                    {
                                        [25] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 25 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the original lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceIndices = new int[] { 25 },
                                        RoomNumber = 25,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 3,
                                            [1] = 0,
                                            [2] = 1,
                                            [3] = 2,
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
                            Comments = "Remove the default lever texture in room 25.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[36].RoomData.Rectangles[10].Texture] = new EMGeometryMap
                                {
                                    [36] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 6 }
                                    }
                                },

                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Rotate the face to match the rest of the room.",
                            EMType = EMType.ModifyFace,
                            Rotations = new EMFaceRotation[]
                            {
                                new EMFaceRotation
                                {
                                    FaceIndices = new int[] { 6 },
                                    RoomNumber = 36,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexRemap = new Dictionary<int, int>
                                    {
                                        [0] = 3,
                                        [1] = 0,
                                        [2] = 1,
                                        [3] = 2,
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
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 48640 + 1024,
                                    Y = 768,
                                    Z = 28160,
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
                                    [level.Rooms[36].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 10 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the original lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceIndices = new int[] { 10 },
                                        RoomNumber = 36,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 1,
                                            [1] = 2,
                                            [2] = 3,
                                            [3] = 0,
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
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 48640 + 2048,
                                    Y = 768,
                                    Z = 28160,
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
                                    [level.Rooms[36].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 14 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the original lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceIndices = new int[] { 14 },
                                        RoomNumber = 36,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 1,
                                            [1] = 2,
                                            [2] = 3,
                                            [3] = 0,
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
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 48640 + 2048,
                                    Y = 768,
                                    Z = 28160,
                                    Room = 36
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[36].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 15 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the original lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceIndices = new int[] { 15 },
                                        RoomNumber = 36,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 1,
                                            [1] = 2,
                                            [2] = 3,
                                            [3] = 0,
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
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 48640 + 1024,
                                    Y = 768,
                                    Z = 28160,
                                    Room = 36
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[36].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 11 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the original lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceIndices = new int[] { 11 },
                                        RoomNumber = 36,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 1,
                                            [1] = 2,
                                            [2] = 3,
                                            [3] = 0,
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
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 48640,
                                    Y = 768,
                                    Z = 28160,
                                    Room = 36
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[36].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 7 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the original lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceIndices = new int[] { 7 },
                                        RoomNumber = 36,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 1,
                                            [1] = 2,
                                            [2] = 3,
                                            [3] = 0,
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
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 48640 - 1024,
                                    Y = 768,
                                    Z = 28160,
                                    Room = 36
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[36].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 3 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the original lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceIndices = new int[] { 3 },
                                        RoomNumber = 36,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 1,
                                            [1] = 2,
                                            [2] = 3,
                                            [3] = 0,
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
                                EntityIndex = 45,
                                Location = new EMLocation
                                {
                                    X = 48640 - 1024,
                                    Y = 768,
                                    Z = 28160,
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
                                    [level.Rooms[36].RoomData.Rectangles[6].Texture] = new EMGeometryMap
                                    {
                                        [36] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 2 }
                                        },
                                    }
                                }
                            },
                            new EMModifyFaceFunction
                            {
                                Comments = "Rotate the face to match the original lever.",
                                EMType = EMType.ModifyFace,
                                Rotations = new EMFaceRotation[]
                                {
                                    new EMFaceRotation
                                    {
                                        FaceIndices = new int[] { 2 },
                                        RoomNumber = 36,
                                        FaceType = EMTextureFaceType.Rectangles,
                                        VertexRemap = new Dictionary<int, int>
                                        {
                                            [0] = 1,
                                            [1] = 2,
                                            [2] = 3,
                                            [3] = 0,
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
                        new EMAddFaceFunction
                        {
                            Comments = "Add fake doors to room 12 so we can repurpose the actual entities.",
                            EMType = EMType.AddFace,
                            Tags = new List<EMTag>
                            {
                                EMTag.TrapChange
                            },
                            Quads = new Dictionary<short, List<TRFace4>>
                            {
                                [12] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 620,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[12].RoomData.Rectangles[12].Vertices[1],
                                            level.Rooms[12].RoomData.Rectangles[12].Vertices[0],
                                            level.Rooms[12].RoomData.Rectangles[11].Vertices[2],
                                            level.Rooms[12].RoomData.Rectangles[11].Vertices[1],
                                        }
                                    },
                                    new TRFace4
                                    {
                                        Texture = 624,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[12].RoomData.Rectangles[16].Vertices[1],
                                            level.Rooms[12].RoomData.Rectangles[16].Vertices[0],
                                            level.Rooms[12].RoomData.Rectangles[15].Vertices[1],
                                            level.Rooms[12].RoomData.Rectangles[15].Vertices[0],
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
                            new EMImportNonGraphicsModelFunction
                            {
                                Comments = "Import the clang-clang model.",
                                EMType = EMType.ImportNonGraphicsModel,
                                Data = new List<EMMeshTextureData>
                                {
                                    new EMMeshTextureData
                                    {
                                        ModelID = (short)TREntities.SlammingDoor,
                                        TexturedFace3 = 183,
                                        TexturedFace4 = 114
                                    }
                                }
                            },
                            new EMConvertEntityFunction
                            {
                                Comments = "Change the doors into clang-clang doors and set them up elsewhere.",
                                EMType = EMType.ConvertEntity,
                                EntityIndex = 18,
                                NewEntityType = (short)TREntities.SlammingDoor,
                            },
                            new EMConvertEntityFunction
                            {
                                EMType = EMType.ConvertEntity,
                                EntityIndex = 19,
                                NewEntityType = (short)TREntities.SlammingDoor,
                            },
                            new EMMoveEntityFunction
                            {
                                EMType = EMType.MoveEntity,
                                EntityIndex = 18,
                                TargetLocation= new EMLocation
                                {
                                    X = 38400,
                                    Y = -1792,
                                    Z = 44544,
                                    Room = 56,
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
                                        X = 38400,
                                        Y = -1792,
                                        Z = 44544,
                                        Room = 56,
                                    },
                                    new EMLocation
                                    {
                                        X = 38400,
                                        Y = -1792,
                                        Z = 44544 - 1024,
                                        Room = 56,
                                    }
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
                                            Parameter = 18
                                        }
                                    }
                                }
                            },
                            new EMMoveEntityFunction
                            {
                                EMType = EMType.MoveEntity,
                                EntityIndex = 19,
                                TargetLocation= new EMLocation
                                {
                                    X = 48640,
                                    Y = 1024,
                                    Z = 41472 + 1024,
                                    Room = 50,
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
                                        X = 48640,
                                        Y = 1024,
                                        Z = 41472+1024,
                                        Room = 50,
                                    },
                                    new EMLocation
                                    {
                                        X = 48640,
                                        Y = 1024,
                                        Z = 41472 ,
                                        Room = 50,
                                    }
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
                                            Parameter = 19
                                        }
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMImportNonGraphicsModelFunction
                            {
                                Comments = "Import the clang-clang model.",
                                EMType = EMType.ImportNonGraphicsModel,
                                Data = new List<EMMeshTextureData>
                                {
                                    new EMMeshTextureData
                                    {
                                        ModelID = (short)TREntities.SlammingDoor,
                                        TexturedFace3 = 183,
                                        TexturedFace4 = 114
                                    }
                                }
                            },
                            new EMConvertEntityFunction
                            {
                                Comments = "Change the doors into clang-clang doors and set them up elsewhere.",
                                EMType = EMType.ConvertEntity,
                                EntityIndex = 18,
                                NewEntityType = (short)TREntities.SlammingDoor,
                            },
                            new EMConvertEntityFunction
                            {
                                EMType = EMType.ConvertEntity,
                                EntityIndex = 19,
                                NewEntityType = (short)TREntities.SlammingDoor,
                            },
                            new EMMoveEntityFunction
                            {
                                EMType = EMType.MoveEntity,
                                EntityIndex = 18,
                                TargetLocation= new EMLocation
                                {
                                    X = 31232,
                                    Z = 40448,
                                    Room = 47
                                }
                            },
                            new EMMoveEntityFunction
                            {
                                EMType = EMType.MoveEntity,
                                EntityIndex = 19,
                                TargetLocation= new EMLocation
                                {
                                    X = 31232,
                                    Z = 40448 + 1024,
                                    Room = 47
                                }
                            },
                            new EMTriggerFunction
                            {
                                EMType = EMType.Trigger,
                                ExpandedLocations = new EMLocationExpander
                                {
                                    Location = new EMLocation
                                    {
                                        X = 31232,
                                        Z = 40448,
                                        Room = 47
                                    },
                                    ExpandX = 1,
                                    ExpandZ = 3
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
                                            Parameter = 18
                                        },
                                        new EMTriggerAction
                                        {
                                            Parameter = 19
                                        }
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            new EMImportNonGraphicsModelFunction
                            {
                                Comments = "Import the clang-clang model.",
                                EMType = EMType.ImportNonGraphicsModel,
                                Data = new List<EMMeshTextureData>
                                {
                                    new EMMeshTextureData
                                    {
                                        ModelID = (short)TREntities.SlammingDoor,
                                        TexturedFace3 = 183,
                                        TexturedFace4 = 114
                                    }
                                }
                            },
                            new EMConvertEntityFunction
                            {
                                Comments = "Change one of the doors into clang-clang doors and the other into bait.",
                                EMType = EMType.ConvertEntity,
                                EntityIndex = 18,
                                NewEntityType = (short)TREntities.SlammingDoor,
                            },
                            new EMConvertEntityFunction
                            {
                                EMType = EMType.ConvertEntity,
                                EntityIndex = 19,
                                NewEntityType = (short)TREntities.LargeMed_S_P,
                            },
                            new EMMoveEntityFunction
                            {
                                EMType = EMType.MoveEntity,
                                EntityIndex = 18,
                                TargetLocation= new EMLocation
                                {
                                    X = 23040,
                                    Y = 3328,
                                    Z = 15872,
                                    Room = 11,
                                    Angle = -16384
                                }
                            },
                            new EMMoveEntityFunction
                            {
                                EMType = EMType.MoveEntity,
                                EntityIndex = 19,
                                TargetLocation= new EMLocation
                                {
                                    X = 22016,
                                    Y = 3328,
                                    Z = 15872,
                                    Room = 11
                                }
                            },
                            new EMTriggerFunction
                            {
                                EMType = EMType.Trigger,
                                ExpandedLocations = new EMLocationExpander
                                {
                                    Location = new EMLocation
                                    {
                                        X = 23040-1024,
                                        Y = 3328,
                                        Z = 15872,
                                        Room = 11,
                                    },
                                    ExpandX = 2,
                                    ExpandZ = 1
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
                                            Parameter = 18
                                        }
                                    }
                                }
                            }
                        },
                    }
                }
            };

            mapping.ConditionalAll = new List<EMConditionalSingleEditorSet>
            {
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMSectorContainsSecretCondition
                    {
                        Comments = "If there is a secret in this crevice, create an additional panther trigger.",
                        ConditionType = EMConditionType.SectorContainsSecret,
                        Location = new EMLocation
                        {
                            X = 25088,
                            Y = -1280,
                            Z = 19968,
                            Room = 5
                        }
                    },
                    OnTrue = new EMEditorSet
                    {
                        new EMRemoveTriggerActionFunction
                        {
                            Comments = "Remove the panther action from the secret trigger.",
                            EMType = EMType.RemoveTriggerAction,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088,
                                    Y = -1280,
                                    Z = 19968,
                                    Room = 5
                                }
                            },
                            ActionItem = new EMTriggerAction
                            {
                                Parameter = 5
                            }
                        },
                        new EMDuplicateTriggerFunction
                        {
                            Comments = "Duplicate the standard trigger onto the slope below.",
                            EMType = EMType.DuplicateTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = 25088+1024,
                                Y = -1280,
                                Z = 19968,
                                Room = 5
                            },
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 25088,
                                    Y = -128,
                                    Z = 18944,
                                    Room = 2
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

            mapping.RewardEntities = new List<int> { 47, 48, 51, 84 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 49664,
                            Y = 4096,
                            Z = 34304
                        },
                        new Location
                        {
                            X = 49664,
                            Y = 4096,
                            Z = 35328
                        },
                        new Location
                        {
                            X = 49664,
                            Y = 4096,
                            Z = 36352
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door1,
                            X = 49664,
                            Y = 4096,
                            Z = 41472,
                            Intensity = 6400,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 49784,
                            Y = 3248,
                            Z = 44483,
                            Room = 65
                        }
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 47,
                            LinkedLocation = new EMLocation
                            {
                                X = 49664,
                                Y = 4096,
                                Z = 41472,
                                Room = 35
                            },
                            NewLocation = new EMLocation
                            {
                                X = 48128,
                                Y = 4096,
                                Z = 32768,
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [35] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 49664,
                                            Y = 4096,
                                            Z = 40448,
                                            Room = 35
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [35] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 49664,
                                            Y = 4096,
                                            Z = 41472,
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
                                    BaseRoom = 35,
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
                                            Y = 3072,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 3072,
                                            Y = 3072,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 3072,
                                            Y = 4096,
                                            Z = 2048
                                        },
                                        new TRVertex
                                        {
                                            X = 4096,
                                            Y = 4096,
                                            Z = 2048
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 35,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 3072,
                                            Z = 8192
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = 3072,
                                            Z = 8192
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = 4096,
                                            Z = 8192
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = 4096,
                                            Z = 8192
                                        }
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
                                        Texture = 221,
                                        Vertices = new ushort[]
                                        {
                                            10, 11, 0, 8
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
                                    RoomNumber = 35,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndex = 15,
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
                                    FaceIndices = new int[]{ 0, 3, 6, 9, 12, 15, 18 },
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
                                    RoomNumber = 35,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    FaceIndices = new int[]{ 13 },
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
                                [114] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0, 3, 6, 9, 12, 15, 18 }
                                    }
                                },
                                [123] = new EMGeometryMap
                                {
                                    [35] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 13 }
                                    }
                                },
                                [221] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 20 }
                                    }
                                },
                                [225] = new EMGeometryMap
                                {
                                    [35] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 15 }
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

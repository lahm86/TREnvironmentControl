using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TREnvironmentEditor;
using TREnvironmentEditor.Helpers;
using TREnvironmentEditor.Model;
using TREnvironmentEditor.Model.Conditions;
using TREnvironmentEditor.Model.Types;
using TRFDControl;
using TRLevelReader.Helpers;
using TRLevelReader.Model;
using TRLevelReader.Model.Enums;
using TRRandomizerCore.Helpers;
using TRRandomizerCore.Secrets;

namespace TREnvironmentControl
{
    public class TR1CisternControl : BaseTR1Control
    {
        public override string Level => TRLevelNames.CISTERN;

        public override void GenerateEnvironmentMapping()
        {
            EMEditorMapping mapping = GetMapping();
            TRLevel level = GetTR1Level(Level);

            mapping.Any = new List<EMEditorSet>
            {
            };

            mapping.NonPurist = new EMEditorSet
            {
                new EMAddEntityFunction
                {
                    Comments = "Add a pushblock to allow returning to the start.",
                    EMType = EMType.AddEntity,
                    TypeID = (short)TREntities.PushBlock1,
                    Intensity = level.Entities[7].Intensity,
                    Location = new EMLocation
                    {
                        X = 46592-2048,
                        Y = -3328,
                        Z = 70144,
                        Room = 7
                    }
                }
            };

            mapping.AllWithin = new List<List<EMEditorSet>>
            {
                // Keyhole1
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 40448 + 1 * 1024,
                                Y = -8448,
                                Z = 36352,
                                Room = 15,
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 40448 + 2 * 1024,
                                Y = -8448,
                                Z = 36352,
                                Room = 15,
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 40448 + 2 * 1024,
                                Y = -8448,
                                Z = 36352,
                                Room = 15,
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 40448 + 2 * 1024,
                                Y = -8448,
                                Z = 36352,
                                Room = 15
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 40448 - 1 * 1024,
                                Y = -8448,
                                Z = 36352,
                                Room = 15,
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 40448 - 2 * 1024,
                                Y = -8448,
                                Z = 36352,
                                Room = 15,
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 40448 - 2 * 1024,
                                Y = -8448,
                                Z = 36352,
                                Room = 15,
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 40448 - 2 * 1024,
                                Y = -8448,
                                Z = 36352,
                                Room = 15
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 41472,
                                Y = -5888,
                                Z = 37376,
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 41472,
                                Y = -5888,
                                Z = 37376,
                                Room = 14,
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 41472 - 2048,
                                Y = -5888,
                                Z = 37376,
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
                            EntityIndex = 20,
                            Location = new EMLocation
                            {
                                X = 41472 - 2048,
                                Y = -5888,
                                Z = 37376,
                                Room = 14,
                                Angle = -16384
                            }
                        },
                    },
                },
                // Keyhole2A
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
                            EntityIndex = 17,
                            Location = new EMLocation
                            {
                                X = 40448,
                                Y = -5632,
                                Z = 47616,
                                Room = 13,
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
                            EntityIndex = 17,
                            Location = new EMLocation
                            {
                                X = 40448 + 1024,
                                Y = -5632,
                                Z = 47616 + 1024,
                                Room = 84,
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
                            EntityIndex = 17,
                            Location = new EMLocation
                            {
                                X = 40448 + 2 * 1024,
                                Y = -5632 + 256,
                                Z = 47616 + 2 * 1024,
                                Room = 84,
                                Angle = 16384
                            }
                        },
                    },
                },
                // Keyhole2B
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
                            EntityIndex = 18,
                            Location = new EMLocation
                            {
                                X = 40448,
                                Y = -5632,
                                Z = 45568,
                                Room = 13,
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
                            EntityIndex = 18,
                            Location = new EMLocation
                            {
                                X = 40448 - 1 * 1024,
                                Y = -5632,
                                Z = 45568 + 3 * 1024,
                                Room = 8,
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
                            EntityIndex = 18,
                            Location = new EMLocation
                            {
                                X = 40448 - 1 * 1024,
                                Y = -5632,
                                Z = 45568 + 3 * 1024,
                                Room = 8,
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
                            EntityIndex = 18,
                            Location = new EMLocation
                            {
                                X = 40448 - 2 * 1024,
                                Y = -5632 + 256,
                                Z = 45568 + 4 * 1024,
                                Room = 8,
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
                            EntityIndex = 18,
                            Location = new EMLocation
                            {
                                X = 40448 - 2 * 1024,
                                Y = -5632 + 256,
                                Z = 45568 + 4 * 1024,
                                Room = 8,
                                Angle = -16384
                            }
                        },
                    },
                }
            };

            mapping.ConditionalAllWithin = new List<EMConditionalEditorSet>
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
                            Comments = "Remove the default lever texture in room 4.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[4].RoomData.Rectangles[8].Texture] = new EMGeometryMap
                                {
                                    [4] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 13 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 2 * 1024,
                                    Y = -6656,
                                    Z = 71168 + 1024,
                                    Room = 4
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 51 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 3 * 1024,
                                    Y = -6656,
                                    Z = 71168 + 1024,
                                    Room = 4
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 66 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 4 * 1024,
                                    Y = -6656,
                                    Z = 71168 + 1024,
                                    Room = 4
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 80 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 4 * 1024,
                                    Y = -6656 + 1024,
                                    Z = 71168 + 1024,
                                    Room = 4,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 89 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 4 * 1024,
                                    Y = -6656 + 1024,
                                    Z = 71168,
                                    Room = 4,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 86 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 4 * 1024,
                                    Y = -6656 + 1024,
                                    Z = 71168 - 1024,
                                    Room = 4,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 4 * 1024,
                                    Y = -6656 + 1024,
                                    Z = 71168 - 2 * 1024,
                                    Room = 4,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 81 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 4 * 1024,
                                    Y = -6656 + 1024,
                                    Z = 71168 - 2 * 1024,
                                    Room = 4,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 69 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 2 * 1024,
                                    Y = -6656 + 1024,
                                    Z = 71168 - 2 * 1024,
                                    Room = 4,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 39 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 1 * 1024,
                                    Y = -6656 + 1024,
                                    Z = 71168 - 2 * 1024,
                                    Room = 4,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 25 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 2 * 1024,
                                    Y = -6656,
                                    Z = 71168 - 2 * 1024,
                                    Room = 4,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 41 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 1 * 1024,
                                    Y = -6656,
                                    Z = 71168 - 2 * 1024,
                                    Room = 4,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [4] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 27 }
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
                                EntityIndex = 5,
                                Location = new EMLocation
                                {
                                    X = 45568 + 1 * 1024,
                                    Y = -6656,
                                    Z = 71168 + 3 * 1024,
                                    Room = 5,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[4].RoomData.Rectangles[13].Texture] = new EMGeometryMap
                                    {
                                        [5] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 21 }
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
                            Comments = "Remove the default lever texture in room 9.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[9].RoomData.Rectangles[1].Texture] = new EMGeometryMap
                                {
                                    [9] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 5 }
                                    }
                                },

                            }
                        },
                        new EMModifyFaceFunction
                        {
                            Comments = "Move the face to fit the rest of the room.",
                            EMType = EMType.ModifyFace,
                            Modifications = new EMFaceModification[]
                            {
                                new EMFaceModification
                                {
                                    RoomNumber = 9,
                                    FaceIndex = 5,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -256,
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -256,
                                        },
                                    }
                                }
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [9] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 4 }
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
                                EntityIndex = 11,
                                Location = new EMLocation
                                {
                                    X = 23040,
                                    Y = -6656,
                                    Z = 55808 - 1024,
                                    Room = 9,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[9].RoomData.Rectangles[5].Texture] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 1 }
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
                                EntityIndex = 11,
                                Location = new EMLocation
                                {
                                    X = 23040,
                                    Y = -6656,
                                    Z = 55808 - 1024,
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
                                    [level.Rooms[9].RoomData.Rectangles[5].Texture] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 11,
                                Location = new EMLocation
                                {
                                    X = 23040 + 1024,
                                    Y = -6656,
                                    Z = 55808 - 1024,
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
                                    [level.Rooms[9].RoomData.Rectangles[5].Texture] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 19 }
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
                                EntityIndex = 11,
                                Location = new EMLocation
                                {
                                    X = 23040 + 1024,
                                    Y = -6656,
                                    Z = 55808,
                                    Room = 9,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[9].RoomData.Rectangles[5].Texture] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 34 }
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
                                EntityIndex = 11,
                                Location = new EMLocation
                                {
                                    X = 23040 + 3 * 1024,
                                    Y = -6656,
                                    Z = 55808 - 1024,
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
                                    [level.Rooms[9].RoomData.Rectangles[5].Texture] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 49 }
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
                                EntityIndex = 11,
                                Location = new EMLocation
                                {
                                    X = 23040 + 4 * 1024,
                                    Y = -6656,
                                    Z = 55808 - 1024,
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
                                    [level.Rooms[9].RoomData.Rectangles[5].Texture] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 63 }
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
                                EntityIndex = 11,
                                Location = new EMLocation
                                {
                                    X = 23040 + 4 * 1024,
                                    Y = -6656,
                                    Z = 55808 - 1024,
                                    Room = 9,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[9].RoomData.Rectangles[5].Texture] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 73 }
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
                                EntityIndex = 11,
                                Location = new EMLocation
                                {
                                    X = 23040 + 5 * 1024,
                                    Y = -6656,
                                    Z = 55808,
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
                                    [level.Rooms[9].RoomData.Rectangles[5].Texture] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 75 }
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
                                EntityIndex = 11,
                                Location = new EMLocation
                                {
                                    X = 23040 + 5 * 1024,
                                    Y = -6656,
                                    Z = 55808 + 1024,
                                    Room = 9,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[9].RoomData.Rectangles[5].Texture] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 85 }
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
                                EntityIndex = 11,
                                Location = new EMLocation
                                {
                                    X = 23040 + 5 * 1024,
                                    Y = -6656,
                                    Z = 55808 + 2 * 1024,
                                    Room = 9,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[9].RoomData.Rectangles[5].Texture] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 86 }
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
                                EntityIndex = 11,
                                Location = new EMLocation
                                {
                                    X = 23040 + 5 * 1024,
                                    Y = -6656,
                                    Z = 55808 + 3 * 1024,
                                    Room = 9,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[9].RoomData.Rectangles[5].Texture] = new EMGeometryMap
                                    {
                                        [9] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 87 }
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
                            Comments = "Remove the default lever texture in room 30.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[30].RoomData.Rectangles[18].Texture] = new EMGeometryMap
                                {
                                    [30] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 57856 + 1 * 1024,
                                    Y = -4608 - 1024 - 256,
                                    Z = 48640 + 2 * 1024,
                                    Room = 29,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[30].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [29] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 16 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 57856 + 1 * 1024,
                                    Y = -4608 - 1024 - 256,
                                    Z = 48640 - 1 * 1024,
                                    Room = 29,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[30].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [29] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 57856 + 1 * 1024,
                                    Y = -4608 - 1024 - 256,
                                    Z = 48640 - 1 * 1024,
                                    Room = 29,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[30].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [29] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 5 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 57856 + 1 * 1024,
                                    Y = -4608 + 1024,
                                    Z = 48640 + 4 * 1024,
                                    Room = 31,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[30].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [31] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 7 }
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 57856 + 1 * 1024,
                                    Y = -4608 + 1024,
                                    Z = 48640 + 5 * 1024,
                                    Room = 31,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[30].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [31] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 35,
                                Location = new EMLocation
                                {
                                    X = 59904,
                                    Y = -1280,
                                    Z = 59904,
                                    Room = 34,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[30].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                    {
                                        [34] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 6 }
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
                            Comments = "Remove the default lever texture in room 42.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[42].RoomData.Rectangles[2].Texture] = new EMGeometryMap
                                {
                                    [42] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 51,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = -5632,
                                    Z = 37376,
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
                                    [level.Rooms[42].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 51,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = -5632,
                                    Z = 37376 + 1024,
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
                                    [level.Rooms[42].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 51,
                                Location = new EMLocation
                                {
                                    X = 53760,
                                    Y = -5632,
                                    Z = 37376 + 1024,
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
                                    [level.Rooms[42].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 8 }
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
                                    X = 53760,
                                    Y = -5632,
                                    Z = 37376,
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
                                    [level.Rooms[42].RoomData.Rectangles[3].Texture] = new EMGeometryMap
                                    {
                                        [42] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 7 }
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
                            Comments = "Remove the default lever texture in room 60.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[60].RoomData.Rectangles[32].Texture] = new EMGeometryMap
                                {
                                    [60] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 35 }
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
                                EntityIndex = 68,
                                Location = new EMLocation
                                {
                                    X = 39424 - 1024,
                                    Y = -6400,
                                    Z = 24064 - 1024,
                                    Room = 60,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[60].RoomData.Rectangles[35].Texture] = new EMGeometryMap
                                    {
                                        [60] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 68,
                                Location = new EMLocation
                                {
                                    X = 39424 + 1024,
                                    Y = -6400,
                                    Z = 24064,
                                    Room = 60,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[60].RoomData.Rectangles[35].Texture] = new EMGeometryMap
                                    {
                                        [60] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 41 }
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
                                EntityIndex = 68,
                                Location = new EMLocation
                                {
                                    X = 39424 + 2 * 1024,
                                    Y = -6400,
                                    Z = 24064 - 1 * 1024,
                                    Room = 60,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[60].RoomData.Rectangles[35].Texture] = new EMGeometryMap
                                    {
                                        [60] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 45 }
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
                                EntityIndex = 68,
                                Location = new EMLocation
                                {
                                    X = 39424 - 3 * 1024,
                                    Y = -6400,
                                    Z = 24064 - 0 * 1024,
                                    Room = 60
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[60].RoomData.Rectangles[35].Texture] = new EMGeometryMap
                                    {
                                        [60] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 68,
                                Location = new EMLocation
                                {
                                    X = 39424 - 5 * 1024,
                                    Y = -6400,
                                    Z = 24064 - 0 * 1024,
                                    Room = 60
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[60].RoomData.Rectangles[35].Texture] = new EMGeometryMap
                                    {
                                        [60] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 68,
                                Location = new EMLocation
                                {
                                    X = 39424 - 5 * 1024,
                                    Y = -6400,
                                    Z = 24064 - 0 * 1024,
                                    Room = 60,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[60].RoomData.Rectangles[35].Texture] = new EMGeometryMap
                                    {
                                        [60] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 5 }
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
                                EntityIndex = 68,
                                Location = new EMLocation
                                {
                                    X = 39424 - 5 * 1024,
                                    Y = -6400,
                                    Z = 24064 - 2 * 1024,
                                    Room = 60,
                                    Angle = -16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[60].RoomData.Rectangles[35].Texture] = new EMGeometryMap
                                    {
                                        [60] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 1 }
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
                            Comments = "Remove the default lever texture in room 66.",
                            EMType = EMType.Reface,
                            Tags = new List<EMTag>
                            {
                                EMTag.SlotChange
                            },
                            TextureMap = new EMTextureMap
                            {
                                [level.Rooms[66].RoomData.Rectangles[94].Texture] = new EMGeometryMap
                                {
                                    [66] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 92 }
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
                                EntityIndex = 90,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = -6400,
                                    Z = 19968 + 1024,
                                    Room = 66,
                                    Angle = 16384
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[66].RoomData.Rectangles[92].Texture] = new EMGeometryMap
                                    {
                                        [66] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 94 }
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
                                EntityIndex = 90,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = -6400,
                                    Z = 19968 + 1024,
                                    Room = 66
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[66].RoomData.Rectangles[92].Texture] = new EMGeometryMap
                                    {
                                        [66] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 77 }
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
                                EntityIndex = 90,
                                Location = new EMLocation
                                {
                                    X = 33280,
                                    Y = -6400,
                                    Z = 19968,
                                    Room = 66,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[66].RoomData.Rectangles[92].Texture] = new EMGeometryMap
                                    {
                                        [66] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 71 }
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
                                EntityIndex = 90,
                                Location = new EMLocation
                                {
                                    X = 33280 - 1 * 1024,
                                    Y = -6400,
                                    Z = 19968,
                                    Room = 66,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[66].RoomData.Rectangles[92].Texture] = new EMGeometryMap
                                    {
                                        [66] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 55 }
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
                                EntityIndex = 90,
                                Location = new EMLocation
                                {
                                    X = 33280 - 2 * 1024,
                                    Y = -6400,
                                    Z = 19968,
                                    Room = 66,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[66].RoomData.Rectangles[92].Texture] = new EMGeometryMap
                                    {
                                        [66] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 44 }
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
                                EntityIndex = 90,
                                Location = new EMLocation
                                {
                                    X = 33280 - 3 * 1024,
                                    Y = -6400,
                                    Z = 19968,
                                    Room = 66,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[66].RoomData.Rectangles[92].Texture] = new EMGeometryMap
                                    {
                                        [66] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 90,
                                Location = new EMLocation
                                {
                                    X = 33280 - 4 * 1024,
                                    Y = -6400,
                                    Z = 19968,
                                    Room = 66,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[66].RoomData.Rectangles[92].Texture] = new EMGeometryMap
                                    {
                                        [66] = new Dictionary<EMTextureFaceType, int[]>
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
                                EntityIndex = 90,
                                Location = new EMLocation
                                {
                                    X = 33280 - 5 * 1024,
                                    Y = -6400,
                                    Z = 19968,
                                    Room = 66,
                                    Angle = -32768
                                }
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Refacing for above.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [level.Rooms[66].RoomData.Rectangles[92].Texture] = new EMGeometryMap
                                    {
                                        [66] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 4 }
                                        }
                                    }
                                }
                            },
                        },
                    }
                },

                // End-room puzzle
                new EMEditorGroupedSet
                {
                    Leader = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            Comments = "Make a copy of room 14.",
                            EMType = EMType.CopyRoom,
                            Tags = new List<EMTag>
                            {
                                EMTag.PuzzleRoom
                            },
                            RoomIndex = 14,
                            LinkedLocation = new EMLocation
                            {
                                X = 42496,
                                Y = -6400,
                                Z = 22016,
                                Room = 60
                            },
                            NewLocation = new EMLocation
                            {
                                X = 41984 - 5 * 1024,
                                Y = -6400 + 1024 + 768,
                                Z = 21504 - 8 * 1024
                            },
                            FloorHeights = new Dictionary<sbyte, List<int>>
                            {
                                [0] = new List<int> { 13,49 }
                            }
                        },
                        new EMClickFunction
                        {
                            Comments = "Adjust some sectors.",
                            EMType = EMType.Click,
                            CeilingClicks = -3,
                            Location = new EMLocation
                            {
                                X = 42496,
                                Y = -5632,
                                Z = 20992,
                                Room = -1
                            }
                        },
                        new EMClickFunction
                        {
                            EMType = EMType.Click,
                            CeilingClicks = 1,
                            Location = new EMLocation
                            {
                                X = 38400,
                                Y = -6400,
                                Z = 17920,
                                Room = -1
                            }
                        },
                        new EMClickFunction
                        {
                            EMType = EMType.Click,
                            FloorClicks = 0,
                            CeilingClicks = 1,
                            Location = new EMLocation
                            {
                                X = 39424,
                                Y = -6400,
                                Z = 17920,
                                Room = -1
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
                                    FaceIndex = 117,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = -768,
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -768,
                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = -768,
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -768,
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndices = new int[]{ 13,120},
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
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
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndices = new int[]{12, 121 },
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
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 13,
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
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 11,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = -1024,
                                            Y = -768,
                                            Z = 1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = -768
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = 1024,
                                            Y = -768,
                                            Z = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -768
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 44,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1024,
                                            Z = -1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = 1024,
                                            Y = -1024,
                                            Z = -1024
                                        },
                                        [2] = new TRVertex
                                        {

                                            Y = -1024 - 7*256,
                                            Z = -1024
                                        },
                                        [3] = new TRVertex
                                        {
                                            Y = -1024 - 7*256,
                                            Z = -1024
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 19,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = 3*1024,
                                            Y = -1024,
                                            Z = -1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = 3*1024,
                                            Y = -1024,
                                            Z = -1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = 3*1024,
                                            Y = -1024 - 7*256,
                                            Z = -2048
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = 3*1024,
                                            Y = -1024 - 7*256,
                                            Z = -2048
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 104,
                                    FaceType = EMTextureFaceType.Rectangles,
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
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = 1024,
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 105,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            X = 1024,
                                            Y = -768-512
                                        },
                                        [3] = new TRVertex
                                        {
                                            X = 1024,
                                            Y = -768-512
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 111,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 1024+256,
                                            Z = -1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            Y = 1024+256,
                                            Z = -1024
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 113,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [1] = new TRVertex
                                        {
                                            X = 1024,
                                            Z = -1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = 1024,
                                            Y = -512,
                                            Z = -1024
                                        },
                                        [3] =  new TRVertex
                                        {
                                            Y = -512,
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 108,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = 1024,
                                            Y = 768,
                                            Z = 1024
                                        },
                                        [1] = new TRVertex
                                        {

                                            Y = 768,

                                        },
                                        [2] = new TRVertex
                                        {
                                            Y = 256
                                        },
                                        [3] =  new TRVertex
                                        {
                                            X = 1024,
                                            Z = 1024,
                                            Y = 256
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 106,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = -4*1024,
                                            Y = 1280,
                                            Z = 1024
                                        },
                                        [1] = new TRVertex
                                        {
                                            X = -4*1024,
                                            Y = 1280,
                                            Z = 1024
                                        },
                                        [2] = new TRVertex
                                        {
                                            X = -4*1024,
                                        },
                                        [3] =  new TRVertex
                                        {
                                            X = -4*1024,
                                        },
                                    }
                                },


                                new EMFaceModification
                                {
                                    RoomNumber = 69,
                                    FaceIndex = 4,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [2] = new TRVertex
                                        {
                                            Y = -256,
                                        },
                                        [3] =  new TRVertex
                                        {
                                            Y = -256,
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = 69,
                                    FaceIndex = 5,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            Y = 768,
                                        },
                                        [1] =  new TRVertex
                                        {
                                            Y = 768,
                                        },
                                    }
                                },
                                new EMFaceModification
                                {
                                    RoomNumber = -1,
                                    FaceIndex = 62,
                                    FaceType = EMTextureFaceType.Rectangles,
                                    VertexChanges = new Dictionary<int, TRVertex>
                                    {
                                        [0] = new TRVertex
                                        {
                                            X = -1024,
                                            Z = -1024
                                        },
                                        [3] =  new TRVertex
                                        {
                                            X = -1024,
                                            Z = -1024
                                        },
                                    }
                                },
                            }
                        },
                        new EMAddFaceFunction
                        {
                            Comments = "Add new faces to patch gaps.",
                            EMType = EMType.AddFace,
                            Quads = new Dictionary<short, List<TRFace4>>
                            {
                                [60] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 53,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[60].RoomData.Rectangles[38].Vertices[3],
                                            level.Rooms[60].RoomData.Rectangles[38].Vertices[2],
                                            level.Rooms[60].RoomData.Rectangles[39].Vertices[3],
                                            level.Rooms[60].RoomData.Rectangles[39].Vertices[2],
                                        }
                                    }
                                },
                                [69] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 53,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[69].RoomData.Rectangles[7].Vertices[0],
                                            level.Rooms[69].RoomData.Rectangles[4].Vertices[1],
                                            level.Rooms[69].RoomData.Rectangles[4].Vertices[0],
                                            level.Rooms[69].RoomData.Rectangles[7].Vertices[1],
                                        }
                                    }
                                },
                                [-1] = new List<TRFace4>
                                {
                                    new TRFace4
                                    {
                                        Texture = 104,
                                        Vertices = new ushort[] { 169,172,158,159 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[10].Texture,
                                        Vertices = new ushort[] { 5,7,182,181 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[100].Texture,
                                        Vertices = new ushort[]
                                        {
                                            level.Rooms[14].RoomData.Rectangles[55].Vertices[3],
                                            level.Rooms[14].RoomData.Rectangles[55].Vertices[2],
                                            level.Rooms[14].RoomData.Rectangles[53].Vertices[1],
                                            level.Rooms[14].RoomData.Rectangles[53].Vertices[0],
                                        }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[62].Texture,
                                        Vertices = new ushort[] { 28,214,215,177 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[62].Texture,
                                        Vertices = new ushort[] { 66,34,186,88 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[62].Texture,
                                        Vertices = new ushort[] { 34,33,183,186 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[61].Texture,
                                        Vertices = new ushort[] { 143,113,194,141 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[61].Texture,
                                        Vertices = new ushort[] { 84,64,187,193 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[61].Texture,
                                        Vertices = new ushort[] { 87,88,186,185 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[61].Texture,
                                        Vertices = new ushort[] { 190,189,28,25 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[61].Texture,
                                        Vertices = new ushort[] { 141,194,110,140 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[61].Texture,
                                        Vertices = new ushort[] { 194,193,81,110 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[61].Texture,
                                        Vertices = new ushort[] { 193,187,61,81 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[61].Texture,
                                        Vertices = new ushort[] { 187,190,23,61 }
                                    },
                                    new TRFace4
                                    {
                                        Texture = level.Rooms[14].RoomData.Rectangles[61].Texture,
                                        Vertices = new ushort[] { 190,25,24,23 }
                                    },
                                }
                            }
                        },
                        new EMRefaceFunction
                        {
                            Comments = "Retexture some faces.",
                            EMType = EMType.Reface,
                            TextureMap = new EMTextureMap
                            {
                                [150] = new EMGeometryMap
                                {
                                    [69] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[]{ 5 }
                                    }
                                },
                                [level.Rooms[14].RoomData.Rectangles[61].Texture] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[]{ 20,106,82,103,111, 11, 143, 61, 83, 105,44,19,89,15 }
                                    }
                                },
                                [level.Rooms[14].RoomData.Rectangles[12].Texture] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[]{ 113,108 }
                                    }
                                }
                            }
                        },
                        new EMCopyVertexAttributesFunction
                        {
                            Comments = "Normalize vertex lighting",
                            EMType = EMType.CopyVertexAttributes,
                            RoomMap = new Dictionary<short, TR3RoomVertex>
                            {
                                [-1] = new TR3RoomVertex
                                {
                                    Lighting = level.Rooms[14].RoomData.Vertices[level.Rooms[14].RoomData.Rectangles[36].Vertices[0]].Lighting
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
                                    BaseRoom = -1,
                                    AdjoiningRoom = 69,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -5632,
                                            Z = 8 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -5632,
                                            Z = 8 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 4 * 1024,
                                            Y = -4608,
                                            Z = 8 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 3 * 1024,
                                            Y = -4608,
                                            Z = 8 * 1024,
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 69,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -5632,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -5632,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 1 * 1024,
                                            Y = -4608,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 2 * 1024,
                                            Y = -4608,
                                            Z = 1 * 1024,
                                        }
                                    }
                                },

                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 60,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -7424,
                                            Z = 8 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = -7424,
                                            Z = 8 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 6 * 1024,
                                            Y = -6400,
                                            Z = 8 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 5 * 1024,
                                            Y = -6400,
                                            Z = 8 * 1024,
                                        }
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = 60,
                                    AdjoiningRoom = -1,
                                    Normal = new TRVertex
                                    {
                                        Z = 1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 10 * 1024,
                                            Y = -7424,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 9 * 1024,
                                            Y = -7424,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 9 * 1024,
                                            Y = -6400,
                                            Z = 1 * 1024,
                                        },
                                        new TRVertex
                                        {
                                            X = 10 * 1024,
                                            Y = -6400,
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
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [69] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 40448,
                                            Y = -4608,
                                            Z = 20992 + 1024
                                        }
                                    },
                                    [60] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 42496,
                                            Y = -5632,
                                            Z = 20992 + 1024
                                        }
                                    }
                                },
                                [69] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 40448,
                                            Y = -4608,
                                            Z = 20992
                                        }
                                    }
                                },
                                [60] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 42496,
                                            Y = -6400,
                                            Z = 20992
                                        }
                                    }
                                },
                            }
                        },
                        new EMRemoveCollisionalPortalFunction
                        {
                            Comments = "Remove the old portal to the level end.",
                            EMType = EMType.RemoveCollisionalPortal,
                            Location1 = new EMLocation
                            {
                                X = 39424 + 1024,
                                Y = -6400 - 256,
                                Z = 22016,
                                Room = 60
                            },
                            Location2 = new EMLocation
                            {
                                X = 39424 + 1024,
                                Y = -6400 + 256,
                                Z = 22016,
                                Room = 69
                            }
                        },
                        new EMRemoveFaceFunction
                        {
                            Comments = "Remove a face to make way for the new room.",
                            EMType = EMType.RemoveFace,
                            GeometryMap = new EMGeometryMap
                            {
                                [60] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[]{ 51}
                                }
                            }
                        },
                        new EMAddStaticMeshFunction
                        {
                            Comments = "Add a gargoyle",
                            EMType = EMType.AddStaticMesh,
                            Mesh = new TR2RoomStaticMesh
                            {
                                MeshID = 30,
                                Intensity1 = level.Rooms[109].StaticMeshes.ToList().Find(m => m.MeshID == 30).Intensity
                            },
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 40448,
                                    Y = -4864,
                                    Z = 14848,
                                    Room = -1
                                }
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a push block in front of the new room.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.PushBlock1,
                            Intensity = level.Entities[69].Intensity,
                            Location = new EMLocation
                            {
                                X = 39424 + 3*1024,
                                Y = -6400,
                                Z = 22016,
                                Room = 60
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a medi in the new room.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.LargeMed_S_P,
                            Intensity = level.Entities[110].Intensity,
                            Location = new EMLocation
                            {
                                X = 38400,
                                Y = -5632,
                                Z = 20992,
                                Room = -1
                            }
                        },
                        new EMAddEntityFunction
                        {
                            Comments = "Add a door blocking the path to the exit.",
                            EMType = EMType.AddEntity,
                            TypeID = (short)TREntities.Door1,
                            Intensity = level.Entities[86].Intensity,
                            Location = new EMLocation
                            {
                                X = 40448,
                                Y = -4608,
                                Z = 20992,
                                Room = -1,
                                Angle = -32768
                            }
                        },
                        new EMTriggerFunction
                        {
                            Comments = "Some music for the puzzle.",
                            EMType = EMType.Trigger,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = 42496,
                                    Y = -5632,
                                    Z = 20992,
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
                                        Action = FDTrigAction.PlaySoundtrack,
                                        Parameter = 9
                                    }
                                }
                            }
                        }
                    },
                    Followers = new List<EMEditorSet>
                    {
                        new EMEditorSet
                        {
                            new EMModifyEntityFunction
                            {
                                Comments = "Pierre forgot to reset the puzzle and left the door open.",
                                EMType = EMType.ModifyEntity,
                                EntityIndex = -1,
                                Flags = 31 << 9
                            },
                            new EMConvertEntityFunction
                            {
                                Comments = "Convert the medi into something else.",
                                EMType = EMType.ConvertEntity,
                                EntityIndex = -2,
                                NewEntityType = (short)TREntities.UziAmmo_S_P
                            }
                        },
                        new EMEditorSet
                        {
                            // Puzzle 1
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 40448,
                                        Y = -4608,
                                        Z = 19968,
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
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 42496,
                                        Y = -4608,
                                        Z = 18944,
                                        Room = -1
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 1,
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
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 38400,
                                        Y = -4608,
                                        Z = 17920,
                                        Room = -1
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
                                            Parameter = -1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 39424,
                                        Y = -4608,
                                        Z = 16896,
                                        Room = -1
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
                                            Parameter = -1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 42496,
                                        Y = -4608,
                                        Z = 15872,
                                        Room = -1
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
                                            Parameter = -1
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
                                    Comments = "Puzzle antipads in hard mode.",
                                    EMType = EMType.Trigger,
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
                                    },
                                    Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("cisternpuzzleantipads1.json"))[TRLevelNames.CISTERN]
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Texture hints.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [780] = new EMGeometryMap
                                    {
                                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 68,110,11,44,145 }
                                        }
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            // Puzzle 2
                            new EMConvertEntityFunction
                            {
                                Comments = "Convert the medi into something else.",
                                EMType = EMType.ConvertEntity,
                                EntityIndex = -2,
                                NewEntityType = (short)TREntities.SmallMed_S_P
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 40448,
                                        Y = -4608,
                                        Z = 19968,
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
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 39424,
                                        Y = -4608,
                                        Z = 18944,
                                        Room = -1
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 1,
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
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 41472,
                                        Y = -4608,
                                        Z = 17920,
                                        Room = -1
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
                                            Parameter = -1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 40448,
                                        Y = -4608,
                                        Z = 16896,
                                        Room = -1
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
                                            Parameter = -1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 38400,
                                        Y = -4608,
                                        Z = 16896,
                                        Room = -1
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
                                            Parameter = -1
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
                                    Comments = "Puzzle antipads in hard mode.",
                                    EMType = EMType.Trigger,
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
                                    },
                                    Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("cisternpuzzleantipads2.json"))[TRLevelNames.CISTERN]
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Texture hints.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [780] = new EMGeometryMap
                                    {
                                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 68,46,83,142,144 }
                                        }
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            // Puzzle 3
                            new EMConvertEntityFunction
                            {
                                Comments = "Convert the medi into something else.",
                                EMType = EMType.ConvertEntity,
                                EntityIndex = -2,
                                NewEntityType = (short)TREntities.ShotgunAmmo_S_P
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 38400,
                                        Y = -4608,
                                        Z = 15872,
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
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 42496,
                                        Y = -4608,
                                        Z = 15872,
                                        Room = -1
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 1,
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
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 40448,
                                        Y = -4608,
                                        Z = 17920,
                                        Room = -1
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
                                            Parameter = -1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 40448,
                                        Y = -4608,
                                        Z = 18944,
                                        Room = -1
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
                                            Parameter = -1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 42496,
                                        Y = -4608,
                                        Z = 19968,
                                        Room = -1
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
                                            Parameter = -1
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
                                    Comments = "Puzzle antipads in hard mode.",
                                    EMType = EMType.Trigger,
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
                                    },
                                    Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("cisternpuzzleantipads3.json"))[TRLevelNames.CISTERN]
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Texture hints.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [780] = new EMGeometryMap
                                    {
                                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 145,149,61,65,115 }
                                        }
                                    }
                                }
                            }
                        },
                        new EMEditorSet
                        {
                            // Puzzle 4
                            new EMConvertEntityFunction
                            {
                                Comments = "Convert the medi into something else.",
                                EMType = EMType.ConvertEntity,
                                EntityIndex = -2,
                                NewEntityType = (short)TREntities.MagnumAmmo_S_P
                            },
                            new EMMoveEntityFunction
                            {
                                Comments = "Move it beside the gargoyle.",
                                EMType = EMType.MoveEntity,
                                EntityIndex = -2,
                                TargetLocation = new EMLocation
                                {
                                    X = 41472,
                                    Y = -4864,
                                    Z = 14848,
                                    Room = -1
                                }
                            },
                            new EMAddStaticMeshFunction
                            {
                                Comments = "Add a plant pot in the alcove.",
                                EMType = EMType.AddStaticMesh,
                                Mesh = new TR2RoomStaticMesh
                                {
                                    MeshID = 38,
                                    Intensity1 = level.Rooms[84].StaticMeshes.ToList().Find(m => m.MeshID == 38).Intensity
                                },
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 38400,
                                        Y = -5632,
                                        Z = 20992,
                                        Room = -1,
                                        Angle = -32768
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 40448,
                                        Y = -4608,
                                        Z = 19968,
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
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 38400,
                                        Y = -4608,
                                        Z = 19968,
                                        Room = -1
                                    }
                                },
                                Trigger = new EMTrigger
                                {
                                    Mask = 1 << 1,
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
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 38400,
                                        Y = -4608,
                                        Z = 16896,
                                        Room = -1
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
                                            Parameter = -1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 42496,
                                        Y = -4608,
                                        Z = 17920,
                                        Room = -1
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
                                            Parameter = -1
                                        }
                                    }
                                }
                            },
                            new EMTriggerFunction
                            {
                                Comments = "Pads to open the door.",
                                EMType = EMType.Trigger,
                                Locations = new List<EMLocation>
                                {
                                    new EMLocation
                                    {
                                        X = 41472,
                                        Y = -4608,
                                        Z = 16896,
                                        Room = -1
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
                                            Parameter = -1
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
                                    Comments = "Puzzle antipads in hard mode.",
                                    EMType = EMType.Trigger,
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
                                    },
                                    Locations = JsonConvert.DeserializeObject<Dictionary<string, List<EMLocation>>>(GetResource("cisternpuzzleantipads4.json"))[TRLevelNames.CISTERN]
                                },
                            },
                            new EMRefaceFunction
                            {
                                Comments = "Texture hints.",
                                EMType = EMType.Reface,
                                TextureMap = new EMTextureMap
                                {
                                    [780] = new EMGeometryMap
                                    {
                                        [-1] = new Dictionary<EMTextureFaceType, int[]>
                                        {
                                            [EMTextureFaceType.Rectangles] = new int[] { 20, 67, 111, 80, 7,  }
                                        }
                                    },
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
                        Comments = "Check if key item #46 is in its default position. If not, move the trigger to its new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 46,
                        X = level.Entities[46].X,
                        Y = level.Entities[46].Y,
                        Z = level.Entities[46].Z,
                        Room = level.Entities[46].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = level.Entities[46].X,
                                Y = level.Entities[46].Y,
                                Z = level.Entities[46].Z,
                                Room = level.Entities[46].Room
                            },
                            EntityLocation = 46
                        },
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #61 is in its default position. If not, move the trigger to its new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 61,
                        X = level.Entities[61].X,
                        Y = level.Entities[61].Y,
                        Z = level.Entities[61].Z,
                        Room = level.Entities[61].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMMoveTriggerFunction
                        {
                            EMType = EMType.MoveTrigger,
                            BaseLocation = new EMLocation
                            {
                                X = level.Entities[61].X,
                                Y = level.Entities[61].Y,
                                Z = level.Entities[61].Z,
                                Room = level.Entities[61].Room
                            },
                            EntityLocation = 61
                        },
                    }
                },
                new EMConditionalSingleEditorSet
                {
                    Condition = new EMEntityPropertyCondition
                    {
                        Comments = "Check if key item #67 is in its default position. If not, move the trigger (from flipmap) to its new location.",
                        ConditionType = EMConditionType.EntityProperty,
                        EntityIndex = 67,
                        X = level.Entities[67].X,
                        Y = level.Entities[67].Y,
                        Z = level.Entities[67].Z,
                        Room = level.Entities[67].Room
                    },
                    OnFalse = new EMEditorSet
                    {
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            EntityLocation = 67,
                            Trigger = new EMTrigger
                            {
                                Mask = 31,
                                TrigType = FDTrigType.Pickup,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 67
                                    },
                                    new EMTriggerAction
                                    {
                                        Parameter = 65
                                    }
                                }
                            }
                        },
                        new EMTriggerFunction
                        {
                            EMType = EMType.Trigger,
                            Replace = true,
                            Locations = new List<EMLocation>
                            {
                                new EMLocation
                                {
                                    X = level.Entities[67].X,
                                    Y = level.Entities[67].Y,
                                    Z = level.Entities[67].Z,
                                    Room = 56
                                },
                                new EMLocation
                                {
                                    X = level.Entities[67].X,
                                    Y = level.Entities[67].Y,
                                    Z = level.Entities[67].Z,
                                    Room = 72
                                }
                            },
                            Trigger= new EMTrigger
                            {
                                Mask = 31,
                                Actions = new List<EMTriggerAction>
                                {
                                    new EMTriggerAction
                                    {
                                        Parameter = 104
                                    }
                                }
                            }
                        }
                    }
                },
            };

            WriteMapping(mapping);
        }

        public override void GenerateSecretRoomMapping()
        {
            TRSecretMapping<TREntity> mapping = GetSecretRoomMapping();

            mapping.RewardEntities = new List<int> { 92, 93, 94, 95, 97, 98, 99 };
            mapping.Rooms = new List<TRSecretRoom<TREntity>>
            {
                new TRSecretRoom<TREntity>
                {
                    RewardPositions = new List<Location>
                    {
                        new Location
                        {
                            X = 40448,
                            Y = -7680,
                            Z = 17920
                        },
                        new Location
                        {
                            X = 40448,
                            Y = -7680,
                            Z = 18944
                        },
                        new Location
                        {
                            X = 40448,
                            Y = -7680,
                            Z = 19968
                        }
                    },
                    Doors = new List<TREntity>
                    {
                        new TREntity
                        {
                            TypeID = (short)TREntities.Door2,
                            X = 40448,
                            Y = -7680,
                            Z = 22016,
                            Intensity = 6400,
                            Room = -1
                        }
                    },
                    Cameras = new List<TRCamera>
                    {
                        new TRCamera
                        {
                            X = 40348,
                            Y = -8121,
                            Z = 32651,
                            Room = 61
                        }
                    },
                    Room = new EMEditorSet
                    {
                        new EMCopyRoomFunction
                        {
                            EMType = EMType.CopyRoom,
                            RoomIndex = 13,
                            LinkedLocation = new EMLocation
                            {
                                X = 40448,
                                Y = -7680,
                                Z = 22016,
                                Room = 63
                            },
                            NewLocation = new EMLocation
                            {
                                X = 38912,
                                Y = -7680,
                                Z = 16384,
                            }
                        },
                        new EMHorizontalCollisionalPortalFunction
                        {
                            EMType = EMType.HorizontalCollisionalPortal,
                            Portals = new Dictionary<short, Dictionary<short, EMLocation[]>>
                            {
                                [63] = new Dictionary<short, EMLocation[]>
                                {
                                    [-1] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 40448,
                                            Y = -7680,
                                            Z = 20992,
                                            Room = 63
                                        }
                                    }
                                },
                                [-1] = new Dictionary<short, EMLocation[]>
                                {
                                    [63] = new EMLocation[]
                                    {
                                        new EMLocation
                                        {
                                            X = 40448,
                                            Y = -7680,
                                            Z = 22016,
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
                                    BaseRoom = 63,
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
                                            Y = -8704,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7168,
                                            Y = -8704,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 7168,
                                            Y = -7680,
                                            Z = 1024
                                        },
                                        new TRVertex
                                        {
                                            X = 8192,
                                            Y = -7680,
                                            Z = 1024
                                        },
                                    }
                                },
                                new EMVisibilityPortal
                                {
                                    BaseRoom = -1,
                                    AdjoiningRoom = 63,
                                    Normal = new TRVertex
                                    {
                                        Z = -1
                                    },
                                    Vertices = new TRVertex[]
                                    {
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = -8704,
                                            Z = 5120
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -8704,
                                            Z = 5120
                                        },
                                        new TRVertex
                                        {
                                            X = 2048,
                                            Y = -7680,
                                            Z = 5120
                                        },
                                        new TRVertex
                                        {
                                            X = 1024,
                                            Y = -7680,
                                            Z = 5120
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
                                [128] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 2, 5, 8, 11, 12, 13, 14, 15 }
                                    }
                                },
                                [42] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 1, 4, 7, 10 }
                                    }
                                },
                                [111] = new EMGeometryMap
                                {
                                    [-1] = new Dictionary<EMTextureFaceType, int[]>
                                    {
                                        [EMTextureFaceType.Rectangles] = new int[] { 0, 3, 6, 9 }
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
                                        Texture = 128,
                                        Vertices = new ushort[]
                                        {
                                            3, 2, 0, 1
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
                                [63] = new Dictionary<EMTextureFaceType, int[]>
                                {
                                    [EMTextureFaceType.Rectangles] = new int[] { 55 }
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

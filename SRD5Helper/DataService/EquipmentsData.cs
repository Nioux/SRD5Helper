using SRD5Helper.DataModels;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.Data;

public partial class DataService
{


    //private IReadOnlyList<Equipment> _equipmentStoreList = new List<Equipment>();
    //private IReadOnlyDictionary<string, Equipment> _equipmentStore2 => _equipmentStoreList.
    private IReadOnlyList<EquipmentDatum> _equipmentData = new List<EquipmentDatum>
    {
        // ARMURES LÉGÈRES
        new()
        {
            //ID = Library.Equipments.armure_matelassee,
            ID = Library.Equipments.padded_armor,
            Type = EquipmentType.Light_Armor,
            Heaviness = WeaponHeaviness.Light,
            Cost = Money.FromGP(5),
            ArmorClass = 11,
            StealthDisadvantage = true,
            Weight = 4000
        },
        new()
        {
            //ID = Library.Equipments.armure_de_cuir,
            ID = Library.Equipments.leather_armor,
            Type = EquipmentType.Light_Armor,
            Heaviness = WeaponHeaviness.Light,
            Cost = Money.FromGP(10),
            ArmorClass = 11,
            Weight = 5000
        },
        new()
        {
            //ID = Library.Equipments.armure_de_cuir_cloute,
            ID = Library.Equipments.studded_leather_armor,
            Type = EquipmentType.Light_Armor,
            Heaviness = WeaponHeaviness.Light,
            Cost = Money.FromGP(45),
            ArmorClass = 12,
            Weight = 6500
        },

        // ARMURES INTERMÉDIAIRES
        new()
        {
            //ID = Library.Equipments.armure_de_peau,
            ID = Library.Equipments.hide_armor,
            Type = EquipmentType.Medium_Armor,
            Heaviness = WeaponHeaviness.Medium,
            Cost = Money.FromGP(10),
            ArmorClass = 12,
            MaxDexterityModifier = 2,
            Weight = 6000
        },
        new()
        {
            //ID = Library.Equipments.chemise_de_mailles,
            ID = Library.Equipments.chain_shirt,
            Type = EquipmentType.Medium_Armor,
            Heaviness = WeaponHeaviness.Medium,
            Cost = Money.FromGP(50),
            ArmorClass = 13,
            MaxDexterityModifier = 2,
            Weight = 10000
        },
        new()
        {
            //ID = Library.Equipments.armure_d_ecailles,
            ID = Library.Equipments.scale_mail,
            Type = EquipmentType.Medium_Armor,
            Heaviness = WeaponHeaviness.Medium,
            Cost = Money.FromGP(50),
            ArmorClass = 14,
            MaxDexterityModifier = 2,
            StealthDisadvantage = true,
            Weight = 22500,
        },
        new()
        {
            //ID = Library.Equipments.cuirasse,
            ID = Library.Equipments.breastplate,
            Type = EquipmentType.Medium_Armor,
            Heaviness = WeaponHeaviness.Medium,
            Cost = Money.FromGP(400),
            ArmorClass = 14,
            MaxDexterityModifier = 2,
            Weight = 10000,
        },
        new()
        {
            //ID = Library.Equipments.armure_de_demi_plate,
            ID = Library.Equipments.half_plate,
            Type = EquipmentType.Medium_Armor,
            Heaviness = WeaponHeaviness.Medium,
            Cost = Money.FromGP(750),
            ArmorClass = 15,
            MaxDexterityModifier = 2,
            StealthDisadvantage = true,
            Weight = 20000,
        },
        
        // ARMURES LOURDES
        new()
        {
            //ID = Library.Equipments.broigne,
            ID = Library.Equipments.ring_mail,
            Type = EquipmentType.Heavy_Armor,
            Heaviness = WeaponHeaviness.Heavy,
            Cost = Money.FromGP(30),
            ArmorClass = 14,
            StealthDisadvantage = true,
            Weight = 20000,
        },
        new()
        {
            //ID = Library.Equipments.cotte_de_mailles,
            ID = Library.Equipments.chain_mail,
            Type = EquipmentType.Heavy_Armor,
            Heaviness = WeaponHeaviness.Heavy,
            Cost = Money.FromGP(75),
            ArmorClass = 16,
            Strength = 13,
            StealthDisadvantage = true,
            Weight = 27500,
        },
        new()
        {
            //ID = Library.Equipments.clibanion,
            ID = Library.Equipments.splint,
            Type = EquipmentType.Heavy_Armor,
            Heaviness = WeaponHeaviness.Heavy,
            Cost = Money.FromGP(200),
            ArmorClass = 17,
            Strength = 15,
            StealthDisadvantage = true,
            Weight = 30000,
        },
        new()
        {
            //ID = Library.Equipments.harnois,
            ID = Library.Equipments.plate,
            Type = EquipmentType.Heavy_Armor,
            Heaviness = WeaponHeaviness.Heavy,
            Cost = Money.FromGP(1500),
            ArmorClass = 18,
            Strength = 15,
            StealthDisadvantage = true,
            Weight = 32500,
        },

        // BOUCLIER
        new()
        {
            //ID = Library.Equipments.bouclier,
            ID = Library.Equipments.shield,
            Type = EquipmentType.Shield,
            Cost = Money.FromGP(10),
            ArmorClassModifier = 2,
            Weight = 3000,
        },

        // ARMES DE CORPS À CORPS COURANTES
        new()
        {
            //ID = Library.Equipments.baton,
            ID = Library.Equipments.club,
            Type = EquipmentType.Simple_Melee_Weapon,
            Cost = Money.FromGP(2),
            MeleeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Bludgeoning,

            },
            Weight = 2000,
            WeaponAbility = WeaponAbility.Strength,
            HandCount = WeaponHandCount.Versatile,
            TwoHandledMeleeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Bludgeoning,
            },
        },
        new()
        {
            //ID = Library.Equipments.dague,
            ID = Library.Equipments.dagger,
            Type = EquipmentType.Simple_Melee_Weapon,
            Cost = Money.FromGP(2),
            MeleeDamage = new Damage
            {
                Dice = 4,
                Type = DamageType.Piercing,
            },
            Weight = 500,
            WeaponAbility = WeaponAbility.Finesse,
            Heaviness = WeaponHeaviness.Light,
            RangeDamage = new Damage
            {
                Dice = 4,
                Type = DamageType.Piercing,
                NormalRange = Distance.FromMeters(6),
                LongRange = Distance.FromMeters(18),
            }
        },
        new()
        {
            //ID = Library.Equipments.gourdin,
            ID = Library.Equipments.greatclub,
            Type = EquipmentType.Simple_Melee_Weapon,
            Cost = Money.FromSP(1),
            MeleeDamage = new Damage
            {
                Dice = 4,
                Type = DamageType.Bludgeoning,
            },
            WeaponAbility = WeaponAbility.Strength,
            Heaviness = WeaponHeaviness.Light,
            Weight = 1000,
        },
        new()
        {
            //ID = Library.Equipments.hachette,
            ID = Library.Equipments.handaxe,
            Type = EquipmentType.Simple_Melee_Weapon,
            Cost = Money.FromGP(5),
            MeleeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Slashing,
            },
            Weight = 1000,
            WeaponAbility = WeaponAbility.Strength,
            Heaviness = WeaponHeaviness.Light,
            RangeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Slashing,
                NormalRange = Distance.FromMeters(6),
                LongRange = Distance.FromMeters(18),
            }
        },
        new()
        {
            //ID = Library.Equipments.javeline,
            ID = Library.Equipments.javelin,
            Type = EquipmentType.Simple_Melee_Weapon,
            Cost = Money.FromSP(5),
            MeleeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Piercing,
            },
            Weight = 1000,
            RangeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Piercing,
                NormalRange = Distance.FromMeters(9),
                LongRange = Distance.FromMeters(36),
            }
        },
        new()
        {
            /// ???????
            ID = Library.Equipments.lance,
            Type = EquipmentType.Simple_Melee_Weapon, // ?????
            Cost = Money.FromGP(1),
            MeleeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Piercing,
            },
            Weight = 1500,
            RangeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Piercing,
                NormalRange = Distance.FromMeters(6),
                LongRange = Distance.FromMeters(18),
            },
        },
        new()
        {
            //ID = Library.Equipments.marteau_leger,
            ID = Library.Equipments.light_hammer,
            Type = EquipmentType.Simple_Melee_Weapon,
            Cost = Money.FromGP(2),
            MeleeDamage = new Damage
            {
                Dice = 4,
                Type = DamageType.Bludgeoning,
            },
            Weight = 1000,
            Heaviness = WeaponHeaviness.Light,
            RangeDamage = new Damage
            {
                Dice = 4,
                Type = DamageType.Bludgeoning,
                NormalRange = Distance.FromMeters(6),
                LongRange = Distance.FromMeters(18),
            },
        },
        new()
        {
            //ID = Library.Equipments.masse_d_armes,
            ID = Library.Equipments.mace,
            Type = EquipmentType.Simple_Melee_Weapon,
            Cost = Money.FromGP(5),
            MeleeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Bludgeoning,
            },
            Weight = 2000,
        },
        new()
        {
            //ID = Library.Equipments.massue,
            ID = Library.Equipments.quarterstaff,
            Type = EquipmentType.Simple_Melee_Weapon,
            Cost = Money.FromSP(2),
            TwoHandledMeleeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Bludgeoning,
            },
            Weight = 5000,
            HandCount = WeaponHandCount.Two_Handed,
        },
        new()
        {
            //ID = Library.Equipments.serpe,
            ID = Library.Equipments.sickle,
            Type = EquipmentType.Simple_Melee_Weapon,
            Cost = Money.FromGP(1),
            MeleeDamage = new Damage
            {
                Dice = 4,
                Type = DamageType.Slashing,
            },
            Weight = 1000,
            Heaviness = WeaponHeaviness.Light,
        },

        // spear ?????

        //ARMES À DISTANCE COURANTES
        new()
        {
            //ID = Library.Equipments.arbalete_legere,
            ID = Library.Equipments.light_crossbow,
            Type = EquipmentType.Simple_Ranged_Weapon,
            Cost = Money.FromGP(25),
            RangeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Piercing,
                NormalRange = Distance.FromMeters(24),
                LongRange = Distance.FromMeters(96),
                Ammunition = true,
                Loading = true,
            },
            Weight = 2500,
            HandCount = WeaponHandCount.Two_Handed,
        },
        new()
        {
            //ID = Library.Equipments.arc_court,
            ID = Library.Equipments.shortbow,
            Type = EquipmentType.Simple_Ranged_Weapon,
            Cost = Money.FromGP(25),
            RangeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Piercing,
                NormalRange = Distance.FromMeters(24),
                LongRange = Distance.FromMeters(96),
                Ammunition = true,
            },
            Weight = 1000,
            HandCount = WeaponHandCount.Two_Handed,
        },
        new()
        {
            //ID = Library.Equipments.flechette,
            ID = Library.Equipments.dart,
            Type = EquipmentType.Simple_Ranged_Weapon,
            Cost = Money.FromCP(5),
            RangeDamage = new Damage
            {
                Dice = 4,
                Type = DamageType.Piercing,
                NormalRange = Distance.FromMeters(6),
                LongRange = Distance.FromMeters(18),
            },
            Weight = 100,
            WeaponAbility = WeaponAbility.Finesse,
        },
        new()
        {
            //ID = Library.Equipments.fronde,
            ID = Library.Equipments.sling,
            Type = EquipmentType.Simple_Ranged_Weapon,
            Cost = Money.FromSP(1),
            RangeDamage = new Damage
            {
                Dice = 4,
                Type = DamageType.Bludgeoning,
                Ammunition = true,
                NormalRange = Distance.FromMeters(9),
                LongRange = Distance.FromMeters(36),
            }
        },

        //ARMES DE CORPS À CORPS DE GUERRE
        new()
        {
            //ID = Library.Equipments.cimeterre,
            ID = Library.Equipments.scimitar,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(25),
            MeleeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Slashing,
            },
            Weight = 1500,
            WeaponAbility = WeaponAbility.Finesse,
            Heaviness = WeaponHeaviness.Light,
        },
        new()
        {
            //ID = Library.Equipments.coutille,
            ID = Library.Equipments.glaive,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(20),
            TwoHandledMeleeDamage = new Damage
            {
                Dice = 10,
                Type = DamageType.Slashing,
                Reach = true,
            },
            Weight = 3000,
            Heaviness = WeaponHeaviness.Heavy,
            HandCount = WeaponHandCount.Two_Handed,
        },
        new()
        {
            //ID = Library.Equipments.epee_a_deux_mains,
            ID = Library.Equipments.greatsword,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(50),
            TwoHandledMeleeDamage = new Damage
            {
                Dice = 6,
                DiceCount = 2,
                Type = DamageType.Slashing,
            },
            Weight = 3000,
            Heaviness = WeaponHeaviness.Heavy,
            HandCount = WeaponHandCount.Two_Handed,
        },
        new()
        {
            //ID = Library.Equipments.epee_courte,
            ID = Library.Equipments.shortsword,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(10),
            MeleeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Piercing,
            },
            Weight = 1000,
            WeaponAbility = WeaponAbility.Finesse,
            Heaviness = WeaponHeaviness.Light,
        },
        new()
        {
            //ID = Library.Equipments.epee_longue,
            ID = Library.Equipments.longsword,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(15),
            MeleeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Slashing,
            },
            Weight = 5000,
        },
        new()
        {
            //ID = Library.Equipments.fleau,
            ID = Library.Equipments.flail,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(10),
            MeleeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Bludgeoning,
            },
            Weight = 1000,
        },
        new()
        {
            //ID = Library.Equipments.fouet,
            ID = Library.Equipments.whip,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(2),
            MeleeDamage = new Damage
            {
                Dice = 4,
                Type = DamageType.Slashing,
                Reach = true,
            },
            Weight = 1500,
            WeaponAbility = WeaponAbility.Finesse,
        },
        new()
        {
            //ID = Library.Equipments.hache_a_deux_mains,
            ID = Library.Equipments.greataxe,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(30),
            TwoHandledMeleeDamage = new Damage
            {
                Dice = 12,
                Type = DamageType.Slashing,
            },
            Weight = 3500,
            Heaviness = WeaponHeaviness.Heavy,
            HandCount = WeaponHandCount.Two_Handed,
        },
        new()
        {
            //ID = Library.Equipments.hache_d_armes,
            ID = Library.Equipments.battleaxe,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(10),
            MeleeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Slashing,
            },
            Weight = 2000,
            HandCount = WeaponHandCount.Versatile,
            TwoHandledMeleeDamage = new Damage
            {
                Dice = 10,
                Type = DamageType.Slashing,
            },
        },
        new()
        {
            //ID = Library.Equipments.hallebarde,
            ID = Library.Equipments.halberd,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(20),
            TwoHandledMeleeDamage = new Damage
            {
                Dice = 10,
                Type = DamageType.Slashing,
                Reach = true,
            },
            Weight = 3000,
            Heaviness = WeaponHeaviness.Heavy,
            HandCount = WeaponHandCount.Two_Handed,
        },
        new()
        {
            //ID = Library.Equipments.pic_de_guerre,
            ID = Library.Equipments.war_pick,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(5),
            MeleeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Piercing,
            },
            Weight = 1000,
        },
        new()
        {
            //ID = Library.Equipments.marteau_de_guerre,
            ID = Library.Equipments.warhammer,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(15),
            MeleeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Bludgeoning,
            },
            Weight = 1000,
            HandCount = WeaponHandCount.Versatile,
            TwoHandledMeleeDamage = new Damage
            {
                Dice = 10,
                Type = DamageType.Bludgeoning,
            },
        },
        new()
        {
            //ID = Library.Equipments.merlin,
            ID = Library.Equipments.maul,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(10),
            TwoHandledMeleeDamage = new Damage
            {
                Dice = 6,
                DiceCount = 2,
                Type = DamageType.Bludgeoning,
            },
            Weight = 5000,
            Heaviness = WeaponHeaviness.Heavy,
            HandCount = WeaponHandCount.Two_Handed,
        },
        new()
        {
            //ID = Library.Equipments.morgenstern,
            ID = Library.Equipments.morningstar,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(15),
            MeleeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Piercing,
            },
            Weight = 2000,
        },
        new()
        {
            //ID = Library.Equipments.pique,
            ID = Library.Equipments.pike,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(5),
            TwoHandledMeleeDamage = new Damage
            {
                Dice = 10,
                Type = DamageType.Piercing,
                Reach = true,
            },
            Weight = 9000,
            Heaviness = WeaponHeaviness.Heavy,
            HandCount = WeaponHandCount.Two_Handed,
        },
        new()
        {
            //ID = Library.Equipments.rapiere,
            ID = Library.Equipments.rapier,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(25),
            MeleeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Piercing,
            },
            Weight = 1000,
            WeaponAbility = WeaponAbility.Finesse,
        },
        new()
        {
            //ID = Library.Equipments.trident,
            ID = Library.Equipments.trident,
            Type = EquipmentType.Martial_Melee_Weapon,
            Cost = Money.FromGP(5),
            MeleeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Piercing,
            },
            Weight = 2000,
            RangeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Piercing,
                NormalRange = Distance.FromMeters(6),
                LongRange = Distance.FromMeters(18),
            },
            HandCount = WeaponHandCount.Versatile,
            TwoHandledMeleeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Piercing,
            }
        },

        //ARMES À DISTANCE DE GUERRE
        new()
        {
            //ID = Library.Equipments.arbalete_de_poing,
            ID = Library.Equipments.hand_crossbow,
            Type = EquipmentType.Martial_Ranged_Weapon,
            Cost = Money.FromGP(75),
            RangeDamage = new Damage
            {
                Dice = 6,
                Type = DamageType.Piercing,
                NormalRange = Distance.FromMeters(9),
                LongRange = Distance.FromMeters(36),
                Ammunition = true,
                Loading = true,
            },
            Weight = 1500,
            Heaviness = WeaponHeaviness.Light,
        },
        new()
        {
            //ID = Library.Equipments.arbalete_lourde,
            ID = Library.Equipments.heavy_crossbow,
            Type = EquipmentType.Martial_Ranged_Weapon,
            Cost = Money.FromGP(50),
            RangeDamage = new Damage
            {
                Dice = 10,
                Type = DamageType.Piercing,
                NormalRange = Distance.FromMeters(30),
                LongRange = Distance.FromMeters(120),
                Ammunition = true,
                Loading = true,
            },
            Weight = 9000,
            Heaviness = WeaponHeaviness.Heavy,
            HandCount = WeaponHandCount.Two_Handed,
        },
        new()
        {
            //ID = Library.Equipments.arc_long,
            ID = Library.Equipments.longbow,
            Type = EquipmentType.Martial_Ranged_Weapon,
            Cost = Money.FromGP(50),
            RangeDamage = new Damage
            {
                Dice = 8,
                Type = DamageType.Piercing,
                NormalRange = Distance.FromMeters(45),
                LongRange = Distance.FromMeters(180),
                Ammunition = true,
            },
            Weight = 1000,
            Heaviness = WeaponHeaviness.Heavy,
            HandCount = WeaponHandCount.Two_Handed,
        },
        new()
        {
            //ID = Library.Equipments.sarbacane,
            ID = Library.Equipments.blowgun,
            Type = EquipmentType.Martial_Ranged_Weapon,
            Cost = Money.FromGP(10),
            RangeDamage = new Damage
            {
                Dice = 1,
                Type = DamageType.Piercing,
                NormalRange = Distance.FromMeters(7, 50),
                LongRange = Distance.FromMeters(30),
                Ammunition = true,
                Loading = true,
            },
            Weight = 500,
        },

        /// net ?????


        // CUSTOM !!


        // Harnois nain (te donne une CA de base de 19 quand tu la portes, 10 sinon)
        new()
        {
            ID = Library.Equipments.harnois_nain,
            Type = EquipmentType.Heavy_Armor,
            Heaviness = WeaponHeaviness.Heavy,
            Cost = Money.FromGP(1500),
            ArmorClass = 19,
            Strength = 15,
            StealthDisadvantage = true,
            Weight = 32500,
        },
        // Épée ardente +1 (arme de corps à corps, dégâts 1d8 + bonus de Force, +1d6 dégâts de feu, une action pour l’activer, une action pour la désactiver)
        new()
        {
            ID = Library.Equipments.epee_ardente1,
            Type = EquipmentType.Martial_Melee_Weapon,
            MeleeDamage = new Damage
            {
                Dice = 8,
                Modifier = 1,
                Type = DamageType.Slashing,
            },
        },




        new()
        {
            //ID = Library.Equipments.fiole_acide,
            ID = Library.Equipments.acid_vial,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(25),
            Weight = 500,
        },
        new()
        {
            //ID = Library.Equipments.balance_de_marchand,
            ID = Library.Equipments.merchant_s_scale,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(5),
            Weight = 1500,
        },
        new()
        {
            //ID = Library.Equipments.belier_portatif,
            ID = Library.Equipments.portable_ram,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(4),
            Weight = 17500,
        },
        new()
        {
            ID = Library.Equipments.sac_de_billes,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 1000,
        },
        new()
        {
            ID = Library.Equipments.bougie,
            Type = EquipmentType.Item,
            Cost = Money.FromCP(1),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.boulier,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(2),
            Weight = 1000,
        },
        new()
        {
            ID = Library.Equipments.bouteille_en_verre,
            Type = EquipmentType.Container,
            Cost = Money.FromGP(2),
            Weight = 1000,
        },
        new()
        {
            ID = Library.Equipments.briquet_a_amadou,
            Type = EquipmentType.Item,
            Cost = Money.FromSP(5),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.cadenas,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(10),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.carquois,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.chaine,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(5),
            Weight = 5000,
        },
        new()
        {
            ID = Library.Equipments.chausse_trappes,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 1000,
            Quantity = 20,
        },
        new()
        {
            ID = Library.Equipments.chevaliere,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(5),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.cire_a_cacheter,
            Type = EquipmentType.Item,
            Cost = Money.FromSP(5),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.cloche,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.coffre,
            Type = EquipmentType.Container,
            Cost = Money.FromGP(5),
            Weight = 12500,
        },
        new()
        {
            ID = Library.Equipments.corde_en_chanvre,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 5000,
        },
        new()
        {
            ID = Library.Equipments.corde_en_soie,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(10),
            Weight = 2500,
        },
        new()
        {
            ID = Library.Equipments.couverture,
            Type = EquipmentType.Item,
            Cost = Money.FromSP(5),
            Weight = 1500,
        },
        new()
        {
            ID = Library.Equipments.craie,
            Type = EquipmentType.Item,
            Cost = Money.FromCP(1),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.cruche_ou_pichet,
            Type = EquipmentType.Container,
            Cost = Money.FromCP(2),
            Weight = 2000,
        },
        new()
        {
            ID = Library.Equipments.flasque_d_eau_benite,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(25),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.echelle,
            Type = EquipmentType.Item,
            Cost = Money.FromSP(1),
            Weight = 12500,
        },
        new()
        {
            ID = Library.Equipments.bouteille_d_encre,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(10),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.equipement_d_escalade,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(25),
            Weight = 6000,
        },
        new()
        {
            ID = Library.Equipments.etui_pour_carreaux,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.etui_a_cartes_ou_parchemins,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.fiole,
            Type = EquipmentType.Container,
            Cost = Money.FromGP(1),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.flasque_ou_chope,
            Type = EquipmentType.Container,
            Cost = Money.FromCP(2),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.grappin,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(2),
            Weight = 2000,
        },
        new()
        {
            //ID = Library.Equipments.grimoire,
            ID = Library.Equipments.spellbook,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(50),
            Weight = 1500,
        },
        new()
        {
            ID = Library.Equipments.flasque_d_huile,
            Type = EquipmentType.Item,
            Cost = Money.FromSP(1),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.lampe,
            Type = EquipmentType.Item,
            Cost = Money.FromSP(5),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.lanterne_a_capote,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(5),
            Weight = 1000,
        },
        new()
        {
            ID = Library.Equipments.lanterne_sourde,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(10),
            Weight = 1000,
        },
        new()
        {
            ID = Library.Equipments.livre,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(25),
            Weight = 2500,
        },
        new()
        {
            ID = Library.Equipments.longue_vue,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1000),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.loupe,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(100),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.marteau,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 1500,
        },
        new()
        {
            ID = Library.Equipments.masse,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(2),
            Weight = 5000,
        },
        new()
        {
            ID = Library.Equipments.materiel_de_peche,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 2000,
        },
        new()
        {
            ID = Library.Equipments.menottes,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(2),
            Weight = 3000,
        },
        new()
        {
            ID = Library.Equipments.miroir_en_acier,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(5),
            Weight = 250,
        },
        new()
        {
            ID = Library.Equipments.fleches,
            Type = EquipmentType.Ammunition,
            Cost = Money.FromGP(1),
            Weight = 500,
            Quantity = 20,
        },
        new()
        {
            ID = Library.Equipments.dards_de_sarbacane,
            Type = EquipmentType.Ammunition,
            Cost = Money.FromGP(1),
            Weight = 500,
            Quantity = 50,
        },
        new()
        {
            ID = Library.Equipments.carreaux_d_arbalete,
            Type = EquipmentType.Ammunition,
            Cost = Money.FromGP(1),
            Weight = 750,
            Quantity = 20,
        },
        new()
        {
            ID = Library.Equipments.billes_de_fronde,
            Type = EquipmentType.Ammunition,
            Cost = Money.FromCP(4),
            Weight = 750,
        },
        new()
        {
            ID = Library.Equipments.outre,
            Type = EquipmentType.Container,
            Cost = Money.FromSP(2),
            Weight = 2500,
        },
        new()
        {
            ID = Library.Equipments.palan,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 2500,
        },
        new()
        {
            ID = Library.Equipments.panier,
            Type = EquipmentType.Container,
            Cost = Money.FromSP(4),
            Weight = 1000,
        },
        new()
        {
            ID = Library.Equipments.papier,
            Type = EquipmentType.Item,
            Cost = Money.FromSP(2),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.parchemin,
            Type = EquipmentType.Item,
            Cost = Money.FromSP(1),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.parfum,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(5),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.pelle,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(2),
            Weight = 2500,
        },
        new()
        {
            ID = Library.Equipments.perche,
            Type = EquipmentType.Item,
            Cost = Money.FromCP(5),
            Weight = 3500,
        },
        new()
        {
            ID = Library.Equipments.pics_en_fer,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 2500,
        },
        new()
        {
            ID = Library.Equipments.pied_de_biche,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(2),
            Weight = 2500,
        },
        new()
        {
            ID = Library.Equipments.piege_a_machoires,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(5),
            Weight = 12500,
        },
        new()
        {
            ID = Library.Equipments.pierre_a_affuter,
            Type = EquipmentType.Item,
            Cost = Money.FromCP(1),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.pioche_de_mineur,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(2),
            Weight = 5000,
        },
        new()
        {
            ID = Library.Equipments.piton,
            Type = EquipmentType.Item,
            Cost = Money.FromCP(5),
            Weight = 125,
        },
        new()
        {
            ID = Library.Equipments.porte_plume,
            Type = EquipmentType.Item,
            Cost = Money.FromCP(2),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.pot_en_fer,
            Type = EquipmentType.Container,
            Cost = Money.FromGP(2),
            Weight = 5000,
        },
        new()
        {
            ID = Library.Equipments.potion_de_soins,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(50),
            Weight = 250,
        },
        new()
        {
            ID = Library.Equipments.rations,
            Type = EquipmentType.Item,
            Cost = Money.FromSP(5),
            Weight = 1000,
        },
        new()
        {
            ID = Library.Equipments.sablier,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(25),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.sac,
            Type = EquipmentType.Container,
            Cost = Money.FromCP(1),
            Weight = 250,
        },
        new()
        {
            //ID = Library.Equipments.sac_a_dos,
            ID = Library.Equipments.backpack,
            Type = EquipmentType.Container,
            Cost = Money.FromGP(2),
            Weight = 2500,
        },
        new()
        {
            //ID = Library.Equipments.sac_de_couchage,
            ID = Library.Equipments.bedroll,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 3500,
        },
        new()
        {
            ID = Library.Equipments.sacoche,
            Type = EquipmentType.Container,
            Cost = Money.FromSP(5),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.savon,
            Type = EquipmentType.Item,
            Cost = Money.FromCP(2),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.seau,
            Type = EquipmentType.Container,
            Cost = Money.FromCP(5),
            Weight = 1000,
        },
        new()
        {
            ID = Library.Equipments.sifflet,
            Type = EquipmentType.Item,
            Cost = Money.FromCP(5),
            Weight = 0,
        },


        new()
        {
            ID = Library.Equipments.amulette,
            Type = EquipmentType.Holy_Symbol,
            Cost = Money.FromGP(5),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.embleme,
            Type = EquipmentType.Holy_Symbol,
            Cost = Money.FromGP(5),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.reliquaire,
            Type = EquipmentType.Holy_Symbol,
            Cost = Money.FromGP(5),
            Weight = 1000,
        },


        new()
        {
            ID = Library.Equipments.tente_deux_personnes,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(2),
            Weight = 10000,
        },
        new()
        {
            ID = Library.Equipments.tonneau,
            Type = EquipmentType.Container,
            Cost = Money.FromGP(2),
            Weight = 35000,
        },
        new()
        {
            ID = Library.Equipments.torche,
            Type = EquipmentType.Item,
            Cost = Money.FromCP(1),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.trousse_de_soins,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(5),
            Weight = 1500,
        },
        new()
        {
            ID = Library.Equipments.costume,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(5),
            Weight = 2000,
        },
        new()
        {
            ID = Library.Equipments.habits_courants,
            Type = EquipmentType.Item,
            Cost = Money.FromSP(5),
            Weight = 1500,
        },
        new()
        {
            ID = Library.Equipments.habits_de_bonne_qualite,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(15),
            Weight = 3000,
        },
        new()
        {
            ID = Library.Equipments.robes,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(1),
            Weight = 2000,
        },
        new()
        {
            ID = Library.Equipments.tenue_de_voyageur,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(2),
            Weight = 2000,
        },





        new()
        {
            ID = Library.Equipments.outils_de_voleur,
            Type = EquipmentType.Artisans_Tools,
            Cost = Money.FromGP(25),
            Weight = 500,
        },
        new()
        {
            ID = Library.Equipments.ficelle,
            Type = EquipmentType.Item,
            Cost = Money.FromGP(0),
            Weight = 0,
        },
        new()
        {
            ID = Library.Equipments.materiel_dherboriste,
            Type = EquipmentType.Artisans_Tools,
            Cost = Money.FromGP(0),
            Weight = 0,
        },

        /*
Instruments de musique
Chalemie 2 po 0,5 kg
Cor 3 po 1 kg
Cornemuse 30 po 3 kg
Flûte 2 po 0,5 kg
Flûte de pan 12 po 1 kg
Luth 35 po 1 kg
Lyre 30 po 1 kg
Tambour 6 po 1,5 kg
Tympanon 25 po 5 kg
Viole 30 po 0,5 kg
Instruments de navigation 25 po 1 kg
Jeux
Dés 1 pa _
Jeu de cartes 5 pa _
Matériel d’empoisonneur 50 po 1 kg
Matériel d’herboriste 5 po 1,5 kg
Outils d’artisan
Matériel d’alchimiste 50 po 4 kg
Matériel de brasseur 20 po 4,5 kg
Objet Prix Poids
Outils de bricoleur 50 po 5 kg
Matériel de calligraphie 10 po 2,5 kg
Outils de cartographe 15 po 3 kg
Outils de charpentier 8 po 3 kg
Outils de cordonnier 5 po 2,5 kg
Ustensiles de cuisinier 1 po 4 kg
Accessoires de déguisement 25 po 1,5 kg
Accessoires de faussaire 15 po 2,5 kg
Outils de forgeron 20 po 4 kg
Outils de joaillier 25 po 1 kg
Outils de maçon 10 po 4 kg
Outils de menuisier 1 po 2,5 kg
Matériel de peintre 10 po 2,5 kg
Outils de potier 10 po 1,5 kg
Outils de souffleur de verre 30 po 2,5 kg
Outils de tanneur 5 po 2,5 kg
Outils de tisserand 1 po 2,5 kg
Outils de voleur 25 po 0,5 kg         * */
    };
    private IReadOnlyDictionary<string, EquipmentDatum> _equipmentDataMap = null;
    public IReadOnlyDictionary<string, EquipmentDatum> EquipmentsData => _equipmentDataMap ??= _equipmentData.ToDictionary(s => s.ID, s => s);

}

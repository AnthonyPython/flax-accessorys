using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.Utilities;

namespace Game
{

    public enum ItemType
    {
        Digestible,
        Helmet,
        Weapon,
        Shield,
        Boots,
        Chest,
        Default
    }

    public enum Attributes
    {
        Agility,
        Intellect,
        Stamina,
        Strength
    }
    //[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Items/item")]
    public class ItemObject
    {

        public Sprite uiDisplay;
        public Actor characterDisplay;
        public AnimatedModel characterDisplayModel;
        public bool stackable;
        public ItemType type;
        //[TextArea(15, 20)]
        public string description;
        public Item data = new Item();

        public List<string> boneNames = new List<string>();

        public Item CreateItem()
        {
            Item newItem = new Item(this);
            return newItem;
        }

        public void OnValidate()
        {
            boneNames.Clear();
            if (characterDisplayModel == null)
                return;
            if (!characterDisplayModel.SkinnedModel)
                return;

            

            var renderer = characterDisplayModel.SkinnedModel;
            var bones = renderer.Bones;

            foreach (var t in bones)
            {
                boneNames.Add(t.ToString());
            }

        }


    }

    [System.Serializable]
    public class Item
    {
        public string Name;
        public int Id = -1;
        public ItemBuff[] buffs;
        public Item()
        {
            Name = "";
            Id = -1;
        }
        public Item(ItemObject item)
        {
            Name = item.ToString();
            Id = item.data.Id;
            buffs = new ItemBuff[item.data.buffs.Length];
            for (int i = 0; i < buffs.Length; i++)
            {
                buffs[i] = new ItemBuff(item.data.buffs[i].min, item.data.buffs[i].max)
                {
                    attribute = item.data.buffs[i].attribute
                };
            }
        }
    }

    [System.Serializable]
    public class ItemBuff : IModifier
    {
        public Attributes attribute;
        public int value;
        public int min;
        public int max;
        public ItemBuff(int _min, int _max)
        {
            min = _min;
            max = _max;
            GenerateValue();
        }

        public void AddValue(ref int baseValue)
        {
            baseValue += value;
        }

        public void GenerateValue()
        {
            var rand = new Random();
            value = rand.Next(min, max);
        }
    }
}

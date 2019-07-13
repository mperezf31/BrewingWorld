﻿using System;

using BrewingWorld.Models;

namespace BrewingWorld.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel_old
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
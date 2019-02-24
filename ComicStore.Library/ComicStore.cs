﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ComicStore.Library
{
    public class ComicStore
    {
        //locationname
        //list of products
        private string _Location;
        private List<Product> _Inventory;


        public string Name
        {
            get => _Location;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name of location must not be empty. ");
                }
                _Location= value;
            }
        }



        public List<Product> Inventory
        {
            get => _Inventory;
            set
            {
                if (value?.Any() != true)
                {
                    throw new ArgumentException("Cannot accept a null or empty list for inventory products. ");
                }
                _Inventory = value;
            }
        }




    }
}
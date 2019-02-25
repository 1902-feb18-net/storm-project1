﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ComicStore.Library
{
    class ComiceStoreRepository
    {
        //handles the add/delete/edit for comicstores and products.
        private readonly ICollection<ComicStore> _data;



        public ComiceStoreRepository(ICollection<ComicStore> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }



        //search comic

        public IEnumerable<ComicStore> GetComicStore(string search = null)
        {
            if (search == null)
            {
                foreach (var item in _data)
                {
                    yield return item;
                }
            }
            else
            {
                foreach (var item in _data.Where(r => r.Name.Contains(search)))
                {
                    yield return item;
                }
            }
        }

        //add comic 


        public void AddComicStore ( ComicStore comicstore)
        {
            if (_data.Any(c => c.Name == comicstore.Name))
            {
                throw new InvalidOperationException("A Comic Store with that name already exists. ");
            }
            _data.Add(comicstore);
        }


        //delete comic 

        public void DeleteComicStore (ComicStore comicstore)
        {
            _data.Delete(comicstore);
        }


        //update comic 
        public void UpdateComicStore (ComicStore comicstore)
        {
            DeleteComicStore(comicstore);
            AddComicStore(comicstore);
        }


        //search product name
        /*
        public IEnumerable<ComicStore> GetProduct(string search = null)
        {

        }
        */

        //add product
        public void AddProduct(Product product, ComicStore comicstore)
        {
            comicstore.Inventory.Add(product);
        }



        //delete product
        public void DeleteProduct(Product product)
        {
            var store = _data.First(x => x.Inventory.Any(y => y.Name == product.Name));
            store.Inventory.Remove(store.Inventory.First(x => x.Name == product.Name));
        }



        //update product name
        public Product UpdateProduct(Product product, string name)
        {
            var store = _data.First(x => x.Inventory.Any(y => y.Name == name));
            var placeholder = store.Invetory.IndexOf(store.Inventory.First(y => y.Name == name));
            store.Inventory[placeholder] = product;
        }
        










    }
}
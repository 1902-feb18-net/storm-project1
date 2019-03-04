﻿using System;
using System.Collections.Generic;
using System.Linq;
using ComicStore.Library;
using ET.ComicStore.Library;
using Microsoft.EntityFrameworkCore;

namespace ComicStore
{
    static class Program
    {
        static void Main(string[] args)
        {
            var CSdata = new List<Comicstore>();
            var Cdata = new List<Library.Customer>();

            var csrepo = new ComiceStoreRepository(CSdata);
            var crepo = new CustomerRepository(Cdata);
            string curr_name = "";
            string curr_email;


            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(Secret.ConnectionString);
            var options = optionsBuilder.Options;
                /*
                Console.WriteLine("Welcome to Comic League United the 7th largest comic supply store in the tri-state area.");
                Console.WriteLine("Please login in order make a new customer. ");
                Console.WriteLine("Please enter Customer name now. ");
                curr_name = Console.ReadLine();
                Console.WriteLine("Please enter Customer email now. ");
                curr_email = Console.ReadLine();
                

                crepo.CheckCustomer(curr_name, curr_email);
                */
                while (true)
                {
                    MainMenu();
                    string choice = "11";
                    string temp = "";

                    try
                    {
                        choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "0")
                        {
                            break;
                        }
                        else if (choice == "1")
                        {
                            choice = "11";
                            Console.WriteLine("1: Add a Store");
                            Console.WriteLine("2: Delete a Store");
                            Console.WriteLine("3: Update a Store");
                            choice = Console.ReadLine();
                            Console.Clear();
                            if (choice == "1")
                            {
                                Console.WriteLine("Please enter a Store Name to add");
                                temp = Console.ReadLine();
                            using (var dbContext = new Project0Context(options))
                            {
                                AddStore(dbContext, temp);
                            }
                        }
                            else if (choice == "2")
                            {
                                Console.WriteLine("Please enter a Store Name to delete");
                                temp = Console.ReadLine();
                            using (var dbContext = new Project0Context(options))
                            {
                                DeleteStore(dbContext, temp);
                            }
                        }
                            else if (choice == "3")
                            {
                                Console.WriteLine("Please enter a Store Name to update");
                                temp = Console.ReadLine();
                                Console.WriteLine("Please enter the new name. ");
                                string temp2 = Console.ReadLine();
                                using (var dbContext = new Project0Context(options))
                                {
                                    UpdateStore(dbContext, temp, temp2);
                                }
                        }
                            else
                            {
                                throw new ArgumentException("Please pick a valid option. ");
                            }
                        }
                        else if (choice == "2")
                        {
                            choice = "11";
                            Console.WriteLine("1: Show All Stores. ");
                            Console.WriteLine("2: Show One Store. ");
                            choice = Console.ReadLine();
                            Console.Clear();
                            if (choice == "1")
                            {
                            using (var dbContext = new Project0Context(options))
                                {
                                    ShowStores(dbContext);
                                    Console.ReadKey();
                                }
                            }
                            else if (choice == "2")
                            {
                                Console.WriteLine("Please enter the store name. ");
                                temp = Console.ReadLine();
                                var store = csrepo.GetComicStore(temp).ToList();
                                using (var dbContext = new Project0Context(options))
                                {
                                    ShowStores(dbContext,temp);
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Please pick a valid option. ");
                            }
                        }
                        else if (choice == "3")
                        {
                            choice = "11";
                            Console.WriteLine("1: Add a Product");
                            Console.WriteLine("2: Delete a Product");
                            Console.WriteLine("3: Update a Product");
                            choice = Console.ReadLine();
                            Console.Clear();
                            if (choice == "1")
                            {
                                string placeholder;
                                int inv = 1;
                                decimal price = 5.00m;
                                int id;
                                Console.WriteLine("Please enter a Product Name.");
                                placeholder = Console.ReadLine();
                                Console.WriteLine("Please enter the number of products in inventory.");
                                temp = Console.ReadLine();
                                int.TryParse(temp, out inv);
                                Console.WriteLine("Please enter the price of the product.");
                                temp = Console.ReadLine();
                                decimal.TryParse(temp, out price);
                                Console.WriteLine("Please enter a Store ID to add the Product.");
                                temp = Console.ReadLine();
                                int.TryParse(temp, out id);
                                

                                using (var dbContext = new Project0Context(options))
                                {
                                    AddProduct(dbContext, placeholder, price, inv, id);
                                }
                        }
                            else if (choice == "2")
                            {
                                Console.WriteLine("Please enter a product Name to delete");
                                temp = Console.ReadLine();
                                using (var dbContext = new Project0Context(options))
                                {
                                    DeleteProduct(dbContext, temp);
                                }
                            }
                            else if (choice == "3")
                            {
                            string placeholder;
                            string old;
                            int inv = 1;
                            decimal price = 5.00m;
                            int id;
                            Console.WriteLine("Please enter the old Product Name.");
                            old = Console.ReadLine();
                            Console.WriteLine("Please enter the new Product Name.");
                            placeholder = Console.ReadLine();
                            Console.WriteLine("Please enter the number of products in inventory.");
                            temp = Console.ReadLine();
                            int.TryParse(temp, out inv);
                            Console.WriteLine("Please enter the price of the product.");
                            temp = Console.ReadLine();
                            decimal.TryParse(temp, out price);
                            Console.WriteLine("Please enter a Store ID to add the Product.");
                            temp = Console.ReadLine();
                            int.TryParse(temp, out id);


                            using (var dbContext = new Project0Context(options))
                            {
                                UpdateProduct(dbContext, placeholder, price, inv, id, old);
                            }
                        }

                            else
                            {
                                throw new ArgumentException("Please pick a valid option. ");
                            }
                        }
                        else if (choice == "4")
                        {
                            choice = "11";
                            Console.WriteLine("1: Show All Products");
                            Console.WriteLine("2: Show A Product");
                            choice = Console.ReadLine();
                            Console.Clear();
                        if (choice == "1")
                        {
                            using (var dbContext = new Project0Context(options))
                            {
                                ShowProducts(dbContext);
                                Console.ReadKey();
                            }
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Please enter the product name. ");
                            temp = Console.ReadLine();
                            var store = csrepo.GetProduct(temp).ToList();
                            using (var dbContext = new Project0Context(options))
                            {
                                ShowProducts(dbContext, temp);
                                Console.ReadKey();
                            }

                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                        }
                        else if (choice == "5")
                        {
                            choice = "11";
                            Console.WriteLine("1: Add a Customer");
                            Console.WriteLine("2: Delete a Customer");
                            Console.WriteLine("3: Update a Customer");
                            choice = Console.ReadLine();
                            Console.Clear();
                            if (choice == "1")
                            {  
                                string email;
                                string id;
                                Console.WriteLine("Please enter the name of the customer. ");
                                temp = Console.ReadLine();
                                Console.WriteLine("Please enter the customers email. ");
                                email = Console.ReadLine();
                                Console.WriteLine("Please enter the customers store name. ");
                                id = Console.ReadLine();
                                using (var dbContext = new Project0Context(options))
                                {
                                    AddCustomer(dbContext,temp, email,id);
                                }
                            }
                            else if (choice == "2")
                            {
                                string email;
                                Console.WriteLine("Please enter the name of the customer. ");
                                temp = Console.ReadLine();
                                Console.WriteLine("Please enter the customers email. ");
                                email = Console.ReadLine();
                                using (var dbContext = new Project0Context(options))
                                {
                                    DeleteCustomer(dbContext,temp, email);
                                }
                            }
                            else if (choice == "3")
                            {
                            string email, oldn, olde;
                                Console.WriteLine("Please enter the name of the customer to edit. ");
                                oldn = Console.ReadLine();
                                Console.WriteLine("Please enter the old customers email. ");
                                olde = Console.ReadLine();
                                Console.WriteLine("Please enter the new name of the customer. ");
                                temp = Console.ReadLine();
                                Console.WriteLine("Please enter the new customers email. ");
                                email = Console.ReadLine();
                                using (var dbContext = new Project0Context(options))
                                {
                                    UpdateCustomer(dbContext ,temp, email, oldn, olde);
                                }
                            

                            }
                            else
                            {
                                throw new ArgumentException("Please pick a valid option. ");
                            }
                        }
                        else if (choice == "6")
                        {
                            Console.Clear();
                            using (var dbContext = new Project0Context(options))
                            {
                                ShowCustomers(dbContext);
                                Console.ReadKey();
                            }
                    }
                }/*
                        else if (choice == "7")
                        {
                            choice = "11";
                            Console.WriteLine("1: Add a product to your cart");
                            Console.WriteLine("2: Delete a product from your cart");
                            Console.WriteLine("3: Checkout");
                            choice = Console.ReadLine();
                            Console.Clear();
                            if (choice == "1")
                            {
                                int inv = 1;
                                Console.WriteLine("Please enter the name of the product you'd like to add. ");
                                temp = Console.ReadLine();
                                var prod = csrepo.GetProduct(temp).ToList();
                                Console.WriteLine("How many would you like to add. ");
                                temp = Console.ReadLine();
                                int.TryParse(temp, out inv);
                                crepo.AddProduct(prod[0], curr_name, inv);

                            }
                            else if (choice == "2")
                            {
                                int inv = 1;
                                Console.WriteLine("Please enter the name of the product you'd like to remove. ");
                                temp = Console.ReadLine();
                                Console.WriteLine("How many would you like to remove. ");
                                string temper = Console.ReadLine();
                                int.TryParse(temper, out inv);
                                crepo.DeleteProduct(temp, curr_name, inv);

                            }
                            else if (choice == "3")
                            {
                                Console.Clear();
                                double total = 0;
                                var cart = crepo.GetProduct(curr_name);
                                foreach (var item in cart)
                                {
                                    Console.WriteLine(item.Name + ":   " + item.Price);
                                    total = total + item.Price;
                                }
                                Console.WriteLine("Total: " + total);
                                //ToDo: add cart to order history for customer
                                Console.WriteLine("Thank you for shopping with us come back soon. ");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                throw new ArgumentException("Please pick a valid option. ");
                            }
                        }
                        else if (choice == "8")
                        {
                            Console.Clear();
                            double total = 0;
                            var cart = crepo.GetProduct(curr_name);
                            foreach (var item in cart)
                            {
                                Console.WriteLine(item.Name + ":   " + item.Price);
                                total = total + item.Price;
                            }
                            Console.WriteLine("Total: " + total);
                        }
                        else if (choice == "9")
                        {
                            Console.Clear();
                            var orders = crepo.GetHistory(curr_name);
                            foreach (var item in orders)
                            {
                                Console.WriteLine("Order ID: " + item.ID);
                                Console.WriteLine("Order Total: " + item.Total);
                                foreach(var prod in item.Products)
                                {
                                    Console.WriteLine(prod.Name + "   " + prod.Price);
                                }
                            }

                        }
                        else
                        {
                            throw new ArgumentException("Please pick a valid option. ");
                        }
                    } */
                    catch(ArgumentException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e);
                        Console.ReadKey();
                    }


                    choice = "11";
                }

               
                /* 
                 * Todo: All unit tests
                 * ToDo: Add way/option to save cart to cust history.
                 * ToDo: Add try/catch to save and delete functions for the save changes
                 * ToDo: Add Interface for repositories right click on class name and extract interface
                 * ToDo: Add in logging
                 * ToDo: Go through the console app and replace what can with the sql stuff that is easier.
                 * ToDo: Map the things to the other things. 
                 * ToDo: Add in sets to add complexity to the database and inventory. 
                 */
            }

        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Edit a store Location. ");
            Console.WriteLine("2. Show a store Location. ");
            Console.WriteLine("3. Edit a Product. ");
            Console.WriteLine("4. Show a Product. ");
            Console.WriteLine("5. Edit a Customer. ");
            Console.WriteLine("6. Show Customer Info. ");
            Console.WriteLine("7. Edit Cart. ");//ToDo
            Console.WriteLine("8. Show Cart. ");//ToDo
            Console.WriteLine("9. Show Order History. ");//ToDo
            Console.WriteLine("0. Quit. ");
        }


        static void ShowStores(Project0Context dbContext, string name = null)
        {
            if (name == null)
            {
                foreach (var store in dbContext.ComicStore)
                {
                    Console.WriteLine("Store Id: " + store.StoreId + "  Location: " + store.Location);
                }
            }
            else
            {
                var store = dbContext.ComicStore.FirstOrDefault(x => x.Location == name);
                if (store == null)
                {
                    Console.WriteLine("No store of that name found. ");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Store Id: " + store.StoreId + "  Location: " + store.Location);
            }
            
        }



        static void AddStore(Project0Context dbContext, string name)
        {
            var ComicStore = new ET.ComicStore.Library.ComicStore();
            ComicStore.Location = name;
            dbContext.Add(ComicStore);
            dbContext.SaveChanges();
        }




        static void DeleteStore(Project0Context dbContext, string name)
        {
            var ComicStore = dbContext.ComicStore.FirstOrDefault(x => x.Location == name);
            if (ComicStore == null)
            {
                Console.WriteLine("No store of that name found. ");
                Console.ReadKey();
                return;
            }
            dbContext.Remove(ComicStore);
            dbContext.SaveChanges();
        }



        static void UpdateStore(Project0Context dbContext, string name , string ne)
        {
            var ComicStore = dbContext.ComicStore.FirstOrDefault(x => x.Location == name);
            if (ComicStore == null)
            {
                Console.WriteLine("No store of that name found. ");
                Console.ReadKey();
                return;
            }
            dbContext.Remove(ComicStore);
            var ComicStore2 = new ET.ComicStore.Library.ComicStore();
            ComicStore2.Location = ne;
            dbContext.Add(ComicStore2);
            dbContext.SaveChanges();
        }



        static void ShowProducts(Project0Context dbContext, string name = null)
        {
            if (name == null)
            {
                foreach (var store in dbContext.StoreProduct)
                {
                    Console.WriteLine(store.Name + "  -  " + store.Price + "  Left in stock: " + store.InventorySize); 
                }
            }
            else
            {
                var store = dbContext.StoreProduct.FirstOrDefault(x => x.Name == name);
                if (store == null)
                {
                    Console.WriteLine("No comic of that name found. ");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine(store.Name + "  -  " + store.Price + "  Left in stock: " + store.InventorySize);
            }
        }


        static void AddProduct(Project0Context dbContext, string name,decimal price,int size, int store)
        {
            var stores = dbContext.ComicStore.Include(x => x.Inventory).ThenInclude(y => y.StoreProduct);
            var ComicStore = new ET.ComicStore.Library.StoreProduct();
            ComicStore.Name = name;
            ComicStore.InventorySize = size;
            ComicStore.Price = price;
            ComicStore.InventoryId = store;
            dbContext.Add(ComicStore);
            dbContext.SaveChanges();
        }



        static void DeleteProduct(Project0Context dbContext, string name)
        {
            var ComicStore = dbContext.StoreProduct.FirstOrDefault(x => x.Name == name);
            if (ComicStore == null)
            {
                Console.WriteLine("No Comic of that name found. ");
                Console.ReadKey();
                return;
            }
            dbContext.Remove(ComicStore);
            dbContext.SaveChanges();
        }


        static void UpdateProduct(Project0Context dbContext, string name, decimal price, int size, int store, string old)
        {
            var stores = dbContext.ComicStore.Include(x => x.Inventory).ThenInclude(y => y.StoreProduct);
            var oldstore = dbContext.StoreProduct.FirstOrDefault(x => x.Name == old);
            if (oldstore == null)
            {
                Console.WriteLine("No Comic of that name found. ");
                Console.ReadKey();
                return;
            }
            var ComicStore = new ET.ComicStore.Library.StoreProduct();
            ComicStore.Name = name;
            ComicStore.InventorySize = size;
            ComicStore.Price = price;
            ComicStore.InventoryId = store;
            dbContext.Remove(oldstore);
            dbContext.Add(ComicStore);
            dbContext.SaveChanges();
        }




        static void ShowCustomers(Project0Context dbContext, string name = null)
        {
            if (name == null)
            {
                foreach (var store in dbContext.Customer)
                {
                    Console.WriteLine(store.Name + "  -  " + store.Email + "  Store Location " + store.Location);
                }
            }
            else
            {
                var store = dbContext.Customer.FirstOrDefault(x => x.Name == name || x.Email == name);
                if (store == null)
                {
                    Console.WriteLine("No customer was found. ");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine(store.Name + "  -  " + store.Email + "  Store Location " + store.Location);
            }
        }



        static void AddCustomer(Project0Context dbContext, string name, string email, string storeid)
        {
            var ComicStore = new ET.ComicStore.Library.Customer();
            ComicStore.Name = name;
            ComicStore.Email = email;
            ComicStore.Location = storeid;
            dbContext.Add(ComicStore);
            dbContext.SaveChanges();
        }

        static void DeleteCustomer(Project0Context dbContext, string name, string email)
        {
            var ComicStore = dbContext.Customer.FirstOrDefault(x => x.Name == name && x.Email == email);
            if (ComicStore == null)
            {
                Console.WriteLine("No customer of that name found. ");
                Console.ReadKey();
                return;
            }
            dbContext.Remove(ComicStore);
            dbContext.SaveChanges();
        }



        static void UpdateCustomer(Project0Context dbContext, string name, string email, string oldn, string olde)
        {
            var oldstore = dbContext.Customer.FirstOrDefault(x => x.Name == oldn && x.Email == olde);
            if (oldstore == null)
            {
                Console.WriteLine("No customer of that name found. ");
                Console.ReadKey();
                return;
            }
            var ComicStore = new ET.ComicStore.Library.Customer();
            ComicStore.Name = name;
            ComicStore.Email = email;
            ComicStore.Location = oldstore.Location;
            dbContext.Remove(oldstore);
            dbContext.Add(ComicStore);
            dbContext.SaveChanges();
        }



    }
}
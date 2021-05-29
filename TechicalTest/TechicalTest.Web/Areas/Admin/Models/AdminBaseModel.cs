using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using TT.Framework;

namespace TechicalTest.Web.Areas.Admin.Models
{
    public abstract class AdminBaseModel
    {
        public MenuModel MenuModel { get; set; }
        public ResponseModel Response
        {
            get
            {
                if (_httpContextAccessor.HttpContext.Session.IsAvailable
                    && _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));

                    return response;
                }
                else
                    return null;
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.Set(nameof(Response),
                    value);
            }
        }

        protected IHttpContextAccessor _httpContextAccessor;
        public AdminBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SetupMenu();
        }

        public AdminBaseModel()
        {
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            SetupMenu();
        }

        private void SetupMenu()
        {
            MenuModel = new MenuModel
            {
                MenuItems = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Title = "Register Admin",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = "Create Admin", Url = "/Identities/Register/Registration" }

                        }

                    },
                    new MenuItem
                    {
                        Title = "Product",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = "View Product", Url = "/Admin/Product" },
                            new MenuChildItem{ Title = "Add Product", Url = "/Admin/Product/CreateProduct" }

                        }

                    },
                    new MenuItem
                    {
                        Title = "Sell Product",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = "View Selling Product", Url = "/Admin/SellProduct/" },
                            new MenuChildItem{ Title = "Add Selling Product", Url ="/Admin/SellProduct/CreateSellProduct"}
                                
                        }

                    },
                 
                    new MenuItem
                    {
                        Title = "Setting",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = "Manage Profile", Url = "/Identity/Account/Manage/Index" },
                            new MenuChildItem{ Title = "Log Out", Url ="/Identity/Account/Logout"}

                        }

                    }
                }
            };

        }
    }
}


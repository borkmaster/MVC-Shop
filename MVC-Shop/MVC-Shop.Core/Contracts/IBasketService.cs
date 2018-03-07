using System;
using System.Collections.Generic;
using System.Web;
using MVC_Shop.Core.ViewModels;


namespace MVC_Shop.Services
{
    public interface IBasketService
    {
        void AddToBasket(HttpContextBase httpContext, string productId);
        List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);
        void RemoveFromBasket(HttpContextBase httpContext, string itemId);
    }
}
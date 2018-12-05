using AppFidelidade.MobileAppService.Models;
using System;
using System.Collections.Generic;

namespace AppFidelidade.MobileAppService.Interfaces
{
    public interface IItemRepository
    {
        void Add(Item item);
        void Update(Item item);
        Item Remove(string key);
        Item Get(string id);
        IEnumerable<Item> GetAll();
    }
}

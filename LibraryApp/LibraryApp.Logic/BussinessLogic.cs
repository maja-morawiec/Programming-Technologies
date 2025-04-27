using System;
using LibraryApp.Data;

namespace LibraryApp.Logic
{
    public class BussinessLogic
    {
        private readonly IDataLayer _data;

        public BussinessLogic(IDataLayer dataLayer)
        {
            _data = dataLayer;
        }

        public void AddUser(int  id, string name)
        {
            _data.Users.Add(new Reader { Id = id, Name = name });
        }

        public void AddProduct(int id, string name, int quantity)
        {
            _data.Catalog[id] = new Book { Id = id, Name = name, Quantity = quantity };
        }

        public void RecordEvent(string description)
        {
            _data.Events.Add(new BorrowEvent
            {
                Id = _data.Events.Count + 1,
                Description = description,
                Timestamp = DateTime.Now
            });
        }

        public void BorrowProduct(int productId)
        {
            if (_data.Catalog.ContainsKey(productId) && _data.Catalog[productId].Quantity > 0)
            {
                _data.Catalog[productId].Quantity--;
                RecordEvent($"Product ID {productId} borrowed.");
            }
            else
            {
                throw new InvalidOperationException("Product unavailable.");
            }
        }

        public void ReturnProduct(int productId)
        {
            if (_data.Catalog.ContainsKey(productId))
            {
                _data.Catalog[productId].Quantity++;
                RecordEvent($"Product ID {productId} returned.");
            }
        }
    }
}

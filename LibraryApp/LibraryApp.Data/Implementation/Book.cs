﻿using LibraryApp.Data.API;

namespace LibraryApp.Data.Implementation
{
    internal class Book : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}

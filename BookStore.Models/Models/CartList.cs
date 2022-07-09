using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models
{
    public class CartList
    {
        public CartList() { }

        public CartList(Cart model)
        {
            Id = model.Id;
            UserId = model.Userid;
            Quantity = model.Quantity;
            BookId = model.Bookid;
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public int BookId { get; set; }
        public BookModel Book { get; set; }
        public int Quantity { get; set; }
    }
}

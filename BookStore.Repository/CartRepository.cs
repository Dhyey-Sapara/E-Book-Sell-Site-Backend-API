using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class CartRepository : BaseRepository
    {

        public List<CartList> GetCartItems(int id)
        {

            var query = _context.Carts.Where(c => c.Userid == id).ToList();
            List<CartList> carts = query.Select(c => new CartList(c)).ToList();
            for (int i = 0; i < carts.Count(); i++)
            {
                carts[i].Book = new BookModel(_context.Books.FirstOrDefault(c => c.Id == carts[i].BookId));
            }
            return carts;
        }

        //public List<Cart> GetCartItems(string keyword)
        //{
          //  keyword = keyword?.ToLower()?.Trim();
           // var query = _context.Carts.Include(c => c.Book).Where(c => keyword == null || c.Book.Name.ToLower().Contains(keyword)).AsQueryable();
            //return query.ToList();
        //}

        public Cart GetCarts(int id)
        {
            return _context.Carts.FirstOrDefault(c => c.Id == id);
        }

        public Cart AddCart(Cart cart)
        {
            var query = _context.Carts.FirstOrDefault(c => c.Bookid == cart.Bookid && c.Userid == cart.Userid);
            if (query == null)
            {
                var entry = _context.Carts.Add(cart);
                _context.SaveChanges();
                return entry.Entity;
            }
            else
            {
                return null;
            }
        }

        public Cart UpdateCart(Cart category)
        {
            var entry = _context.Carts.Update(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteCart(int id)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);
            if (cart == null)
                return false;

            _context.Carts.Remove(cart);
            _context.SaveChanges();
            return true;
        }
    }
}

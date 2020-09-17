using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabsV05.Entities;

namespace lab1.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Количество калорий
        /// </summary>
        public int AutoCost
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
                item.Value.Auto.AutoCost);
            }
        }
        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="auto">добавляемый объект</param>
        public virtual void AddToCart(Auto auto)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(auto.AutoId))
                Items[auto.AutoId].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(auto.AutoId, new CartItem
                {
                    Auto = auto,
                    Quantity = 1
                });
        }
        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Auto Auto { get; set; }
        public int Quantity { get; set; }
    }
}
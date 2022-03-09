using OnlineStore.BLL.ViewModels.Category;
using OnlineStore.BLL.ViewModels.FeedBack;
using OnlineStore.BLL.ViewModels.ProductImage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.ViewModels.Product
{
    public class GetProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InventoryQuantity { get; set; }
        public int? CategoryId { get; set; }
        public string ImagePath { get; set; }
        public ICollection<GetProductImageViewModel> ProductImages { get; set; }
        public  GetCategoryViewModel Category { get; set; }
        public decimal TotalRating
        {
            get
            {
                if (FeedBacks.Any())
                {
                    return (FeedBacks.Average(x => x.Rate));
                }

                return 0;
            }

        }
        public ICollection<GetFeedBackViewModel> FeedBacks { get; set; }

    }
}

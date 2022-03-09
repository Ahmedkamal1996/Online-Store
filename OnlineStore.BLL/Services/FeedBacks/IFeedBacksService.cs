using System.Collections.Generic;
using OnlineStore.BLL.ViewModels.FeedBack;
using OnlineStore.DAL.Models.FeedBacks;

namespace OnlineStore.BLL.Services.FeedBacks
{
    public interface IFeedBacksService
    {

        ICollection<GetFeedBackViewModel> GetFeedBacks();
        GetFeedBackViewModel GetFeedBackById(int feedBackId);
        GetFeedBackViewModel GetFeedBackByUserId(string userId);
        GetFeedBackViewModel GetFeedBackByProductId(int productId);
        GetFeedBackViewModel Add(CreateFeedBackViewModel model);
        bool Update(UpdateFeedBackViewModel model);
        bool Delete(int feedBackId);

        //ICollection<FeedBack> GetFeedBack();
        //FeedBack GetFeedBackById(int feedbackId);
        //void Add(FeedBack feedBack);
        //void Update(FeedBack feedBack);
        //void Delete(int feedbackId);
    }
}

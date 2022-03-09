using AutoMapper;
using OnlineStore.BLL.ViewModels.FeedBack;
using OnlineStore.DAL.Database;
using System.Collections.Generic;
using System.Linq;
using OnlineStore.DAL.Models.FeedBacks;
using System.Data.Entity;

namespace OnlineStore.BLL.Services.FeedBacks
{
    public class FeedBacksService : IFeedBacksService
    {
        private readonly OnlineStoreDbContext _context;

        public FeedBacksService(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public GetFeedBackViewModel Add(CreateFeedBackViewModel model)
        {
            var feedBack = Mapper.Map<FeedBack>(model);

            _context.FeedBacks.Add(feedBack);

            return _context.SaveChanges() > 0 ? Mapper.Map<GetFeedBackViewModel>(feedBack) : null;
        }

        public bool Delete(int feedBackId)
        {
            var feedBack = _context.FeedBacks.Find(feedBackId);
            if (feedBack==null)
            {
                return false;
            }
            _context.FeedBacks.Remove(feedBack);
            return _context.SaveChanges()>0;
        }

        public GetFeedBackViewModel GetFeedBackById(int feedBackId)
        {
            var feedBack = _context.FeedBacks.Find(feedBackId);

            return feedBack == null ? null : Mapper.Map<GetFeedBackViewModel>(feedBack);
        }

        public GetFeedBackViewModel GetFeedBackByProductId(int productId)
        {
            var feedBack = _context.FeedBacks.Where(z => z.ProductId == productId);
            return feedBack == null ? null : Mapper.Map<GetFeedBackViewModel>(feedBack);
        }

        public GetFeedBackViewModel GetFeedBackByUserId(string userId)
        {
            var feedBack = _context.FeedBacks.Where(z => z.UserId == userId);
            return feedBack == null ? null : Mapper.Map<GetFeedBackViewModel>(feedBack); 
        }

        public ICollection<GetFeedBackViewModel> GetFeedBacks()
        {
            var feedBacks = _context.FeedBacks.ToList();
            return Mapper.Map<ICollection<GetFeedBackViewModel>>(feedBacks);
        }

        public bool Update(UpdateFeedBackViewModel model)
        {
            var oldValue = _context.FeedBacks.Find(model.Id);
            if (oldValue == null)
            {
                return false;
            }
            Mapper.Map(model, oldValue);

            _context.Entry(oldValue).State = EntityState.Modified;

            return _context.SaveChanges() > 0;
        }






        //public void Add(FeedBack feedBack)
        //{
        //    _context.FeedBack.Add(feedBack);
        //    _context.SaveChanges();
        //}

        //public void Delete(int feedbackId)
        //{
        //    var feedback = _context.FeedBack.Find(feedbackId);
        //    _context.FeedBack.Remove(feedback);
        //    _context.SaveChanges();
        //}

        //public ICollection<FeedBack> GetFeedBack()
        //{
        //    var feedback = _context.FeedBack.ToList();
        //    return feedback;
        //}

        //public FeedBack GetFeedBackById(int feedbackId)
        //{
        //    var feedback = _context.FeedBack.Find(feedbackId);
        //    return feedback;
        //}

        //public void Update(FeedBack feedBack)
        //{
        //    var oldfeedback = _context.FeedBack.Find(feedBack.Id);
        //    _context.Entry(oldfeedback).CurrentValues.SetValues(feedBack);
        //    _context.SaveChanges();
        //}
    }
}

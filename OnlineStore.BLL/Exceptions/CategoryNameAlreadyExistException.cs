using System;

namespace OnlineStore.BLL.Exceptions
{
    public class CategoryNameAlreadyExistException : Exception
    {
        public CategoryNameAlreadyExistException() : base("Category is already exist")
        {
            
        }
    }
}
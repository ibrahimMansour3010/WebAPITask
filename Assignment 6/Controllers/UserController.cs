using Assignment_6.Result;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModels;

namespace Assignment_6.Controllers
{
    public class UserController : ApiController
    {
        IUnitOfWork UnitOfWork;
        IMainRepo<User> UserRepo;
        WebApiResult Result;
        public UserController(IUnitOfWork _UinteOfWord)
        {
            UnitOfWork = _UinteOfWord;
            UserRepo = UnitOfWork.GetUserRepo();
            Result = new WebApiResult();
        }
        [HttpGet]
        public WebApiResult Get()
        {
            Result.Data = UserRepo.Get();
            return Result;
        }
        [HttpGet]
        public WebApiResult Get(int id)
        {
            Result.Data = UserRepo.Get(id);
            return Result;
        }
        [HttpPut]
        public WebApiResult Put(AddUserModel addUserModel)
        {
            UserRepo.Add(addUserModel.ToUser());
            UnitOfWork.Save();
            return Result;
        }
        [HttpDelete]
        public WebApiResult Delete(int id)
        {
            UserRepo.Delete(new User() { ID=id});
            UnitOfWork.Save();
            return Result;
        }
        [HttpPut]
        public WebApiResult Edit(User user)
        {
            UserRepo.Edit(user);
            UnitOfWork.Save();
            return Result;
        }
    }
}

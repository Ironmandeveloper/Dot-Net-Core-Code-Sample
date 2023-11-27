using DataModels.DAL;
using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Services.AuthServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AnonymousUsersServices
{
    public class AnonymousUsersService : IAnonymousUsersService
    {
       
        public AnonymousUsersService()
        {
        }

        //public async Task<string> Create(AnonymousUsers user)
        //{
        //    var res=await _context.AnonymousUsers.AddAsync(new AnonymousUsers { 
        //    CreatedOn=DateTime.Now,
        //    UpdatedOn=DateTime.Now,
        //    Email=user.Email,
        //    Password=user.Password,
        //    IsActive=true,
        //    IsDeleted=false,
        //    UserName=user.UserName,
        //    CreatedBy="",
        //    UpdatedBy="",
        //    PhoneNum=user.PhoneNum,
        //    Address=user.Address
        //    });
        //    await _context.SaveChangesAsync();
        //    return res.Entity.Id.ToString();
        //}

        //public async Task<string> Signin(string UserName, string Password)
        //{
        //    var obj = await _context.AnonymousUsers.Where(x => x.Email.Equals(UserName)).FirstOrDefaultAsync();
        //    if (obj != null) {
        //    if (_context.AnonymousUsers.Where(x => x.Email.Equals(UserName) && _authService.VerifyPassword(obj.Password, Password)).Count()>0)
        //        {
        //            return obj.Id.ToString();
        //        } }
        //    return "Invalid login attempt";
            
        //}
    }
}

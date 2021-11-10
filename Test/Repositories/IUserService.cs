using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;


namespace Test.Repositories
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(User model);

        Task<UserManagerResponse> LoginUserAsync(User model);

        Task<UserManagerResponse> RecordAsync(ComplaintModel model);

        //Task<UserManagerResponse> GetStatusAsync(int Id);

        Task<UserManagerResponse> PutStatusAsync(ComplaintModel model);
    }



    public class UserService : IUserService
    {

        private readonly TestDbContext _context;

        public UserService(TestDbContext context)
        {
            _context = context;
        }


        private UserManager<IdentityUser> _userManger;
        private IConfiguration _configuration;


        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManger = userManager;
            _configuration = configuration;

        }

        public async Task<UserManagerResponse> RegisterUserAsync(User model)
        {
            if (model == null)
                throw new NullReferenceException("Reigster Model is null");

            var check = _context.Users.FirstOrDefault(s => s.NationalCode == model.NationalCode);
            if (check == null)
            {
                _context.Users.Add(model);
                await _context.SaveChangesAsync();
                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                };

            }
            else
            {
                return new UserManagerResponse
                {
                    Message = "NationalCode already exists",
                    IsSuccess = false,
                };
            }


            

        }

        public async Task<UserManagerResponse> LoginUserAsync(User model)
        {

            var user = await _context.Users.FirstOrDefaultAsync(i => i.NationalCode == model.NationalCode && i.Pass == model.Pass);


            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that NationalCode",
                    IsSuccess = false,
                };
            }

           
            return new UserManagerResponse
            {

                IsSuccess = true,
                ID = user.Id
            };


        }


        public async Task<UserManagerResponse> RecordAsync(ComplaintModel model)
        {

            if (model == null)
                throw new NullReferenceException("Reigster Model is null");

            var check = _context.ComplaintModels.FirstOrDefault(s => s.Title == model.Title);
            if (check == null)
            {
                _context.ComplaintModels.Add(model);
                await _context.SaveChangesAsync();
                return new UserManagerResponse
                {
                    Message = "Complaint created successfully!",
                    IsSuccess = true,
                };

            }
            else
            {
                return new UserManagerResponse
                {
                    Message = "NationalCode already exists",
                    IsSuccess = false,
                };
            }
        }



        public async Task<UserManagerResponse> GetStatusAsync(long Id)
        {
            if (Id == 0)
            {
                return new UserManagerResponse
                {

                    IsSuccess = false,
                };
            }
            var obj = await _context.ComplaintModels.FindAsync(Id);
            if (obj == null)
            {
                return new UserManagerResponse
                {
                    Message = "Complaint does not exists",
                    IsSuccess = false,
                };
            }

            return new UserManagerResponse
            {
                Message = "Complaint does not exists",
                IsSuccess = true,
                model = obj
            };
        }



        public async Task<UserManagerResponse> PutStatusAsync(ComplaintModel obj)
        {
            if (obj == null)
                throw new NullReferenceException("Post Model is null");

            var entity = _context.ComplaintModels.FirstOrDefault(e => e.Id == obj.Id);
            //await _context.ComplaintModels.Update(obj);
            if (entity != null)
            {
                entity.Title = obj.Title;
                entity.Text = obj.Text;
                entity.Status = obj.Status;

                await _context.SaveChangesAsync();


                return new UserManagerResponse
                {
                    Message = "Complaint created successfully!",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "Complaint not exists",
                IsSuccess = false,
            };

        }
    }
}


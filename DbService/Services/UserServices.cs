using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbServices.Base;
using Entities.Models;
using Interfaces.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Interfaces.ViewModel.UserVM;
using Interfaces.Helpers;

namespace DbServices.Services
{
    public class UserServices : BaseService, IUser
    {
        private readonly DbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly ICoreBase _repoCore;


        public UserServices(DbContext context, UserManager<Users> userManager, ICoreBase repoCore)
        {
            _context = context;
            _repoCore = repoCore;
            _userManager = userManager;
        }



        //public async Task<IList<Users>> GetAllUsesWithRoleAdmin()
        //{
        //    var users = await _userManager.GetUsersInRoleAsync("Admin");

        //    return users;
        //}


        //public async Task<IList<Users>> GetAllUsesWithRoleUser()
        //{
        //    var users = await _userManager.GetUsersInRoleAsync("User");

        //    return users;
        //}

        //public async Task<Users> GetUserById(string userId)
        //{
        //    var user = await _context.Users
        //        .SingleOrDefaultAsync(c => c.Id == userId);

        //    return user;
        //}

        //public async Task<UserContractDetailsViewModel> GetUserContractDetails(string userId, int id, UserParams _params)
        //{
        //    var userContract = await _context.Contracts
        //        .Include(c => c.ContractType)
        //        .SingleOrDefaultAsync(c => c.UserId == userId && c.Id == id);

        //    var model = new UserContractDetailsViewModel()
        //    {
        //        Id = id,
        //        ElvatorName = _params.Lang == "en" ? userContract.ElvatorNameEn : userContract.ElvatorNameAr,
        //        ContractType = userContract.ContractType.Name,
        //        StartDate = DateTime.Parse(userContract.DateofBeginningTheContract).ToString("dd/MM/yyyy"),
        //        EndDate = DateTime.Parse(userContract.DateofEndTheContract).ToString("dd/MM/yyyy"),
        //        MaintenanceVisits = userContract.NumOfVisites,
        //        CompensatoryVisits = userContract.NumberOfExtraVisist,
        //        ElvatorsCount = userContract.NumOfElvators
        //    };

        //    return model;
        //}


        //public async Task<UserProfileDetails> GetUserProfile(string userId, UserParams _params)
        //{
        //    var user = await _context.Users
        //        .SingleOrDefaultAsync(c => c.Id == userId);

        //    var userBranch = await _context.Branchs.SingleOrDefaultAsync(c => c.Id == user.BrachId);

        //    var userContracts = await _context.Contracts.Where(c => c.UserId == userId).ToListAsync();

        //    var userContractsModel = new List<UserContractsViewModel>();

        //    foreach (var userContract in userContracts)
        //    {
        //        var tempModel = new UserContractsViewModel()
        //        {
        //            Id = userContract.Id,
        //            ElevatorName = _params.Lang == "en" ? userContract.ElvatorNameEn : userContract.ElvatorNameAr,
        //            MaintenanceNumber = userContract.NumOfVisites
        //        };

        //        userContractsModel.Add(tempModel);
        //    }

        //    var model = new UserProfileDetails()
        //    {
        //        Branch = _params.Lang == "en" ? userBranch.NameEn : userBranch.NameAr,
        //        Email = user.Email,
        //        Name = user.Name,
        //        Phone = user.Name,
        //        UserContracts = userContractsModel
        //    };

        //    return model;
        //}

        //public async Task<bool> CreateComplaintByUser(string userId, int id, CreateComplaintByUserViewModel model)
        //{
        //    var newTechTask
        //}
    }
}

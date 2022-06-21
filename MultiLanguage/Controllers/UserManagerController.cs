using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiLanguage.Core.PublicClasses.Repository.Interfaces;
using MultiLanguage.Core.ViewModels;
using Multipisus.DataLayer.Entities;

namespace MultiLanguage.Controllers
{
    public class UserManagerController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly INotyfService _notify;
        private readonly IMapper _mapper;

        public UserManagerController(IUnitOfWork context,INotyfService noty , IMapper mapper)
        {
            _context = context;
            _notify = noty;
            _mapper = mapper;
        }

        //list of user
        public async Task<IActionResult> Index()
        {

            var user = await _context.UsermanagerUW.GetEntitiesAsync();
            return View(user);
        }
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserViewModels model)
        {
            var user = new ApplicationUser
            {
              Name=model.Name,
              LastName=model.LastName,
              UserImg=model.UserImg,
              Department=model.Department,
              IsActive=model.IsActive,
              IsDelete = false,
            };
            await _context.UsermanagerUW.Create(user);
            await _context.saveAsync();
            _notify.Success("You successfuly Added  a new user !", 5);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Detials(string id)
        {
            var user = await _context.UsermanagerUW.GetByIdAsync(id);
            return View(user);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.UsermanagerUW.GetByIdAsync(id);
            if (user.IsDelete)
            {
                ViewBag.Message = "You are actvating this Category!";
            }
            else
            {
                ViewBag.Message = "You are InActvating this Category! , you can always undo";
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDelete)
                {
                    model.IsDelete = false;
                }
                else
                {
                    model.IsDelete = true;
                }
                _context.UsermanagerUW.Update(model);
                await _context.saveAsync();
                _notify.Success("You successfuly changed the user status   !", 5);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _context.UsermanagerUW.GetByIdAsync(id);
            var mapUser = _mapper.Map<UserViewModels>(user);
            return View(mapUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserViewModels model)
        {

return View(model); 
        }


    }
}

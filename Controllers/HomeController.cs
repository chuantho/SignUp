using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignUp.Models;
using SignUp.ViewModel;

namespace SignUp.Controllers
{
    public class HomeController : Controller
    {

        private IWebHostEnvironment _env;
       
        public HomeController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel()
            {
                Activities = new Activities
                {
                    AvailableActivities = GetActivities()
                }
            };

            return View(viewModel);
        }

        private List<Activity> GetActivities()
        {
            string filePath = System.IO.Path.Combine(_env.WebRootPath, "Activities.txt");
            return System.IO.File.ReadAllText(filePath).Split(new char[] { ',' }).ToList().Select(x => new Activity() { Name = x }).ToList();
        }

        public ActionResult InterestedPeople(HomeViewModel viewModel)
        {
            if (viewModel.Activities.AvailableActivities.Where(x => x.Selected).Count() > 0)
            {
                viewModel.SignUpActivity.Activities = new List<string>();
                viewModel.SignUpActivity.Activities.AddRange(viewModel.Activities.AvailableActivities.Where(x => x.Selected).Select(x => x.Name));
                ModelState["SignUpActivity.Activities"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
            }

            if (ModelState.IsValid)
            {
                string filePath = System.IO.Path.Combine(_env.WebRootPath, "InterestedPeople.txt");

                List<SignUpActivity> interestedPeople = null;
                if (System.IO.File.Exists(filePath))
                {
                    interestedPeople = JsonConvert.DeserializeObject<List<SignUpActivity>>(System.IO.File.ReadAllText(filePath));
                }
                else
                {
                    interestedPeople = new List<SignUpActivity>();
                }


                interestedPeople.Add(viewModel.SignUpActivity);


                System.IO.File.WriteAllText(filePath, JsonConvert.SerializeObject(interestedPeople));


                return View("InterestedPeople", interestedPeople);
            }
            else
            {
                return View("Index", viewModel);
            }
        }
    }
}

using AutoMapper;
using Business_Layer;
using Business_Layer.Models;
using MVC_Git.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Git.Controllers
{
    public class HomeController : Controller
    {
        MapperConfiguration config;
        IMapper mapper;
        BLL_Layer bLL_Layer;
        public HomeController()
        {
            bLL_Layer = new BLL_Layer();
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Authers_VM, Author_DTO>();
             

            });
            mapper = config.CreateMapper();
        }
        public ActionResult Index()
        {
            List<Authers_VM> authorsVM = new List<Authers_VM>();
            var authers = bLL_Layer.GetAuthors_BLL();
            foreach(var auther in authers)
            {
                Authers_VM avm = new Authers_VM();
                avm.state = auther.state;
                avm.phone = auther.phone;
                avm.address = auther.address;
                avm.contract = auther.contract;
                avm.zip = auther.zip;
                avm.au_fname = auther.au_fname;
                avm.au_lname = auther.au_lname;
                avm.au_id = auther.au_id;
                avm.city = auther.city;
                authorsVM.Add(avm);
            }
            return View("Index",authorsVM);
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Your Create page.";

            return View();
        }
        [HttpPost]
        public ActionResult Create(Authers_VM author)
        {
           // Author_DTO authorDTO = new Author_DTO();
            var _authorDTO = mapper.Map<Authers_VM, Author_DTO>(author);
             bLL_Layer.AddAuthors_BLL(_authorDTO);
            ViewBag.Success = "Added Successfully";
            return View("Create_success",author);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
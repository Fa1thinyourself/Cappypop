﻿using System.Diagnostics;
using System.Reflection;
using CappypopMVC.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using CappypopMVC.Models;
using Supabase;

namespace CappypopMVC.Controllers;

public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly Client supabase;

        public AdminController(ILogger<AdminController> logger, Client client)
        {
            _logger = logger;
            supabase = client;
        }
    public IActionResult Index()
    {
        var user = supabase.From<Users>().Where(u => u.UserUid == supabase.Auth.CurrentUser.Id).Get();
        if (user == null){
            return NotFound();
        }
        return View(user);
    }
}

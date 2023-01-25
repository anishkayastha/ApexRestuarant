using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
//using Microsoft.AspNetCore.Cors;

namespace ApexRestaurant.Api.Controller
{
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index() {
            // get base_uri, e.g. https://localhost:5001
            var base_uri = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            // available api endpoints list
            var endpoints = new List<string>{"customer", "meal", "mealdish", "menu", "menuitem", "staff", "staffrole"};

            // taag (text to ascii art generator)
            var api_is_working = @"
  _____ _               _    ____ ___   _                          _    _             
 |_   _| |__   ___     / \  |  _ \_ _| (_)___  __      _____  _ __| | _(_)_ __   __ _ 
   | | | '_ \ / _ \   / _ \ | |_) | |  | / __| \ \ /\ / / _ \| '__| |/ / | '_ \ / _` |
   | | | | | |  __/  / ___ \|  __/| |  | \__ \  \ V  V / (_) | |  |   <| | | | | (_| |
   |_| |_| |_|\___| /_/   \_\_|  |___| |_|___/   \_/\_/ \___/|_|  |_|\_\_|_| |_|\__, |
                                                                                |___/ 

            ";

            // construct text to display by default
            var api_text = "";
            foreach (var endpoint in endpoints)
            {
                api_text += Environment.NewLine + $"{base_uri}/api/{endpoint}";
            }

            // return Ok (status code 200)
            return Ok(api_is_working + api_text);
        }
    }
}
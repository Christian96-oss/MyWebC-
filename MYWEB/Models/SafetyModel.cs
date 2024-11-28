using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;

namespace MYWEB.Models
{
    public class SafetyModel
    {
        public string? count { get; set; }
        public string Text { get; set; }
        public string Id { get; set; }
        public int id_so { get; set; }
        public string sesa_id { get; set; }
        public string happen { get; set; }
        public string locations { get; set; }
        public string sector { get; set; }
        public string pic_before { get; set; }
        public string pic_after { get; set; }
        public string issue { get; set; }
        public string founder { get; set; }
        public string category { get; set; }
        public string sites { get; set; }
        public string areas { get; set; }
        public string specs { get; set; }
        public string family { get; set; }
        public string roots { get; set; }
        public string injury { get; set; }
        public string actionplan { get; set; }
        public string pic { get; set; }
        public string timeline { get; set; }
        public string done { get; set; }
        public string status { get; set; }
        public string plant { get; set; }
        public IFormFile File { get; set; }
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot : Identification
    {
        private string id;

        public Robot(string model, string id) : base(model, id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
    }
}
using System.Collections.Generic;

namespace BorderControl
{
    public class Robot : IIdentification
    {
        private List<Robot> robots = new List<Robot>();

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Id { get; set; }
        public string Model { get; set; }
    }
}